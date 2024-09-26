using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTi_day_17_lab.Models
{
    public class Employee
    {
        [Key]
        public string SSN { get; set; } = string.Empty;

        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [MaxLength(20, ErrorMessage = "Name must be at most 10 characters")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [MaxLength(20, ErrorMessage = "Name must be at most 10 characters")]
        public string LastName { get; set; } = string.Empty;
        public string Address {  get; set; } = string.Empty;
        public char Gender {  get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Middle initial must be 1 character only")]
        [MaxLength(1, ErrorMessage = "Middle initial must be 1 character only")]
        public string? MINIT { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is required")]
        public decimal Salary { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public DateTime BirthDate { get; set; }

        [ForeignKey("Supervisor")]
        public string? SupervisorSSN { get; set; } = string.Empty;
        public virtual Employee? Supervisor {  get; set; }

        [InverseProperty("Supervisor")]
        public virtual List<Employee>? Supervisee { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        public virtual List<WorksOn>? WorksOns { get; set; }
        public virtual List<Dependent>? Dependents { get; set; }
    }
}
