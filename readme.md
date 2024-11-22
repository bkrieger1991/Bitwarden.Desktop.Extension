# Bitwarden Autofill Extension for Windows
## Introduction
This application is an extension for Bitwarden, designed to address a key missing feature in the Bitwarden Desktop app: Autofill for Windows desktop applications. While Bitwarden provides manual access to your vault through their desktop software, browser extension, and mobile app, it does not offer native autofill functionality for desktop applications.

With this extension, you can automate password filling in any Windows desktop application that requires authentication, removing the need to manually copy and paste credentials from the Bitwarden vault. The app works seamlessly in the background and is accessible through a system tray icon and customizable hotkeys.

## Trust issue
I understand that trust is a critical concern, especially when dealing with a password manager. It’s completely valid to be cautious about using software from an unknown publisher, particularly when it interacts with sensitive information like your passwords. If you have any reservations, I encourage you to review the source code yourself and even build the application from scratch rather than downloading a precompiled release. This way, you can be sure of what’s included and ensure it meets your security standards. Trust should never be assumed, and I respect your right to make an informed decision about the software you use.

## Features
### System Tray Icon
The app runs quietly in the background and is accessible through the Windows tray icon, allowing you to manage settings or launch the autofill functionality with ease.

### Customizable Hotkeys
You can configure a custom keyboard shortcut to trigger the autofill window. This ensures quick and convenient access without interrupting your workflow.

### Secret Selection Window
Upon pressing the hotkey, a window opens, displaying all relevant secrets matching the currently active application or window. You can then choose the appropriate credential for autofill.

### Configurable Autofill Patterns
The app allows you to define patterns for how credentials (such as usernames, passwords, and other secrets) should be inserted into fields. You can customize these patterns according to the specific needs of different applications.

## How It Works
### Vault Access
The app connects directly to your Bitwarden vault (using Bitwardens CLI tool) and retrieves the credentials stored there. After a one-time login to your Bitwarden account, the extension securely stores a session token to facilitate quick autofill actions without repeatedly prompting for your master password.

### Window Matching
The app automatically detects the currently active window and suggests relevant credentials from your vault based on window titles or application identifiers. This streamlines the process by filtering out irrelevant entries.

### Autofill in Action
Once a credential is selected, the app follows the predefined autofill pattern defined in the *Notes* section in the stored secret and inserts the necessary information directly into the application's authentication fields. This can include usernames and passwords.

## Development
The Bitwarden Autofill Extension App is built using .NET 8 with Windows Forms (WinForms), making it exclusively compatible with the Windows operating system. Development is recommended in Visual Studio, which provides robust support for .NET applications and an efficient debugging experience.

### Steps to Get Started with Development:
1. Clone or Download the Repository: Ensure you have the source code locally.
1. Open the Project in Visual Studio: Launch Visual Studio and open the project file (.csproj) or solution file (.sln).
1. Restore Dependencies: Visual Studio will automatically restore the required NuGet packages.
1. Start Debugging: Simply press F5 or select “Start Debugging” to compile and run the application.

By leveraging the WinForms framework, the application maintains a lightweight and straightforward design, making it accessible for developers and contributors familiar with the .NET ecosystem.

## Usage Instructions
### Configure Hotkeys
Open the settings by right-clicking on the tray icon and selecting “Settings.” From here, you can define the hotkey that triggers the autofill window.

### Setting Autofill Patterns
Define patterns for each application if needed. For example, some applications may require filling the username first, followed by pressing "Tab," and then inserting the password.

### Trigger Autofill
Press your configured hotkey whenever you are in an application that requires authentication. The secret selection window will appear, allowing you to choose the correct credentials.

### Select and Fill
Select the relevant credentials from the list, and the app will automatically input the data into the active window following the specified pattern.

## Conclusion
This Bitwarden Autofill Extension simplifies your desktop experience by eliminating the need to manually copy and paste credentials from your vault. By leveraging customizable hotkeys and intelligent window detection, it makes password management more seamless and efficient for Windows desktop applications. Enjoy the peace of mind of secure, automated login processes with the security and convenience of Bitwarden.