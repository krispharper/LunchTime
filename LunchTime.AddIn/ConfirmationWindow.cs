using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LunchTime.AddIn
{
    public partial class ConfirmationWindow : Form
    {
        internal List<string> Restaurants
        {
            get;
            set;
        }

        internal List<ArrivalTime> ArrivalTimes
        {
            get { return this.gvData.DataSource as List<ArrivalTime>; }
        }

        public ConfirmationWindow(IEnumerable<ArrivalTime> arrivalTimes)
        {
            if (arrivalTimes.Count() < 1)
            {
                MessageBox.Show("No arrival time messages found in Inbox.");
                this.Close();
            }

            InitializeComponent();

            SetUpGrid(arrivalTimes);
        }
        
        private void SetUpGrid(IEnumerable<ArrivalTime> arrivalTimes)
        {
            using (var service = new LunchTimeService.LunchTimeClient())
            {
                this.Restaurants = service.GetRestaurants().Select(restaurant => restaurant.Name).ToList();
            }

            this.UpdateRestaurantList(arrivalTimes);

            this.colRestaurant.DataSource = this.Restaurants;

            var cellStyle = new DataGridViewCellStyle();
            cellStyle.Format = "MM/dd/yyyy HH:mm:ss";
            this.colTime.DefaultCellStyle = cellStyle;

            gvData.AutoGenerateColumns = false;
            gvData.DataSource = arrivalTimes.ToList();
        }

        private void UpdateRestaurantList(IEnumerable<ArrivalTime> arrivalTimes)
        {
            foreach (string restaurant in arrivalTimes.Select(time => time.Restaurant))
            {
                if (this.Restaurants.Where(r => r.ToLower().Contains(restaurant.ToLower())).Count() < 1)
                    this.Restaurants.Add(restaurant);
            }
        }

        private static LunchTimeService.ArrivalTime ConvertArrivalTimes(ArrivalTime time)
        {
            var result = new LunchTimeService.ArrivalTime();
            var restaurant = new LunchTimeService.Restaurant();
            restaurant.Name = time.Restaurant;
            result.Restaurant = restaurant;
            result.TimeArrived = time.Time;
            return result;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (var service = new LunchTimeService.LunchTimeClient())
            {
                var arrivalTimes = this.gvData.DataSource as List<ArrivalTime>;

                if (arrivalTimes != null)
                    service.InsertArrivalTimes(arrivalTimes.Select(at => ConvertArrivalTimes(at)).ToArray());
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddRestaurant_Click(object sender, EventArgs e)
        {
            AddRestaurant window = new AddRestaurant();
            window.ShowDialog(this);

            if (window.DialogResult == DialogResult.OK)
            {
                this.colRestaurant.DataSource = null;
                this.Restaurants.Add(window.NewName);
                this.colRestaurant.DataSource = this.Restaurants;
            }
        }

        private void gvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void gvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = gvData.CurrentCell as DataGridViewComboBoxCell;

            if (cell != null)
            {
                gvData.BeginEdit(true);
            }
        }

        private void gvData_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            gvData.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
