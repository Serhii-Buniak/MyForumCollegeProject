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
    public class CommentController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly ICommentRateRepository _commentRateRepository;
        private readonly ICommentNotificationRepository _notificationRepository;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(IPostRepository postRepository, ICommentRepository commentRepository,ICommentRateRepository commentRateRepository, ICommentNotificationRepository commentNotificationRepository, UserManager<AppUser> userManager)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            _commentRateRepository = commentRateRepository;
            _notificationRepository = commentNotificationRepository;
            _userManager = userManager;
        }

        [HttpPost]
     
        public async Task<IActionResult> Create(Comment comment)
        {

            comment.Post = await _postRepository.GetByIdAsync(comment.PostId);
            if (comment.Post == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid == false)
            {
                return View("~/Views/Post/Details.cshtml", comment.Post);
            }
            AppUser user = await _userManager.GetUserAsync(User);

            comment.User = user;
            await _commentRepository.AddAsync(comment);

            string content = comment.Content;
            if (content.StartsWith('@'))
            {
                var spaceIndex = content.IndexOf(' ');
                var username = content.Substring(1, spaceIndex - 1);
                AppUser markedUser = await _userManager.FindByNameAsync(username);

                if (markedUser != null)              
                    await _notificationRepository.AddAsync(new CommentNotification { Comment = comment, User = markedUser });        
            }

            return RedirectToAction("Details", "Post", new { id = comment.PostId });
        }

        public async Task<IActionResult> Like(long commentId)
        {
            return await SetRate(commentId, Rate.Like);
        }

        public async Task<IActionResult> Dislike(long commentId)
        {
            return await SetRate(commentId, Rate.Dislike);
        }

        public async Task<IActionResult> ResetRate(long commentId)
        {
            return await SetRate(commentId, Rate.None);
        }

        [NonAction]
        private async Task<IActionResult> SetRate(long commentId, Rate rate)
        {

            AppUser user = await _userManager.GetUserAsync(User);
            Comment comment = await _commentRepository.GetByIdAsync(commentId);
            CommentRate commentRate = comment.Rates.FirstOrDefault(r => r.Comment.Id == commentId && r.User == user);

            var successResult = RedirectToAction("Details", "Post", new { Id = comment.PostId });

            if (rate == Rate.None)
            {
                if (commentRate == null)
                {
                    return BadRequest();
                }
            }
            else
            {
                if (commentRate == null)
                {
                    await _commentRateRepository.AddAsync(new CommentRate { Rate = rate, Comment = comment, User = user });
                    return successResult;
                }
            }
            if (commentRate.Rate == rate)
            {
                return BadRequest();
            }

            commentRate.Rate = rate;
            _commentRateRepository.Update(commentRate);

            return successResult;
        }
    }
}
