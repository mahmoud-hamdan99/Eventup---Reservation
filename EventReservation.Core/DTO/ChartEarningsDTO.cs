using System;
using System.Collections.Generic;
using System.Text;

namespace EventReservation.Core.DTO
{
    public class ChartEarningsDTO
    {
        public int totalHalls { get; set; }
        public int totalUsers { get; set; }
        public int monthlyEarnings { get; set; }
        public int annualEarnings { get; set; }
    }
}
