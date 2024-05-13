using Entities;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface ICommenterService
    {
        IQueryable<Commenter> GetAllCommenters(bool trackChanges);
        IQueryable<Commenter> GetAllCommentersWithDetails(CommenterRequestParameters p);
        Commenter? GetOneCommenter(string id, bool trackChanges);
        void CreateCommenter(commenter_createDto commenter);
        void Delete(Commenter commenter);
        void UpdateOneCommenter(commenter_updateDto entity);
    }
}