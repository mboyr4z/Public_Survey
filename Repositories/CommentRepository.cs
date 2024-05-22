
using Entities.Models;

using Repositories.Contracts;


namespace Repositories
{
    public sealed class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryContext context) : base(context)
        {

        }


        public void CreateComment(Comment Comment) => Create(Comment);
       


        public void Delete(Comment Comment) => Remove(Comment);
       

       

        public IQueryable<Comment> GetAllComments(bool trackChanges) => FindAll(trackChanges);

  

        public Comment GetOneComment(string id, bool trackChanges)
        {
            return FindByCondition(b => b.Id.Equals(id), trackChanges);
        }

       

        public void UpdateOneComment(Comment entity)
        {
              Update(entity);
        }
    }
}