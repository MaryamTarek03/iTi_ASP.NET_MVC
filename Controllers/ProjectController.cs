using iTi_day_17_lab.Models.FirmDatabase;
using iTi_day_17_lab.Utils;
using iTi_day_17_lab.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace iTi_day_17_lab.Controllers
{
    public class ProjectController : Controller
    {
        FirmContext _firmContext;
        public ProjectController ()
        {
            _firmContext = new FirmContext();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            List<Project> projects = _firmContext.Projects.OrderBy(p => p.Id).ToList();
            return View(projects);
        }
        public IActionResult GetById(int id)
        {
            Project? projects
                = _firmContext.Projects
                .Where(e => e.Id == id)
                .First();
            return View(projects);
        }
        public IActionResult DeleteData(int id)
        {
            Project? project
                = _firmContext.Projects
                .Where(p => p.Id == id)
                .SingleOrDefault();
            _firmContext.Projects.Remove(project);
            _firmContext.SaveChanges();
            return RedirectToAction(ActionNames.GetAll);
        }

        public IActionResult EditForm(int id)
        {
            Project project = _firmContext.Projects.Single(p => p.Id == id);
            List<Department>? departments = _firmContext.Departments.ToList();
            ViewBag.Departments = departments;
            return View(project);
        }

        public IActionResult UpdateData(Project project)
        {
            if (ModelState.IsValid)
            {
                _firmContext.Projects.Update(project);
                _firmContext.SaveChanges();
                return RedirectToAction(ActionNames.GetAll);
            }
            return RedirectToAction(ActionNames.EditForm, new { id = project.Id });
        }
    }
}
