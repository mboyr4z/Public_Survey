namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IAuthorRepository Author { get; }
        IBossRepository Boss { get; }
        ICommentatorRepository Commentator { get; }
        ICompanyRepository Company { get; }
        IChatRepository Chat { get; }
        ICommentRepository Comment { get; }
        IFollowRepository Follow { get; }
        ILikeRepository Like { get; }
        IPostRepository Post { get; }

        void Save();
    }
}