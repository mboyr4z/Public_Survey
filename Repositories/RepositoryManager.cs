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
        private readonly IChatRepository _chatRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IFollowRepository _followRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly IPostRepository _postRepository;




        public RepositoryManager(RepositoryContext context, ICommentatorRepository commentatorRepository, IBossRepository bossRepository, IAuthorRepository authorRepository, ICompanyRepository companyRepository, IChatRepository chatRepository, ICommentRepository commentRepository, IFollowRepository followRepository, ILikeRepository likeRepository, IPostRepository postRepository)
        {
            _context = context;
            _commentatorRepository = commentatorRepository;
            _bossRepository = bossRepository;
            _authorRepository = authorRepository;
            _companyRepository = companyRepository;
            _chatRepository = chatRepository;
            _commentRepository = commentRepository;
            _followRepository = followRepository;
            _likeRepository = likeRepository;
            _postRepository = postRepository;
        }
        public IAuthorRepository Author => _authorRepository;
        public IBossRepository Boss => _bossRepository;
        public ICommentatorRepository Commentator => _commentatorRepository;
        public ICompanyRepository Company => _companyRepository;
        public IChatRepository Chat => _chatRepository;
        public ICommentRepository Comment => _commentRepository;
        public IFollowRepository Follow => _followRepository;
        public ILikeRepository Like => _likeRepository;
        public IPostRepository Post => _postRepository;

        public void Save()
        {
            _context.SaveChanges();
        } 
    }
}