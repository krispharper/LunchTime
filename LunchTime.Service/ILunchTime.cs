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
        List<ArrivalTimeData> GetArrivalTimes(string restaurant);

        [OperationContract]
        List<RestaurantData> GetRestaurants();

        [OperationContract]
        StatisticData GetStatistic(string restaurant);

        [OperationContract]
        List<StatisticData> GetStatistics();

        [OperationContract]
        void InsertArrivalTimes(IEnumerable<ArrivalTimeData> arrivalTimes);
    }
}
