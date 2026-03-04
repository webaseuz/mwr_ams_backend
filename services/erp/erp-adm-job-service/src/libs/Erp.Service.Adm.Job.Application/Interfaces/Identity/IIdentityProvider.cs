using Erp.Core.Service.Domain;

namespace Erp.Service.Adm.Job.Application;

public interface IIdentityProvider
{
    Task<User> GetUserAsync(long userId);
    Task<bool> CreateUserAsync(User user, string password);
    Task<bool> UpdateUserAsync(User user, string password = null);
}
