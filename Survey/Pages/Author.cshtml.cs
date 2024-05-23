using Entities.Models;
using Microsoft.AspNetCore.Identity;
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

        public void OnGet(string authorId)
        {
            Author author = _manager.AuthorService.GetOneAuthor(authorId, false);

            if (author is not null)
            {
                // p.f(author.Name + " " + author.Surname);

                AuthorId = author.Id;
                Name = author.Name;
                Surname = author.Surname;
                ImageUrl = author.ImageUrl;
                followers = _manager.FollowService.GetAllFollows(false).Where(f => f.FollowedId.Equals(authorId));
                FollowerCount = followers.Count();
                // LikeCount = _manager.LikeService.GetAllLikes(false).Where(l => l.)
                PublishCount = _manager.PostService.GetAllPosts(false).Where(p => p.PublisherId.Equals(authorId)).Count();
                CompanyImageUrl = _manager.CompanyService.GetOneCompany(author.CompanyId, false).ImageUrl;
                CompanyName = _manager.CompanyService.GetOneCompany(author.CompanyId, false).Name;

                CurrentUser = _mainPageModel.User;

                if (_mainPageModel.User is not null)
                {

                    Follow follow = followers.Where(f => f.FollowById == _mainPageModel.User.Id).FirstOrDefault();
                    if (follow is not null)
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
