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
    public class CommentManager : ICommentService
    {

        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CommentManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public void CreateComment(Comment Comment)
        {
            _manager.Comment.Create(Comment);
            _manager.Save();
        }

        public void Delete(Comment Comment)
        {
            _manager.Comment.Delete(Comment);
            _manager.Save();
        }

        public IQueryable<Comment> GetAllComments(bool trackChanges)
        {
            return _manager.Comment.GetAllComments(trackChanges);
        }

        public IQueryable<Comment> GetCommentsWithPostId(int postId, bool trackChanges)
        {
            return GetAllComments(trackChanges).Where(p => p.PostId == postId);
        }

        public Comment? GetOneComment(string id, bool trackChanges)
        {
            return _manager.Comment.GetOneComment(id, trackChanges);
        }

        public void UpdateOneComment(Comment entity)
        {
            _manager.Comment.UpdateOneComment(entity);
            _manager.Save();
        }
    }
}