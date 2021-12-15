using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyForumProject.Models;
using MyForumProject.Services.Ropositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyForumProject.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostRateRepository _postRateRepository;
        private readonly UserManager<AppUser> _userManager;

        public PostController(IPostRepository postRepository, IPostRateRepository postRateRepository, UserManager<AppUser> userManager)
        {
            _postRepository = postRepository;
            _postRateRepository = postRateRepository;
            _userManager = userManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_postRepository.Posts);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(long id)
        {
            Post post = await _postRepository.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        public RedirectToActionResult Random()
        {
            Random random = new Random();
            long id = random.Next(1, _postRepository.Posts.Count() + 1);
            return RedirectToAction("Details", new { Id = id });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            AppUser user = await _userManager.GetUserAsync(User);
            post.User = user;
            await _postRepository.AddAsync(post);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Like(long postId)
        {
            return await SetRate(postId, Rate.Like);
        }

        public async Task<IActionResult> Dislike(long postId)
        {
            return await SetRate(postId, Rate.Dislike);
        }

        public async Task<IActionResult> ResetRate(long postId)
        {
            return await SetRate(postId, Rate.None);
        }

        [NonAction]
        private async Task<IActionResult> SetRate(long postId, Rate rate)
        {
            var successResult = RedirectToAction("Details", new { Id = postId });

            AppUser user = await _userManager.GetUserAsync(User);
            Post post = await _postRepository.GetByIdAsync(postId);
            PostRate postRate = post.Rates.FirstOrDefault(r => r.Post.Id == post.Id && r.User == user);

            if (rate == Rate.None)
            {
                if (postRate == null)
                {
                    return BadRequest();
                }
            }
            else
            {
                if (postRate == null)
                {
                    await _postRateRepository.AddAsync(new PostRate { Rate = rate, Post = post, User = user });
                    return successResult;
                }
            }
            if (postRate.Rate == rate)
            {
                return BadRequest();
            }

            postRate.Rate = rate;
            _postRateRepository.Update(postRate);

            return successResult;
        }
    }
}
