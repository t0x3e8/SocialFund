using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.App.Models;
using SF.App.Models.ViewModels;

namespace SF.App.Controllers {
    public class DashboardController : Controller {
        [Authorize(Policy="RegisteredAsUser")]
        public ViewResult Index() {

            return View();
        }

        
        [Authorize(Policy="RegisteredAsAdmin")]
        public ViewResult Admin() {
            return View();
        }
    }
}