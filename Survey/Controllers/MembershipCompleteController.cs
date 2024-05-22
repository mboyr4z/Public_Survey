using AutoMapper;
using Benimkiler.Roles;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repositories.Contracts;
using Services.Contracts;
using Survey.Benimkiler;
using Survey.Models;

namespace Survey.Controllers
{
    public class MembershipCompleteController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRepositoryManager _repoManager;
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;


        public MembershipCompleteController(UserManager<IdentityUser> userManager, IServiceManager manager, IMapper mapper, IRepositoryManager repoManager, MainPageModel mainPageModel)
        {
            _userManager = userManager;
            _manager = manager;
            _mapper = mapper;
            _repoManager = repoManager;
        }

        public async Task<IActionResult> CustomizeAccordingToRole(Roles role, string userId)
        {
            switch (role)
            {
                case Roles.Author:
                    return await AuthorPage();
                    break;
                case Roles.Boss:
                    return await BossPage();
                    break;
                case Roles.Commentator:
                    return await CommentatorPage();
                default:
                    return await MainPage();
            }
        }

        private async Task<IActionResult> MainPage()
        {
            return RedirectToAction("Index", "MainPage");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompleteAuthorMembership([FromForm] author_createDto authorDto, IFormFile imageFileAuthor)
        {
            IdentityUser user = await GetLoginedUserAsync();
            if (user is not null)
            {
                String authorImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "author", user.UserName + ".jpeg");

                string authorImageInRootPath = Path.Combine("images", "author", user.UserName + ".jpeg");

                authorDto.ImageUrl = authorImageInRootPath;


                using (var stream = new FileStream(authorImagePath, FileMode.Create))
                {
                    await imageFileAuthor.CopyToAsync(stream);
                }

                Author newAuthor = _mapper.Map<Author>(authorDto);

                newAuthor.Id = user.Id;

                _manager.AuthorService.CreateAuthor(newAuthor);
                p.f("author başarıyla eklendi");
            }
            else
            {
                p.f("author eklenirken hata. ");
            }
            return await MainPage();
        }

        private async Task<IdentityUser> GetLoginedUserAsync(){
            return await _userManager.GetUserAsync(User);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompleteBossMembership([FromForm] boss_createDto bossDto, IFormFile imageFileBoss, IFormFile imageFileCompany)
        {
            IdentityUser user = await GetLoginedUserAsync();
            if (user is not null)
            {
                String bossImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "boss", user.UserName + ".jpeg");
                String companyImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "company", user.UserName + ".jpeg");

                string bossImageInRootPath = Path.Combine("images", "boss", user.UserName + ".jpeg");
                string companyImageInRootPath = Path.Combine("images", "company", user.UserName + ".jpeg");

                bossDto.ImageUrl = bossImageInRootPath;
                bossDto.companyCreateDto.ImageUrl = companyImageInRootPath;

                Boss newBoss = _mapper.Map<Boss>(bossDto);

                // p.f("bosspath : " + bossImagePath);
                // p.f("company path : " + companyImagePath);

                using (var stream = new FileStream(bossImagePath, FileMode.Create))
                {
                    await imageFileBoss.CopyToAsync(stream);
                }

                using (var stream = new FileStream(companyImagePath, FileMode.Create))
                {
                    await imageFileCompany.CopyToAsync(stream);
                }

                _manager.CompanyService.CreateCompany(bossDto.companyCreateDto);

                Company company = _manager.CompanyService.GetOneCompanyWithName(bossDto.companyCreateDto.Name, false);

                newBoss.Id = user.Id;
                newBoss.CompanyId = company.Id;
                _manager.BossService.CreateBoss(newBoss);
                p.f("boss ve company başarıyla ekelendi");
            }
            else
            {
                p.f("boss eklenirken hata");
            }
            return await MainPage();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompleteCommentatorMembership([FromForm] commentator_createDto commentatorDto, IFormFile imageFileCommentator)
        {
            IdentityUser user = await GetLoginedUserAsync();
            if (user is not null)
            {

                String commentatorImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "commentator", user.UserName + ".jpeg");

                string commentatorImageInRootPath = Path.Combine("images", "commentator", user.UserName + ".jpeg");
                commentatorDto.ImageUrl = commentatorImageInRootPath;

                using (var stream = new FileStream(commentatorImagePath, FileMode.Create))
                {
                    await imageFileCommentator.CopyToAsync(stream);
                }

                commentatorDto.Id = user.Id;
                _manager.CommentatorService.CreateCommentator(commentatorDto);
                p.f("commentator başarıyla eklendi");
            }
            else
            {
                p.f("commentator eklenirken hata");
            }

            return await MainPage();
        }

        public async Task<IActionResult> AuthorPage()
        {
            ViewBag.Companies = GetCompaniesSelectList();

            return View("AuthorPage");
        }

        public async Task<IActionResult> BossPage() => View("BossPage");

        public async Task<IActionResult> CommentatorPage() => View("CommentatorPage");

        public SelectList GetCompaniesSelectList()
        {
            IQueryable<Company> companies = _manager.CompanyService.GetAllCompanies(false);
            SelectList companySelectList = new SelectList(companies, "Id", "Name", "1");
            return companySelectList;
        }


    }
}