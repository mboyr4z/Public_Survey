namespace Entities.Models
{
    public abstract class SurveyUser
    {
        public string Id {get; set;}
        public string Name {get; set;}
        public string? Surname {get; set;}
        public int? Age {get; set;}
        public string? City {get; set;}
        public float? LikeRate{get; set;}
        public string ImageUrl{get; set;}

        public string FullName => Name + " " + Surname;

    }
}