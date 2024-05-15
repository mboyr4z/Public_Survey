using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.Dtos
{
    public record company_createDto
    {   
        public int Id{get; set;}
        [Required(ErrorMessage = "Name is required")]
        public string Name{get;set;}
        [Required(ErrorMessage = "Address is required")]
        public string Address {get;set;}
        public string ImageUrl {get; set;}
    }
}