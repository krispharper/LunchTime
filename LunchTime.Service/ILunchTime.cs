using System;
using System.Collections.Generic;
using System.ServiceModel;
using LunchTime.Service.DataTransferObjects;

namespace LunchTime.Service
{
    [ServiceContract]
    public interface ILunchTime
    {
        [OperationContract]
        List<TimeSpan> GetArrivalTimes(string restaurant);

        [OperationContract]
        List<RestaurantData> GetRestaurants();

        [OperationContract]
        Statistic GetStatistic(string restaurant);

        [OperationContract]
        void InsertArrivalTimes(IEnumerable<ArrivalTimeData> arrivalTimes);
    }
}
