using System;
using AutoMapper;

public static class MapperFactory
{
   private static volatile IMapper mapperInstance;
   private static object syncRoot = new Object();

    public static IMapper GetMapperInstance() {
        if (mapperInstance == null) {
            lock(syncRoot) {
                var mappingProfile = new SF.App.Models.MappingProfile();
                Mapper.Initialize(m => m.AddProfile(mappingProfile));
                Mapper.AssertConfigurationIsValid();
                if (mapperInstance == null)
                    mapperInstance = Mapper.Instance;
            }
        }

        return mapperInstance;
    }
}