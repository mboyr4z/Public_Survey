using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Survey.Pages
{
    public class BossPageModel : PageModel
    {
        public string bossId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName => Name + " " + Surname;
        public string ImageUrl { get; set; }
        public int FollowerCount { get; set; }
        public int LikeCount { get; set; }
        public int PublishCount { get; set; }
        public string CompanyImageUrl { get; set; }
        public string CompanyName { get; set; }
        public string Information => "Boss at " + CompanyName;
        public void OnGet(string publisherId)
        {
        }

        public async Task OnPostAsync()
        {

        }
    }


}
