using Microsoft.EntityFrameworkCore;
using CSharp_Student_Management_API.Models;

namespace CSharp_Student_Management_API.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}