
using Entities.Models;

using Repositories.Contracts;


namespace Repositories
{
    public sealed class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(RepositoryContext context) : base(context)
        {

        }


        public void CreatePost(Post Post) => Create(Post);
       


        public void Delete(Post Post) => Remove(Post);
       

       

        public IQueryable<Post> GetAllPosts(bool trackChanges) => FindAll(trackChanges);

  

        public Post GetOnePost(string id, bool trackChanges)
        {
            return FindByCondition(b => b.Id.Equals(id), trackChanges);
        }

       

        public void UpdateOnePost(Post entity)
        {
              Update(entity);
        }
    }
}