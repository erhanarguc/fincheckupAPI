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
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;
using System.Linq;
using fincheckup.Models.NKolay.ViewM;
using System.Threading;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using CsvHelper;
using DevExpress.ClipboardSource.SpreadsheetML;
using fincheckup.Models.AImodel;
using fincheckup.Models.NKolay;

namespace fincheckup.Helper.Report
{
    public static class ReportCheckZoneMain
    {
        public static RiskDataColor rdColor { get; set; }
        public static RiskData riskdatachk { get; set; }
        public static RiskData riskdata { get; set; }
        public static long UserID { get; set; }
        public static int YearCount { get; set; }
        public static LineSeriesView checkSeries { get; set; }
        public static List<ReportMainItem> ncheck { get; set; }
        public static List<ReportMainItem> nchecklast { get; set; }
        public static List<ReportMainItem> nchecka { get; set; }
        public static List<ReportMainItem> ncheck1 { get; set; }
        public static List<ReportMainItem> ncheck1a { get; set; }
 
        public static List<ReportMainItem> ncheckb { get; set; }
        public static List<ReportMainItem> ncheckc { get; set; }
        public static List<ReportMainItem> ncheckd{ get; set; }
        public static List<ReportMainItem> nchecke{ get; set; }
        public static List<ReportMainItem> ncheckf{ get; set; }
        public static List<ReportMainItem> ncheckg{ get; set; }
        public static List<ReportMainItem> ncheck1_{ get; set; }
        public static List<ReportMainItem> ncheck2{ get; set; }
        public static List<ReportMainItem> ncheck3{ get; set; }
        public static List<ReportMainItem> ncheck4{ get; set; }
        public static List<ReportMainItem> ncheck5{ get; set; }
        public static List<ReportMainItem> ncheck6{ get; set; }
        public static List<ReportMainItem> ncheck7{ get; set; }
        public static List<ReportMainItem> ncheck8{ get; set; }
        public static List<ReportMainItem> ncheck9{ get; set; }
        public static List<ReportMainItem> ncheck10{ get; set; }
        public static List<ReportMainItem> ncheck11{ get; set; }
        public static List<ReportMainItem> ncheck12{ get; set; }
        public static ReportKapak ncheckKapak{ get; set; } 
        public static List<ReportMainChart> ncheckchart{ get; set; }
        public static List<ReportMainChart> ncheckchartb{ get; set; }
        public static List<ReportMainChart> ncheckchart1{ get; set; }
        public static List<ReportMainChart> ncheckchart2{ get; set; }
        public static List<ReportMainChart> ncheckchart3{ get; set; }
        public static List<ReportMainChart> ncheckchart4{ get; set; }
        public static List<ReportMainChart> ncheckchart5{ get; set; }
        public static List<ReportMainChart> ncheckchart6{ get; set; }
        public static List<ReportMainChart> ncheckchart7{ get; set; }
        public static List<ReportMainChart> ncheckchart8{ get; set; }
        public static List<ReportMainChart> ncheckchart9{ get; set; }
        public static List<ReportMainChart> ncheckchart10{ get; set; }
        public static List<ReportMainChart> ncheckchart11{ get; set; }
        public static List<ReportMainChart> ncheckchart12{ get; set; }
        public static IEnumerable<Companies> mreqListCompany{ get; set; }
        public static HhvnUsers CurrentUser{ get; set; }
        public static Companies CCompanies{ get; set; }
        public static string compnacecode{ get; set; }
        public static long companyID{ get; set; }
        public static bool Isfailed{ get; set; }
        public static string repchakec{ get; set; }
        public static string header{ get; set; }
        public static string nccode{ get; set; }
        public static IEnumerable<CsvDynamic> csvDynamiclist { get; set; }
        public static IEnumerable<CsvDynamicII> csvDynamicIIlist { get; set; }
        public static IEnumerable<CsvDynamicIII> csvDynamicIIIlist { get; set; }
        public static IEnumerable<CsvDynamicIIII> csvDynamicIIIIlist { get; set; }

        public static DynamicReportfour getReportMizanFour(long companyID, string nacceco, long usride_, List<int> nyearChkList)
        {

           if (nacceco !=null && nacceco.Length>0) { Companies.DataReportMainNace(nacceco, companyID); }
            nyearChkList.Reverse();
            nyearChkList = nyearChkList.Take(4).ToList();
            int nyear_ = nyearChkList.Max();

            int[] nyearListmain = nyearChkList.ToArray();
     
            YearCount = nyearChkList.Count;
            nyearChkList.Sort();


            var nnlist = Companies.Get_CompanyReportYearMainMizanReport(companyID);
            nnlist.Reverse();
            nnlist = nnlist.Take(4).ToList();
            switch (nnlist.Count)
            {
                case 1: csvDynamiclist = Companies.GetDynamic(companyID, 3); break;
                case 2: csvDynamicIIlist = Companies.GetDynamicII(companyID, 3); break;
                case 3: csvDynamicIIIlist = Companies.GetDynamicIII(companyID, 3); break;
                case 4: csvDynamicIIIIlist = Companies.GetDynamicIIII(companyID, 3); break;
                default:
                    break;
            }

            //var chkkkmain = Companies.GetDynamic(companyID,3);

            string nname = System.Guid.NewGuid().ToString("D") + ".csv";
            var FileDicz = "/FileContent/" + nname;
            var FileDic = "wwwroot\\FileContent\\" + nname;

            //
            string filePathZ = WebHelper.path;
            string FilePath = System.IO.Path.Combine(filePathZ, FileDic);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", HasHeaderRecord = false };
            using (var writer = new StreamWriter(FilePath, append: true))
            {
                using (var csv = new CsvWriter(writer, config))
                {
                    switch (nnlist.Count)
                    {
                        case 1: csv.WriteRecords(csvDynamiclist); break;
                        case 2: csv.WriteRecords(csvDynamicIIlist); break;
                        case 3: csv.WriteRecords(csvDynamicIIIlist); break;
                        case 4: csv.WriteRecords(csvDynamicIIIIlist); break;
                        default:
                            break;
                    }

                }
            }
            nnlist.Sort();
            string replacenull = "Hesap;" + string.Join(";", nnlist);
            replacenull += File.ReadAllText(FilePath);
            replacenull = replacenull.Replace("null", "").Replace("\r\n", "\t");

          
           
                string retvalue = Startup.FooServiceInstance.FirstSetupAsync(replacenull).Result;
            try
            {
                int vall = retvalue.IndexOf("Dönen Varlıklar"); if (vall < 0) { vall = 0; }
                retvalue = retvalue.Substring(vall);
            vall = retvalue.IndexOf("**Varlıklar**");
                if (vall<0){  vall = 0; }
            retvalue = retvalue.Substring(vall);

            retvalue = retvalue.Replace("**", "").Replace("#", "").Replace("-", "");
            Isfailed = false;
            //Color.FromArgb(182,33,45) red
            //Color.FromArgb(23, 127, 117) greeen
            UserID = usride_;

                CCompanies = Companies.Get_CompanyRow(companyID);
                compnacecode = CCompanies.NaceCode;
            companyID = CCompanies.ID;
            

        
            repchakec = "Kayıtlarda Bir Sorunla Karşılaşıldı";
            header = CCompanies.CompanyName;

          
                var checkedData = MainDash.DataReportMainKapakDynamic(nyear_, companyID);
                riskdatachk = RiskData.getListedPoint(checkedData);
                riskdata = RiskData.getPoint(riskdatachk);
                ncheckKapak = ReportKapak.setKapak(checkedData);
                if (ncheckKapak == null)
                {
                    ncheckKapak = new ReportKapak();
                }
                //if (ncheckKapak.nitemAltmanz.TumYil > 7)
                //{
                //    ncheckKapak.nitemAltmanz.TumYil = 7;
                //}
                //if (ncheckKapak.nitemCariOran.IsFailed > 0) { shape1 = Color.FromArgb(182, 33, 45); } else { shape1 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemLikitideOran.IsFailed > 0) { shape2 = Color.FromArgb(182, 33, 45); } else { shape2 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemNakitOran.IsFailed > 0) { shape3 = Color.FromArgb(182, 33, 45); } else { shape3 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemAlacakDevir.IsFailed > 0) { shape4 = Color.FromArgb(182, 33, 45); } else { shape4 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemTicariBorcDevir.IsFailed > 0) { shape5 = Color.FromArgb(182, 33, 45); } else { shape5 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemStokDevir.IsFailed > 0) { shape6 = Color.FromArgb(182, 33, 45); } else { shape6 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemBorcOzsermaye.IsFailed > 0) { shape7 = Color.FromArgb(182, 33, 45); } else { shape7 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemTpolamBankaBorc.IsFailed > 0) { shape8 = Color.FromArgb(182, 33, 45); } else { shape8 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemOzkaynakAktif.IsFailed > 0) { shape9 = Color.FromArgb(182, 33, 45); } else { shape9 = Color.FromArgb(23, 127, 117); };
                ncheck = MainDash.DataReportMainDynamic(nyearListmain, companyID);
                nchecka = MainDash.DataReportMainADynamic(nyearListmain, companyID);

                ncheck1 = MainDash.DataReportMainBDynamic(nyearListmain, companyID);
                ncheck1a = MainDash.DataReportMainCDynamic(nyearListmain, companyID);

                ncheckd = MainDash.DataReportMainDDynamic(nyearListmain, companyID);
                nchecke = MainDash.DataReportMainEDynamic(nyearListmain, companyID);
                ncheckf = MainDash.DataReportMainFDynamic(nyearListmain, companyID);
                ncheckg = MainDash.DataReportMainGDynamic(nyearListmain, companyID);
                nchecklast = MainDash.DataReportMainTDynamic(nyearListmain, companyID);
                ncheckb = new List<ReportMainItem>();

                ncheckb.AddRange(ncheck.Where(x => x.CounterZone == 11).ToList());
                ncheckchart = MainDash.DataReportMainChartMainMulti(ncheckb.OrderBy(x => x.Year));
                ncheckc = new List<ReportMainItem>();
                ncheckc.AddRange(ncheck.Where(x => x.CounterZone == 1011).ToList());
                ncheckchartb = MainDash.DataReportMainChartMainMulti(ncheckc.OrderBy(x => x.Year));
                rdColor = new RiskDataColor();
                ncheck1_ = MainDash.DataReportMain1Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck2 = MainDash.DataReportMain2Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck3 = MainDash.DataReportMain3Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck4 = MainDash.DataReportMain4Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck5 = MainDash.DataReportMain5Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck6 = MainDash.DataReportMain6Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck7 = MainDash.DataReportMain7Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck8 = MainDash.DataReportMain8Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck9 = MainDash.DataReportMain9Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck10 = MainDash.DataReportMain10Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck11 = MainDash.DataReportMain11Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck12 = MainDash.DataReportMain12Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));

                RiskDataColor.getListedPoint(ncheck1_, 1, false, rdColor);
                RiskDataColor.getListedPoint(ncheck2, 2, false, rdColor);
                RiskDataColor.getListedPoint(ncheck3, 3, false, rdColor);
                RiskDataColor.getListedPoint(ncheck4, 4, false, rdColor);
                RiskDataColor.getListedPoint(ncheck5, 5, false, rdColor);
                RiskDataColor.getListedPoint(ncheck6, 6, false, rdColor);
                RiskDataColor.getListedPoint(ncheck7, 7, false, rdColor);
                RiskDataColor.getListedPoint(ncheck8, 8, false, rdColor);
                RiskDataColor.getListedPoint(ncheck9, 9, false, rdColor);
                RiskDataColor.getListedPoint(ncheck10, 10, false, rdColor);
                RiskDataColor.getListedPoint(ncheck11, 11, false, rdColor);
                RiskDataColor.getListedPoint(ncheck12, 12, false, rdColor);
                ncheckchart1 = MainDash.DataReportMainChartMainMulti(ncheck1_.OrderBy(x => x.Year));
                ncheckchart2 = MainDash.DataReportMainChartMainMulti(ncheck2.OrderBy(x => x.Year));
                ncheckchart3 = MainDash.DataReportMainChartMainMulti(ncheck3.OrderBy(x => x.Year));
                ncheckchart4 = MainDash.DataReportMainChartMainMulti(ncheck4.OrderBy(x => x.Year));
                ncheckchart5 = MainDash.DataReportMainChartMainMulti(ncheck5.OrderBy(x => x.Year));
                ncheckchart6 = MainDash.DataReportMainChartMainMulti(ncheck6.OrderBy(x => x.Year));
                ncheckchart7 = MainDash.DataReportMainChartMainMulti(ncheck7.OrderBy(x => x.Year));
                ncheckchart8 = MainDash.DataReportMainChartMainMulti(ncheck8.OrderBy(x => x.Year));
                ncheckchart9 = MainDash.DataReportMainChartMainMulti(ncheck9.OrderBy(x => x.Year));
                ncheckchart10 = MainDash.DataReportMainChartMainMulti(ncheck10.OrderBy(x => x.Year));
                ncheckchart11 = MainDash.DataReportMainChartMainMulti(ncheck11.OrderBy(x => x.Year));
                ncheckchart12 = MainDash.DataReportMainChartMainMulti(ncheck12.OrderBy(x => x.Year));

            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = companyID;
                lg.CsvID = 9191;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                Isfailed = true;

            }

            DynamicReportfour report = new DynamicReportfour(riskdata, rdColor);

            LineSeriesView checkSeries = new LineSeriesView();

            //report.testlist.AddRange(fields);
            //report.testlistHeader.AddRange(fieldsHeader);
   

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



            report.xrCrossTab1.DataSource = objectDataSource;
            report.xrCrossTab2.DataSource = objectDataSourceA;
            report.xrCrossTabBilancoGenel.DataSource = objectDataSourceB;
            report.xrCrossTabYukumluuk.DataSource = objectDataSourceC;
            report.xrCrossTabKarlk.DataSource = objectDataSourceD;
            report.xrCrossTabBorcOdeme.DataSource = objectDataSourceE;
            report.xrCrossTabLikidite.DataSource = objectDataSourceF;
            report.xrCrossTabSermaye.DataSource = objectDataSourceG;
            report.xrCrossTabRasio.DataSource = objectDataSourceT;

            report.xrCrossTabBnkYabKynk.DataSource = ncheck1_;
            report.xrCrossTabBnkAktif.DataSource = ncheck2;
            report.xrCrossTabDuranOkynk.DataSource = ncheck3;
            report.xrCrossTabDonenAktif.DataSource = ncheck4;
            report.xrCrossTabKVAktif.DataSource = ncheck5;
            report.xrCrossTabKVDonen.DataSource = ncheck6;

            report.xrCrossTabKVPasif.DataSource = ncheck7;
            report.xrCrossTabMaddiOzkaynak.DataSource = ncheck8;
            report.xrCrossTabStokAktif.DataSource = ncheck9;
            report.xrCrossTabUVadePasif.DataSource = ncheck10;
            report.xrCrossTabOKynkYbKyn.DataSource = ncheck11;
            report.xrCrossTabOKynkAktif.DataSource = ncheck12;





            var chart = (XRChart)report.FindControl("xrChart1", false);
            chart.Series.Clear();
            chart.DataSource = ncheckchart;//Method from documentation you reffered
            chart.SeriesTemplate.SeriesDataMember = "GroupName";
            chart.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart.SeriesTemplate.ValueDataMembers.AddRange("Value");



            var chart1 = (XRChart)report.FindControl("xrChart2", false);
            chart1.Series.Clear();
            chart1.DataSource = ncheckchartb;//Method from documentation you reffered
            chart1.SeriesTemplate.SeriesDataMember = "GroupName";
            chart1.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart1.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart1.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart1.SeriesTemplate.ValueDataMembers.AddRange("Value");

            report.xrChartBnkYabKynk.SeriesTemplate.View = checkSeries;
            report.xrChartBnkYabKynk.DataSource = ncheckchart1;//Method from documentation you reffered
            report.xrChartBnkYabKynk.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartBnkYabKynk.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartBnkYabKynk.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartBnkYabKynk.SeriesTemplate.ValueDataMembers.AddRange("Value"); report.xrChartBnkYabKynk.PaletteName = "PaletteDyn";
            report.xrChartBnkYabKynk.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartBnkAktif.SeriesTemplate.View = checkSeries;
            report.xrChartBnkAktif.DataSource = ncheckchart2;//Method from documentation you reffered
            report.xrChartBnkAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartBnkAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartBnkAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartBnkAktif.SeriesTemplate.ValueDataMembers.AddRange("Value"); report.xrChartBnkAktif.PaletteName = "PaletteDyn";
            report.xrChartBnkAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartDuranOkynk.SeriesTemplate.View = checkSeries;
            report.xrChartDuranOkynk.DataSource = ncheckchart3;//Method from documentation you reffered
            report.xrChartDuranOkynk.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartDuranOkynk.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartDuranOkynk.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartDuranOkynk.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartBnkYabKynk.PaletteName = "PaletteDyn";
            report.xrChartDuranOkynk.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartDonenAktif.SeriesTemplate.View = checkSeries;
            report.xrChartDonenAktif.DataSource = ncheckchart4;//Method from documentation you reffered
            report.xrChartDonenAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartDonenAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartDonenAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartDonenAktif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartDonenAktif.PaletteName = "PaletteDyn";
            report.xrChartDonenAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrChartKVAktif.SeriesTemplate.View = checkSeries;
            report.xrChartKVAktif.DataSource = ncheckchart5;//Method from documentation you reffered
            report.xrChartKVAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartKVAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartKVAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartKVAktif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartKVAktif.PaletteName = "PaletteDyn";
            report.xrChartKVAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrChartKVDonen.SeriesTemplate.View = checkSeries;
            report.xrChartKVDonen.DataSource = ncheckchart6;//Method from documentation you reffered
            report.xrChartKVDonen.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartKVDonen.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartKVDonen.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartKVDonen.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartKVDonen.PaletteName = "PaletteDyn";
            report.xrChartKVDonen.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            //////
            report.xrChartKVPasif.SeriesTemplate.View = checkSeries;
            report.xrChartKVPasif.DataSource = ncheckchart7;//Method from documentation you reffered
            report.xrChartKVPasif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartKVPasif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartKVPasif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartKVPasif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartKVPasif.PaletteName = "PaletteDyn";
            report.xrChartKVPasif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrChartMaddiOzkaynak.SeriesTemplate.View = checkSeries;
            report.xrChartMaddiOzkaynak.DataSource = ncheckchart8;//Method from documentation you reffered
            report.xrChartMaddiOzkaynak.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartMaddiOzkaynak.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartMaddiOzkaynak.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartMaddiOzkaynak.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartMaddiOzkaynak.PaletteName = "PaletteDyn";
            report.xrChartMaddiOzkaynak.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartStokAktif.SeriesTemplate.View = checkSeries;
            report.xrChartStokAktif.DataSource = ncheckchart9;//Method from documentation you reffered
            report.xrChartStokAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartStokAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartStokAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartStokAktif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartStokAktif.PaletteName = "PaletteDyn";
            report.xrChartStokAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartUVadePasif.SeriesTemplate.View = checkSeries;
            report.xrChartUVadePasif.DataSource = ncheckchart10;//Method from documentation you reffered
            report.xrChartUVadePasif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartUVadePasif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartUVadePasif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartUVadePasif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartUVadePasif.PaletteName = "PaletteDyn";
            report.xrChartUVadePasif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartOKynkYbKyn.SeriesTemplate.View = checkSeries;
            report.xrChartOKynkYbKyn.DataSource = ncheckchart11;//Method from documentation you reffered
            report.xrChartOKynkYbKyn.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartOKynkYbKyn.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartOKynkYbKyn.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartOKynkYbKyn.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartOKynkYbKyn.PaletteName = "PaletteDyn";
            report.xrChartOKynkYbKyn.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrChartOKynkAktif.SeriesTemplate.View = checkSeries;
            report.xrChartOKynkAktif.DataSource = ncheckchart12;//Method from documentation you reffered
            report.xrChartOKynkAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartOKynkAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartOKynkAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartOKynkAktif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartOKynkAktif.PaletteName = "PaletteDyn";
            report.xrChartOKynkAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrLblOzkaynak.Text = ncheckKapak.nitemOzkaynakAktif.TumYil.ToString("N2");
            report.xrlblCarioran.Text = ncheckKapak.nitemCariOran.TumYil.ToString("N2");
            report.xrlblROA.Text = (ncheckKapak.nitemROAAktifKarlilik.TumYil * 100).ToString("N2") + "%";
            report.xrlblAltmanZ.Text = ncheckKapak.nitemAltmanz.TumYil.ToString("N2");
            report.xrlblNetIsletmeSerm.Text = ncheckKapak.nitemNetIsletmeSermaye.TumYil.ToString("N0");
            report.xrlblFaizVeVergi.Text = ncheckKapak.nitemFaizVergiOncesiKarZarar.TumYil.ToString("N2");
            report.xrLabelCompanyName.Text = CCompanies.CompanyName;
            report.xrLabelCompanyAdress.Text = CCompanies.Adress;
            report.xrLabelCompanyNace.Text = CCompanies.NaceCode;
            //var xrlbl1 = (XRLabel)report.FindControl("xrLblOzkaynak", false);
            //xrlbl1.Text = ncheckKapak.nitemOzkaynakAktif.TumYil.ToString("N2");

            //var xrlbl2 = (XRLabel)report.FindControl("xrlblCarioran", false);
            //xrlbl2.Text = ncheckKapak.nitemCariOran.TumYil.ToString("N2");


            //var xrlbl3 = (XRLabel)report.FindControl("xrlblROA", false);
            //xrlbl3.Text = (ncheckKapak.nitemROAAktifKarlilik.TumYil * 100).ToString("N2") + "%";



            //var xrlbl5 = (XRLabel)report.FindControl("xrlblAltmanZ", false);
            //xrlbl5.Text = ncheckKapak.nitemAltmanz.TumYil.ToString("N2");


            //var xrlbl6 = (XRLabel)report.FindControl("xrlblNetIsletmeSerm", false);
            //xrlbl6.Text = ncheckKapak.nitemNetIsletmeSermaye.TumYil.ToString("N0");


            //var xrlbl7 = (XRLabel)report.FindControl("xrlblFaizVeVergi", false);
            //xrlbl7.Text = ncheckKapak.nitemFaizVergiOncesiKarZarar.TumYil.ToString("N2");

            report.xrRichTextAnaMetin.Rtf = retvalue;



            report.PrintingSystem.Document.Name = "Balance_raporlar";

            return report;

        }
        public static DynamicReport getReportMizan(long companyID, string nacceco, long usride_, List<int> nyearChkList)
        {
            if (nacceco != null && nacceco.Length > 0) { Companies.DataReportMainNace(nacceco, companyID); }
            nyearChkList.Sort();
            int[] nyearListmain = nyearChkList.ToArray();
            int nyear_ = nyearListmain.Max();
            YearCount = nyearChkList.Count;



            var nnlist = Companies.Get_CompanyReportYearMainMizanReport(companyID);
            switch (nnlist.Count)
            {
                case 1: csvDynamiclist = Companies.GetDynamic(companyID, 3);break;
                case 2: csvDynamicIIlist = Companies.GetDynamicII(companyID, 3); break;
                case 3: csvDynamicIIIlist = Companies.GetDynamicIII(companyID, 3); break;
                case 4: csvDynamicIIIIlist = Companies.GetDynamicIIII(companyID, 3); break;
                default:
                    break;
            }
            nnlist.Sort();
            //var chkkkmain = Companies.GetDynamic(companyID,3);

            string nname = System.Guid.NewGuid().ToString("D") + ".csv";
            var FileDicz = "/FileContent/" + nname;
            var FileDic = "wwwroot\\FileContent\\" + nname;

            //
            string filePathZ = WebHelper.path;
            string FilePath = System.IO.Path.Combine(filePathZ, FileDic);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", HasHeaderRecord = false };
            using (var writer = new StreamWriter(FilePath, append: true))
            {
                using (var csv = new CsvWriter(writer, config))
                {
                    switch (nnlist.Count)
                    {
                        case 1: csv.WriteRecords(csvDynamiclist) ; break;
                        case 2: csv.WriteRecords(csvDynamicIIlist); break;
                        case 3: csv.WriteRecords(csvDynamicIIIlist); break;
                        case 4: csv.WriteRecords(csvDynamicIIIIlist); break;
                        default:
                            break;
                    }
                    
                }
            }

            string replacenull = "Hesap;"+ string.Join(";", nnlist);
            replacenull += File.ReadAllText(FilePath);
            replacenull = replacenull.Replace("null", "").Replace("\r\n", "\t");

             
           
                string retvalue = Startup.FooServiceInstance.FirstSetupAsync(replacenull).Result;
            try
            {
                int vall = retvalue.IndexOf("Dönen Varlıklar"); if (vall < 0) { vall = 0; }
                retvalue = retvalue.Substring(vall);
                vall = retvalue.IndexOf("**Varlıklar**");
                if (vall < 0) { vall = 0; }
                retvalue = retvalue.Substring(vall);

                retvalue = retvalue.Replace("**", "").Replace("#", "").Replace("-", "");
                Isfailed = false;
            //Color.FromArgb(182,33,45) red
            //Color.FromArgb(23, 127, 117) greeen
            UserID = usride_;

                CCompanies = Companies.Get_CompanyRow(companyID); 

            companyID = CCompanies.ID;
                compnacecode = CCompanies.NaceCode;
             

        
            repchakec = "Kayıtlarda Bir Sorunla Karşılaşıldı";
            header = CCompanies.CompanyName;

           
                var checkedData = MainDash.DataReportMainKapakDynamic(nyear_, companyID);
                riskdatachk = RiskData.getListedPoint(checkedData);
                riskdata = RiskData.getPoint(riskdatachk);
                ncheckKapak = ReportKapak.setKapak(checkedData);
                if (ncheckKapak == null)
                {
                    ncheckKapak = new ReportKapak();
                }
                //if (ncheckKapak.nitemAltmanz.TumYil > 7)
                //{
                //    ncheckKapak.nitemAltmanz.TumYil = 7;
                //}
                //if (ncheckKapak.nitemCariOran.IsFailed > 0) { shape1 = Color.FromArgb(182, 33, 45); } else { shape1 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemLikitideOran.IsFailed > 0) { shape2 = Color.FromArgb(182, 33, 45); } else { shape2 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemNakitOran.IsFailed > 0) { shape3 = Color.FromArgb(182, 33, 45); } else { shape3 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemAlacakDevir.IsFailed > 0) { shape4 = Color.FromArgb(182, 33, 45); } else { shape4 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemTicariBorcDevir.IsFailed > 0) { shape5 = Color.FromArgb(182, 33, 45); } else { shape5 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemStokDevir.IsFailed > 0) { shape6 = Color.FromArgb(182, 33, 45); } else { shape6 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemBorcOzsermaye.IsFailed > 0) { shape7 = Color.FromArgb(182, 33, 45); } else { shape7 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemTpolamBankaBorc.IsFailed > 0) { shape8 = Color.FromArgb(182, 33, 45); } else { shape8 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemOzkaynakAktif.IsFailed > 0) { shape9 = Color.FromArgb(182, 33, 45); } else { shape9 = Color.FromArgb(23, 127, 117); };
                ncheck = MainDash.DataReportMainDynamic(nyearListmain, companyID);
                nchecka = MainDash.DataReportMainADynamic(nyearListmain, companyID);

                ncheck1 = MainDash.DataReportMainBDynamic(nyearListmain, companyID);
                ncheck1a = MainDash.DataReportMainCDynamic(nyearListmain, companyID);

                ncheckd = MainDash.DataReportMainDDynamic(nyearListmain, companyID);
                nchecke = MainDash.DataReportMainEDynamic(nyearListmain, companyID);
                ncheckf = MainDash.DataReportMainFDynamic(nyearListmain, companyID);
                ncheckg = MainDash.DataReportMainGDynamic(nyearListmain, companyID);
                nchecklast = MainDash.DataReportMainTDynamic(nyearListmain, companyID);
                ncheckb = new List<ReportMainItem>();

                ncheckb.AddRange(ncheck.Where(x => x.CounterZone == 11).ToList());
                ncheckchart = MainDash.DataReportMainChartMainMulti(ncheckb.OrderBy(x => x.Year));
                ncheckc = new List<ReportMainItem>();
                ncheckc.AddRange(ncheck.Where(x => x.CounterZone == 1011).ToList());
                ncheckchartb = MainDash.DataReportMainChartMainMulti(ncheckc.OrderBy(x => x.Year));
                rdColor = new RiskDataColor();
                ncheck1_ = MainDash.DataReportMain1Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck2 = MainDash.DataReportMain2Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck3 = MainDash.DataReportMain3Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck4 = MainDash.DataReportMain4Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck5 = MainDash.DataReportMain5Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck6 = MainDash.DataReportMain6Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck7 = MainDash.DataReportMain7Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck8 = MainDash.DataReportMain8Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck9 = MainDash.DataReportMain9Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck10 = MainDash.DataReportMain10Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck11 = MainDash.DataReportMain11Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck12 = MainDash.DataReportMain12Dynamic(nyearListmain, companyID, Convert.ToInt32(compnacecode));

                RiskDataColor.getListedPoint(ncheck1_, 1, false, rdColor);
                RiskDataColor.getListedPoint(ncheck2, 2, false, rdColor);
                RiskDataColor.getListedPoint(ncheck3, 3, false, rdColor);
                RiskDataColor.getListedPoint(ncheck4, 4, false, rdColor);
                RiskDataColor.getListedPoint(ncheck5, 5, false, rdColor);
                RiskDataColor.getListedPoint(ncheck6, 6, false, rdColor);
                RiskDataColor.getListedPoint(ncheck7, 7, false, rdColor);
                RiskDataColor.getListedPoint(ncheck8, 8, false, rdColor);
                RiskDataColor.getListedPoint(ncheck9, 9, false, rdColor);
                RiskDataColor.getListedPoint(ncheck10, 10, false, rdColor);
                RiskDataColor.getListedPoint(ncheck11, 11, false, rdColor);
                RiskDataColor.getListedPoint(ncheck12, 12, false, rdColor);
                ncheckchart1 = MainDash.DataReportMainChartMainMulti(ncheck1_.OrderBy(x => x.Year));
                ncheckchart2 = MainDash.DataReportMainChartMainMulti(ncheck2.OrderBy(x => x.Year));
                ncheckchart3 = MainDash.DataReportMainChartMainMulti(ncheck3.OrderBy(x => x.Year));
                ncheckchart4 = MainDash.DataReportMainChartMainMulti(ncheck4.OrderBy(x => x.Year));
                ncheckchart5 = MainDash.DataReportMainChartMainMulti(ncheck5.OrderBy(x => x.Year));
                ncheckchart6 = MainDash.DataReportMainChartMainMulti(ncheck6.OrderBy(x => x.Year));
                ncheckchart7 = MainDash.DataReportMainChartMainMulti(ncheck7.OrderBy(x => x.Year));
                ncheckchart8 = MainDash.DataReportMainChartMainMulti(ncheck8.OrderBy(x => x.Year));
                ncheckchart9 = MainDash.DataReportMainChartMainMulti(ncheck9.OrderBy(x => x.Year));
                ncheckchart10 = MainDash.DataReportMainChartMainMulti(ncheck10.OrderBy(x => x.Year));
                ncheckchart11 = MainDash.DataReportMainChartMainMulti(ncheck11.OrderBy(x => x.Year));
                ncheckchart12 = MainDash.DataReportMainChartMainMulti(ncheck12.OrderBy(x => x.Year));

            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = companyID;
                lg.CsvID = 9191;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                Isfailed = true;

            }

            DynamicReport report = new DynamicReport(riskdata, rdColor);

            LineSeriesView checkSeries = new LineSeriesView();

            //report.testlist.AddRange(fields);
            //report.testlistHeader.AddRange(fieldsHeader);
            report.CheckSize = YearCount;

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



            report.xrCrossTab1.DataSource = objectDataSource;
            report.xrCrossTab2.DataSource = objectDataSourceA;
            report.xrCrossTabBilancoGenel.DataSource = objectDataSourceB;
            report.xrCrossTabYukumluuk.DataSource = objectDataSourceC;
            report.xrCrossTabKarlk.DataSource = objectDataSourceD;
            report.xrCrossTabBorcOdeme.DataSource = objectDataSourceE;
            report.xrCrossTabLikidite.DataSource = objectDataSourceF;
            report.xrCrossTabSermaye.DataSource = objectDataSourceG;
            report.xrCrossTabRasio.DataSource = objectDataSourceT;

            report.xrCrossTabBnkYabKynk.DataSource = ncheck1_;
            report.xrCrossTabBnkAktif.DataSource = ncheck2;
            report.xrCrossTabDuranOkynk.DataSource = ncheck3;
            report.xrCrossTabDonenAktif.DataSource = ncheck4;
            report.xrCrossTabKVAktif.DataSource = ncheck5;
            report.xrCrossTabKVDonen.DataSource = ncheck6;

            report.xrCrossTabKVPasif.DataSource = ncheck7;
            report.xrCrossTabMaddiOzkaynak.DataSource = ncheck8;
            report.xrCrossTabStokAktif.DataSource = ncheck9;
            report.xrCrossTabUVadePasif.DataSource = ncheck10;
            report.xrCrossTabOKynkYbKyn.DataSource = ncheck11;
            report.xrCrossTabOKynkAktif.DataSource = ncheck12;





            var chart = (XRChart)report.FindControl("xrChart1", false);
            chart.Series.Clear();
            chart.DataSource = ncheckchart;//Method from documentation you reffered
            chart.SeriesTemplate.SeriesDataMember = "GroupName";
            chart.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart.SeriesTemplate.ValueDataMembers.AddRange("Value");



            var chart1 = (XRChart)report.FindControl("xrChart2", false);
            chart1.Series.Clear();
            chart1.DataSource = ncheckchartb;//Method from documentation you reffered
            chart1.SeriesTemplate.SeriesDataMember = "GroupName";
            chart1.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart1.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart1.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart1.SeriesTemplate.ValueDataMembers.AddRange("Value");

            report.xrChartBnkYabKynk.SeriesTemplate.View = checkSeries;
            report.xrChartBnkYabKynk.DataSource = ncheckchart1;//Method from documentation you reffered
            report.xrChartBnkYabKynk.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartBnkYabKynk.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartBnkYabKynk.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartBnkYabKynk.SeriesTemplate.ValueDataMembers.AddRange("Value"); report.xrChartBnkYabKynk.PaletteName = "PaletteDyn";
            report.xrChartBnkYabKynk.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartBnkAktif.SeriesTemplate.View = checkSeries;
            report.xrChartBnkAktif.DataSource = ncheckchart2;//Method from documentation you reffered
            report.xrChartBnkAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartBnkAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartBnkAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartBnkAktif.SeriesTemplate.ValueDataMembers.AddRange("Value"); report.xrChartBnkAktif.PaletteName = "PaletteDyn";
            report.xrChartBnkAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartDuranOkynk.SeriesTemplate.View = checkSeries;
            report.xrChartDuranOkynk.DataSource = ncheckchart3;//Method from documentation you reffered
            report.xrChartDuranOkynk.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartDuranOkynk.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartDuranOkynk.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartDuranOkynk.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartBnkYabKynk.PaletteName = "PaletteDyn";
            report.xrChartDuranOkynk.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartDonenAktif.SeriesTemplate.View = checkSeries;
            report.xrChartDonenAktif.DataSource = ncheckchart4;//Method from documentation you reffered
            report.xrChartDonenAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartDonenAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartDonenAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartDonenAktif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartDonenAktif.PaletteName = "PaletteDyn";
            report.xrChartDonenAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrChartKVAktif.SeriesTemplate.View = checkSeries;
            report.xrChartKVAktif.DataSource = ncheckchart5;//Method from documentation you reffered
            report.xrChartKVAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartKVAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartKVAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartKVAktif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartKVAktif.PaletteName = "PaletteDyn";
            report.xrChartKVAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrChartKVDonen.SeriesTemplate.View = checkSeries;
            report.xrChartKVDonen.DataSource = ncheckchart6;//Method from documentation you reffered
            report.xrChartKVDonen.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartKVDonen.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartKVDonen.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartKVDonen.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartKVDonen.PaletteName = "PaletteDyn";
            report.xrChartKVDonen.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            //////
            report.xrChartKVPasif.SeriesTemplate.View = checkSeries;
            report.xrChartKVPasif.DataSource = ncheckchart7;//Method from documentation you reffered
            report.xrChartKVPasif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartKVPasif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartKVPasif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartKVPasif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartKVPasif.PaletteName = "PaletteDyn";
            report.xrChartKVPasif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrChartMaddiOzkaynak.SeriesTemplate.View = checkSeries;
            report.xrChartMaddiOzkaynak.DataSource = ncheckchart8;//Method from documentation you reffered
            report.xrChartMaddiOzkaynak.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartMaddiOzkaynak.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartMaddiOzkaynak.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartMaddiOzkaynak.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartMaddiOzkaynak.PaletteName = "PaletteDyn";
            report.xrChartMaddiOzkaynak.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartStokAktif.SeriesTemplate.View = checkSeries;
            report.xrChartStokAktif.DataSource = ncheckchart9;//Method from documentation you reffered
            report.xrChartStokAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartStokAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartStokAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartStokAktif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartStokAktif.PaletteName = "PaletteDyn";
            report.xrChartStokAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartUVadePasif.SeriesTemplate.View = checkSeries;
            report.xrChartUVadePasif.DataSource = ncheckchart10;//Method from documentation you reffered
            report.xrChartUVadePasif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartUVadePasif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartUVadePasif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartUVadePasif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartUVadePasif.PaletteName = "PaletteDyn";
            report.xrChartUVadePasif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartOKynkYbKyn.SeriesTemplate.View = checkSeries;
            report.xrChartOKynkYbKyn.DataSource = ncheckchart11;//Method from documentation you reffered
            report.xrChartOKynkYbKyn.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartOKynkYbKyn.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartOKynkYbKyn.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartOKynkYbKyn.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartOKynkYbKyn.PaletteName = "PaletteDyn";
            report.xrChartOKynkYbKyn.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrChartOKynkAktif.SeriesTemplate.View = checkSeries;
            report.xrChartOKynkAktif.DataSource = ncheckchart12;//Method from documentation you reffered
            report.xrChartOKynkAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartOKynkAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartOKynkAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartOKynkAktif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartOKynkAktif.PaletteName = "PaletteDyn";
            report.xrChartOKynkAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrLblOzkaynak.Text = ncheckKapak.nitemOzkaynakAktif.TumYil.ToString("N2");
            report.xrlblCarioran.Text = ncheckKapak.nitemCariOran.TumYil.ToString("N2");
            report.xrlblROA.Text = (ncheckKapak.nitemROAAktifKarlilik.TumYil * 100).ToString("N2") + "%";
            report.xrlblAltmanZ.Text = ncheckKapak.nitemAltmanz.TumYil.ToString("N2");
            report.xrlblNetIsletmeSerm.Text = ncheckKapak.nitemNetIsletmeSermaye.TumYil.ToString("N0");
            report.xrlblFaizVeVergi.Text = ncheckKapak.nitemFaizVergiOncesiKarZarar.TumYil.ToString("N2");

            report.xrLabelCompanyName.Text = CCompanies.CompanyName;
            report.xrLabelCompanyAdress.Text = CCompanies.Adress;
            report.xrLabelCompanyNace.Text = CCompanies.NaceCode;

            //report.xrRichTextUstMetin.Rtf = mttin;
            report.xrRichTextAnaMetin.Rtf = retvalue;
            
            //var xrlbl1 = (XRLabel)report.FindControl("xrLblOzkaynak", false);
            //xrlbl1.Text = ncheckKapak.nitemOzkaynakAktif.TumYil.ToString("N2");

            //var xrlbl2 = (XRLabel)report.FindControl("xrlblCarioran", false);
            //xrlbl2.Text = ncheckKapak.nitemCariOran.TumYil.ToString("N2");


            //var xrlbl3 = (XRLabel)report.FindControl("xrlblROA", false);
            //xrlbl3.Text = (ncheckKapak.nitemROAAktifKarlilik.TumYil * 100).ToString("N2") + "%";



            //var xrlbl5 = (XRLabel)report.FindControl("xrlblAltmanZ", false);
            //xrlbl5.Text = ncheckKapak.nitemAltmanz.TumYil.ToString("N2");


            //var xrlbl6 = (XRLabel)report.FindControl("xrlblNetIsletmeSerm", false);
            //xrlbl6.Text = ncheckKapak.nitemNetIsletmeSermaye.TumYil.ToString("N0");


            //var xrlbl7 = (XRLabel)report.FindControl("xrlblFaizVeVergi", false);
            //xrlbl7.Text = ncheckKapak.nitemFaizVergiOncesiKarZarar.TumYil.ToString("N2");





            report.PrintingSystem.Document.Name = "Balance_raporlar";

            return report;

        }
        public static DynamicReport getReport(long companyID, List<int> nyearList,  string nacceco, long usride_, List<int> nyearChkList )
        {
            if (nacceco != null && nacceco.Length > 0) { Companies.DataReportMainNace(nacceco, companyID); }
            nyearChkList.Sort();
            int[] nyearListmain = nyearChkList.ToArray();
            int nyear_ = Companies.Get_CompanyReportMaxYear( companyID );
            YearCount = nyearChkList.Count;

            foreach (int year_ in nyearList) {
                ReportSetMain.Set_ReportSetMain(year_, companyID);
                Thread.Sleep(1000);
            }


            var nnlist = Companies.Get_CompanyReportYearMainReport(companyID);
            nnlist.Reverse(); 
            switch (nnlist.Count)
            {
                case 1: csvDynamiclist = Companies.GetDynamic(companyID, 1); break;
                case 2: csvDynamicIIlist = Companies.GetDynamicII(companyID, 1); break;
                case 3: csvDynamicIIIlist = Companies.GetDynamicIII(companyID, 1); break;
                case 4: csvDynamicIIIIlist = Companies.GetDynamicIIII(companyID, 1); break;
                default:
                    break;
            }

            //var chkkkmain = Companies.GetDynamic(companyID,3);

            string nname = System.Guid.NewGuid().ToString("D") + ".csv";
            var FileDicz = "/FileContent/" + nname;
            var FileDic = "wwwroot\\FileContent\\" + nname;

            //
            string filePathZ = WebHelper.path;
            string FilePath = System.IO.Path.Combine(filePathZ, FileDic);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", HasHeaderRecord = false };
            using (var writer = new StreamWriter(FilePath, append: true))
            {
                using (var csv = new CsvWriter(writer, config))
                {
                    switch (nnlist.Count)
                    {
                        case 1: csv.WriteRecords(csvDynamiclist); break;
                        case 2: csv.WriteRecords(csvDynamicIIlist); break;
                        case 3: csv.WriteRecords(csvDynamicIIIlist); break;
                        case 4: csv.WriteRecords(csvDynamicIIIIlist); break;
                        default:
                            break;
                    }

                }
            }
            nnlist.Sort();


                string replacenull = "Hesap;" + string.Join(";", nnlist);
            replacenull += File.ReadAllText(FilePath);
            replacenull = replacenull.Replace("null", "").Replace("\r\n", "\t");

            string retvalue = Startup.FooServiceInstance.FirstSetupAsync(replacenull).Result;
            try
            {
                int vall = retvalue.IndexOf("Dönen Varlıklar"); if (vall < 0) { vall = 0; }
                retvalue = retvalue.Substring(vall);
                vall = retvalue.IndexOf("**Varlıklar**");
                if (vall < 0) { vall = 0; }
                retvalue = retvalue.Substring(vall);

                retvalue = retvalue.Replace("**", "").Replace("#", "").Replace("-", "");
                Isfailed = false;
                //Color.FromArgb(182,33,45) red
                //Color.FromArgb(23, 127, 117) greeen
                CCompanies = Companies.Get_CompanyRow(companyID);

                companyID = CCompanies.ID;
                compnacecode = CCompanies.NaceCode;

                repchakec = "Kayıtlarda Bir Sorunla Karşılaşıldı";
            header = CCompanies.CompanyName;
        
          
                var checkedData = MainDash.DataReportMainKapak(nyear_, companyID);
                riskdatachk = RiskData.getListedPoint(checkedData);
                riskdata = RiskData.getPoint(riskdatachk);
                ncheckKapak = ReportKapak.setKapak(checkedData);
                if (ncheckKapak == null)
                {
                    ncheckKapak = new ReportKapak();
                }
                //if (ncheckKapak.nitemAltmanz.TumYil > 7)
                //{
                //    ncheckKapak.nitemAltmanz.TumYil = 7;
                //}
                //if (ncheckKapak.nitemCariOran.IsFailed > 0) { shape1 = Color.FromArgb(182, 33, 45); } else { shape1 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemLikitideOran.IsFailed > 0) { shape2 = Color.FromArgb(182, 33, 45); } else { shape2 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemNakitOran.IsFailed > 0) { shape3 = Color.FromArgb(182, 33, 45); } else { shape3 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemAlacakDevir.IsFailed > 0) { shape4 = Color.FromArgb(182, 33, 45); } else { shape4 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemTicariBorcDevir.IsFailed > 0) { shape5 = Color.FromArgb(182, 33, 45); } else { shape5 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemStokDevir.IsFailed > 0) { shape6 = Color.FromArgb(182, 33, 45); } else { shape6 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemBorcOzsermaye.IsFailed > 0) { shape7 = Color.FromArgb(182, 33, 45); } else { shape7 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemTpolamBankaBorc.IsFailed > 0) { shape8 = Color.FromArgb(182, 33, 45); } else { shape8 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemOzkaynakAktif.IsFailed > 0) { shape9 = Color.FromArgb(182, 33, 45); } else { shape9 = Color.FromArgb(23, 127, 117); };
                ncheck = MainDash.DataReportMainDynamicNew(nyearListmain, companyID);
                nchecka = MainDash.DataReportMainADynamicNew(nyearListmain, companyID);

                ncheck1 = MainDash.DataReportMainBDynamicNew(nyearListmain, companyID);
                ncheck1a = MainDash.DataReportMainCDynamicNew(nyearListmain, companyID);

                ncheckd = MainDash.DataReportMainDDynamicNew(nyearListmain, companyID);
                nchecke = MainDash.DataReportMainEDynamicNew(nyearListmain, companyID);
                ncheckf = MainDash.DataReportMainFDynamicNew(nyearListmain, companyID);
                ncheckg = MainDash.DataReportMainGDynamicNew(nyearListmain, companyID);
                nchecklast = MainDash.DataReportMainTDynamicNew(nyearListmain, companyID);
                ncheckb = new List<ReportMainItem>();
                
                ncheckb.AddRange(ncheck.Where(x => x.CounterZone == 11).ToList());
                ncheckchart = MainDash.DataReportMainChartMainMulti(ncheckb.OrderBy(x => x.Year));
                ncheckc = new List<ReportMainItem>();
                ncheckc.AddRange(ncheck.Where(x => x.CounterZone == 1011).ToList());
                ncheckchartb = MainDash.DataReportMainChartMainMulti(ncheckc.OrderBy(x => x.Year));
                rdColor = new RiskDataColor();
                ncheck1_ = MainDash.DataReportMain1DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck2 = MainDash.DataReportMain2DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck3 = MainDash.DataReportMain3DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck4 = MainDash.DataReportMain4DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck5 = MainDash.DataReportMain5DynamicNew(nyearListmain,  companyID, Convert.ToInt32(compnacecode));
                ncheck6 = MainDash.DataReportMain6DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck7 = MainDash.DataReportMain7DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck8 = MainDash.DataReportMain8DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck9 = MainDash.DataReportMain9DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck10 = MainDash.DataReportMain10DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck11 = MainDash.DataReportMain11DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck12 = MainDash.DataReportMain12DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));

                RiskDataColor.getListedPoint(ncheck1_, 1, false, rdColor);
                RiskDataColor.getListedPoint(ncheck2, 2, false, rdColor);
                RiskDataColor.getListedPoint(ncheck3, 3, false, rdColor);
                RiskDataColor.getListedPoint(ncheck4, 4, false, rdColor);
                RiskDataColor.getListedPoint(ncheck5, 5, false, rdColor);
                RiskDataColor.getListedPoint(ncheck6, 6, false, rdColor);
                RiskDataColor.getListedPoint(ncheck7, 7, false, rdColor);
                RiskDataColor.getListedPoint(ncheck8, 8, false, rdColor);
                RiskDataColor.getListedPoint(ncheck9, 9, false, rdColor);
                RiskDataColor.getListedPoint(ncheck10, 10, false, rdColor);
                RiskDataColor.getListedPoint(ncheck11, 11, false, rdColor);
                RiskDataColor.getListedPoint(ncheck12, 12, false, rdColor);
                ncheckchart1 = MainDash.DataReportMainChartMainMulti(ncheck1_.OrderBy(x => x.Year));
                ncheckchart2 = MainDash.DataReportMainChartMainMulti(ncheck2.OrderBy(x => x.Year));
                ncheckchart3 = MainDash.DataReportMainChartMainMulti(ncheck3.OrderBy(x => x.Year));
                ncheckchart4 = MainDash.DataReportMainChartMainMulti(ncheck4.OrderBy(x => x.Year));
                ncheckchart5 = MainDash.DataReportMainChartMainMulti(ncheck5.OrderBy(x => x.Year));
                ncheckchart6 = MainDash.DataReportMainChartMainMulti(ncheck6.OrderBy(x => x.Year));
                ncheckchart7 = MainDash.DataReportMainChartMainMulti(ncheck7.OrderBy(x => x.Year));
                ncheckchart8 = MainDash.DataReportMainChartMainMulti(ncheck8.OrderBy(x => x.Year));
                ncheckchart9 = MainDash.DataReportMainChartMainMulti(ncheck9.OrderBy(x => x.Year));
                ncheckchart10 = MainDash.DataReportMainChartMainMulti(ncheck10.OrderBy(x => x.Year));
                ncheckchart11 = MainDash.DataReportMainChartMainMulti(ncheck11.OrderBy(x => x.Year));
                ncheckchart12 = MainDash.DataReportMainChartMainMulti(ncheck12.OrderBy(x => x.Year));

            }
            catch(Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = companyID;
                lg.CsvID = 9191;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();

                Isfailed = true;

            }

            DynamicReport report = new DynamicReport(riskdata, rdColor);

            LineSeriesView checkSeries = new LineSeriesView();

            //report.testlist.AddRange(fields);
            //report.testlistHeader.AddRange(fieldsHeader);
            report.CheckSize = YearCount;

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



            report.xrCrossTab1.DataSource = objectDataSource;
            report.xrCrossTab2.DataSource = objectDataSourceA;
            report.xrCrossTabBilancoGenel.DataSource = objectDataSourceB;
            report.xrCrossTabYukumluuk.DataSource = objectDataSourceC;
            report.xrCrossTabKarlk.DataSource = objectDataSourceD;
            report.xrCrossTabBorcOdeme.DataSource = objectDataSourceE;
            report.xrCrossTabLikidite.DataSource = objectDataSourceF;
            report.xrCrossTabSermaye.DataSource = objectDataSourceG;
            report.xrCrossTabRasio.DataSource = objectDataSourceT;

            report.xrCrossTabBnkYabKynk.DataSource = ncheck1_;
            report.xrCrossTabBnkAktif.DataSource = ncheck2;
            report.xrCrossTabDuranOkynk.DataSource = ncheck3;
            report.xrCrossTabDonenAktif.DataSource = ncheck4;
            report.xrCrossTabKVAktif.DataSource = ncheck5;
            report.xrCrossTabKVDonen.DataSource = ncheck6;

            report.xrCrossTabKVPasif.DataSource = ncheck7;
            report.xrCrossTabMaddiOzkaynak.DataSource = ncheck8;
            report.xrCrossTabStokAktif.DataSource = ncheck9;
            report.xrCrossTabUVadePasif.DataSource = ncheck10;
            report.xrCrossTabOKynkYbKyn.DataSource = ncheck11;
            report.xrCrossTabOKynkAktif.DataSource = ncheck12;





            var chart = (XRChart)report.FindControl("xrChart1", false);
            chart.Series.Clear();
            chart.DataSource = ncheckchart;//Method from documentation you reffered
            chart.SeriesTemplate.SeriesDataMember = "GroupName";
            chart.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart.SeriesTemplate.ValueDataMembers.AddRange("Value");



            var chart1 = (XRChart)report.FindControl("xrChart2", false);
            chart1.Series.Clear();
            chart1.DataSource = ncheckchartb;//Method from documentation you reffered
            chart1.SeriesTemplate.SeriesDataMember = "GroupName";
            chart1.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart1.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart1.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart1.SeriesTemplate.ValueDataMembers.AddRange("Value");

            report.xrChartBnkYabKynk.SeriesTemplate.View = checkSeries;
            report.xrChartBnkYabKynk.DataSource = ncheckchart1;//Method from documentation you reffered
            report.xrChartBnkYabKynk.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartBnkYabKynk.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartBnkYabKynk.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartBnkYabKynk.SeriesTemplate.ValueDataMembers.AddRange("Value"); report.xrChartBnkYabKynk.PaletteName = "PaletteDyn";
            report.xrChartBnkYabKynk.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartBnkAktif.SeriesTemplate.View = checkSeries;
            report.xrChartBnkAktif.DataSource = ncheckchart2;//Method from documentation you reffered
            report.xrChartBnkAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartBnkAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartBnkAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartBnkAktif.SeriesTemplate.ValueDataMembers.AddRange("Value"); report.xrChartBnkAktif.PaletteName = "PaletteDyn";
            report.xrChartBnkAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartDuranOkynk.SeriesTemplate.View = checkSeries;
            report.xrChartDuranOkynk.DataSource = ncheckchart3;//Method from documentation you reffered
            report.xrChartDuranOkynk.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartDuranOkynk.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartDuranOkynk.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartDuranOkynk.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartBnkYabKynk.PaletteName = "PaletteDyn";
            report.xrChartDuranOkynk.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartDonenAktif.SeriesTemplate.View = checkSeries;
            report.xrChartDonenAktif.DataSource = ncheckchart4;//Method from documentation you reffered
            report.xrChartDonenAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartDonenAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartDonenAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartDonenAktif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartDonenAktif.PaletteName = "PaletteDyn";
            report.xrChartDonenAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrChartKVAktif.SeriesTemplate.View = checkSeries;
            report.xrChartKVAktif.DataSource = ncheckchart5;//Method from documentation you reffered
            report.xrChartKVAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartKVAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartKVAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartKVAktif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartKVAktif.PaletteName = "PaletteDyn";
            report.xrChartKVAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrChartKVDonen.SeriesTemplate.View = checkSeries;
            report.xrChartKVDonen.DataSource = ncheckchart6;//Method from documentation you reffered
            report.xrChartKVDonen.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartKVDonen.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartKVDonen.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartKVDonen.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartKVDonen.PaletteName = "PaletteDyn";
            report.xrChartKVDonen.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            //////
            report.xrChartKVPasif.SeriesTemplate.View = checkSeries;
            report.xrChartKVPasif.DataSource = ncheckchart7;//Method from documentation you reffered
            report.xrChartKVPasif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartKVPasif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartKVPasif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartKVPasif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartKVPasif.PaletteName = "PaletteDyn";
            report.xrChartKVPasif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrChartMaddiOzkaynak.SeriesTemplate.View = checkSeries;
            report.xrChartMaddiOzkaynak.DataSource = ncheckchart8;//Method from documentation you reffered
            report.xrChartMaddiOzkaynak.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartMaddiOzkaynak.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartMaddiOzkaynak.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartMaddiOzkaynak.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartMaddiOzkaynak.PaletteName = "PaletteDyn";
            report.xrChartMaddiOzkaynak.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartStokAktif.SeriesTemplate.View = checkSeries;
            report.xrChartStokAktif.DataSource = ncheckchart9;//Method from documentation you reffered
            report.xrChartStokAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartStokAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartStokAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartStokAktif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartStokAktif.PaletteName = "PaletteDyn";
            report.xrChartStokAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartUVadePasif.SeriesTemplate.View = checkSeries;
            report.xrChartUVadePasif.DataSource = ncheckchart10;//Method from documentation you reffered
            report.xrChartUVadePasif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartUVadePasif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartUVadePasif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartUVadePasif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartUVadePasif.PaletteName = "PaletteDyn";
            report.xrChartUVadePasif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartOKynkYbKyn.SeriesTemplate.View = checkSeries;
            report.xrChartOKynkYbKyn.DataSource = ncheckchart11;//Method from documentation you reffered
            report.xrChartOKynkYbKyn.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartOKynkYbKyn.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartOKynkYbKyn.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartOKynkYbKyn.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartOKynkYbKyn.PaletteName = "PaletteDyn";
            report.xrChartOKynkYbKyn.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrChartOKynkAktif.SeriesTemplate.View = checkSeries;
            report.xrChartOKynkAktif.DataSource = ncheckchart12;//Method from documentation you reffered
            report.xrChartOKynkAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartOKynkAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartOKynkAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartOKynkAktif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartOKynkAktif.PaletteName = "PaletteDyn";
            report.xrChartOKynkAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrLblOzkaynak.Text = ncheckKapak.nitemOzkaynakAktif.TumYil.ToString("N2");
            report.xrlblCarioran.Text = ncheckKapak.nitemCariOran.TumYil.ToString("N2");
            report.xrlblROA.Text = (ncheckKapak.nitemROAAktifKarlilik.TumYil * 100).ToString("N2") + "%";
            report.xrlblAltmanZ.Text = ncheckKapak.nitemAltmanz.TumYil.ToString("N2");
            report.xrlblNetIsletmeSerm.Text = ncheckKapak.nitemNetIsletmeSermaye.TumYil.ToString("N0");
            report.xrlblFaizVeVergi.Text = ncheckKapak.nitemFaizVergiOncesiKarZarar.TumYil.ToString("N2");
            report.xrLabelCompanyName.Text = CCompanies.CompanyName;
            report.xrLabelCompanyAdress.Text = CCompanies.Adress;
            report.xrLabelCompanyNace.Text = CCompanies.NaceCode;
  

            report.xrRichTextAnaMetin.Rtf = retvalue;


            report.PrintingSystem.Document.Name = "Balance_raporlar";

            return report;

        }
        public static DynamicReportfour getReportFour(long companyID, List<int> nyearList, string nacceco, long usride_, List<int> nyearChkList)
        {
            if (nacceco != null && nacceco.Length > 0) { Companies.DataReportMainNace(nacceco, companyID); }
            nyearChkList.Reverse() ;
            nyearChkList = nyearChkList.Take(4).ToList();

            nyearList.Reverse();
            nyearList = nyearList.Take(4).ToList();
            int[] nyearListmain = nyearChkList.ToArray();
            int nyear_ = Companies.Get_CompanyReportMaxYear(companyID);
            YearCount = nyearChkList.Count;
            nyearChkList.Sort();
            foreach (int year_ in nyearList)
            {
                ReportSetMain.Set_ReportSetMain(year_, companyID);
                Thread.Sleep(1000);
            }

            var nnlist = Companies.Get_CompanyReportYearMainReport(companyID);
            nnlist.Reverse();
            nnlist = nnlist.Take(4).ToList();
            switch (nnlist.Count)
            {
                case 1: csvDynamiclist = Companies.GetDynamic(companyID, 1); break;
                case 2: csvDynamicIIlist = Companies.GetDynamicII(companyID, 1); break;
                case 3: csvDynamicIIIlist = Companies.GetDynamicIII(companyID, 1); break;
                case 4: csvDynamicIIIIlist = Companies.GetDynamicIIII(companyID, 1); break;
                default:
                    break;
            }

            //var chkkkmain = Companies.GetDynamic(companyID,3);

            string nname = System.Guid.NewGuid().ToString("D") + ".csv";
            var FileDicz = "/FileContent/" + nname;
            var FileDic = "wwwroot\\FileContent\\" + nname;

            //
            string filePathZ = WebHelper.path;
            string FilePath = System.IO.Path.Combine(filePathZ, FileDic);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", HasHeaderRecord = false };
            using (var writer = new StreamWriter(FilePath, append: true))
            {
                using (var csv = new CsvWriter(writer, config))
                {
                    switch (nnlist.Count)
                    {
                        case 1: csv.WriteRecords(csvDynamiclist); break;
                        case 2: csv.WriteRecords(csvDynamicIIlist); break;
                        case 3: csv.WriteRecords(csvDynamicIIIlist); break;
                        case 4: csv.WriteRecords(csvDynamicIIIIlist); break;
                        default:
                            break;
                    }

                }
            }
            nnlist.Sort();
            string replacenull = "Hesap;" + string.Join(";", nnlist);
            replacenull += File.ReadAllText(FilePath);
            replacenull = replacenull.Replace("null", "").Replace("\r\n", "\t");

            string retvalue = Startup.FooServiceInstance.FirstSetupAsync(replacenull).Result;
            try
            {
                int vall = retvalue.IndexOf("Dönen Varlıklar"); if (vall < 0) { vall = 0; }
                retvalue = retvalue.Substring(vall);
                vall = retvalue.IndexOf("**Varlıklar**");
                if (vall < 0) { vall = 0; }
                retvalue = retvalue.Substring(vall);

                retvalue = retvalue.Replace("**", "").Replace("#", "").Replace("-", "");
                Isfailed = false;
                //Color.FromArgb(182,33,45) red
                //Color.FromArgb(23, 127, 117) greeen
                CCompanies = Companies.Get_CompanyRow(companyID);

                companyID = CCompanies.ID;
                compnacecode = CCompanies.NaceCode;

                repchakec = "Kayıtlarda Bir Sorunla Karşılaşıldı";
            header = CCompanies.CompanyName;

            
                var checkedData = MainDash.DataReportMainKapak(nyear_, companyID);
                riskdatachk = RiskData.getListedPoint(checkedData);
                riskdata = RiskData.getPoint(riskdatachk);
                ncheckKapak = ReportKapak.setKapak(checkedData);
                if (ncheckKapak == null)
                {
                    ncheckKapak = new ReportKapak();
                }
                //if (ncheckKapak.nitemAltmanz.TumYil > 7)
                //{
                //    ncheckKapak.nitemAltmanz.TumYil = 7;
                //}
                //if (ncheckKapak.nitemCariOran.IsFailed > 0) { shape1 = Color.FromArgb(182, 33, 45); } else { shape1 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemLikitideOran.IsFailed > 0) { shape2 = Color.FromArgb(182, 33, 45); } else { shape2 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemNakitOran.IsFailed > 0) { shape3 = Color.FromArgb(182, 33, 45); } else { shape3 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemAlacakDevir.IsFailed > 0) { shape4 = Color.FromArgb(182, 33, 45); } else { shape4 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemTicariBorcDevir.IsFailed > 0) { shape5 = Color.FromArgb(182, 33, 45); } else { shape5 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemStokDevir.IsFailed > 0) { shape6 = Color.FromArgb(182, 33, 45); } else { shape6 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemBorcOzsermaye.IsFailed > 0) { shape7 = Color.FromArgb(182, 33, 45); } else { shape7 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemTpolamBankaBorc.IsFailed > 0) { shape8 = Color.FromArgb(182, 33, 45); } else { shape8 = Color.FromArgb(23, 127, 117); };
                //if (ncheckKapak.nitemOzkaynakAktif.IsFailed > 0) { shape9 = Color.FromArgb(182, 33, 45); } else { shape9 = Color.FromArgb(23, 127, 117); };
                ncheck = MainDash.DataReportMainDynamicNew(nyearListmain, companyID);
                nchecka = MainDash.DataReportMainADynamicNew(nyearListmain, companyID);

                ncheck1 = MainDash.DataReportMainBDynamicNew(nyearListmain, companyID);
                ncheck1a = MainDash.DataReportMainCDynamicNew(nyearListmain, companyID);

                ncheckd = MainDash.DataReportMainDDynamicNew(nyearListmain, companyID);
                nchecke = MainDash.DataReportMainEDynamicNew(nyearListmain, companyID);
                ncheckf = MainDash.DataReportMainFDynamicNew(nyearListmain, companyID);
                ncheckg = MainDash.DataReportMainGDynamicNew(nyearListmain, companyID);
                nchecklast = MainDash.DataReportMainTDynamicNew(nyearListmain, companyID);
                ncheckb = new List<ReportMainItem>();

                ncheckb.AddRange(ncheck.Where(x => x.CounterZone == 11).ToList());
                ncheckchart = MainDash.DataReportMainChartMainMulti(ncheckb.OrderBy(x => x.Year));
                ncheckc = new List<ReportMainItem>();
                ncheckc.AddRange(ncheck.Where(x => x.CounterZone == 1011).ToList());
                ncheckchartb = MainDash.DataReportMainChartMainMulti(ncheckc.OrderBy(x => x.Year));
                rdColor = new RiskDataColor();
                ncheck1_ = MainDash.DataReportMain1DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck2 = MainDash.DataReportMain2DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck3 = MainDash.DataReportMain3DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck4 = MainDash.DataReportMain4DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck5 = MainDash.DataReportMain5DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck6 = MainDash.DataReportMain6DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck7 = MainDash.DataReportMain7DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck8 = MainDash.DataReportMain8DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck9 = MainDash.DataReportMain9DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck10 = MainDash.DataReportMain10DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck11 = MainDash.DataReportMain11DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));
                ncheck12 = MainDash.DataReportMain12DynamicNew(nyearListmain, companyID, Convert.ToInt32(compnacecode));

                RiskDataColor.getListedPoint(ncheck1_, 1, false, rdColor);
                RiskDataColor.getListedPoint(ncheck2, 2, false, rdColor);
                RiskDataColor.getListedPoint(ncheck3, 3, false, rdColor);
                RiskDataColor.getListedPoint(ncheck4, 4, false, rdColor);
                RiskDataColor.getListedPoint(ncheck5, 5, false, rdColor);
                RiskDataColor.getListedPoint(ncheck6, 6, false, rdColor);
                RiskDataColor.getListedPoint(ncheck7, 7, false, rdColor);
                RiskDataColor.getListedPoint(ncheck8, 8, false, rdColor);
                RiskDataColor.getListedPoint(ncheck9, 9, false, rdColor);
                RiskDataColor.getListedPoint(ncheck10, 10, false, rdColor);
                RiskDataColor.getListedPoint(ncheck11, 11, false, rdColor);
                RiskDataColor.getListedPoint(ncheck12, 12, false, rdColor);
                ncheckchart1 = MainDash.DataReportMainChartMainMulti(ncheck1_.OrderBy(x => x.Year));
                ncheckchart2 = MainDash.DataReportMainChartMainMulti(ncheck2.OrderBy(x => x.Year));
                ncheckchart3 = MainDash.DataReportMainChartMainMulti(ncheck3.OrderBy(x => x.Year));
                ncheckchart4 = MainDash.DataReportMainChartMainMulti(ncheck4.OrderBy(x => x.Year));
                ncheckchart5 = MainDash.DataReportMainChartMainMulti(ncheck5.OrderBy(x => x.Year));
                ncheckchart6 = MainDash.DataReportMainChartMainMulti(ncheck6.OrderBy(x => x.Year));
                ncheckchart7 = MainDash.DataReportMainChartMainMulti(ncheck7.OrderBy(x => x.Year));
                ncheckchart8 = MainDash.DataReportMainChartMainMulti(ncheck8.OrderBy(x => x.Year));
                ncheckchart9 = MainDash.DataReportMainChartMainMulti(ncheck9.OrderBy(x => x.Year));
                ncheckchart10 = MainDash.DataReportMainChartMainMulti(ncheck10.OrderBy(x => x.Year));
                ncheckchart11 = MainDash.DataReportMainChartMainMulti(ncheck11.OrderBy(x => x.Year));
                ncheckchart12 = MainDash.DataReportMainChartMainMulti(ncheck12.OrderBy(x => x.Year));

            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = companyID;
                lg.CsvID = 9191;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                Isfailed = true;

            }

            DynamicReportfour report = new DynamicReportfour(riskdata, rdColor);

            LineSeriesView checkSeries = new LineSeriesView();

            //report.testlist.AddRange(fields);
            //report.testlistHeader.AddRange(fieldsHeader);
     

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



            report.xrCrossTab1.DataSource = objectDataSource;
            report.xrCrossTab2.DataSource = objectDataSourceA;
            report.xrCrossTabBilancoGenel.DataSource = objectDataSourceB;
            report.xrCrossTabYukumluuk.DataSource = objectDataSourceC;
            report.xrCrossTabKarlk.DataSource = objectDataSourceD;
            report.xrCrossTabBorcOdeme.DataSource = objectDataSourceE;
            report.xrCrossTabLikidite.DataSource = objectDataSourceF;
            report.xrCrossTabSermaye.DataSource = objectDataSourceG;
            report.xrCrossTabRasio.DataSource = objectDataSourceT;

            report.xrCrossTabBnkYabKynk.DataSource = ncheck1_;
            report.xrCrossTabBnkAktif.DataSource = ncheck2;
            report.xrCrossTabDuranOkynk.DataSource = ncheck3;
            report.xrCrossTabDonenAktif.DataSource = ncheck4;
            report.xrCrossTabKVAktif.DataSource = ncheck5;
            report.xrCrossTabKVDonen.DataSource = ncheck6;

            report.xrCrossTabKVPasif.DataSource = ncheck7;
            report.xrCrossTabMaddiOzkaynak.DataSource = ncheck8;
            report.xrCrossTabStokAktif.DataSource = ncheck9;
            report.xrCrossTabUVadePasif.DataSource = ncheck10;
            report.xrCrossTabOKynkYbKyn.DataSource = ncheck11;
            report.xrCrossTabOKynkAktif.DataSource = ncheck12;





            var chart = (XRChart)report.FindControl("xrChart1", false);
            chart.Series.Clear();
            chart.DataSource = ncheckchart;//Method from documentation you reffered
            chart.SeriesTemplate.SeriesDataMember = "GroupName";
            chart.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart.SeriesTemplate.ValueDataMembers.AddRange("Value");



            var chart1 = (XRChart)report.FindControl("xrChart2", false);
            chart1.Series.Clear();
            chart1.DataSource = ncheckchartb;//Method from documentation you reffered
            chart1.SeriesTemplate.SeriesDataMember = "GroupName";
            chart1.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart1.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart1.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart1.SeriesTemplate.ValueDataMembers.AddRange("Value");

            report.xrChartBnkYabKynk.SeriesTemplate.View = checkSeries;
            report.xrChartBnkYabKynk.DataSource = ncheckchart1;//Method from documentation you reffered
            report.xrChartBnkYabKynk.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartBnkYabKynk.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartBnkYabKynk.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartBnkYabKynk.SeriesTemplate.ValueDataMembers.AddRange("Value"); report.xrChartBnkYabKynk.PaletteName = "PaletteDyn";
            report.xrChartBnkYabKynk.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartBnkAktif.SeriesTemplate.View = checkSeries;
            report.xrChartBnkAktif.DataSource = ncheckchart2;//Method from documentation you reffered
            report.xrChartBnkAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartBnkAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartBnkAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartBnkAktif.SeriesTemplate.ValueDataMembers.AddRange("Value"); report.xrChartBnkAktif.PaletteName = "PaletteDyn";
            report.xrChartBnkAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartDuranOkynk.SeriesTemplate.View = checkSeries;
            report.xrChartDuranOkynk.DataSource = ncheckchart3;//Method from documentation you reffered
            report.xrChartDuranOkynk.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartDuranOkynk.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartDuranOkynk.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartDuranOkynk.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartBnkYabKynk.PaletteName = "PaletteDyn";
            report.xrChartDuranOkynk.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartDonenAktif.SeriesTemplate.View = checkSeries;
            report.xrChartDonenAktif.DataSource = ncheckchart4;//Method from documentation you reffered
            report.xrChartDonenAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartDonenAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartDonenAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartDonenAktif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartDonenAktif.PaletteName = "PaletteDyn";
            report.xrChartDonenAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrChartKVAktif.SeriesTemplate.View = checkSeries;
            report.xrChartKVAktif.DataSource = ncheckchart5;//Method from documentation you reffered
            report.xrChartKVAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartKVAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartKVAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartKVAktif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartKVAktif.PaletteName = "PaletteDyn";
            report.xrChartKVAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrChartKVDonen.SeriesTemplate.View = checkSeries;
            report.xrChartKVDonen.DataSource = ncheckchart6;//Method from documentation you reffered
            report.xrChartKVDonen.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartKVDonen.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartKVDonen.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartKVDonen.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartKVDonen.PaletteName = "PaletteDyn";
            report.xrChartKVDonen.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            //////
            report.xrChartKVPasif.SeriesTemplate.View = checkSeries;
            report.xrChartKVPasif.DataSource = ncheckchart7;//Method from documentation you reffered
            report.xrChartKVPasif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartKVPasif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartKVPasif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartKVPasif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartKVPasif.PaletteName = "PaletteDyn";
            report.xrChartKVPasif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrChartMaddiOzkaynak.SeriesTemplate.View = checkSeries;
            report.xrChartMaddiOzkaynak.DataSource = ncheckchart8;//Method from documentation you reffered
            report.xrChartMaddiOzkaynak.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartMaddiOzkaynak.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartMaddiOzkaynak.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartMaddiOzkaynak.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartMaddiOzkaynak.PaletteName = "PaletteDyn";
            report.xrChartMaddiOzkaynak.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartStokAktif.SeriesTemplate.View = checkSeries;
            report.xrChartStokAktif.DataSource = ncheckchart9;//Method from documentation you reffered
            report.xrChartStokAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartStokAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartStokAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartStokAktif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartStokAktif.PaletteName = "PaletteDyn";
            report.xrChartStokAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartUVadePasif.SeriesTemplate.View = checkSeries;
            report.xrChartUVadePasif.DataSource = ncheckchart10;//Method from documentation you reffered
            report.xrChartUVadePasif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartUVadePasif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartUVadePasif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartUVadePasif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartUVadePasif.PaletteName = "PaletteDyn";
            report.xrChartUVadePasif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;


            report.xrChartOKynkYbKyn.SeriesTemplate.View = checkSeries;
            report.xrChartOKynkYbKyn.DataSource = ncheckchart11;//Method from documentation you reffered
            report.xrChartOKynkYbKyn.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartOKynkYbKyn.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartOKynkYbKyn.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartOKynkYbKyn.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartOKynkYbKyn.PaletteName = "PaletteDyn";
            report.xrChartOKynkYbKyn.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrChartOKynkAktif.SeriesTemplate.View = checkSeries;
            report.xrChartOKynkAktif.DataSource = ncheckchart12;//Method from documentation you reffered
            report.xrChartOKynkAktif.SeriesTemplate.SeriesDataMember = "GroupName";
            report.xrChartOKynkAktif.SeriesTemplate.Label.TextPattern = "{V:n2}";
            report.xrChartOKynkAktif.SeriesTemplate.ArgumentDataMember = "GroupText";
            report.xrChartOKynkAktif.SeriesTemplate.ValueDataMembers.AddRange("Value");
            report.xrChartOKynkAktif.PaletteName = "PaletteDyn";
            report.xrChartOKynkAktif.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            report.xrLblOzkaynak.Text = ncheckKapak.nitemOzkaynakAktif.TumYil.ToString("N2");
            report.xrlblCarioran.Text = ncheckKapak.nitemCariOran.TumYil.ToString("N2");
            report.xrlblROA.Text = (ncheckKapak.nitemROAAktifKarlilik.TumYil * 100).ToString("N2") + "%";
            report.xrlblAltmanZ.Text = ncheckKapak.nitemAltmanz.TumYil.ToString("N2");
            report.xrlblNetIsletmeSerm.Text = ncheckKapak.nitemNetIsletmeSermaye.TumYil.ToString("N0");
            report.xrlblFaizVeVergi.Text = ncheckKapak.nitemFaizVergiOncesiKarZarar.TumYil.ToString("N2");
            report.xrLabelCompanyName.Text = CCompanies.CompanyName;
            report.xrLabelCompanyAdress.Text = CCompanies.Adress;
            report.xrLabelCompanyNace.Text = CCompanies.NaceCode;
            //var xrlbl1 = (XRLabel)report.FindControl("xrLblOzkaynak", false);
            //xrlbl1.Text = ncheckKapak.nitemOzkaynakAktif.TumYil.ToString("N2");

            //var xrlbl2 = (XRLabel)report.FindControl("xrlblCarioran", false);
            //xrlbl2.Text = ncheckKapak.nitemCariOran.TumYil.ToString("N2");


            //var xrlbl3 = (XRLabel)report.FindControl("xrlblROA", false);
            //xrlbl3.Text = (ncheckKapak.nitemROAAktifKarlilik.TumYil * 100).ToString("N2") + "%";



            //var xrlbl5 = (XRLabel)report.FindControl("xrlblAltmanZ", false);
            //xrlbl5.Text = ncheckKapak.nitemAltmanz.TumYil.ToString("N2");


            //var xrlbl6 = (XRLabel)report.FindControl("xrlblNetIsletmeSerm", false);
            //xrlbl6.Text = ncheckKapak.nitemNetIsletmeSermaye.TumYil.ToString("N0");


            //var xrlbl7 = (XRLabel)report.FindControl("xrlblFaizVeVergi", false);
            //xrlbl7.Text = ncheckKapak.nitemFaizVergiOncesiKarZarar.TumYil.ToString("N2");



            report.xrRichTextAnaMetin.Rtf = retvalue;

            report.PrintingSystem.Document.Name = "Balance_raporlar";

            return report;

        }
    }
}
