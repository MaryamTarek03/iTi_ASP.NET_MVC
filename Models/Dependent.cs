using System.ComponentModel.DataAnnotations.Schema;

namespace iTi_day_17_lab.Models
{
    public class Dependent
    {
        public string Name { get; set; } = string.Empty;
        public char Gender { get; set; }
        public string Relationship { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        [ForeignKey("Employee")]
        public string EmployeeSSN { get; set; } = string.Empty;
        public virtual Employee? Employee { get; set; }
    }
}
