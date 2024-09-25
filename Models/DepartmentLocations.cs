using System.ComponentModel.DataAnnotations.Schema;

namespace iTi_day_17_lab.Models
{
    public class DepartmentLocations
    {
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        public string Location { get; set; } = string.Empty;
    }
}
