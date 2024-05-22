namespace Entities.Models
{
    public class Post 
    {
        public int Id {get;set;}
        public string PublisherId{get;set;} 
        public string Content {get;set;}
        public bool IsGlobal {get;set;}
        public DateTime PublishTime {get;set;}
    }
}