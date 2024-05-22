using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using Survey.Benimkiler;

namespace Survey.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly IServiceManager _manager;


        public AccountController(IMapper mapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IServiceManager manager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _manager = manager;
        }

        public IActionResult Login(){
            return View();
        }

        public IActionResult Success(){
            return View();
        }

        public IActionResult Register(){
            
            ViewBag.allRoles = new SelectList(_manager.AuthService.Roles.Where(role => role.Name!= "Admin"), "Id", "Name", "1");
            return View();

        }

        
        public async Task<IActionResult> LogOutAsync(){
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "MainPage");
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] account_LoginDto userDto){
            if(ModelState.IsValid){
                IdentityUser loginingUser = await _userManager.FindByNameAsync(userDto.UserName);

                if(loginingUser is not null){
                    
                    await _signInManager.SignOutAsync();


                    if((await _signInManager.PasswordSignInAsync(loginingUser, userDto.Password, false, false)).Succeeded){
                        return RedirectToAction("Index","MainPage");                        
                    }else{
                        ModelState.AddModelError("Error", "Password is wrong");    
                    }
                }else{
                    ModelState.AddModelError("Error", "Invalid username");
                }
            }
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] account_RegisterDto userDto)
        {

            //p.f("role name : " + userDto.RoleId);

            IdentityUser newUser = _mapper.Map<IdentityUser>(userDto);


            IdentityResult result = await _userManager.CreateAsync(newUser, userDto.Password);

            if (result.Succeeded)
            {
                //p.f("Kullanıcı başarıyla eklendi");

                IdentityRole role = _manager.AuthService.GetOneRoleWithId(userDto.RoleId);
                var result2 = await _userManager.AddToRoleAsync(newUser, role.Name);

                if(result2.Succeeded){
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