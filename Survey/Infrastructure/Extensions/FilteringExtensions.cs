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
                userList = userList.Where(user => user.UserName.ToLower().Contains(parameters.Username.ToLower())).ToList();
            }

            if(!string.IsNullOrEmpty(parameters.Email)){
                userList = userList.Where(user => user.Email.ToLower().Contains(parameters.Email.ToLower())).ToList();
            }

            return userList;
        }

        public static RegisteredAdmins FilteringRegisteredAdmins(this RegisteredAdmins registeredAdmins,IdentityUserRequestParameters parameters){

            registeredAdmins.adminList = registeredAdmins.adminList.FilterByIdentityUserParams(parameters);
            return registeredAdmins;
        }

        
        public static RegisteredAuthors FilteringRegisteredAuthorsByIdentityUser(
            this RegisteredAuthors registeredAuthors,SurveyUserRequestParameters surveyUserParameters, IdentityUserRequestParameters identityUserParameters){
            
            if(!string.IsNullOrEmpty(identityUserParameters.Email)){
                registeredAuthors.authorList = registeredAuthors.authorList.Where(authorItem => authorItem.user.Email.ToLower().Contains(identityUserParameters.Email.ToLower())).ToList();
            }

            if(!string.IsNullOrEmpty(identityUserParameters.Username)){
                registeredAuthors.authorList = registeredAuthors.authorList.Where(authorItem => authorItem.user.UserName.ToLower().Contains(identityUserParameters.Username.ToLower())).ToList();
            }

            if(!string.IsNullOrEmpty(surveyUserParameters.Name)){
                registeredAuthors.authorList = registeredAuthors.authorList.Where(authorItem => authorItem.author.Name.ToLower().Contains(surveyUserParameters.Name.ToLower())).ToList();
            }

            if(!string.IsNullOrEmpty(surveyUserParameters.Surname)){
                registeredAuthors.authorList = registeredAuthors.authorList.Where(authorItem => authorItem.author.Surname.ToLower().Contains(surveyUserParameters.Surname.ToLower())).ToList();
            }

            if(!string.IsNullOrEmpty(surveyUserParameters.minLikeRate.ToString())){
                registeredAuthors.authorList = registeredAuthors.authorList.Where(authorItem => authorItem.author.LikeRate > surveyUserParameters.minLikeRate).ToList();
            }

            if(!string.IsNullOrEmpty(surveyUserParameters.maxLikeRate.ToString())){
                registeredAuthors.authorList = registeredAuthors.authorList.Where(authorItem => authorItem.author.LikeRate < surveyUserParameters.maxLikeRate).ToList();
            }


            
           // registeredAuthors.authorList = registeredAuthors.authorList..FilterByIdentityUserParams(parameters);
            return registeredAuthors;
        }

        // public static RegisteredAdmins FilteringRegisteredBosses(this RegisteredBosses registeredBosses,SurveyUserRequestParameters surveyParameters, IdentityUserRequestParameters identityParameters){

        //     registeredAdmins.adminList = registeredAdmins.adminList.FilterByIdentityUserParams(parameters);
        //     return registeredAdmins;
        // }
    }
}