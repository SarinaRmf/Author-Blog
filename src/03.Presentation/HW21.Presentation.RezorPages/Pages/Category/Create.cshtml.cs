using HW21.Domain.Core.Contracts.AppService;
using HW21.Domain.Core.Dtos.Category;
using HW21.Presentation.RezorPages.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW21.Presentation.RezorPages.Pages.Category
{
    public class CreateModel(ICategoryAppService categoryApp) : BasePageModel
    {
        [BindProperty]
        public CreateCategoryDto CategoryDto { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            CategoryDto.AuthorId = GetUserId();
            var createResult = categoryApp.Add(CategoryDto);
            if (createResult.IsSuccess)
            {
                return RedirectToPage("/Post/Index");
            }
            Message = createResult.Message;
            return Page();
        }
    }
}
