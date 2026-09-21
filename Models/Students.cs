using System.ComponentModel.DataAnnotations;

namespace CSharp_Student_Management_API.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Range(5, 100)]
        public int Age { get; set; }

        [Required]
        [StringLength(100)]
        public string Course { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}