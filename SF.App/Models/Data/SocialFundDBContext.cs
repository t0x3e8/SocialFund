using System;
using System.Collections.Generic;
using SF.App.Models.Data;

namespace SF.App.Models.Data {
    public class SocialFundDBContext : IDatabaseContext{
    
        public List<Employee> Employees { get; private set;}
        public List<Report> Reports { get; private set;}
        public SocialFundDBContext()
        {
            this.InitializeEmployees();
            this.InitializeReports();
        }

        private void InitializeReports()
        {
            this.Reports = new List<Report>();
            this.Reports.Add(new Report {ID = "1", RequesterEmail = "jaju@dgs.com", SubmissionDate = new DateTime(2017, 10, 5), Type = ReportType.FamilyIncome, Status = ReportStatus.New, Data = 2 });
            this.Reports.Add(new Report {ID = "2", RequesterEmail = "jaju@dgs.com", SubmissionDate = new DateTime(2017, 10, 15), Type = ReportType.MissingProfileInfo, Status = ReportStatus.Resolved});
        }

        private void InitializeEmployees()
        {
            this.Employees = new List<Employee>();
            this.Employees.Add(new Employee {ID = "ID1234", Email="jaju@dgs.com", Name= "Jarek", Surname="Jurczyk", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 1, 1) , RoleName = "Admin" });
            this.Employees.Add(new Employee {ID = "ID1235", Email="pwso@dgs.com", Name= "Paweł", Surname="Synsołtysa", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 12, 1), RoleName = "Admin"});
            this.Employees.Add(new Employee {ID = "ID1236", Email="qaju@dgs.com", Name= "Agata", Surname="Ataga", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 3, 1) });
            this.Employees.Add(new Employee {ID = "ID1237", Email="waju@dgs.com", Name= "Alex", Surname="Reks", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 4, 1) });
            this.Employees.Add(new Employee {ID = "ID1238", Email="eaju@dgs.com", Name= "Amanta", Surname="Młoda", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 5, 1) });
            this.Employees.Add(new Employee {ID = "ID1239", Email="raju@dgs.com", Name= "Antonina", Surname="Macierewiczowa", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 1, 1) });
            this.Employees.Add(new Employee {ID = "ID1240", Email="taju@dgs.com", Name= "Antoni", Surname="Macierewicz", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 1, 1) });
            this.Employees.Add(new Employee {ID = "ID1241", Email="yaju@dgs.com", Name= "Filip", Surname="Zkonopii", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 6, 1) });
            this.Employees.Add(new Employee {ID = "ID1242", Email="uaju@dgs.com", Name= "Aga", Surname="Zgaga", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2016, 7, 1) });
            this.Employees.Add(new Employee {ID = "ID1243", Email="iaju@dgs.com", Name= "Jarek", Surname="Myśliwy", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 8, 1) });
            this.Employees.Add(new Employee {ID = "ID1244", Email="oaju@dgs.com", Name= "Michał", Surname="Miszał", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 9, 1) });
            this.Employees.Add(new Employee {ID = "ID1245", Email="paju@dgs.com", Name= "Paweł", Surname="Pawelec", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 10, 1) });
            this.Employees.Add(new Employee {ID = "ID1246", Email="saju@dgs.com", Name= "Tomek", Surname="Iprzyjaciele", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2012, 12, 1) });
            this.Employees.Add(new Employee {ID = "ID1247", Email="daju@dgs.com", Name= "Magda", Surname="Gessler", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 4, 1) });
            this.Employees.Add(new Employee {ID = "ID1248", Email="faju@dgs.com", Name= "Natalia", Surname="Siwiec", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 8, 1) });
            this.Employees.Add(new Employee {ID = "ID1249", Email="gaju@dgs.com", Name= "Sylwia", Surname="Niegrzeczna", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 3, 1) });
            this.Employees.Add(new Employee {ID = "ID1240", Email="haju@dgs.com", Name= "Czesław", Surname="Nowy", Manager="Michał ", Department = "Finance", HiredDate = new DateTime(2017, 1, 1) });
            this.Employees.Add(new Employee {ID = "ID1251", Email="kaju@dgs.com", Name= "Henryk", Surname="Hnrykański", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2015, 1, 1) });
            this.Employees.Add(new Employee {ID = "ID1252", Email="laju@dgs.com", Name= "Maria", Surname="Curie", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2014, 1, 1) });
            this.Employees.Add(new Employee {ID = "ID1253", Email="zaju@dgs.com", Name= "Ania", Surname="Annowska", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2013, 1, 1) });
            this.Employees.Add(new Employee {ID = "ID1254", Email="xaju@dgs.com", Name= "Sebastian", Surname="Zwykły", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2012, 1, 1) });
            this.Employees.Add(new Employee {ID = "ID1255", Email="caju@dgs.com", Name= "Kacper", Surname="Kacperski", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2011, 1, 1) });
            this.Employees.Add(new Employee {ID = "ID1256", Email="vaju@dgs.com", Name= "Antoni", Surname="Jurczyk", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2010, 1, 1) });
            this.Employees.Add(new Employee {ID = "ID1257", Email="baju@dgs.com", Name= "Sylwester", Surname="Doskonały", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2012, 12, 1) });
            this.Employees.Add(new Employee {ID = "ID1258", Email="maju@dgs.com", Name= "Łukasz", Surname="Łukaszewski", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2011, 3, 1) });
            this.Employees.Add(new Employee {ID = "ID1259", Email="naju@dgs.com", Name= "Halina", Surname="Malina", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 4, 1) });
            this.Employees.Add(new Employee {ID = "ID1260", Email="jdju@dgs.com", Name= "Ryszard", Surname="LwieSerce", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2009, 1, 1) });
            this.Employees.Add(new Employee {ID = "ID1261", Email="jfju@dgs.com", Name= "Wiktor", Surname="Wiktorowaty", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2015, 1, 1) });
            this.Employees.Add(new Employee {ID = "ID1262", Email="jgju@dgs.com", Name= "Wojtek", Surname="Wojcieszny", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2012, 1, 1) });
            this.Employees.Add(new Employee {ID = "ID1263", Email="jhju@dgs.com", Name= "Szymon", Surname="Szymanero", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2011, 1, 1) });
            this.Employees.Add(new Employee {ID = "ID1264", Email="jjju@dgs.com", Name= "Lech", Surname="Lechowy", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2012, 1, 1) });
            this.Employees.Add(new Employee {ID = "ID1265", Email="jkju@dgs.com", Name= "Wikoria", Surname="Wiktoriak", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 1, 1) });
            this.Employees.Add(new Employee {ID = "ID1266", Email="jyju@dgs.com", Name= "Aleksandra", Surname="Sylwiak", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2013, 1, 1) });
            this.Employees.Add(new Employee {ID = "ID1267", Email="jrju@dgs.com", Name= "Jacek", Surname="Kowalski", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 4, 1) });
            this.Employees.Add(new Employee {ID = "ID1268", Email="jeju@dgs.com", Name= "Katarzyna", Surname="Ada", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 6, 1) });
            this.Employees.Add(new Employee {ID = "ID1269", Email="jwju@dgs.com", Name= "Jakub", Surname="Jurczyk", Manager="Adam Kowalski", Department = "Finance", HiredDate = new DateTime(2017, 5, 1) });
        }
    }
}