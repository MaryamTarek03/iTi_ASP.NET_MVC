using System.ComponentModel.DataAnnotations.Schema;

namespace iTi_day_17_lab.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? ManagerStartDate { get; set; }

        [ForeignKey("Manager")]
        public string? ManagerSSN { get; set; } = string.Empty;
        public virtual Employee? Manager { get; set; }

        public virtual List<DepartmentLocations>? DepartmentLocations { get; set; }

        [InverseProperty("Department")]
        public virtual List<Employee>? Employees { get; set; }
        public virtual List<Project>? Projects { get; set; }
    }
}
