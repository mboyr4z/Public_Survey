using Benimkiler.Roles;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Survey.Benimkiler;
using Survey.Models;

namespace Survey.Components
{
    public class ShowPostsViewComponent : ViewComponent
    {

        private readonly IServiceManager _manager;
        private readonly UserManager<IdentityUser> _userManager;

        public readonly MainPageModel _mainPageModel;
        public ShowPostsViewComponent(IServiceManager manager, UserManager<IdentityUser> userManager, MainPageModel mainPageModel)
        {
            _manager = manager;
            _userManager = userManager;
            _mainPageModel = mainPageModel;
        }

        private List<ShowedPost> showedPosts;
        private ShowedPost newShowedPost;
        private Company publisherCompany;
        private IdentityUser publisher;
        public async Task<IViewComponentResult> InvokeAsync()
        {
            showedPosts = new List<ShowedPost>();

            List<string> myFollowList = null;
            if (_mainPageModel.User is not null)
            {
                myFollowList = _manager.FollowService.GetAllFollows(false)
                    .Where(f => f.FollowById.Equals(_mainPageModel.User.Id)).Select(p => p.FollowedId).ToList();
            }

            var posts = _manager.PostService.GetAllPosts(false).Where(p => p.IsGlobal == true);

            if (_mainPageModel.User is not null)
            {
                posts = _manager.PostService.GetAllPosts(false).Where(p => p.IsGlobal == true || myFollowList.Contains(p.PublisherId));
            }

            foreach (Post post in posts)
            {
                newShowedPost = new ShowedPost();
                newShowedPost.publisherId = post.PublisherId;
                newShowedPost.content = post.Content;
                newShowedPost.publishTime = post.PublishTime;
                newShowedPost.likeCount = _manager.LikeService.GetLikesWithPostId(post.Id, false).Count();
                newShowedPost.commentCount = _manager.CommentService.GetCommentsWithPostId(post.Id, false).Count();
                

                publisher = await _userManager.FindByIdAsync(newShowedPost.publisherId);
                
                Roles role = p.RoleToEnum((await _userManager.GetRolesAsync(publisher)).FirstOrDefault());

                if (role == Roles.Author)
                {
                    Author author = _manager.AuthorService.GetOneAuthor(newShowedPost.publisherId, false);
                    newShowedPost.publisherFullName = author.Name + " " + author.Surname;
                    newShowedPost.publisherImagePath = author.ImageUrl;

                    publisherCompany = _manager.CompanyService.GetOneCompany(author.CompanyId, false);

                }
                else
                {
                    Boss boss = _manager.BossService.GetOneBoss(newShowedPost.publisherId, false);
                    newShowedPost.publisherFullName = boss.Name + " " + boss.Surname;
                    newShowedPost.publisherImagePath = boss.ImageUrl;

                    publisherCompany = _manager.CompanyService.GetOneCompany(boss.CompanyId, false);
                }

                newShowedPost.publisherInformation = role.ToString() + " at " + publisherCompany.Name;
                showedPosts.Add(
                    newShowedPost
                );
            }
            return View(model: showedPosts);
        }
    }


}