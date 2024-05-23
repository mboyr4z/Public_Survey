using Benimkiler.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using Survey.Benimkiler;

namespace Survey.Pages
{
    public class RouterPageModel : PageModel
    {

        private readonly UserManager<IdentityUser> _userManager;
        public RouterPageModel( UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(string userId)
        {
            IdentityUser user = await _userManager.FindByIdAsync(userId);

            if (user is not null)
            {
                string roleText = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                Roles role = p.RoleToEnum(roleText);
                // p.f("roleText: " + roleText + " role : " + role.ToString());
                // p.f("id : " + user.Id + " -> role :" + role);

                if (role == Roles.Author)
                {
                    // p.f("a");
                    return RedirectToPage("/Author", new { authorId = userId });
                }
                else if (role == Roles.Commentator)
                {
                    // p.f("c");
                    return RedirectToPage("/Commentator", new { commentatorId = userId });
                }
                else if (role == Roles.Boss)
                {
                    // p.f("b");
                    return RedirectToPage("/Boss", new { bossId = userId });
                }

            }else{
                p.f("kullanıcı yok");
            }

            return RedirectToPage("/Boss");
        }


    }


}
