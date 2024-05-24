namespace Entities.Models
{
    public class Author : SurveyUser
    {
        public bool? Confirmed { get; set; } = false;
        public int CompanyId{get;set;}


    }
}