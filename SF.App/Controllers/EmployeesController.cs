using System.Collections.Generic;
using System.IO;
using SF.App.Models;
using SF.App.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SF.App.Models.Repositories;
using AutoMapper;

namespace SF.App.Controllers
{
    public class EmployeesController : BaseController
    {
        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
            : base(employeeRepository, null, mapper)            
        {
            
        }

        public IActionResult Index()
        {
            EmployeesViewModel viewModel = new EmployeesViewModel();
            viewModel.Employees = this.EmployeeRepository.GetAll();

            return View(viewModel);
        }

        public IActionResult Single()
        {
            return View();
        }
    }
}