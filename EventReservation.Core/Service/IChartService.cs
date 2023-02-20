using EventReservation.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventReservation.Core.Service
{
    public interface IChartService
    {
        List<HallsCountByUsageDTO> HallsCountUsage();
        List<EventsCountByStatusDTO> GetEventCountByStatus();
        List<EventsCountMonthDTO> GetEventsCountMonth();
        List<UserCountOnAgeDTO> GetUserCountOnAge();
        List<ChartEarningsDTO> GetEarnings();
    }
}
