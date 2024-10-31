
using EagleTask.Models.Specifications;

namespace EagleTask.Models.RepositoriesInterfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T> specification);
        Task<T> GetByIdAsync(int id);
    }
}
