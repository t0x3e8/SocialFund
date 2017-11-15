using System.Collections.Generic;
using Code.Models.Data;

namespace Code.Models
{
    public class EmployeesViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
}