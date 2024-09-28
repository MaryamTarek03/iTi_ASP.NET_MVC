using Microsoft.AspNetCore.Mvc;
using iTi_day_17_lab.Utils;
using iTi_day_17_lab.ViewModels;
using iTi_day_17_lab.Models.FirmDatabase;

namespace iTi_day_17_lab.Controllers
{
    public class DepartmentController : Controller
    {
        FirmContext context;
        public DepartmentController()
        {
            context = new FirmContext();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            List<Department> departments = context.Departments.OrderBy(d => d.Id).ToList();
            return View(departments);
        }
        public IActionResult GetById(int id)
        {
            Department? department = context.Departments.SingleOrDefault(x => x.Id == id);
            return View(department);
        }

        public IActionResult AddForm()
        {
            List<Employee> employees = context.Employees.ToList();
            return View(employees);
        }

        public IActionResult EditForm(int id)
        {
            Department? department = context.Departments.SingleOrDefault(d => d.Id == id);
            List<Employee> employees = context.Employees.ToList();
            ViewBag.Employees = employees;
            return View(department);
        }

        public IActionResult UpdateData(Department department)
        {
            if (ModelState.IsValid)
            {
                context.Departments.Update(department);
                context.SaveChanges();
                return RedirectToAction(ActionNames.GetAll);
            }
            return RedirectToAction(ActionNames.EditForm, new { id = department.Id });
        }

        public IActionResult DeleteData(int id)
        {
            Department? department
                = context.Departments
                .Where(d => d.Id == id)
                .SingleOrDefault();
            context.Departments.Remove(department);
            context.SaveChanges();
            return RedirectToAction(ActionNames.GetAll);
        }

        public IActionResult SaveData (string name, string ManagerSSN)
        {
            Department department = new Department()
            {
                Name = name,
                ManagerSSN = ManagerSSN,
                ManagerStartDate = DateTime.UtcNow,
            };
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction(ActionNames.GetAll);
        }
    }
}
