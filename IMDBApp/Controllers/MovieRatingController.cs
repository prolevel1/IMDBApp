using IMDBApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Controllers
{
   [Route("api/MovieRating")]
   [ApiController]
   public class MovieRatingController : ControllerBase
    {
     
        [HttpGet]
   
    public ActionResult Get()
        {
            return Ok("show");
        }
        //[HttpGet("resturant/{resturantId}/dish")]
        //[Route("api/MovieRating/{name}")]
        [Route("resturant/{resturantId}/dish")]
        public ActionResult Get(int resturantId)
        {
            
            return Ok(resturantId);
        }
    


    }
}
