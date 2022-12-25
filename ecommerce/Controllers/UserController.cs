using Microsoft.AspNetCore.Mvc;
using ecommerce.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Web.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace ecommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpContextAccessor context;

        public UserController(IHttpContextAccessor httpContextAccessor)
        {
            context = httpContextAccessor;
        }

        EcommerceDotnetCoreDibboContext db = new EcommerceDotnetCoreDibboContext();
        
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("username") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();

            }

        }

        [HttpPost]
        public IActionResult Login(User loginUser,String ReturnUrl)
        {
            var user = db.Users.FirstOrDefault(u => u.PhoneNo == loginUser.PhoneNo);

            var isPasswordMatched = Crypto.VerifyHashedPassword(user.Password, loginUser.Password);

            if (isPasswordMatched)
            {
                HttpContext.Session.SetString("username", user.FirstName);
                context.HttpContext.Session.SetInt32("userid", user.UserId);

                if (user.IsAdmin == 0)
                {
                    return RedirectToAction("Index", "Home");//user
                }
                else
                {
                    return RedirectToAction("Index", "AdminDashboard");//admin
                }
                
            }
            else
            {
                TempData["Faild"] = "Invalid Account";
                return RedirectToAction("Login", "User");
            }

        }


        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login");
        }



        public IActionResult SignUp()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();

            }
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                try {
                    user.Password = Crypto.HashPassword(user.Password);
                    user.CreatedDate = DateTime.Now;

                    db.Users.Add(user);

                    if (db.SaveChanges() > 0)
                    {
                        return RedirectToAction("Login");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }

            }

            return View();
        }



    }
}
