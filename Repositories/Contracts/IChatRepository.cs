using Entities;
using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IChatRepository : IRepositoryBase<Chat>{
        
        IQueryable<Chat> GetAllChats(bool trackChanges);
        Chat? GetOneChat(string id, bool trackChanges);
        void CreateChat(Chat chat);
        void Delete(Chat chat);
        void UpdateOneChat(Chat entity);
    }
}