using Entities;
using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface ICommentService {
        
        IQueryable<Comment> GetAllComments(bool trackChanges);
        Comment? GetOneComment(string id, bool trackChanges);
        void CreateComment(Comment comment);
        void Delete(Comment comment);
        void UpdateOneComment(Comment entity);

        IQueryable<Comment> GetCommentsWithPostId(int postId, bool trackChanges);
    }
}