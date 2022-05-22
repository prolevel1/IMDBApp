using IMDBApp.Models;
using IMDBApp.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBTest.Test.MockResources
{
    public class GenreMock
    {
        public static readonly Mock<IGenreRepository> GenreRepoMock = new Mock<IGenreRepository>();
        public static void MockGetAll()
        {
            GenreRepoMock.Setup(repo => repo.Get()).Returns(ListOfGenres());
        }

        private static IEnumerable<Genre> ListOfGenres()
        {
            var list = new List<Genre>
            {
                new Genre
                {
                     Id=1,
                     Name="Action",
                },
                new Genre
                {
                    Id=3,
                    Name="Romance",
                }
            };
            return list;
        }
        public static void MockGet()
        {
            GenreRepoMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int id) => ListOfGenres().SingleOrDefault(x => x.Id == id));
        }

        public static void MockPost()
        {
            GenreRepoMock.Setup(repo => repo.Post(It.IsAny<Genre>()));
        }

        public static void MockPut()
        {
            GenreRepoMock.Setup(repo => repo.Put(It.IsAny<int>(), It.IsAny<Genre>()));
        }

        public static void MockDelete()
        {
            GenreRepoMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }
        //public static Dictionary<int, List<int>> MovieGenreMapping()
        //{
        //    var movieGenreMapping = new Dictionary<int, List<int>>
        //    {
        //        {1, new List<int> {1} }
        //    };
        //    return movieGenreMapping;
        //}

        //public static List<Genre> GetGenreByMovieId(int movieId)
        //{
        //    List<Genre> genres = new List<Genre>();
        //    var movieGenreMapping = MovieGenreMapping();
        //    movieGenreMapping[movieId].ForEach(id =>
        //    {
        //        genres.Add(ListOfGenres().Single(a => a.Id == id));
        //    });
        //    return genres;
        //}
    }
}
