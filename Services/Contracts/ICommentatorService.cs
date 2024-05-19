using Entities;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface ICommentatorService
    {
        IQueryable<Commentator> GetAllCommentators(bool trackChanges);
        Commentator? GetOneCommentator(string id, bool trackChanges);
        void CreateCommentator(commentator_createDto commentator);
        void Delete(Commentator commentator);
        void UpdateOneCommentator(commentator_updateDto entity);
    }
}