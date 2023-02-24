using AspnetCore.Unpoly;
using LunchTime.Database;
using LunchTime.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Principal;

namespace LunchTime.Controllers
{
    [Authorize]
    public class HomeController : UpController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _db;

        public HomeController(ILogger<HomeController> logger, DatabaseContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ToggleTheme()
        {
            var newTheme = Theme == "light" ? "dark" : "light";

            Response.Cookies.Delete("theme");
            Response.Cookies.Append("theme", newTheme);
            ViewData["Theme"] = newTheme;
            var referer = Request.Headers["Referer"].FirstOrDefault();
            return Redirect(referer ?? "/");
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}