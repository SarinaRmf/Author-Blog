using HW21.Domain.Core.Contracts.AppService;
using HW21.Domain.Core.Dtos.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW21.Presentation.RezorPages.Pages.Category
{
    public class UpdateModel(ICategoryAppService categoryApp) : PageModel
    {
        [BindProperty]
        public GetCategoryDto CategoryDto { get; set; }
        public string Message { get; set; }
        
        public void OnGet(int id)
        {
            CategoryDto = categoryApp.GetById(id);
        }
        public IActionResult OnPost(int id)
        {
            CategoryDto.Id = id;
            var result = categoryApp.Update(CategoryDto);
            if (result.IsSuccess)
            {
                return RedirectToPage("/Category/Index");
            }
            Message = result.Message;
            return Page();
        }
    }
}
