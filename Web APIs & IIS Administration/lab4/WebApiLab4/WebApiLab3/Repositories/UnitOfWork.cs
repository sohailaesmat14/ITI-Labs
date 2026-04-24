using System.Threading.Tasks;
using WebApiLab3.Models;

namespace WebApiLab3.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ItiContext _context;

        public IGenericRepository<Student> Students { get; private set; }
        public IGenericRepository<Department> Departments { get; private set; }

        public UnitOfWork(ItiContext context)
        {
            _context = context;

            Students = new GenericRepository<Student>(_context);
            Departments = new GenericRepository<Department>(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}