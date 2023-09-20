using job.DTO;
using job.Models;
using job.Repository;
using Microsoft.AspNetCore.Mvc;

namespace job.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        ITeacherDataRepository teacherRepository;
        
        public TeacherController(ITeacherDataRepository _teacher)
        {
            teacherRepository = _teacher;
        }
        [HttpGet("AllTeachers")]
        public IActionResult AllTeachers()
        {
            List<Profile> teachers = teacherRepository.AllTeachers();
            return Ok(teachers);
        }
        [HttpDelete("DeleteTeacher")]
        public IActionResult deleteTeacher(string id)
        {
            teacherRepository.deleteTeacher(id);
            return Ok();
        }
    }
}
