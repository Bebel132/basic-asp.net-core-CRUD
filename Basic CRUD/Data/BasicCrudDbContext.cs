using Basic_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Basic_CRUD.Data
{
    public class BasicCrudDbContext : DbContext
    {
        public BasicCrudDbContext(DbContextOptions<BasicCrudDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
