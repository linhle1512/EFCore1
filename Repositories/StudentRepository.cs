using EFcore.Models;

namespace EFcore.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentManagementContext context) : base(context)
        {
        }
    }
}