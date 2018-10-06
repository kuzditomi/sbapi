using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SportsbookAPI.Web.Models;
using SportsbookAPI.Web.Repository;

namespace SportsbookAPI.Web.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventsRepository _eventsRepository;

        public EventsController(EventsRepository eventsRepository)
        {
            this._eventsRepository = eventsRepository;
        }
        /// <summary>
        /// Returns events in system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SportsbookEvent>), 200)]
        public ActionResult Get()
        {
            var events = _eventsRepository.GetEvents();

            return Ok(events);
        }

        /// <summary>
        /// Creates new event
        /// </summary>
        /// <param name="evt"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(int), 204)]
        [ProducesResponseType(typeof(string), 400)]
        public ActionResult Create(SportsbookEventCreation evt)
        {
            try
            {
                var id = _eventsRepository.AddEvent(new SportsbookEvent(evt));
                return Ok(id);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(400, "Too much event in the system, please delete some.");
            }
        }

        /// <summary>
        /// Deletes event
        /// </summary>
        /// <param name="id">Identifier of event to delete</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(int), 204)]
        [ProducesResponseType(typeof(string), 400)]
        public ActionResult Delete(int id)
        {
            try
            {
                _eventsRepository.Delete(id);
                return NoContent();
            }
            catch (OperationCanceledException)
            {
                return StatusCode(400, $"No event in the system with id {id}.");
            }
        }
    }
}
