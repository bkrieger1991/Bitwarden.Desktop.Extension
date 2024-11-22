using System.Security.Cryptography;
using System.Text;

namespace Bitwarden.Desktop.AutoFill.UI;

public static class EncryptionHelper
{
    public static string DecryptMasterPassword(string encrypted, byte[] entropy)
    {
        var plain = ProtectedData.Unprotect(
            Convert.FromBase64String(encrypted),
            entropy,
            DataProtectionScope.CurrentUser
        );

        return Encoding.UTF8.GetString(plain);
    }

    public static string EncryptMasterPassword(string password, byte[] entropy)
    {
        var encrypted = ProtectedData.Protect(
            Encoding.UTF8.GetBytes(password),
            entropy,
            DataProtectionScope.CurrentUser
        );
        return Convert.ToBase64String(encrypted);
    }

    public static byte[] GenerateEntropy()
    {
        return RandomNumberGenerator.GetBytes(20);
    }
}