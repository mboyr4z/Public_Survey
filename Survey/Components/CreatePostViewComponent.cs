using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Survey.Components
{
    public class CreatePostViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(){
            return View(model : new PostDto());
        }
    }
}