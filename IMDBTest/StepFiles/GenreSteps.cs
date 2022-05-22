using IMDBApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;
using IMDBTest.Test.MockResources;

namespace IMDBTest.Test.StepFiles
{
    [Scope(Feature = "Genre Resource")]
    [Binding]
    public class GenreSteps : BaseSteps
    {
        public GenreSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Producer Repo
                    services.AddScoped(service => GenreMock.GenreRepoMock.Object);
                  //  services.AddScoped<IActorService, ActorService>();
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            GenreMock.MockGetAll();
            GenreMock.MockGet();
            GenreMock.MockPost();
            GenreMock.MockPut();
            GenreMock.MockDelete();
        }
    }
}
