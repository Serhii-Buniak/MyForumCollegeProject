using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MyForumProject.Models;
using System.Threading.Tasks;

namespace MyForumProject.Component
{
    public class CommentViewComponent : ViewComponent
    {
        public async Task<ViewViewComponentResult> InvokeAsync(long postId)
        {
            return await Task.Run(() =>
            {
                Comment post = new Comment() { PostId = postId };
                return View(post);
            }); 
        }
    }
}
