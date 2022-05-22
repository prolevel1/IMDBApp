using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Controllers
{
   [Route("api/Values")]
   [ApiController]
    public class ValuesController : ControllerBase
    {
        //[HttpGet("Department/id/Employee/Emp_id")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("otherwise");
        }
    }
}
