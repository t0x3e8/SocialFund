using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SF.App.Models.Repositories;

namespace SF.App.Controllers {
    public class BaseController : Controller {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IReportRepository ReportRepository { get; set; }
        
        public BaseController(IEmployeeRepository employeeRepository, IReportRepository reportRepository)
        {
            this.EmployeeRepository = employeeRepository;
            this.ReportRepository = reportRepository;
        }

        public virtual string GetUserEmail() {
            var userUpn = this.User.FindFirst(claim => claim.Type == ClaimTypes.Upn);
            var userEmail = (userUpn != null) ? userUpn.Value : "";

            return userEmail;
        }
    }
}