using System.Collections.Generic;
using System.ServiceModel;
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
