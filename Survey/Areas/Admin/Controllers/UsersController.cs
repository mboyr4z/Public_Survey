using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Benimkiler;
using Services.Contracts;

namespace Survey.Areas.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        public IActionResult Index()
        {
          
            var model = _userManager.Users;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                P.f("Rol silme başarılı");
            }
            else
            {
                P.f("Silme esnasında bir hata ile karşılaşıldı");
            }
            return RedirectToAction("Index");
        }
    }
}