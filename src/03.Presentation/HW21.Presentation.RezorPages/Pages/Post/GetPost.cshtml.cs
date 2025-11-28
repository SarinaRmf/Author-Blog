using HW21.Domain.Core.Contracts.AppService;
using HW21.Domain.Core.Dtos.Comment;
using HW21.Domain.Core.Dtos.Post;
using HW21.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW21.Presentation.RezorPages.Pages.Post
{
    public class GetPostModel(IPostAppService postAppService,ICommentAppService commentApp) : PageModel
    {
        [BindProperty]
        public CreateCommentDto CreateCommentDto { get; set; }
        [BindProperty]
        public List<GetCommentDto> Comments { get; set; } = new List<GetCommentDto>();
        [BindProperty]
        public GetPostDto SelectedPost { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public void OnGet(int id)
        {
            SelectedPost = postAppService.GetPost(id);
            Comments = commentApp.GetAcceptedComments(id);
        }
        public IActionResult OnPost(int id)
        {

            if (string.IsNullOrWhiteSpace(CreateCommentDto.FirstName) || string.IsNullOrWhiteSpace(CreateCommentDto.LastName) 
                || string.IsNullOrWhiteSpace(CreateCommentDto.Email) || string.IsNullOrEmpty(CreateCommentDto.Text)){
                Message = "فیلد های لازم باید پر شوند!";
                return Page();
            }
            var submitComment = commentApp.Add(CreateCommentDto);
            Message = submitComment.Message;

            //SelectedPost = postAppService.GetPost(id);
            //Comments = commentApp.GetAcceptedComments(id);

            return RedirectToPage("/Post/GetPost", new {id = id});
        }

    }
}
