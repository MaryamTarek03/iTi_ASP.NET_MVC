using iTi_day_17_lab.Interfaces;
using iTi_day_17_lab.Models.FirmDatabase;

namespace iTi_day_17_lab.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        FirmContext _context;
        public EmployeeRepo() => _context = new FirmContext();
        public Employee? GetEmployee(string ssn)
        {
            Employee? employee = _context.Employees.SingleOrDefault(e => e.SSN == ssn);
            return employee;
        }
        public Employee? GetEmployeeByFirstName(string name)
        {
            Employee? employee = _context.Employees.SingleOrDefault(e => e.FirstName == name);
            return employee;
        }
        public Employee? GetEmployeeByLastName(string name)
        {
            Employee? employee = _context.Employees.SingleOrDefault(e => e.LastName == name);
            return employee;
        }

        public List<Employee> GetEmployeeList()
        {
            List<Employee>? employees = [.. _context.Employees];
            return employees;
        }

        public void InsertEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}
