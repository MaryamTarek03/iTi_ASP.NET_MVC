using iTi_day_17_lab.Models;
using iTi_day_17_lab.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace iTi_day_17_lab.Controllers
{
    public class EmployeeController : Controller
    {
        FirmContext context;
        public EmployeeController()
        {
            context = new FirmContext();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            List<Employee> employees = context.Employees.OrderBy(e => e.FirstName).ToList();
            return View(employees);
        }
        public IActionResult GetBySSN(string id)
        {
            Employee? employee 
                = context.Employees
                .Where(e => e.SSN == id)
                .First();
            return View(employee);
        }
        public IActionResult GoToAddForm()
        {
            List<Department> departments = context.Departments.ToList();
            List<Employee> employees = context.Employees.ToList();
            EmployeeVM employeeVM = new EmployeeVM(departments, employees);
            return View(employeeVM);
        }

        public IActionResult AddData(
            string ssn, 
            string firstName, 
            string MINIT, 
            string lastName, 
            string address, 
            decimal salary, 
            DateTime birthDate, 
            string supervisorSSN, 
            char gender,
            int departmentId)
        {
            DateTime utcBirthDate = birthDate.ToUniversalTime();
            Employee employee = new Employee()
            {
                SSN = ssn,
                FirstName = firstName,
                MINIT = MINIT,
                LastName = lastName,
                Address = address,
                Salary = salary,
                Gender = gender,
                BirthDate = utcBirthDate,
                SupervisorSSN = supervisorSSN,
                DepartmentId = departmentId
            };
            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }
    }
}
