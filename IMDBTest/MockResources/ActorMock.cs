using IMDBApp.Models;
using IMDBApp.Repository;
using IMDBApp.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDBTest.Test.MockResources
{
    public class ActorMock
    {
         public static readonly Mock<IActorRepository> ActorRepoMock = new Mock<IActorRepository>();

        public static void MockGetAll()
        {
             ActorRepoMock.Setup(repo => repo.Get()).Returns(ListOfActors());
        }

        private static IEnumerable<Actor> ListOfActors()
        {
            var list = new List<Actor>()
            {
                new Actor()
                {
                     Id=1,
                     Name="Mila Kunis",
                    Gender="Female",
                    Bio="Americal  Actress",
                    Dob=new DateTime(1986,11,14)

                },
                new Actor()
                {
                    Id=2,
                    Name="George Michael",
                    Gender="Male",
                    Bio="A romantic",
                    Dob=new DateTime(1978,11,23)
                }
            };
            return list;
        }
        public static void MockGet()
        {
            ActorRepoMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int id) => ListOfActors().SingleOrDefault(x => x.Id == id));
           
        }

        public static void MockPost()
        {
            ActorRepoMock.Setup(repo => repo.Post(It.IsAny<Actor>()));
        }

        public static void MockPut()
        {
            ActorRepoMock.Setup(repo => repo.Put(It.IsAny<int>(), It.IsAny<Actor>()));
        }

        public static void MockDelete()
        {
            ActorRepoMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }
        //public static Dictionary<int, List<int>> MovieActorMapping()

        //{

        //    var movieActorMapping = new Dictionary<int, List<int>>

        //    {

        //        {1, new List<int> {1} }

        //    };

        //    return movieActorMapping;

        //}
        //public static List<Actor> GetActorsByMovieId(int movieId)

        //{

        //    List<Actor> actors = new List<Actor>();

        //    var movieActorsMapping = MovieActorMapping();

        //    movieActorsMapping[movieId].ForEach(id =>

        //    {

        //        actors.Add(ListOfActors().Single(a => a.Id == id));

        //    });

        //    return actors;

        //}



    }
}