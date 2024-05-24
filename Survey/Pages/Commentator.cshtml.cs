using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Survey.Pages
{
    public class CommentatorPageModel : PageModel
    {
        public string CommentatorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName => Name + " " + Surname;
        public string ImageUrl { get; set; }
        public int FollowerCount { get; set; }
        public int LikeCount { get; set; }
        public void OnGet(string commentatorId)
        {
        }

        public async Task OnPostAsync()
        {

        }
    }


}
