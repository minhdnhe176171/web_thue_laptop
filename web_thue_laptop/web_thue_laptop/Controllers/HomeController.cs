using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_thue_laptop.Models; // Nhớ dòng này
using System.Diagnostics;

namespace web_thue_laptop.Controllers
{
    public class HomeController : Controller
    {
        private readonly Swp391LaptopContext _context; // Khai báo Context

        // Inject Context vào Constructor
        public HomeController(Swp391LaptopContext context)
        {
            _context = context;
        }

        

        // ... các hàm khác giữ nguyên
    }
}