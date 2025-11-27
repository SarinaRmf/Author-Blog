using HW21.Domain.Core.Contracts.AppService;
using HW21.Domain.Core.Dtos.Category;
using HW21.Presentation.RezorPages.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW21.Presentation.RezorPages.Pages.Category
{
    public class IndexModel(ICategoryAppService categoryAppService) : BasePageModel
    {
        public List<GetCategoryDto> Categories { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            Categories = categoryAppService.GetAll(GetUserId());
        }
        public IActionResult OnGetDelete(int Id)
        {
            var result = categoryAppService.Delete(Id);
            if (result.IsSuccess)
            {
                return RedirectToPage();
            }
            Message = result.Message;
            return RedirectToPage();
        }

    }
}
