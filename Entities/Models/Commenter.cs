namespace Entities.Models
{
    public class Commenter : SurveyUser
    {
        public bool Confirmed { get; set; } = true;
    }
}