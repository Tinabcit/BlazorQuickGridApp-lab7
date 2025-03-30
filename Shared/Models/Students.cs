using System.ComponentModel.DataAnnotations;  // For DataAnnotations

namespace BlazorQuickGridApp.Shared.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        public string Grade { get; set; }
    }
}
