using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp.Application;

public static class InitializeConfigurations
{
    public static void Initialize(IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}