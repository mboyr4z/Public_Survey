namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IAuthorRepository Author { get; }
        IBossRepository Boss { get; }
        ICommentatorRepository Commentator { get; }
        ICompanyRepository Company { get; }
        void Save();
    }
}