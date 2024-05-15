namespace Services.Contracts
{
    public interface IServiceManager
    {
        IAuthorService AuthorService{get;}
        IBossService BossService{get;}
        ICommenterService CommenterService{get;}
        IAuthService AuthService{get;}
    }
}