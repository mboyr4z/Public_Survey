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
    public class PostManager : IPostService
    {

        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public PostManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public void CreatePost(Post Post)
        {
            _manager.Post.Create(Post);
            _manager.Save();
        }

        public void Delete(Post Post)
        {
            _manager.Post.Delete(Post);
            _manager.Save();
        }

        public IQueryable<Post> GetAllPosts(bool trackChanges)
        {
            return _manager.Post.GetAllPosts(trackChanges);
        }

        public Post? GetOnePost(string id, bool trackChanges)
        {
            return _manager.Post.GetOnePost(id, trackChanges);
        }

        public void UpdateOnePost(Post entity)
        {
            _manager.Post.UpdateOnePost(entity);
            _manager.Save();
        }
    }
}