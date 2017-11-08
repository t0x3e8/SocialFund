using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;
using Code.Models;
using Code.Models.Data;

namespace Code.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();

            using (var stream = new FileStream(Path.GetFullPath("data.json"), FileMode.Open))
            {
                using (var rdr = new StreamReader(stream))
                {
                    viewModel.Employees = (IEnumerable<Employee>)JsonConvert.DeserializeObject<IEnumerable<Employee>>(rdr.ReadToEnd());
                }
            }

            return View(viewModel);
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
