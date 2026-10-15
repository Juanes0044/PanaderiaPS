using Microsoft.EntityFrameworkCore;
using PanaderiaV2.Web.Data.Entities;

namespace PanaderiaV2.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
