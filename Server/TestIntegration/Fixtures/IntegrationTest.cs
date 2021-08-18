using API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Xunit;

namespace TestIntegration.Fixtures
{
    public abstract class IntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly WebApplicationFactory<Startup> _factory;
        protected readonly HttpClient _client;

        public IntegrationTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }
    }
}
