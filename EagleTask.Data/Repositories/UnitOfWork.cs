
using EagleTask.Data.Repositories.RepositoriesInterfaces;
using EagleTask.Models.RepositoriesInterfaces;
using System.Collections;

namespace EagleTask.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderManagementDbContext _context;
        private Hashtable _repositories;

        public UnitOfWork(OrderManagementDbContext context)
        {
            _context = context;
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repoType = typeof(Repository<>);
                var repoInstance =
                    Activator
                    .CreateInstance(repoType.MakeGenericType(typeof(T)), _context);
                
                _repositories.Add(type, repoInstance);
            }

            return (IRepository<T>) _repositories[type];
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
