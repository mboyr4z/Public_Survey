using Entities;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface IAuthorService
    {
        IQueryable<Author> GetAllAuthors(bool trackChanges);
        Author? GetOneAuthor(string id, bool trackChanges);
        void CreateAuthor(author_createDto authorDto);

        void CreateAuthor(Author author);
        void Delete(Author author);
        void UpdateOneAuthor(author_updateDto entity);

        void UpdateOneAuthor(Author author);
    }
}