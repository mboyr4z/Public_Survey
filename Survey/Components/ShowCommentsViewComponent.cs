using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Survey.Benimkiler;
using Survey.Models;

namespace Survey.Components
{
    public class ShowCommentsViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        private readonly MainPageModel _mainPageModel;

        public ShowCommentsViewComponent(IServiceManager manager, MainPageModel mainPageModel)
        {
            _manager = manager;
            _mainPageModel = mainPageModel;
        }
        private CommentItem commentItem;

        private ShowCommentsItem showCommentsItems;

        public async Task<IViewComponentResult> InvokeAsync(int postId)
        {

            IQueryable<Comment> comments = _manager.CommentService.GetAllComments(false).Where(c => c.PostId.Equals(postId));
            showCommentsItems = new ShowCommentsItem();


            showCommentsItems.userImageUrl = (_mainPageModel.User is not null  && await _manager.IsSurveyUserMembershipCompletedAsync(_mainPageModel.User)) ?  await _manager.GetImageUrlById(_mainPageModel.User.Id) : ""; 
            showCommentsItems.postId = postId;

            foreach (Comment comment in comments)
            {
                
                commentItem = new CommentItem();

                string commenterId = comment.CommenterId;

                commentItem.FullName = await _manager.GetFullNameById(commenterId);
                commentItem.PublishTime = comment.PublishTime;
                commentItem.Content = comment.Content;
                commentItem.CommenterImageUrl = await _manager.GetImageUrlById(commenterId);
                commentItem.CommentatorId = comment.CommenterId;

                showCommentsItems.commentItems.Add(
                        commentItem
                );
            }


            return View(model: showCommentsItems);
        }
    }

    public class ShowCommentsItem
    {
        public int postId;
        public string userImageUrl;
        public List<CommentItem> commentItems;

        public ShowCommentsItem()
        {
              commentItems = new List<CommentItem>();
        }
    }
    public class CommentItem
    {
        public string CommentatorId{get;set;}

        public string FullName { get; set; }
        public DateTime PublishTime { get; set; }
        public string Content;

        public string CommenterImageUrl { get; set; }
    }
}