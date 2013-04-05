using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LunchTime.Service.DataTransferObjects
{
    [DataContract]
    public class RestaurantData
    {
        [DataMember]
        public String Name
        {
            get;
            set;
        }

        public RestaurantData(Restaurant restaurant)
        {
            this.Name = restaurant.Name;
        }
    }
}