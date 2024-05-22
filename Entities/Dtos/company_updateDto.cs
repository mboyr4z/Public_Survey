using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.Dtos
{
    public record company_updateDto
    {
        public int Id{get; set;}
        public string Name{get;set;}
        public string? Address {get;set;}
        public string ImageUrl {get; set;}

        public bool? IsConfirmed{get;set;}
    }
}