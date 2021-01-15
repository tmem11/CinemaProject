using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaProject.Models
{
    public class MovieShowHall
    {
        public int id { get; set; }
        [Key, Column(Order = 1)]
        public int Movieid { get; set; }
        [Key, Column(Order = 2)]
        public int Hallid { get; set; }
        public Hall hall { get; set; }


        public DateTime date { get; set; }
        public double length { get; set; }

        public virtual Movie Movie { get; set; }

    }
}