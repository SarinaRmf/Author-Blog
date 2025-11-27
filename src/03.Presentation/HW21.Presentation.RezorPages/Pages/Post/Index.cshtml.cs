using HW21.Domain.Core.Contracts.AppService;
using HW21.Domain.Core.Dtos.Post;
using HW21.Presentation.RezorPages.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW21.Presentation.RezorPages.Pages.Post
{
    public class IndexModel(IPostAppService postApp) : BasePageModel
    {
        public List<GetPostDto> Posts {  get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            Posts = postApp.GetUserPosts(GetUserId());
        }
        public IActionResult OnGetDelete(int postId)
        {
            var result = postApp.Delete(postId);
            if (result.IsSuccess)
            {
                return RedirectToPage();
            }
            Message = result.Message;
            return RedirectToPage();
        }
    }
}
