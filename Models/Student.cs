using System.ComponentModel.DataAnnotations;

namespace databaseAPI.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
