using System.Linq.Expressions;
using Entities;
using Entities.Models;

namespace Repositories.Extensions
{
    public static class SurveyUserExtension
    {





        public static IQueryable<SurveyUser> FilteredByName(this IQueryable<SurveyUser> source, string name)

        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return source;

            }
            else
            {
                var toLowerName = name.ToLower();

                return source.Where(author => author.Name.Contains(name));
            }
        }

















        public static IQueryable<SurveyUser> FilteredBySurname(this IQueryable<SurveyUser> source, string surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
            {
                return source;
            }
            else
            {
                var toLowerSurname = surname.ToLower();

                return source.Where(author => author.Surname.Contains(surname));
            }
        }




        public static IQueryable<SurveyUser> FilteredByLikeRate(this IQueryable<SurveyUser> source,int minLikeRate, int maxLikeRate, bool isValidLikeRate)
        {
            if (!isValidLikeRate)
            {
                return source;
            }

            return source.Where(entity => entity.LikeRate >= minLikeRate && entity.LikeRate <= maxLikeRate);
        }



    }
}