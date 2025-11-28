using HW21.Domain.Core.Contracts.AppService;
using HW21.Domain.Core.Dtos.Comment;
using HW21.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW21.Presentation.RezorPages.Pages.Comment
{
    public class IndexModel(ICommentAppService commentApp) : PageModel
    {
        public List<GetCommentDto> Comments { get; set; } 
        public void OnGet(int postId)
        {
            Comments = commentApp.GetComments(postId);
           
        }

        public IActionResult OnGetReject(int commentId, int postId) {

            var result = commentApp.SetCommentStatus(commentId, Domain.Core.Enums.CommentStatus.Rejected);

            return RedirectToPage("/Comment/Index", new {postId});
        }
        public IActionResult OnGetAccept(int commentId, int postId)
        {
            var result = commentApp.SetCommentStatus(commentId, Domain.Core.Enums.CommentStatus.Accepted);
            return RedirectToPage("/Comment/Index", new {postId });
        }
    }
}
