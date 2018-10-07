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
        private int idCounter;
        private ICollection<Stadium> stadiums;

        public StadiumsRepository()
        {
            this.idCounter = 1;
            this.stadiums = new List<Stadium>();

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
            return stadiums.ToList();
        }

        public int AddStadium(Stadium s)
        {
            if (stadiums.Count > 10)
            {
                throw new OperationCanceledException("Too much stadiums");
            }

            s.Id = idCounter++;
            stadiums.Add(s);

            return s.Id;
        }

        public void Delete(int id)
        {
            var stadium = stadiums.SingleOrDefault(s => s.Id == id);
            if (stadium == null)
            {
                throw new OperationCanceledException();
            }

            stadiums.Remove(stadium);
        }
    }
}
