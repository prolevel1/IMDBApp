using IMDBApp;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using IMDBTest.Test.MockResources;
using TechTalk.SpecFlow;

namespace IMDBTest.Test.StepFiles
{
    [Scope(Feature = "Producer Resource")]
    [Binding]
    public class ProducerSteps :BaseSteps
    {
        public ProducerSteps(CustomWebApplicationFactory<TestStartup> factory)
           : base(factory.WithWebHostBuilder(builder =>
           {
               builder.ConfigureServices(services =>
               {
                    // Producer Repo
                    services.AddScoped(service => ProducerMock.producerRepoMock.Object);

               });
           }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            ProducerMock.MockGetAll();
            ProducerMock.MockGet();
            ProducerMock.MockPost();
            ProducerMock.MockPut();
            ProducerMock.MockDelete();
        }
    }
}
