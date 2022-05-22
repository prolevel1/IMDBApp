using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  DateTime YOR { get; set; }
        public  string Plot { get; set; }
        public int ProducerId { get; set; }
       
    }
}
