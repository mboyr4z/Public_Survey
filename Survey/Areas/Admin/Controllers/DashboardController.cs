using Benimkiler.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;
using Survey.Models;

namespace Survey.Areas.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {

        private readonly IServiceManager _manager;

        private readonly  MainPageModel _mainPageModel;

        private readonly UserManager<IdentityUser> _userManager;

        public DashboardController(IServiceManager manager, MainPageModel mainPageModel, UserManager<IdentityUser> userManager)
        {
            _manager = manager;
            _mainPageModel = mainPageModel;
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            _mainPageModel.IsUserLogged = true;
            _mainPageModel.User = await _userManager.GetUserAsync(User);
            _mainPageModel.Role = Roles.Admin;


            ViewBag.HeaderModel = _mainPageModel;
            return View();
        }
    }
}