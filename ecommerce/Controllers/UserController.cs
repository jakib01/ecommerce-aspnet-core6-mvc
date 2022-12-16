using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
