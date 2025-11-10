using System.ComponentModel.DataAnnotations;

namespace ADPasswordChanger.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Benutzername ist erforderlich.")]
        [Display(Name = "Benutzername")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Aktuelles Kennwort ist erforderlich.")]
        [DataType(DataType.Password)]
        [Display(Name = "Aktuelles Kennwort")]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Neues Kennwort ist erforderlich.")]
        [DataType(DataType.Password)]
        [Display(Name = "Neues Kennwort")]
        [MinLength(8, ErrorMessage = "Das Kennwort muss mindestens 8 Zeichen lang sein.")]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bestätigung des Kennworts ist erforderlich.")]
        [DataType(DataType.Password)]
        [Display(Name = "Kennwort bestätigen")]
        [Compare("NewPassword", ErrorMessage = "Die Kennwörter stimmen nicht überein.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
