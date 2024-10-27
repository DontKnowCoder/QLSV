using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLSV.Data;
using QLSV.Models;
using System.Diagnostics;

namespace QLSV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QLSVContext _context;
        public HomeController(ILogger<HomeController> logger, QLSVContext context)
        {
            _logger = logger;
            _context=context;
        }

        public async Task<IActionResult> Index(string searchQuery)
        {
            var students = await _context.SV
                .Where(s => string.IsNullOrEmpty(searchQuery) || s.Name.Contains(searchQuery))
                .ToListAsync();

            ViewData["Title"] = "Trang chủ";
            return View(students); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
