using Xunit;
using SF.App.Controllers;
using Microsoft.AspNetCore.Mvc;
using SF.App.Models;
using SF.App.Models.Data;

public class EmployeesControllerTests {

    [Fact]
    public void Index_Should_Return_Collection_of_Employees()
    {
        //arrange
        var controller = new EmployeesController();
        
        //act        
        var result = controller.Index() as ViewResult;

        //assert
        Assert.NotNull(result);
        Assert.NotNull(result.Model);
        Assert.IsType<EmployeesViewModel>(result.Model);
        Assert.NotEmpty((result.Model as EmployeesViewModel).Employees);        
    }
}