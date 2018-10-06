using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsbookAPI.Web.Models
{
    public class SportsbookEvent
    {
        /// <summary>
        /// Uniq identifier of event
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date and time of the event's start
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Publicly displayable title of the event
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identifier of the stadium which hosts the event
        /// </summary>
        public int StadiumId { get; set; }
    }
}
