using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Student GetStudentWithDetails(int id);
    }
}