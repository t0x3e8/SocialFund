using Xunit;
using SF.App.Controllers;
using Microsoft.AspNetCore.Mvc;
using SF.App.Models;
using SF.App.Models.Data;
using Moq;
using SF.App.Models.Repositories;
using AutoMapper;
using System;

public class EmployeesControllerTests : IDisposable {
    public void Dispose()
    {
        Mapper.Reset();
    }

    [Fact]
    public void Index_Should_Return_Collection_of_Employees()
    {
        //arrange
        IEmployeeRepository repo = new EmployeeRepository(new SocialFundDBContext());
        var controller = new EmployeesController(repo, MapperFactory.GetMapperInstance());
        
        //act        
        var result = controller.Index() as ViewResult;

        //assert
        Assert.NotNull(result);
        Assert.NotNull(result.Model);
        Assert.IsType<EmployeesViewModel>(result.Model);
        Assert.NotEmpty((result.Model as EmployeesViewModel).Employees);
    }
}