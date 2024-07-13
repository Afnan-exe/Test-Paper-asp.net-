using Microsoft.EntityFrameworkCore;
namespace ShoppingCart.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> x):base(x) { }

        public DbSet<Category> categories { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<LoginRegister> loginRegister { get; set; }
    }
}
