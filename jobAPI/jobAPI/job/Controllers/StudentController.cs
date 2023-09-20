using job.DTO;
using job.Models;
using job.Repository;
using Microsoft.AspNetCore.Mvc;

namespace job.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
          IStudentRepository studentRepository;
          
        public StudentController(IStudentRepository _student)
        {
            studentRepository = _student;
        }
        [HttpGet("AllStudents")]
        public IActionResult AllStudents()
        {
            List<StudentDTO> Stds = new List<StudentDTO>();
            List<Profile> students = studentRepository.AllStudents();
            foreach(Profile s in students)
            {
                StudentDTO std = new StudentDTO();
                std.Id = s.Id;
                std.Email = s.AUser.Email;
                std.ForthName = s.ForthName;
                std.NationalID = s.NationalID;
                std.UserName = s.AUser.UserName;
                std.userNumber = s.userNumber;
                Stds.Add(std);
            }
            return Ok(Stds);
        }
        [HttpDelete("DeleteStudent")]
        public IActionResult deleteStudent(string id)
        {
            studentRepository.deleteStudent(id);
            return Ok();
        }
    }
}
