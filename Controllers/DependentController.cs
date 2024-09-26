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
            return View();
        }
        public IActionResult SaveData(Dependent dependent)
        {
            if (ModelState.IsValid)
            {
                dependent.BirthDate = dependent.BirthDate.ToUniversalTime();
                context.Dependents.Add(dependent);
                context.SaveChanges();
                return RedirectToAction(ActionNames.GetAll);
            }
            List<Employee> employees = context.Employees.ToList();
            ViewBag.Employees = employees;
            return View(ActionNames.AddForm);
        }
    }
}
