
using Entities.Models;

using Repositories.Contracts;


namespace Repositories
{
    public sealed class LikeRepository : RepositoryBase<Like>, ILikeRepository
    {
        public LikeRepository(RepositoryContext context) : base(context)
        {

        }


        public void CreateLike(Like Like) => Create(Like);
       


        public void Delete(Like Like) => Remove(Like);
       

       

        public IQueryable<Like> GetAllLikes(bool trackChanges) => FindAll(trackChanges);

  

        public Like GetOneLike(string id, bool trackChanges)
        {
            return FindByCondition(b => b.Id.Equals(id), trackChanges);
        }

       

        public void UpdateOneLike(Like entity)
        {
              Update(entity);
        }
    }
}