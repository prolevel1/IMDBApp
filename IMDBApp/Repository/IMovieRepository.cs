using IMDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Repository
{
    public interface IMovieRepository
    {
        public IEnumerable<Movie> Get();
        public Movie Get(int id);
        //  void Post(Movie movie, List<int> actor, List<int> genre);
        void Post(Movie movie, string actor, string genre);
        // void Put(int id, Movie movie, List<int> actor, List<int> genre);
        void Put(int id, Movie movie, string actor, string genre);
        void Delete(int id);
    }
}
