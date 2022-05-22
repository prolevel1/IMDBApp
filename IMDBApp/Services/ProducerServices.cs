using IMDBApp.Models;
using IMDBApp.Models.Request;
using IMDBApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Services
{
    public class ProducerServices : IProducerServices
    {
        private readonly IProducerRepository producerRepository;
        public ProducerServices(IProducerRepository _producerRepository)
        {
            producerRepository = _producerRepository;
        }
        public void Delete(int id)
        {
            producerRepository.Delete(id);
        }

        public IEnumerable<ProducerRequest> Get()
        {
           
            List<ProducerRequest> lists = new List<ProducerRequest>();
            List<ProducerRequest> allProducers = lists;
            var prducerEntities = producerRepository.Get();
            
            foreach (var producerEntity in prducerEntities)
            {
                var producerRequestEntity = new ProducerRequest
                {
                    Id = producerEntity.Id,
                    Name = producerEntity.Name,
                    Bio = producerEntity.Bio,
                    Dob = producerEntity.Dob,
                    Gender = producerEntity.Gender
                };
                allProducers.Add(producerRequestEntity);
            }
            return allProducers;
        }

        public ProducerRequest Get(int id)
        {
            var producerEntity = producerRepository.Get(id);
            ProducerRequest producerRequest =
            new ProducerRequest()
            {
                Id = producerEntity.Id,
                Name = producerEntity.Name,
                Gender = producerEntity.Gender,
                Bio = producerEntity.Bio,
                Dob = producerEntity.Dob
            };
            return producerRequest;
        }

        public void Post(ProducerRequest producerRequest)
        {
            var producerEntity = new Producer()
            {

                Name = producerRequest.Name,
                Gender = producerRequest.Gender,
                Bio = producerRequest.Bio,
                Dob = producerRequest.Dob

            };
            producerRepository.Post(producerEntity);
        }

        public void Put(int id, ProducerRequest producerRequest)
        { 
                var variable = new Producer()
                {
                    Id = producerRequest.Id,
                    Name = producerRequest.Name,
                    Gender = producerRequest.Gender,
                    Bio = producerRequest.Bio,
                    Dob = producerRequest.Dob
                };
             producerRepository.Put(id, variable);
            
        }
    }
}
