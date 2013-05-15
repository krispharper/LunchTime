using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LunchTime.Client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Left = Properties.Settings.Default.LocationX;
                this.Top = Properties.Settings.Default.LocationY;
                this.Width = Properties.Settings.Default.Width;
                this.Height = Properties.Settings.Default.Height;

                using (var client = new LunchTimeService.LunchTimeClient())
                {
                    var restaurants = client.GetRestaurants().Select(r => r.Name);
                    this.summaryComboBox.ItemsSource = restaurants;
                    this.detailsComboBox.ItemsSource = restaurants;

                    var statistics = client.GetStatistics();
                    this.statisticsGrid.ItemsSource = statistics.Select(s => new Statistic(s));
                }

                this.summaryComboBox.SelectedIndex = Properties.Settings.Default.SummaryIndex;
                this.detailsComboBox.SelectedIndex = Properties.Settings.Default.DetailsIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void summaryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (var client = new LunchTimeService.LunchTimeClient())
                {
                    string restaurant = this.summaryComboBox.SelectedValue as string;
                    Statistic statistic = new Statistic(client.GetStatistic(restaurant));

                    if (statistic == null)
                        return;

                    this.summaryGrid.ItemsSource = (new List<Statistic> { statistic });

                    var arrivalTimes = client.GetArrivalTimes(restaurant)
                                             .Select(at => at.TimeArrived.TimeOfDay);

                    if (arrivalTimes.Count() > 4)
                    {
                        var histogram = new HistogramGenerator(arrivalTimes);
                        this.summaryDataSeries.ItemsSource = arrivalTimes.GroupBy(at => histogram.GetHistogramBucket(at))
                                                                  .OrderBy(group => group.Key)
                                                                  .Select(group => new
                                                                  {
                                                                      Index = Statistic.FormatTimeSpan(group.Key, false),
                                                                      Value = group.Count()
                                                                  });
                    }
                    else
                    {
                        this.summaryDataSeries.ItemsSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void detailsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (var client = new LunchTimeService.LunchTimeClient())
                {
                    string restaurant = this.detailsComboBox.SelectedValue as string;
                    var arrivalTimes = client.GetArrivalTimes(restaurant)
                                             .Select(at => new
                                             {
                                                 Date = at.TimeArrived.Date,
                                                 Time = new DateTime(at.TimeArrived.TimeOfDay.Ticks)
                                             })
                                             .OrderBy(at => at.Date);

                    this.detailsDataSeries.ItemsSource = arrivalTimes;
                    this.detailsGrid.ItemsSource = arrivalTimes.Select(at => new
                                                               {
                                                                   Date = at.Date.ToString("MM.dd.yyyy"),
                                                                   Time = Statistic.FormatTimeSpan(at.Time.TimeOfDay)
                                                               })
                                                               .Reverse();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.LocationX = this.Left;
            Properties.Settings.Default.LocationY = this.Top;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Height = this.Height;
            Properties.Settings.Default.SummaryIndex = this.summaryComboBox.SelectedIndex;
            Properties.Settings.Default.DetailsIndex = this.detailsComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }
    }
}
