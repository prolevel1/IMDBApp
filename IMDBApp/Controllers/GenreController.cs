
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
    public class GenreController : ControllerBase
    {
        private readonly IGenreServices genreService;
        public GenreController(IGenreServices _genreService)
        {
            genreService = _genreService;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public IActionResult Get()
        {
            var genre = genreService.Get();
            return Ok(genre);
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var genre = genreService.Get(id);
            return Ok(genre);
        }

        // POST api/<GenreController>
        [HttpPost]
        public IActionResult Post([FromBody] GenreRequest genreRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            genreService.Post(genreRequest);
            return Ok();
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GenreRequest genreRequest)
        {
            genreService.Put(id, genreRequest);
            return Ok();
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            genreService.Delete(id);
            return Ok();
        }
    }
}
