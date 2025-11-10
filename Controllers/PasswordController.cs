using Microsoft.AspNetCore.Mvc;
using ADPasswordChanger.Models;
using ADPasswordChanger.Services;

namespace ADPasswordChanger.Controllers
{
    public class PasswordController : Controller
    {
        private readonly IActiveDirectoryService _adService;
        private readonly IPasswordGeneratorService _passwordGenerator;
        private readonly ILogger<PasswordController> _logger;

        public PasswordController(
            IActiveDirectoryService adService,
            IPasswordGeneratorService passwordGenerator,
            ILogger<PasswordController> logger)
        {
            _adService = adService;
            _passwordGenerator = passwordGenerator;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ChangePasswordViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            try
            {
                // Validate current credentials
                var isValid = await _adService.ValidateUserAsync(model.Username, model.CurrentPassword);
                if (!isValid)
                {
                    ModelState.AddModelError("", "Aktuelle Anmeldeinformationen sind ungültig.");
                    return View("Index", model);
                }

                // Validate new password strength
                var (isStrong, message) = _passwordGenerator.ValidatePasswordStrength(model.NewPassword);
                if (!isStrong)
                {
                    ModelState.AddModelError(nameof(model.NewPassword), message);
                    return View("Index", model);
                }

                // Change password
                var result = await _adService.ChangePasswordAsync(
                    model.Username,
                    model.CurrentPassword,
                    model.NewPassword);

                if (result)
                {
                    _logger.LogInformation("Password changed successfully for user: {Username}", model.Username);
                    return RedirectToAction("Success");
                }
                else
                {
                    ModelState.AddModelError("", "Kennwortänderung fehlgeschlagen. Bitte versuchen Sie es erneut.");
                    return View("Index", model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error changing password for user: {Username}", model.Username);
                ModelState.AddModelError("", "Ein Fehler ist aufgetreten. Bitte kontaktieren Sie den Administrator.");
                return View("Index", model);
            }
        }

        [HttpGet]
        public IActionResult GeneratePassword()
        {
            var password = _passwordGenerator.GeneratePassword(
                length: 16,
                includeUppercase: true,
                includeLowercase: true,
                includeNumbers: true,
                includeSpecialChars: true);

            return Json(new { password });
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
    }
}
