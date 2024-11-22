namespace Bitwarden.Desktop.AutoFill.UI.Bitwarden;

public class BitwardenClientFactory
{
    private readonly Settings _settings;
    private BitwardenClient? _client;

    public BitwardenClientFactory(Settings settings)
    {
        _settings = settings;
    }

    public BitwardenClient Create()
    {
        Console.WriteLine("Getting bitwarden client...");
        if (_client == null)
        {
            if (_settings == null)
            {
                throw new Exception(
                    "Bitwarden client can't be created, since settings are not available. Call SetSettings() before creating client."
                );
            }

            Console.WriteLine("Bitwarden client is not ready. Creating...");
            _client = new BitwardenClient(
                _settings.BitwardenUri,
                _settings.BitwardenEmail,
                _settings.BitwardenPassword.Read()
            );
            Console.WriteLine($"Bitwarden client was created.");
        }

        return _client;
    }

    public void Reload()
    {
        Console.WriteLine($"Re-Generate bitwarden client session...");
        Reset();
        Create();
    }

    public void Reset()
    {
        Console.WriteLine("Forgetting stored client session...");
        _client = null;
    }
}