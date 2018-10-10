using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SportsbookAPI.Web.Models;

namespace SportsbookAPI.Web.Repository
{
    public class StadiumsRepository
    {
        private int _idCounter;
        private readonly ICollection<Stadium> _stadiums;

        public StadiumsRepository()
        {
            this._idCounter = 1;
            this._stadiums = new List<Stadium>();

            this.Init();
        }

        private void Init()
        {
            this.AddStadium(new Stadium
            {
                Id = 1,
                Name = "Wembley Stadium",
            });
        }

        public IEnumerable<Stadium> GetStadiums()
        {
            return _stadiums.ToList();
        }

        public int AddStadium(Stadium s)
        {
            if (_stadiums.Count > 10)
            {
                throw new OperationCanceledException("Too much stadiums");
            }

            s.Id = _idCounter++;
            _stadiums.Add(s);

            return s.Id;
        }

        public void Delete(int id)
        {
            var stadium = _stadiums.SingleOrDefault(s => s.Id == id);
            if (stadium == null)
            {
                throw new OperationCanceledException();
            }

            _stadiums.Remove(stadium);
        }
    }
}
