using AutoMapper;
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
        private readonly IMapper _mapper;

        public RolesController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            var roles = _manager.AuthService.Roles;
            return View(roles);
        }

        public IActionResult CreateRole()
        {
            P.f("GET İSTEGİ ");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> CreateRole(RoleDtoForCreation roleDto)
        {
            
            IdentityRole role = _manager.AuthService.GetOneRoleWithName(roleDto.Name);

            if(role is null){
                IdentityResult result = await _manager.AuthService.CreateRole(roleDto);

                if(result.Succeeded){
                    P.f("Başarılı şeklde " + roleDto.Name + " eklendi");
                }else{
                    P.f("Bir hata ile karşılaşıldı");
                }
            }else{
                P.f("Zaten rol daha önce yaratılmş");
            }
            
            // P.f("roleDtroName : " + roleDto.Name);
            

            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult Delete(string id)
        {
            IdentityRole role = _manager.AuthService.GetOneRoleWithId(id);
            return RedirectToAction("Index");
        }
    }
}