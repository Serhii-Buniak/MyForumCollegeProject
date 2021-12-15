using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyForumProject.Models;
using System.Threading.Tasks;

namespace MyForumProject.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public NotificationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            AppUser user = await _userManager.GetUserAsync(User);
            return View(user.Notifications);
        }
    }
}
