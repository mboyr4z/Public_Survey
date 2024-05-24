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
    public class FollowPageModel : PageModel
    {

        private readonly IServiceManager _manager;

        public FollowPageModel(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> OnGetAsync(string followedId, string followerId, string returnUrl)
        {
            FollowUser(followedId, followerId);
            return Redirect(returnUrl);
        }
        private void FollowUser(string followedId, string followerId)
        {
            Follow newFollow = new Follow();
            newFollow.FollowedId = followedId;
            newFollow.FollowById = followerId;
            newFollow.FollowTime = DateTime.Now;

            _manager.FollowService.CreateFollow(newFollow);
        }

    }
}
