using HW21.Domain.Core.Contracts.AppService;
using HW21.Domain.Core.Dtos.Author;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW21.Presentation.RezorPages.Pages.Account
{
    public class RegisterModel(IAuthorAppService authorAppService) : PageModel
    {
        [BindProperty]
        public CreateAuthorDto authorDto { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var registerResult = authorAppService.Register(authorDto);
            if (registerResult.IsSuccess)
            {
                return RedirectToPage("/Account/Login");
            }
            Message = registerResult.Message;
            return Page();
        }
    }
}
