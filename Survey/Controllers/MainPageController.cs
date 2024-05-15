using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Survey.Benimkiler;

namespace Survey.Controllers
{
    public class MainPageController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;


        public MainPageController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        private async Task<IActionResult> CustomizeAccordingByLogin(){
            
            var user = await _userManager.GetUserAsync(User);

            if(user is not null){
                P.f("Giriş Yapılmış");
                return RedirectToAction("CustomizeAccordingToRole","CheckingSurveyUser");
            }
            else{
                 P.f("giriş yapılmamış");
                 return View();
            }
        }


        
        

        public async Task<IActionResult> Index()
        {
            return await CustomizeAccordingByLogin();
        }
    }
}