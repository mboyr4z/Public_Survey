using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;

namespace Survey.Areas.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {

        private readonly IServiceManager _manager;

        public UsersController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}