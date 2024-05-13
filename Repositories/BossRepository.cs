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
       

      
        
      public IQueryable<Boss> GetAllBossesWithDetails(BossRequestParameters pr)
        {
            IQueryable<Boss> bosses = GetAllBosses(false)
            .FilteredByName(boss => boss.Name, pr.Name)
            .FilteredBySurname(boss => boss.Surname, pr.Surname)
            .FilteredByLikeRate(boss => (int)boss.LikeRate, pr.minLikeRate, pr.maxLikeRate, pr.IsValidLikeRate);

            return bosses;
        }
       

        public Boss? GetOneBoss(string id, bool trackChanges)
        {
            return FindByCondition(b => b.id.Equals(id), trackChanges);
        }

       

        public void UpdateOneBoss(Boss entity)
        {
              Update(entity);
        }
    }
}