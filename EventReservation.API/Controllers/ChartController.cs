using EventReservation.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace EventReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly IChartService _chartService;


        public ChartController(IChartService chartService)
        {
            _chartService = chartService;
        }




        [HttpGet]
        [Route("HallsCountUsage")]
        public IActionResult HallsCountUsage()
        {
            var result = _chartService.HallsCountUsage();
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);

        }


        [HttpGet]
        [Route("EventsCountStatus")]
        public IActionResult GetEventCountByStatus()
        {
            var result = _chartService.GetEventCountByStatus();
            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);

        }

        [HttpGet]
        [Route("EventsCountMonths")]
        public IActionResult GetEventsCountMonth()
        {
            var result = _chartService.GetEventsCountMonth();
            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);

        }


        [HttpGet]
        [Route("UserCountOnAge")]
        public IActionResult GetUserCountOnAge()
        {
            var result = _chartService.GetUserCountOnAge();
            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);

        }


        [HttpGet]
        [Route("GetEarnings")]
        public IActionResult GetEarnings()
        {
            var result = _chartService.GetEarnings();
            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);

        }
    }
}
