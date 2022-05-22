using IMDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Repository
{
   public interface IGenreRepository
    {
        public IEnumerable<Genre> Get();
        public Genre Get(int id);
        void Post(Genre genre);
        void Put(int id, Genre genre);
        void Delete(int id);
        public IEnumerable<Genre> GetGenresByMovieId(int id);
    }
}
