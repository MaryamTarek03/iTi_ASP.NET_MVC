using iTi_day_17_lab.Models;

namespace iTi_day_17_lab.ViewModels
{
    public class EmployeeVM
    {
        public List<Department> Departments {  get; set; }
        public List<Employee> Supervisors { get; set; }
        public EmployeeVM(List<Department> departments, List<Employee> supervisors) 
        {
            Departments = departments;
            Supervisors = supervisors;
        }
    }
}
