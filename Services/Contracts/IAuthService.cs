using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        IdentityRole GetOneRoleWithId(string roleId);
        IdentityRole GetOneRoleWithName(string roleName);
        Task<IdentityResult> CreateRole(RoleDtoForCreation roleDto);
        Task<IdentityResult> DeleteRole(string id);
        
    }
}