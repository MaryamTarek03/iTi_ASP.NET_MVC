using Microsoft.AspNetCore.Mvc;
using iTi_day_17_lab.Models;

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
            List<Department> departments = context.Departments.ToList();
            return View(departments);
        }
        public IActionResult GetById(int id)
        {
            Department? department = context.Departments.SingleOrDefault(x => x.Id == id);
            return View(department);
        }

        public IActionResult GoToAddForm()
        {
            List<Employee> employees = context.Employees.ToList();
            return View(employees);
        }

        public IActionResult AddData (string name, string ManagerSSN)
        {
            Department department = new Department()
            {
                Name = name,
                ManagerSSN = ManagerSSN,
                ManagerStartDate = DateTime.UtcNow,
            };
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }
    }
}
