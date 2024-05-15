namespace Entities.Models
{
    public record surveyUser_updateDto
    {
        public string? id {get; set;}
        public string? Name {get; set;}
        public string? Surname {get; set;}
        public int? Age {get; set;}
        public string? City {get; set;}
        public float? LikeRate{get; set;}
        public string? ImageUrl{get; set;}
    }
}