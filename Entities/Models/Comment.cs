namespace Entities.Models
{
    public class Comment 
    {
        public int Id {get;set;}
        public int PostId {get;set;}
        public string Content {get;set;}
        public string CommenterId {get;set;}
        public DateTime PublishTime {get;set;}
    }
}