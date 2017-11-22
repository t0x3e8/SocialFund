using System.Collections.Generic;
using SF.App.Models.Data;

namespace SF.App.Models
{
    public class EmployeesViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
}