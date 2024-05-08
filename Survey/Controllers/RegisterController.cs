using System.Security.Cryptography;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Survey.Controllers
{
    public class RegisterController : Controller
    {

        private readonly IServiceManager _manager;

        public RegisterController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {

            var users = _manager.AuthService.GetAllUsers();


            ViewBag.Users = users;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] RegisterDto userDto)
        {
            P.f("name : " + userDto.UserName + " mail : " + userDto.Email + " pass : " + userDto.Password);
            return View();
        }
    }
}