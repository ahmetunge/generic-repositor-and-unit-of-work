using Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Data.EntityFrameworkCore
{
    public class EfCoreContext : DbContext
    {
        public EfCoreContext(DbContextOptions<EfCoreContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }
    }
}