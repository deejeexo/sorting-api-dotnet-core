using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using sorting_api_dotnet_core.API;

namespace sorting_api_dotnet_core.Tests;

public class SortingApiFactory : WebApplicationFactory<Sorter>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.AddServices();
        });
    }
}
