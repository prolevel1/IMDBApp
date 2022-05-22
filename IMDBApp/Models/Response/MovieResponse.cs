
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Models.Response
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime YOR { get; set; }
        public string Plot { get; set; }
        public List<Actor> Actor { get; set; }
        public List<Genre> Genre { get; set; }
        public Producer Producer { get; set; }
    }
}
