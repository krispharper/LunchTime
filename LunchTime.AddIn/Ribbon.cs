using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Outlook;

namespace LunchTime.AddIn
{
    public partial class Ribbon
    {
        private void addTimes_Click(object sender, RibbonControlEventArgs e)
        {

            try
            {
                Selection selectedItems = Globals.ThisAddIn.Application.ActiveExplorer().Selection;

                if (selectedItems.OfType<MailItem>().Count() < 1)
                {
                    MessageBox.Show("Please select at least one mail item to use this function.");
                    return;
                }

                string pattern = "If you ordered from (.*),.*";

                var items = selectedItems
                                .Cast<MailItem>()
                                .Where(item => Regex.IsMatch(item.Subject, pattern, RegexOptions.IgnoreCase))
                                .Select(item => new
                                {
                                   restaurant = Regex.Match(item.Subject, pattern, RegexOptions.IgnoreCase).Groups[1].Value,
                                   arrivalTime = item.SentOn,
                                   ID = item.EntryID
                                })
                                .Select(item => new ArrivalTime(item.restaurant, item.arrivalTime, item.ID));

                if (items.Count() < 1)
                {
                    MessageBox.Show("No arrival time messages found in Inbox.");
                    return;
                }

                ConfirmationWindow window = new ConfirmationWindow(items);
                window.ShowDialog();

                if (window.DialogResult == DialogResult.OK)
                {
                    selectedItems
                        .Cast<MailItem>()
                        .Where(item => window.ArrivalTimes.Select(at => at.ID)
                        .Contains(item.EntryID))
                        .ToList()
                        .ForEach(item => item.Delete());
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
