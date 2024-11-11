using Carl_Zeiss_Assignment.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carl_Zeiss_Assignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }


    }
}
