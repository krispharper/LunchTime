using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace LunchTime.AddIn
{
    public partial class Ribbon
    {
        private void addTimes_Click(object sender, RibbonControlEventArgs e)
        {
            using (var service = new LunchTimeService.LunchTimeClient())
            {
                IEnumerable<string> restaurants = service.GetRestaurants().Select(restaurant => restaurant.Name);
                System.Windows.Forms.MessageBox.Show(String.Join("\n", restaurants));
            }
        }
    }
}
