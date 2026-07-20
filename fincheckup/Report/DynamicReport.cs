using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UI.CrossTab;
using fincheckup.Helper.Report;
using System;
using System.Drawing;

namespace fincheckup.Report
{
    public partial class DynamicReport : DevExpress.XtraReports.UI.XtraReport
    {
        public DynamicReport(RiskData datachk, RiskDataColor rdColor)
        {
            InitializeComponent();


            FillReportData(datachk, rdColor);
        }
 
        private void FillReportData(RiskData data, RiskDataColor rdColor)
        {
            FillCariRates(data.CariRate, "xrRisk", "xrCariOranLabel", data.CariRatePoint);
            FillCariRates(data.TotalDebttoEquityRatio, "xrToplamBorc", "xrToplamBorcLabel", data.TotalDebttoEquityRatioPoint);
            FillCariRates(data.LiquidityRatio, "xrLikidite", "xrLikiditeLabel", data.LiquidityRatioPoint);
            FillCariRates(data.TotalDebttoEquityRatio, "xrDevirHizi", "xrDevirHiziLabel", data.TotalDebttoEquityRatioPoint);
            FillCariRates(data.CashAssetRatio, "xrNakit", "xrNakitLabel", data.CashAssetRatioPoint);
            FillCariRates(data.Equity, "xrAktif", "xrAktifLabel", data.EquityPoint);

            FillSektorelRates(rdColor.ncheck1, "xrCellBnkYabKynk", rdColor.ncheck1Point);
            FillSektorelRates(rdColor.ncheck2, "xrCellBnkAktif", rdColor.ncheck2Point);
            FillSektorelRates(rdColor.ncheck3, "xrCellDuranOkynk", rdColor.ncheck3Point);
            FillSektorelRates(rdColor.ncheck4, "xrCellDonenAktif", rdColor.ncheck4Point);
            FillSektorelRates(rdColor.ncheck5, "xrCellKVAktif", rdColor.ncheck5Point);
            FillSektorelRates(rdColor.ncheck6, "xrCellKVDonen", rdColor.ncheck6Point);

            FillSektorelRates(rdColor.ncheck7, "xrCellKVPasif", rdColor.ncheck7Point);
            FillSektorelRates(rdColor.ncheck8, "xrCellMaddiOzkaynak", rdColor.ncheck8Point);
            FillSektorelRates(rdColor.ncheck9, "xrCellStokAktif", rdColor.ncheck9Point);
            FillSektorelRates(rdColor.ncheck10, "xrCellUVadePasif", rdColor.ncheck10Point);
            FillSektorelRates(rdColor.ncheck11, "xrCellOKynkYbKyn", rdColor.ncheck11Point);
            FillSektorelRates(rdColor.ncheck12, "xrCellOKynkAktif", rdColor.ncheck12Point);
        }

        private void FillCariRates(float ratio, string id, string labelId,int ratioPoint)
        {
            var lastShape = new XRShape();
            for (int i = 1; i <= (int)ratioPoint; i++)
            {
                if (i >7) break;

                var shape1 = this.Report.FindControl(id + i.ToString() , true) as XRShape;
                shape1.FillColor = CheckColor(i);

                lastShape = shape1;
            }

            var label = this.Report.FindControl(labelId, true) as XRLabel;
            label.LocationF = new System.Drawing.Point((int)lastShape.LocationF.X, (int)lastShape.LocationF.Y);
            if (ratio == 0)
            {
                label.Text = ratio.ToString("n0");
            }
            else { label.Text = ratio.ToString("n2"); }
        
            label.BringToFront();
        }
        private void FillSektorelRates(float ratio, string id,  int ratioPoint)
        {
            var lastShape = new XRTableCell();
       

                var shape1 = this.Report.FindControl(id + ratioPoint.ToString(), true) as XRTableCell;
                shape1.BackColor = CheckColorSektorel(ratioPoint);
                if (ratio == 0)
                {
                    shape1.Text = ratio.ToString("n0");
                }
                else { shape1.Text = ratio.ToString("n2"); }
            
                lastShape = shape1;
            
 
        }
        public Color CheckColor(int colorpoint)
        {
            Color ncolor = new Color();

            switch (colorpoint)
            {
                case 1: return Color.FromArgb(45, 165, 84);
                case 2: return Color.FromArgb(88, 182, 75);
                case 3: return Color.FromArgb(190, 214, 58);
                case 4: return Color.FromArgb(242, 169, 42);
                case 5: return Color.FromArgb(234, 117, 44);
                case 6: return Color.FromArgb(227, 46, 44);
                case 7: return Color.FromArgb(169, 32, 28);
                default:
                    break;
            }

            return ncolor;

        }
        public Color CheckColorSektorel(int colorpoint)
        {
            Color ncolor = new Color();

            switch (colorpoint)
            {
                case 1: return Color.FromArgb(88, 183, 75);
                case 2: return Color.FromArgb(189, 214, 58);
                case 3: return Color.FromArgb(242, 168, 43);
                case 4: return Color.FromArgb(229, 113, 43);
                case 5: return Color.FromArgb(230, 52, 43); 
                default:
                    break;
            }

            return ncolor;

        }
        public int CheckSize { get; set; }
        private void xrCrossTab1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CheckSize == 1)
            {
                xrCrossTabCellDuranOkynk.WidthF = 529;
                xrCrossTabCellDonenAktif.WidthF = 529;
                crossTabHeaderCellMain.WidthF = 529;
                xrCrossTabCell4Main.WidthF = 529;
                xrCrossTabCell57Main.WidthF = 529;
                xrCrossTabCell65Main.WidthF = 529;
                xrCrossTabCellKVAktif.WidthF = 529;
                xrCrossTabCellKVDonen.WidthF = 529;

                xrCrossTabCellRasio.WidthF = 529; 
                xrCrossTabCellSermaye.WidthF = 529;
                xrCrossTabCellLikidite.WidthF = 529;
                xrCrossTabCellBorcOdeme.WidthF = 529;
                xrCrossTabCellKrlk.WidthF = 529;
                xrCrossTabCellBilancoGenel.WidthF = 529;
                xrCrossTabCellYukumluluk.WidthF = 529;
                xrCrossTabCellOKynkAktif.WidthF = 529;
                xrCrossTabCellOKynkYbKyn.WidthF = 529;
                xrCrossTabCellUVadePasif.WidthF = 529;
                xrCrossTabCellStokAktif.WidthF = 529;
                xrCrossTabCellMaddiOzkaynak.WidthF = 529;
                xrCrossTabCellKVPasif.WidthF = 529;
            }
            else if (CheckSize == 2)
            {
                xrCrossTabCellDuranOkynk.WidthF = 415;
                xrCrossTabCellDonenAktif.WidthF = 415;
                crossTabHeaderCellMain.WidthF = 415;
                xrCrossTabCell4Main.WidthF = 415; xrCrossTabCell57Main.WidthF = 415; xrCrossTabCell65Main.WidthF = 415;
                xrCrossTabCellKVAktif.WidthF = 415;
                xrCrossTabCellKVDonen.WidthF = 415;
                xrCrossTabCellRasio.WidthF = 415;
                xrCrossTabCellSermaye.WidthF = 415;
                xrCrossTabCellLikidite.WidthF = 415;
                xrCrossTabCellBorcOdeme.WidthF = 415;
                xrCrossTabCellKrlk.WidthF = 415;
                xrCrossTabCellBilancoGenel.WidthF = 415;
                xrCrossTabCellYukumluluk.WidthF = 415;
                xrCrossTabCellOKynkAktif.WidthF = 415;
                xrCrossTabCellOKynkYbKyn.WidthF = 415;
                xrCrossTabCellUVadePasif.WidthF = 415;
                xrCrossTabCellStokAktif.WidthF = 415;
                xrCrossTabCellMaddiOzkaynak.WidthF = 415;
                xrCrossTabCellKVPasif.WidthF = 415;
            }
            else if (CheckSize >= 3)
            {
                
                xrCrossTabCellDuranOkynk.WidthF = 243;
                xrCrossTabCellDonenAktif.WidthF = 243;
                crossTabHeaderCellMain.WidthF = 243;
                xrCrossTabCellKVAktif.WidthF = 243;
                xrCrossTabCellKVDonen.WidthF = 243;
                xrCrossTabCell4Main.WidthF = 243; xrCrossTabCell57Main.WidthF = 243; xrCrossTabCell65Main.WidthF = 243;
                xrCrossTabCellRasio.WidthF = 243;
                xrCrossTabCellSermaye.WidthF = 243;
                xrCrossTabCellLikidite.WidthF = 243;
                xrCrossTabCellBorcOdeme.WidthF = 243;
                xrCrossTabCellKrlk.WidthF = 243;
                xrCrossTabCellBilancoGenel.WidthF = 243;
                xrCrossTabCellYukumluluk.WidthF = 243;

                xrCrossTabCellOKynkAktif.WidthF = 243;
                xrCrossTabCellOKynkYbKyn.WidthF = 243;
                xrCrossTabCellUVadePasif.WidthF = 243;
                xrCrossTabCellStokAktif.WidthF = 243;
                xrCrossTabCellMaddiOzkaynak.WidthF = 243;
                xrCrossTabCellKVPasif.WidthF = 243;
            }
            XRCrossTab crossTab = sender as XRCrossTab;

            //ctcCategoryName.ColumnAutoWidthMode = AutoSizeMode.None;
            //ctcContactName.ColumnAutoWidthMode = AutoSizeMode.None;
            //ctcGrandTotal.ColumnAutoWidthMode = AutoSizeMode.None;

            float availableWidth = crossTab.RootReport.PageWidth - crossTab.RootReport.Margins.Left - crossTab.RootReport.Margins.Right - crossTab.LocationF.X;

            //SqlDataSource ds = crossTab.DataSource as SqlDataSource;
            //int columnsCount = ds.Result[crossTab.DataMember].GroupBy(t => t["CategoryName"]).Count();

            //ctcCategoryName.WidthF = (availableWidth - ctcContactName.WidthF - ctcGrandTotal.WidthF) / columnsCount;
        }

        private void xrChart3_BoundDataChanged(object sender, EventArgs e)
        {
            //var chart = (DevExpress.XtraReports.UI.XRChart)sender;
            //Series series = chart.Series[0];
            //;
            //PointSeriesView seriesView = (PointSeriesView)series.View;
            //// Assign Cyan color  

            //seriesView.PointMarkerOptions.Kind = MarkerKind.Circle;
            //seriesView.PointMarkerOptions.BorderColor = Color.White;

            //seriesView.PointMarkerOptions.BorderVisible = true;
            //seriesView.PointMarkerOptions.FillStyle.FillMode = FillMode.Solid;
            //seriesView.PointMarkerOptions.Size = 9;


        }
    }
}
