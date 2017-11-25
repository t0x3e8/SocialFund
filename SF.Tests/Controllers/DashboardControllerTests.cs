using Xunit;
using SF.App.Controllers;
using Microsoft.AspNetCore.Mvc;
using SF.App.Models;

public class DashboardControllerTests { 
    [Fact]
    public void Index_Should_Return_Form_of_Current_User() {
        // arrange
        DashboardController controller = new DashboardController();
        
        //act
        ViewResult result = controller.Index() as ViewResult;
    
        // assert
        Assert.NotNull(result);
        Assert.NotNull(result.Model);
        Assert.IsType<DashboardIndexViewModel>(result.Model);        
    }
}