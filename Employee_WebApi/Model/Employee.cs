using System.ComponentModel.DataAnnotations;

namespace Employee_WebApi.Model
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Name is Required Field")]
        [StringLength(50,ErrorMessage ="Employee Name Should Not Exceed 50 charecters")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Email is Required Feild")]
        [StringLength(50, ErrorMessage = "Invalid Format")]
        [EmailAddress]
        public string Email { get; set; }


    }
}
