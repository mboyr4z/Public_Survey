using Benimkiler.Roles;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using Survey.Benimkiler;

namespace MyApp.Pages
{
    public class GetUsersModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }

        public SelectList roleSelectList;

        public Roles role;
        public List<ListedAdmin> admins;
        public List<ListedAuthor> authors;
        public List<ListedBoss> bosses;
        public List<ListedCommentator> commentators;

        private readonly IServiceManager _manager;

        private readonly UserManager<IdentityUser> _userManager;

        public GetUsersModel(IServiceManager manager, UserManager<IdentityUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        public void OnGet()
        {
            role = Roles.Guess;
           FindRoles();
        }

        private void FindRoles(){
             roleSelectList = new SelectList(_manager.AuthService.Roles.Select(
                r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                }
            ), "Value", "Text");

        }

        public async Task OnPostAsync()
        {
            role = p.RoleToEnum(Name);
            switch (role)
            {
                case Roles.Admin:
                    FindAllAdminsAsync();
                    // p.f("admin sayısı : " + admins.Count());
                    break;
                case Roles.Author:
                    FindAllAuthorsAsync();
                    // p.f("author sayısı : " + authors.Count());
                    break;
                case Roles.Boss:
                    FindAllBossesAsync();
                    // p.f("boss sayısı : " + bosses.Count());
                    break;
                case Roles.Commentator:
                    FindAllCommentatorsAsync();
                    // p.f("commentator sayısı : " + commentators.Count());
                    break;
                default:
                    break;
            }
                  FindRoles();

        }

        private async Task FindAllAdminsAsync()
        {
            IList<IdentityUser> IdentityAdmins = await _userManager.GetUsersInRoleAsync("Admin");

            admins = new List<ListedAdmin>();

            foreach (IdentityUser item in IdentityAdmins)
            {
                admins.Add(
                    new ListedAdmin
                    {
                        user = item
                    }
                );
            }
        }


        private async Task FindAllAuthorsAsync()
        {
            IList<IdentityUser> IdentityAuthors = await _userManager.GetUsersInRoleAsync("Author");

            authors = new List<ListedAuthor>();

            foreach (IdentityUser item in IdentityAuthors)
            {
                authors.Add(
                    new ListedAuthor
                    {
                        user = item,
                        author = _manager.AuthorService.GetOneAuthor(item.Id, false)
                    }
                );
            }
        }

        private async Task FindAllBossesAsync()
        {
            IList<IdentityUser> IdentityBosses = await _userManager.GetUsersInRoleAsync("Boss");

            bosses = new List<ListedBoss>();

            foreach (IdentityUser item in IdentityBosses)
            {
                bosses.Add(
                    new ListedBoss
                    {
                        user = item,
                        boss = _manager.BossService.GetOneBoss(item.Id, false)
                    }
                );
            }
        }

        private async Task FindAllCommentatorsAsync()
        {
            IList<IdentityUser> IdentityCommentators = await _userManager.GetUsersInRoleAsync("Commentator");

            commentators = new List<ListedCommentator>();

            foreach (IdentityUser item in IdentityCommentators)
            {
                commentators.Add(
                    new ListedCommentator
                    {
                        user = item,
                        commentator = _manager.CommentatorService.GetOneCommentator(item.Id, false)
                    }
                );
            }
        }
    }

    public class ListedUser
    {
        public IdentityUser user;

    }

    public class ListedAuthor : ListedUser
    {
        public Author author;
    }

    public class ListedAdmin : ListedUser
    {
    }

    public class ListedBoss : ListedUser
    {
        public Boss boss;
    }

    public class ListedCommentator : ListedUser
    {
        public Commentator commentator;
    }
}
