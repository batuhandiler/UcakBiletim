using Microsoft.AspNetCore.Mvc;

namespace UcakBiletim.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
