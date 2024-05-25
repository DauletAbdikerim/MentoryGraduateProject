using GraduateProject.Domain.Core;
using GraduateProject.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace MentoryGraduateProject_WebApp.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var login = claimsIdentity?.FindFirst(ClaimTypes.Name);

            if (login != null)
            {
                var user = new User
                {
                    Login = login.Value
                };
                return View(user);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var userFromDb = _userRepository.GetUserByLoginAndPassword(user.Login, user.Password);
            if (userFromDb != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Login)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
