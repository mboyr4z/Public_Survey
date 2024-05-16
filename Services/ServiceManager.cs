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



        public ServiceManager(IAuthService authService, IBossService bossService, ICommentatorService commentatorService, IAuthorService authorService, ICompanyService companyService)
        {
            _authService = authService;
            _bossService = bossService;
            _commentatorService = commentatorService;
            _authorService = authorService;
            _companyService = companyService;
        }

        public IAuthService AuthService => _authService;

        public IAuthorService AuthorService => _authorService;

        public IBossService BossService => _bossService;

        public ICommentatorService CommentatorService => _commentatorService;

        public ICompanyService CompanyService => _companyService;
    }
}