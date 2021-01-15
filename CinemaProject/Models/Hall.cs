using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CinemaProject.Models
{
    public class Hall
    {
        [DisplayName("hall number")]
        public int id { get; set; }

        [DisplayName("number of seats")]
        public int numberOfSeats { get; set; }

        [DisplayName("seats list")]
        public virtual ICollection <SeatList> seatList { get; set; }
        public virtual ICollection<MovieShowHall> MovieShowHalls { get; set; }



    }
}