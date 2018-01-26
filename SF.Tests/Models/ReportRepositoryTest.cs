using System;
using System.Collections.Generic;
using Moq;
using SF.App.Models.Data;
using SF.App.Models.Repositories;
using Xunit;

namespace SF.Tests.Models {
    public class ReportRepositoryTest {
        private static List<Report> CreateTestReportList () {
            var reports = new List<Report>();
            reports.Add(new Report {Data = 1, SubmissionDate = new DateTime(2017, 2, 12), RequesterEmail = "aaaa@unittest.com", Status = ReportStatus.Resolved, Type = ReportType.FamilyIncome});
            reports.Add(new Report {Data = 2, SubmissionDate = new DateTime(2017, 3, 21), RequesterEmail = "bbbb@unittest.com", Status = ReportStatus.New, Type = ReportType.FamilyIncome});
            reports.Add(new Report {SubmissionDate = new DateTime(2017, 5, 1), RequesterEmail = "aaaa@unittest.com", Status = ReportStatus.New, Type = ReportType.MissingProfileInfo});
            reports.Add(new Report {Data = 2, SubmissionDate = new DateTime(2017, 6, 2), RequesterEmail = "cccc@unittest.com", Status = ReportStatus.New, Type = ReportType.FamilyIncome});
            reports.Add(new Report {Data = 3, SubmissionDate = new DateTime(2017, 1, 30), RequesterEmail = "dddd@unittest.com", Status = ReportStatus.New, Type = ReportType.FamilyIncome});
            return reports;
        }

        [Fact]
        public void Get_Should_Return_Employee_When_Email_Provided() {
            //Given
            var reportsTestList = CreateTestReportList();
            var mock = new Mock<IDatabaseContext>();
            mock.SetupGet(m => m.Reports).Returns(reportsTestList);
            ReportRepository repo = new ReportRepository(mock.Object);
            //When
            var report = repo.Get(ReportType.FamilyIncome, "aaaa@unittest.com");
            //Then
            Assert.NotNull(report);
            Assert.Same(reportsTestList[0], report); 
        }

        [Fact]
        public void Get_Should_Return_Null_When_Email_Not_Exist() {
            //Given
            var reportsTestList = CreateTestReportList();
            var mock = new Mock<IDatabaseContext>();
            mock.SetupGet(m => m.Reports).Returns(reportsTestList);
            ReportRepository repo = new ReportRepository(mock.Object);
            //When
            var report = repo.Get(ReportType.FamilyIncome, "ffff@unittest.com");
            //Then
            Assert.Null(report);
        }

        [Fact]
        public void Get_Should_Return_Null_When_ReportType_Not_Exist() {
            //Given
            var reportsTestList = CreateTestReportList();
            var mock = new Mock<IDatabaseContext>();
            mock.SetupGet(m => m.Reports).Returns(reportsTestList);
            ReportRepository repo = new ReportRepository(mock.Object);
            //When
            var report = repo.Get(ReportType.MissingProfileInfo, "bbbb@unittest.com");
            //Then
            Assert.Null(report);
        }

        [Fact]
        public void Get_Should_Return_ReportList_When_Email_Provided() {
            //Given
            var reportsTestList = CreateTestReportList();
            var mock = new Mock<IDatabaseContext>();
            mock.SetupGet(m => m.Reports).Returns(reportsTestList);
            ReportRepository repo = new ReportRepository(mock.Object);
            //When
            IEnumerable<Report> reports = repo.GetAll("aaaa@unittest.com");
            //Then
            Assert.NotNull(reports);
            Assert.Equal(2, new List<Report>(reports).Count);
        } 
    }
}