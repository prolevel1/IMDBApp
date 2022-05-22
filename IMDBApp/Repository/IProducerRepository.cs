using IMDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Repository
{
    public interface IProducerRepository
    {
        public IEnumerable<Producer> Get();
        public Producer Get(int id);
        void Post(Producer producer);
        void Put(int id, Producer producer);
        void Delete(int id);


    }
}
