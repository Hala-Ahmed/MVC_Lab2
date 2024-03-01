using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Lab2.Models;
using System;

namespace MVC_Lab2.Controllers
{
    public class EmployeeProjectController : Controller
    {
        BanhaDbContext db = new BanhaDbContext();


      
        public IActionResult Index()
        {
            var EmployeeProject = db.WorksFor.Include(x => x.Employee).Include(x => x.Project).ToList();
            foreach (var item in EmployeeProject)
            {
                ViewData[$"color_{item.ESSN}_{item.Pno}"] = item.Hours < 50 ? "red" : "blue";
            }
            return View(EmployeeProject);
        }

        public IActionResult GetProjectsForEmployee()
        {
            var Employees = db.Employees.ToList();
            return View(Employees);
        }


        public IActionResult ProjectsForEmployee(int id)
        {
            var Projects = db.WorksFor.Include(x => x.Employee).Include(x => x.Project).Where(x => x.ESSN == id).Select(x => new { x.Project.Pnumber, x.Project.Pname, x.Hours }).ToList();

            //  return View(Projects);
            return Json(Projects);
        }
        [HttpPost]
        public IActionResult EditHour(int eId, int pId, int hour)
        {
            var worksOn = db.WorksFor.FirstOrDefault(x => x.ESSN == eId && x.Pno== pId);
            if (worksOn == null)
            {
                var Employees = db.Employees.ToList();
                return View("GetProjectsForEmployee", Employees);
            }
            else
            {
                worksOn.Hours = hour;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


        }

    }
}