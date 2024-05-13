using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IAuthorRepository _authorRepository;

        private readonly IBossRepository _bossRepository;
        private readonly ICommenterRepository _commenterRepository;


        public RepositoryManager(RepositoryContext context, ICommenterRepository commenterRepository, IBossRepository bossRepository, IAuthorRepository authorRepository)
        {
            _context = context;
            _commenterRepository = commenterRepository;
            _bossRepository = bossRepository;
            _authorRepository = authorRepository;
        }
        public IAuthorRepository Author => _authorRepository;
        public IBossRepository Boss => _bossRepository;
        public ICommenterRepository Commenter => _commenterRepository;

        public void Save()
        {
            _context.SaveChanges();
        } 
    }
}