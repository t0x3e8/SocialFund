using System.Collections.Generic;

namespace SF.App.Models.Data {
    public interface IDatabaseContext
    {
        List<Employee> Employees { get; }
        List<Report> Reports { get; }
    }
}