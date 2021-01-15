using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaProject.Models
{
    public class SeatList
    {
        public int id { get; set; }
        public string seatNumber { get; set; }
       public bool IsAvailable { get; set; }

       
        public int Hallid { get; set; }
        public virtual Hall hall { get; set; }
    }
}