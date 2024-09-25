using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTi_day_17_lab.Models
{
    public class Employee
    {
        [Key]
        public string SSN { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address {  get; set; } = string.Empty;
        public char Gender {  get; set; }
        public string? MINIT { get; set; } = string.Empty;
        public decimal Salary { get; set; }
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
