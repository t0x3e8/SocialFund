using Microsoft.AspNetCore.Mvc;
using SF.App.Controllers;
using SF.App.Models.Data;
using SF.App.Models.Repositories;
using SF.App.Models.ViewModels;
using Xunit;
using Moq;
using AutoMapper;

public class HomeControllerTests : BaseUnitTest {
    private static Employee MakeTestEmployee() {
        Employee emp = new Employee();
        emp.Department = "testDepartment";
        emp.Email = "test@email.com";
        emp.HiredDate = new System.DateTime(1981, 03, 01);
        emp.ID = "1234";
        emp.Manager = "testManager";
        emp.Name = "testName";
        emp.RoleName = "testRole";
        emp.Surname = "testSurname";
        
        return emp;
    }

    [Fact]
    public void Index_Should_Return_Form_of_Registered_User() {
        // arrange
        var mock = new Mock<IEmployeeRepository>();

        mock.Setup(er => er.Get("test@email.com")).Returns(MakeTestEmployee());
        HomeController controller = new HomeController(mock.Object, null, Mapper.Instance);
        controller.ControllerContext = Helper.CreateControllerContextWithUserClaim("test@email.com");
        
        //act
        ViewResult result = controller.Index() as ViewResult;
    
        // assert
        Assert.NotNull(result);
        Assert.NotNull(result.Model);
        Assert.IsType<HomeIndexViewModel>(result.Model);
        Assert.NotNull((result.Model as HomeIndexViewModel).Department);
        Assert.NotNull((result.Model as HomeIndexViewModel).DirectManager);
        Assert.NotNull((result.Model as HomeIndexViewModel).Email);
        Assert.NotNull((result.Model as HomeIndexViewModel).Id);
        Assert.NotNull((result.Model as HomeIndexViewModel).HiredDate);
        Assert.NotNull((result.Model as HomeIndexViewModel).Name);
        Assert.NotNull((result.Model as HomeIndexViewModel).Surname);
        Assert.False((result.Model as HomeIndexViewModel).IsModelEmpty);
        mock.Verify(er => er.Get(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void Index_Should_Allow_To_Update_Employee_Record() {

        // arrange
        var mock = new Mock<IEmployeeRepository>();
        mock.Setup(er => er.Get("test@email.com")).Returns(MakeTestEmployee());
        HomeController controller = new HomeController(mock.Object, null, Mapper.Instance);
        controller.ControllerContext = Helper.CreateControllerContextWithUserClaim("test@email.com");
        HomeIndexViewModel vm = (controller.Index() as ViewResult).Model as HomeIndexViewModel;
        
        // act
        vm.Name = "UnitTest1";
        controller.Index(vm);
        vm = (controller.Index() as ViewResult).Model as HomeIndexViewModel;

        //assert
        Assert.Same("UnitTest1", vm.Name);
        mock.Verify(er => er.Get(It.IsAny<string>()), Times.Exactly(3));
    }

    [Fact]
    public void Index_Should_Return_Information() {
        // arrange
        var mock = new Mock<IEmployeeRepository>();
        mock.Setup(er => er.Get("test@email.com")).Returns<Employee>(null);
        HomeController controller = new HomeController(mock.Object, null, null);
        controller.ControllerContext = Helper.CreateControllerContextWithUserClaim("doesnotexit@dgs.com");
        
        //act
        object result = controller.Index();
    
        // assert
        Assert.NotNull(result);
        Assert.IsType(typeof(RedirectToActionResult), result);
        mock.Verify(er => er.Get(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void ReportNoRecord_Should_File_A_Request() {
        // arrange        
        var mock = new Mock<IReportRepository>();
        mock.SetupSequence(rr => rr.Get(ReportType.MissingProfileInfo, "test@email.com"))
                .Returns(null)
                .Returns(new Report());
        mock.Setup(rr => rr.Add(It.IsAny<Report>()));

        HomeController controller = new HomeController(null, mock.Object, null);
        controller.ControllerContext = Helper.CreateControllerContextWithUserClaim("test@email.com");
        
        //act
        // running twice to proof that the same report won't be requested twice for the same email
        controller.ReportNoRecord();
        controller.ReportNoRecord();
    
        // assert
        mock.Verify(rr => rr.Add(It.IsAny<Report>()), Times.Once);
        mock.Verify(rr => rr.Get(ReportType.MissingProfileInfo, It.IsAny<string>()), Times.Exactly(2));
    }
}