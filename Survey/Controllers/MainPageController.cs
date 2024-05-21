using System.Security.Claims;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Survey.Benimkiler;

namespace Survey.Controllers
{
    public class MainPageController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly IServiceManager _manager;


        public MainPageController(UserManager<IdentityUser> userManager, IServiceManager manager)
        {
            _userManager = userManager;
            _manager = manager;
        }

        private async Task<IActionResult> CustomizeAccordingByLogin()
        {

            var user = await _userManager.GetUserAsync(User);


            if (user is not null)
            {

                // p.f("Giriş Yapılmış");
                return RedirectToAction("CustomizeAccordingToRole", "CheckingSurveyUser");
            }
            else
            {
                
                // p.f("giriş yapılmamış");
                return View("Index");
            }
        }


        public async Task<IActionResult> GuestPage()
        {
             ClaimsPrincipal curUser = User;
            ViewBag.isMemberShipCompleted = await _manager.IsSurveyUserMembershipCompletedAsync(curUser);

            // p.f("üyelik tamamlandı mı : " + ViewBag.isMemberShipCompleted);

            

            
            return View("Index");
        }


        public async Task<IActionResult> Index()
        {

            ClaimsPrincipal curUser = User;
            ViewBag.isMemberShipCompleted = await _manager.IsSurveyUserMembershipCompletedAsync(curUser);

            var identityBosses = await _userManager.GetUsersInRoleAsync("Boss");
            
            foreach (var identityBoss in  identityBosses)
            {
                Boss boss = _manager.BossService.GetOneBoss(identityBoss.Id, false);

                if(boss is not null){
                    boss.Company = _manager.CompanyService.GetOneCompany(boss.CompanyId, false);
                }

                p.f(identityBoss.UserName + " -> " + identityBoss.Email + " -> " + boss?.Name + " -> " + boss?.Company?.Name);


            }

            // p.f("üyelik tamamlandı mı : " + ViewBag.isMemberShipCompleted);
            return await CustomizeAccordingByLogin();
        }


    }
}