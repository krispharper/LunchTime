using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using LunchTime.Service.DataTransferObjects;

namespace LunchTime.Service
{
    [ServiceContract]
    public interface ILunchTime
    {
        [OperationContract]
        List<ArrivalTimeData> GetArrivalTimes();

        [OperationContract]
        List<RestaurantData> GetRestaurants();

        [OperationContract]
        void InsertArrivalTimes(IEnumerable<ArrivalTimeData> arrivalTimes);
    }
}
