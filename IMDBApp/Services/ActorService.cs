using IMDBApp.Models;
using IMDBApp.Models.Request;
using IMDBApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository actorRepository;
        public ActorService(IActorRepository _actorRepository)
        {
             actorRepository =  _actorRepository;
        }

        public void Delete(int id)
        {
            actorRepository.Delete(id);
        }

        public IEnumerable<ActorRequest> Get()
        {
            List<ActorRequest> allActors = new List<ActorRequest>();
            var actorEntities = actorRepository.Get();
            foreach (var actorEntity in actorEntities)
            {

                var actorRequestEntity = new ActorRequest
                {
                    Id = actorEntity.Id,
                    Name = actorEntity.Name,
                    Gender = actorEntity.Gender,
                    Bio = actorEntity.Bio,
                    Dob  = actorEntity.Dob
                };
                allActors.Add(actorRequestEntity);
            }
            return allActors;
        }

        public ActorRequest Get(int id)
        {
            var actorEntity = actorRepository.Get(id);
            ActorRequest actorRequest =
            new ActorRequest()
            {
                Id = actorEntity.Id,
                Name = actorEntity.Name,
                Gender = actorEntity.Gender,
                Bio = actorEntity.Bio,
                Dob = actorEntity.Dob
            };
            return actorRequest;
        }

        public void Post(ActorRequest actorRequest)
        {
            var actor = new Actor()
            {
                Id = actorRequest.Id,
                Name = actorRequest.Name,
                Gender = actorRequest.Gender,
                Bio = actorRequest.Bio,
                Dob = actorRequest.Dob
            };
            actorRepository.Post(actor);
        }

        public void Put(int id, ActorRequest actorRequest)
        {
            var actor = new Actor()
            {
                Id = actorRequest.Id,
                Name = actorRequest.Name,
                Gender = actorRequest.Gender,
                Bio = actorRequest.Bio,
                Dob = actorRequest.Dob
            };
            actorRepository.Put(id, actor);
        }
    }
}
