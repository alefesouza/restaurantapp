using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.Controllers
{
    [Route("views/[controller]")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("product")]
        public IActionResult Product()
        {
            return View();
        }
    }
}
