using System;
using System.Collections.Generic;
using System.Text;

namespace EventReservation.Core.DTO
{
    public class EventsCountByStatusDTO
    {
        public int totalEvent { get; set; }
        public int pendingEvent { get; set; }
        public int acceptedEvent { get; set; }
        public int rejectedEvent { get; set; }
    }
}
