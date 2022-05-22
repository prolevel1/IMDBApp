using IMDBTest.Test.MockResources;
using IMDBApp;
using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;
namespace IMDBTest.Test.StepFiles
{
    [Scope(Feature = "Movie Resource")]
    [Binding]
    public class MovieSteps : BaseSteps
    {
        public MovieSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Producer Repo
                     services.AddScoped(service => MovieMock.MovieRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            MovieMock.MockGetAll();
            MovieMock.MockGet();
            MovieMock.MockPost();
            MovieMock.MockPut();
            MovieMock.MockDelete();
            
        }
    }
}
