using System;
using AutoMapper;

public class BaseUnitTest : IDisposable
{
    public BaseUnitTest() {
        if (Mapper.Instance == null) {
            var mappingProfile = new SF.App.Models.MappingProfile();
            Mapper.Initialize(m => m.AddProfile(mappingProfile));
            Mapper.AssertConfigurationIsValid();
        }
    }
    public void Dispose() {
        Mapper.Reset();
    }
}