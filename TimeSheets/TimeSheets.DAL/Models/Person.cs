using System.ComponentModel.DataAnnotations;
namespace TimeSheets.DAL.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }
        public bool IsDelete { get; set; }
    }
}
