using BlazorQuickGridApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlazorQuickGridApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "John Doe", Age = 20, Grade = "A" },
            new Student { Id = 2, Name = "Jane Smith", Age = 22, Grade = "B" }
        };

        // GET: api/student
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            return Ok(students);
        }
    }
}
