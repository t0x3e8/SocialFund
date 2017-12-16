using Microsoft.AspNetCore.Mvc;
using SF.App.Controllers;
using SF.App.Models.Data;
using SF.App.Models.ViewModels;
using Xunit;

public class HomeControllerTests {

    [Fact]
    public void Index_Should_Return_Form_of_Registered_User() {
        // arrange
        SocialFundDBContext dBContext = new SocialFundDBContext();
        HomeController controller = new HomeController(dBContext);
        controller.ControllerContext = Helper.CreateControllerContextWithUserClaim("jaju@dgs.com");
        
        //act
        ViewResult result = controller.Index() as ViewResult;
    
        // assert
        Assert.NotNull(result);
        Assert.NotNull(result.Model);
        Assert.IsType<HomeIndexViewModel>(result.Model);
        Assert.NotNull((result.Model as HomeIndexViewModel).Department);
        Assert.NotNull((result.Model as HomeIndexViewModel).DirectManager);
        Assert.NotNull((result.Model as HomeIndexViewModel).Email);
        Assert.NotNull((result.Model as HomeIndexViewModel).EmployeeId);
        Assert.NotNull((result.Model as HomeIndexViewModel).HiredDate);
        Assert.NotNull((result.Model as HomeIndexViewModel).Name);
        Assert.NotNull((result.Model as HomeIndexViewModel).Surname);
        Assert.False((result.Model as HomeIndexViewModel).IsModelEmpty);
    }

        [Fact]
    public void Index_Should_Return_Information() {
        // arrange
        SocialFundDBContext dBContext = new SocialFundDBContext();
        HomeController controller = new HomeController(dBContext);
        controller.ControllerContext = Helper.CreateControllerContextWithUserClaim("doesnotexit@dgs.com");
        
        //act
        ViewResult result = controller.Index() as ViewResult;
    
        // assert
        Assert.NotNull(result);
        Assert.Null(result.Model);
        Assert.True((result.Model as HomeIndexViewModel).IsModelEmpty);
    }
}