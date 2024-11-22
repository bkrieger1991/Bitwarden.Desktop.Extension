using System.Text.Json.Serialization;

namespace Bitwarden.Desktop.AutoFill.UI;

[Serializable]
public class AutoFillInfo
{
    [JsonPropertyName("search")]
    [JsonInclude]
    public string Search { get; set; }

    [JsonPropertyName("keys")]
    [JsonInclude]
    public string Keys { get; set; }
}

public class Credential
{
    public string Name { get; init; } = string.Empty;
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string? Description { get; init; } = string.Empty;
    public AutoFillInfo? AutoFillInfo { get; set; }
}