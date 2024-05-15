using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {

        private readonly IAuthService _authService;
        private readonly IAuthorService _authorService;

       
        private readonly IBossService _bossService;

        private readonly ICommenterService _commenterService;



        public ServiceManager(IAuthService authService, IBossService bossService, ICommenterService commenterService, IAuthorService authorService)
        {
            _authService = authService;
            _bossService = bossService;
            _commenterService = commenterService;
            _authorService = authorService;
        }

        public IAuthService AuthService => _authService;

        public IAuthorService AuthorService => _authorService;

        public IBossService BossService => _bossService;

        public ICommenterService CommenterService => _commenterService;
    }
}