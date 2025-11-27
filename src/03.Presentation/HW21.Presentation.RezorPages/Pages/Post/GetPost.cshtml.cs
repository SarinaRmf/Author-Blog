using HW21.Domain.Core.Contracts.AppService;
using HW21.Domain.Core.Dtos.Post;
using HW21.Framework;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW21.Presentation.RezorPages.Pages.Post
{
    public class GetPostModel(IPostAppService postAppService) : PageModel
    {
        public GetPostDto SelectedPost { get; set; }
        public void OnGet(int id)
        {
            SelectedPost = postAppService.GetPost(id);
        }
    }
}
