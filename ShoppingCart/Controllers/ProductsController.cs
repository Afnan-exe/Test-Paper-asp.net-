using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using System.IO;


namespace ShoppingCart.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Context _context;
        public IWebHostEnvironment environment;

        public ProductsController(Context context, IWebHostEnvironment e)
        {
            _context = context;
            environment = e;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var context = _context.products.Include(p => p.Category);
            //var context = from p in _context.products join c in _context.categories on p.CategoryId equals c.CategoryId select new {c,p};
            
            
            return View(await context.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var products = await _context.products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CatName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Products products, IFormFile image)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(products);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CatName", products.CategoryId);
            //return View(products);

            if (image != null)
            {
                string extention = Path.GetExtension(image.FileName);

                switch (extention)
                {
                    case ".jpg":
                    case ".gif":
                    case ".pdf":

                        string p = Path.Combine(environment.WebRootPath, "photos");
                        var filename = Path.GetFileName(image.FileName);
                        string ipath = Path.Combine(p, filename);

                        using (var fs = new FileStream(ipath, FileMode.Create))
                        {
                            await image.CopyToAsync(fs);
                        }
                        products.Pimage = @"\photos\" + filename;
                        _context.Add(products);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index");

                        break;

                    default:
                        ViewBag.m = "Wrong Picture Format";
                        break;
                }


            }
            else
            {
                ViewBag.m = "Must Add Picture";

            }
            return View();
        } 

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var a = _context.products.Find(id);
            ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CatName", a.CategoryId);
            return View(a);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Products products)
        {
            _context.Update(products);
           await _context.SaveChangesAsync();
            ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CatName", products.CategoryId);
            return RedirectToAction("Index");
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var products = await _context.products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.products == null)
            {
                return Problem("Entity set 'Context.products'  is null.");
            }
            var products = await _context.products.FindAsync(id);
            if (products != null)
            {
                _context.products.Remove(products);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
          return (_context.products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("i") == null && HttpContext.Session.GetString("adm") == "admin@gmail.com")
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
