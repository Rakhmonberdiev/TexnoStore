using Microsoft.EntityFrameworkCore;
using TexnoStore.Core.Entities;
using System.Reflection;

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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
