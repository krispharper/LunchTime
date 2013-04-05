using System.Collections.Generic;
using System.Linq;
using LunchTime.Service.DataTransferObjects;

namespace LunchTime.Service
{
    public class LunchTime : ILunchTime
    {
        public List<ArrivalTimeData> GetArrivalTimes()
        {
            using (var database = new DataClassesDataContext())
            {
                return database.ArrivalTimes.Select(at => new ArrivalTimeData(at)).ToList();
            }
        }

        public List<RestaurantData> GetRestaurants()
        {
            using (var database = new DataClassesDataContext())
            {
                return database.Restaurants.Select(r => new RestaurantData(r)).ToList();
            }
        }

        public void InsertArrivalTimes(IEnumerable<ArrivalTimeData> arrivalTimes)
        {
            using (var database = new DataClassesDataContext())
            {
                foreach (var arrivalTime in arrivalTimes)
                {
                    var result = new ArrivalTime();
                    database.ArrivalTimes.InsertOnSubmit(result);

                    var restaurant = database.Restaurants.FirstOrDefault(r => r.Name == arrivalTime.Restaurant.Name);

                    if (restaurant == default(Restaurant))
                    {
                        restaurant = new Restaurant();
                        restaurant.Name = arrivalTime.Restaurant.Name;
                        database.Restaurants.InsertOnSubmit(restaurant);
                    }

                    result.Restaurant = restaurant;
                    result.TimeArrived = arrivalTime.TimeArrived;
                    database.ArrivalTimes.InsertOnSubmit(result);
                }

                database.SubmitChanges();
            }
        }
    }
}
