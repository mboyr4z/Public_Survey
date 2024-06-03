using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Survey.Models;

namespace Survey.Components
{
    public class SearchUserViewComponent : ViewComponent
    {

        private readonly IServiceManager _manager;
        

        public SearchUserViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync(){
            return View();
        }
    }
}