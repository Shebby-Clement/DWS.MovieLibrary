using DWS.MovieLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DWS.MovieLibrary.Domain.Dtos
{

    public class PersonDto : BaseEntity<Guid>
    {

        public PersonDto()
        {
            ID = Guid.NewGuid();
        }

        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Role")]
        public int Role { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public int Gender { get; set; }

        
        [Display(Name = "Movie")]
        public List<DropDownItem> MovieList { get; set; }
        [Required(ErrorMessage = "Please provide movie name. First create movies if empty.")]
        public string MovieID { get; set; }
    }
}
