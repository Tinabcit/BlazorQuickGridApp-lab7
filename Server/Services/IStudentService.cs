using BlazorQuickGridApp.Shared.Models;  // Ensure this is correct for your StudentViewModel
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorQuickGridApp.Server.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentViewModel>> GetAllStudentsAsync();
        Task<StudentViewModel> GetStudentByIdAsync(int id);
        Task AddStudentAsync(StudentViewModel student);
        Task UpdateStudentAsync(StudentViewModel student);
        Task DeleteStudentAsync(int id);
    }
}
