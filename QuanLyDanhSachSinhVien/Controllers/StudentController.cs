using Microsoft.AspNetCore.Mvc;
using QuanLyDanhSachSinhVien.Interface;
using QuanLyDanhSachSinhVien.ViewModels;

namespace QuanLyDanhSachSinhVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("GetStudentList")]
        public IActionResult GetStudentList()
        {
            var result = _studentService.GetStudentList();
            if (result == null)
            {
                return NotFound("Not Found!");
            }
            return Ok(result);
        }
        [HttpGet("GetStudentById/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var result = await _studentService.GetStudentById(id);
            if (result == null)
            {
                return NotFound("Not Found!");
            }
            return Ok(result);
        }
        [HttpPost("CreateStudent")]
        public async Task<IActionResult> AddService([FromForm] CreateStudentRequest request)
        {
            var result = await _studentService.CreateStudent(request);
            if (result == null)
            {
                return NotFound("Not Found!");
            }
            return Ok(result);
        }
        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent([FromForm] UpdateStudentRequest request)
        {
            var result = await _studentService.UpdateStudent(request);
            if (result == null)
            {
                return NotFound("Not Found!");
            }
            return Ok(result);
        }
        [HttpDelete("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudent(id);
            if (!result)
            {
                return BadRequest("Delete was unsuccessfully!");
            }
            return Ok(result);
        }
    }
}
