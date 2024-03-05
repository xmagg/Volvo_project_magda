using Microsoft.AspNetCore.Mvc;

namespace NewsPlatform2.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
