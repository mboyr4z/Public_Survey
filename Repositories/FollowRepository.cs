
using Entities.Models;

using Repositories.Contracts;


namespace Repositories
{
    public sealed class FollowRepository : RepositoryBase<Follow>, IFollowRepository
    {
        public FollowRepository(RepositoryContext context) : base(context)
        {

        }


        public void CreateFollow(Follow Follow) => Create(Follow);
       


        public void Delete(Follow Follow) => Remove(Follow);
       

       

        public IQueryable<Follow> GetAllFollows(bool trackChanges) => FindAll(trackChanges);

  

        public Follow GetOneFollow(string id, bool trackChanges)
        {
            return FindByCondition(b => b.Id.Equals(id), trackChanges);
        }

       

        public void UpdateOneFollow(Follow entity)
        {
              Update(entity);
        }
    }
}