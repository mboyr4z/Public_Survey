namespace Services.Contracts
{
    public interface IServiceManager
    {
        IAuthorService AuthorService{get;}
        IBossService BossService{get;}
        ICommentatorService CommentatorService{get;}
        ICompanyService CompanyService{get;}

        IAuthService AuthService{get;}
    }
}