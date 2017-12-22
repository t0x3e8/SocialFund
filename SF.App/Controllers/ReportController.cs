using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SF.App.Controllers
{
    public class ReportController : Controller
    {
        [Authorize(Policy="RegisteredAsUser")]
        public IActionResult Index()
        {
            return View();
        }


        [Authorize(Policy="RegisteredAsUser")]
        public IActionResult FamilyIncome()
        {
            return View();
        }
    }
}