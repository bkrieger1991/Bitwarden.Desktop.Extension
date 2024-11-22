using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bitwarden.Desktop.AutoFill.UI.AppSettings;

[Serializable]
public class Settings
{
    private const string Filename = "settings.json";
    private static JsonSerializerOptions _serializerOptions = new()
    {
        WriteIndented = true
    };

    [JsonPropertyName("Combination")]
    [JsonInclude]
    public Keys[] Combination { get; set; } = [Keys.LControlKey, Keys.RControlKey];

    [JsonPropertyName("BitwardenEmail")]
    [JsonInclude]
    public string BitwardenEmail = "";

    [JsonPropertyName("BitwardenUri")]
    [JsonInclude]
    public string BitwardenUri = "https://vault.bitwarden.com";

    [JsonPropertyName("BitwardenPassword")]
    [JsonInclude]
    public PasswordContainer BitwardenPassword { get; set; } = new();

    [JsonPropertyName("StorePassword")]
    [JsonInclude]
    public bool StorePassword { get; set; }

    public static Settings Read()
    {
        Settings? settings;
        try
        {
            var path = GetSettingsFilePath();
            if (!File.Exists(path))
            {
                settings = CreateNew();
            }
            else
            {
                var json = File.ReadAllText(path);
                settings = JsonSerializer.Deserialize<Settings>(json) ?? CreateNew();
            }
        }
        catch (Exception e)
        {
            MessageBox.Show($"Error loading settings file: {e.Message}");
            throw;
        }

        return settings;
    }

    public void Save()
    {
        // If password shouldn't be stored clear values but keep cached password...
        if (!StorePassword && BitwardenPassword.Exists())
        {
            var password = BitwardenPassword.Read();
            BitwardenPassword.Forget();
            SerializeToFile();
            // Set password after saving...
            BitwardenPassword.Set(password);
        }
        else
        {
            SerializeToFile();
        }
    }

    private void SerializeToFile()
    {
        var json = JsonSerializer.Serialize(this, _serializerOptions);
        File.WriteAllText(GetSettingsFilePath(), json);
    }

    private static string GetSettingsFilePath()
    {
        var assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
        return Path.Combine(assemblyLocation, Filename);
    }

    private static Settings CreateNew()
    {
        var settings = new Settings();
        settings.Save();
        return settings;
    }

    public void Reload()
    {
        var settings = Read();

        BitwardenPassword = settings.BitwardenPassword;
        BitwardenUri = settings.BitwardenUri;
        BitwardenEmail = settings.BitwardenEmail;
        StorePassword = settings.StorePassword;
        Combination = settings.Combination;
    }
}