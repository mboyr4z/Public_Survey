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
            return View();
        }

    }
}