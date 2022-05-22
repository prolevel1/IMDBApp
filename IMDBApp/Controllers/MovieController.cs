
using IMDBApp.Models.Request;
using IMDBApp.Models.Response;
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
    public class MovieController : ControllerBase
    {
        private readonly IMovieServices movieService;
        public MovieController(IMovieServices _movieService)
        {
            movieService = _movieService;
        }
        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult Get()
        {
           var res =  movieService.Get();
            return Ok(res);
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = movieService.Get(id);
            return Ok(movie);
        }

        // POST api/<MovieController>
        [HttpPost]
        public IActionResult Post([FromBody] MovieRequest movieRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            movieService.Post(movieRequest);
            return Ok();
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MovieRequest movieRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            movieService.Put(id, movieRequest);
            return Ok();
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            movieService.Delete(id);
            return Ok();
        }
    }
}
