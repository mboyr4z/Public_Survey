using System.Linq.Expressions;
using Entities;
using Entities.Models;

namespace Repositories.Extensions
{
    public static class CompanyExtension
    {



        public static IQueryable<Company> FilteredByName(this IQueryable<Company> source, string name)

        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return source;

            }
            else
            {
                var toLowerName = name.ToLower();

                return source.Where(c => c.Name.Contains(name));
            }
        }




    }
}