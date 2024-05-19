using Entities;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{
    public sealed class BossRepository : RepositoryBase<Boss>, IBossRepository
    {
        public BossRepository(RepositoryContext context) : base(context)
        {

        }


        public void CreateBoss(Boss boss) => Create(boss);
       


        public void Delete(Boss boss) => Remove(boss);
       

       

        public IQueryable<Boss> GetAllBosses(bool trackChanges) => FindAll(trackChanges);
       

      

       

        public Boss? GetOneBoss(string id, bool trackChanges)
        {
            return FindByCondition(b => b.Id.Equals(id), trackChanges);
        }

       

        public void UpdateOneBoss(Boss entity)
        {
              Update(entity);
        }
    }
}