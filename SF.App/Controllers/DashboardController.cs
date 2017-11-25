using Microsoft.AspNetCore.Mvc;
using SF.App.Models;

namespace SF.App.Controllers {
    public class DashboardController : Controller {

        public ViewResult Index() {

            DashboardIndexViewModel viewModel = new DashboardIndexViewModel() { 
                EmployeeId = "MP1234",
                Name = "Jan",
                Surname = "Nowak"
            };

            return View(viewModel);
        }
    }
}