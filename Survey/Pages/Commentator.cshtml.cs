using Benimkiler.Roles;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using Survey.Benimkiler;
using Survey.Models;

namespace Survey.Pages
{
    public class CommentatorPageModel : PageModel
    {
        public string CommentatorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName => Name + " " + Surname;
        public string ImageUrl { get; set; }
        public int FollowerCount { get; set; }
        public bool CommentatorFollowing;
        public IdentityUser CurrentUser { get; set; }
        private IQueryable<Follow> Followers;
        private readonly IServiceManager _manager;
        private MainPageModel _mainPageModel;

        public CommentatorPageModel(IServiceManager manager, MainPageModel mainPageModel)
        {
            _manager = manager;
            _mainPageModel = mainPageModel;
        }

        private Commentator commentator;
        public void OnGet(string _CommentatorId)
        {
            commentator = _manager.CommentatorService.GetOneCommentator(_CommentatorId, false);

            if (commentator is not null)
            {
                // p.f(author.Name + " " + author.Surname);

                CommentatorId = commentator.Id;
                Name = commentator.Name;
                Surname = commentator.Surname;
                ImageUrl = commentator.ImageUrl;
                Followers = _manager.FollowService.GetAllFollows(false).Where(f => f.FollowedId.Equals(_CommentatorId));
                FollowerCount = Followers.Count();

                CurrentUser = _mainPageModel.User;

                if (_mainPageModel.User is not null)
                {
                    Follow IFollowToThisAuthor = Followers.Where(f => f.FollowById.Equals(_mainPageModel.User.Id)).FirstOrDefault(); // authorun takipçi lsitesinde ben varmıyım
                    if (IFollowToThisAuthor is not null)
                    {
                        CommentatorFollowing = true;
                    }
                    else
                    {
                        CommentatorFollowing = false;
                    }
                }
            }
        }


        

    }


}
