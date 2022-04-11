using Microsoft.AspNetCore.Mvc;

namespace Amigo.BAU.API.Controllers
{
    public class EngineerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
