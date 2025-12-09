using Microsoft.AspNetCore.Mvc;

namespace web_thue_laptop.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
