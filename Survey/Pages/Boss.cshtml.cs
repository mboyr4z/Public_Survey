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
    public class BossPageModel : PageModel
    {
        public string BossId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName => Name + " " + Surname;
        public string ImageUrl { get; set; }
        public int FollowerCount { get; set; }
        public int LikeCount { get; set; }
        public int PublishCount { get; set; }
        public string CompanyImageUrl { get; set; }
        public string CompanyName { get; set; }
        public string Information => "Boss at " + CompanyName;
        public bool BossFollowing;

        public List<Post> AllPosts;
        public List<Post> GlobalPosts;

        public IdentityUser CurrentUser { get; set; }
        private IQueryable<Follow> Followers;


        private readonly IServiceManager _manager;
        private MainPageModel _mainPageModel;


        public BossPageModel(IServiceManager manager, MainPageModel mainPageModel)
        {
            _manager = manager;
            _mainPageModel = mainPageModel;
        }

        private Boss boss;
        public void OnGet(string _bossId)
        {
            boss = _manager.BossService.GetOneBoss(_bossId, false);

            if (boss is not null)
            {
                // p.f(author.Name + " " + author.Surname);

                BossId = boss.Id;
                Name = boss.Name;
                Surname = boss.Surname;
                ImageUrl = boss.ImageUrl;
                Followers = _manager.FollowService.GetAllFollows(false).Where(f => f.FollowedId.Equals(_bossId));
                FollowerCount = Followers.Count();
                AllPosts = _manager.PostService.GetAllPosts(false).Where(p => p.PublisherId.Equals(boss.Id)).ToList();
                GlobalPosts = AllPosts.Where(p => p.IsGlobal == true).ToList();

                LikeCount = 0;
                foreach (Post post in AllPosts)
                {
                    LikeCount += _manager.LikeService.GetLikesWithPostId(post.Id, false).Count();
                }



                PublishCount = _manager.PostService.GetAllPosts(false).Where(p => p.PublisherId.Equals(_bossId)).Count();
                CompanyImageUrl = _manager.CompanyService.GetOneCompany(boss.CompanyId, false).ImageUrl;
                CompanyName = _manager.CompanyService.GetOneCompany(boss.CompanyId, false).Name;

                CurrentUser = _mainPageModel.User;

                if (_mainPageModel.User is not null)
                {
                    Follow IFollowToThisAuthor = Followers.Where(f => f.FollowById.Equals(_mainPageModel.User.Id)).FirstOrDefault(); // authorun takipçi lsitesinde ben varmıyım
                    if (IFollowToThisAuthor is not null)
                    {
                        BossFollowing = true;
                    }
                    else
                    {
                        BossFollowing = false;
                    }
                }
            }
        }

        List<ShowedPost> showedPosts;
        ShowedPost newShowedPost;

        public List<ShowedPost> PostToShowedPost(List<Post> posts)
        {
            showedPosts = new List<ShowedPost>();
            foreach (Post post in posts)
            {
                newShowedPost = new ShowedPost();
                newShowedPost.publisherId = post.PublisherId;
                newShowedPost.content = post.Content;
                newShowedPost.publishTime = post.PublishTime;
                newShowedPost.likeCount = _manager.LikeService.GetLikesWithPostId(post.Id, false).Count();
                newShowedPost.commentCount = _manager.CommentService.GetCommentsWithPostId(post.Id, false).Count();
                newShowedPost.postId = post.Id;




                newShowedPost.publisherFullName = FullName;
                newShowedPost.publisherImagePath = ImageUrl;




                newShowedPost.publisherInformation = CompanyName;
                showedPosts.Add(
                    newShowedPost
                );
            }

            return showedPosts;
        }


    }


}
