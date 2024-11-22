using Bitwarden.Desktop.AutoFill.UI.Bitwarden;
using Microsoft.Extensions.DependencyInjection;
using Timer = System.Threading.Timer;

namespace Bitwarden.Desktop.AutoFill.UI;

public static class Program
{
    private static Settings.Settings _settings = null!;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    public static void Main()
    {
#if DEBUG
        NativeApi.AllocConsole();
#endif

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        var settings = Settings.Read();
        var provider = new ServiceCollection()
            .AddSingleton(settings)
            .AddSingleton<BitwardenClientFactory>()
            .BuildServiceProvider();

        _ = new Timer(
            (_) =>
            {
                // Reading the password ensures it gets re-encrypted
                Console.WriteLine("Re-Encrypting password...");
                _settings.BitwardenPassword.Read();
                if (_settings.StorePassword)
                {
                    _settings.Save();
                }
            },
            null,
            TimeSpan.FromSeconds(5),
            TimeSpan.FromSeconds(30)
        );

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new SettingsForm()
        {
            Settings = _settings
        });
    }

    public static void ResetPassword()
    {
        if (!_settings.StorePassword)
        {
            _settings.BitwardenPassword.Forget();
        }
        BitwardenClient.ForgetClient();
    }
}