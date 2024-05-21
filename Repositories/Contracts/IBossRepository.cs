using Entities;
using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IBossRepository : IRepositoryBase<Boss>{
        
        IQueryable<Boss> GetAllBosses(bool trackChanges);
        Boss GetOneBoss(string id, bool trackChanges);
        void CreateBoss(Boss boss);
        void Delete(Boss boss);
        void UpdateOneBoss(Boss entity);
    }
}