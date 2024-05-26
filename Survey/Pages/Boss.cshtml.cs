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
                Followers = _manager.FollowService.GetAllFollows(false).Where(f => f.FollowedId.Equals(_authorId));
                FollowerCount = Followers.Count();
                AllPosts = _manager.PostService.GetAllPosts(false).Where(p => p.PublisherId.Equals(author.Id)).ToList();
                GlobalPosts = AllPosts.Where(p => p.IsGlobal == true).ToList();

                LikeCount = 0;
                foreach (Post post in AllPosts)
                {
                    LikeCount += _manager.LikeService.GetLikesWithPostId(post.Id, false).Count();
                }



                PublishCount = _manager.PostService.GetAllPosts(false).Where(p => p.PublisherId.Equals(_authorId)).Count();
                CompanyImageUrl = _manager.CompanyService.GetOneCompany(author.CompanyId, false).ImageUrl;
                CompanyName = _manager.CompanyService.GetOneCompany(author.CompanyId, false).Name;

                CurrentUser = _mainPageModel.User;

                if (_mainPageModel.User is not null)
                {
                    Follow IFollowToThisAuthor = Followers.Where(f => f.FollowById.Equals(_mainPageModel.User.Id)).FirstOrDefault(); // authorun takipçi lsitesinde ben varmıyım
                    if (IFollowToThisAuthor is not null)
                    {
                        AuthorFollowing = true;
                    }
                    else
                    {
                        AuthorFollowing = false;
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
