using iTi_day_17_lab.Models.FirmDatabase;

namespace iTi_day_17_lab.Interfaces
{
    public interface IEmployeeRepo
    {
        List<Employee> GetEmployeeList();
        Employee? GetEmployee(string ssn);
        Employee? GetEmployeeByFirstName(string name);
        Employee? GetEmployeeByLastName(string name);

        void DeleteEmployee(Employee employee);
        void InsertEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
    }
}
