using HW21.Domain.Core.Contracts.AppService;
using HW21.Domain.Core.Dtos.Category;
using HW21.Domain.Core.Dtos.Post;
using HW21.Presentation.RezorPages.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW21.Presentation.RezorPages.Pages.Post
{
    public class EditPostModel(IPostAppService postApp, ICategoryAppService categoryApp) : BasePageModel
    {
        public string Message { get; set; }
        public List<GetCategoryDto> Categories { get; set; }
        [BindProperty]
        public UpdatePostDto updatedPost { get; set; }
        public void OnGet(int postId)
        {
            Categories = categoryApp.GetAll(GetUserId());
            updatedPost = postApp.GetUpdatePost(postId);
        }
        public IActionResult OnPost()
        {
            Categories = categoryApp.GetAll(GetUserId());
            var updateResult = postApp.Update(updatedPost);
            if (updateResult.IsSuccess)
            {
                return RedirectToPage("/Post/Index");
            }
            Message = updateResult.Message;
            return Page();
        }
    }
}
