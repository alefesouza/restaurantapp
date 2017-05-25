using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.Controllers
{
    [Route("views")]
    public class SimpleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet("welcome")]
        public IActionResult Welcome()
        {
            return View();
        }

        [HttpGet("settings")]
        public IActionResult Settings()
        {
            return View();
        }
    }
}
