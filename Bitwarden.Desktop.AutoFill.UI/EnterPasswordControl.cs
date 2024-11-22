namespace Bitwarden.Desktop.AutoFill.UI;

public partial class EnterPasswordControl : UserControl
{
    public Action<string> PasswordSet { get; set; } = (_) => { };
    public Action Cancel { get; set; } = () => { };

    public EnterPasswordControl()
    {
        InitializeComponent();
    }

    private void HandlePasswordKeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            PasswordSet(_txtMasterPassword.Text);
        }
    }

    private void HandlePasswordContinue(object sender, EventArgs e)
    {
        PasswordSet(_txtMasterPassword.Text);
    }

    private void HandlePasswordCancel(object sender, EventArgs e)
    {
        Program.ResetPassword();
        Cancel();
    }
}