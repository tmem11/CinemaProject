using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaProject.Models
{
    public class Movie
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="title")]
        public string movieTitle { get; set; }
        [Required]
        [Display(Name = "release Date")]
        public DateTime releaseDate { get; set; }
        [Required]
        [Display(Name = "movie story")]
        public string description { get; set; }
        [Required]
        [Display(Name = "genere")]
        public string genere { get; set; }
        [Required]
        [Display(Name = "allowed age")]
        public int age { get; set; }
        [Required]
        [Display(Name = "price for the ticket")]
        public double price { get; set; }
        [Display(Name = "movie poster")]
        public string movieImage { get; set; }
        public double porularity { get; set; }
        public virtual ICollection<MovieShowHall> MovieShowHalls { get; set; }







    }
}