using AutoMapper;
using Entities;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CommenterManager : ICommenterService
    {

        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CommenterManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public void CreateCommenter(commenter_createDto commenter)
        {
            Commenter newCommenter = _mapper.Map<Commenter>(commenter);
            _manager.Commenter.Create(newCommenter);
            _manager.Save();
        }

        public void Delete(Commenter commenter)
        {
            _manager.Commenter.Delete(commenter);
            _manager.Save();
        }

        public IQueryable<Commenter> GetAllCommenters(bool trackChanges)
        {
            return _manager.Commenter.GetAllCommenters(trackChanges);
        }

        public IQueryable<Commenter> GetAllCommentersWithDetails(CommenterRequestParameters p)
        {
            return _manager.Commenter.GetAllCommentersWithDetails(p);
        }

        public Commenter? GetOneCommenter(string id, bool trackChanges)
        {
            return _manager.Commenter.GetOneCommenter(id, trackChanges);
        }

        public void UpdateOneCommenter(commenter_updateDto entity)
        {
            Commenter updatingCommenter = _mapper.Map<Commenter>(entity);
            _manager.Commenter.UpdateOneCommenter(updatingCommenter);
            _manager.Save();
        }
    }
}