using Entities;
using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface ICommenterRepository : IRepositoryBase<Commenter>{
        
        IQueryable<Commenter> GetAllCommenters(bool trackChanges);
        IQueryable<Commenter> GetAllCommentersWithDetails(CommenterRequestParameters p);
        Commenter? GetOneCommenter(string id, bool trackChanges);
        void CreateCommenter(Commenter commenter);
        void Delete(Commenter commenter);
        void UpdateOneCommenter(Commenter entity);
    }
}