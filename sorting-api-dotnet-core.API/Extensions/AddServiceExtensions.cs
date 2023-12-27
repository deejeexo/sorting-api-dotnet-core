using System.Reflection;
using FluentValidation;

namespace sorting_api_dotnet_core.API;

public static class AddServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IFileManager, FileManager>();
        services.AddScoped<Sorter>();

        services.AddValidators();

        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        AssemblyScanner
            .FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
            .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

        return services;
    }
}
