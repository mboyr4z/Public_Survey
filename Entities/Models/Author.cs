namespace Entities.Models
{
    public class Author : SurveyUser
    {
        public bool Confirmed { get; set; } = false;
        public Company Company { get; set; }

    }
}