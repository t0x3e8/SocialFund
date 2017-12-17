using System;

namespace SF.App.Models.Data {
    public class Report {
        public string RequesterEmail {get; set;}
        public DateTime SubmissionDate { get; set; }
        public ReportType Type { get; set; }
        public ReportStatus Status { get; set;}

        public Report()
        {
            this.SubmissionDate = DateTime.Now;
            this.Status = ReportStatus.New;
        }
    }

    public enum ReportType : int {
        MissingProfileInfo = 1,
    }

    public enum ReportStatus : int {
        New = 1,
        Resolved = 2,
        Rejected = 3
    }
}