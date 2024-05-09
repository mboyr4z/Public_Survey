using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Survey.Components
{
    public class RoleSummaryViewComponent : ViewComponent
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleSummaryViewComponent(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public string Invoke(){
            return _roleManager.Roles.Count().ToString();
        }
    }
}