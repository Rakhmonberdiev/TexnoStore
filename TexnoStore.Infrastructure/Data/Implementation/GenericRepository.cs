using Microsoft.EntityFrameworkCore;
using TexnoStore.Core.Entities;
using TexnoStore.Core.Interfaces;
using TexnoStore.Core.Specifications;

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
        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpec(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpec(spec).ToListAsync();
        }


        private IQueryable<T> ApplySpec(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpec(spec).CountAsync();
        }
    }
}
