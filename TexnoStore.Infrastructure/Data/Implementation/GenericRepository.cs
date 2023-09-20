using Microsoft.EntityFrameworkCore;
using TexnoStore.Core.Entities;
using TexnoStore.Core.Interfaces;

namespace TexnoStore.Infrastructure.Data.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly TexnoStoreContext _context;
        public GenericRepository(TexnoStoreContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
           return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
