using EventReservation.Core.DTO;
using EventReservation.Core.Repository;
using EventReservation.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventReservation.Infra.Service
{
    public class ChartService : IChartService
    {
        private readonly IChartRepository _chartRepository;
        public ChartService(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }


        public List<HallsCountByUsageDTO> HallsCountUsage()
        {
            return _chartRepository.HallsCountUsage();
        }

        public List<EventsCountByStatusDTO> GetEventCountByStatus()
        {
            return _chartRepository.GetEventCountByStatus();
        }

        public List<EventsCountMonthDTO> GetEventsCountMonth()
        {
            return _chartRepository.GetEventsCountMonth();
        }

        public List<UserCountOnAgeDTO> GetUserCountOnAge()
        {
            return _chartRepository.GetUserCountOnAge();
        }

        public List<ChartEarningsDTO> GetEarnings()
        {
            return _chartRepository.GetEarnings();
        }
    }
}
