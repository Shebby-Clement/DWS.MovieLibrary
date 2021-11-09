using DWS.MovieLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DWS.MovieLibrary.Domain.Dtos
{
    public class MovieDto : BaseEntity<Guid>
    {
        public MovieDto()
        {
            ID = Guid.NewGuid();
        }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Year { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int Genre { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int Country { get; set; }

        [Required]
        [Display(Name = "Language")]
        public string Language { get; set; }

        [Required]
        [Display(Name = "rating")]
        public int Rating { get; set; }
    }
}
