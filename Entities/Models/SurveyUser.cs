namespace Entities.Models
{
    public abstract class SurveyUser
    {
        public string? id {get; set;}
        public string? Name {get; set;}
        public string? Surname {get; set;}
        public int? Age {get; set;}
        public string? City {get; set;}
        public float? LikeRate{get; set;}
    }
}