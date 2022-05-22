using IMDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Repository
{
    public interface IActorRepository 
    {
        public IEnumerable<Actor> Get();
        public Actor Get(int id);
        void Post(Actor actors);
        void Put(int id, Actor actors);
        void Delete(int id);
        public IEnumerable<Actor> GetActorsByMovieId(int id);
    }
}
