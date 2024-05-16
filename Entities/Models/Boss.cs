namespace Entities.Models
{
    public class Boss : SurveyUser
    {
        public bool? Confirmed { get; set; } = false;
        public Company Company{get;set;}



    }
}