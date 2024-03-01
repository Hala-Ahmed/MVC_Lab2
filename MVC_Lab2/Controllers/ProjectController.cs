using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Lab2.Models;

namespace MVC_Lab2.Controllers
{
    public class ProjectController : Controller
    {
        private BanhaDbContext Db;
        public ProjectController()
        {
            Db = new BanhaDbContext();
        }
        
       
        public IActionResult Index()
        {  
            List<Project> projects = Db.Projects.Include(p=>p.Department).ToList();

            return View(projects);
        }



        public IActionResult Details(int id)
        {
            Project pro =  Db.Projects.Include(p => p.Department).SingleOrDefault( p => p.Pnumber == id) ;
            return View(pro);
        }


        // Create 
        // display form
        public IActionResult GetAddForm()
        {

            List<Department> departments = Db.Departments.ToList();

            ViewData["departments"] = departments;
            return View();
        }



        // get form data
        public IActionResult GetFormData(string name, string location , string city ,int deptId)
        {
            Project project = new()
            {
                Pname=name ,
                Plocation =location,
                City =city,
                Dno = deptId
            };

            Db.Projects.Add(project);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        // Update
        // display form
        public IActionResult GetEditForm(int id)
        {
            Project pro = Db.Projects.SingleOrDefault(p => p.Pnumber == id);

            List<Department> departments = Db.Departments.ToList();

            ViewData["departments"] = departments;
            return View(pro);
        }
        public IActionResult Update(int id, string name, string location, string city, int deptId)
        {

            Project pro = Db.Projects.SingleOrDefault(p => p.Pnumber == id);
            pro.Pname = name;
            pro.Plocation = location;
            pro.City = city;
            pro.Dno = deptId;

            Db.SaveChanges();

            return RedirectToAction("Index");
        }


        // delete
        public IActionResult Delete(int id)
        {
            Project pro = Db.Projects.SingleOrDefault(p => p.Pnumber == id);
            Db.Projects.Remove(pro);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
