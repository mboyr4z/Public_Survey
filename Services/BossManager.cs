using AutoMapper;
using Entities;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;
using SQLitePCL;

namespace Services
{
    public class BossManager : IBossService
    {

        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public BossManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public void CreateBoss(boss_createDto bossDto)
        {
            Boss newBoss = _mapper.Map<Boss>(bossDto);
            _manager.Boss.Create(newBoss);
            _manager.Save();
        }

        public void CreateBoss(Boss boss)
        {
            _manager.Boss.Create(boss);
            _manager.Save();
        }

        public void Delete(Boss boss)
        {
            _manager.Boss.Delete(boss);
            _manager.Save();
        }

        public IQueryable<Boss> GetAllBosses(bool trackChanges)
        {
           return _manager.Boss.GetAllBosses(trackChanges);
        }


        public Boss? GetOneBoss(string id, bool trackChanges)
        {
            return _manager.Boss.GetOneBoss(id, trackChanges);
        }

        public void UpdateOneBoss(boss_updateDto entity)
        {
            Boss updatingBoss = _mapper.Map<Boss>(entity);
            _manager.Boss.UpdateOneBoss(updatingBoss);
            _manager.Save();
        }
    }
}