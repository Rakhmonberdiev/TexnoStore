using Microsoft.EntityFrameworkCore;
using TexnoStore.Core.Entities;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TexnoStore.Infrastructure.Data
{
    public class TexnoStoreContext : IdentityDbContext<AppUser>
    {
        public TexnoStoreContext(DbContextOptions<TexnoStoreContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Address> Addresss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
