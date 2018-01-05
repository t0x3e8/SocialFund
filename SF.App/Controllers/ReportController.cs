using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.App.Models.ViewModels;

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
            var vm = new ReportFamilyIncomeViewModel();
            return View(vm);
        }

        [Authorize(Policy="RegisteredAsUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FamilyIncome(ReportFamilyIncomeViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}