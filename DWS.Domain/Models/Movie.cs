using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.MovieLibrary.Domain.Models
{
    public class Movie : BaseEntity<string>
    {
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public int Genre { get; set; }
        public int Country { get; set; }
        public string Language { get; set; }
        public int Rating { get; set; }

        public ICollection<Person> Person { get; set; }
    }
}
