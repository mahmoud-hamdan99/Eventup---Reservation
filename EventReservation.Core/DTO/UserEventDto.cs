using System;
using System.Collections.Generic;
using System.Text;

namespace EventReservation.Core.DTO
{
  public class UserEventDto
    {
        public string Eventtype { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Status { get; set; }
        public int NoPerson { get; set; }
        public decimal totalprice { set; get; }

        public string ImageUrl { set; get; }

        public string name { get; set; }




    }
}
