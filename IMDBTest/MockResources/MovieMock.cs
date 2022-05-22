using IMDBApp.Models;
using IMDBApp.Models.Request;
using IMDBApp.Models.Response;
using IMDBApp.Repository;
using IMDBApp.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBTest.Test.MockResources
{
    public class MovieMock
    {
       // public static readonly Mock<IMovieServices> MovieRepoMock = new Mock<IMovieServices>();
        public static readonly Mock<IMovieRepository> MovieRepoMock = new Mock<IMovieRepository>();
        public static void MockGetAll()
        {
            MovieRepoMock.Setup(repo => repo.Get()).Returns(ListOfMovies());
        }

       /* private static IEnumerable<MovieResponse> ListOfMovies()
        {
            var list = new List<MovieResponse>
            {
                new MovieResponse
                {
                    Id=1,
                    Name="Roc",
                    YOR=new DateTime(1992,09,26),    
                    Plot="Hindi",
                    Producer= ProducerMock.GetProducerByMovieId(1),
                    Actor= ActorMock.GetActorsByMovieId(1),
                    Genre=GenreMock.GetGenreByMovieId(1)


                }
            };
            return list;
        }*/
        private static IEnumerable<Movie> ListOfMovies()
        { 
            var list = new List<Movie>
            { 
                new Movie
                {
                    Id=1,
                    Name="Roc",
                    YOR=new DateTime(1992,09,26),
                    Plot="Hindi",
                    ProducerId = 1
                }
            };
            return list;
        }

    public static void MockGet()
        {
            MovieRepoMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int id) => ListOfMovies().SingleOrDefault(x => x.Id == id));
        }

        
    public static void MockPost()
    {
        MovieRepoMock.Setup(repo => repo.Post(It.IsAny<Movie>(), It.IsAny<string>(), It.IsAny<string>()));
    }

        public static void MockPut()
        {
            MovieRepoMock.Setup(repo => repo.Put(It.IsAny<Movie>(), It.IsAny<string>(), It.IsAny<string>()));
        }

        public static void MockDelete()
        {
            MovieRepoMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }

    }
}
    

