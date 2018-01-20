using System;
using SF.App.Models.Data;

namespace SF.App.Models.Repositories {
    public sealed class EmployeeRepository : IEmployeeRepository {
        private IDatabaseContext databaseContext;
        public EmployeeRepository(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Employee Get(string email)
        {
            return this.databaseContext.Employees.Find(emp => emp.Email.Equals(email));
        }
    }
}