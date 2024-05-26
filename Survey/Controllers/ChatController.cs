using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;
using Survey.Benimkiler;
using Survey.Components;
using Survey.Models;

namespace Survey.Controllers;

public class ChatController : Controller
{

    private readonly MainPageModel _mainPageModel;
    private readonly IServiceManager _manager;

    private ChatPageModel model;

    public ChatController(IServiceManager manager, IMapper mapper, MainPageModel mainPageModel)
    {
        _manager = manager;
        _mainPageModel = mainPageModel;
    }

    public IActionResult Index(string contactId)
    {

        string myId = _mainPageModel.User is not null ? _mainPageModel.User.Id : "";
        model = new ChatPageModel();
        List<string> myContactsIds;


        myContactsIds = _manager.ChatService.GetAllCotnactsUsernameById(myId).ToList();
        SetContactAreaModel(model.contactAreaModel, myContactsIds);



        if (!string.IsNullOrEmpty(contactId))
        {
            model.isChatedContact = true;
            model.chatedContactId = contactId;

            SetMessageAreaModelAsync(model.messageAreaModel, myId, contactId);
        }

        return View(model);
    }

    private async void SetContactAreaModel(ContactAreaModel contactAreaModel, List<string> contactIds)
    {
        contactAreaModel.contactList = new List<ContactModel>();

        foreach (string contactId in contactIds)
        {
            contactAreaModel.contactList.Add(
                new ContactModel
                {
                    userId = contactId,
                    name = await _manager.GetFullNameById(contactId),
                    imageUrl = await _manager.GetImageUrlById(contactId)
                }
            );
        }
    }

    private async Task SetMessageAreaModelAsync(MessageAreaModel messageAreaModel, string myId, string contactId)
    {
        messageAreaModel.myId = myId;
        messageAreaModel.contactId = contactId;
        messageAreaModel.myImageUrl = await _manager.GetImageUrlById(myId);
        messageAreaModel.contactImageUrl = await _manager.GetImageUrlById(contactId);
        messageAreaModel.contactName = await _manager.GetFullNameById(contactId);

        messageAreaModel.messages = new List<MessageModel>();

        IQueryable<Chat> allChats = _manager.ChatService.GetAllChats(false).Where(c => 
        (c.SenderId.Equals(myId) && c.ReceiverId.Equals(contactId)) 
        || 
        (c.SenderId.Equals(contactId) &&  c.ReceiverId.Equals(myId))
        );

        foreach (Chat chat in allChats)
        {
            messageAreaModel.messages.Add(
                new MessageModel
                {
                    content = chat.Content,
                    time = chat.PublishTime,
                    isMyMessage = chat.SenderId.Equals(myId)
                }
            );
        }
    }
}

public class MessageAreaModel
{
    public string myId { get; set; }
    public string contactId { get; set; }
    public string myImageUrl { get; set; }
    public string contactImageUrl { get; set; }
    public string contactName { get; set; }

    public List<MessageModel> messages { get; set; }
}


public class MessageModel
{
    public string content { get; set; }
    public DateTime time { get; set; }
    public bool isMyMessage;
}


public class ChatPageModel
{
    public ContactAreaModel contactAreaModel;
    public MessageAreaModel messageAreaModel;

    public bool isChatedContact;

    public string chatedContactId;

    public ChatPageModel()
    {
        contactAreaModel = new ContactAreaModel();
        messageAreaModel = new MessageAreaModel();
    }
}

public class ContactAreaModel
{
    public List<ContactModel> contactList;
}

public class ContactModel
{
    public string userId { get; set; }
    public string name { get; set; }
    public string imageUrl { get; set; }
}



