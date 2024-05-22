using System.Security.Claims;
using Benimkiler.Roles;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {

        private readonly IAuthService _authService;
        private readonly IAuthorService _authorService;
        private readonly IBossService _bossService;
        private readonly ICommentatorService _commentatorService;
        private readonly ICompanyService _companyService;

        private readonly IChatService _chatService;

        private readonly ICommentService _commentService;

        private readonly IFollowService _followService;

        private readonly ILikeService _likeService;

        private readonly IPostService _postService;

        private readonly UserManager<IdentityUser> _userManager;



        public ServiceManager(IAuthService authService, IBossService bossService, ICommentatorService commentatorService, IAuthorService authorService, ICompanyService companyService, UserManager<IdentityUser> userManager, IChatService chatService, ICommentService commentService, IFollowService followService, ILikeService likeService, IPostService postService)
        {
            _authService = authService;
            _bossService = bossService;
            _commentatorService = commentatorService;
            _authorService = authorService;
            _companyService = companyService;
            _userManager = userManager;
            _chatService = chatService;
            _commentService = commentService;
            _followService = followService;
            _likeService = likeService;
            _postService = postService;
        }

        public IAuthService AuthService => _authService;

        public IAuthorService AuthorService => _authorService;

        public IBossService BossService => _bossService;

        public ICommentatorService CommentatorService => _commentatorService;

        public ICompanyService CompanyService => _companyService;

        public IChatService ChatService => _chatService;

        public ICommentService CommentService => _commentService;

        public IFollowService FollowService => _followService;

        public ILikeService LikeService => _likeService;

        public IPostService PostService => _postService;

        public async Task<bool> IsConfirmedMember(ClaimsPrincipal curUser)
        {
            IdentityUser user = await _userManager.GetUserAsync(curUser);

            if (user is not null)
            {
                string firstRole = (await _userManager.GetRolesAsync(user))[0];

                Roles signingRole = (Roles)Enum.Parse(typeof(Roles), firstRole);

                switch (signingRole)
                {
                    case Roles.Author:
                        Author author = _authorService.GetOneAuthor(user.Id, false);
                        if (author is not null)
                        {
                            return (bool)author.Confirmed;
                        }
                        break;
                    case Roles.Boss:
                        Boss boss = _bossService.GetOneBoss(user.Id, false);
                        if (boss is not null)
                        {
                            return (bool)boss.Confirmed;
                        }
                        break;
                    default:
                        return false;
                }
            }
            return false;
        }

        public async Task<bool> IsSurveyUserMembershipCompletedAsync(ClaimsPrincipal curUser)
        {
            IdentityUser user = await _userManager.GetUserAsync(curUser);

            if (user is not null)
            {
                string firstRole = (await _userManager.GetRolesAsync(user))[0];

                Roles signingRole = (Roles)Enum.Parse(typeof(Roles), firstRole);

                switch (signingRole)
                {
                    case Roles.Author:
                        Author author = _authorService.GetOneAuthor(user.Id, false);
                        if (author is not null)
                        {
                            return true;
                        }
                        break;
                    case Roles.Boss:
                        Boss boss = _bossService.GetOneBoss(user.Id, false);
                        if (boss is not null)
                        {
                            return true;
                        }
                        break;
                    case Roles.Commentator:
                        Commentator commentator  = _commentatorService.GetOneCommentator(user.Id, false);
                        if (commentator is not null)
                        {
                            return true;
                        }
                        break;

                    default:
                        return true;
                        break;
                }
            }
            return false;
        }

    }
}