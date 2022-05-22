using IMDBApp.Models.Request;
using IMDBApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Services
{
    public interface IMovieServices
    {
        public IEnumerable<MovieResponse> Get();
        public MovieResponse Get(int Id);

        public void Post(MovieRequest movieRequest);
        public void Delete(int id);
        public void Put(int id, MovieRequest movieRequest);
    }
}
