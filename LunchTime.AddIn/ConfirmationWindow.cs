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

        internal BindingList<ArrivalTime> ArrivalTimes
        {
            get { return this.gvData.DataSource as BindingList<ArrivalTime>; }
        }

        public ConfirmationWindow(IEnumerable<ArrivalTime> arrivalTimes)
        {
            InitializeComponent();
            SetUpGrid(arrivalTimes);
        }
        
        private void SetUpGrid(IEnumerable<ArrivalTime> arrivalTimes)
        {
            try
            {
                using (var service = new LunchTimeService.LunchTimeClient())
                {
                    this.Restaurants = service.GetRestaurants().Select(r => r.Name).ToList();
                }

                var cellStyle = new DataGridViewCellStyle();
                cellStyle.Format = "MM/dd/yyyy HH:mm:ss";
                this.colTime.DefaultCellStyle = cellStyle;

                gvData.AutoGenerateColumns = false;

                this.SetDataSources(arrivalTimes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SetDataSources(IEnumerable<ArrivalTime> arrivalTimes)
        {
            var dataSource = new BindingList<ArrivalTime>();

            foreach (var arrivalTime in arrivalTimes)
            {
                string restaurant = arrivalTime.Restaurant;
                var matches = this.Restaurants.Where(r => r.ToLower().Contains(restaurant.ToLower()));

                if (matches.Count() < 1)
                    this.Restaurants.Add(restaurant);
                else
                    arrivalTime.Restaurant = matches.First();

                dataSource.Add(arrivalTime);
            }

            this.colRestaurant.DataSource = this.Restaurants;
            this.gvData.DataSource = dataSource;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var service = new LunchTimeService.LunchTimeClient())
                {
                    if (this.ArrivalTimes != null)
                        service.InsertArrivalTimes(this.ArrivalTimes.Select(at => at.ConvertToDto()).ToArray());
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

        private void gvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyDown += (s, e2) =>
            {
                if (gvData.CurrentCell.ColumnIndex == 0)
                {
                    if (e2.KeyCode == Keys.Delete)
                    {
                        foreach (DataGridViewRow row in gvData.SelectedRows)
                        {
                            gvData.Rows.Remove(row);
                        }
                    }
                }
            };
        }
    }
}
