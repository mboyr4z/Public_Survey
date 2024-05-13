namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IAuthorRepository Author { get; }
        IBossRepository Boss { get; }
        ICommenterRepository Commenter { get; }
        void Save();
    }
}