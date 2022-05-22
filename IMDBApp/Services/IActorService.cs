using IMDBApp.Models;
using IMDBApp.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Services
{
    public interface IActorService
    {
        public IEnumerable<ActorRequest> Get();
        public ActorRequest Get(int id);
        public void Post(ActorRequest actorRequest);
        public void Put(int id, ActorRequest actorsRequest);
        public void Delete(int id);
        
    }
}
