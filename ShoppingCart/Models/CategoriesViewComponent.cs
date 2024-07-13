using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Models
{
    public class CategoriesViewComponent:ViewComponent
    {
        public Context _context;
       public CategoriesViewComponent(Context c)
        {
            _context = c;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.categories.ToListAsync());
        }
    }
}
