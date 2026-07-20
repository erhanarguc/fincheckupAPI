using DevExpress.XtraReports.UI;
using System;
using System.Drawing;

namespace fincheckup.Report
{
    public partial class IcDenetimVergi : DevExpress.XtraReports.UI.XtraReport
    {
        public IcDenetimVergi()
        {
            InitializeComponent();
        }

        private void tableCell30_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (GetCurrentColumnValue("ColorDescInside") != DBNull.Value)
            {
                XRTableCell label = (XRTableCell)sender;
                var supplierID = GetCurrentColumnValue<int>("ColorDescInside");

                if (supplierID == 1)
                {
                    label.BackColor = Color.FromArgb(255, 225, 93);

                }
                else if (supplierID == 2)
                {
                    label.BackColor = Color.FromArgb(234, 76, 76);
                }
                else
                {
                    label.Text = string.Empty;
                    label.BackColor = Color.Transparent;

                }
            }
        }

        private void xrTableCell1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (GetCurrentColumnValue("ColorDescTax") != DBNull.Value)
            {
                XRTableCell label = (XRTableCell)sender;
                var supplierID = GetCurrentColumnValue<int>("ColorDescTax");

                if (supplierID == 1)
                {
                    label.BackColor = Color.FromArgb(255, 225, 93);

                }
                else if (supplierID == 2)
                {
                    label.BackColor = Color.FromArgb(234, 76, 76);
                }
                else
                {
                    label.Text = string.Empty;
                    label.BackColor = Color.Transparent;
                }
            }
        }
    }
}
