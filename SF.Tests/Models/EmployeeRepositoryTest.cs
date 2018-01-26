using System;
using System.Collections.Generic;
using Moq;
using SF.App.Models.Data;
using SF.App.Models.Repositories;
using Xunit;

namespace SF.Tests.Models {
    public class EmployeeRepositoryTest {
        private static List<Employee> CreateTestEmployeeList () {
            var employees = new List<Employee>();
            employees.Add(new Employee {ID = "ID1234", Email="aaaa@unittest.com", Name= "Peter", Surname="PeterSurname", Manager="Simon SimonSurname", Department = "Finance", HiredDate = new DateTime(2017, 1, 1) , RoleName = "Admin" });
            employees.Add(new Employee {ID = "ID1235", Email="bbbb@unittest.com", Name= "Simon", Surname="SimonSurname", Manager="Bill Gates", Department = "Finance", HiredDate = new DateTime(2017, 12, 1), RoleName = "Admin"});
            employees.Add(new Employee {ID = "ID1236", Email="cccc@unittest.com", Name= "John", Surname="JohnSurname", Manager="Simon SimonSurname", Department = "Finance", HiredDate = new DateTime(2017, 3, 1) });
            employees.Add(new Employee {ID = "ID1237", Email="dddd@unittest.com", Name= "Alex", Surname="AlexSurname", Manager="Simon SimonSurname", Department = "Finance", HiredDate = new DateTime(2017, 4, 1) });
            employees.Add(new Employee {ID = "ID1238", Email="eeee@unittest.com", Name= "Anna", Surname="AnnaSurname", Manager="Simon SimonSurname", Department = "Finance", HiredDate = new DateTime(2017, 5, 1) });
            return employees;
        }

        [Fact]
        public void Get_Should_Return_Employee_When_Email_Provided() {
            //Given
            var employeesTestList = CreateTestEmployeeList();
            var mock = new Mock<IDatabaseContext>();
            mock.SetupGet(m => m.Employees).Returns(employeesTestList);
            EmployeeRepository repo = new EmployeeRepository(mock.Object);
            //When
            var employee = repo.Get("cccc@unittest.com");
            //Then
            Assert.NotNull(employee);
            Assert.Same(employeesTestList[2], employee); 
        }

        [Fact]
        public void Get_Should_Return_Null_When_Email_Not_Exist() {
            //Given
            var employeesTestList = CreateTestEmployeeList();
            var mock = new Mock<IDatabaseContext>();
            mock.SetupGet(m => m.Employees).Returns(employeesTestList);
            EmployeeRepository repo = new EmployeeRepository(mock.Object);
            //When
            var employee = repo.Get("ffff@unittest.com");
            //Then
            Assert.Null(employee);
        }
    }
}