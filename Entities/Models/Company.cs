namespace Entities.Models
{
    public class Company
    {
        public int Id{get; set;}
        public string Name{get;set;}
        public string? Address {get;set;}
        public string ImageUrl {get; set;}
        public bool? IsConfirmed{get;set;}
    }
}