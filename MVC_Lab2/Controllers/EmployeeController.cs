using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Lab2.Models;
using MVC_Lab2.ViewModels;
using System.Runtime.Intrinsics.X86;
using static System.Net.Mime.MediaTypeNames;

namespace MVC_Lab2.Controllers
{
    public class EmployeeController : Controller

    {
        private BanhaDbContext Db;
        public EmployeeController()
        {
            Db = new BanhaDbContext();
        }

        public IActionResult Index()
        {
            List<Employee> employees = Db.Employees.ToList();
            List<Department> departments = Db.Departments.ToList();
            return View(employees);
        }

        public IActionResult Emp(int ssn)
        {
            Employee employee = Db.Employees.SingleOrDefault(s => s.SSN == ssn);
            return View(employee);
        }
       
        

        

    }
}
