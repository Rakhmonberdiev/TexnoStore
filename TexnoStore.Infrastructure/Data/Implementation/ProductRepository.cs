using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.Entities;
using TexnoStore.Core.Interfaces;

namespace TexnoStore.Infrastructure.Data.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly TexnoStoreContext _context;
        public ProductRepository(TexnoStoreContext context)
        {
            _context = context;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
