using Entities;
using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface ILikeService {
        
        IQueryable<Like> GetAllLikes(bool trackChanges);
        Like? GetOneLike(string id, bool trackChanges);
        void CreateLike(Like like);
        void Delete(Like like);
        void UpdateOneLike(Like entity);
        IQueryable<Like> GetLikesWithPostId(int postId, bool trackChanges);
    }
}