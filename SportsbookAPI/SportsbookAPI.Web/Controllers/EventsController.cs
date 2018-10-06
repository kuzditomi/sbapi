using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SportsbookAPI.Web.Models;

namespace SportsbookAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        /// <summary>
        /// Returns events in system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SportsbookEvent>), 200)]
        public ActionResult<IEnumerable<string>> Get()
        {
            var events = new List<SportsbookEvent>
            {
                new SportsbookEvent
                {
                    Id = 1,
                    Name = "Manchester UTD - Newcastle",
                    StartTime = new DateTime(2018, 10, 6, 18, 30, 0),
                    StadiumId = 1
                }
            };

            return Ok(events);
        }
    }
}
