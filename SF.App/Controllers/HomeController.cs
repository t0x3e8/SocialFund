using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.App.Models;
using SF.App.Models.ViewModels;
using System.Collections.Generic;
using SF.App.Models.Data;
using System;
using SF.App.Models.Repositories;

namespace SF.App.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IEmployeeRepository employeeRepository, IReportRepository reportRepository)
            : base(employeeRepository, reportRepository, null)
        {
        }

        [Authorize]
        public IActionResult Index()
        {
            var userEmail = this.GetUserEmail();
            HomeIndexViewModel viewModel = new HomeIndexViewModel { IsModelEmpty = true};

            if (!string.IsNullOrEmpty(userEmail)) {
                var employee = this.EmployeeRepository.Get(userEmail);
                if (employee != null) {
                    viewModel = new HomeIndexViewModel() {
                        EmployeeId = employee.ID,
                        Name = employee.Name,
                        Surname = employee.Surname,
                        Department = employee.Department,
                        DirectManager = employee.Manager,
                        HiredDate = employee.HiredDate.ToShortDateString(),
                        Email = employee.Email,
                        IsModelEmpty = false
                    };
                }
            }

            if (viewModel.IsModelEmpty) 
                return RedirectToAction("NoRecord");

            return View(viewModel);
        }
        
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Index(HomeIndexViewModel viewModel) {
            var employee = this.EmployeeRepository.Get(viewModel.Email);
            if (employee.Name != viewModel.Name)
                employee.Name = viewModel.Name;
            if (employee.Surname != viewModel.Surname)
                employee.Surname = viewModel.Surname;
            if (employee.Department != viewModel.Department)
                employee.Department = viewModel.Department;
            if (employee.Manager != viewModel.DirectManager)
                employee.Manager = viewModel.DirectManager;

            return View(viewModel);
        }

        [Authorize]
        public IActionResult NoRecord() {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult ReportNoRecord() {
            var userEmail = this.GetUserEmail();
            
            if (!string.IsNullOrEmpty(userEmail)) {
                var report = this.ReportRepository.Get(ReportType.MissingProfileInfo, userEmail);
                if(report == null) {
                    report = new Report{
                        RequesterEmail = userEmail,
                        Type = ReportType.MissingProfileInfo
                    };

                    this.ReportRepository.Add(report);
                }
                else {
                    report.SubmissionDate = DateTime.Now;
                }
            }

            return Redirect("NoRecord");
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
