using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;
using SQLitePCL;

namespace Services
{
    public class AuthManager : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly IMapper _mapper;

        public AuthManager(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IEnumerable<IdentityRole> Roles =>
            _roleManager.Roles;

        public IdentityRole GetOneRoleWithId(string roleId)
        {
            IdentityRole role = Roles.FirstOrDefault(r => r.Id == roleId);
            return role;
        }

           public IdentityRole GetOneRoleWithName(string roleName)
        {
            IdentityRole role = Roles.FirstOrDefault(r => r.Name == roleName);
            return role;
        }

        public async Task<IdentityResult> CreateRole(RoleDtoForCreation roleDto)
        {
            var newUser = _mapper.Map<IdentityRole>(roleDto);
            var result = await _roleManager.CreateAsync(newUser);

            return result;
        }

        public async Task<IdentityResult> DeleteRole(string id)
        {
            var role = GetOneRoleWithId(id);

            var result = await _roleManager.DeleteAsync(role);
            return result;
        }
     

        
    }
}