using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Lab2.Models;

namespace MVC_Lab2.Controllers
{
    public class WorksForController : Controller
    {
        BanhaDbContext Db = new BanhaDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Getall()
        {
            List<WorksFor> worksFors = Db.WorksFor.Include(w => w.Project).Include(w => w.Employee).ToList();
            return View(worksFors);
        }
    }
}
