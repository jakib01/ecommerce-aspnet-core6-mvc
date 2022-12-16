using Microsoft.AspNetCore.Mvc;
using ecommerce.DAL;
using ecommerce.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Web.Helpers;

namespace ecommerce.Controllers
{
    public class UserController : Controller
    {
        EcommerceDotnetCoreDibboContext db = new EcommerceDotnetCoreDibboContext();
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User loginUser,String ReturnUrl)
        {
            var user = db.Users.FirstOrDefault(u => u.PhoneNo == loginUser.PhoneNo);

            var isPasswordMatched = Crypto.VerifyHashedPassword(user.Password, loginUser.Password);

            if (isPasswordMatched)
            {
                HttpContext.Session.SetString("username", user.FirstName);
                //return View();

                //TempData["Success"] = "Added Successfully!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Faild"] = "Invalid Account";
                return RedirectToAction("Login", "User");
            }

            //return View();
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
            return View();
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
