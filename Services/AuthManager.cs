using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Services.Benimkiler;
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


        #region Roles

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


       
        #endregion


        #region Users

        public async Task<IdentityResult> CreateUser(account_RegisterDto userDto)
        {

            P.f("USERTDO - > name : " + userDto.UserName + "mail : " + userDto.Email + " pass : "  + userDto.Password);
            IdentityUser user = _mapper.Map<IdentityUser>(userDto);
            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);

            P.f("ıdentıty user - > name : " + user.UserName + "mail : " + user.Email + " pass : "  + user.PasswordHash);
            return result;

        }
        public async Task<IdentityResult> DeleteUseer(string id)
        {
            var user = await GetUserWithIdAsync(id);
            var result = await _userManager.DeleteAsync(user);


            return result;
        }

        public async Task<IdentityUser> GetUserWithIdAsync(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<IdentityUser> GetUserWithUsernameAsync(string userName)
        {
            IdentityUser user = await _userManager.FindByNameAsync(userName);
            return user;
        }


        #endregion

    }
}