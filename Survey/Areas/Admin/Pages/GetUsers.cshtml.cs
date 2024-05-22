using Benimkiler.Roles;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using Survey.Benimkiler;
using Survey.Infrastructure.Extensions;

namespace MyApp.Pages
{
    public class GetUsersModel : PageModel
    {
        [BindProperty]
        public string RoleName { get; set; }

        [BindProperty]
        public SurveyUserRequestParameters _surveyUserRequestParameters { get; set; }
        [BindProperty]
        public IdentityUserRequestParameters _identityUserRequestParameters { get; set; }

        public SelectList roleSelectList;
        public Roles role;
        public RegisteredAdmins registeredAdmins;
        public RegisteredAuthors registeredAuthors;
        public RegisteredBosses registeredBosses;
        public RegisteredCommentators registeredCommentators;
        private readonly IServiceManager _manager;
        private readonly UserManager<IdentityUser> _userManager;

        public GetUsersModel(IServiceManager manager, UserManager<IdentityUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        private void FindRoles()
        {
            roleSelectList = new SelectList(_manager.AuthService.Roles.Select(
               r => new SelectListItem
               {
                   Value = r.Name,
                   Text = r.Name
               }
           ), "Value", "Text");

        }
        public void OnGet()
        {
            role = Roles.Guess;
            // p.f("get ");
            FindRoles();
        }

        public async Task OnPostAsync()
        {
            // p.f("param : username : " + _identityUserRequestParameters.Username);
            // p.f("param : mail : " + _identityUserRequestParameters.Email);

            // p.f("role name : " + role.ToString());
            // p.f("post");

            role = p.RoleToEnum(RoleName);
            switch (role)
            {
                case Roles.Admin:
                    FindAllAdminsAsync();
                    p.f("admin sayısı : " + registeredAdmins.adminList.Count());
                    break;
                case Roles.Author:
                    FindAllAuthorsAsync();
                    p.f("author sayısı : " + registeredAuthors.authorList.Count());
                    break;
                case Roles.Boss:
                    FindAllBossesAsync();
                    p.f("boss sayısı : " + registeredBosses.bossList.Count());
                    break;
                case Roles.Commentator:
                    FindAllCommentatorsAsync();
                    p.f("commentator sayısı : " + registeredCommentators.commentatorList.Count());
                    break;
                default:
                    break;
            }
            FindRoles();

        }

        private async Task FindAllAdminsAsync()
        {
            IList<IdentityUser> IdentityAdmins = await _userManager.GetUsersInRoleAsync("Admin");

            registeredAdmins = new RegisteredAdmins();

            foreach (IdentityUser item in IdentityAdmins)
            {
                registeredAdmins.adminList.Add(
                    item
                );
            }

            registeredAdmins.FilteringRegisteredAdmins(_identityUserRequestParameters);
            registeredAdmins._surveyUserRequestParameters = _surveyUserRequestParameters;
            registeredAdmins._identityUserRequestParameters = _identityUserRequestParameters;
        }

        private async Task FindAllAuthorsAsync()
        {
            IList<IdentityUser> IdentityAuthors = await _userManager.GetUsersInRoleAsync("Author");

            registeredAuthors = new RegisteredAuthors();

            foreach (IdentityUser item in IdentityAuthors)
            {

                Author author = _manager.AuthorService.GetOneAuthor(item.Id, false);


                registeredAuthors.authorList.Add(
                    new AuthorItem
                    {
                        user = item,
                        author = author,
                        company = author is not null ? _manager.CompanyService.GetOneCompany(author.CompanyId, false) : null
                    }
                );
            }

            registeredAuthors.FilteringRegisteredAuthorsByIdentityUser(_surveyUserRequestParameters, _identityUserRequestParameters);
            registeredAuthors._surveyUserRequestParameters = _surveyUserRequestParameters;
            registeredAuthors._identityUserRequestParameters = _identityUserRequestParameters;


        }

        private async Task FindAllBossesAsync()
        {
            IList<IdentityUser> IdentityBosses = await _userManager.GetUsersInRoleAsync("Boss");

            registeredBosses = new RegisteredBosses();

            foreach (IdentityUser item in IdentityBosses)
            {



                Boss newBoss = _manager.BossService.GetOneBoss(item.Id, false);
                Company newCompany = null;

                if (newBoss is not null)
                {
                    newCompany = _manager.CompanyService.GetOneCompany(newBoss.CompanyId, false);
                }




                registeredBosses.bossList.Add(
                    new BossItem
                    {
                        user = item,
                        boss = newBoss,
                        company = newCompany
                    }
                );







            }


            registeredBosses.FilteringRegisteredBossesByIdentityUser(_surveyUserRequestParameters, _identityUserRequestParameters);
            registeredBosses._surveyUserRequestParameters = _surveyUserRequestParameters;
            registeredBosses._identityUserRequestParameters = _identityUserRequestParameters;
        }

        private async Task FindAllCommentatorsAsync()
        {
            IList<IdentityUser> IdentityCommentators = await _userManager.GetUsersInRoleAsync("Commentator");

            registeredCommentators = new RegisteredCommentators();

            foreach (IdentityUser item in IdentityCommentators)
            {
                registeredCommentators.commentatorList.Add(
                    new CommentatorItem
                    {
                        user = item,
                        commentator = _manager.CommentatorService.GetOneCommentator(item.Id, false)
                    }

                );
            }
            registeredCommentators.FilteringRegisteredCommentatorsByIdentityUser(_surveyUserRequestParameters, _identityUserRequestParameters);
            registeredCommentators._surveyUserRequestParameters = _surveyUserRequestParameters;
            registeredCommentators._identityUserRequestParameters = _identityUserRequestParameters;
        }
    }


    public class RegisteredAdmins : RequestClass
    {

        public RegisteredAdmins()
        {
            adminList = new List<IdentityUser>();
        }
        public List<IdentityUser> adminList;
    }

    public abstract class RequestClass
    {
        public SurveyUserRequestParameters _surveyUserRequestParameters { get; set; }
        public IdentityUserRequestParameters _identityUserRequestParameters { get; set; }
    }

    public class RegisteredAuthors : RequestClass
    {

        public RegisteredAuthors()
        {
            authorList = new List<AuthorItem>();
        }
        public List<AuthorItem> authorList;
    }

    public class AuthorItem
    {

        public IdentityUser user;
        public Author author;

        public Company company;
    }



    public class RegisteredBosses : RequestClass
    {
        public RegisteredBosses()
        {
            bossList = new List<BossItem>();
        }
        public List<BossItem> bossList;
    }


    public class BossItem
    {
        public IdentityUser user;
        public Boss boss;

        public Company company;
    }
    public class RegisteredCommentators : RequestClass
    {
        public RegisteredCommentators()
        {
            commentatorList = new List<CommentatorItem>();
        }
        public List<CommentatorItem> commentatorList;
    }

    public class CommentatorItem
    {
        public IdentityUser user;
        public Commentator commentator;
    }


}
