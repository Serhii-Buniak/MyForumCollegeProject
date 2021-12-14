using Microsoft.AspNetCore.Mvc;
using MyForumProject.Data;
using MyForumProject.Models;

namespace MyForumProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}