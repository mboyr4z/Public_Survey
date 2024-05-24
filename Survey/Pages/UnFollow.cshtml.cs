







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
    public class UnFollowPageModel : PageModel
    {

        private readonly IServiceManager _manager;

        public UnFollowPageModel(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> OnGetAsync(string followedId, string followerId, string returnUrl)
        {
            UnfollowUser(followedId, followerId);
            return Redirect(returnUrl);
        }
        private void UnfollowUser(string followedId, string followerId)
        {
            Follow deletingFollow = _manager.FollowService.GetAllFollows(false).Where(f => f.FollowedId.Equals(followedId) && f.FollowById.Equals(followerId)).FirstOrDefault();
            _manager.FollowService.Delete(deletingFollow);
        }

    }


}




