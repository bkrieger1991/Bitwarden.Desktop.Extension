using System.Text.Json.Serialization;

namespace Bitwarden.Desktop.AutoFill.UI.Settings;

[Serializable]
public class PasswordContainer
{
    [JsonPropertyName("Encrypted")]
    [JsonInclude]
    public string Encrypted { get; set; } = string.Empty;

    [JsonPropertyName("Entropy")]
    [JsonInclude]
    public byte[] Entropy { get; set; } = [];

    public bool Exists()
    {
        return !string.IsNullOrWhiteSpace(Encrypted);
    }

    public void Forget()
    {
        Entropy = [];
        Encrypted = string.Empty;
    }

    public void Set(string password)
    {
        Entropy = EncryptionHelper.GenerateEntropy();
        Encrypted = EncryptionHelper.EncryptMasterPassword(password, Entropy);
    }

    public string Read()
    {
        if (!Exists())
        {
            return string.Empty;
        }

        var password = EncryptionHelper.DecryptMasterPassword(Encrypted, Entropy);
        // Re-Set password to ensure generating a new entropy
        Set(password);

        return password;
    }
}