using Microsoft.AspNetCore.Mvc;

namespace PlayerCatalog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(nameof(Index));
        }
    }
}
