
using IMDBApp.Models.Request;
using IMDBApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDBApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerServices producerServices;
        public ProducerController(IProducerServices _producerServices)
        {
            producerServices = _producerServices;
        }

        // GET: api/<ProducerController>
        [HttpGet]
        public IActionResult Get()
        {
            var producers = producerServices.Get();
            return Ok(producers);
        }

        // GET api/<ProducerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var producer = producerServices.Get(id);
            return Ok(producer);
        }

        // POST api/<ProducerController>
        [HttpPost]
        public IActionResult Post([FromBody] ProducerRequest producerRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            producerServices.Post(producerRequest);
            return Ok();

        }

        // PUT api/<ProducerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProducerRequest producerRequest)
        {
            producerServices.Put(id, producerRequest);
            return Ok();
        }

        // DELETE api/<ProducerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            producerServices.Delete(id);
            return Ok("deleted");
        }
    }
}
