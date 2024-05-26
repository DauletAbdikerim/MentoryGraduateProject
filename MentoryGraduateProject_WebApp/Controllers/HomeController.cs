using GraduateProject.Infrastructure.Data;
using MentoryGraduateProject_WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace MentoryGraduateProject_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationContext db)
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
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var login = claimsIdentity?.FindFirst(ClaimTypes.Name);
            if (login == null) 
            {
                return RedirectToAction("Login", "User");
            }
            var user = _db.Users.FirstOrDefault(x => x.Login == login.Value);
            if(user == null)
            {
                return RedirectToAction("Login", "User");
            }
            return View(_db.Books.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
