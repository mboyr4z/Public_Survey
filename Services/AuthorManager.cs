using AutoMapper;
using Entities;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class AuthorManager : IAuthorService
    {

        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AuthorManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public void CreateAuthor(author_createDto authorDto)
        {
            Author newAuthor = _mapper.Map<Author>(authorDto);
            _manager.Author.Create(newAuthor);
            _manager.Save();
        }

        public void Delete(Author author)
        {
            _manager.Author.Delete(author);
            _manager.Save();
        }

        public IQueryable<Author> GetAllAuthors(bool trackChanges)
        {
            return _manager.Author.GetAllAuthors(trackChanges);
        }

        public IQueryable<Author> GetAllAuthorsWithDetails(AuthorRequestParameters p)
        {
            return _manager.Author.GetAllAuthorsWithDetails(p);
        }

        public Author? GetOneAuthor(string id, bool trackChanges)
        {
            return _manager.Author.GetOneAuthor(id, trackChanges);
        }

        public void UpdateOneAuthor(author_updateDto entity)
        {
            Author updatingAuthor = _mapper.Map<Author>(entity);
            _manager.Author.UpdateOneAuthor(updatingAuthor);
            _manager.Save();
        }
    }
}