using System.Text;

namespace ADPasswordChanger.Services;

public class PasswordGeneratorService : IPasswordGeneratorService
{
    private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
    private const string NumberChars = "0123456789";
    private const string SpecialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";

    public string GeneratePassword(int length = 12, bool includeUppercase = true, bool includeLowercase = true, bool includeNumbers = true, bool includeSpecialChars = true)
    {
        var charSet = new StringBuilder();
        var password = new StringBuilder();
        var random = new Random();

        if (includeUppercase) charSet.Append(UppercaseChars);
        if (includeLowercase) charSet.Append(LowercaseChars);
        if (includeNumbers) charSet.Append(NumberChars);
        if (includeSpecialChars) charSet.Append(SpecialChars);

        if (charSet.Length == 0)
            throw new ArgumentException("At least one character type must be selected");

        for (int i = 0; i < length; i++)
        {
            password.Append(charSet[random.Next(charSet.Length)]);
        }

        return password.ToString();
    }

    public bool ValidatePasswordStrength(string password)
    {
        if (string.IsNullOrEmpty(password) || password.Length < 8)
            return false;

        bool hasUpper = password.Any(char.IsUpper);
        bool hasLower = password.Any(char.IsLower);
        bool hasDigit = password.Any(char.IsDigit);
        bool hasSpecial = password.Any(c => !char.IsLetterOrDigit(c));

        return hasUpper && hasLower && hasDigit && hasSpecial;
    }
}
