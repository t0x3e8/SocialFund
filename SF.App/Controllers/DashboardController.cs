using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.App.Models.ViewModels;

namespace SF.App.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize]
        public ViewResult Index()
        {
            DashboardIndexViewModel viewModel = new DashboardIndexViewModel()
            {
                EmployeeId = "MP1234",
                Name = "Jan",
                Surname = "Nowak",
                Email = User.Identity.Name
            };

            return View(viewModel);
        }
    }
}