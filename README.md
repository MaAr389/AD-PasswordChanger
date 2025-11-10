# AD-PasswordChanger

Eine ASP.NET Core Webanwendung zum Ändern von Active Directory Passwörtern mit integriertem Passwortgenerator.

## Features

- ✅ Active Directory Passwort-Änderung
- ✅ Integrierter Passwortgenerator
- ✅ Benutzerfreundliche Web-Oberfläche
- ✅ Sichere Passwortvalidierung
- ✅ MVC-Architektur

## Technologie-Stack

- ASP.NET Core 7.0+
- C# 11
- System.DirectoryServices.AccountManagement
- Bootstrap 5
- jQuery

## Projektstruktur

```
AD-PasswordChanger/
├── Program.cs
├── appsettings.json
├── ADPasswordChanger.csproj
├── Controllers/
│   └── PasswordController.cs
├── Models/
│   ├── ChangePasswordViewModel.cs
│   └── PasswordRequirements.cs
├── Services/
│   ├── IActiveDirectoryService.cs
│   ├── ActiveDirectoryService.cs
│   ├── IPasswordGeneratorService.cs
│   └── PasswordGeneratorService.cs
└── Views/
    ├── _ViewStart.cshtml
    ├── Shared/
    │   └── _Layout.cshtml
    └── Password/
        ├── Index.cshtml
        └── Success.cshtml

```

## Installation

1. Repository klonen:
```bash
git clone https://github.com/MaAr389/AD-PasswordChanger.git
cd AD-PasswordChanger
```

2. NuGet-Pakete installieren:
```bash
dotnet restore
```

3. `appsettings.json` konfigurieren:
```json
{
  "ActiveDirectory": {
    "Domain": "ihredomain.local"
  }
}
```

4. Anwendung ausführen:
```bash
dotnet run
```

## Konfiguration

### Active Directory Einstellungen

Bearbeiten Sie die `appsettings.json` und tragen Sie Ihre Domain ein:

```json
{
  "ActiveDirectory": {
    "Domain": "contoso.local"
  }
}
```

## Verwendung

1. Öffnen Sie die Anwendung im Browser (Standard: https://localhost:5001)
2. Geben Sie Ihren Benutzernamen ein
3. Geben Sie Ihr aktuelles Passwort ein
4. Geben Sie ein neues Passwort ein oder nutzen Sie den Passwortgenerator
5. Bestätigen Sie das neue Passwort
6. Klicken Sie auf "Passwort ändern"

## Passwortgenerator

Der integrierte Passwortgenerator erstellt sichere Passwörter mit:
- Großbuchstaben (A-Z)
- Kleinbuchstaben (a-z)
- Zahlen (0-9)
- Sonderzeichen (!@#$%^&*)
- Konfigurierbare Länge (Standard: 12 Zeichen)

## Services

### IActiveDirectoryService
Interface für Active Directory Operationen:
- `ChangePasswordAsync()` - Ändert das Benutzerpasswort
- `ValidateUserAsync()` - Validiert Benutzeranmeldedaten

### IPasswordGeneratorService
Interface für Passwortgenerierung:
- `GeneratePassword()` - Generiert ein sicheres Passwort
- `ValidatePasswordStrength()` - Prüft Passwortstärke

## Sicherheit

- Passwörter werden niemals im Klartext gespeichert
- HTTPS wird erzwungen
- Passwort-Komplexitätsanforderungen werden durchgesetzt
- Sichere Kommunikation mit Active Directory

## Systemanforderungen

- .NET 7.0 SDK oder höher
- Windows Server mit Active Directory
- Netzwerkzugriff auf den Domain Controller
- IIS oder Kestrel Webserver

## Lizenz

MIT License

## Autor

MaAr389

## Support

Bei Fragen oder Problemen erstellen Sie bitte ein Issue auf GitHub.
