using SF.App.Models.Data;

namespace SF.App.Models.Repositories {
    public interface IEmployeeRepository {
        Employee Get(string email);
    }
}