using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAJAXDEMO2.Models;

namespace WebApplicationAJAXDEMO2.Controllers
{
    public class ApiController : Controller
    {
        private readonly MyDBContext _context;
        public ApiController(MyDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //暫停五秒
            System.Threading.Thread.Sleep(1000);
            string content = "Ajax, 您好";
            return Content(content, "text/plain", System.Text.Encoding.UTF8);
        }
        public IActionResult Cities()
        {
            //MyDBContext _context = new MyDBContext(); 
            var cities = _context.Addresses.Select(async => async.City).Distinct();
            return Json(cities);
        }
        //todo 根據 city 讀出鄉鎮區(site_id)的資料

        //todo 根據 site_id 讀出路名(road) 

        //public IActionResult SiteRoadName(string )
        //{
                    //var member = _context.Addresses.Find(city);
                    //if (member != null)
                    //{

                    //    return View();
                    //}
                    //return NotFound();

        //}

        public IActionResult Avatar(int id=1)
        {
            var member = _context.Members.Find(id);
            if (member != null)
            {
                byte[] img = member.FileData;
                return File(img, "image/jpeg");
            }
            return NotFound();

        }
        

    }
}