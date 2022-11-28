using Microsoft.AspNetCore.Mvc;

namespace ITI.Ecommerce.Presenation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
