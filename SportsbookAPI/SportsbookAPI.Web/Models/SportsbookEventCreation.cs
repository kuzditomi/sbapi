using System;
using System.ComponentModel.DataAnnotations;

namespace SportsbookAPI.Web.Models
{
    public class SportsbookEventCreation
    {
        /// <summary>
        /// Date and time of the event's start
        /// </summary>
        [Required]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Publicly displayable title of the event
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Identifier of the stadium which hosts the event
        /// </summary>
        [Required]
        public int StadiumId { get; set; }
    }
}
