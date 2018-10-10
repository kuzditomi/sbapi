using System;
using System.Collections.Generic;
using System.Linq;
using SportsbookAPI.Web.Models;

namespace SportsbookAPI.Web.Repository
{
    public class EventsRepository
    {
        private int _idCounter;
        private readonly ICollection<SportsbookEvent> _events;

        public EventsRepository()
        {
            this._idCounter = 1;
            this._events = new List<SportsbookEvent>();

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
            return _events.ToList();
        }

        public int AddEvent(SportsbookEvent e)
        {
            if (_events.Count > 10)
            {
                throw new OperationCanceledException("Too much events");
            }

            e.Id = _idCounter++;
            _events.Add(e);

            return e.Id;
        }

        public void Delete(int id)
        {
            var evt = _events.SingleOrDefault(e => e.Id == id);
            if (evt == null)
            {
                throw new OperationCanceledException();
            }

            _events.Remove(evt);
        }
    }
}
