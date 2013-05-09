using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Client
{
    public class Statistic
    {
        public string Name
        {
            get;
            set;
        }

        public int Count
        {
            get;
            set;
        }

        public TimeSpan Min
        {
            get;
            set;
        }

        public String MinFormatted
        {
            get { return FormatTimeSpan(this.Min); }
        }

        public TimeSpan Max
        {
            get;
            set;
        }

        public String MaxFormatted
        {
            get { return FormatTimeSpan(this.Max); }
        }

        public int Range
        {
            get;
            set;
        }

        public TimeSpan Mean
        {
            get;
            set;
        }

        public String MeanFormatted
        {
            get { return FormatTimeSpan(this.Mean); }
        }

        public TimeSpan StandardDeviation
        {
            get;
            set;
        }

        public String StandardDeviationFormatted
        {
            get { return FormatTimeSpan(this.StandardDeviation); }
        }

        public string ConfidenceInterval
        {
            get;
            set;
        }

        public Statistic(LunchTimeService.StatisticData statistic)
        {
            this.Name = statistic.Name;
            this.Count = statistic.Count;
            this.Min = statistic.Min;
            this.Max = statistic.Max;
            this.Range = statistic.Range;
            this.Mean = statistic.Mean;
            this.StandardDeviation = statistic.StandardDeviation;
            this.ConfidenceInterval = statistic.ConfidenceInterval;
        }

        public static string FormatTimeSpan(TimeSpan t, bool includeMilliseconds = true)
        {
            return String.Format("{0}:{1}:{2} {3}",
                                 t.Hours.ToString().PadLeft(2, '0'),
                                 t.Minutes.ToString().PadLeft(2, '0'),
                                 t.Seconds.ToString().PadLeft(2, '0'),
                                 includeMilliseconds ? t.Milliseconds.ToString().PadLeft(3, '0') : "");
        }
    }
}
