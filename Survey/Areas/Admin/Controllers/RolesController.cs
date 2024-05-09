using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Benimkiler;
using Services.Contracts;

namespace Survey.Areas.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

          private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public RolesController(IServiceManager manager, IMapper mapper, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _manager = manager;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {

            var roles = _manager.AuthService.Roles;
            return View(roles);
        }

        public IActionResult CreateRole()
        {
            P.f("GET İSTEGİ ");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(RoleDtoForCreation roleDto)
        {

            IdentityRole role = _manager.AuthService.GetOneRoleWithName(roleDto.Name);

            if (role is null)
            {
                var newUser = _mapper.Map<IdentityRole>(roleDto);
                var result = await _roleManager.CreateAsync(newUser);

                if (result.Succeeded)
                {
                    P.f("Başarılı şeklde " + roleDto.Name + " eklendi");
                }
                else
                {
                    P.f("Bir hata ile karşılaşıldı");
                }
            }
            else
            {
                P.f("Zaten rol daha önce yaratılmş");
            }

            // P.f("roleDtroName : " + roleDto.Name);


            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
             var role = _manager.AuthService.GetOneRoleWithId(id);

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                P.f("Rol silme başarılı");
            }
            else
            {
                P.f("Silme esnasında bir hata ile karşılaşıldı");
            }
            return RedirectToAction("Index");
        }
    }
}