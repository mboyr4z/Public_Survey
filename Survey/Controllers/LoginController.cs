using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Survey.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(IMapper mapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] account_LoginDto userDto){
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
    }
}