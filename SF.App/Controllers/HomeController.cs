using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.App.Models;
using SF.App.Models.ViewModels;
using System.Collections.Generic;
using SF.App.Models.Data;
using System;

namespace SF.App.Controllers
{
    public class HomeController : Controller
    {
        private SocialFundDBContext dBContext;

        public HomeController(SocialFundDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userUpn = this.User.FindFirst(claim => claim.Type == ClaimTypes.Upn);
            var userEmail = (userUpn != null) ? userUpn.Value : "";
            HomeIndexViewModel viewModel = new HomeIndexViewModel { IsModelEmpty = true};

            if (!string.IsNullOrEmpty(userEmail)) {
                var employee = this.dBContext.Employees.Find(e => e.Email == userEmail);
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
        public IActionResult Index(HomeIndexViewModel viewModel) {
            var employee = this.dBContext.Employees.Find(emp => emp.Email == viewModel.Email);
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
        public IActionResult ReportNoRecord() {
            var userUpn = this.User.FindFirst(claim => claim.Type == ClaimTypes.Upn);
            var userEmail = (userUpn != null) ? userUpn.Value : "";

            if (!string.IsNullOrEmpty(userEmail)) {
                var report = this.dBContext.Reports.Find(r => r.RequesterEmail == userEmail && r.Type == ReportType.MissingProfileInfo);
                if(report == null) {
                    report = new Report{
                        RequesterEmail = userEmail,
                        Type = ReportType.MissingProfileInfo
                    };

                    this.dBContext.Reports.Add(report);
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
