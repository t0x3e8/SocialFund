using System;
using SF.App.Models.Data;

namespace SF.App.Models.Repositories {
    public sealed class ReportRepository : IReportRepository {
        private IDatabaseContext databaseContext;
        public ReportRepository(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(string userId, object data, ReportType reportType) {
            Report report = new Report();
            report.Type = reportType;
            report.SubmissionDate = DateTime.Now;
            report.RequesterEmail = userId;
            report.Data = data;
            
            switch (report.Type) {
                case ReportType.FamilyIncome :
                    report.Status = ReportStatus.Resolved;
                    break;
                case ReportType.MissingProfileInfo : 
                    report.Status = ReportStatus.New;
                    break;
                default : 
                    break;
            }

            this.Add(report);
        }

        public void Add(Report report) {
            this.databaseContext.Reports.Add(report);
        }

        public Report Get(ReportType reportType, string email) {
            return this.databaseContext.Reports.Find(r => r.RequesterEmail.Equals(email) && r.Type.Equals(reportType));
        }
    }
}