using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SportsbookAPI.Web.Models;

namespace SportsbookAPI.Web.Repository
{
    public class EventsRepository
    {
        private int idCounter;
        private ICollection<SportsbookEvent> events;

        public EventsRepository()
        {
            this.idCounter = 1;
            this.events = new List<SportsbookEvent>();

            this.Init();
        }

        private void Init()
        {
            this.AddEvent(new SportsbookEvent
            {
                Id = 1,
                Name = "Manchester UTD - Newcastle",
                StartTime = new DateTime(2018, 10, 6, 18, 30, 0),
                StadiumId = 1
            });
        }

        public IEnumerable<SportsbookEvent> GetEvents()
        {
            return events.ToList();
        }

        public int AddEvent(SportsbookEvent e)
        {
            if (events.Count > 10)
            {
                throw new OperationCanceledException("Too much events");
            }

            e.Id = idCounter++;
            events.Add(e);

            return e.Id;
        }
    }
}
