using Microsoft.AspNetCore.Mvc;

namespace MVC_Lab2.Controllers
{
    public class ClientSideController : Controller
    {
        public IActionResult Address(string Address)
        {
            if (Address == "Cairo" || Address == "Alex" || Address == "Giza")
            {
                return Json(true);


            }
            else
            {
                return Json(false);

            }
        }
    }
}
