using System;
using System.Threading.Tasks;
using WebApiLab3.Models;

namespace WebApiLab3.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Student> Students { get; }
        IGenericRepository<Department> Departments { get; }
        Task<int> SaveAsync();
    }
}