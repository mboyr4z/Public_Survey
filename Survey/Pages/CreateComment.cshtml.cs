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
    public class CreateCommentPageModel : PageModel
    {

        private readonly IServiceManager _manager;

        public CreateCommentPageModel(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> OnGetAsync(string content, string commenterId, int postId, string returnUrl)
        {
            CreateComment(content,commenterId, postId);
            return Redirect(returnUrl);
        }
        private void CreateComment(string content, string commenterId, int postId)
        {
            Comment newComment = new Comment();
            newComment.Content =content;
            newComment.CommenterId = commenterId;
            newComment.PublishTime = DateTime.Now;
            newComment.PostId = postId;
            _manager.CommentService.CreateComment(newComment);
        }

    }
}
