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
        Assert.Null((result.Model as ReportFamilyIncomeViewModel).ValidationErrorMessage);
        Assert.False((result.Model as ReportFamilyIncomeViewModel).IsSuccess);
        Assert.Equal(IncomeLevelType.None, (result.Model as ReportFamilyIncomeViewModel).SelectedIncomeLevel);
    }

    [Fact]
    public void IncomeReport_Should_Return_False_When_Validation_Fails()
    {
        //Given
        ReportController controller = new ReportController();
        // GET page to get empty view model
        ReportFamilyIncomeViewModel notChangedViewModel = (controller.FamilyIncome() as ViewResult).Model as ReportFamilyIncomeViewModel;
        //When
        ViewResult result = controller.FamilyIncome(notChangedViewModel) as ViewResult;
        //Then
        Assert.NotNull(result);
        Assert.NotNull(result.Model);
        Assert.False((result.Model as ReportFamilyIncomeViewModel).IsSuccess);
        Assert.NotEmpty((result.Model as ReportFamilyIncomeViewModel).ValidationErrorMessage);
    }

    [Fact]
    public void IncomeReport_Should_Redirect_To_Success_When_Validation_Passes()
    {
        //Given
        ReportController controller = new ReportController();
        // GET page to get empty view model
        ReportFamilyIncomeViewModel changedViewModel = (controller.FamilyIncome() as ViewResult).Model as ReportFamilyIncomeViewModel;
        //When
        changedViewModel.SelectedIncomeLevel = IncomeLevelType.BelowThen2000;
        RedirectToActionResult result = controller.FamilyIncome(changedViewModel) as RedirectToActionResult;
        //Then
        Assert.NotNull(result);
        Assert.Same("Success", result.ActionName);
    }
}