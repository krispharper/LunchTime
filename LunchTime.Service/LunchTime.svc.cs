using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LunchTime.Service
{
    public class LunchTime : ILunchTime
    {
        public List<ArrivalTime> GetArrivalTimes()
        {
            return (new DataClassesDataContext()).ArrivalTimes.ToList();
        }

        public List<Restaurant> GetRestaurants()
        {
            return (new DataClassesDataContext()).Restaurants.ToList();
        }

        public void InsertArrivalTimes(IEnumerable<ArrivalTime> arrivalTimes)
        {
            var database = new DataClassesDataContext();
            database.ArrivalTimes.InsertAllOnSubmit(arrivalTimes);
            database.SubmitChanges();
        }
    }
}
