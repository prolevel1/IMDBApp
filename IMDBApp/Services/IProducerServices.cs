using IMDBApp.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Services
{
    public interface IProducerServices 
    {
        public IEnumerable<ProducerRequest> Get();
        public ProducerRequest Get(int id);
        public void Post(ProducerRequest producerRequest);
        public void Put(int id, ProducerRequest producerRequest);
        public void Delete(int id);

    }
}
