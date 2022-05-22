using IMDBApp.Models;
using IMDBApp.Models.Request;
using IMDBApp.Models.Response;
using IMDBApp.Repository;
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
    public class ActorController : ControllerBase
    {
        private readonly IActorService actorService;

        public ActorController(IActorService _actorService)
        {
            actorService = _actorService;
        }
   
         [HttpGet]
         public IActionResult Get()
         {
              var actors = actorService.Get();
              return Ok(actors);
         }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var actor = actorService.Get(id);
            return Ok(actor);
        }

        // POST api/<ActorController>
        [HttpPost]
        public IActionResult Post([FromBody] ActorRequest actorRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            actorService.Post(actorRequest);
            return Ok();
        }

        // PUT api/<ActorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActorRequest actorRequest)
        {
            actorService.Put(id, actorRequest);
            return Ok();
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            actorService.Delete(id);
            return Ok("Deleted...");
        }
        
    }
}
