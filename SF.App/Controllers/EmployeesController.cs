using System.Collections.Generic;
using System.IO;
using Code.Models;
using Code.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Code.Controllers {
    
    public class EmployeesController :Controller {
        public IActionResult Index () {
            EmployeesViewModel viewModel = new EmployeesViewModel ();

            using (var stream = new FileStream (Path.GetFullPath ("data.json"), FileMode.Open)) {
                using (var rdr = new StreamReader (stream)) {
                    viewModel.Employees = (IEnumerable<Employee>) JsonConvert.DeserializeObject<IEnumerable<Employee>> (rdr.ReadToEnd ());
                }
            }

            return View(viewModel);
        }

        public IActionResult Single () {
            return View();
        }
    }
}