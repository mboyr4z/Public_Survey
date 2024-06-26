using Entities;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{
    public sealed class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateAuthor(Author author) => Create(author);

       
        public void Delete(Author author) => Remove(author);

        public IQueryable<Author> GetAllAuthors(bool trackChanges) => FindAll(trackChanges);

        public Author? GetOneAuthor(string id, bool trackChanges)
        {
            return FindByCondition(a => a.Id.Equals(id), trackChanges);
        }

      
        public void UpdateOneAuthor(Author entity)
        {
            Update(entity);
        }

        
    }
}