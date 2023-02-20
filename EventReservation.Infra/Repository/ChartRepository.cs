using Dapper;
using EventReservation.Core.Common;
using EventReservation.Core.DTO;
using EventReservation.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EventReservation.Infra.Repository
{
    public class ChartRepository : IChartRepository
    {
        private readonly IDbContext _dbContext;

        public ChartRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;

        }


        public List<HallsCountByUsageDTO> HallsCountUsage()
        {
            var result = _dbContext.Connection.Query<HallsCountByUsageDTO>("CHART_PACKAGE.GETHALLCOUNTBYUSAGE", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<EventsCountByStatusDTO> GetEventCountByStatus()
        {
            var result = _dbContext.Connection.Query<EventsCountByStatusDTO>("CHART_PACKAGE.GETEVENTCOUNTBYSTATUS", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }


        public  List<EventsCountMonthDTO> GetEventsCountMonth()
        {
            var result =  _dbContext.Connection.Query<EventsCountMonthDTO>("CHART_PACKAGE.GETEVENTCOUNTBYMONTHS", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<UserCountOnAgeDTO> GetUserCountOnAge()
        {
            var result = _dbContext.Connection.Query<UserCountOnAgeDTO>("CHART_PACKAGE.GETUSERCOUNTONAGE", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<ChartEarningsDTO> GetEarnings()
        {
            var result = _dbContext.Connection.Query<ChartEarningsDTO>("CHART_PACKAGE.GETEARNINGS", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}
