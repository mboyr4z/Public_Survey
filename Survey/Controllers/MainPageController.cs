using System.Security.Claims;
using Benimkiler.Roles;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Survey.Benimkiler;
using Survey.Models;

namespace Survey.Controllers
{
    public class MainPageController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IServiceManager _manager;
        private MainPageModel _mainPageModel;
        public MainPageController(UserManager<IdentityUser> userManager, IServiceManager manager, MainPageModel mainPageModel)
        {
            _userManager = userManager;
            _manager = manager;
            _mainPageModel = mainPageModel;
        }

        private async Task<bool> IsLoggedInAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user is not null)
            {
                return true;
            }
            return false;
        }

        public async Task<IActionResult> Index()
        {
            _mainPageModel.IsUserLogged = false;
            _mainPageModel.IsUserConfirmed = false;
            _mainPageModel.IsUserCompletedMembership = false;
            _mainPageModel.User = null;
            _mainPageModel.Role = Roles.Guess;

            
            if(await IsLoggedInAsync()){

                _mainPageModel.IsUserLogged = true;
                _mainPageModel.IsUserConfirmed = await _manager.IsConfirmedMember(User);
                _mainPageModel.IsUserCompletedMembership = await _manager.IsSurveyUserMembershipCompletedAsync(User);
                _mainPageModel.User = await _userManager.GetUserAsync(User);
                _mainPageModel.Role = p.RoleToEnum((await _userManager.GetRolesAsync(_mainPageModel.User)).FirstOrDefault());

            }

            ViewBag.HeaderModel = _mainPageModel;
            return View(model: _mainPageModel);
        }
    }

    

    
}