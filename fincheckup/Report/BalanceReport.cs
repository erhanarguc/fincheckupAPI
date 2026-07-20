using DevExpress.XtraReports.UI;
using System;

namespace fincheckup.Report
{
    public partial class BalanceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public BalanceReport()
        {
            InitializeComponent();
        }

        private void BalanceReport_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void xrTableCell1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void xrTableCell9_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = (XRTableCell)sender;
            XRShape shape = cell.Controls[0] as XRShape;
            XRShape shape1 = cell.Controls[1] as XRShape;
            if (DetailReport.GetCurrentColumnValue("IsErrored") != DBNull.Value)
            {

                var supplierID = DetailReport.GetCurrentColumnValue<bool>("IsErrored");

                if (supplierID)
                {

                    shape.Visible = false;
                    shape1.Visible = true;

                }
                else
                {

                    shape1.Visible = false;
                    shape.Visible = true;
                }

            }
        }
    }
}
