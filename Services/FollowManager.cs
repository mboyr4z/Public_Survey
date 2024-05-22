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
    public class FollowManager : IFollowService
    {

        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public FollowManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public void CreateFollow(Follow Follow)
        {
            _manager.Follow.Create(Follow);
            _manager.Save();
        }

        public void Delete(Follow Follow)
        {
            _manager.Follow.Delete(Follow);
            _manager.Save();
        }

        public IQueryable<Follow> GetAllFollows(bool trackChanges)
        {
            return _manager.Follow.GetAllFollows(trackChanges);
        }

        public Follow? GetOneFollow(string id, bool trackChanges)
        {
            return _manager.Follow.GetOneFollow(id, trackChanges);
        }

        public void UpdateOneFollow(Follow entity)
        {
            _manager.Follow.UpdateOneFollow(entity);
            _manager.Save();
        }
    }
}