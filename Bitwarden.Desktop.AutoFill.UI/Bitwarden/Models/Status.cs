namespace Bitwarden.Desktop.AutoFill.UI.Bitwarden.Models;

public class Status
{
    public object serverUrl { get; set; }
    public DateTime lastSync { get; set; }
    public string userEmail { get; set; }
    public string userId { get; set; }
    public string status { get; set; }
}