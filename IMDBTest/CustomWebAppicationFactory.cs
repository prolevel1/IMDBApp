using IMDBApp;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;


namespace IMDBTest.Test
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TestStartup>
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder()
                .UseEnvironment("Testing")
                .UseStartup<TestStartup>();
        }
    }
}