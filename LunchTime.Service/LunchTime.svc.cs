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

        public void InsertArrivalTime(string name, DateTime time)
        {
            var database = new DataClassesDataContext();
            Restaurant restaurant = database.Restaurants.FirstOrDefault(r => r.Name == name);

            if (restaurant == default(Restaurant))
                return;

            var arrivalTime = new ArrivalTime();
            arrivalTime.TimeArried = time;
            arrivalTime.Restaurant = restaurant;
            database.ArrivalTimes.InsertOnSubmit(arrivalTime);
            database.SubmitChanges();
        }

        public void InsertRestaurant(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            var database = new DataClassesDataContext();

            if (database.Restaurants.FirstOrDefault(r => r.Name == name) != default(Restaurant))
                return;

            var restaurant = new Restaurant();
            restaurant.Name = name;
            database.Restaurants.InsertOnSubmit(restaurant);
            database.SubmitChanges();
        }
    }
}
