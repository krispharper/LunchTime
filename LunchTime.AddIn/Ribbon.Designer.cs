namespace LunchTime.AddIn
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabFolder = this.Factory.CreateRibbonTab();
            this.lunchTime = this.Factory.CreateRibbonGroup();
            this.addTimes = this.Factory.CreateRibbonButton();
            this.tabFolder.SuspendLayout();
            this.lunchTime.SuspendLayout();
            // 
            // tabFolder
            // 
            this.tabFolder.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabFolder.ControlId.OfficeId = "TabFolder";
            this.tabFolder.Groups.Add(this.lunchTime);
            this.tabFolder.Label = "TabFolder";
            this.tabFolder.Name = "tabFolder";
            // 
            // lunchTime
            // 
            this.lunchTime.Items.Add(this.addTimes);
            this.lunchTime.Label = "Lunch Time";
            this.lunchTime.Name = "lunchTime";
            // 
            // addTimes
            // 
            this.addTimes.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.addTimes.Label = "Add Arrival Times";
            this.addTimes.Name = "addTimes";
            this.addTimes.OfficeImageId = "StartAfterPrevious";
            this.addTimes.ShowImage = true;
            this.addTimes.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.addTimes_Click);
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.tabFolder);
            this.tabFolder.ResumeLayout(false);
            this.tabFolder.PerformLayout();
            this.lunchTime.ResumeLayout(false);
            this.lunchTime.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabFolder;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup lunchTime;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton addTimes;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
