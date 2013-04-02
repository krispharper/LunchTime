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
    public partial class AddRestaurant : Form
    {
        public string NewName
        {
            get
            {
                return this.txtBoxName.Text;
            }
        }

        public AddRestaurant()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddRestaurant_Load(object sender, EventArgs e)
        {
            this.txtBoxName.Select();
        }
    }
}
