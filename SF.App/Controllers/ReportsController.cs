using Microsoft.AspNetCore.Mvc;

namespace SF.App.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}