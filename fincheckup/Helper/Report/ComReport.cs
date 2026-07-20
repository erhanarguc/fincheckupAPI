using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using fincheckup.ENTITY;
using fincheckup.Models.Hvvn;
using fincheckup.Models.ViewM;
using fincheckup.Report;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace fincheckup.Helper.Report
{
    public static  class ComReport
    {
        public static List<ReportMainItem> ncheck;
        public static List<ReportMainItem> nchecklast;
        public static List<ReportMainItem> nchecka;
        public static List<ReportMainItem> ncheck1;
        public static List<ReportMainItem> ncheck1a;
        public static List<ReportMainItem> ncheckb;
        public static List<ReportMainItem> ncheckc;
        public static List<ReportMainItem> ncheckd;
        public static List<ReportMainItem> nchecke;
        public static List<ReportMainItem> ncheckf;
        public static List<ReportMainItem> ncheckg;
        public static List<ReportMainItem> ncheck1_;
        public static List<ReportMainItem> ncheck2;
        public static List<ReportMainItem> ncheck3;
        public static List<ReportMainItem> ncheck4;
        public static List<ReportMainItem> ncheck5;
        public static List<ReportMainItem> ncheck6;
        public static List<ReportMainItem> ncheck7;
        public static List<ReportMainItem> ncheck8;
        public static List<ReportMainItem> ncheck9;
        public static List<ReportMainItem> ncheck10;
        public static List<ReportMainItem> ncheck11;
        public static List<ReportMainItem> ncheck12;
        public static ReportKapak ncheckKapak;
        public static Color shape1;
        public static Color shape2;
        public static Color shape3;
        public static Color shape4;
        public static Color shape5;
        public static Color shape6;
        public static Color shape7;
        public static Color shape8;
        public static Color shape9;
        public static List<ReportMainChart> ncheckchart;
        public static List<ReportMainChart> ncheckchartb;
        public static List<ReportMainChart> ncheckchart1;
        public static List<ReportMainChart> ncheckchart2;
        public static List<ReportMainChart> ncheckchart3;
        public static List<ReportMainChart> ncheckchart4;
        public static List<ReportMainChart> ncheckchart5;
        public static List<ReportMainChart> ncheckchart6;
        public static List<ReportMainChart> ncheckchart7;
        public static List<ReportMainChart> ncheckchart8;
        public static List<ReportMainChart> ncheckchart9;
        public static List<ReportMainChart> ncheckchart10;
        public static List<ReportMainChart> ncheckchart11;
        public static List<ReportMainChart> ncheckchart12;
        public static IEnumerable<Companies> mreqListCompany;
        public static LineSeriesView checkSeries { get; set; }

        public static int compnacecode;
 
        public static string repchakec;
        public static string header;
        public static string nccode;

        public static ReportFinancialOverview Getreport(int nyear,Companies comp)
        {
            long companyID = comp.ID;
            compnacecode = 2790;
            if (!string.IsNullOrEmpty(comp.NaceCode) && !string.IsNullOrWhiteSpace(comp.NaceCode))
            {
                compnacecode = Convert.ToInt32(comp.NaceCode.Replace(".", "").Substring(0, 4));
            }

        
            repchakec = "Kayıtlarda Bir Sorunla Karşılaşıldı";
            header = comp.CompanyName;
            nccode = comp.NaceCode;
            ncheckKapak = ReportKapak.setKapak(MainDash.DataReportMainKapak(nyear, companyID));
            if (ncheckKapak == null)
            {
                ncheckKapak = new ReportKapak();
            }

            if (ncheckKapak.nitemCariOran.IsFailed > 0) { shape1 = Color.FromArgb(182, 33, 45); } else { shape1 = Color.FromArgb(23, 127, 117); };
            if (ncheckKapak.nitemLikitideOran.IsFailed > 0) { shape2 = Color.FromArgb(182, 33, 45); } else { shape2 = Color.FromArgb(23, 127, 117); };
            if (ncheckKapak.nitemNakitOran.IsFailed > 0) { shape3 = Color.FromArgb(182, 33, 45); } else { shape3 = Color.FromArgb(23, 127, 117); };
            if (ncheckKapak.nitemAlacakDevir.IsFailed > 0) { shape4 = Color.FromArgb(182, 33, 45); } else { shape4 = Color.FromArgb(23, 127, 117); };
            if (ncheckKapak.nitemTicariBorcDevir.IsFailed > 0) { shape5 = Color.FromArgb(182, 33, 45); } else { shape5 = Color.FromArgb(23, 127, 117); };
            if (ncheckKapak.nitemStokDevir.IsFailed > 0) { shape6 = Color.FromArgb(182, 33, 45); } else { shape6 = Color.FromArgb(23, 127, 117); };
            if (ncheckKapak.nitemBorcOzsermaye.IsFailed > 0) { shape7 = Color.FromArgb(182, 33, 45); } else { shape7 = Color.FromArgb(23, 127, 117); };
            if (ncheckKapak.nitemTpolamBankaBorc.IsFailed > 0) { shape8 = Color.FromArgb(182, 33, 45); } else { shape8 = Color.FromArgb(23, 127, 117); };
            if (ncheckKapak.nitemOzkaynakAktif.IsFailed > 0) { shape9 = Color.FromArgb(182, 33, 45); } else { shape9 = Color.FromArgb(23, 127, 117); };
            ncheck = MainDash.DataReportMain(nyear, companyID);
            nchecka = MainDash.DataReportMainA(nyear, companyID);

            ncheck1 = MainDash.DataReportMainB(nyear, companyID);
            ncheck1a = MainDash.DataReportMainC(nyear, companyID);

            ncheckd = MainDash.DataReportMainD(nyear, companyID);
            nchecke = MainDash.DataReportMainE(nyear, companyID);
            ncheckf = MainDash.DataReportMainF(nyear, companyID);
            ncheckg = MainDash.DataReportMainG(nyear, companyID);
            nchecklast = MainDash.DataReportMainT(nyear, companyID);
            ncheckb = new List<ReportMainItem>();
            //ncheckb.Add(nchecka.Where(x=>x.CounterZone==44).First());
            ncheckb.Add(ncheck.Where(x => x.CounterZone == 11).First());
            ncheckchart = MainDash.DataReportMainChartMain(ncheckb);
            ncheckc = new List<ReportMainItem>();
            ncheckc.Add(ncheck.Where(x => x.CounterZone == 1011).First());
            ncheckchartb = MainDash.DataReportMainChartMain(ncheckc);

            ncheck1_ = MainDash.DataReportMain1(nyear, companyID, compnacecode);
            ncheck2 = MainDash.DataReportMain2(nyear, companyID, compnacecode);
            ncheck3 = MainDash.DataReportMain3(nyear, companyID, compnacecode);
            ncheck4 = MainDash.DataReportMain4(nyear, companyID, compnacecode);
            ncheck5 = MainDash.DataReportMain5(nyear, companyID, compnacecode);
            ncheck6 = MainDash.DataReportMain6(nyear, companyID, compnacecode);
            ncheck7 = MainDash.DataReportMain7(nyear, companyID, compnacecode);
            ncheck8 = MainDash.DataReportMain8(nyear, companyID, compnacecode);
            ncheck9 = MainDash.DataReportMain9(nyear, companyID, compnacecode);
            ncheck10 = MainDash.DataReportMain10(nyear, companyID, compnacecode);
            ncheck11 = MainDash.DataReportMain11(nyear, companyID, compnacecode);
            ncheck12 = MainDash.DataReportMain12(nyear, companyID, compnacecode);

            ncheckchart1 = MainDash.DataReportMainChartMain(ncheck1_);
            ncheckchart2 = MainDash.DataReportMainChartMain(ncheck2);
            ncheckchart3 = MainDash.DataReportMainChartMain(ncheck3);
            ncheckchart4 = MainDash.DataReportMainChartMain(ncheck4);
            ncheckchart5 = MainDash.DataReportMainChartMain(ncheck5);
            ncheckchart6 = MainDash.DataReportMainChartMain(ncheck6);
            ncheckchart7 = MainDash.DataReportMainChartMain(ncheck7);
            ncheckchart8 = MainDash.DataReportMainChartMain(ncheck8);
            ncheckchart9 = MainDash.DataReportMainChartMain(ncheck9);
            ncheckchart10 = MainDash.DataReportMainChartMain(ncheck10);
            ncheckchart11 = MainDash.DataReportMainChartMain(ncheck11);
            ncheckchart12 = MainDash.DataReportMainChartMain(ncheck12);
            ReportFinancialOverview report = new ReportFinancialOverview();
            ObjectDataSource objectDataSource = new ObjectDataSource();
            objectDataSource.Name = "DataViewer";
            objectDataSource.DataSource = ncheck;

            objectDataSource.Fill();

            ObjectDataSource objectDataSourceA = new ObjectDataSource();
            objectDataSourceA.Name = "DataViewerA";
            objectDataSourceA.DataSource = nchecka;

            objectDataSourceA.Fill();

            ObjectDataSource objectDataSourceB = new ObjectDataSource();
            objectDataSourceB.Name = "DataViewerB";
            objectDataSourceB.DataSource = ncheck1;

            objectDataSourceB.Fill();

            ObjectDataSource objectDataSourceC = new ObjectDataSource();
            objectDataSourceC.Name = "DataViewerC";
            objectDataSourceC.DataSource = ncheck1a;

            objectDataSourceC.Fill();


            ObjectDataSource objectDataSourceD = new ObjectDataSource();
            objectDataSourceD.Name = "DataViewerD";
            objectDataSourceD.DataSource = ncheckd;

            objectDataSourceD.Fill();

            ObjectDataSource objectDataSourceE = new ObjectDataSource();
            objectDataSourceE.Name = "DataViewerE";
            objectDataSourceE.DataSource = nchecke;

            objectDataSourceE.Fill();

            ObjectDataSource objectDataSourceF = new ObjectDataSource();
            objectDataSourceF.Name = "DataViewerF";
            objectDataSourceF.DataSource = ncheckf;

            objectDataSourceF.Fill();



            ObjectDataSource objectDataSourceG = new ObjectDataSource();
            objectDataSourceG.Name = "DataViewerG";
            objectDataSourceG.DataSource = ncheckg;
            objectDataSourceG.Fill();

            ObjectDataSource objectDataSourceT = new ObjectDataSource();
            objectDataSourceT.Name = "DataViewerT";
            objectDataSourceT.DataSource = nchecklast;
            objectDataSourceT.Fill();

            checkSeries = new LineSeriesView();
            DetailReportBand detailReport = report.Bands["DetailReport"] as DetailReportBand;
            DetailReportBand detailReport1 = report.Bands["DetailReport1"] as DetailReportBand;
            DetailReportBand detailReport2 = report.Bands["DetailReport2"] as DetailReportBand;
            DetailReportBand detailReport3 = report.Bands["DetailReport4"] as DetailReportBand;


            DetailReportBand detailReport11 = report.Bands["DetailReport11"] as DetailReportBand;
            DetailReportBand detailReport12 = report.Bands["DetailReport12"] as DetailReportBand;
            DetailReportBand detailReport13 = report.Bands["DetailReport13"] as DetailReportBand;
            DetailReportBand detailReport14 = report.Bands["DetailReport14"] as DetailReportBand;
            DetailReportBand detailReport15 = report.Bands["DetailReport15"] as DetailReportBand;

            detailReport.DataSource = objectDataSource;
            detailReport1.DataSource = objectDataSourceA;
            detailReport2.DataSource = objectDataSourceB;
            detailReport3.DataSource = objectDataSourceC;

            detailReport11.DataSource = objectDataSourceD;
            detailReport12.DataSource = objectDataSourceE;
            detailReport13.DataSource = objectDataSourceF;
            detailReport14.DataSource = objectDataSourceG;
            detailReport15.DataSource = objectDataSourceT;

            var chart = (XRChart)report.FindControl("xrChart1", false);
            chart.Series.Clear();
            chart.DataSource = ncheckchart;//Method from documentation you reffered
            chart.SeriesTemplate.SeriesDataMember = "GroupName";

            chart.SeriesTemplate.Label.TextPattern = "{V:n0}";
            chart.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart.SeriesTemplate.ValueDataMembers.AddRange("Value");

            var chart1 = (XRChart)report.FindControl("xrChart2", false);
            chart1.Series.Clear();
            chart1.DataSource = ncheckchartb;//Method from documentation you reffered
            chart1.SeriesTemplate.SeriesDataMember = "GroupName";
            chart1.SeriesTemplate.Label.TextPattern = "{V:n0}";
            chart1.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart1.SeriesTemplate.ValueDataMembers.AddRange("Value");


            var chart3 = (XRChart)report.FindControl("xrChart3", false);
            chart3.Series.Clear();
            chart3.DataSource = ncheckchart1;//Method from documentation you reffered
            chart3.SeriesTemplate.SeriesDataMember = "GroupName";
            chart3.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart3.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart3.SeriesTemplate.ValueDataMembers.AddRange("Value");


            var chart4 = (XRChart)report.FindControl("xrChart4", false);
            chart4.Series.Clear();
            chart4.DataSource = ncheckchart2;//Method from documentation you reffered
            chart4.SeriesTemplate.SeriesDataMember = "GroupName";
            chart4.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart4.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart4.SeriesTemplate.ValueDataMembers.AddRange("Value");

            var chart5 = (XRChart)report.FindControl("xrChart5", false);
            chart5.Series.Clear();
            chart5.DataSource = ncheckchart3;//Method from documentation you reffered
            chart5.SeriesTemplate.SeriesDataMember = "GroupName";
            chart5.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart5.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart5.SeriesTemplate.ValueDataMembers.AddRange("Value");


            var chart6 = (XRChart)report.FindControl("xrChart6", false);
            chart6.Series.Clear();
            chart6.DataSource = ncheckchart4;//Method from documentation you reffered
            chart6.SeriesTemplate.SeriesDataMember = "GroupName";
            chart6.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart6.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart6.SeriesTemplate.ValueDataMembers.AddRange("Value");

            report.xrLabel31.Text = header;
            report.xrLabel29.Text = nccode;
            var chart7 = (XRChart)report.FindControl("xrChart7", false);
            chart7.Series.Clear();
            chart7.DataSource = ncheckchart5;//Method from documentation you reffered
            chart7.SeriesTemplate.SeriesDataMember = "GroupName";
            chart7.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart7.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart7.SeriesTemplate.ValueDataMembers.AddRange("Value");

            var chart8 = (XRChart)report.FindControl("xrChart8", false);
            chart8.Series.Clear();
            chart8.DataSource = ncheckchart6;//Method from documentation you reffered
            chart8.SeriesTemplate.SeriesDataMember = "GroupName";
            chart8.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart8.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart8.SeriesTemplate.ValueDataMembers.AddRange("Value");


            var chart9 = (XRChart)report.FindControl("xrChart9", false);
            chart9.Series.Clear();
            chart9.DataSource = ncheckchart7;//Method from documentation you reffered
            chart9.SeriesTemplate.SeriesDataMember = "GroupName";
            chart9.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart9.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart9.SeriesTemplate.ValueDataMembers.AddRange("Value");


            var chart10 = (XRChart)report.FindControl("xrChart10", false);
            chart10.Series.Clear();
            chart10.DataSource = ncheckchart8;//Method from documentation you reffered
            chart10.SeriesTemplate.SeriesDataMember = "GroupName";
            chart10.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart10.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart10.SeriesTemplate.ValueDataMembers.AddRange("Value");


            var chart11 = (XRChart)report.FindControl("xrChart11", false);
            chart11.Series.Clear();
            chart11.DataSource = ncheckchart9;//Method from documentation you reffered
            chart11.SeriesTemplate.SeriesDataMember = "GroupName";
            chart11.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart11.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart11.SeriesTemplate.ValueDataMembers.AddRange("Value");



            var chart12 = (XRChart)report.FindControl("xrChart12", false);
            chart12.Series.Clear();
            chart12.DataSource = ncheckchart10;//Method from documentation you reffered
            chart12.SeriesTemplate.SeriesDataMember = "GroupName";
            chart12.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart12.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart12.SeriesTemplate.ValueDataMembers.AddRange("Value");



            var chart13 = (XRChart)report.FindControl("xrChart13", false);
            chart13.Series.Clear();
            chart13.DataSource = ncheckchart11;//Method from documentation you reffered
            chart13.SeriesTemplate.SeriesDataMember = "GroupName";
            chart13.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart13.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart13.SeriesTemplate.ValueDataMembers.AddRange("Value");

            //Color.FromArgb(182,33,45) red
            //Color.FromArgb(23, 127, 117) greeen
            var chart14 = (XRChart)report.FindControl("xrChart14", false);
            chart14.Series.Clear();
            chart14.DataSource = ncheckchart12;//Method from documentation you reffered
            chart14.SeriesTemplate.SeriesDataMember = "GroupName";
            chart14.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart14.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart14.SeriesTemplate.ValueDataMembers.AddRange("Value");

            var xrlbl1 = (XRLabel)report.FindControl("xrLblOzkaynak", false);
            xrlbl1.Text = ncheckKapak.nitemOzkaynakAktif.TumYil.ToString("N2");

            var xrlbl2 = (XRLabel)report.FindControl("xrlblCarioran", false);
            xrlbl2.Text = ncheckKapak.nitemCariOran.TumYil.ToString("N2");


            var xrlbl3 = (XRLabel)report.FindControl("xrlblROA", false);
            xrlbl3.Text = (ncheckKapak.nitemROAAktifKarlilik.TumYil * 100).ToString("N2") + "%";

            //var xrlbl4 = (XRLabel)report.FindControl("xrlblNetsatbuyume", false);
            //xrlbl4.Text = ncheckKapak.nitemNetSatisBuyumeOran.TumYil.ToString("N2");

            var xrlbl5 = (XRLabel)report.FindControl("xrlblAltmanZ", false);
            xrlbl5.Text = ncheckKapak.nitemAltmanz.TumYil.ToString("N2");


            var xrlbl6 = (XRLabel)report.FindControl("xrlblNetIsletmeSerm", false);
            xrlbl6.Text = ncheckKapak.nitemNetIsletmeSermaye.TumYil.ToString("N0");


            var xrlbl7 = (XRLabel)report.FindControl("xrlblFaizVeVergi", false);
            xrlbl7.Text = ncheckKapak.nitemFaizVergiOncesiKarZarar.TumYil.ToString("N2");



            var xrlbl8 = (XRLabel)report.FindControl("xrCaritablo", false);
            xrlbl8.Text = ncheckKapak.nitemCariOran.TumYil.ToString("N2");


            var xrlbl9 = (XRLabel)report.FindControl("xrLikiditetablo", false);
            xrlbl9.Text = ncheckKapak.nitemLikitideOran.TumYil.ToString("N2");

            var xrlbl10 = (XRLabel)report.FindControl("xrNakittablo", false);
            xrlbl10.Text = ncheckKapak.nitemNakitOran.TumYil.ToString("N2");





            var xrlbl14 = (XRLabel)report.FindControl("xrtoplamborcsermtablo", false);
            xrlbl14.Text = ncheckKapak.nitemBorcOzsermaye.TumYil.ToString("N2");

            var xrlbl15 = (XRLabel)report.FindControl("xrtoplambankaborcdevirtablo", false);
            xrlbl15.Text = ncheckKapak.nitemTpolamBankaBorc.TumYil.ToString("N2");

            var xrlbl16 = (XRLabel)report.FindControl("xrOzaynakaktifktablo", false);
            xrlbl16.Text = ncheckKapak.nitemOzkaynakAktif.TumYil.ToString("N2");

            var gauget = (XRGauge)report.FindControl("xrGauge1", false);
            gauget.TargetValue = ncheckKapak.nitemAltmanz.TumYil;

            var rShape1 = (XRShape)report.FindControl("xrShape1", false);
            rShape1.BackColor = shape1;

            var rShape2 = (XRShape)report.FindControl("xrShape2", false);
            rShape2.BackColor = shape2;

            var rShape3 = (XRShape)report.FindControl("xrShape3", false);
            rShape3.BackColor = shape3;



            var rShape7 = (XRShape)report.FindControl("xrShape7", false);
            rShape7.BackColor = shape7;

            var rShape8 = (XRShape)report.FindControl("xrShape8", false);
            rShape8.BackColor = shape8;

            var rShape9 = (XRShape)report.FindControl("xrShape9", false);
            rShape9.BackColor = shape9;

            return report;
        }
    }
}
