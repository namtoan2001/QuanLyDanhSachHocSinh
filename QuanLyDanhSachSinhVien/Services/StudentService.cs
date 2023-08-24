using QuanLyDanhSachSinhVien.Interface;
using QuanLyDanhSachSinhVien.Models;
using QuanLyDanhSachSinhVien.ViewModels;

namespace QuanLyDanhSachSinhVien.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentContext _studentContext;
        public StudentService(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<bool> CreateStudent(CreateStudentRequest request)
        {
            var data = new Student()
            {
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                BirthDate = request.BirthDate,
            };
            _studentContext.Student.Add(data);
            await _studentContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var data = _studentContext.Student.FirstOrDefault(x => x.Id == id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy sinh viên có ID là " + id);
            }
            _studentContext.Student.Remove(data);
            await _studentContext.SaveChangesAsync();
            return true;
        }

        public async Task<Student> GetStudentById(int id)
        {
            var data = _studentContext.Student.FirstOrDefault(x => x.Id == id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy sinh viên có ID là " + id);
            }
            return new Student
            {
                Id = data.Id,
                FullName = data.FullName,
                Email = data.Email,
                BirthDate = data.BirthDate,
                PhoneNumber = data.PhoneNumber,
            };
        }

        public List<Student> GetStudentList()
        {
            var data = _studentContext.Student.ToList();
            var students = new List<Student>();
            foreach (var item in data)
            {
                students.Add(new Student
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    Email = item.Email,
                    BirthDate = item.BirthDate,
                    PhoneNumber = item.PhoneNumber
                });
            }
            return students;
        }

        public async Task<bool> UpdateStudent(UpdateStudentRequest request)
        {
            var data = _studentContext.Student.FirstOrDefault(x => x.Id == request.Id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy sinh viên có ID là " + request.Id);
            }
            data.FullName = request.FullName ?? data.FullName;
            data.Email = request.Email ?? data.Email;
            data.PhoneNumber = request.PhoneNumber ?? data.PhoneNumber;
            data.BirthDate = request.BirthDate ?? data.BirthDate;

            _studentContext.Student.Update(data);
            await _studentContext.SaveChangesAsync();

            return true;
        }
    }
}
