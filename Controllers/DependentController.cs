using iTi_day_17_lab.Models;
using iTi_day_17_lab.Utils;
using iTi_day_17_lab.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace iTi_day_17_lab.Controllers
{
    public class DependentController : Controller
    {
        FirmContext context;
        public DependentController ()
        {
            context = new FirmContext ();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            List<Dependent> dependents = context.Dependents.OrderBy(e => e.Name).ToList();
            return View(dependents);
        }
        public IActionResult AddForm()
        {
            List<Employee> employees = context.Employees.ToList();
            ViewBag.Employees = employees;
            return View(employees);
        }
        public IActionResult SaveData(Employee employee)
        {
            if (ModelState.IsValid)
            {
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
