namespace Survey.Models;

public class ShowedPost
{
    public string publisherId { get; set; }
    public string content { get; set; }
    public string publisherFullName { get; set; }
    public DateTime publishTime { get; set; }
    public int commentCount { get; set; }
    public int likeCount { get; set; }
    public IQueryable<string> comments { get; set; }
    public string publisherInformation{get;set;}
    public string publisherImagePath {get;set;}

    public int postId{get;set;}
}