using Benimkiler.Roles;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using Survey.Benimkiler;
using System.Threading.Tasks;

public class DeleteUserModel : PageModel
{

    [BindProperty]
    public string UserId { get; set; }

    private readonly UserManager<IdentityUser> _userManager;

    private readonly RoleManager<IdentityRole> _roleManager;

    private readonly IServiceManager _manager;

    public DeleteUserModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IServiceManager manager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _manager = manager;
    }

    public IdentityUser UserToDelete { get; set; }


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
                case Roles.Admin:
                    return await DeleteAdmin(user);
                case Roles.Author:
                    return await DeleteAuthor(user);
                case Roles.Boss:
                    return await DeleteBoss(user);
                case Roles.Commentator:
                    return await DeleteCommentator(user);
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

    private async Task<IActionResult> DeleteAdmin(IdentityUser user)
    {
        var result = await _userManager.DeleteAsync(user);
        if (result.Succeeded)
        {
            return RedirectToPage("./GetUsers");
        }

        foreach (var error in result.Errors)
        {
               p.f(error.Description);
        }
        return RedirectToPage("./GetUsers");
    }

    private async Task<IActionResult> DeleteCommentator(IdentityUser user)
    {
        string id = user.Id;

        Commentator commentator = _manager.CommentatorService.GetOneCommentator(id, false);

        if (commentator is not null)
        {
            _manager.CommentatorService.Delete(commentator);

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToPage("./GetUsers");
            }

            foreach (var error in result.Errors)
            {
                 p.f(error.Description);
            }
        }

        return RedirectToPage("./GetUsers");
    }

    private async Task<IActionResult> DeleteBoss(IdentityUser user)
    {
        string id = user.Id;
        Boss boss = _manager.BossService.GetOneBoss(id, false);

        int companyId =  boss.CompanyId;
        Company company = _manager.CompanyService.GetOneCompany(companyId, false);



        if (boss is not null)
        {

            _manager.BossService.Delete(boss);
            _manager.CompanyService.Delete(company);
            
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToPage("./GetUsers");
            }

            foreach (var error in result.Errors)
            {
                p.f(error.Description);
            }
        }

        return RedirectToPage("./GetUsers");
    }

    private async Task<IActionResult> DeleteAuthor(IdentityUser user)
    {
         string id = user.Id;

        Author author = _manager.AuthorService.GetOneAuthor(id, false);

        if (author is not null)
        {
            _manager.AuthorService.Delete(author);

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToPage("./GetUsers");
            }

            foreach (var error in result.Errors)
            {
                p.f(error.Description);
            }
        }

        return RedirectToPage("./GetUsers");
    }
}
