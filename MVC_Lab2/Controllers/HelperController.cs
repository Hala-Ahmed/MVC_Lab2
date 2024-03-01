using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Lab2.Models;

namespace MVC_Lab2.Controllers
{
    public class HelperController : Controller
    {         BanhaDbContext Db = new BanhaDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            ViewBag.employees = Db.Employees.Except(Db.Departments.Include(i => i.Manger).Select(d => d.Manger));

            //ViewBag.employees=Db.Employees.ToList();
            return View();
        }
        public IActionResult AddDB(Department department)
        {
            if (department.Dname != null)
            {
                Db.Departments.Add(department);
                Db.SaveChanges();
                return RedirectToAction("Index", "department");
            }
            else
            {
                ViewBag.employees = Db.Employees.Except(Db.Departments.Include(i=>i.Manger).Select(d => d.Manger));
                return View("Edit");

            }
        }

        public IActionResult Edit(int Id)
        { 
            Department department=Db.Departments.SingleOrDefault(d=>d.Dno==Id);
            ViewBag.employees = Db.Employees.ToList();
            return View(department); 
        }

        public IActionResult EditDB(Department department)
        {
            if (department.Dname != null)
            {
                Db.Departments.Update(department);
                Db.SaveChanges();
                return RedirectToAction("Index", "department");
            }
            else
            {
                ViewBag.employees = Db.Employees.ToList();
                return View("Edit");

            }
        }

    }
}
