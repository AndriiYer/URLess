using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;

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
                
            });
        }
    }
}
