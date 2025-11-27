using HW21.Domain.Core.Contracts.AppService;
using HW21.Domain.Core.Dtos.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW21.Presentation.RezorPages.Pages.Home
{
    public class IndexModel(IPostAppService postAppService) : PageModel
    {
        public List<GetPostDto> Posts { get; set; }
        public void OnGet()
        {
            Posts = postAppService.GetAll();
        }
        public void OnPost() { 
        
        
        }
    }
}
