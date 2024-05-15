using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBossRepository _bossRepository;
        private readonly ICommentatorRepository _commentatorRepository;
        private readonly ICompanyRepository _companyRepository;




        public RepositoryManager(RepositoryContext context, ICommentatorRepository commentatorRepository, IBossRepository bossRepository, IAuthorRepository authorRepository, ICompanyRepository companyRepository)
        {
            _context = context;
            _commentatorRepository = commentatorRepository;
            _bossRepository = bossRepository;
            _authorRepository = authorRepository;
            _companyRepository = companyRepository;
        }
        public IAuthorRepository Author => _authorRepository;
        public IBossRepository Boss => _bossRepository;
        public ICommentatorRepository Commentator => _commentatorRepository;

        public ICompanyRepository Company => _companyRepository;

        public void Save()
        {
            _context.SaveChanges();
        } 
    }
}