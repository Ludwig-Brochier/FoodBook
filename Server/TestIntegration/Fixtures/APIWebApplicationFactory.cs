using API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace TestIntegration.Fixtures
{
    public class APIWebApplicationFactory : WebApplicationFactory<Startup>
    {
        public IConfiguration configuration { get; private set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                configuration = new ConfigurationBuilder()
                    .AddJsonFile("integrationsettings.json")
                    .Build();

                config.AddConfiguration(configuration);
            });
        }
    }
}
