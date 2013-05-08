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
            this.Left = Properties.Settings.Default.LocationX;
            this.Top = Properties.Settings.Default.LocationY;
            this.Width = Properties.Settings.Default.Width;
            this.Height = Properties.Settings.Default.Height;

            using (var client = new LunchTimeService.LunchTimeClient())
            {
                var restaurants = client.GetRestaurants().Select(r => r.Name);
                this.restaurantsComboBox.ItemsSource = restaurants;
            }

            this.restaurantsComboBox.SelectedIndex = 0;
        }

        private void restaurantsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var client = new LunchTimeService.LunchTimeClient())
            {
                string restaurant = this.restaurantsComboBox.SelectedValue as string;
                Statistic statistic = new Statistic(client.GetStatistic(restaurant));

                if (statistic == null)
                    return;
                
                this.DataGrid.ItemsSource = (new List<Statistic> { statistic });

                var arrivalTimes = client.GetArrivalTimes(restaurant);
                var histogram = new HistogramGenerator(arrivalTimes);

                if (arrivalTimes.Count() > 1)
                {
                    this.dataSeries.ItemsSource = arrivalTimes.GroupBy(at => histogram.GetHistogramBucket(at))
                                                              .OrderBy(group => group.Key)
                                                              .Select(group => new
                                                              {
                                                                  Index = Statistic.FormatTimeSpan(group.Key, false),
                                                                  Value = group.Count()
                                                              });
                }
                else
                {
                    this.dataSeries.ItemsSource = null;
                }
            }
        }

        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.LocationX = this.Left;
            Properties.Settings.Default.LocationY = this.Top;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Height = this.Height;
            Properties.Settings.Default.Save();
        }
    }
}
