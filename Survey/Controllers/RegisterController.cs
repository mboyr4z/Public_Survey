using System.Security.Cryptography;
using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Benimkiler;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] account_RegisterDto userDto)
        {



            IdentityUser newUser = _mapper.Map<IdentityUser>(userDto);


            IdentityResult result = await _userManager.CreateAsync(newUser, userDto.Password);

            if (result.Succeeded)
            {
                P.f("Kullanıcı başarıyla eklendi");
            }
            else
            {
                // Hata durumunda hata mesajlarını yazdır
                foreach (var error in result.Errors)
                {
                    P.f($"Hata: {error.Description}");
                }

                return View();
            }



            return RedirectToAction("Index");
        }

    }
}