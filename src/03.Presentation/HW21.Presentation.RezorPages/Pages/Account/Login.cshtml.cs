using HW21.Domain.Core.Contracts.AppService;
using HW21.Presentation.RezorPages.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW21.Presentation.RezorPages.Pages.Account
{
    
    public class LoginModel(IAuthorAppService authorAppService, ICookieService cookieService) : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost() { 
        
            var loginResult = authorAppService.Login(Username, Password);
            if (loginResult.IsSuccess)
            {
                cookieService.Set("Id", loginResult.Data.UserId.ToString());
                cookieService.Set("Username", loginResult.Data.UserName);

                return RedirectToPage("/Post/Index");
            }
            else {

                Message = loginResult.Message;
                return Page();
            }
        }
    }
}
