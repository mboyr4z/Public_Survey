
namespace Entities.Models
{
    public class Chat 
    {
        public int Id {get;set;}
        public string SenderId {get;set;}
        public string ReceiverId {get;set;}
        public string Content {get;set;}
        public DateTime PublishTime {get;set;}
    }
}