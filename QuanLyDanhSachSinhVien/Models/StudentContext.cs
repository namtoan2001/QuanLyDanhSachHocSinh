using Microsoft.EntityFrameworkCore;

namespace QuanLyDanhSachSinhVien.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext()
        {

        }
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Student> Student { get; set; } = null!;
    }
}
