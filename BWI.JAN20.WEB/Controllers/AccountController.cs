using BWI.JAN20.WEB.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BWI.JAN20.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly BWIJAN20WEBContext _context;
        public AccountController(BWIJAN20WEBContext dboContext)
        {
            _context = dboContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignUp(string? email, string? password, string? confirmPassword)
        {
            var model = new SignupModel();
            model = new SignupModel() { Email = "binod@gmail.com" };
            return View(model);
        }

        [HttpPost]
        public IActionResult SignUp(SignupModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["model"] = $"Email {model.Email} Password {model.Password}";
                return RedirectToAction("Index", "Account");
            }
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost, AllowAnonymous]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.User.FirstOrDefault(x => x.Email == model.Username && x.Password == model.Password);
                if (user != null)
                {
                    //do some thing regarding authentication
                    //
                    List<Claim> claims = new List<Claim>() {
                     new Claim(ClaimTypes.Email,model.Username),
                     new Claim("wardno","1"),
                     new Claim(ClaimTypes.Role,"user"),
                     new Claim(ClaimTypes.Role,"admin")
                    };

                    var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimPrinciple = new ClaimsPrincipal(claimsIdentity);
                    HttpContext.SignInAsync(claimPrinciple);

                    return RedirectToAction("index", "home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid Username Or Password");
                }
            }
            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext
                .SignOutAsync();
            return RedirectToAction("login");
        }
        private void addingClaimIdentity(LoginModel user, string roles, string fullname)
        {
            //list of claims
            var userClaims = new List<Claim>()
                {
                    new Claim("UserName", user.Username),
                    new Claim(ClaimTypes.Email,user.Username),
                    new Claim(ClaimTypes.Name,fullname),
                    new Claim("Mobile","9841235678"),
                   // new Claim(ClaimTypes.Role,"user"),
                    new Claim(ClaimTypes.Role,roles)
                 };

            //create a identity claims
            var claimsIdentity = new ClaimsIdentity(
            userClaims, CookieAuthenticationDefaults.AuthenticationScheme);


            //httcontext , current user is authentic user
            //sing in user to httpcontext
            HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity)
            );
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
