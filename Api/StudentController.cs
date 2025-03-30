// Server/Controllers/StudentController.cs
using BlazorQuickGridApp.Shared.Models; // Use the shared model for StudentViewModel
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlazorQuickGridApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<StudentViewModel> students = new List<StudentViewModel>
        {
            new StudentViewModel { Id = 1, Name = "John Doe", Age = 20, Grade = "A" },
            new StudentViewModel { Id = 2, Name = "Jane Smith", Age = 22, Grade = "B" },
            new StudentViewModel { Id = 3, Name = "James Sally", Age = 20, Grade = "A" },
            new StudentViewModel { Id = 4, Name = "Will Smith", Age = 22, Grade = "B" },
            new StudentViewModel { Id = 5, Name = "John Doe", Age = 20, Grade = "A" },
            new StudentViewModel { Id = 6, Name = "Jane Smith", Age = 22, Grade = "B" },
            new StudentViewModel { Id = 7, Name = "David Clark", Age = 19, Grade = "C" },
            new StudentViewModel { Id = 8, Name = "Grace Walker", Age = 25, Grade = "B" },
            new StudentViewModel { Id = 9, Name = "Sarah Lee", Age = 23, Grade = "A" },
            new StudentViewModel { Id = 10, Name = "Michael Johnson", Age = 21, Grade = "B" }
        };

        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentViewModel student)
        {
            if (student == null)
            {
                return BadRequest("Student data is null");
            }

            student.Id = students.Count > 0 ? students.Max(s => s.Id) + 1 : 1;
            students.Add(student);  // Add to the in-memory list

            return Ok(student);  // Return the added student
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentViewModel>> GetAllStudents()
        {
            return Ok(students);
        }

        // GET: api/student/{id}
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound("Student not found");
            }

            return Ok(student);
        }

        // PUT: api/student/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentViewModel student)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.Name = student.Name;
            existingStudent.Age = student.Age;
            existingStudent.Grade = student.Grade;

            return Ok(existingStudent);
        }

        // DELETE: api/student/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            students.Remove(student);
            return Ok();
        }
    }
}

