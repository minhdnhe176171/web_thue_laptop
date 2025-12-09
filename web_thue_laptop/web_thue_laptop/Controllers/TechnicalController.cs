using Microsoft.AspNetCore.Mvc;

namespace web_thue_laptop.Controllers
{
    public class TechnicalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
