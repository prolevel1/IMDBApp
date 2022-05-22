using IMDBApp.Models;
using IMDBApp.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBTest.Test.MockResources
{
    public class ProducerMock
    {
        public static readonly Mock<IProducerRepository> producerRepoMock = new Mock<IProducerRepository>();


        public static void MockGetAll()
        {
            producerRepoMock.Setup(repo => repo.Get()).Returns(ListOfProducers());
        }

        private static List<Producer> ListOfProducers()
        {
            var list = new List<Producer>() {
            new Producer()
            {
                  Id= 1,
                  Name="Arjun",
                  Gender= "Male",
                  Bio = "A director",
                  Dob= new DateTime(1962,8,15)

            },
            new Producer()
            {
                Id=2,
                Name="Tom",
                Gender= "Male",
                Bio="a directorial",
                Dob=new DateTime(1987,11,03)
            }

          };
            return list;
        }

        public static void MockGet()
        {
            producerRepoMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int id) => ListOfProducers().SingleOrDefault(x => x.Id == id));
        }

        public static void MockPost()
        {
            producerRepoMock.Setup(repo => repo.Post(It.IsAny<Producer>()));
        }

        public static void MockPut()
        {
            producerRepoMock.Setup(repo => repo.Put(It.IsAny<int>(), It.IsAny<Producer>()));
        }

        public static void MockDelete()
        {
            producerRepoMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }
        public static Dictionary<int, int> MovieProducerMapping() => new Dictionary<int, int>
        {
            
            {1, 1}
        };

        public static Producer GetProducerByMovieId(int movieId)
        {
            var listOfProducers = ListOfProducers();
            var movieProducerMapping = MovieProducerMapping();

            var producer = listOfProducers.Where(p => p.Id == movieProducerMapping[movieId]).First();

            return producer;
        }
    }
}
