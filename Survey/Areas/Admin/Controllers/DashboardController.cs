using Microsoft.AspNetCore.Mvc;

namespace Survey.Areas.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}