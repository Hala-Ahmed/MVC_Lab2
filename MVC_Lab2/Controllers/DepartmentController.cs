using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Lab2.Models;

namespace MVC_Lab2.Controllers
{
    public class DepartmentController : Controller
    {
        private BanhaDbContext Db;
        public DepartmentController()
        {
            Db = new BanhaDbContext();
        }
        public IActionResult Index()
        {
            List<Department> departments = Db.Departments.Include(e => e.Employees).ToList();

            return View(departments);

        }







        public IActionResult Details(int id)
        {
            Department department = Db.Departments.Include(e => e.Manger).SingleOrDefault(e => e.Dno == id);
            return View(department);
        }



        public IActionResult GetAddForm()
        {
            List<Employee> employees = Db.Employees.ToList();

            ViewData["employees"] = employees;
            return View();
        }

        // get form data
        public IActionResult GetFormData(string name, DateTime mgrStartDate, int MSSN)
        {
            Department Department = new()
            {
                Dname = name,
                MGRStartDate = mgrStartDate,
                MGRSSN = MSSN
            };

            Db.Departments.Add(Department);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }


        // Update
        // display form
        public IActionResult GetEditForm(int id)
        {
            Department Department = Db.Departments.SingleOrDefault(p => p.Dno == id);

            List<Employee> Employees = Db.Employees.ToList();

            ViewData["Employees"] = Employees;
            return View(Department);
        }
        public IActionResult Update(int id, string name, DateTime mgrStartDate, int MSSN)
        {

            Department Department = Db.Departments.SingleOrDefault(p => p.Dno == id);
            {
                Department.Dname = name;
                Department.MGRStartDate = mgrStartDate;
                Department.MGRSSN = MSSN;
                Db.SaveChanges();

                return RedirectToAction("Index");
            };


        }




        // delete
        public IActionResult Delete(int id)
        { 
            Department department=Db.Departments.SingleOrDefault(d=>d.Dno==id);
            Db.Departments.Remove(department);
            Db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
    }



