using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;

namespace Survey.Areas.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {

        private readonly IServiceManager _manager;

        public DashboardController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
             int userCount = _manager.AuthService.GetAllUsers().Count();
              int roleCount = _manager.AuthService.Roles.Count();

              ViewBag.userCount = userCount;
              ViewBag.roleCount = roleCount;

            return View();
        }
    }
}