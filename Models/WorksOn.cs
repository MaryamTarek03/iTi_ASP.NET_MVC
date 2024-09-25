using System.ComponentModel.DataAnnotations.Schema;

namespace iTi_day_17_lab.Models
{
    public class WorksOn
    {
        [ForeignKey("Employee")]
        public string? EmployeeSSN { get; set; } = string.Empty;
        public virtual Employee? Employee {  get; set; }

        [ForeignKey("Project")]
        public int? ProjectId { get; set; }
        public virtual Project? Project { get; set; }

        public int Hours { get; set; }
    }
}
