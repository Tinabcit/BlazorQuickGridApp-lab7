using BlazorQuickGridApp.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorQuickGridApp.Server.Services
{
    public class StudentService : IStudentService
    {
        private static List<StudentViewModel> students = new List<StudentViewModel>
        {
            new StudentViewModel { Id = 1, Name = "John Doe", Age = 20, Grade = "A" },
            new StudentViewModel { Id = 2, Name = "Jane Smith", Age = 22, Grade = "B" }
        };

        public Task<IEnumerable<StudentViewModel>> GetAllStudentsAsync() =>
            Task.FromResult<IEnumerable<StudentViewModel>>(students);

        public Task<StudentViewModel> GetStudentByIdAsync(int id) =>
            Task.FromResult(students.FirstOrDefault(s => s.Id == id));

        public Task AddStudentAsync(StudentViewModel student)
        {
            student.Id = students.Max(s => s.Id) + 1;  // Auto-generate the ID
            students.Add(student);  // Add to the in-memory list
            return Task.CompletedTask;
        }

        public Task UpdateStudentAsync(StudentViewModel student)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Age = student.Age;
                existingStudent.Grade = student.Grade;
            }
            return Task.CompletedTask;
        }

        public Task DeleteStudentAsync(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
            return Task.CompletedTask;
        }
    }
}
