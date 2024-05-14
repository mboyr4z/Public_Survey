using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Survey.Controllers
{
    public class MainPageController : Controller
    {
      

        public IActionResult Index()
        {
            return View();
        }

        
    }
}