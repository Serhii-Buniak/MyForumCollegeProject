using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyForumProject.Models;
using MyForumProject.Services.Ropositories;
using System.Linq;
using System.Threading.Tasks;

namespace MyForumProject.Controllers
{
    [Authorize]
    public class FavoriteController : Controller
    {
        private readonly IFavoritePostRepository _favoriteRepository;
        private readonly IPostRepository _postRepository;
        private readonly UserManager<AppUser> _userManager;

        public FavoriteController(IFavoritePostRepository favoritePostRepository, IPostRepository postRepository, UserManager<AppUser> userManager)
        {
            _favoriteRepository = favoritePostRepository;
            _postRepository = postRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            AppUser user = await _userManager.GetUserAsync(User);
            return View(user.FavoritePosts);
        }

        public async Task<IActionResult> Add(long postId)
        {
            AppUser user = await _userManager.GetUserAsync(User);
            Post post = await _postRepository.GetByIdAsync(postId);
            if (post == null)
            {
                return NotFound();
            }
            bool wasAdded = _favoriteRepository.ContainPost(post, user);
            if (wasAdded)
            {
                return BadRequest();
            }
            else
            {
                await _favoriteRepository.AddAsync(new FavoritePost { Post = post, User = user });
                return RedirectToAction("Details", "Post", new { Id = postId });
            }
        }

        public async Task<IActionResult> Remove(long postId)
        {
            AppUser user = await _userManager.GetUserAsync(User);
            var favorite = _favoriteRepository.GetByPost(postId, user);
            if (favorite == null)
            {
                return NotFound();
            }
            else
            {
                _favoriteRepository.Delete(favorite);
                return RedirectToAction("Details", "Post", new { Id = postId });
            }
        }

        public async Task<IActionResult> Delete(long Id)
        {
            bool wasAdded = _favoriteRepository.Contain(Id);
            if (wasAdded)
            {
                await _favoriteRepository.DeleteAsync(Id);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
               
            }
        }
    }
}
