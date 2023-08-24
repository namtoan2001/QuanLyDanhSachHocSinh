namespace QuanLyDanhSachSinhVien.ViewModels
{
    public class CreateStudentRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
