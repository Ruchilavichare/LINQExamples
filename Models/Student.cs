using System.ComponentModel.DataAnnotations;
namespace LinqDemoApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        [Required]
        public string Course { get; set; }

        public double Grade { get; set; }
    }
}
