using iTi_day_17_lab.Interfaces;
using iTi_day_17_lab.Models.FirmDatabase;
using iTi_day_17_lab.Utils;
using iTi_day_17_lab.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace iTi_day_17_lab.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepo _employeeRepo;
        FirmContext _firmContext;

        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
            _firmContext = new FirmContext();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            List<Employee> employees = _employeeRepo.GetEmployeeList();
            return View(employees);
        }
        public IActionResult GetById(string id)
        {
            Employee? employee = _employeeRepo.GetEmployee(id);
            return View(employee);
        }
        public IActionResult AddForm()
        {
            List<Department> departments = _firmContext.Departments.ToList();
            List<Employee> employees = _employeeRepo.GetEmployeeList();
            EmployeeVM employeeVM = new EmployeeVM(departments, employees);
            ViewBag.EmployeeAddVM = employeeVM;
            return View(new Employee());
        }
        public IActionResult EditForm(string id)
        {
            List<Department> departments = _firmContext.Departments.ToList();
            List<Employee> employees = _employeeRepo.GetEmployeeList();
            EmployeeVM employeeVM = new EmployeeVM(departments, employees);
            Employee? employee
                = _employeeRepo.GetEmployee(id);
            ViewBag.EmployeeUpdateVM = employeeVM;
            return View(employee);
        }

        public IActionResult DeleteData(string id)
        {
            Employee? employee = _employeeRepo.GetEmployee(id);
            _employeeRepo.DeleteEmployee(employee);
            return RedirectToAction(ActionNames.GetAll);
        }

        public IActionResult UpdateData(Employee employee)
        {
            //if (ModelState.IsValid)
            //{
                employee.BirthDate = employee.BirthDate.ToUniversalTime();
                _employeeRepo.UpdateEmployee(employee);
                return RedirectToAction(ActionNames.GetAll);
            //}
            //return RedirectToAction(ActionNames.EditForm, new { id = employee.SSN });
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
                _employeeRepo.InsertEmployee(employee);
                return RedirectToAction(ActionNames.GetAll);
            }
            List<Department> departments = _firmContext.Departments.ToList();
            List<Employee> employees = _employeeRepo.GetEmployeeList();
            EmployeeVM employeeVM = new EmployeeVM(departments, employees);
            ViewBag.EmployeeAddVM = employeeVM;
            return View(@ActionNames.AddForm);
        }

        public IActionResult IsSalaryValid(decimal salary)
        {
            if (salary >= 10000 && salary <= 20000) return Json(true);
            return Json(false);
        }
    }
}
