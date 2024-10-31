using EagleTask.Models.RepositoriesInterfaces;
using System;

namespace EagleTask.Data.Repositories.RepositoriesInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        void Save();
    }
}
