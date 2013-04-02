using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunchTime.AddIn
{
    public class ArrivalTime
    {
        public string Restaurant
        {
            get;
            set;
        }

        public DateTime Time
        {
            get;
            set;
        }

        public String ID
        {
            get;
            set;
        }

        public ArrivalTime(string restaurant, DateTime arrivalTime, string ID)
        {
            this.Restaurant = restaurant;
            this.Time = arrivalTime;
            this.ID = ID;
        }
    }
}
