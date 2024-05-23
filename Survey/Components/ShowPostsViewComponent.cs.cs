using Benimkiler.Roles;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Survey.Benimkiler;
using Survey.Models;

namespace Survey.Components
{
    public class ShowPostsViewComponent : ViewComponent
    {

        private readonly IServiceManager _manager;
        private readonly UserManager<IdentityUser> _userManager;
        public ShowPostsViewComponent(IServiceManager manager, UserManager<IdentityUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        private List<ShowedPost> showedPosts;
        private ShowedPost newShowedPost; 
        private Company publisherCompany;
        private IdentityUser publisher;
        public async Task<IViewComponentResult> InvokeAsync()
        {
            showedPosts = new List<ShowedPost>();

            var posts = _manager.PostService.GetAllPosts(false);

            foreach (Post post in posts)
            {
                newShowedPost = new ShowedPost();
                newShowedPost.publisherId = post.PublisherId;
                newShowedPost.content = post.Content;
                newShowedPost.publishTime = post.PublishTime;
                
                publisher = await  _userManager.FindByIdAsync(newShowedPost.publisherId);
                Roles role =   p.RoleToEnum((await _userManager.GetRolesAsync(publisher)).FirstOrDefault());

                if(role == Roles.Author){
                    Author author = _manager.AuthorService.GetOneAuthor(newShowedPost.publisherId, false);
                    newShowedPost.publisherFullName = author.Name  + " " + author.Surname;
                    newShowedPost.publisherImagePath = author.ImageUrl;

                    publisherCompany = _manager.CompanyService.GetOneCompany(author.CompanyId, false);
                    

                    
                }else{
                    Boss boss = _manager.BossService.GetOneBoss(newShowedPost.publisherId, false);
                    newShowedPost.publisherFullName = boss.Name + " " + boss.Surname;
                    newShowedPost.publisherImagePath = boss.ImageUrl;

                    publisherCompany = _manager.CompanyService.GetOneCompany(boss.CompanyId, false);
                }

                newShowedPost.publisherInformation = role.ToString() + " at " + publisherCompany.Name;
                showedPosts.Add(
                    newShowedPost
                );
            }
            return View(model: showedPosts);
        }
    }


}