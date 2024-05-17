using System.Dynamic;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IAuthorService AuthorService{get;}
        IBossService BossService{get;}
        ICommentatorService CommentatorService{get;}
        ICompanyService CompanyService{get;}

        IAuthService AuthService{get;}

        Task<bool> IsSurveyUserMembershipCompletedAsync(ClaimsPrincipal curUser);
    }
}