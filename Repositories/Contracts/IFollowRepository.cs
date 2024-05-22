using Entities;
using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IFollowRepository : IRepositoryBase<Follow>{
        
        IQueryable<Follow> GetAllFollows(bool trackChanges);
        Follow? GetOneFollow(string id, bool trackChanges);
        void CreateFollow(Follow follow);
        void Delete(Follow follow);
        void UpdateOneFollow(Follow entity);
    }
}