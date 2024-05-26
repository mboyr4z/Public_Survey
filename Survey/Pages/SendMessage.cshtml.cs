using System.Diagnostics;
using System.Net.Http.Headers;
using Benimkiler.Roles;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using Survey.Benimkiler;

namespace Survey.Pages
{
    public class SendMessagePageModel : PageModel
    {

        private readonly IServiceManager _manager;

        public SendMessagePageModel(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> OnGetAsync(string senderId, string receiverId, string content, string returnUrl)
        {
            SendMessage(senderId, receiverId, content);
            p.f("return URL : " + returnUrl);
            return Redirect(returnUrl);
        }
        private void SendMessage(string senderId, string receiverId, string content)
        {
            Chat chat = new Chat();
            chat.Content=content;
            chat.SenderId = senderId;
            chat.ReceiverId = receiverId;
            chat.PublishTime = DateTime.Now;

            _manager.ChatService.CreateChat(chat);
        }

    }
}
