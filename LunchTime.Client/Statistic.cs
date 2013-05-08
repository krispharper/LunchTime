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

        public Statistic(LunchTimeService.Statistic statistic)
        {
            this.Name = statistic.Name;
            this.Count = statistic.Count.GetValueOrDefault();
            this.Min = statistic.Min.GetValueOrDefault();
            this.Max = statistic.Max.GetValueOrDefault();
            this.Range = statistic.Range.GetValueOrDefault();
            this.Mean = statistic.Mean.GetValueOrDefault();
            this.StandardDeviation = statistic.StandardDeviation.GetValueOrDefault();
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
