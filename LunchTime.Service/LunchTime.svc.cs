using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using LunchTime.Service.DataTransferObjects;

namespace LunchTime.Service
{
    public class LunchTime : ILunchTime
    {
        public List<TimeSpan> GetArrivalTimes(string restaurant)
        {
            using (var database = new DataClassesDataContext())
            {
                return database.ArrivalTimes
                               .Where(at => at.Restaurant.Name == restaurant)
                               .Select(at => at.Time.Value)
                               .ToList();
            }
        }

        public List<RestaurantData> GetRestaurants()
        {
            using (var database = new DataClassesDataContext())
            {
                return database.Restaurants.Select(r => new RestaurantData(r)).ToList();
            }
        }

        public StatisticData GetStatistic(string restaurant)
        {
            using (var database = new DataClassesDataContext())
            {
                return database.Statistics
                               .Where(s => s.Name == restaurant)
                               .Select(s => new StatisticData(s))
                               .First();
            }
        }

        public List<StatisticData> GetStatistics()
        {
            using (var database = new DataClassesDataContext())
            {
                return database.Statistics
                               .OrderBy(s => s.Name)
                               .Select(s => new StatisticData(s))
                               .ToList();
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
