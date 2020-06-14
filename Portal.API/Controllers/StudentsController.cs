using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.API.Data;

namespace Portal.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IPortalRepository _repo;
        public StudentsController(IPortalRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _repo.GetStudents();

            return Ok(students);
        }

        [AllowAnonymous]
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudent(string studentId)
        {
            var student = await _repo.GetStudent(studentId);

            return Ok(student);
        }
    }
}