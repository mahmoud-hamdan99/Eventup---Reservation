using System;
using System.Collections.Generic;
using System.Text;

namespace EventReservation.Core.DTO
{
    public class HallReusltDto
    {

        public int Hallid { get; set; }
        public string Name { get; set; }
        public int? Capacity { get; set; }
        public int? Waiters { get; set; }
        public int? Sale { get; set; }
        public float? Reservationprice { get; set; }
        public string Usage { get; set; }
        public int? Locationid { get; set; }

        public string ImageUrl { get; set; }

        public int Rate { get; set; }


    }
}
