namespace Bitwarden.Desktop.AutoFill.UI;

public partial class CredentialItem : UserControl
{
    public const int CredentialItemHeight = 60;
    public Credential? Credential { get; set; }
    public Guid Id { get; } = Guid.NewGuid();
        
    public CredentialItem()
    {
            InitializeComponent();
            // Init selected state
            SetSelected(false);
        }

    public void SetSelected(bool selected)
    {
            BackColor = selected ? Color.FromArgb(60, 70, 70) : Color.FromArgb(42, 49, 51);
        }

    private void CredentialItem_Load(object sender, EventArgs e)
    {
            if (Credential == null)
            {
                return;
            }

            _lblCredentialName.Text = Credential.Name;
            _lblUsername.Text = GetDescription();
            _lblUsername.Text = Credential.Username + " - Command: " + Credential?.AutoFillInfo?.Keys;
        }

    private string GetDescription()
    {
            var length = Credential?.Description?.Length ?? 0;
            var shortened = Credential?.Description?.Substring(0, Math.Min(75, length));
            shortened += length > 75 ? "..." : "";
            return shortened;
        }
}