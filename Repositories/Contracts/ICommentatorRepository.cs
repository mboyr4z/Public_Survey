using Entities;
using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface ICommentatorRepository : IRepositoryBase<Commentator>{
        
        IQueryable<Commentator> GetAllCommentators(bool trackChanges);
        IQueryable<Commentator> GetAllCommentatorsWithDetails(CommentatorRequestParameters p);
        Commentator? GetOneCommentator(string id, bool trackChanges);
        void CreateCommentator(Commentator commentator);
        void Delete(Commentator commentator);
        void UpdateOneCommentator(Commentator entity);
    }
}