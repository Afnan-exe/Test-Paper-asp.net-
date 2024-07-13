using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class LoginController : Controller
    {
        public Context _context;

        public LoginController(Context c)
        {
            _context = c;
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LoginRegister a)
        {
            var x = _context.loginRegister.FirstOrDefault(i=>i.Email==a.Email);
            if (a.Email.Equals(x?.Email))
            {

				ViewBag.c = "Already Have an Account using this Email";
				return View();
                
			}
            else
            {
				if (a.Password == a.PasswordConfirmed)
				{

					_context.loginRegister.Add(a);
					_context.SaveChanges();
					return RedirectToAction(nameof(UserLogin));

				}
				else
				{
					ViewBag.c = "Password is not confirmed";
					return View();
				}

			}
            return RedirectToAction("UserLogin");

        }

        [HttpGet]
        public IActionResult UserLogin() {
            return View();
        }

         [HttpPost]
        public IActionResult UserLogin(LoginRegister a) {

            if(a.Email== "admin@gmail.com" && a.Password== "1234567")
            {
                HttpContext.Session.SetString("adm", a.Email);
                return RedirectToAction("Dashboard" , "Products");
            }

           var x = from i in _context.loginRegister
                    where i.Email.Equals(a.Email)
                    && i.Password.Equals(a.Password)
                    select i; 
            if (x.Any())
            {
                HttpContext.Session.SetString("i", a.Email);
                return RedirectToAction("Index", "Home");
            }

            else
            {
                ViewBag.m = "Invalid Credentials";
                return View();
            }

            //var c = _context.loginRegister.Where(b => b.Email == a.Email && b.Password == a.Password);
            //if (c.Any())
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    ViewBag.m = "Invalid Credentials";
            //    return View();
            //}
     
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var x = _context.loginRegister.Find(id);
            return View(x);
        }

        [HttpPost]
        public IActionResult Edit(LoginRegister a)
        {
            _context.Update(a);
            _context.SaveChanges();
            return RedirectToAction("Profile","Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
} 