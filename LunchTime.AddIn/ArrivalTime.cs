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

        public DateTime TimeArrived
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
            this.TimeArrived = arrivalTime;
            this.ID = ID;
        }

        public ArrivalTime(LunchTimeService.ArrivalTimeData arrivalTime)
        {
            this.Restaurant = arrivalTime.Restaurant.Name;
            this.TimeArrived = arrivalTime.TimeArrived;
        }
    }
}
