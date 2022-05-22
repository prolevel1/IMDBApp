﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Models.Response
{
    public class ActorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        
    }
}
