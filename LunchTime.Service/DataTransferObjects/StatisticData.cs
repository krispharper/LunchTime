using System;
using System.Runtime.Serialization;

namespace LunchTime.Service.DataTransferObjects
{
    [DataContract]
    public class StatisticData
    {
        [DataMember]
        public string Name
        {
            get;
            set;
        }

        [DataMember]
        public int Count
        {
            get;
            set;
        }

        [DataMember]
        public TimeSpan Min
        {
            get;
            set;
        }

        [DataMember]
        public TimeSpan Max
        {
            get;
            set;
        }

        [DataMember]
        public int Range
        {
            get;
            set;
        }

        [DataMember]
        public TimeSpan Mean
        {
            get;
            set;
        }

        [DataMember]
        public TimeSpan Median
        {
            get;
            set;
        }

        [DataMember]
        public TimeSpan StandardDeviation
        {
            get;
            set;
        }

        [DataMember]
        public string ConfidenceInterval
        {
            get;
            set;
        }

        public StatisticData(Statistic statistic)
        {
            this.Name = statistic.Name;
            this.Count = statistic.Count.GetValueOrDefault();
            this.Min = statistic.Min.GetValueOrDefault();
            this.Max = statistic.Max.GetValueOrDefault();
            this.Range = statistic.Range.GetValueOrDefault();
            this.Mean = statistic.Mean.GetValueOrDefault();
            this.Median = statistic.Median.GetValueOrDefault();
            this.StandardDeviation = statistic.StandardDeviation.GetValueOrDefault();
            this.ConfidenceInterval = statistic.ConfidenceInterval;
        }
    }
}