using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Identity;
using MyApp.Pages;
using Survey.Benimkiler;

namespace Survey.Infrastructure.Extensions
{
    public static class FilteringExtensions
    {
        public static List<IdentityUser> FilterByIdentityUserParams(this List<IdentityUser> userList, IdentityUserRequestParameters parameters){
            if(!string.IsNullOrEmpty(parameters.Username)){
                p.f("username not null");
                userList = userList.Where(user => user.UserName.ToLower().Contains(parameters.Username.ToLower())).ToList();
                p.f("count : " + userList.Count());
            }

            if(!string.IsNullOrEmpty(parameters.Email)){
                p.f("email not null");
                userList = userList.Where(user => user.Email.ToLower().Contains(parameters.Email.ToLower())).ToList();
                           p.f("count : " + userList.Count());
            }

            return userList;
        }

        public static RegisteredAdmins FilteringRegisteredAdmins(this RegisteredAdmins registeredAdmins,IdentityUserRequestParameters parameters){

            registeredAdmins.adminList = registeredAdmins.adminList.FilterByIdentityUserParams(parameters);
            return registeredAdmins;
        }

        // public static RegisteredAdmins FilteringRegisteredBosses(this RegisteredBosses registeredBosses,SurveyUserRequestParameters surveyParameters, IdentityUserRequestParameters identityParameters){

        //     registeredAdmins.adminList = registeredAdmins.adminList.FilterByIdentityUserParams(parameters);
        //     return registeredAdmins;
        // }
    }
}