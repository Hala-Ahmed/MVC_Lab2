using Microsoft.AspNetCore.Mvc;
using MVC_Lab2.Models;

namespace MVC_Lab2.Controllers
{
    public class AccountController : Controller
    {
        BanhaDbContext Db = new();
        public IActionResult login()
        {
            return View();

        }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }



        public IActionResult LoginDB(string name, string password)
        {

            Employee employee = Db.Employees.SingleOrDefault(e => e.Fname == name && e.SSN == int.Parse(password));
            if (employee != null)
            {
                HttpContext.Session.SetString("name", employee.Fname);
                HttpContext.Session.SetInt32("password", employee.SSN);

                return RedirectToAction("Index", "Employee");


            }
            return View("login");

        }
    }
}
