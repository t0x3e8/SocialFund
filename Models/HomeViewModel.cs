using System.Collections.Generic;
using Code.Models.Data;

namespace Code.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
}