using System;
using System.Collections.Generic;
using System.Text;

namespace DWS.MovieLibrary.Domain.Models
{
    public class Person : BaseEntity<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }
        public int Gender { get; set; }

        public string MovieID { get; set; }
        public Movie Movie { get; set; }
    }
}
