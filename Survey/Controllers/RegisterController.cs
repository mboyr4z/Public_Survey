using System.Security.Cryptography;
using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Survey.Benimkiler;
using Services.Contracts;

namespace Survey.Controllers
{
    public class RegisterController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly IServiceManager _manager;

        private readonly IMapper _mapper;

        public RegisterController(IServiceManager manager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _manager = manager;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            ViewBag.allRoles = new SelectList(_manager.AuthService.Roles.Where(role => role.Name!= "Admin"), "Id", "Name", "1");
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] account_RegisterDto userDto)
        {

            p.f("role name : " + userDto.RoleId);

            IdentityUser newUser = _mapper.Map<IdentityUser>(userDto);


            IdentityResult result = await _userManager.CreateAsync(newUser, userDto.Password);

            if (result.Succeeded)
            {
                p.f("Kullanıcı başarıyla eklendi");

                IdentityRole role = _manager.AuthService.GetOneRoleWithId(userDto.RoleId);
                var result2 = await _userManager.AddToRoleAsync(newUser, role.Name);

                if(result2.Succeeded){
                    p.f("Rol de başarıyla eklendi");
                    return RedirectToAction("Success");
                }
            }
            else
            {
                // Hata durumunda hata mesajlarını yazdır
                foreach (var error in result.Errors)
                {
                     ModelState.AddModelError("", error.Description);
                } 
            }
            ViewBag.allRoles = new SelectList(_manager.AuthService.Roles.Where(role => role.Name!= "Admin"), "Id", "Name", "1");
            return View();
        }

    }
}