using System.Dynamic;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Repositories.Contracts;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IAuthorService AuthorService{get;}
        IBossService BossService{get;}
        ICommentatorService CommentatorService{get;}
        ICompanyService CompanyService{get;}

        IAuthService AuthService{get;}

        IChatService ChatService{get;}

        ICommentService CommentService{get;}

        IFollowService FollowService{get;}

        ILikeService LikeService{get;}

        IPostService PostService{get;}
        Task<bool> IsConfirmedMember(ClaimsPrincipal curUser);
        Task<bool> IsSurveyUserMembershipCompletedAsync(ClaimsPrincipal curUser);
    }
}