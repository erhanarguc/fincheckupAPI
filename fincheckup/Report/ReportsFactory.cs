using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;

namespace fincheckup.Report
{
    public static class ReportsFactory
    {
        public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>()
        {
            ["TestReport"] = () => new KontrolRaporu()
        };
    }
}
