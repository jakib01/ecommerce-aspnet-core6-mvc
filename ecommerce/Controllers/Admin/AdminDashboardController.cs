using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ecommerce.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ecommerce.Models;

namespace ecommerce.Controllers.Admin
{
    public class AdminDashboardController : Controller
    {
        private int userID;
        UserInfo userInfo = new UserInfo();

        public AdminDashboardController()
        {
            userID = userInfo.getLoggedInUserId();
        }

        public  IActionResult Index()
        {
            var userData =  userInfo.getLoggedInUserInfo(userID);
            Console.WriteLine(userData);
            return View(userData);
        }



    }
}
