

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Benimkiler;
using Services.Contracts;

namespace StoreApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "user-role")]
    public class UserRoleTagHelper : TagHelper
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        private readonly IServiceManager _manager;

        [HtmlAttributeName("user-name")]
        public String? UserName { get; set; }

        public UserRoleTagHelper(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IServiceManager manager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _manager = manager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.FindByNameAsync(UserName);


            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Count > 0)
            {
                TagBuilder ul = new TagBuilder("ul");
                foreach (string role in roles)
                {
                     TagBuilder li = new TagBuilder("li");
                     li.InnerHtml.Append(role);
                          li.Attributes["style"] = "color: blue;";
                     ul.InnerHtml.AppendHtml(li);
                }

                output.Content.AppendHtml(ul);
            }else{
                TagBuilder ul = new TagBuilder("ul");
                
                     TagBuilder li = new TagBuilder("li");
                     li.InnerHtml.Append("-");
                
                     ul.InnerHtml.AppendHtml(li);
                
                output.Content.AppendHtml(ul);
            }


        }
    }

}