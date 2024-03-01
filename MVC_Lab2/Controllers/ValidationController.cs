using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Lab2.Models;
using MVC_Lab2.ViewModels;

namespace MVC_Lab2.Controllers
{
    public class ValidationController : Controller
    {    BanhaDbContext Db = new BanhaDbContext();
        public IActionResult Index()
        {

            List<Employee> employees = Db.Employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Add()
        {
            EmployeeVM employeeVM = new EmployeeVM()
            {
                departments = new SelectList(Db.Departments, nameof(Department.Dno), nameof(Department.Dname))
            };
            
            return View(employeeVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Add(EmployeeVM emp)
        {
            if(ModelState.IsValid)
            {
                Employee employee = new Employee()
                {
                   SSN = emp.SSN,
                   Fname = emp.Fname,
                   Lname = emp.Lname,
                   Salary = emp.Salary,
                   Address = emp.Address,
                   Password=emp.Password,
                   Dno = emp.Dno,


                };
                Db.Employees.Add(employee);
                Db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }

            //ViewBag.departmnts = new SelectList(Db.Departments, nameof(Department.Dno), nameof(Department.Dname));
            emp.departments= new SelectList(Db.Departments, nameof(Department.Dno), nameof(Department.Dname));
            return View(emp);
        }

    }
}
