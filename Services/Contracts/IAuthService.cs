using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthService
    {
        // ROLES
        IEnumerable<IdentityRole> Roles { get; }
        IdentityRole GetOneRoleWithId(string roleId);
        IdentityRole GetOneRoleWithName(string roleName);
        Task<IdentityUser> GetUserWithIdAsync(string id);
        Task<IdentityUser> GetUserWithUsernameAsync(string id);

        
        
    }
}