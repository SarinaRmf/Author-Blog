using HW21.Domain.Core.Contracts.AppService;
using HW21.Domain.Core.Dtos.Category;
using HW21.Domain.Core.Dtos.Post;
using HW21.Domain.Core.Entities;
using HW21.Presentation.RezorPages.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW21.Presentation.RezorPages.Pages.Post
{
    public class CreatePostModel(IPostAppService postAppService, ICategoryAppService categoryAppService) : BasePageModel
    {
        [BindProperty]
        public CreatePostDto Post { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public List<GetCategoryDto> Categories { get; set; }
        public void OnGet()
        {
            UserId = GetUserId();
            Categories = categoryAppService.GetAll(UserId);
        }
        public IActionResult OnPost()
        {
            Post.AuthorId = GetUserId();
            var createResult = postAppService.Add(Post);
            if (createResult.IsSuccess)
            {
                return RedirectToPage("/Post/Index");//
            }
            Message = createResult.Message;
            return Page();
        }
    }
}
