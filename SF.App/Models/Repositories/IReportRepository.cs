using SF.App.Models.Data;

namespace SF.App.Models.Repositories {
    public interface IReportRepository {
        void Add(string userId, object data, ReportType reportType);
        void Add(Report report);
        Report Get(ReportType reportType, string email);
    }
}