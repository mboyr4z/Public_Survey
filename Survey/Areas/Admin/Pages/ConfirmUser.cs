using Benimkiler.Roles;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using Survey.Benimkiler;
using System.Threading.Tasks;

public class ConfirmUserModel  : PageModel
{

    [BindProperty]
    public string UserId { get; set; }

    private readonly UserManager<IdentityUser> _userManager;

    private readonly RoleManager<IdentityRole> _roleManager;

    private readonly IServiceManager _manager;

    public ConfirmUserModel (UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IServiceManager manager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _manager = manager;
    }


        public IdentityUser UserToConfirm { get; set; }
    public async Task<IActionResult> OnPostAsync()
    {
        // p.f("POST GELDİ");
        // p.f("id : " + UserId);



        var user = await _userManager.FindByIdAsync(UserId);
        if (user != null)
        {

            var roles = await _userManager.GetRolesAsync(user);
            Roles role = p.RoleToEnum(roles.FirstOrDefault());

            switch (role)
            {
            
                case Roles.Author:
                    return await ConfirmAuthor(user);
                case Roles.Boss:
                    return await ConfirmBoss(user);
            
                default:
                    return RedirectToPage("./GetUsers");
            }
        }
        else
        {
            p.f("eleman boş geldi");
        }
        return RedirectToPage("./GetUsers");
    }

  
  

    private async Task<IActionResult> ConfirmBoss(IdentityUser user)
    {
        Boss boss = _manager.BossService.GetOneBoss(user.Id, false);

        if(boss is not null){
            boss.Confirmed = true;

            _manager.BossService.UpdateOneBoss(boss);
        }

        return RedirectToPage("./GetUsers");
    }

     private async Task<IActionResult> ConfirmAuthor(IdentityUser user)
    {
        Author author = _manager.AuthorService.GetOneAuthor(user.Id, false);

        if(author is not null){
            author.Confirmed = true;

            _manager.AuthorService.UpdateOneAuthor(author);
        }

        return RedirectToPage("./GetUsers");
    }

}
