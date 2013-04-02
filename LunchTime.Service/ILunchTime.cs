using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LunchTime.Service
{
    [ServiceContract]
    public interface ILunchTime
    {
        [OperationContract]
        List<ArrivalTime> GetArrivalTimes();

        [OperationContract]
        List<Restaurant> GetRestaurants();

        [OperationContract]
        void InsertArrivalTimes(IEnumerable<ArrivalTime> arrivalTimes);
    }
}
