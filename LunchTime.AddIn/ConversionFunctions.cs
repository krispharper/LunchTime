using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunchTime.AddIn
{
    public static class ConversionFunctions
    {
        public static LunchTimeService.ArrivalTimeData ConvertToDto(this ArrivalTime arrivalTime)
        {
            var result = new LunchTimeService.ArrivalTimeData();
            var restaurant = new LunchTimeService.RestaurantData();
            restaurant.Name = arrivalTime.Restaurant;
            result.Restaurant = restaurant;
            result.TimeArrived = arrivalTime.TimeArrived;
            return result;
        }
    }
}
