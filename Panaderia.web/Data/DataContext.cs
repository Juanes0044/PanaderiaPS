using Microsoft.EntityFrameworkCore;
using Panaderia.web.Data.Entities;

namespace Panaderia.web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet <Product> Products { get; set; }
        

        public DbSet<Supplier> Suppliers { get; set; }

    }

}
