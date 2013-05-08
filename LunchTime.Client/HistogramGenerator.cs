using System;
using System.Collections.Generic;
using System.Linq;

namespace LunchTime.Client
{
    class HistogramGenerator
    {
        private IEnumerable<TimeSpan> Data
        {
            get;
            set;
        }

        private IEnumerable<Double> WorkingData
        {
            get { return this.Data.Select(datum => (double)datum.Ticks); }
        }

        private long Range
        {
            get { return (this.Data.Max() - this.Data.Min()).Ticks; }
        }

        private double InterQuartileRange
        {
            get;
            set;
        }

        private double BucketSize
        {
            // http://en.wikipedia.org/wiki/Freedman-Diaconis_rule

            get { return 2 * this.InterQuartileRange * Math.Pow((double)this.Data.Count(), -1 / 3.0); }
        }

        public HistogramGenerator(IEnumerable<TimeSpan> data)
        {
            this.Data = data.OrderBy(datum => datum);
            this.InterQuartileRange = this.GetQuartile(0.75) - this.GetQuartile(0.25); 
        }

        public TimeSpan GetHistogramBucket(TimeSpan time)
        {
            double proportion = (time - this.Data.Min()).Ticks / ((double)this.Range);
            int buckets = (int)(this.Range / this.BucketSize);
            return new TimeSpan((long)((int)(buckets * proportion) * this.BucketSize)) + this.Data.Min();
        }

        private double GetQuartile(double quartile)
        {
            double index = quartile * (this.WorkingData.Count() + 1);
            double remainder = index % 1;
            index = Math.Floor(index) - 1;

            if (remainder == 0)
            {
                return this.WorkingData.ElementAt((int)index);
            }
            else
            {
                double value = this.WorkingData.ElementAt((int)index);
                double interpolationValue = (this.WorkingData.ElementAt((int)index + 1) - value) * remainder;

                return value + interpolationValue;
            }
        }
    }
}
