namespace ADPasswordChanger.Models
{
    public class PasswordRequirements
    {
        public int MinimumLength { get; set; } = 8;
        public bool RequireUppercase { get; set; } = true;
        public bool RequireLowercase { get; set; } = true;
        public bool RequireDigit { get; set; } = true;
        public bool RequireSpecialChar { get; set; } = true;

        public string GetRequirementsText()
        {
            var requirements = new List<string>();

            requirements.Add($"Mindestens {MinimumLength} Zeichen");

            if (RequireUppercase)
                requirements.Add("Mindestens ein Großbuchstabe");

            if (RequireLowercase)
                requirements.Add("Mindestens ein Kleinbuchstabe");

            if (RequireDigit)
                requirements.Add("Mindestens eine Zahl");

            if (RequireSpecialChar)
                requirements.Add("Mindestens ein Sonderzeichen");

            return string.Join(", ", requirements);
        }
    }
}
