using System;
using System.ComponentModel.DataAnnotations;

namespace SportsbookAPI.Web.Models
{
    public class SportsbookEvent: SportsbookEventCreation
    {
        /// <summary>
        /// Uniq identifier of event
        /// </summary>
        public int Id { get; set; }

        public SportsbookEvent()
        {

        }

        public SportsbookEvent(SportsbookEventCreation se)
        {
            this.Name = se.Name;
            this.StadiumId = se.StadiumId;
            this.StartTime = se.StartTime;
        }
    }
}
