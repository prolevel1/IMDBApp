using IMDBTest.Test.MockResources;
using IMDBApp;
using TechTalk.SpecFlow;
using IMDBTest.Test;
using IMDBTest;
using Microsoft.Extensions.DependencyInjection;
using IMDBApp.Services;

namespace IMDBTest.Test.StepFiles
{
    [Scope(Feature = "Actor Resource")]
    [Binding]
    public class ActorSteps : BaseSteps
    {
        public ActorSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Producer Repo
                    services.AddScoped(service => ActorMock.ActorRepoMock.Object);
                  
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            ActorMock.MockGetAll();
            ActorMock.MockGet();
            ActorMock.MockPost();
            ActorMock.MockPut();
            ActorMock.MockDelete();
        }
    }
}