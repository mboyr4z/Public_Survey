using System.Dynamic;

namespace Entities.RequestParameters
{
    public class SurveyUserRequestParameters
    {
        public string? Name{get;set;}
        public string? Surname{get;set;}
        public int? minLikeRate{get;set;}
        public int? maxLikeRate{get;set;}
      
    }
}