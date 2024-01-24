using Book_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_CRUD.Data
{
    /*
 * Defines the application's database context, inheriting from DbContext.
 */
    public class ApplicationDbContext : DbContext
    {
        /*
         * Includes a DbSet for 'Category' which maps to a table named 'categories' in the database.
         */
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; } // This will create a category table with the name of "categories"
    }
}
