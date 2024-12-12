using Microsoft.AspNetCore.Mvc;

namespace EcartCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
