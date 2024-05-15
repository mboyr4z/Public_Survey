using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Benimkiler;
using Services.Contracts;
using StoreApp.Infrastructure.Roles;

namespace Survey.Controllers
{
    public class MainPageController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MainPageController(SignInManager<IdentityUser> signInManager, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        private async Task<IActionResult> CustomizeAccordingToRole(){
            
            var loginingUser = _httpContextAccessor.HttpContext.User;

            if(loginingUser.Identity.IsAuthenticated){
                IdentityUser user = await _userManager.GetUserAsync(loginingUser);

                string firstRole = (await _userManager.GetRolesAsync(user))[0];
                Roles signingRole = (Roles)Enum.Parse(typeof(Roles), firstRole);
                  P.f("giriş başarıyla yapılmış");
                  P.f("first:role : " + firstRole);
                switch (signingRole)
                {
                    case Roles.Admin:
                        P.f ("admins");
                        return await AdminPage();
                        break;
                        
                    case Roles.Author:
                    P.f ("author");
                        return await AuthorPage();
                        break;
                    case Roles.Boss:
                    P.f ("bossr");
                        return await BossPage();
                        break;
                    case Roles.Commentator:
                    P.f ("commentator");
                        return await CommenterPage();
                        break;
                    default:
                    P.f ("guestt");
                       return await GuestPage();
                        break;
                }
            }else{
                P.f("giriş yapılmamış");
                 return await GuestPage();
            }
        }


        
        public async Task<IActionResult> GuestPage() => View("Index");

        public async Task<IActionResult> AdminPage() => View("AdminPage");

        public async Task<IActionResult> AuthorPage() => View("AuthorPage");

        public async Task<IActionResult> BossPage() => View("BossPage");

        public async Task<IActionResult> CommenterPage() => View("CommenterPage");

        public async Task<IActionResult> Index()
        {
            return await CustomizeAccordingToRole();
        }
    }
}