using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplicationAJAXDEMO2.Models;

namespace WebApplicationAJAXDEMO2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDBContext _context;

        public HomeController(ILogger<HomeController> logger, MyDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult HomeWork()
        {
            return View();
        }
        public IActionResult JsonTest()
        {

            var emps = new List<Employee>
        {
            new Employee { Name = "Tom", WorkYears = 3, Salary = 35000 },
            new Employee { Name = "Jack", WorkYears = 5, Salary = 4000 },
            new Employee { Name = "Mary", WorkYears = 8, Salary = 30000 }
        };

            return View(emps);
        }
        public class Employee
        {
            public string Name { get; set; }
            public int WorkYears { get; set; }
            public int Salary { get; set; }
        }
        public IActionResult CallAPi()
        {
            return View();
        }
        public IActionResult First()
        {
            var categories = _context.Categories;
            return View(categories);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
