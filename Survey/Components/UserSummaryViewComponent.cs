using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Survey.Components
{
    public class UserSummaryViewComponent : ViewComponent
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserSummaryViewComponent(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public string Invoke(){
            return _userManager.Users.Count().ToString();
        }
    }
}