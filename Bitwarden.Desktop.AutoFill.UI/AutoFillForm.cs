using System.Text.Json;
using Bitwarden.Desktop.AutoFill.UI.AppSettings;
using Bitwarden.Desktop.AutoFill.UI.Bitwarden;

namespace Bitwarden.Desktop.AutoFill.UI;

public partial class AutoFillForm : Form
{
    private Settings Settings { get; init; }

    private NativeApi.WindowInfo TargetWindowInfo { get; init; }
    private CredentialItem[] _credentialItems = [];
    private int _selectedIndex = -1;
    private const int WindowWidth = 450;
    private const int WindowHeight = 140;
    private readonly Label _statusLabel = new();

    private AutoFillForm()
    {
        InitializeComponent();

        // Create loading label to dynamically add/remove it to panel.
        _statusLabel.AutoSize = false;
        _statusLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        _statusLabel.TextAlign = ContentAlignment.MiddleCenter;
        _statusLabel.Dock = DockStyle.Fill;
    }

    ~AutoFillForm()
    {
        _credentialItems.ToList().ForEach(
            i =>
            {
                i.Click -= HandleItemClick;
                i.DoubleClick -= HandleAutoFillItem;
            });
    }

    public static void Open(NativeApi.WindowInfo windowInfo, Settings settings)
    {
        var form = new AutoFillForm()
        {
            TargetWindowInfo = windowInfo,
            StartPosition = FormStartPosition.CenterScreen,
            Settings = settings
            // StartPosition = FormStartPosition.Manual,
            // Top = windowInfo.CaretPositionScreen.Y + 25,
            // Left = windowInfo.CaretPositionScreen.X
        };

        form.Show();
    }

    private CredentialItem CreateCredentialItem(Credential credential)
    {
        var item = new CredentialItem()
        {
            Credential = credential,
            Dock = DockStyle.Top
        };

        item.Click += HandleItemClick;
        item.DoubleClick += HandleAutoFillItem;

        return item;
    }

    private void HandleItemClick(object? sender, EventArgs e)
    {
        if (sender is CredentialItem item)
        {
            SelectItem(item);
        }
    }

    private void HandleAutoFillItem(object? sender, EventArgs e)
    {
        if (sender is CredentialItem item)
        {
            SelectItem(item);
            if (item.Credential != null)
            {
                var result = NativeApi.AutoFillCredential(item.Credential, TargetWindowInfo);
                if (!result.Success)
                {
                    ShowStatus(result.Message, Color.OrangeRed);
                }
                else
                {
                    Close();
                }
            }
        }
    }

    private void SelectItem(CredentialItem item)
    {
        _credentialItems.ToList().ForEach(i => i.SetSelected(false));
        item.SetSelected(true);
        _selectedIndex = _credentialItems.ToList().FindIndex(i => i.Id == item.Id);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Escape)
        {
            Console.WriteLine($"Escape detected - closing autofill form...");
            Close();
        }
        if (keyData == Keys.Enter && _selectedIndex >= 0)
        {
            Console.WriteLine($"Enter detected - start filling...");
            HandleAutoFillItem(_credentialItems[_selectedIndex], EventArgs.Empty);
        }
        if (keyData == Keys.Up)
        {
            Console.WriteLine($"Up detected...");
            // Natural "down" implementation, reverse due to panel's dock=top setting...
            var index = Math.Min(_selectedIndex + 1, _credentialItems.Length - 1);
            if (index < _credentialItems.Length)
            {
                var item = _credentialItems[index];
                SelectItem(item);
            }
        }
        if (keyData == Keys.Down)
        {
            Console.WriteLine($"Down detected...");
            // Natural "up" implementation, reverse due to panel's dock=top setting...
            var index = Math.Max(_selectedIndex - 1, 0);
            if (index < _credentialItems.Length)
            {
                var item = _credentialItems[index];
                SelectItem(item);
            }
        }

        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void HandleFormLoad(object sender, EventArgs e)
    {
        if (!Settings.BitwardenPassword.Exists())
        {
            var passwordControl = new EnterPasswordControl();
            passwordControl.PasswordSet = pw =>
            {
                _credentialsPanel.Controls.Remove(passwordControl);
                _credentialsPanel.Focus();
                Settings.BitwardenPassword.Set(pw);
                FetchSecrets();
            };
            passwordControl.Cancel = () =>
            {
                _credentialsPanel.Controls.Remove(passwordControl);
                Close();
            };

            _credentialsPanel.Controls.Add(passwordControl);
        }
        else
        {
            FetchSecrets();
        }
    }

    private void ShowStatus(string text, Color? color = null)
    {
        if (InvokeRequired)
        {
            Invoke(() => ShowStatus(text, color));
            return;
        }
        _credentialsPanel.Controls.Clear();
        Size = new Size(WindowWidth, WindowHeight);
        _statusLabel.Text = text;
        _statusLabel.ForeColor = color ?? Color.FromArgb(171, 164, 170);
        _credentialsPanel.Controls.Add(_statusLabel);
    }

    private AutoFillInfo? TryParseAutoFillInfo(string input)
    {
        try
        {
            var info = JsonSerializer.Deserialize<AutoFillInfo>(input);
            if (info != null)
            {
                Console.WriteLine($"Successful parsed input: {input}");
                return info;
            }
        }
        catch
        {
            // Do Nothing
        }
        return null;
    }

    private Task FetchSecretsAsync()
    {
        Credential[] credentials;
        var windowTitle = TargetWindowInfo.Title;
        try
        {
            var client = BitwardenClient.GetClient();
            var items = client.ListItems();
            credentials = items
                // Filter items matching to windows title
                .Where(i => i.login != null && i.login.uris.Count > 0)
                .SelectMany(item => 
                    item.login!.uris
                        // Try to convert each uri into autofill info object
                        .Select(uri => TryParseAutoFillInfo(uri.uri))
                        .Where(i => i != null && !string.IsNullOrWhiteSpace(i.Keys))
                        .Where(i => 
                            {
                                Console.WriteLine($"Try matching '{windowTitle}' with '{i.Search}'...");
                                var match =
                                    // Window title contains search string - where neither search string is empty nor window title is empty
                                    (!string.IsNullOrWhiteSpace(windowTitle) && !string.IsNullOrWhiteSpace(i.Search) && windowTitle.Contains(i.Search))
                                    // Trimmed title equals search
                                    || windowTitle.Trim() == i.Search.Trim();
                                if (match)
                                {
                                    Console.WriteLine($"Matched credentials - Window: '{windowTitle}' | Search: '{i.Search}'");
                                }

                                return match;
                            }
                        )
                        .Select(i => new Credential()
                        {
                            Name = item.name,
                            Password = item.login.password,
                            Username = item.login.username,
                            AutoFillInfo = i,
                            Description = item.notes
                        })
                )
                .ToArray();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());

            ShowStatus("Error: Can't connect or authorize at Bitwarden API. Incorrect password?\nPress ESC to close.", Color.OrangeRed);
            Program.ResetPassword();
            return Task.CompletedTask;
        }

        if (credentials.Length <= 0)
        {
            Console.WriteLine($"No credentials found. Search: {windowTitle}");
            ShowStatus($"No credentials found for window\n\"{windowTitle}\"\nPress ESC to close.", Color.OrangeRed);
            return Task.CompletedTask;
        }

        var windowHeight = 10 + CredentialItem.CredentialItemHeight * credentials.Length;

            
        _credentialItems = credentials.Select(CreateCredentialItem).Reverse().ToArray();

        Invoke(
            () =>
            {
                Size = new Size(WindowWidth, windowHeight);
                _credentialsPanel.Controls.Clear();
                _credentialsPanel.Controls.AddRange(_credentialItems.Select(i => i as Control).ToArray());
                if (_credentialItems.Length > 0)
                {
                    SelectItem(_credentialItems.Last());
                }
                NativeApi.SetForegroundWindow(Handle);
            }
        );

        return Task.CompletedTask;
    }

    private void FetchSecrets()
    {
        ShowStatus("Loading...");
        Task.Run(FetchSecretsAsync);
    }
}