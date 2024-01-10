using Microsoft.EntityFrameworkCore;
using MvcAppSales.Models;

namespace MvcAppSales.Data
{
    public class MvcAppSalesContext(DbContextOptions<MvcAppSalesContext> options) : DbContext(options)
    {
        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;
    }
}
