using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public record surveyUser_createDto
    {
        
        public string? Id {get; set;}
        [Required(ErrorMessage = "Name is required")]
        public string? Name {get; set;}
        // [Required(ErrorMessage = "Surname is required")]
        public string? Surname {get; set;}
        // [Required(ErrorMessage = "Age is required")]
        public int? Age {get; set;}
        // [Required(ErrorMessage = "City is required")]
        public string? City {get; set;}
        public float? LikeRate{get; set;}
        public string? ImageUrl{get; set;}
    }
}