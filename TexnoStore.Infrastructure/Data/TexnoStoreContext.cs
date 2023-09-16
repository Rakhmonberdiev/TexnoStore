using Microsoft.EntityFrameworkCore;
using TexnoStore.Core.Entities;

namespace TexnoStore.Infrastructure.Data
{
    public class TexnoStoreContext : DbContext
    {
        public TexnoStoreContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
    }
}
