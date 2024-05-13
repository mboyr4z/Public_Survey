using System.Linq.Expressions;
using Entities;
using Entities.Models;

namespace Repositories.Extensions
{
    public static class SurveyUserExtension
    {

        public static IQueryable<T> FilteredByName<T>(this IQueryable<T> source, Expression<Func<T, string>> nameProperty, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return source;
            }
            else
            {
                var toLowerName = name.ToLower();
                return source
                    .Where(entity => nameProperty.Compile()(entity).ToLower().Contains(toLowerName));
            }
        }

        public static IQueryable<T> FilteredBySurname<T>(this IQueryable<T> source, Expression<Func<T, string>> surNameProperty, string? surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
            {
                return source;
            }
            else
            {
                var toLowerSurname = surname.ToLower();
                return source
                    .Where(entity => surNameProperty.Compile()(entity).ToLower().Contains(toLowerSurname));
            }
        }

      


        public static IQueryable<T> FilteredByLikeRate<T>(
            this IQueryable<T> source,
            Expression<Func<T, int>> likeRateProperty,
            int minLikeRate,
            int maxLikeRate,
            bool isValidLikeRate)
        {
            if (!isValidLikeRate)
            {
                return source;
            }

            return source.Where(entity =>
                likeRateProperty.Compile()(entity) >= minLikeRate &&
                likeRateProperty.Compile()(entity) <= maxLikeRate);
        }



    }
}