using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LunchTime.Service.DataTransferObjects
{
    [DataContract]
    public partial class ArrivalTimeData
    {
        [DataMember]
        public RestaurantData Restaurant
        {
            get;
            set;
        }

        [DataMember]
        public DateTime TimeArrived
        {
            get;
            set;
        }

        public ArrivalTimeData(ArrivalTime arrivalTime)
        {
            this.Restaurant = new RestaurantData(arrivalTime.Restaurant);
            this.TimeArrived = arrivalTime.TimeArrived;
        }
    }
}