using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Bitwarden.Desktop.AutoFill.UI;

public static class NativeApi
{
    public class AutoFillResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class WindowInfo
    {
        public IntPtr Handle { get; set; }
        public Point CaretPositionClient { get; set; }
        public Point CaretPositionScreen { get; set; }
        public string Title { get; set; } = string.Empty;
        public GUITHREADINFO GuiThreadInfo { get; set; }
    }

    public static WindowInfo GetForegroundWindowInfo()
    {
        var guiInfo = new GUITHREADINFO();
        guiInfo.cbSize = (uint)Marshal.SizeOf(guiInfo);
        GetGUIThreadInfo(0, out guiInfo);

        var caretPosition = new Point
        {
            X = (int)guiInfo.rcCaret.Left + 25,
            Y = (int)guiInfo.rcCaret.Bottom + 25
        };

        ClientToScreen(guiInfo.hwndCaret, out var caretScreenPosition);

        var foregroundWindow = GetForegroundWindow();
        var title = GetWindowTitle(foregroundWindow);

        return new WindowInfo()
        {
            CaretPositionClient = caretPosition,
            CaretPositionScreen = caretScreenPosition,
            Handle = foregroundWindow,
            Title = title,
            GuiThreadInfo = guiInfo
        };
    }

    public static AutoFillResult AutoFillCredential(Credential credential, WindowInfo targetWindowInfo)
    {
        const string passwordAction = "password";
        const string usernameAction = "user";

        var username = credential.Username;
        var password = credential.Password;

        var command = credential.AutoFillInfo?.Keys ?? "";
        if (string.IsNullOrWhiteSpace(command))
        {
            return new AutoFillResult
            {
                Message =
                    "AutoFill is not configured for this secret! Add 'AutoFill:' pattern to notes section.",
                Success = false
            };
        }
        var keyValues = Enum.GetNames(typeof(Keys));
        var regex = new Regex(@"\{[^}]*\}");
        var matches = regex.Matches(command);
        var actions = matches.Select(m => m.Value)
            .Select(m => m.Replace("{", "").Replace("}", ""))
            .Where(
                v => keyValues.Contains(v)
                    || v.Equals(passwordAction, StringComparison.InvariantCultureIgnoreCase)
                    || v.Equals(usernameAction, StringComparison.InvariantCultureIgnoreCase)
            )
            .ToArray();

        if (actions.Length == 0)
        {
            return new AutoFillResult
            {
                Message =
                    $"Your AutoFill configuration might be incorrect. Found configuration: '{command}'",
                Success = false
            };
        }

        SetForegroundWindow(targetWindowInfo.Handle);
        foreach (var action in actions)
        {
            if (action.Equals(passwordAction, StringComparison.InvariantCultureIgnoreCase))
            {
                SendKeys.SendWait(password);
            }
            else if (action.Equals(usernameAction, StringComparison.InvariantCultureIgnoreCase))
            {
                SendKeys.SendWait(username);
            }
            else if (Enum.TryParse<Keys>(action, true, out var key))
            {
                var sendKey = MapKey(key);
                if (sendKey != null)
                {
                    SendKeys.SendWait($"{{{sendKey}}}");
                }
            }
            else
            {
                Console.WriteLine($"Warning: action '{action}' doesn't match anything...");
            }
        }

        return new AutoFillResult { Success = true };
    }

    private static string? MapKey(Keys key)
    {
        switch (key)
        {
            case Keys.Back: return "BACKSPACE";
            case Keys.Escape: return "ESC";
            case Keys.Home:
            case Keys.End:
            case Keys.Left:
            case Keys.Right:
            case Keys.Down:
            case Keys.Up:
            case Keys.Tab:
            case Keys.Enter:
                return key.ToString().ToUpper();
        }

        return null;
    }

    public static string GetWindowTitle(IntPtr hWnd)
    {
        unsafe
        {
            const int capacity = 260;
            var caption = stackalloc char[capacity];
            var nrCharacters = GetWindowText(hWnd, caption, capacity);
            if (nrCharacters == 0)
            {
                return string.Empty;
            }
            return new string(caption, 0, nrCharacters);
        }
    }

    #region Data Structs
    [StructLayout(LayoutKind.Sequential)]    // Required by user32.dll
    public struct RECT
    {
        public uint Left;
        public uint Top;
        public uint Right;
        public uint Bottom;
    };

    [StructLayout(LayoutKind.Sequential)]    // Required by user32.dll
    public struct GUITHREADINFO
    {
        public uint cbSize;
        public uint flags;
        public IntPtr hwndActive;
        public IntPtr hwndFocus;
        public IntPtr hwndCapture;
        public IntPtr hwndMenuOwner;
        public IntPtr hwndMoveSize;
        public IntPtr hwndCaret;
        public RECT rcCaret;
    };
    #endregion

    #region DLL Imports
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern unsafe int GetWindowText(IntPtr hWnd, char* lpString, int capacity);
    
    [DllImport("user32.dll", EntryPoint = "GetGUIThreadInfo")]
    public static extern bool GetGUIThreadInfo(uint tId, out GUITHREADINFO threadInfo);

    [DllImport("user32.dll")]
    public static extern bool ClientToScreen(IntPtr hWnd, out Point position);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool AllocConsole();
    #endregion
}