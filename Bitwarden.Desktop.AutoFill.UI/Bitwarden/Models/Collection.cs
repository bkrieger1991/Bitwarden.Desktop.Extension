using System.Diagnostics;

namespace Bitwarden.Desktop.AutoFill.UI.Bitwarden.Models;

[DebuggerDisplay("Name = {name}")]
public class Collection
{
    public string @object { get; set; }
    public string id { get; set; }
    public string organizationId { get; set; }
    public string name { get; set; }
    public string externalId { get; set; }
}