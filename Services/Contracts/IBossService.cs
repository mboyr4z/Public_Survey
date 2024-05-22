using Entities;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface IBossService
    {
        IQueryable<Boss> GetAllBosses(bool trackChanges);
        Boss? GetOneBoss(string id, bool trackChanges);
        void CreateBoss(boss_createDto bossDto);
        void CreateBoss(Boss boss);
        void Delete(Boss boss);
        void UpdateOneBoss(boss_updateDto entity);
        void UpdateOneBoss(Boss boss);
    }
}