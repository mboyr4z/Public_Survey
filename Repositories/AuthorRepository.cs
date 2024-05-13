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

        public IQueryable<Author> GetAllAuthorsWithDetails(AuthorRequestParameters pr)
        {
            IQueryable<Author> authors = GetAllAuthors(false)
            .FilteredByName(author => author.Name, pr.Name)
            .FilteredBySurname(author => author.Surname, pr.Surname)
            .FilteredByLikeRate(author => (int)author.LikeRate, pr.minLikeRate, pr.maxLikeRate, pr.IsValidLikeRate);

            return authors;
        }

        public Author? GetOneAuthor(string id, bool trackChanges)
        {
            return FindByCondition(a => a.id.Equals(id), trackChanges);
        }

      
        public void UpdateOneAuthor(Author entity)
        {
            Update(entity);
        }

        
    }
}