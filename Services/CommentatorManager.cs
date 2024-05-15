using AutoMapper;
using Entities;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CommentatorManager : ICommentatorService
    {

        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CommentatorManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public void CreateCommentator(commentator_createDto commentator)
        {
            Commentator newCommentator = _mapper.Map<Commentator>(commentator);
            _manager.Commentator.Create(newCommentator);
            _manager.Save();
        }

        public void Delete(Commentator commentator)
        {
            _manager.Commentator.Delete(commentator);
            _manager.Save();
        }

        public IQueryable<Commentator> GetAllCommentators(bool trackChanges)
        {
            return _manager.Commentator.GetAllCommentators(trackChanges);
        }

       

        public IQueryable<Commentator> GetAllCommentatorsWithDetails(CommentatorRequestParameters p)
        {
             return _manager.Commentator.GetAllCommentatorsWithDetails(p);
        }

        public Commentator? GetOneCommentator(string id, bool trackChanges)
        {
            return _manager.Commentator.GetOneCommentator(id, trackChanges);
        }

        public void UpdateOneCommentator(commentator_updateDto entity)
        {
            Commentator updatingCommentator = _mapper.Map<Commentator>(entity);
            _manager.Commentator.UpdateOneCommentator(updatingCommentator);
            _manager.Save();
        }
    }
}