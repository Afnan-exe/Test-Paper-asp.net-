using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly Context _context;

        public HomeController(ILogger<HomeController> logger,Context context)
        {
            _logger = logger;
            _context = context;
        }

    

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Shop(string CategorySlug = "")
        {
            
            var count = _context.products.Select(x=>x.Brand).Count();
            HttpContext.Session.SetInt32("countbrands",count);
            if (CategorySlug == "")
            {
                return View(_context.products.OrderByDescending(x => x.ProductId).ToList());
            }
            else
            {
                var category = _context.categories.Where(a=>a.slug== CategorySlug).FirstOrDefault();
                if (category != null)
                {
                    var probycat = _context.products.Where(p=>p.CategoryId==category.CategoryId) ;
                    return View(probycat.OrderByDescending(v => v.ProductId).ToList());
                }
                else { return RedirectToAction("Shop"); }
            }
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult ShopSingle(int? Id) {
            var x = _context.products.Find(Id);
            return View(x);
        }

        public IActionResult Profile(LoginRegister d)
        {

            var x = _context.loginRegister.Where(a => a.Email == HttpContext.Session.GetString("i"));
            return View(x.ToList());
        }

        public IActionResult CheckOut()
        {

            return View();
        }
    }
}