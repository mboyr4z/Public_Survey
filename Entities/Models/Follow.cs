namespace Entities.Models
{
    public class Follow 
    {
        public int Id {get;set;}
        public string FollowById{get;set;}
        public string FollowedId{get;set;}
        public DateTime FollowTime{get;set;}
    }
}