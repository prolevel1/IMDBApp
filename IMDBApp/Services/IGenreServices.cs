using IMDBApp.Models.Request;
using IMDBApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Services
{
    public interface IGenreServices
    {
        public IEnumerable<GenreRequest> Get();
        public GenreRequest Get(int id);
        public void Post(GenreRequest genreRequest);
        public void Put(int id, GenreRequest genreRequest);
        public void Delete(int id);
    }
}
