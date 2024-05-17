using System.Security.Claims;
using Benimkiler.Roles;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Survey.Components
{
    public class ConfirmedMembershipForAuthorAndBossViewComponent : ViewComponent
    {
        private UserManager<IdentityUser> _userManager;

        private readonly IServiceManager _manager;
        public ConfirmedMembershipForAuthorAndBossViewComponent(UserManager<IdentityUser> userManager, IServiceManager manager)
        {
            _userManager = userManager;
            _manager = manager;
        }

        public async Task<string> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(UserClaimsPrincipal);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var roleString = roles.FirstOrDefault(); // Kullanıcının ilk rolünü alıyoruz (birden fazla rol varsa)

                Roles role = (Roles)Enum.Parse(typeof(Roles), roleString);

                switch (role)
                {
                    case Roles.Author:
                        Author author = _manager.AuthorService.GetOneAuthor(user.Id, false);

                        return  (bool)author.Confirmed ? "" : "your membership has not yet been approved";
                        break;
                    case Roles.Boss:
                        Boss boss = _manager.BossService.GetOneBoss(user.Id, false);

                         return  (bool)boss.Confirmed ? "" : "your membership has not yet been approved";
                        break;
                    default:
                        break;
                }

            }
           return "your membership has not yet been approved";
        }
    }
}