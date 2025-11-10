namespace ADPasswordChanger.Services;

public interface IActiveDirectoryService
{
    Task<bool> ChangePasswordAsync(string username, string oldPassword, string newPassword);
    Task<bool> ValidateUserAsync(string username, string password);
}
