using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ecommerce.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ecommerce.Controllers.Admin
{
    public class AdminDashboardController : Controller
    {
        public AdminDashboardController(IHttpContextAccessor userid)
        {
            var userID = userid.HttpContext.Session.GetInt32("userid");
        }

        public IActionResult Index()
        {

            return View();
        }



    }
}
