using Microsoft.AspNetCore.Mvc;
using SF.App.Controllers;
using SF.App.Models.ViewModels;
using Xunit;

public class ReportControllerTests {
    [Fact]
    public void IncomeReport_Should_Return_ViewModel()
    {
        //Given
        ReportController controller = new ReportController(); 
        //When
        ViewResult result = controller.FamilyIncome() as ViewResult;
        //Then
        Assert.NotNull(result);
        Assert.IsType(typeof(ReportFamilyIncomeViewModel), result.Model);
        Assert.NotNull(result.Model);
        Assert.False((result.Model as ReportFamilyIncomeViewModel).IsVoucherRequested);
        Assert.NotEmpty((result.Model as ReportFamilyIncomeViewModel).IncomeLevels);
        Assert.Equal(0, (result.Model as ReportFamilyIncomeViewModel).SelectedIncomeLevel);
    }
}