using EagleTask.Models.RepositoriesInterfaces;
using EagleTask.Models.Specifications;
using Microsoft.EntityFrameworkCore;

namespace EagleTask.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OrderManagementDbContext _db;
        private DbSet<T> _dbSet;

        public Repository(OrderManagementDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbSet.AsNoTracking().AsQueryable(), specification);
        }
    }
}
