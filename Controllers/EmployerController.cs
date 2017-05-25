using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.Controllers
{
    [Route("views/[controller]")]
    public class EmployerController : Controller
    {
        [HttpGet("waiter")]
        public IActionResult Waiter()
        {
            return View();
        }

        [HttpGet("cooker")]
        public IActionResult Cooker()
        {
            return View();
        }

        [HttpGet("cashier")]
        public IActionResult Cashier()
        {
            return View();
        }
    }
}
