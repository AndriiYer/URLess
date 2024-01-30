using AndriYer.URLess.Data.Contracts;
using AndriYer.URLess.WebApi.Tests.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AndriYer.URLess.WebApi.Tests
{
    public class WebApiTestFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                builder.ConfigureAppConfiguration((host, configurationBuilder) =>
                {
                    configurationBuilder.AddInMemoryCollection(
                        new List<KeyValuePair<string, string?>>
                        {
                            new("InstanceName", "FromTests")
                        });
                });
            });
            
            builder.ConfigureTestServices(services =>
            {
                services.AddSingleton<TestDataBase>();
                services.AddScoped<IUrlRepository, TestUrlRepository>();
            });
        }
    }
}
