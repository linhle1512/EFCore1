using Microsoft.EntityFrameworkCore;

namespace EFcore.Models
{
    public class StudentManagementContext : DbContext
    {
        public StudentManagementContext(DbContextOptions<StudentManagementContext> options)
        : base(options)
        {
        }

        public DbSet<Student>? Students { get; set; }
    }
}