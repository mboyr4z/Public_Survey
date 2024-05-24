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
    public class UnlikePageModel : PageModel
    {

        private readonly IServiceManager _manager;

        public UnlikePageModel(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> OnGetAsync(string likerId, int postId, string returnUrl)
        {
            UnlikePost(likerId, postId);
            return Redirect(returnUrl);
        }
        private void UnlikePost(string likerId, int postId)
        {
            Like deletingLike = _manager.LikeService.GetLikesWithPostId(postId, false).Where(p => p.LikerId.Equals(likerId)).FirstOrDefault();
            _manager.LikeService.Delete(deletingLike);
        }

    }
}
