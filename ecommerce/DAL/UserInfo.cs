using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.DAL
{
    public class UserInfo
    {
        EcommerceDotnetCoreDibboContext DBcontext = new EcommerceDotnetCoreDibboContext();
        //List<User> users = new List<User>();
        public int getLoggedInUserId()
        {
            IHttpContextAccessor accessor = new HttpContextAccessor();

            return (int)accessor.HttpContext.Session.GetInt32("userid");
        }

        public  List<User> getLoggedInUserInfo(int userID)
        {

            //var users = DBcontext.Users.Select(c => new User
            //{
            //    UserId = c.UserId,
            //    FirstName = c.FirstName,
            //    LastName = c.LastName,
            //    Email = c.Email,
            //    PhoneNo = c.PhoneNo,
            //    IsAdmin = c.IsAdmin,
            //}).Where(a => a.UserId == userID).Single();



            //List<User> userData = DBcontext.Users.Include(dept => dept.UserProfiles).Where(dept => dept.UserId == userID).ToList();
            var userData = DBcontext.Users.Include(dept => dept.UserProfiles).ToList();

            //foreach (var user in userData)
            //{
            //    foreach (var profile in user.UserProfiles)
            //    {
            //        Console.WriteLine(profile.FullName);

            //    }
            //}

            return userData;
        }


    }
}
