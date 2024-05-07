using Microsoft.AspNetCore.Mvc;

namespace Survey.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index(){
            return View();
        }
    }
}