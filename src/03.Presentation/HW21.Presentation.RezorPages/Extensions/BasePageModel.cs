using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW21.Presentation.RezorPages.Extensions
{
    public class BasePageModel : PageModel
    {
        public bool UserIsLoggedIn()
        {
            return Request.Cookies.Any(x => x.Key == "Id");

        }

        public int GetUserId()
        {
            if (Request.Cookies.TryGetValue("Id", out var userIdStr) &&
                int.TryParse(userIdStr, out var userIdFromCookie))
            {
                return userIdFromCookie;
            }

            throw new Exception("User is not logged in.");
        }
    }
}
