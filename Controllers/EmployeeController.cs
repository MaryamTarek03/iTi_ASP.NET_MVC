using iTi_day_17_lab.Models;
using iTi_day_17_lab.Utils;
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
        public IActionResult GetById(string id)
        {
            Employee? employee 
                = context.Employees
                .Where(e => e.SSN == id)
                .SingleOrDefault();
            return View(employee);
        }
        public IActionResult AddForm()
        {
            List<Department> departments = context.Departments.ToList();
            List<Employee> employees = context.Employees.ToList();
            EmployeeVM employeeVM = new EmployeeVM(departments, employees);
            ViewBag.EmployeeAddVM = employeeVM;
            return View(new Employee());
        }
        public IActionResult EditForm(string id)
        {
            List<Department> departments = context.Departments.ToList();
            List<Employee> employees = context.Employees.ToList();
            EmployeeVM employeeVM = new EmployeeVM(departments, employees);
            Employee? employee
                = context.Employees
                .SingleOrDefault(e => e.SSN == id);
            ViewBag.EmployeeUpdateVM = employeeVM;
            return View(employee);
        }

        public IActionResult DeleteData(string id)
        {
            Employee? employee 
                = context.Employees
                .Where(e => e.SSN == id)
                .SingleOrDefault();
            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction(ActionNames.GetAll);
        }

        public IActionResult UpdateData(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.BirthDate = employee.BirthDate.ToUniversalTime();
                context.Employees.Update(employee);
                context.SaveChanges();
                return RedirectToAction(ActionNames.GetAll);
            }
            return RedirectToAction(ActionNames.EditForm, new { id = employee.SSN });
            //List<Department> departments = context.Departments.ToList();
            //List<Employee> employees = context.Employees.ToList();
            //EmployeeVM employeeVM = new EmployeeVM(departments, employees);
            //ViewBag.EmployeeUpdateVM = employeeVM;
            //return View(@ActionNames.EditForm, new {id = employee.SSN});
        }

        public IActionResult SaveData(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.BirthDate = employee.BirthDate.ToUniversalTime();
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction(ActionNames.GetAll);
            }
            List<Department> departments = context.Departments.ToList();
            List<Employee> employees = context.Employees.ToList();
            EmployeeVM employeeVM = new EmployeeVM(departments, employees);
            ViewBag.EmployeeAddVM = employeeVM;
            return View(@ActionNames.AddForm);
        }
    }
}
