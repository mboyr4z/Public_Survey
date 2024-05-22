using Entities;
using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface ILikeRepository : IRepositoryBase<Like>{
        
        IQueryable<Like> GetAllLikes(bool trackChanges);
        Like? GetOneLike(string id, bool trackChanges);
        void CreateLike(Like like);
        void Delete(Like like);
        void UpdateOneLike(Like entity);
    }
}