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
    public class LikeManager : ILikeService
    {

        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public LikeManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public void CreateLike(Like Like)
        {
            _manager.Like.Create(Like);
            _manager.Save();
        }

        public void Delete(Like Like)
        {
            _manager.Like.Delete(Like);
            _manager.Save();
        }

        public IQueryable<Like> GetAllLikes(bool trackChanges)
        {
            return _manager.Like.GetAllLikes(trackChanges);
        }

        public Like? GetOneLike(string id, bool trackChanges)
        {
            return _manager.Like.GetOneLike(id, trackChanges);
        }

        public IQueryable<Like> GetLikesWithPostId(int postId, bool trackChanges)
        {
            return _manager.Like.GetAllLikes(trackChanges).Where(l => l.PostId == postId);
        }

        public void UpdateOneLike(Like entity)
        {
            _manager.Like.UpdateOneLike(entity);
            _manager.Save();
        }
    }
}