using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using Survey.Benimkiler;
using Survey.Models;

namespace Survey.Pages
{
    public class AuthorPageModel : PageModel
    {
        public string AuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName => Name + " " + Surname;
        public string ImageUrl { get; set; }
        public int FollowerCount { get; set; }
        public int LikeCount { get; set; }
        public int PublishCount { get; set; }
        public string CompanyImageUrl { get; set; }
        public string CompanyName { get; set; }
        public string Information => "Author at " + CompanyName;
        public bool AuthorFollowing;
        private readonly IServiceManager _manager;
        private IQueryable<Follow> followers;

        private MainPageModel _mainPageModel;

        public IdentityUser CurrentUser {get;set;}

        public AuthorPageModel(IServiceManager manager, MainPageModel mainPageModel)
        {
            _manager = manager;
            _mainPageModel = mainPageModel;
        }

        private Author author;
        public void OnGet(string _authorId)
        {
            author = _manager.AuthorService.GetOneAuthor(_authorId, false);

            if (author is not null)
            {
                // p.f(author.Name + " " + author.Surname);

                AuthorId = author.Id;
                Name = author.Name;
                Surname = author.Surname;
                ImageUrl = author.ImageUrl;
                followers = _manager.FollowService.GetAllFollows(false).Where(f => f.FollowedId.Equals(_authorId));
                FollowerCount = followers.Count();
                // LikeCount = _manager.LikeService.GetAllLikes(false).Where(l => l.)
                PublishCount = _manager.PostService.GetAllPosts(false).Where(p => p.PublisherId.Equals(_authorId)).Count();
                CompanyImageUrl = _manager.CompanyService.GetOneCompany(author.CompanyId, false).ImageUrl;
                CompanyName = _manager.CompanyService.GetOneCompany(author.CompanyId, false).Name;

                CurrentUser = _mainPageModel.User;

                if (_mainPageModel.User is not null)
                {
                    Follow IFollowToThisAuthor = followers.Where(f => f.FollowById.Equals(_mainPageModel.User.Id)).FirstOrDefault(); // authorun takipçi lsitesinde ben varmıyım
                    if (IFollowToThisAuthor is not null)
                    {
                        AuthorFollowing = true;
                    }else{
                        AuthorFollowing = false;
                    }
                }
            }
        }

     

        public async Task OnPostAsync()
        {

        }
    }


}
