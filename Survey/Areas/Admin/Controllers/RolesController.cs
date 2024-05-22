using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using Survey.Benimkiler;
using Services.Contracts;
using Survey.Models;
using Benimkiler.Roles;

namespace Survey.Areas.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly  MainPageModel _mainPageModel;
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

          private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public RolesController(IServiceManager manager, IMapper mapper, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, MainPageModel mainPageModel)
        {
            _manager = manager;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _mainPageModel = mainPageModel;
        }

        public async Task<IActionResult> IndexAsync()
        {
            _mainPageModel.IsUserLogged = true;
            _mainPageModel.User = await _userManager.GetUserAsync(User);
            _mainPageModel.Role = Roles.Admin;


            ViewBag.HeaderModel = _mainPageModel;

            var roles = _manager.AuthService.Roles;
            return View(roles);
        }

        public IActionResult CreateRole()
        {
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
                    //p.f("Başarılı şeklde " + roleDto.Name + " eklendi");
                }
                else
                {
                    //p.f("Bir hata ile karşılaşıldı");
                }
            }
            else
            {
                //p.f("Zaten rol daha önce yaratılmş");
            }

            // p.f("roleDtroName : " + roleDto.Name);


            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
             var role = _manager.AuthService.GetOneRoleWithId(id);

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                p.f("Rol silme başarılı");
            }
            else
            {
                p.f("Silme esnasında bir hata ile karşılaşıldı");
            }
            return RedirectToAction("Index");
        }
    }
}