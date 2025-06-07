using System.Linq.Expressions;
using KnowledgeCheck.DAL.Data;
using KnowledgeCheck.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace KnowledgeCheck.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly KnowledgeCheckDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(KnowledgeCheckDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync([id], cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync(cancellationToken);
        }

        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }

        public void Update(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entity);
        }
    }
}
