using Bitwarden.Desktop.AutoFill.UI.AppSettings;
using Bitwarden.Desktop.AutoFill.UI.Bitwarden;

namespace Bitwarden.Desktop.AutoFill.UI;

public partial class SettingsForm : Form, IDisposable
{
    private Keys[] _desiredCombination;
    private Keys[] _recordedCombination = [];
    private bool _shouldRecordCombination;
    private readonly List<Keys> _actualCombination = [];
    private readonly GlobalKeyboardHook _globalKeyboardHook;

    public Settings Settings { get; init; } = null!;

    public SettingsForm()
    {
        InitializeComponent();
        _lblChangeKeyStrokeInfo.Text = "";
        _globalKeyboardHook = new GlobalKeyboardHook();
        _globalKeyboardHook.KeyboardPressed += OnKeyPressed;
    }

    private void HandleFormLoad(object sender, EventArgs e)
    {
        _notifyIcon.Visible = true;

        // Fill form fields
        FillFormFields();
        MinimizeToTray();
    }

    private void FillFormFields()
    {
        _btnSave.Enabled = false;
        _txtBitwardenUri.Text = Settings.BitwardenUri;
        _txtBitwardenEmail.Text = Settings.BitwardenEmail;
        _txtBitwardenPassword.Text = Settings.BitwardenPassword.Read();
        _checkStoreMasterPassword.Checked = Settings.StorePassword;
        _desiredCombination = Settings.Combination;

        DisplayCombination();
    }

    private void DisplayCombination()
    {
        _txtKeyStroke.Text = "";
        if (_shouldRecordCombination)
        {
            _txtKeyStroke.Text = string.Join(" + ", _actualCombination.Select(_globalKeyboardHook.GetHumanReadableKeyName));
        }
        else
        {
            _txtKeyStroke.Text = string.Join(" + ", _desiredCombination.Select(_globalKeyboardHook.GetHumanReadableKeyName));
        }
    }

    private void OnKeyPressed(object? sender, GlobalKeyboardHookEventArgs e)
    {
        if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.SysKeyDown ||
            e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
        {
            if (_actualCombination.Contains(e.KeyboardData.Key))
            {
                return;
            }
            _actualCombination.Add(e.KeyboardData.Key);

            if (_shouldRecordCombination)
            {
                DisplayCombination();
            }

            var isCombinationHit = _desiredCombination.All(_actualCombination.Contains);
            if (!_shouldRecordCombination && isCombinationHit)
            {
                ShowAutoFill();
            }
        }

        if ((e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyUp ||
                e.KeyboardState == GlobalKeyboardHook.KeyboardState.SysKeyUp)
            && _actualCombination.Count > 0)
        {
            if (_shouldRecordCombination)
            {
                _recordedCombination = _actualCombination.ToArray();
            }

            _actualCombination.Clear();
        }
    }

    private void ShowAutoFill()
    {
        var info = NativeApi.GetForegroundWindowInfo();
        Console.WriteLine($"Current active window: {info.Title}");
        Console.WriteLine($"Active Window handle: {info.Handle}");
        Console.WriteLine($"Focus Gui Handle: {info.GuiThreadInfo.hwndFocus}");
        Console.WriteLine($"Active Gui Handle: {info.GuiThreadInfo.hwndActive}");
        Console.WriteLine($"Caret hwnd: {info.GuiThreadInfo.hwndCaret}");
        Console.WriteLine($"Caret position (client): {info.CaretPositionClient.X},{info.CaretPositionClient.Y}");
        Console.WriteLine($"Caret position (screen): {info.CaretPositionScreen.X},{info.CaretPositionScreen.Y}");
        AutoFillForm.Open(info, Settings);
    }

    ~SettingsForm()
    {
        Dispose();
    }

    public new void Dispose()
    {
        _globalKeyboardHook.Dispose();
        GC.SuppressFinalize(this);
    }

    private void HandleKeyStrokeChange(object sender, EventArgs e)
    {
        if (_shouldRecordCombination)
        {
            _shouldRecordCombination = false;
            _desiredCombination = _recordedCombination;
            _btnChangeKeyStroke.Text = "Change";
            _lblChangeKeyStrokeInfo.Text = "";
            DisplayCombination();

            // Store combination in settings
            Settings.Combination = _desiredCombination;
            Settings.Save();
        }
        else
        {
            _shouldRecordCombination = true;
            _btnChangeKeyStroke.Text = "Save";
            _lblChangeKeyStrokeInfo.Text = "Press your desired combination now...";
        }
    }

    private void MinimizeToTray()
    {
        _notifyIcon.ShowBalloonTip(500);
        ShowInTaskbar = false;
        Hide();
    }

    private void MaximizeFromTray()
    {
        ShowInTaskbar = true;
        Show();
        BringToFront();
    }

    private void HandleTrayIconClick(object sender, MouseEventArgs e)
    {
        MaximizeFromTray();
    }

    private void HandleFormMinimize(object sender, EventArgs e)
    {
        if (WindowState == FormWindowState.Minimized)
        {
            MinimizeToTray();
        }
    }

    private void HandleFormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            MinimizeToTray();
            e.Cancel = true;
        }
    }

    private void ActivateSaveButton()
    {
        _btnSave.Enabled = true;
    }

    private void HandleTextChange(object sender, EventArgs e)
    {
        if (_txtBitwardenUri.Text != Settings.BitwardenUri
            || _txtBitwardenEmail.Text != Settings.BitwardenEmail
            || _checkStoreMasterPassword?.Checked != Settings.StorePassword)
        {
            ActivateSaveButton();
        }
    }

    private void HandleSaveSettings(object? sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(_txtBitwardenPassword.Text))
        {
            Settings.BitwardenPassword.Set(_txtBitwardenPassword.Text);
        }

        Settings.StorePassword = _checkStoreMasterPassword.Checked;
        Settings.BitwardenUri = _txtBitwardenUri.Text;
        Settings.BitwardenEmail = _txtBitwardenEmail.Text;

        Settings.Save();
        MinimizeToTray();
    }

    private void HandleQuit(object sender, EventArgs e)
    {
        var result = MessageBox.Show(
            "Do you really want to quit the application?",
            "Quit Bitwarden Desktop Autofill",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );
        if (result == DialogResult.Yes)
        {
            Application.Exit();
        }
    }

    private void HandleReload(object sender, EventArgs e)
    {
        BitwardenClient.Reset();
        Settings.BitwardenPassword.Forget();
        Settings.Reload();
        FillFormFields();
    }
}