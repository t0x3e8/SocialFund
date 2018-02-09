using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.App.Models.Repositories;
using SF.App.Models.ViewModels;
using SF.App.Resources;
using SF.App.Models.Data;
using AutoMapper;

namespace SF.App.Controllers
{
    public class ReportController : BaseController
    {
        public ReportController(IReportRepository reportRepository, IMapper mapper) : base(null, reportRepository, mapper)
        {
        }

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
            if (viewModel.SelectedIncomeLevel == IncomeLevelType.BelowThen2000 || 
                viewModel.SelectedIncomeLevel == IncomeLevelType.Between3500And2000 || 
                viewModel.SelectedIncomeLevel == IncomeLevelType.AboveThen3500) {
                    viewModel.ValidationErrorMessage = null;
                    viewModel.IsSuccess = true;

                    this.ReportRepository.Add(
                            userId: this.GetUserEmail(), 
                            data: viewModel.SelectedIncomeLevel, 
                            reportType: ReportType.FamilyIncome);

                    return RedirectToAction("Success");
            } else {
                viewModel.ValidationErrorMessage = SharedStrings.MissingIncomeLevelValidationError;
            }
            
            return View(viewModel);
        }

        [Authorize(Policy="RegisteredAsUser")]
        public IActionResult Success()
        {
            return View();
        }
    }
}