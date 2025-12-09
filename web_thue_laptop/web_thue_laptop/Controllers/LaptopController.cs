using Microsoft.AspNetCore.Mvc;

namespace web_thue_laptop.Controllers
{
    public class LaptopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
