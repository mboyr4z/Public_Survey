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
    public class LikePageModel : PageModel
    {

        private readonly IServiceManager _manager;

        public LikePageModel(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> OnGetAsync(string likerId, int postId, string returnUrl)
        {
            LikePost(likerId, postId);
            return Redirect(returnUrl);
        }
        private void LikePost(string likerId, int postId)
        {
            Like newLike = new Like();
            newLike.LikerId = likerId;
            newLike.PostId = postId;
            _manager.LikeService.CreateLike(newLike);
        }

    }
}
