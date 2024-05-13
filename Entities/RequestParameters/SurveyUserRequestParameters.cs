using System.Dynamic;

namespace Entities.RequestParameters
{
    public class SurveyUserRequestParameters : RequestParameters
    {
        public string Name{get;set;}
        public string Surname{get;set;}
        public int minLikeRate{get;set;}
        public int maxLikeRate{get;set;}
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public bool IsValidLikeRate {get; set;}

        public SurveyUserRequestParameters(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public SurveyUserRequestParameters() : this(1,6)   // boş nesne çalıştırmaya çalışan olursa diğer rcoonsta böyle yönlendir, alternatif olarak ta parametreye = ile default değer ver
        {
            
        }
    }
}