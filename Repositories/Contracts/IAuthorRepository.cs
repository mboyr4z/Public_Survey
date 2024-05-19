using Entities;
using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IAuthorRepository : IRepositoryBase<Author>{
        
        IQueryable<Author> GetAllAuthors(bool trackChanges);
        Author? GetOneAuthor(string id, bool trackChanges);
        void CreateAuthor(Author author);
        void Delete(Author author);
        void UpdateOneAuthor(Author entity);
    }
}