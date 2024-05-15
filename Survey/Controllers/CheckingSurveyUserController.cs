using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using StoreApp.Infrastructure.Roles;
using Survey.Benimkiler;

namespace Survey.Controllers
{
    public class CheckingSurveyUserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;


        public CheckingSurveyUserController(UserManager<IdentityUser> userManager, IServiceManager manager, IMapper mapper)
        {
            _userManager = userManager;
            _manager = manager;
            _mapper = mapper;
        }


        public async Task<IActionResult> CustomizeAccordingToRole()
        {
            P.f("buradayyım");
            var user = await _userManager.GetUserAsync(User);

            string firstRole = (await _userManager.GetRolesAsync(user))[0];

            Roles signingRole = (Roles)Enum.Parse(typeof(Roles), firstRole);
            P.f("first:role : " + firstRole);
            switch (signingRole)
            {
                case Roles.Admin:
                    P.f("admins");
                    return await AdminPage();
                    break;

                case Roles.Author:
                    P.f("author");
                    return await AuthorPage();
                    break;
                case Roles.Boss:
                    P.f("boss");
                    return await BossPage();
                    break;
                case Roles.Commentator:
                    P.f("commentator");
                    return await CommentatorPage();
                    break;
                default:
                    P.f("guestt");
                    return await GuestPage();
                    break;
            }

        }

        public async Task<IActionResult> GuestPage() => View("Index");

        public async Task<IActionResult> AdminPage() => View("AdminPage");

        public async Task<IActionResult> AuthorPage()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                var userId = user.Id;

                Author? author = _manager.AuthorService.GetOneAuthor(userId, false);


                if (author is not null)
                {
                    P.f("author tablosunda var");
                    ViewBag.completedMembership = true;
                }
                else
                {
                    P.f("author tablosunda yok");
                    ViewBag.completedMembership = false;
                }
            }


            return View("AuthorPage");
        }

        public async Task<IActionResult> BossPage()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                var userId = user.Id;

                Boss? boss = _manager.BossService.GetOneBoss(userId, false);


                if (boss is not null)
                {
                    P.f("boss tablosunda var");
                    ViewBag.completedMembership = true;
                }
                else
                {
                    P.f("boss tablosunda yok");
                    ViewBag.completedMembership = false;
                }
            }


            return View("BossPage");
        }

        public async Task<IActionResult> CommentatorPage()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                var userId = user.Id;

                Commentator? Commentator = _manager.CommentatorService.GetOneCommentator(userId, false);


                if (Commentator is not null)
                {
                    P.f("Commentator tablosunda var");
                    ViewBag.completedMembership = true;
                }
                else
                {
                    P.f("Commentator tablosunda yok");
                    ViewBag.completedMembership = false;
                }
            }


            return View("CommentatorPage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompleteBossMembership([FromForm] boss_createDto bossDto){


            _manager.BossService.CreateBoss(bossDto);
           _manager.CompanyService.CreateCompany(bossDto.companyCreateDto);

            return RedirectToAction("Index","MainPage");
        }
    }
}