using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsbookAPI.Web.Models;
using SportsbookAPI.Web.Repository;

namespace SportsbookAPI.Web.Controllers
{
    [Route("api/stadiums")]
    [Authorize]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly StadiumsRepository _stadiumsRepository;

        public StadiumController(StadiumsRepository stadiumsRepository)
        {
            this._stadiumsRepository = stadiumsRepository;
        }

        /// <summary>
        /// Returns stadiums in system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<Stadium>), 200)]
        public ActionResult Get()
        {
            var stadiums = _stadiumsRepository.GetStadiums();

            return Ok(stadiums);
        }

        /// <summary>
        /// Creates new stadium
        /// </summary>
        /// <param name="stadium"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(int), 204)]
        [ProducesResponseType(typeof(string), 400)]
        public ActionResult Create(StadiumCreateModel stadium)
        {
            try
            {
                var id = _stadiumsRepository.AddStadium(new Stadium(stadium));
                return Ok(id);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(400, "Too much stadiums in the system, please delete some.");
            }
        }

        /// <summary>
        /// Deletes event
        /// </summary>
        /// <param name="id">Identifier of stadium to delete</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(int), 204)]
        [ProducesResponseType(typeof(string), 400)]
        public ActionResult Delete(int id)
        {
            try
            {
                _stadiumsRepository.Delete(id);
                return NoContent();
            }
            catch (OperationCanceledException)
            {
                return StatusCode(400, $"No stadium in the system with id {id}.");
            }
        }
    }
}
