using System.Collections.Generic;
using System.IO;
using SF.App.Models;
using SF.App.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SF.App.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            EmployeesViewModel viewModel = new EmployeesViewModel();
            PopulateViewModel(viewModel);

            return View(viewModel);
        }

        private static void PopulateViewModel(EmployeesViewModel viewModel)
        {
            using (var stream = new FileStream(Path.GetFullPath("data.json"), FileMode.Open))
            {
                using (var rdr = new StreamReader(stream))
                {
                    viewModel.Employees = (IEnumerable<Employee>)JsonConvert.DeserializeObject<IEnumerable<Employee>>(rdr.ReadToEnd());
                }
            }
        }

        public IActionResult Single()
        {
            return View();
        }
    }
}