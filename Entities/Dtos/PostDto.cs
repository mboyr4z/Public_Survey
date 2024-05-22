using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record PostDto
    {
        public int Id {get;set;}
        public string PublisherId{get;set;} 

        [Required(ErrorMessage = "Content is required")]
        public string Content {get;set;}
        public bool IsGlobal {get;set;}
        public DateTime PublishTime {get;set;}
        public string IsGlobalString{get;set;}
    }
}