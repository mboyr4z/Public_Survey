
using Entities.Models;

using Repositories.Contracts;


namespace Repositories
{
    public sealed class ChatRepository : RepositoryBase<Chat>, IChatRepository
    {
        public ChatRepository(RepositoryContext context) : base(context)
        {

        }


        public void CreateChat(Chat Chat) => Create(Chat);
       


        public void Delete(Chat Chat) => Remove(Chat);
       

       

        public IQueryable<Chat> GetAllChats(bool trackChanges) => FindAll(trackChanges);

  

        public Chat GetOneChat(string id, bool trackChanges)
        {
            return FindByCondition(b => b.Id.Equals(id), trackChanges);
        }

       

        public void UpdateOneChat(Chat entity)
        {
              Update(entity);
        }
    }
}