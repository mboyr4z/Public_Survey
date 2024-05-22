using Benimkiler.Roles;
using Microsoft.AspNetCore.Identity;

namespace Survey.Models
{
    public class MainPageModel
    {
        public bool IsUserLogged{get;set;}

        public bool IsUserConfirmed{get;set;}

        public bool IsUserCompletedMembership {get;set;}

        public Roles Role{get;set;}

        public string Username{get;set;} 

        public IdentityUser User{get;set;}

    
    }
}