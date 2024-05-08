using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;

namespace Survey.Areas.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {

        private readonly IServiceManager _manager;

        public RolesController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {

            var roles = _manager.AuthService.Roles;
            return View(roles);
        }

        public IActionResult CreateRole()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            IdentityRole role = _manager.AuthService.GetOneRoleWithId(id);
            P.f("name : " + role.Name );
            return RedirectToAction("Index");
        }
    }
}