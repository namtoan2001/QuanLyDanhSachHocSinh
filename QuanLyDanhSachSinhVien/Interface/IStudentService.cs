using QuanLyDanhSachSinhVien.Models;
using QuanLyDanhSachSinhVien.ViewModels;
namespace QuanLyDanhSachSinhVien.Interface
{
    public interface IStudentService
    {
        public List<Student> GetStudentList();
        public Task<Student> GetStudentById(int id);
        public Task<bool> CreateStudent(CreateStudentRequest request);
        public Task<bool> UpdateStudent(UpdateStudentRequest request);
        public Task<bool> DeleteStudent(int id);
    }
}
