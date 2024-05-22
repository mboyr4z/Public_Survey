using AutoMapper;
using Entities;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;
using SQLitePCL;

namespace Services
{
    public class ChatManager : IChatService
    {

        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ChatManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public void CreateChat(Chat chat)
        {
            _manager.Chat.Create(chat);
            _manager.Save();
        }

        public void Delete(Chat chat)
        {
            _manager.Chat.Delete(chat);
            _manager.Save();
        }

        public IQueryable<Chat> GetAllChats(bool trackChanges)
        {
            return _manager.Chat.GetAllChats(trackChanges);
        }

        public Chat? GetOneChat(string id, bool trackChanges)
        {
            return _manager.Chat.GetOneChat(id, trackChanges);
        }

        public void UpdateOneChat(Chat entity)
        {
            _manager.Chat.UpdateOneChat(entity);
            _manager.Save();
        }
    }
}