using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace ADPasswordChanger.Services;

public class ActiveDirectoryService : IActiveDirectoryService
{
    private readonly IConfiguration _configuration;

    public ActiveDirectoryService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<bool> ChangePasswordAsync(string username, string oldPassword, string newPassword)
    {
        try
        {
            var domain = _configuration["ActiveDirectory:Domain"];
            using var context = new PrincipalContext(ContextType.Domain, domain);
            using var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username);
            
            if (user == null)
                return false;

            user.ChangePassword(oldPassword, newPassword);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> ValidateUserAsync(string username, string password)
    {
        try
        {
            var domain = _configuration["ActiveDirectory:Domain"];
            using var context = new PrincipalContext(ContextType.Domain, domain);
            return context.ValidateCredentials(username, password);
        }
        catch
        {
            return false;
        }
    }
}
