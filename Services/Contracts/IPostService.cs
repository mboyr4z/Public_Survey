using Entities;
using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IPostService{
        
        IQueryable<Post> GetAllPosts(bool trackChanges);
        Post? GetOnePost(string id, bool trackChanges);
        void CreatePost(Post post);
        void Delete(Post post);
        void UpdateOnePost(Post entity);
    }
}