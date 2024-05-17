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
                
                // p.f("Giriş Yapılmış");
                return RedirectToAction("CustomizeAccordingToRole","CheckingSurveyUser");
            }
            else{
                 // p.f("giriş yapılmamış");
                 return View("Index");
            }
        }


        public async Task<IActionResult> GuestPage()
        {
            return View("Index");
        }
        

        public async Task<IActionResult> Index()
        {
            return await CustomizeAccordingByLogin();
        }
    }
}