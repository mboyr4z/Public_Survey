using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
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
        
        private readonly IRepositoryManager _repoManager;

        public CheckingSurveyUserController(UserManager<IdentityUser> userManager, IServiceManager manager, IMapper mapper, IRepositoryManager repoManager)
        {
            _userManager = userManager;
            _manager = manager;
            _mapper = mapper;
            _repoManager = repoManager;
        }

        private IdentityUser user;
        public async Task<IActionResult> CustomizeAccordingToRole()
        {
            p.f("buradayyım");
            user = await _userManager.GetUserAsync(User);

            string firstRole = (await _userManager.GetRolesAsync(user))[0];

            Roles signingRole = (Roles)Enum.Parse(typeof(Roles), firstRole);
            p.f("first:role : " + firstRole);
            switch (signingRole)
            {
                case Roles.Admin:
                    p.f("admins");
                    return await AdminPage();
                    break;

                case Roles.Author:
                    p.f("author");
                    return await AuthorPage();
                    break;
                case Roles.Boss:
                    p.f("boss");
                    return await BossPage();
                    break;
                case Roles.Commentator:
                    p.f("commentator");
                    return await CommentatorPage();
                    break;
                default:
                    p.f("guestt");
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
                    p.f("author tablosunda var");
                    ViewBag.completedMembership = true;
                }
                else
                {
                    p.f("author tablosunda yok");
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
                    p.f("boss tablosunda var");
                    ViewBag.completedMembership = true;
                }
                else
                {
                    p.f("boss tablosunda yok");
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
                    p.f("Commentator tablosunda var");
                    ViewBag.completedMembership = true;
                }
                else
                {
                    p.f("Commentator tablosunda yok");
                    ViewBag.completedMembership = false;
                }
            }


            return View("CommentatorPage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompleteBossMembership([FromForm] boss_createDto bossDto)
        {
            user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {


                Boss newBoss = _mapper.Map<Boss>(bossDto);
                Company newCompany = _mapper.Map<Company>(bossDto.companyCreateDto);
                newBoss.Company = newCompany;
                newBoss.Id = user.Id;
                _manager.BossService.CreateBoss(newBoss);

                p.f(newBoss.Company.Name);
            }else{
                p.f("kullanıcı yok ");
            }


            return RedirectToAction("Index", "Login");
        }
    }
}