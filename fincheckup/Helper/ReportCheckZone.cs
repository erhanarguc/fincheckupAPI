using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using fincheckup.ENTITY;
using fincheckup.Models.Hvvn;
using fincheckup.Models.ViewM;
using fincheckup.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace fincheckup.Helper
{
    public static class ReportCheckZone
    {

        public static int YearCurrent { get; set; }
        public static string YearCurrentTx { get; set; }
        public static int YearCurrenta { get; set; }
        public static string YearCurrentaTx { get; set; }
        public static int YearCurrentb { get; set; }
        public static string YearCurrentbTx { get; set; }
        public static int YearCurrentc { get; set; }
        public static string YearCurrentcTx { get; set; }
        public static long UserID { get; set; }
        public static List<DashBilancoViewQnb> ncheck { get; set; }

        public static List<DashBilancoViewQnb> ncheck1 { get; set; }
        public static DashBilancoViewQnb ncheck3 { get; set; }
        public static DashBilancoViewQnb ncheck41 { get; set; }
        public static DashBilancoViewQnb ncheck43 { get; set; }
        public static List<DashBilancoViewQnb> ncheck5 { get; set; }


        public static List<DashBilancoViewQnb> ncheck7 { get; set; }
        public static List<DashBilancoViewQnb> ncheck9 { get; set; }
        public static List<DashBilancoViewQnb> ncheck11 { get; set; }
        public static DashBilancoViewQnb ncheck7b { get; set; }
        public static DashBilancoViewQnb ncheck9b { get; set; }
        public static DashBilancoViewQnb ncheck11b { get; set; }

        public static DashBilancoViewQnb ncheck11c { get; set; }
        public static DashBilancoViewQnb ncheck11d { get; set; }
        public static LineSeriesView checkSeries { get; set; }
        public static List<DashBilancoViewQnb> ncheckGelir { get; set; }
        public static List<DashBilancoViewQnb> ncheck13 { get; set; }
        public static DashBilancoViewQnb ncheck13brut { get; set; }

        public static DashBilancoViewQnb ncheck15 { get; set; }
        public static DashBilancoViewQnb ncheck15a { get; set; }

        public static DashBilancoViewQnb ncheck17 { get; set; }
        public static DashBilancoViewQnb ncheck17a { get; set; }
        public static List<ReportMainChartQnb> ncheckchartzone { get; set; }
        public static List<ReportMainItemQnb> _ncheckzone { get; set; }
        public static List<ReportMainItemQnb> _ncheck1 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart1 { get; set; }
        public static List<ReportMainItemQnb> _ncheck2 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart2 { get; set; }
        public static List<ReportMainItemQnb> _ncheck3 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart3 { get; set; }
        public static List<ReportMainItemQnb> _ncheck4 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart4 { get; set; }
        public static List<ReportMainItemQnb> _ncheck5 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart5 { get; set; }
        public static List<ReportMainItemQnb> _ncheck7 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart7 { get; set; }
        public static List<ReportMainItemQnb> _ncheck8 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart8 { get; set; }
        public static List<ReportMainItemQnb> _ncheck9 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart9 { get; set; }
        public static List<ReportMainItemQnb> _ncheck10 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart10 { get; set; }
        public static List<ReportMainItemQnb> _ncheck11 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart11 { get; set; }
        public static List<ReportMainItemQnb> _ncheck13 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart13 { get; set; }
        public static List<ReportMainItemQnb> _ncheck14 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart14 { get; set; }
        public static List<ReportMainItemQnb> _ncheck15 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart15 { get; set; }
        public static List<ReportMainItemQnb> _ncheck16 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart16 { get; set; }
        public static List<ReportMainItemQnb> _ncheck17 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart17 { get; set; }
        public static List<ReportMainItemQnb> _ncheck18 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart18 { get; set; }
        public static List<ReportMainItemQnb> _ncheck19 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart19 { get; set; }
        public static List<ReportMainItemQnb> _ncheck20 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart20 { get; set; }
        public static List<ReportMainItemQnb> _ncheck21 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart21 { get; set; }
        public static List<ReportMainItemQnb> _ncheck22 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart22 { get; set; }
        public static List<ReportMainItemQnb> _ncheck23 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart23 { get; set; }
        public static List<ReportMainItemQnb> _ncheck24 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart24 { get; set; }
        public static List<ReportMainItemQnb> _ncheck25 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart25 { get; set; }
        public static List<ReportMainItemQnb> _ncheck27 { get; set; }
        public static List<ReportMainChartQnb> ncheckchart27 { get; set; }
        public static DashBilancoViewQnb ncheck19 { get; set; }

        public static DashBilancoViewQnb ncheck21 { get; set; }
        public static DashBilancoViewQnb ncheck21a { get; set; }

        public static List<DashBilancoViewQnb> ncheck23 { get; set; }

        public static List<DashBilancoViewQnb> ncheck13Check { get; set; }

        public static DashBilancoViewQnb ncheck25 { get; set; }
        public static DashBilancoViewQnb ncheck27 { get; set; }

        public static int setReportZone(long companyID, List<int> nyear,int chkMizan=0)
        {


            foreach (var item in nyear)
            {
                List<DashBilancoViewQnb> nRequestList = DashBilancoViewMainQnb.getList(item, companyID);
                var tlist = Data.SetBilancoFromListQnb(nRequestList, companyID, item, 1);

                List<DashBilancoViewQnb> nRequestLista = DashBilancoViewMainQnb.getListToplam(item, companyID);
                var tlista = Data.SetBilancoFromListQnb(nRequestLista, companyID, item, 2);

                List<DashBilancoViewQnb> nRequestList1 = DashBilancoViewMainQnb.getListA(item, companyID);
                var tlist1 = Data.SetBilancoFromListQnb(nRequestList1, companyID, item, 3);

                List<DashBilancoViewQnb> nRequestList1a = DashBilancoViewMainQnb.getListAToplam(item, companyID);
                var tlist1a = Data.SetBilancoFromListQnb(nRequestList1a, companyID, item, 4);

                List<DashBilancoViewQnb> nRequestList3 = DashBilancoViewMainQnb.getListB(item, companyID);
                var tlist3 = Data.SetBilancoFromListQnb(nRequestList3, companyID, item, 5);

                List<DashBilancoViewQnb> nRequestList3a = DashBilancoViewMainQnb.getListBToplam(item, companyID);
                var tlist3a = Data.SetBilancoFromListQnb(nRequestList3a, companyID, item, 6);

                List<DashBilancoViewQnb> nRequestList5 = DashBilancoViewMainQnb.getListC(item, companyID);
                var tlist5 = Data.SetBilancoFromListQnb(nRequestList5, companyID, item, 7);

                List<DashBilancoViewQnb> nRequestList5a = DashBilancoViewMainQnb.getListCToplam(item, companyID);
                var tlist5a = Data.SetBilancoFromListQnb(nRequestList5a, companyID, item, 8);

                List<DashBilancoViewQnb> nRequestList7 = DashBilancoViewMainQnb.getListD(item, companyID);
                var tlist7 = Data.SetBilancoFromListQnb(nRequestList7, companyID, item, 9);

                List<DashBilancoViewQnb> nRequestList7a = DashBilancoViewMainQnb.getListDToplam(item, companyID);
                var tlist7a = Data.SetBilancoFromListQnb(nRequestList7a, companyID, item, 11);


                tlist.AddRange(tlista);
                tlist.AddRange(tlist1);
                tlist.AddRange(tlist1a);
                tlist.AddRange(tlist3);
                tlist.AddRange(tlist3a);
                tlist.AddRange(tlist5);
                tlist.AddRange(tlist5a);
                tlist.AddRange(tlist7);
                tlist.AddRange(tlist7a);
                Data.InsertBilncoQnb(tlist);



                List<DashBilancoViewQnb> nRequestList21 = DashBilancoViewMainQnbGelir.getList(item, companyID);
                var tlist21 = Data.SetBilancoFromListQnb(nRequestList21, companyID, item, 13);

                List<DashBilancoViewQnb> nRequestList21a = DashBilancoViewMainQnbGelir.getListA(item, companyID);
                var tlist21a = Data.SetBilancoFromListQnb(nRequestList21a, companyID, item, 15);

                List<DashBilancoViewQnb> nRequestList21b = DashBilancoViewMainQnbGelir.getListB(item, companyID);
                var tlist21b = Data.SetBilancoFromListQnb(nRequestList21b, companyID, item, 17);

                List<DashBilancoViewQnb> nRequestList21c = DashBilancoViewMainQnbGelir.getListC(item, companyID);
                var tlist21c = Data.SetBilancoFromListQnb(nRequestList21c, companyID, item, 19);

                List<DashBilancoViewQnb> nRequestList21d = DashBilancoViewMainQnbGelir.getListD(item, companyID);
                var tlist21d = Data.SetBilancoFromListQnb(nRequestList21d, companyID, item, 21);

                List<DashBilancoViewQnb> nRequestList21e = DashBilancoViewMainQnbGelir.getListE(item, companyID);
                var tlist21e = Data.SetBilancoFromListQnb(nRequestList21e, companyID, item, 23);


                List<DashBilancoViewQnb> nRequestList21f = DashBilancoViewMainQnbGelir.getListF(item, companyID);
                var tlist21f = Data.SetBilancoFromListQnb(nRequestList21f, companyID, item, 25);

                List<DashBilancoViewQnb> nRequestList21g = DashBilancoViewMainQnbGelir.getListG(item, companyID);
                var tlist21g = Data.SetBilancoFromListQnb(nRequestList21g, companyID, item, 27);

                List<DashBilancoViewQnb> nRequestList21h = DashBilancoViewMainQnbGelir.getListH(item, companyID);
                var tlist21h = Data.SetBilancoFromListQnb(nRequestList21h, companyID, item, 29);

                List<DashBilancoViewQnb> nRequestList21i = DashBilancoViewMainQnbGelir.getListI(item, companyID);
                var tlist21i = Data.SetBilancoFromListQnb(nRequestList21i, companyID, item, 31);

                tlist21.AddRange(tlist21a);
                tlist21.AddRange(tlist21b);
                tlist21.AddRange(tlist21c);
                tlist21.AddRange(tlist21d);
                tlist21.AddRange(tlist21e);
                tlist21.AddRange(tlist21f);
                tlist21.AddRange(tlist21g);
                tlist21.AddRange(tlist21h);
                tlist21.AddRange(tlist21i);
                Data.InsertBilncoQnbGelir(tlist21);
                DashBilancoViewMainQnbGelir.setListSektor(item, companyID, chkMizan);
                Thread.Sleep(500);

            }





            return 1;

        }

        public static string RepText1(List<int> year, int type, string naccecode)
        {
            string repval = string.Empty;
            string yearStrList = string.Join<int>("-", year);
            int maxyearTcmb = Companies.Get_LastTCMBReportYear();
            string naccedesc = NaceCode.Get_Description(naccecode);
            switch (type)
            {
                case 1: repval = QnbWording.Wording_2_1.Replace("(x)", year[0].ToString()).Replace("(xx)", naccedesc).Replace("(xxx)", maxyearTcmb.ToString()); break;
                case 2: repval = QnbWording.Wording_2_2.Replace("(xxx)", maxyearTcmb.ToString()).Replace("(xx)", naccedesc).Replace("(x)-(x)", yearStrList).Replace("(x)", maxyearTcmb.ToString()); break;
                case 3: repval = QnbWording.Wording_2_3.Replace("(x)", year[0].ToString()).Replace("(xx)", naccedesc).Replace("(xxx)", maxyearTcmb.ToString()); break;
                case 4: repval = QnbWording.Wording_2_4.Replace("(xxx)", maxyearTcmb.ToString()).Replace("(xx)", naccedesc).Replace("(x)-(x)", yearStrList).Replace("(x)", maxyearTcmb.ToString()); break;
                default:
                    break;
            }

            repval += "<br>" + QnbWording.Wording_3_2_7;

            return repval;



        }

        public static string RepText3(List<int> year, long companyID, int yearLast, int type)
        {
            string repval = string.Empty;
            string yearStrList = string.Join<int>("-", year);
            Dictionary<int, string> testdiCt = new Dictionary<int, string>();
            testdiCt.Add(
                1, "•	Ticari işletmelerin belirli bir zaman aralığında gerçekleştirdikleri faaliyetlerden elde ettikleri hasılatı gösteren “Firma Satışları” ");
            testdiCt.Add(
          5, "•	Bir işletmenin faaliyetleri sonucunda sürdürülebilir gelir elde edebilme kabiliyetini gösteren “Karlılık” ");
            testdiCt.Add(
          7, "•	İşletmelerin varlıklarını finanse ederken kullandığı yabancı kaynakların yükünü ölçen “Borçluluk”  ");
            testdiCt.Add(
          3, "•	Küresel ve rekabetçi iş dünyasında işletmelerin faaliyetlerinde sürekliliği sağlamaları ve gelir-gider kontrolünü sağlamanın temel anahtarlarından biri olan “Maliyet Yönetimi” ");
            testdiCt.Add(
          9, "•	Bir işletmenin faaliyetlerinden elde ettiği gelir ile yükümlülüklerini yerine getirebilme gücünü gösteren “Finansal Yükümlülükler”  ");
            testdiCt.Add(
     11, "•	İşletmenin kısa vadeli yükümlülüklerini karşılayabilme gücünü ölçen “Finansal Yapı ve Likidite”  ");


            float ReelPuan = Companies.Get_ReportREELPUAN(companyID);
            List<RepUstKalemPuan> listUstKalem = Companies.Get_UstKalemPuan(companyID);


            if (ReelPuan > 70)
            {
                repval = QnbWording.Wording_3_2_1.Replace("(x)", yearLast.ToString());

            }
            else if (ReelPuan < 50)
            {
                repval = QnbWording.Wording_3_2_3.Replace("(x)", yearLast.ToString());
            }
            else
            {
                repval = QnbWording.Wording_3_2_2.Replace("(x)", yearLast.ToString());
            }

            List<RepUstKalemPuan> chkListTop = listUstKalem.Where(x => x.USTKALEMPUAN > 70).ToList();
            List<RepUstKalemPuan> chkListMiddle = listUstKalem.Where(x => x.USTKALEMPUAN < 50).ToList();
            if (chkListTop.Count > 0)
            {

                var check = chkListTop.Take(3);

                List<string> resultRep = testdiCt.Where(x => check.Select(x => x.MainID).Contains(x.Key))
                    .Select(x => x.Value)
                    .ToList();
                repval += "<br>" + QnbWording.Wording_3_2_4.Replace("(x)-(x)", yearStrList);
                foreach (var item in resultRep)
                {
                    repval += item + "<br>";
                }


                if (chkListMiddle.Count > 0)
                {
                    check = chkListMiddle.Take(2);
                    resultRep = testdiCt.Where(x => check.Select(x => x.MainID).Contains(x.Key))
                        .Select(x => x.Value)
                        .ToList();
                    repval += "<br>" + QnbWording.Wording_3_2_5_non;
                    foreach (var item in resultRep)
                    {
                        repval += item + "<br>";
                    }
                }


            }
            else
            {
                if (chkListMiddle.Count > 0)
                {
                    var check = chkListMiddle.Take(2);

                    List<string> resultRep = testdiCt.Where(x => check.Select(x => x.MainID).Contains(x.Key))
                        .Select(x => x.Value)
                        .ToList();
                    repval += "<br>" + QnbWording.Wording_3_2_5_;
                    foreach (var item in resultRep)
                    {
                        repval += item + "<br>";
                    }
                }
            }

            repval += "<br>" + QnbWording.Wording_3_2_7;
            return repval;



        }
        public static string RepText4(long companyID, int yearLast)
        {
            string repval = string.Empty;
            Dictionary<int, string> testdiCt = new Dictionary<int, string>();
            testdiCt.Add(
                1, "•	Ticari işletmelerin belirli bir zaman aralığında gerçekleştirdikleri faaliyetlerden elde ettikleri hasılatı gösteren “Firma Satışları” ");
            testdiCt.Add(
          5, "•	Bir işletmenin faaliyetleri sonucunda sürdürülebilir gelir elde edebilme kabiliyetini gösteren “Karlılık” ");
            testdiCt.Add(
          7, "•	İşletmelerin varlıklarını finanse ederken kullandığı yabancı kaynakların yükünü ölçen “Borçluluk”  ");
            testdiCt.Add(
          3, "•	Küresel ve rekabetçi iş dünyasında işletmelerin faaliyetlerinde sürekliliği sağlamaları ve gelir-gider kontrolünü sağlamanın temel anahtarlarından biri olan “Maliyet Yönetimi” ");
            testdiCt.Add(
          9, "•	Bir işletmenin faaliyetlerinden elde ettiği gelir ile yükümlülüklerini yerine getirebilme gücünü gösteren “Finansal Yükümlülükler”  ");
            testdiCt.Add(
     11, "•	İşletmenin kısa vadeli yükümlülüklerini karşılayabilme gücünü ölçen “Finansal Yapı ve Likidite”  ");


            float ReelPuan = Companies.Get_ReportREELPUAN(companyID);
            List<RepUstKalemPuan> listUstKalem = Companies.Get_UstKalemPuan(companyID);


            if (ReelPuan > 70)
            {
                repval = QnbWording.Wording_3_3_1.Replace("(x)", yearLast.ToString());

            }
            else if (ReelPuan < 50)
            {
                repval = QnbWording.Wording_3_3_2.Replace("(x)", yearLast.ToString());
            }
            else
            {
                repval = QnbWording.Wording_3_3_3.Replace("(x)", yearLast.ToString());
            }

            List<RepUstKalemPuan> chkListTop = listUstKalem.Where(x => x.USTKALEMPUAN > 70).ToList();
            List<RepUstKalemPuan> chkListMiddle = listUstKalem.Where(x => x.USTKALEMPUAN < 50).ToList();
            if (chkListTop.Count > 0)
            {

                var check = chkListTop.Take(3);

                List<string> resultRep = testdiCt.Where(x => check.Select(x => x.MainID).Contains(x.Key))
                    .Select(x => x.Value)
                    .ToList();
                repval += "<br>" + QnbWording.Wording_3_3_4;
                foreach (var item in resultRep)
                {
                    repval += item + "<br>";
                }


                if (chkListMiddle.Count > 0)
                {
                    check = chkListMiddle.Take(2);
                    resultRep = testdiCt.Where(x => check.Select(x => x.MainID).Contains(x.Key))
                        .Select(x => x.Value)
                        .ToList();
                    repval += "<br>" + QnbWording.Wording_3_3_5_non;
                    foreach (var item in resultRep)
                    {
                        repval += item + "<br>";
                    }
                }


            }
            else
            {
                if (chkListMiddle.Count > 0)
                {
                    var check = chkListMiddle.Take(2);

                    List<string> resultRep = testdiCt.Where(x => check.Select(x => x.MainID).Contains(x.Key))
                        .Select(x => x.Value)
                        .ToList();
                    repval += "<br>" + QnbWording.Wording_3_3_5_;
                    foreach (var item in resultRep)
                    {
                        repval += item + "<br>";
                    }
                }
            }

            repval += "<br>" + QnbWording.Wording_3_3_7;
            return repval;



        }

        public static string RepText5(long companyID, int yearLast)
        {
            int maxyearTcmb = Companies.Get_LastTCMBReportYear();
            string repval = string.Empty;
            Dictionary<int, string> testdiCt = new Dictionary<int, string>();
            testdiCt.Add(
                1, "•	Ticari işletmelerin belirli bir zaman aralığında gerçekleştirdikleri faaliyetlerden elde ettikleri hasılatı gösteren “Firma Satışları” ");
            testdiCt.Add(
          5, "•	Bir işletmenin faaliyetleri sonucunda sürdürülebilir gelir elde edebilme kabiliyetini gösteren “Karlılık” ");
            testdiCt.Add(
          7, "•	İşletmelerin varlıklarını finanse ederken kullandığı yabancı kaynakların yükünü ölçen “Borçluluk”  ");
            testdiCt.Add(
          3, "•	Küresel ve rekabetçi iş dünyasında işletmelerin faaliyetlerinde sürekliliği sağlamaları ve gelir-gider kontrolünü sağlamanın temel anahtarlarından biri olan “Maliyet Yönetimi” ");
            testdiCt.Add(
          9, "•	Bir işletmenin faaliyetlerinden elde ettiği gelir ile yükümlülüklerini yerine getirebilme gücünü gösteren “Finansal Yükümlülükler”  ");
            testdiCt.Add(
     11, "•	İşletmenin kısa vadeli yükümlülüklerini karşılayabilme gücünü ölçen “Finansal Yapı ve Likidite”  ");


            float ReelPuan = Companies.Get_ReportREELPUAN(companyID);

            float SectorTrendPerc = Companies.Get_ReportSectorTrendPerc(companyID);
            float TrendSectorPerc = Companies.Get_ReportTrendSectorPerc(companyID);
            List<RepUstKalemPuan> listUstKalem = Companies.Get_UstKalemPuan(companyID);


            if (ReelPuan > 70)
            {


                if (SectorTrendPerc > 25)
                {
                    repval = QnbWording.Wording_3_4_1_1.Replace("(x)", maxyearTcmb.ToString());
                }
                else if (TrendSectorPerc > 25)
                {
                    repval = QnbWording.Wording_3_4_1_2.Replace("(x)", maxyearTcmb.ToString());
                }

            }
            else if (ReelPuan < 50)
            {

            }
            else
            {
                //repval = QnbWording.Wording_3_4_2_1.Replace("(x)", maxyearTcmb.ToString());
                if (SectorTrendPerc > 25)
                {
                    repval += "<br>" + QnbWording.Wording_3_4_2_2.Replace("(x)", maxyearTcmb.ToString());
                }
                else if (TrendSectorPerc > 25)
                {
                    repval += "<br>" + QnbWording.Wording_3_4_2_3.Replace("(x)", maxyearTcmb.ToString());
                }
            }

            List<RepUstKalemPuan> chkListTop = listUstKalem.Where(x => x.USTKALEMPUAN > 70).ToList();
            List<RepUstKalemPuan> chkListMiddle = listUstKalem.Where(x => x.USTKALEMPUAN < 50).ToList();
            if (chkListTop.Count > 0)
            {

                var check = chkListTop.Take(3);

                List<string> resultRep = testdiCt.Where(x => check.Select(x => x.MainID).Contains(x.Key))
                    .Select(x => x.Value)
                    .ToList();
                repval += "<br>" + QnbWording.Wording_3_4_4 + "<br>";
                foreach (var item in resultRep)
                {
                    repval += item + "<br>";
                }


                if (chkListMiddle.Count > 0)
                {
                    check = chkListMiddle.Take(2);
                    resultRep = testdiCt.Where(x => check.Select(x => x.MainID).Contains(x.Key))
                        .Select(x => x.Value)
                        .ToList();
                    repval += "<br>" + QnbWording.Wording_3_4_5_nok + "<br>";
                    foreach (var item in resultRep)
                    {
                        repval += item + "<br>";
                    }
                }


            }
            else
            {
                if (chkListMiddle.Count > 0)
                {
                    var check = chkListMiddle.Take(2);

                    List<string> resultRep = testdiCt.Where(x => check.Select(x => x.MainID).Contains(x.Key))
                        .Select(x => x.Value)
                        .ToList();
                    repval += "<br>" + QnbWording.Wording_3_4_5_ + "<br>";
                    foreach (var item in resultRep)
                    {
                        repval += item + "<br>";
                    }
                }
            }

            //repval += "<br>"  + "<br>"  + QnbWording.Wording_3_4_7;
            return repval;



        }
        public static FinansRaporu getReport(long companyID, List<int> nyear, string nacceco, long usride_, int lastyear_, CompanyReportView grview, int chkMizan = 0)
        {
            YearCurrent = lastyear_;

            Companies.DataReportMainNace(nacceco, companyID);
            grview = Companies.Get_CompanyReportView(companyID);
            setReportZone(companyID, nyear, chkMizan);

            int chk = Companies.DataReportMainLastMonth(YearCurrent, companyID);
            YearCurrentTx = YearCurrent.ToString() + " - " + chk.ToString();
            int maxyearTcmb = Companies.Get_LastTCMBReportYear();
            string metin = string.Empty;
            List<int> nyearchk = new List<int>();
            nyearchk.Add(YearCurrent);
            if (lastyear_ == maxyearTcmb)
            {
                metin = "<html><body>" + RepText1(nyearchk, 3, nacceco);
                metin += "<br>" + RepText4(companyID, YearCurrent);
            }
            else
            {
                metin = RepText1(nyearchk, 1, nacceco);
            }
            metin += "</body></html>";


            ncheck = MainDash.DataReportMainQnbT(companyID);

            ncheck1 = ncheck.Where(x => x.MainTypeID == 1).ToList();

            ncheck3 = ncheck.Where(x => x.MainTypeID == 2).FirstOrDefault();
            //ncheck1 = reportZone.getReverse(ncheck1, ncheck3.Amount);


            ncheck5 = ncheck.Where(x => x.MainTypeID == 3).ToList();
            ncheck41 = ncheck.Where(x => x.MainTypeID == 4 && x.TypeID == 471).FirstOrDefault();
            ncheck43 = ncheck.Where(x => x.MainTypeID == 4 && x.TypeID == 473).FirstOrDefault();
            //ncheck3 = reportZone.getReverseSingle(ncheck3, ncheck43.Amount);
            //ncheck41 = reportZone.getReverseSingle(ncheck41, ncheck43.Amount);
            //ncheck5 = reportZone.getReverse(ncheck5, ncheck41.Amount);

            // 2.Sayfa

            ncheck7 = ncheck.Where(x => x.MainTypeID == 5).ToList();
            ncheck9 = ncheck.Where(x => x.MainTypeID == 7).ToList();
            ncheck11 = ncheck.Where(x => x.MainTypeID == 9).ToList();
            ncheck7b = ncheck.Where(x => x.MainTypeID == 6).FirstOrDefault();
            ncheck9b = ncheck.Where(x => x.MainTypeID == 8).FirstOrDefault();
            ncheck11b = ncheck.Where(x => x.TypeID == 951).FirstOrDefault();

            ncheck11c = ncheck.Where(x => x.TypeID == 953).FirstOrDefault();
            ncheck11d = ncheck.Where(x => x.TypeID == 955).FirstOrDefault();

            //ncheck7 = reportZone.getReverse(ncheck7, ncheck7b.Amount);
            //ncheck9 = reportZone.getReverse(ncheck9, ncheck9b.Amount);
            //ncheck11 = reportZone.getReverse(ncheck11, ncheck11b.Amount);

            //ncheck7b = reportZone.getReverseSingle(ncheck7b, ncheck11d.Amount);
            //ncheck9b = reportZone.getReverseSingle(ncheck9b, ncheck11d.Amount);
            //ncheck11b = reportZone.getReverseSingle(ncheck11b, ncheck11d.Amount);
            //ncheck11c = reportZone.getReverseSingle(ncheck11c, ncheck11d.Amount);


            //gelirler
            ncheckGelir = MainDash.DataReportMainQnbGelirT(companyID);
            ncheck13 = ncheckGelir.Where(x => x.MainTypeID == 13).ToList();
            ncheck13brut = ncheckGelir.Where(x => x.TypeID == 109).FirstOrDefault();

            ncheck15 = ncheckGelir.Where(x => x.TypeID == 111).FirstOrDefault();
            ncheck15a = ncheckGelir.Where(x => x.TypeID == 113).FirstOrDefault();

            ncheck17 = ncheckGelir.Where(x => x.TypeID == 115).FirstOrDefault();
            ncheck17a = ncheckGelir.Where(x => x.TypeID == 117).FirstOrDefault();

            ncheck13Check = ncheckGelir.Where(x => x.MainTypeID == 23).ToList();

            ncheck19 = ncheckGelir.Where(x => x.TypeID == 125).FirstOrDefault();

            ncheck23 = ncheckGelir.Where(x => x.MainTypeID == 27).ToList();


            ncheck25 = ncheckGelir.Where(x => x.TypeID == 133).FirstOrDefault();

            ncheck27 = ncheckGelir.Where(x => x.TypeID == 135).FirstOrDefault();

            //var tst = ncheck13.Where(x => x.MainTypeID == 13 && x.TypeID == 101).FirstOrDefault();
            //ncheck13 = reportZone.getReverse(ncheck13, ncheck25.Amount);
            //ncheck13brut = reportZone.getReverseSingle(ncheck13brut, ncheck25.Amount);
            //ncheck15 = reportZone.getReverseSingle(ncheck15, ncheck25.Amount);
            //ncheck15a = reportZone.getReverseSingle(ncheck15a, ncheck25.Amount);
            //ncheck17 = reportZone.getReverseSingle(ncheck17, ncheck25.Amount);
            //ncheck17a = reportZone.getReverseSingle(ncheck17a, ncheck25.Amount);

            //tst = reportZone.getReverseSingle(tst, tst.Amount);

            //ncheck13Check = reportZone.getReverse(ncheck13Check, ncheck25.Amount);

            //ncheck19 = reportZone.getReverseSingle(ncheck19, ncheck25.Amount);
            //ncheck23 = reportZone.getReverse(ncheck23, ncheck25.Amount);

            //ncheck25 = reportZone.getReverseSingle(ncheck25, ncheck25.Amount);
            // chartlar
            _ncheckzone = MainDash.DataReportMain1DynamicMain(companyID);
            ncheckchartzone = MainDash.DataReportMain1DynamicMainChart(companyID);
            _ncheck1 = _ncheckzone.Where(x => x.TypeID == 101).ToList();
            ncheckchart1 = ncheckchartzone.Where(x => x.TypeID == 101).ToList();

            _ncheck1.ToList().ForEach(i => i.Amount = i.Amount / 1000000); _ncheck1.ToList().ForEach(i => i.Amount1 = i.Amount1 / 1000000);
            _ncheck1.ToList().ForEach(i => i.Amount2 = i.Amount2 / 1000000);
            _ncheck1.ToList().ForEach(i => i.Amount3 = i.Amount3 / 1000000);
            _ncheck1.ToList().ForEach(i => i.Amount4 = i.Amount4 / 1000000);
            ncheckchart1.ToList().ForEach(i => i.Amount = i.Amount / 1000000);

            _ncheck2 = _ncheckzone.Where(x => x.TypeID == 103).ToList();
            ncheckchart2 = ncheckchartzone.Where(x => x.TypeID == 103).ToList();

            _ncheck3 = _ncheckzone.Where(x => x.TypeID == 105).ToList();
            ncheckchart3 = ncheckchartzone.Where(x => x.TypeID == 105).ToList();

            _ncheck4 = _ncheckzone.Where(x => x.TypeID == 104).ToList();
            ncheckchart4 = ncheckchartzone.Where(x => x.TypeID == 104).ToList();

            _ncheck5 = _ncheckzone.Where(x => x.TypeID == 107).ToList();
            ncheckchart5 = ncheckchartzone.Where(x => x.TypeID == 107).ToList();

            _ncheck7 = _ncheckzone.Where(x => x.TypeID == 125).ToList();
            ncheckchart7 = ncheckchartzone.Where(x => x.TypeID == 125).ToList();

            _ncheck8 = _ncheckzone.Where(x => x.TypeID == 109).ToList();
            ncheckchart8 = ncheckchartzone.Where(x => x.TypeID == 109).ToList();

            _ncheck9 = _ncheckzone.Where(x => x.TypeID == 111).ToList();
            ncheckchart9 = ncheckchartzone.Where(x => x.TypeID == 111).ToList();

            _ncheck10 = _ncheckzone.Where(x => x.TypeID == 113).ToList();
            ncheckchart10 = ncheckchartzone.Where(x => x.TypeID == 113).ToList();

            _ncheck11 = _ncheckzone.Where(x => x.TypeID == 115).ToList();
            ncheckchart11 = ncheckchartzone.Where(x => x.TypeID == 115).ToList();


            _ncheck13 = _ncheckzone.Where(x => x.TypeID == 117).ToList();
            ncheckchart13 = ncheckchartzone.Where(x => x.TypeID == 117).ToList();

            _ncheck14 = _ncheckzone.Where(x => x.TypeID == 119).ToList();
            ncheckchart14 = ncheckchartzone.Where(x => x.TypeID == 119).ToList();

            _ncheck15 = _ncheckzone.Where(x => x.TypeID == 121).ToList();
            ncheckchart15 = ncheckchartzone.Where(x => x.TypeID == 121).ToList();

            _ncheck16 = _ncheckzone.Where(x => x.TypeID == 123).ToList();
            ncheckchart16 = ncheckchartzone.Where(x => x.TypeID == 123).ToList();
            //125
            _ncheck17 = _ncheckzone.Where(x => x.TypeID == 127).ToList();
            ncheckchart17 = ncheckchartzone.Where(x => x.TypeID == 127).ToList();

            _ncheck18 = _ncheckzone.Where(x => x.TypeID == 129).ToList();
            ncheckchart18 = ncheckchartzone.Where(x => x.TypeID == 129).ToList();

            _ncheck18.ToList().ForEach(i => i.Amount = i.Amount / 1000000); _ncheck18.ToList().ForEach(i => i.Amount1 = i.Amount1 / 1000000);
            _ncheck18.ToList().ForEach(i => i.Amount2 = i.Amount2 / 1000000);
            _ncheck18.ToList().ForEach(i => i.Amount3 = i.Amount3 / 1000000);
            _ncheck18.ToList().ForEach(i => i.Amount4 = i.Amount4 / 1000000);
            ncheckchart18.ToList().ForEach(i => i.Amount = i.Amount / 1000000);

            _ncheck19 = _ncheckzone.Where(x => x.TypeID == 131).ToList();
            ncheckchart19 = ncheckchartzone.Where(x => x.TypeID == 131).ToList();

            _ncheck20 = _ncheckzone.Where(x => x.TypeID == 133).ToList();
            ncheckchart20 = ncheckchartzone.Where(x => x.TypeID == 133).ToList();

            _ncheck21 = _ncheckzone.Where(x => x.TypeID == 135).ToList();
            ncheckchart21 = ncheckchartzone.Where(x => x.TypeID == 135).ToList();

            _ncheck22 = _ncheckzone.Where(x => x.TypeID == 137).ToList();
            ncheckchart22 = ncheckchartzone.Where(x => x.TypeID == 137).ToList();

            _ncheck23 = _ncheckzone.Where(x => x.TypeID == 139).ToList();
            ncheckchart23 = ncheckchartzone.Where(x => x.TypeID == 139).ToList();
            _ncheck23 = _ncheck23.Select(c => { c.Amount = float.Parse("365") / c.Amount; return c; }).ToList();
            _ncheck23 = _ncheck23.Select(c => { c.Amount1 = float.Parse("365") / c.Amount1; return c; }).ToList();
            _ncheck23 = _ncheck23.Select(c => { c.Amount2 = float.Parse("365") / c.Amount2; return c; }).ToList();
            _ncheck23 = _ncheck23.Select(c => { c.Amount3 = float.Parse("365") / c.Amount3; return c; }).ToList();
            ncheckchart23 = ncheckchart23.Select(c => { c.Amount = float.Parse("365") / c.Amount; return c; }).ToList();

            _ncheck24 = _ncheckzone.Where(x => x.TypeID == 141).ToList();
            ncheckchart24 = ncheckchartzone.Where(x => x.TypeID == 141).ToList();

            _ncheck25 = _ncheckzone.Where(x => x.TypeID == 143).ToList();
            ncheckchart25 = ncheckchartzone.Where(x => x.TypeID == 143).ToList();

            _ncheck27 = _ncheckzone.Where(x => x.TypeID == 145).ToList();
            ncheckchart27 = ncheckchartzone.Where(x => x.TypeID == 145).ToList();

            _ncheck27.ToList().ForEach(i => i.Amount = i.Amount / 1000000); _ncheck27.ToList().ForEach(i => i.Amount1 = i.Amount1 / 1000000);
            _ncheck27.ToList().ForEach(i => i.Amount2 = i.Amount2 / 1000000);
            _ncheck27.ToList().ForEach(i => i.Amount3 = i.Amount3 / 1000000);
            _ncheck27.ToList().ForEach(i => i.Amount4 = i.Amount4 / 1000000);
            ncheckchart27.ToList().ForEach(i => i.Amount = i.Amount / 1000000);


            UserID = usride_;

            FinansRaporu report = new FinansRaporu();
            report.xr7CompanyName.Text = grview.CompanyName;
            report.xr7NaceKod.Text = grview.Code;
            report.xrSektorAna.Text = grview.MainDescription;
            report.xrSektorDetay.Text = grview.Description;
            report.xrRichTxtMeitn.Html = metin;
            ObjectDataSource objectDataSourceChrt1 = new ObjectDataSource();
            objectDataSourceChrt1.Name = "DataViewer";
            objectDataSourceChrt1.DataSource = _ncheck1;
            objectDataSourceChrt1.Fill();

            ObjectDataSource objectDataSourceChrt2 = new ObjectDataSource();
            objectDataSourceChrt2.Name = "DataViewerz";
            objectDataSourceChrt2.DataSource = _ncheck2;
            objectDataSourceChrt2.Fill();

            ObjectDataSource objectDataSourceChrt3 = new ObjectDataSource();
            objectDataSourceChrt3.Name = "DataViewerzz";
            objectDataSourceChrt3.DataSource = _ncheck3;
            objectDataSourceChrt3.Fill();

            ObjectDataSource objectDataSourceChrt4 = new ObjectDataSource();
            objectDataSourceChrt4.Name = "D1ataViewerzz1";
            objectDataSourceChrt4.DataSource = _ncheck4;
            objectDataSourceChrt4.Fill();

            ObjectDataSource objectDataSourceChrt5 = new ObjectDataSource();
            objectDataSourceChrt5.Name = "DataViewersszz1";
            objectDataSourceChrt5.DataSource = _ncheck5;
            objectDataSourceChrt5.Fill();

            ObjectDataSource objectDataSource511 = new ObjectDataSource();
            objectDataSource511.Name = "DataViewersszz1";
            objectDataSource511.DataSource = ncheck41;
            objectDataSource511.Fill();


            ObjectDataSource objectDataSourceChrt7 = new ObjectDataSource();
            objectDataSourceChrt7.Name = "Dat1aViewerzz1";
            objectDataSourceChrt7.DataSource = _ncheck7;
            objectDataSourceChrt7.Fill();

            ObjectDataSource objectDataSourceChrt8 = new ObjectDataSource();
            objectDataSourceChrt8.Name = "Data1Viewerzz1";
            objectDataSourceChrt8.DataSource = _ncheck8;
            objectDataSourceChrt8.Fill();


            ObjectDataSource objectDataSourceChrt9 = new ObjectDataSource();
            objectDataSourceChrt9.Name = "DataV1iewerzz1";
            objectDataSourceChrt9.DataSource = _ncheck9;
            objectDataSourceChrt9.Fill();


            ObjectDataSource objectDataSourceChrt10 = new ObjectDataSource();
            objectDataSourceChrt10.Name = "DataVi1ewserzz1";
            objectDataSourceChrt10.DataSource = _ncheck10;
            objectDataSourceChrt10.Fill();


            ObjectDataSource objectDataSourceChrt11 = new ObjectDataSource();
            objectDataSourceChrt11.Name = "DataVi1ewerz4z1";
            objectDataSourceChrt11.DataSource = _ncheck11;
            objectDataSourceChrt11.Fill();

            ObjectDataSource objectDataSourceChrt13 = new ObjectDataSource();
            objectDataSourceChrt13.Name = "DataVie1werzz41";
            objectDataSourceChrt13.DataSource = _ncheck13;
            objectDataSourceChrt13.Fill();

            ObjectDataSource objectDataSourceChrt14 = new ObjectDataSource();
            objectDataSourceChrt14.Name = "DataView1erz1z1";
            objectDataSourceChrt14.DataSource = _ncheck14;
            objectDataSourceChrt14.Fill();

            ObjectDataSource objectDataSourceChrt15 = new ObjectDataSource();
            objectDataSourceChrt15.Name = "DataViewer1zz1";
            objectDataSourceChrt15.DataSource = _ncheck15;
            objectDataSourceChrt15.Fill();


            ObjectDataSource objectDataSourceChrt16 = new ObjectDataSource();
            objectDataSourceChrt16.Name = "DataViewerz1z1";
            objectDataSourceChrt16.DataSource = _ncheck16;
            objectDataSourceChrt16.Fill();


            ObjectDataSource objectDataSourceChrt17 = new ObjectDataSource();
            objectDataSourceChrt17.Name = "Da1taViewerzz11";
            objectDataSourceChrt17.DataSource = _ncheck17;
            objectDataSourceChrt17.Fill();



            ObjectDataSource objectDataSourceChrt18 = new ObjectDataSource();
            objectDataSourceChrt18.Name = "D3ataViewerzz1";
            objectDataSourceChrt18.DataSource = _ncheck18;
            objectDataSourceChrt18.Fill();

            ObjectDataSource objectDataSourceChrt19 = new ObjectDataSource();
            objectDataSourceChrt19.Name = "Dat3aViewerzz1";
            objectDataSourceChrt19.DataSource = _ncheck19;
            objectDataSourceChrt19.Fill();



            ObjectDataSource objectDataSourceChrt20 = new ObjectDataSource();
            objectDataSourceChrt20.Name = "Data3Viewerzz1";
            objectDataSourceChrt20.DataSource = _ncheck20;
            objectDataSourceChrt20.Fill();


            ObjectDataSource objectDataSourceChrt21 = new ObjectDataSource();
            objectDataSourceChrt21.Name = "DataVi3ewerzz1";
            objectDataSourceChrt21.DataSource = _ncheck21;
            objectDataSourceChrt21.Fill();

            ObjectDataSource objectDataSourceChrt22 = new ObjectDataSource();
            objectDataSourceChrt22.Name = "DataVie3werzz1";
            objectDataSourceChrt22.DataSource = _ncheck22;
            objectDataSourceChrt22.Fill();


            ObjectDataSource objectDataSourceChrt23 = new ObjectDataSource();
            objectDataSourceChrt23.Name = "Da33taViewerzz1";
            objectDataSourceChrt23.DataSource = _ncheck23;
            objectDataSourceChrt23.Fill();


            ObjectDataSource objectDataSourceChrt24 = new ObjectDataSource();
            objectDataSourceChrt24.Name = "DataViewe3rzz1";
            objectDataSourceChrt24.DataSource = _ncheck24;
            objectDataSourceChrt24.Fill();

            ObjectDataSource objectDataSourceChrt25 = new ObjectDataSource();
            objectDataSourceChrt25.Name = "DataVie3werzz1";
            objectDataSourceChrt25.DataSource = _ncheck25;
            objectDataSourceChrt25.Fill();


            ObjectDataSource objectDataSourceChrt27 = new ObjectDataSource();
            objectDataSourceChrt27.Name = "DataViewe3r3zz1";
            objectDataSourceChrt27.DataSource = _ncheck27;
            objectDataSourceChrt27.Fill();

            ObjectDataSource objectDataSource = new ObjectDataSource();
            objectDataSource.Name = "DataViewer1";
            objectDataSource.DataSource = ncheck1;

            objectDataSource.Fill();

            ObjectDataSource objectDataSource1 = new ObjectDataSource();
            objectDataSource1.Name = "DataViewer2";
            objectDataSource1.DataSource = ncheck3;

            objectDataSource1.Fill();

            ObjectDataSource objectDataSource3 = new ObjectDataSource();
            objectDataSource3.Name = "DataViewer3";
            objectDataSource3.DataSource = ncheck5;

            objectDataSource3.Fill();

            //ObjectDataSource objectDataSource5 = new ObjectDataSource();
            //objectDataSource5.Name = "DataViewer4";
            //objectDataSource5.DataSource = ncheck41;

            //objectDataSource5.Fill();


            ObjectDataSource objectDataSource7 = new ObjectDataSource();
            objectDataSource7.Name = "DataViewer5";
            objectDataSource7.DataSource = ncheck43;

            objectDataSource7.Fill();

            ObjectDataSource objectDataSource9 = new ObjectDataSource();
            objectDataSource9.Name = "DataViewer6";
            objectDataSource9.DataSource = ncheck7;

            objectDataSource9.Fill();


            ObjectDataSource objectDataSource9b = new ObjectDataSource();
            objectDataSource9b.Name = "DataViewer7";
            objectDataSource9b.DataSource = ncheck7b;

            objectDataSource9b.Fill();

            ObjectDataSource objectDataSource11 = new ObjectDataSource();
            objectDataSource11.Name = "DataViewer8";
            objectDataSource11.DataSource = ncheck9;

            objectDataSource11.Fill();


            ObjectDataSource objectDataSource11b = new ObjectDataSource();
            objectDataSource11b.Name = "DataViewer9";
            objectDataSource11b.DataSource = ncheck9b;

            objectDataSource11b.Fill();

            ObjectDataSource objectDataSource13 = new ObjectDataSource();
            objectDataSource13.Name = "DataViewer10";
            objectDataSource13.DataSource = ncheck11;

            objectDataSource13.Fill();


            ObjectDataSource objectDataSource13b = new ObjectDataSource();
            objectDataSource13b.Name = "DataViewer11";
            objectDataSource13b.DataSource = ncheck11b;

            objectDataSource13b.Fill();

            ObjectDataSource objectDataSource13b1 = new ObjectDataSource();
            objectDataSource13b1.Name = "DataViewer12";
            objectDataSource13b1.DataSource = ncheck11c;

            objectDataSource13b1.Fill();

            ObjectDataSource objectDataSource13b3 = new ObjectDataSource();
            objectDataSource13b3.Name = "DataViewer13";
            objectDataSource13b3.DataSource = ncheck11d;

            objectDataSource13b3.Fill();
            // Gelirler

            ObjectDataSource objectDataSource15 = new ObjectDataSource();
            objectDataSource15.Name = "DataViewer14";
            objectDataSource15.DataSource = ncheck13;

            objectDataSource15.Fill();

            ObjectDataSource objectDataSource15a = new ObjectDataSource();
            objectDataSource15a.Name = "DataViewer15";
            objectDataSource15a.DataSource = ncheck13brut;

            objectDataSource15a.Fill();

            ObjectDataSource objectDataSource17 = new ObjectDataSource();
            objectDataSource17.Name = "DataViewer16";
            objectDataSource17.DataSource = ncheck15;

            objectDataSource17.Fill();

            ObjectDataSource objectDataSource17a = new ObjectDataSource();
            objectDataSource17a.Name = "DataViewer17";
            objectDataSource17a.DataSource = ncheck15a;

            objectDataSource17a.Fill();


            ObjectDataSource objectDataSource19 = new ObjectDataSource();
            objectDataSource19.Name = "DataViewer18";
            objectDataSource19.DataSource = ncheck17;

            objectDataSource19.Fill();

            ObjectDataSource objectDataSource19a = new ObjectDataSource();
            objectDataSource19a.Name = "DataViewer19";
            objectDataSource19a.DataSource = ncheck17a;

            objectDataSource19a.Fill();

            ObjectDataSource objectDataSource13check = new ObjectDataSource();
            objectDataSource13check.Name = "DataViewer20";
            objectDataSource13check.DataSource = ncheck13Check;

            objectDataSource13check.Fill();

            ObjectDataSource objectDataSource21 = new ObjectDataSource();
            objectDataSource21.Name = "DataViewer21";
            objectDataSource21.DataSource = ncheck19;

            objectDataSource21.Fill();

            ObjectDataSource objectDataSource23 = new ObjectDataSource();
            objectDataSource23.Name = "DataViewer22";
            objectDataSource23.DataSource = ncheck21;

            objectDataSource23.Fill();

            ObjectDataSource objectDataSource25 = new ObjectDataSource();
            objectDataSource25.Name = "DataViewer23";
            objectDataSource25.DataSource = ncheck23;

            objectDataSource25.Fill();

            ObjectDataSource objectDataSource27 = new ObjectDataSource();
            objectDataSource27.Name = "DataViewer24";
            objectDataSource27.DataSource = ncheck25;

            objectDataSource27.Fill();
            checkSeries = new LineSeriesView();


            ObjectDataSource objectDataSource29 = new ObjectDataSource();
            objectDataSource29.Name = "DataViewer25";
            objectDataSource29.DataSource = ncheck27;
            objectDataSource29.Fill();

            DetailReportBand detailReport = report.Bands["DetailReport"] as DetailReportBand;
            detailReport.DataSource = objectDataSource;

            DetailReportBand detailReport1 = report.Bands["DetailReport2"] as DetailReportBand;
            detailReport1.DataSource = objectDataSource1;

            DetailReportBand detailReport3 = report.Bands["DetailReport1"] as DetailReportBand;
            detailReport3.DataSource = objectDataSource3;

            DetailReportBand detailReport5 = report.Bands["DetailReport3"] as DetailReportBand;
            detailReport5.DataSource = objectDataSource511;

            DetailReportBand detailReport7 = report.Bands["DetailReport4"] as DetailReportBand;
            detailReport7.DataSource = objectDataSource7;

            DetailReportBand detailReport9 = report.Bands["DetailReport6"] as DetailReportBand;
            detailReport9.DataSource = objectDataSource9;

            DetailReportBand detailReport9b = report.Bands["DetailReport7"] as DetailReportBand;
            detailReport9b.DataSource = objectDataSource9b;

            DetailReportBand detailReport11 = report.Bands["DetailReport8"] as DetailReportBand;
            detailReport11.DataSource = objectDataSource11;

            DetailReportBand detailReport11b = report.Bands["DetailReport9"] as DetailReportBand;
            detailReport11b.DataSource = objectDataSource11b;

            DetailReportBand detailReport13 = report.Bands["DetailReport10"] as DetailReportBand;
            detailReport13.DataSource = objectDataSource13;

            DetailReportBand detailReport13b = report.Bands["DetailReport11"] as DetailReportBand;
            detailReport13b.DataSource = objectDataSource13b;

            DetailReportBand detailReport13b1 = report.Bands["DetailReport12"] as DetailReportBand;
            detailReport13b1.DataSource = objectDataSource13b1;

            DetailReportBand detailReport13b2 = report.Bands["DetailReport13"] as DetailReportBand;
            detailReport13b2.DataSource = objectDataSource13b3;


            DetailReportBand detailReport15 = report.Bands["DetailReport14"] as DetailReportBand;
            detailReport15.DataSource = objectDataSource15;


            DetailReportBand detailReport15a = report.Bands["DetailReport15"] as DetailReportBand;
            detailReport15a.DataSource = objectDataSource15a;


            DetailReportBand detailReport17 = report.Bands["DetailReport16"] as DetailReportBand;
            detailReport17.DataSource = objectDataSource17;

            DetailReportBand detailReport17a = report.Bands["DetailReport17"] as DetailReportBand;
            detailReport17a.DataSource = objectDataSource17a;


            DetailReportBand detailReport19 = report.Bands["DetailReport18"] as DetailReportBand;
            detailReport19.DataSource = objectDataSource19;


            DetailReportBand detailReport19a = report.Bands["DetailReport19"] as DetailReportBand;
            detailReport19a.DataSource = objectDataSource19a;



            DetailReportBand detailReport13Check = report.Bands["DetailReport20"] as DetailReportBand;
            detailReport13Check.DataSource = objectDataSource13check;


            DetailReportBand detailReport21 = report.Bands["DetailReport21"] as DetailReportBand;
            detailReport21.DataSource = objectDataSource21;



            DetailReportBand detailReport25 = report.Bands["DetailReport23"] as DetailReportBand;
            detailReport25.DataSource = objectDataSource25;


            DetailReportBand detailReport27 = report.Bands["DetailReport24"] as DetailReportBand;
            detailReport27.DataSource = objectDataSource27;


            DetailReportBand detailReport29 = report.Bands["DetailReport25"] as DetailReportBand;
            detailReport29.DataSource = objectDataSource29;

            DetailReportBand detailReport22 = report.Bands["DetailReport22"] as DetailReportBand;
            detailReport22.DataSource = objectDataSourceChrt1;

            DetailReportBand detailReport30 = report.Bands["DetailReport29"] as DetailReportBand;
            detailReport30.DataSource = objectDataSourceChrt2;

            DetailReportBand detailReport31 = report.Bands["DetailReport31"] as DetailReportBand;
            detailReport31.DataSource = objectDataSourceChrt3;

            DetailReportBand detailReport33 = report.Bands["DetailReport33"] as DetailReportBand;
            detailReport33.DataSource = objectDataSourceChrt4;


            DetailReportBand detailReport35 = report.Bands["DetailReport35"] as DetailReportBand;
            detailReport35.DataSource = objectDataSourceChrt5;


            DetailReportBand detailReport37 = report.Bands["DetailReport37"] as DetailReportBand;
            detailReport37.DataSource = objectDataSourceChrt7;



            DetailReportBand detailReport39 = report.Bands["DetailReport39"] as DetailReportBand;
            detailReport39.DataSource = objectDataSourceChrt8;



            DetailReportBand detailReport41 = report.Bands["DetailReport41"] as DetailReportBand;
            detailReport41.DataSource = objectDataSourceChrt9;


            DetailReportBand detailReport43 = report.Bands["DetailReport43"] as DetailReportBand;
            detailReport43.DataSource = objectDataSourceChrt10;


            DetailReportBand detailReport45 = report.Bands["DetailReport45"] as DetailReportBand;
            detailReport45.DataSource = objectDataSourceChrt11;


            DetailReportBand detailReport47 = report.Bands["DetailReport47"] as DetailReportBand;
            detailReport47.DataSource = objectDataSourceChrt13;


            DetailReportBand detailReport49 = report.Bands["DetailReport49"] as DetailReportBand;
            detailReport49.DataSource = objectDataSourceChrt14;


            DetailReportBand detailReport51 = report.Bands["DetailReport51"] as DetailReportBand;
            detailReport51.DataSource = objectDataSourceChrt15;


            DetailReportBand detailReport53 = report.Bands["DetailReport53"] as DetailReportBand;
            detailReport53.DataSource = objectDataSourceChrt16;


            DetailReportBand detailReport55 = report.Bands["DetailReport55"] as DetailReportBand;
            detailReport55.DataSource = objectDataSourceChrt17;


            DetailReportBand detailReport57 = report.Bands["DetailReport57"] as DetailReportBand;
            detailReport57.DataSource = objectDataSourceChrt18;


            DetailReportBand detailReport59 = report.Bands["DetailReport59"] as DetailReportBand;
            detailReport59.DataSource = objectDataSourceChrt19;

            DetailReportBand detailReport61 = report.Bands["DetailReport63"] as DetailReportBand;
            detailReport61.DataSource = objectDataSourceChrt20;


            DetailReportBand detailReport63 = report.Bands["DetailReport65"] as DetailReportBand;
            detailReport63.DataSource = objectDataSourceChrt21;

            DetailReportBand detailReport65 = report.Bands["DetailReport67"] as DetailReportBand;
            detailReport65.DataSource = objectDataSourceChrt22;


            DetailReportBand detailReport67 = report.Bands["DetailReport69"] as DetailReportBand;
            detailReport67.DataSource = objectDataSourceChrt23;


            DetailReportBand detailReport69 = report.Bands["DetailReport71"] as DetailReportBand;
            detailReport69.DataSource = objectDataSourceChrt24;


            DetailReportBand detailReport71 = report.Bands["DetailReport73"] as DetailReportBand;
            detailReport71.DataSource = objectDataSourceChrt25;

            DetailReportBand detailReport715 = report.Bands["DetailReport75"] as DetailReportBand;
            detailReport715.DataSource = objectDataSourceChrt27;
            //DetailReportBand detailReport73 = report.Bands["DetailReport73"] as DetailReportBand;
            //detailReport73.DataSource = objectDataSourceChrt27;


            //DetailReportBand detailReport75 = report.Bands["DetailReport75"] as DetailReportBand;
            //detailReport75.DataSource = objectDataSourceChrt25;

            var chart1 = (XRChart)report.FindControl("xrChart1", false);

            chart1.DataSource = ncheckchart1;//Method from documentation you reffered
            chart1.SeriesTemplate.View = checkSeries;
            chart1.SeriesTemplate.SeriesDataMember = "GridName";
            chart1.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart1.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart1.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var chart2 = (XRChart)report.FindControl("xrChart2", false);

            chart2.DataSource = ncheckchart2;//Method from documentation you reffered
            chart2.SeriesTemplate.View = checkSeries;
            chart2.SeriesTemplate.SeriesDataMember = "GridName";
            chart2.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart2.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart2.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var chart3 = (XRChart)report.FindControl("xrChart3", false);

            chart3.DataSource = ncheckchart3;//Method from documentation you reffered
            chart3.SeriesTemplate.View = checkSeries;
            chart3.SeriesTemplate.SeriesDataMember = "GridName";
            chart3.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart3.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart3.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var chart4 = (XRChart)report.FindControl("xrChart4", false);

            chart4.DataSource = ncheckchart4;//Method from documentation you reffered
            chart4.SeriesTemplate.View = checkSeries;
            chart4.SeriesTemplate.SeriesDataMember = "GridName";
            chart4.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart4.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart4.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var chart5 = (XRChart)report.FindControl("xrChart5", false);
            chart5.DataSource = ncheckchart5;//Method from documentation you reffered
            chart5.SeriesTemplate.View = checkSeries;
            chart5.SeriesTemplate.SeriesDataMember = "GridName";
            chart5.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart5.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart5.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var chart7 = (XRChart)report.FindControl("xrChart6", false);
            chart7.DataSource = ncheckchart7;//Method from documentation you reffered
            chart7.SeriesTemplate.View = checkSeries;
            chart7.SeriesTemplate.SeriesDataMember = "GridName";
            chart7.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart7.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart7.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var chart8 = (XRChart)report.FindControl("xrChart7", false);
            chart8.DataSource = ncheckchart8;//Method from documentation you reffered
            chart8.SeriesTemplate.View = checkSeries;
            chart8.SeriesTemplate.SeriesDataMember = "GridName";
            chart8.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart8.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart8.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var chart81 = (XRChart)report.FindControl("xrChart8", false);
            chart81.DataSource = ncheckchart9;//Method from documentation you reffered
            chart81.SeriesTemplate.View = checkSeries;
            chart81.SeriesTemplate.SeriesDataMember = "GridName";
            chart81.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart81.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart81.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var xrChart9 = (XRChart)report.FindControl("xrChart9", false);
            xrChart9.DataSource = ncheckchart10;//Method from documentation you reffered
            xrChart9.SeriesTemplate.View = checkSeries;
            xrChart9.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart9.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart9.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart9.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var xrChart10 = (XRChart)report.FindControl("xrChart10", false);
            xrChart10.DataSource = ncheckchart11;//Method from documentation you reffered
            xrChart10.SeriesTemplate.View = checkSeries;
            xrChart10.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart10.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart10.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart10.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart11 = (XRChart)report.FindControl("xrChart11", false);
            xrChart11.DataSource = ncheckchart13;//Method from documentation you reffered
            xrChart11.SeriesTemplate.View = checkSeries;
            xrChart11.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart11.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart11.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart11.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart12 = (XRChart)report.FindControl("xrChart12", false);
            xrChart12.DataSource = ncheckchart14;//Method from documentation you reffered
            xrChart12.SeriesTemplate.View = checkSeries;
            xrChart12.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart12.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart12.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart12.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart13 = (XRChart)report.FindControl("xrChart13", false);
            xrChart13.DataSource = ncheckchart15;//Method from documentation you reffered
            xrChart13.SeriesTemplate.View = checkSeries;
            xrChart13.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart13.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart13.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart13.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart14 = (XRChart)report.FindControl("xrChart14", false);
            xrChart14.DataSource = ncheckchart16;//Method from documentation you reffered
            xrChart14.SeriesTemplate.View = checkSeries;
            xrChart14.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart14.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart14.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart14.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart15 = (XRChart)report.FindControl("xrChart15", false);
            xrChart15.DataSource = ncheckchart17;//Method from documentation you reffered
            xrChart15.SeriesTemplate.View = checkSeries;
            xrChart15.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart15.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart15.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart15.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart16 = (XRChart)report.FindControl("xrChart16", false);
            xrChart16.DataSource = ncheckchart18;//Method from documentation you reffered
            xrChart16.SeriesTemplate.View = checkSeries;
            xrChart16.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart16.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart16.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart16.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart17 = (XRChart)report.FindControl("xrChart17", false);
            xrChart17.DataSource = ncheckchart19;//Method from documentation you reffered
            xrChart17.SeriesTemplate.View = checkSeries;
            xrChart17.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart17.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart17.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart17.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var xrChart18 = (XRChart)report.FindControl("xrChart18", false);
            xrChart18.DataSource = ncheckchart20;//Method from documentation you reffered
            xrChart18.SeriesTemplate.View = checkSeries;
            xrChart18.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart18.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart18.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart18.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart19 = (XRChart)report.FindControl("xrChart19", false);
            xrChart19.DataSource = ncheckchart21;//Method from documentation you reffered
            xrChart19.SeriesTemplate.View = checkSeries;
            xrChart19.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart19.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart19.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart19.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart20 = (XRChart)report.FindControl("xrChart20", false);
            xrChart20.DataSource = ncheckchart22;//Method from documentation you reffered
            xrChart20.SeriesTemplate.View = checkSeries;
            xrChart20.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart20.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart20.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart20.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart21 = (XRChart)report.FindControl("xrChart21", false);
            xrChart21.DataSource = ncheckchart23;//Method from documentation you reffered
            xrChart21.SeriesTemplate.View = checkSeries;
            xrChart21.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart21.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart21.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart21.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart22 = (XRChart)report.FindControl("xrChart22", false);
            xrChart22.DataSource = ncheckchart24;//Method from documentation you reffered
            xrChart22.SeriesTemplate.View = checkSeries;
            xrChart22.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart22.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart22.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart22.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart23 = (XRChart)report.FindControl("xrChart23", false);
            xrChart23.DataSource = ncheckchart25;//Method from documentation you reffered
            xrChart23.SeriesTemplate.View = checkSeries;
            xrChart23.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart23.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart23.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart23.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart24 = (XRChart)report.FindControl("xrChart24", false);
            xrChart24.DataSource = ncheckchart27;//Method from documentation you reffered
            xrChart24.SeriesTemplate.View = checkSeries;
            xrChart24.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart24.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart24.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart24.SeriesTemplate.ValueDataMembers.AddRange("Amount");
            //PdfExportOptions pdfOptions = report.ExportOptions.Pdf;
            //var xrChart25 = (XRChart)report.FindControl("xrChart25", false);
            //xrChart25.DataSource = ncheckchart27;//Method from documentation you reffered
            //xrChart25.SeriesTemplate.View = checkSeries;
            //xrChart25.SeriesTemplate.SeriesDataMember = "GridName";
            //xrChart25.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            //xrChart25.SeriesTemplate.ArgumentDataMember = "GroupText";
            //xrChart25.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            //pdfOptions.DocumentOptions.Application = "Fincheckup Application";
            //pdfOptions.DocumentOptions.Author = "Fincheckup Team";
            //pdfOptions.DocumentOptions.Keywords = "Fincheckup, Reporting, Finance";
            //pdfOptions.DocumentOptions.Producer = "";
            //pdfOptions.DocumentOptions.Subject = "Fincheckup Reporting";
            //pdfOptions.DocumentOptions.Title = "Finance Reporting";

            report.xrLblYear.Text = YearCurrentTx.ToString();
            report.xrlblYear1.Text = YearCurrentTx.ToString();
            report.xrlblYear3.Text = YearCurrentTx.ToString();
            report.xrlblYear1a1.Text = YearCurrentTx.ToString();
            report.xrlblYear1a3.Text = YearCurrentTx.ToString();
            report.xrlblYear1a31.Text = YearCurrentTx.ToString();
            report.xrlblYear1a3a.Text = YearCurrentTx.ToString();
            report.xrlblYear1a3bg.Text = YearCurrentTx.ToString();
            report.xrlblYear1a3ff.Text = YearCurrentTx.ToString();
            report.xrlblYear1a3h.Text = YearCurrentTx.ToString();
            report.xrlblYear1a3jk.Text = YearCurrentTx.ToString();
            report.xrlblYear1a3kk.Text = YearCurrentTx.ToString();
            report.xrlblYear1a3ll.Text = YearCurrentTx.ToString();
            report.xrlblYear1a3oo.Text = YearCurrentTx.ToString();
            report.xrlblYear1a3s.Text = YearCurrentTx.ToString();
            report.xrlblYear1a3t.Text = YearCurrentTx.ToString();
            report.xrlblYear1a3ww.Text = YearCurrentTx.ToString();
            report.xrlblYear1a3yy.Text = YearCurrentTx.ToString();
            report.xrlblYear311.Text = YearCurrentTx.ToString();
            report.xrlblYear32.Text = YearCurrentTx.ToString();
            report.xrlblYear31.Text = YearCurrentTx.ToString();
            report.xrlblYear4.Text = YearCurrentTx.ToString();
            report.xrlblYear5.Text = YearCurrentTx.ToString();
            report.xrlblYear6.Text = YearCurrentTx.ToString();
            report.xrlblYear7.Text = YearCurrentTx.ToString();
            report.xrlblYear8.Text = YearCurrentTx.ToString();
            report.xrlblYear9.Text = YearCurrentTx.ToString();
            return report;

        }
        public static FinansRaporua getReporta(long companyID, List<int> nyear, string nacceco, long usride_, List<int> nyearChkList, CompanyReportView grview, int chkMizan = 0)
        {

          
            YearCurrent = nyearChkList[0];
            YearCurrenta = nyearChkList[1];
    
            Companies.DataReportMainNace(nacceco, companyID);
            grview = Companies.Get_CompanyReportView(companyID);
            setReportZone(companyID, nyear, chkMizan);

            int chk = Companies.DataReportMainLastMonth(YearCurrenta, companyID);
            YearCurrentaTx = YearCurrenta.ToString() + " - " + chk.ToString();
            int maxyearTcmb = Companies.Get_LastTCMBReportYear();
            string metin = string.Empty;
            List<int> nyearchk = new List<int>();
            nyearchk.Add(YearCurrent);
            if (nyearChkList.Contains(maxyearTcmb))
            {
                metin = "<html><body>" + RepText1(nyearchk, 4, nacceco);
                metin += "<br>" + RepText5(companyID, YearCurrent);
            }
            else
            {
                metin = RepText1(nyearchk, 2, nacceco);
                metin += "<br>" + RepText4(companyID, YearCurrent);
            }

            metin += "</body></html>";

            ncheck = MainDash.DataReportMainQnbT(companyID);


            ncheck1 = ncheck.Where(x => x.MainTypeID == 1).ToList();

            ncheck3 = ncheck.Where(x => x.MainTypeID == 2).FirstOrDefault();
            //ncheck1 = reportZone.getReverse(ncheck1, ncheck3.Amount);


            ncheck5 = ncheck.Where(x => x.MainTypeID == 3).ToList();
            ncheck41 = ncheck.Where(x => x.MainTypeID == 4 && x.TypeID == 471).FirstOrDefault();
            ncheck43 = ncheck.Where(x => x.MainTypeID == 4 && x.TypeID == 473).FirstOrDefault();
            //ncheck3 = reportZone.getReverseSingle(ncheck3, ncheck43.Amount);
            //ncheck41 = reportZone.getReverseSingle(ncheck41, ncheck43.Amount);
            //ncheck5 = reportZone.getReverse(ncheck5, ncheck41.Amount); /////

            // 2.Sayfa

            ncheck7 = ncheck.Where(x => x.MainTypeID == 5).ToList();
            ncheck9 = ncheck.Where(x => x.MainTypeID == 7).ToList();
            ncheck11 = ncheck.Where(x => x.MainTypeID == 9).ToList();
            ncheck7b = ncheck.Where(x => x.MainTypeID == 6).FirstOrDefault();
            ncheck9b = ncheck.Where(x => x.MainTypeID == 8).FirstOrDefault();
            ncheck11b = ncheck.Where(x => x.TypeID == 951).FirstOrDefault();

            ncheck11c = ncheck.Where(x => x.TypeID == 953).FirstOrDefault();
            ncheck11d = ncheck.Where(x => x.TypeID == 955).FirstOrDefault();

            //ncheck7 = reportZone.getReverse(ncheck7, ncheck7b.Amount);
            //ncheck9 = reportZone.getReverse(ncheck9, ncheck9b.Amount);
            //ncheck11 = reportZone.getReverse(ncheck11, ncheck11b.Amount);

            //ncheck7b = reportZone.getReverseSingle(ncheck7b, ncheck11d.Amount);
            //ncheck9b = reportZone.getReverseSingle(ncheck9b, ncheck11d.Amount);
            //ncheck11b = reportZone.getReverseSingle(ncheck11b, ncheck11d.Amount);
            //ncheck11c = reportZone.getReverseSingle(ncheck11c, ncheck11d.Amount);


            //gelirler
            ncheckGelir = MainDash.DataReportMainQnbGelirT(companyID);
            ncheck13 = ncheckGelir.Where(x => x.MainTypeID == 13).ToList();
            ncheck13brut = ncheckGelir.Where(x => x.TypeID == 109).FirstOrDefault();

            ncheck15 = ncheckGelir.Where(x => x.TypeID == 111).FirstOrDefault();
            ncheck15a = ncheckGelir.Where(x => x.TypeID == 113).FirstOrDefault();

            ncheck17 = ncheckGelir.Where(x => x.TypeID == 115).FirstOrDefault();
            ncheck17a = ncheckGelir.Where(x => x.TypeID == 117).FirstOrDefault();

            ncheck13Check = ncheckGelir.Where(x => x.MainTypeID == 23).ToList();

            ncheck19 = ncheckGelir.Where(x => x.TypeID == 125).FirstOrDefault();

            ncheck23 = ncheckGelir.Where(x => x.MainTypeID == 27).ToList();


            ncheck25 = ncheckGelir.Where(x => x.TypeID == 133).FirstOrDefault();

            ncheck27 = ncheckGelir.Where(x => x.TypeID == 135).FirstOrDefault();

            //var tst = ncheck13.Where(x => x.MainTypeID == 13 && x.TypeID == 101).FirstOrDefault();
            //ncheck13 = reportZone.getReverse(ncheck13, ncheck25.Amount);
            //ncheck13brut = reportZone.getReverseSingle(ncheck13brut, ncheck25.Amount);
            //ncheck15 = reportZone.getReverseSingle(ncheck15, ncheck25.Amount);
            //ncheck15a = reportZone.getReverseSingle(ncheck15a, ncheck25.Amount);
            //ncheck17 = reportZone.getReverseSingle(ncheck17, ncheck25.Amount);
            //ncheck17a = reportZone.getReverseSingle(ncheck17a, ncheck25.Amount);

            //tst = reportZone.getReverseSingle(tst, tst.Amount);

            //ncheck13Check = reportZone.getReverse(ncheck13Check, ncheck25.Amount);

            //ncheck19 = reportZone.getReverseSingle(ncheck19, ncheck25.Amount);
            //ncheck23 = reportZone.getReverse(ncheck23, ncheck25.Amount);

            //ncheck25 = reportZone.getReverseSingle(ncheck25, ncheck25.Amount);
            // chartlar
            _ncheckzone = MainDash.DataReportMain1DynamicMain(companyID);
            ncheckchartzone = MainDash.DataReportMain1DynamicMainChart(companyID);
            _ncheck1 = _ncheckzone.Where(x => x.TypeID == 101).ToList();
            ncheckchart1 = ncheckchartzone.Where(x => x.TypeID == 101).ToList();

            _ncheck1.ToList().ForEach(i => i.Amount = i.Amount / 1000000); _ncheck1.ToList().ForEach(i => i.Amount1 = i.Amount1 / 1000000);
            _ncheck1.ToList().ForEach(i => i.Amount2 = i.Amount2 / 1000000);
            _ncheck1.ToList().ForEach(i => i.Amount3 = i.Amount3 / 1000000);
            _ncheck1.ToList().ForEach(i => i.Amount4 = i.Amount4 / 1000000);
            ncheckchart1.ToList().ForEach(i => i.Amount = i.Amount / 1000000);

            _ncheck2 = _ncheckzone.Where(x => x.TypeID == 103).ToList();
            ncheckchart2 = ncheckchartzone.Where(x => x.TypeID == 103).ToList();

            _ncheck3 = _ncheckzone.Where(x => x.TypeID == 105).ToList();
            ncheckchart3 = ncheckchartzone.Where(x => x.TypeID == 105).ToList();

            _ncheck4 = _ncheckzone.Where(x => x.TypeID == 104).ToList();
            ncheckchart4 = ncheckchartzone.Where(x => x.TypeID == 104).ToList();

            _ncheck5 = _ncheckzone.Where(x => x.TypeID == 107).ToList();
            ncheckchart5 = ncheckchartzone.Where(x => x.TypeID == 107).ToList();

            _ncheck7 = _ncheckzone.Where(x => x.TypeID == 125).ToList();
            ncheckchart7 = ncheckchartzone.Where(x => x.TypeID == 125).ToList();

            _ncheck8 = _ncheckzone.Where(x => x.TypeID == 109).ToList();
            ncheckchart8 = ncheckchartzone.Where(x => x.TypeID == 109).ToList();

            _ncheck9 = _ncheckzone.Where(x => x.TypeID == 111).ToList();
            ncheckchart9 = ncheckchartzone.Where(x => x.TypeID == 111).ToList();

            _ncheck10 = _ncheckzone.Where(x => x.TypeID == 113).ToList();
            ncheckchart10 = ncheckchartzone.Where(x => x.TypeID == 113).ToList();

            _ncheck11 = _ncheckzone.Where(x => x.TypeID == 115).ToList();
            ncheckchart11 = ncheckchartzone.Where(x => x.TypeID == 115).ToList();


            _ncheck13 = _ncheckzone.Where(x => x.TypeID == 117).ToList();
            ncheckchart13 = ncheckchartzone.Where(x => x.TypeID == 117).ToList();

            _ncheck14 = _ncheckzone.Where(x => x.TypeID == 119).ToList();
            ncheckchart14 = ncheckchartzone.Where(x => x.TypeID == 119).ToList();

            _ncheck15 = _ncheckzone.Where(x => x.TypeID == 121).ToList();
            ncheckchart15 = ncheckchartzone.Where(x => x.TypeID == 121).ToList();

            _ncheck16 = _ncheckzone.Where(x => x.TypeID == 123).ToList();
            ncheckchart16 = ncheckchartzone.Where(x => x.TypeID == 123).ToList();
            //125
            _ncheck17 = _ncheckzone.Where(x => x.TypeID == 127).ToList();
            ncheckchart17 = ncheckchartzone.Where(x => x.TypeID == 127).ToList();

            _ncheck18 = _ncheckzone.Where(x => x.TypeID == 129).ToList();
            ncheckchart18 = ncheckchartzone.Where(x => x.TypeID == 129).ToList();

            _ncheck18.ToList().ForEach(i => i.Amount = i.Amount / 1000000); _ncheck18.ToList().ForEach(i => i.Amount1 = i.Amount1 / 1000000);
            _ncheck18.ToList().ForEach(i => i.Amount2 = i.Amount2 / 1000000);
            _ncheck18.ToList().ForEach(i => i.Amount3 = i.Amount3 / 1000000);
            _ncheck18.ToList().ForEach(i => i.Amount4 = i.Amount4 / 1000000);
            ncheckchart18.ToList().ForEach(i => i.Amount = i.Amount / 1000000);




            _ncheck19 = _ncheckzone.Where(x => x.TypeID == 131).ToList();
            ncheckchart19 = ncheckchartzone.Where(x => x.TypeID == 131).ToList();

            _ncheck20 = _ncheckzone.Where(x => x.TypeID == 133).ToList();
            ncheckchart20 = ncheckchartzone.Where(x => x.TypeID == 133).ToList();

            _ncheck21 = _ncheckzone.Where(x => x.TypeID == 135).ToList();
            ncheckchart21 = ncheckchartzone.Where(x => x.TypeID == 135).ToList();

            _ncheck22 = _ncheckzone.Where(x => x.TypeID == 137).ToList();
            ncheckchart22 = ncheckchartzone.Where(x => x.TypeID == 137).ToList();

            _ncheck23 = _ncheckzone.Where(x => x.TypeID == 139).ToList();
            ncheckchart23 = ncheckchartzone.Where(x => x.TypeID == 139).ToList();
            _ncheck23 = _ncheck23.Select(c => { c.Amount = float.Parse("365") / c.Amount; return c; }).ToList();
            _ncheck23 = _ncheck23.Select(c => { c.Amount1 = float.Parse("365") / c.Amount1; return c; }).ToList();
            _ncheck23 = _ncheck23.Select(c => { c.Amount2 = float.Parse("365") / c.Amount2; return c; }).ToList();
            _ncheck23 = _ncheck23.Select(c => { c.Amount3 = float.Parse("365") / c.Amount3; return c; }).ToList();
            ncheckchart23 = ncheckchart23.Select(c => { c.Amount = float.Parse("365") / c.Amount; return c; }).ToList();

            _ncheck24 = _ncheckzone.Where(x => x.TypeID == 141).ToList();
            ncheckchart24 = ncheckchartzone.Where(x => x.TypeID == 141).ToList();

            _ncheck25 = _ncheckzone.Where(x => x.TypeID == 143).ToList();
            ncheckchart25 = ncheckchartzone.Where(x => x.TypeID == 143).ToList();

            _ncheck27 = _ncheckzone.Where(x => x.TypeID == 145).ToList();
            ncheckchart27 = ncheckchartzone.Where(x => x.TypeID == 145).ToList();
            _ncheck27.ToList().ForEach(i => i.Amount = i.Amount / 1000000); _ncheck27.ToList().ForEach(i => i.Amount1 = i.Amount1 / 1000000);
            _ncheck27.ToList().ForEach(i => i.Amount2 = i.Amount2 / 1000000);
            _ncheck27.ToList().ForEach(i => i.Amount3 = i.Amount3 / 1000000);
            _ncheck27.ToList().ForEach(i => i.Amount4 = i.Amount4 / 1000000);
            ncheckchart27.ToList().ForEach(i => i.Amount = i.Amount / 1000000);
            UserID = usride_;

            FinansRaporua report = new FinansRaporua();
            report.xrRichTxtMeitn.Html = metin;
            report.xr7CompanyName.Text = grview.CompanyName;
            report.xr7NaceKod.Text = grview.Code;
            report.xrSektorAna.Text = grview.MainDescription;
            report.xrSektorDetay.Text = grview.Description;
            ObjectDataSource objectDataSourceChrt1 = new ObjectDataSource();
            objectDataSourceChrt1.Name = "DataViewer";
            objectDataSourceChrt1.DataSource = _ncheck1;
            objectDataSourceChrt1.Fill();

            ObjectDataSource objectDataSourceChrt2 = new ObjectDataSource();
            objectDataSourceChrt2.Name = "DataViewerz";
            objectDataSourceChrt2.DataSource = _ncheck2;
            objectDataSourceChrt2.Fill();

            ObjectDataSource objectDataSourceChrt3 = new ObjectDataSource();
            objectDataSourceChrt3.Name = "DataViewerzz";
            objectDataSourceChrt3.DataSource = _ncheck3;
            objectDataSourceChrt3.Fill();

            ObjectDataSource objectDataSourceChrt4 = new ObjectDataSource();
            objectDataSourceChrt4.Name = "DataViewerzz41";
            objectDataSourceChrt4.DataSource = _ncheck4;
            objectDataSourceChrt4.Fill();

            ObjectDataSource objectDataSourceChrt5 = new ObjectDataSource();
            objectDataSourceChrt5.Name = "DataViewersszz1";
            objectDataSourceChrt5.DataSource = _ncheck5;
            objectDataSourceChrt5.Fill();

            ObjectDataSource objectDataSource511 = new ObjectDataSource();
            objectDataSource511.Name = "DataViewersszz1";
            objectDataSource511.DataSource = ncheck41;
            objectDataSource511.Fill();


            ObjectDataSource objectDataSourceChrt7 = new ObjectDataSource();
            objectDataSourceChrt7.Name = "DataViewer4zz1";
            objectDataSourceChrt7.DataSource = _ncheck7;
            objectDataSourceChrt7.Fill();

            ObjectDataSource objectDataSourceChrt8 = new ObjectDataSource();
            objectDataSourceChrt8.Name = "DataV4iewerzz1";
            objectDataSourceChrt8.DataSource = _ncheck8;
            objectDataSourceChrt8.Fill();


            ObjectDataSource objectDataSourceChrt9 = new ObjectDataSource();
            objectDataSourceChrt9.Name = "DataViewer44zz1";
            objectDataSourceChrt9.DataSource = _ncheck9;
            objectDataSourceChrt9.Fill();


            ObjectDataSource objectDataSourceChrt10 = new ObjectDataSource();
            objectDataSourceChrt10.Name = "Data23Viewerzz1";
            objectDataSourceChrt10.DataSource = _ncheck10;
            objectDataSourceChrt10.Fill();


            ObjectDataSource objectDataSourceChrt11 = new ObjectDataSource();
            objectDataSourceChrt11.Name = "DataVie3werzz1";
            objectDataSourceChrt11.DataSource = _ncheck11;
            objectDataSourceChrt11.Fill();

            ObjectDataSource objectDataSourceChrt13 = new ObjectDataSource();
            objectDataSourceChrt13.Name = "Da3taViewerzz1";
            objectDataSourceChrt13.DataSource = _ncheck13;
            objectDataSourceChrt13.Fill();

            ObjectDataSource objectDataSourceChrt14 = new ObjectDataSource();
            objectDataSourceChrt14.Name = "DataVie4werzz1";
            objectDataSourceChrt14.DataSource = _ncheck14;
            objectDataSourceChrt14.Fill();

            ObjectDataSource objectDataSourceChrt15 = new ObjectDataSource();
            objectDataSourceChrt15.Name = "D2ataViewerzz1";
            objectDataSourceChrt15.DataSource = _ncheck15;
            objectDataSourceChrt15.Fill();


            ObjectDataSource objectDataSourceChrt16 = new ObjectDataSource();
            objectDataSourceChrt16.Name = "DataVi4ewerz6z1";
            objectDataSourceChrt16.DataSource = _ncheck16;
            objectDataSourceChrt16.Fill();


            ObjectDataSource objectDataSourceChrt17 = new ObjectDataSource();
            objectDataSourceChrt17.Name = "Dat2aVie3werzz1";
            objectDataSourceChrt17.DataSource = _ncheck17;
            objectDataSourceChrt17.Fill();



            ObjectDataSource objectDataSourceChrt18 = new ObjectDataSource();
            objectDataSourceChrt18.Name = "Da3taView5erzz1";
            objectDataSourceChrt18.DataSource = _ncheck18;
            objectDataSourceChrt18.Fill();

            ObjectDataSource objectDataSourceChrt19 = new ObjectDataSource();
            objectDataSourceChrt19.Name = "DataV2iewerzz21";
            objectDataSourceChrt19.DataSource = _ncheck19;
            objectDataSourceChrt19.Fill();



            ObjectDataSource objectDataSourceChrt20 = new ObjectDataSource();
            objectDataSourceChrt20.Name = "Dat3aView4erzz1";
            objectDataSourceChrt20.DataSource = _ncheck20;
            objectDataSourceChrt20.Fill();


            ObjectDataSource objectDataSourceChrt21 = new ObjectDataSource();
            objectDataSourceChrt21.Name = "DataVriewewrzz1";
            objectDataSourceChrt21.DataSource = _ncheck21;
            objectDataSourceChrt21.Fill();

            ObjectDataSource objectDataSourceChrt22 = new ObjectDataSource();
            objectDataSourceChrt22.Name = "DataVivewerzz1";
            objectDataSourceChrt22.DataSource = _ncheck22;
            objectDataSourceChrt22.Fill();


            ObjectDataSource objectDataSourceChrt23 = new ObjectDataSource();
            objectDataSourceChrt23.Name = "DwataVieewerzz1";
            objectDataSourceChrt23.DataSource = _ncheck23;
            objectDataSourceChrt23.Fill();


            ObjectDataSource objectDataSourceChrt24 = new ObjectDataSource();
            objectDataSourceChrt24.Name = "DatawViewerzz1";
            objectDataSourceChrt24.DataSource = _ncheck24;
            objectDataSourceChrt24.Fill();

            ObjectDataSource objectDataSourceChrt25 = new ObjectDataSource();
            objectDataSourceChrt25.Name = "DataViewerwzz1";
            objectDataSourceChrt25.DataSource = _ncheck25;
            objectDataSourceChrt25.Fill();


            ObjectDataSource objectDataSourceChrt27 = new ObjectDataSource();
            objectDataSourceChrt27.Name = "DataVwiewerzz1";
            objectDataSourceChrt27.DataSource = _ncheck27;
            objectDataSourceChrt27.Fill();

            ObjectDataSource objectDataSource = new ObjectDataSource();
            objectDataSource.Name = "DataViewer1";
            objectDataSource.DataSource = ncheck1;

            objectDataSource.Fill();

            ObjectDataSource objectDataSource1 = new ObjectDataSource();
            objectDataSource1.Name = "DataViewer2";
            objectDataSource1.DataSource = ncheck3;

            objectDataSource1.Fill();

            ObjectDataSource objectDataSource3 = new ObjectDataSource();
            objectDataSource3.Name = "DataViewer3";
            objectDataSource3.DataSource = ncheck5;

            objectDataSource3.Fill();

            //ObjectDataSource objectDataSource5 = new ObjectDataSource();
            //objectDataSource5.Name = "DataViewer4";
            //objectDataSource5.DataSource = ncheck41;

            //objectDataSource5.Fill();


            ObjectDataSource objectDataSource7 = new ObjectDataSource();
            objectDataSource7.Name = "DataViewer5";
            objectDataSource7.DataSource = ncheck43;

            objectDataSource7.Fill();

            ObjectDataSource objectDataSource9 = new ObjectDataSource();
            objectDataSource9.Name = "DataViewer6";
            objectDataSource9.DataSource = ncheck7;

            objectDataSource9.Fill();


            ObjectDataSource objectDataSource9b = new ObjectDataSource();
            objectDataSource9b.Name = "DataViewer7";
            objectDataSource9b.DataSource = ncheck7b;

            objectDataSource9b.Fill();

            ObjectDataSource objectDataSource11 = new ObjectDataSource();
            objectDataSource11.Name = "DataViewer8";
            objectDataSource11.DataSource = ncheck9;

            objectDataSource11.Fill();


            ObjectDataSource objectDataSource11b = new ObjectDataSource();
            objectDataSource11b.Name = "DataViewer9";
            objectDataSource11b.DataSource = ncheck9b;

            objectDataSource11b.Fill();

            ObjectDataSource objectDataSource13 = new ObjectDataSource();
            objectDataSource13.Name = "DataViewer10";
            objectDataSource13.DataSource = ncheck11;

            objectDataSource13.Fill();


            ObjectDataSource objectDataSource13b = new ObjectDataSource();
            objectDataSource13b.Name = "DataViewer11";
            objectDataSource13b.DataSource = ncheck11b;

            objectDataSource13b.Fill();

            ObjectDataSource objectDataSource13b1 = new ObjectDataSource();
            objectDataSource13b1.Name = "DataViewer12";
            objectDataSource13b1.DataSource = ncheck11c;

            objectDataSource13b1.Fill();

            ObjectDataSource objectDataSource13b3 = new ObjectDataSource();
            objectDataSource13b3.Name = "DataViewer13";
            objectDataSource13b3.DataSource = ncheck11d;

            objectDataSource13b3.Fill();
            // Gelirler

            ObjectDataSource objectDataSource15 = new ObjectDataSource();
            objectDataSource15.Name = "DataViewer14";
            objectDataSource15.DataSource = ncheck13;

            objectDataSource15.Fill();

            ObjectDataSource objectDataSource15a = new ObjectDataSource();
            objectDataSource15a.Name = "DataViewer15";
            objectDataSource15a.DataSource = ncheck13brut;

            objectDataSource15a.Fill();

            ObjectDataSource objectDataSource17 = new ObjectDataSource();
            objectDataSource17.Name = "DataViewer16";
            objectDataSource17.DataSource = ncheck15;

            objectDataSource17.Fill();

            ObjectDataSource objectDataSource17a = new ObjectDataSource();
            objectDataSource17a.Name = "DataViewer17";
            objectDataSource17a.DataSource = ncheck15a;

            objectDataSource17a.Fill();


            ObjectDataSource objectDataSource19 = new ObjectDataSource();
            objectDataSource19.Name = "DataViewer18";
            objectDataSource19.DataSource = ncheck17;

            objectDataSource19.Fill();

            ObjectDataSource objectDataSource19a = new ObjectDataSource();
            objectDataSource19a.Name = "DataViewer19";
            objectDataSource19a.DataSource = ncheck17a;

            objectDataSource19a.Fill();

            ObjectDataSource objectDataSource13check = new ObjectDataSource();
            objectDataSource13check.Name = "DataViewer20";
            objectDataSource13check.DataSource = ncheck13Check;

            objectDataSource13check.Fill();

            ObjectDataSource objectDataSource21 = new ObjectDataSource();
            objectDataSource21.Name = "DataViewer21";
            objectDataSource21.DataSource = ncheck19;

            objectDataSource21.Fill();

            ObjectDataSource objectDataSource23 = new ObjectDataSource();
            objectDataSource23.Name = "DataViewer22";
            objectDataSource23.DataSource = ncheck21;

            objectDataSource23.Fill();

            ObjectDataSource objectDataSource25 = new ObjectDataSource();
            objectDataSource25.Name = "DataViewer23";
            objectDataSource25.DataSource = ncheck23;

            objectDataSource25.Fill();

            ObjectDataSource objectDataSource27 = new ObjectDataSource();
            objectDataSource27.Name = "DataViewer24";
            objectDataSource27.DataSource = ncheck25;

            objectDataSource27.Fill();
            checkSeries = new LineSeriesView();


            ObjectDataSource objectDataSource29 = new ObjectDataSource();
            objectDataSource29.Name = "DataViewer25";
            objectDataSource29.DataSource = ncheck27;
            objectDataSource29.Fill();

            DetailReportBand detailReport = report.Bands["DetailReport"] as DetailReportBand;
            detailReport.DataSource = objectDataSource;

            DetailReportBand detailReport1 = report.Bands["DetailReport2"] as DetailReportBand;
            detailReport1.DataSource = objectDataSource1;

            DetailReportBand detailReport3 = report.Bands["DetailReport1"] as DetailReportBand;
            detailReport3.DataSource = objectDataSource3;

            DetailReportBand detailReport5 = report.Bands["DetailReport3"] as DetailReportBand;
            detailReport5.DataSource = objectDataSource511;

            DetailReportBand detailReport7 = report.Bands["DetailReport4"] as DetailReportBand;
            detailReport7.DataSource = objectDataSource7;

            DetailReportBand detailReport9 = report.Bands["DetailReport6"] as DetailReportBand;
            detailReport9.DataSource = objectDataSource9;

            DetailReportBand detailReport9b = report.Bands["DetailReport7"] as DetailReportBand;
            detailReport9b.DataSource = objectDataSource9b;

            DetailReportBand detailReport11 = report.Bands["DetailReport8"] as DetailReportBand;
            detailReport11.DataSource = objectDataSource11;

            DetailReportBand detailReport11b = report.Bands["DetailReport9"] as DetailReportBand;
            detailReport11b.DataSource = objectDataSource11b;

            DetailReportBand detailReport13 = report.Bands["DetailReport10"] as DetailReportBand;
            detailReport13.DataSource = objectDataSource13;

            DetailReportBand detailReport13b = report.Bands["DetailReport11"] as DetailReportBand;
            detailReport13b.DataSource = objectDataSource13b;

            DetailReportBand detailReport13b1 = report.Bands["DetailReport12"] as DetailReportBand;
            detailReport13b1.DataSource = objectDataSource13b1;

            DetailReportBand detailReport13b2 = report.Bands["DetailReport13"] as DetailReportBand;
            detailReport13b2.DataSource = objectDataSource13b3;


            DetailReportBand detailReport15 = report.Bands["DetailReport14"] as DetailReportBand;
            detailReport15.DataSource = objectDataSource15;


            DetailReportBand detailReport15a = report.Bands["DetailReport15"] as DetailReportBand;
            detailReport15a.DataSource = objectDataSource15a;


            DetailReportBand detailReport17 = report.Bands["DetailReport16"] as DetailReportBand;
            detailReport17.DataSource = objectDataSource17;

            DetailReportBand detailReport17a = report.Bands["DetailReport17"] as DetailReportBand;
            detailReport17a.DataSource = objectDataSource17a;


            DetailReportBand detailReport19 = report.Bands["DetailReport18"] as DetailReportBand;
            detailReport19.DataSource = objectDataSource19;


            DetailReportBand detailReport19a = report.Bands["DetailReport19"] as DetailReportBand;
            detailReport19a.DataSource = objectDataSource19a;



            DetailReportBand detailReport13Check = report.Bands["DetailReport20"] as DetailReportBand;
            detailReport13Check.DataSource = objectDataSource13check;


            DetailReportBand detailReport21 = report.Bands["DetailReport21"] as DetailReportBand;
            detailReport21.DataSource = objectDataSource21;



            DetailReportBand detailReport25 = report.Bands["DetailReport23"] as DetailReportBand;
            detailReport25.DataSource = objectDataSource25;


            DetailReportBand detailReport27 = report.Bands["DetailReport24"] as DetailReportBand;
            detailReport27.DataSource = objectDataSource27;


            DetailReportBand detailReport29 = report.Bands["DetailReport25"] as DetailReportBand;
            detailReport29.DataSource = objectDataSource29;

            DetailReportBand detailReport22 = report.Bands["DetailReport22"] as DetailReportBand;
            detailReport22.DataSource = objectDataSourceChrt1;

            DetailReportBand detailReport30 = report.Bands["DetailReport29"] as DetailReportBand;
            detailReport30.DataSource = objectDataSourceChrt2;

            DetailReportBand detailReport31 = report.Bands["DetailReport31"] as DetailReportBand;
            detailReport31.DataSource = objectDataSourceChrt3;

            DetailReportBand detailReport33 = report.Bands["DetailReport33"] as DetailReportBand;
            detailReport33.DataSource = objectDataSourceChrt4;


            DetailReportBand detailReport35 = report.Bands["DetailReport35"] as DetailReportBand;
            detailReport35.DataSource = objectDataSourceChrt5;


            DetailReportBand detailReport37 = report.Bands["DetailReport37"] as DetailReportBand;
            detailReport37.DataSource = objectDataSourceChrt7;



            DetailReportBand detailReport39 = report.Bands["DetailReport39"] as DetailReportBand;
            detailReport39.DataSource = objectDataSourceChrt8;



            DetailReportBand detailReport41 = report.Bands["DetailReport41"] as DetailReportBand;
            detailReport41.DataSource = objectDataSourceChrt9;


            DetailReportBand detailReport43 = report.Bands["DetailReport43"] as DetailReportBand;
            detailReport43.DataSource = objectDataSourceChrt10;


            DetailReportBand detailReport45 = report.Bands["DetailReport45"] as DetailReportBand;
            detailReport45.DataSource = objectDataSourceChrt11;


            DetailReportBand detailReport47 = report.Bands["DetailReport47"] as DetailReportBand;
            detailReport47.DataSource = objectDataSourceChrt13;


            DetailReportBand detailReport49 = report.Bands["DetailReport49"] as DetailReportBand;
            detailReport49.DataSource = objectDataSourceChrt14;


            DetailReportBand detailReport51 = report.Bands["DetailReport51"] as DetailReportBand;
            detailReport51.DataSource = objectDataSourceChrt15;


            DetailReportBand detailReport53 = report.Bands["DetailReport53"] as DetailReportBand;
            detailReport53.DataSource = objectDataSourceChrt16;


            DetailReportBand detailReport55 = report.Bands["DetailReport55"] as DetailReportBand;
            detailReport55.DataSource = objectDataSourceChrt17;


            DetailReportBand detailReport57 = report.Bands["DetailReport57"] as DetailReportBand;
            detailReport57.DataSource = objectDataSourceChrt18;


            DetailReportBand detailReport59 = report.Bands["DetailReport59"] as DetailReportBand;
            detailReport59.DataSource = objectDataSourceChrt19;

            DetailReportBand detailReport61 = report.Bands["DetailReport63"] as DetailReportBand;
            detailReport61.DataSource = objectDataSourceChrt20;


            DetailReportBand detailReport63 = report.Bands["DetailReport65"] as DetailReportBand;
            detailReport63.DataSource = objectDataSourceChrt21;

            DetailReportBand detailReport65 = report.Bands["DetailReport67"] as DetailReportBand;
            detailReport65.DataSource = objectDataSourceChrt22;


            DetailReportBand detailReport67 = report.Bands["DetailReport69"] as DetailReportBand;
            detailReport67.DataSource = objectDataSourceChrt23;


            DetailReportBand detailReport69 = report.Bands["DetailReport71"] as DetailReportBand;
            detailReport69.DataSource = objectDataSourceChrt24;


            DetailReportBand detailReport71 = report.Bands["DetailReport73"] as DetailReportBand;
            detailReport71.DataSource = objectDataSourceChrt25;

            DetailReportBand detailReport715 = report.Bands["DetailReport75"] as DetailReportBand;
            detailReport715.DataSource = objectDataSourceChrt27;
            //DetailReportBand detailReport73 = report.Bands["DetailReport73"] as DetailReportBand;
            //detailReport73.DataSource = objectDataSourceChrt27;


            //DetailReportBand detailReport75 = report.Bands["DetailReport75"] as DetailReportBand;
            //detailReport75.DataSource = objectDataSourceChrt25;

            var chart1 = (XRChart)report.FindControl("xrChart1", false);

            chart1.DataSource = ncheckchart1;//Method from documentation you reffered
            chart1.SeriesTemplate.View = checkSeries;
            chart1.SeriesTemplate.SeriesDataMember = "GridName";
            chart1.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart1.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart1.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var chart2 = (XRChart)report.FindControl("xrChart2", false);

            chart2.DataSource = ncheckchart2;//Method from documentation you reffered
            chart2.SeriesTemplate.View = checkSeries;
            chart2.SeriesTemplate.SeriesDataMember = "GridName";
            chart2.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart2.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart2.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var chart3 = (XRChart)report.FindControl("xrChart3", false);

            chart3.DataSource = ncheckchart3;//Method from documentation you reffered
            chart3.SeriesTemplate.View = checkSeries;
            chart3.SeriesTemplate.SeriesDataMember = "GridName";
            chart3.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart3.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart3.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var chart4 = (XRChart)report.FindControl("xrChart4", false);

            chart4.DataSource = ncheckchart4;//Method from documentation you reffered
            chart4.SeriesTemplate.View = checkSeries;
            chart4.SeriesTemplate.SeriesDataMember = "GridName";
            chart4.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart4.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart4.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var chart5 = (XRChart)report.FindControl("xrChart5", false);
            chart5.DataSource = ncheckchart5;//Method from documentation you reffered
            chart5.SeriesTemplate.View = checkSeries;
            chart5.SeriesTemplate.SeriesDataMember = "GridName";
            chart5.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart5.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart5.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var chart7 = (XRChart)report.FindControl("xrChart6", false);
            chart7.DataSource = ncheckchart7;//Method from documentation you reffered
            chart7.SeriesTemplate.View = checkSeries;
            chart7.SeriesTemplate.SeriesDataMember = "GridName";
            chart7.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart7.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart7.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var chart8 = (XRChart)report.FindControl("xrChart7", false);
            chart8.DataSource = ncheckchart8;//Method from documentation you reffered
            chart8.SeriesTemplate.View = checkSeries;
            chart8.SeriesTemplate.SeriesDataMember = "GridName";
            chart8.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart8.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart8.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var chart81 = (XRChart)report.FindControl("xrChart8", false);
            chart81.DataSource = ncheckchart9;//Method from documentation you reffered
            chart81.SeriesTemplate.View = checkSeries;
            chart81.SeriesTemplate.SeriesDataMember = "GridName";
            chart81.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart81.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart81.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var xrChart9 = (XRChart)report.FindControl("xrChart9", false);
            xrChart9.DataSource = ncheckchart10;//Method from documentation you reffered
            xrChart9.SeriesTemplate.View = checkSeries;
            xrChart9.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart9.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart9.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart9.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var xrChart10 = (XRChart)report.FindControl("xrChart10", false);
            xrChart10.DataSource = ncheckchart11;//Method from documentation you reffered
            xrChart10.SeriesTemplate.View = checkSeries;
            xrChart10.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart10.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart10.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart10.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart11 = (XRChart)report.FindControl("xrChart11", false);
            xrChart11.DataSource = ncheckchart13;//Method from documentation you reffered
            xrChart11.SeriesTemplate.View = checkSeries;
            xrChart11.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart11.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart11.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart11.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart12 = (XRChart)report.FindControl("xrChart12", false);
            xrChart12.DataSource = ncheckchart14;//Method from documentation you reffered
            xrChart12.SeriesTemplate.View = checkSeries;
            xrChart12.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart12.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart12.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart12.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart13 = (XRChart)report.FindControl("xrChart13", false);
            xrChart13.DataSource = ncheckchart15;//Method from documentation you reffered
            xrChart13.SeriesTemplate.View = checkSeries;
            xrChart13.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart13.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart13.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart13.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart14 = (XRChart)report.FindControl("xrChart14", false);
            xrChart14.DataSource = ncheckchart16;//Method from documentation you reffered
            xrChart14.SeriesTemplate.View = checkSeries;
            xrChart14.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart14.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart14.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart14.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart15 = (XRChart)report.FindControl("xrChart15", false);
            xrChart15.DataSource = ncheckchart17;//Method from documentation you reffered
            xrChart15.SeriesTemplate.View = checkSeries;
            xrChart15.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart15.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart15.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart15.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart16 = (XRChart)report.FindControl("xrChart16", false);
            xrChart16.DataSource = ncheckchart18;//Method from documentation you reffered
            xrChart16.SeriesTemplate.View = checkSeries;
            xrChart16.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart16.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart16.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart16.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart17 = (XRChart)report.FindControl("xrChart17", false);
            xrChart17.DataSource = ncheckchart19;//Method from documentation you reffered
            xrChart17.SeriesTemplate.View = checkSeries;
            xrChart17.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart17.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart17.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart17.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var xrChart18 = (XRChart)report.FindControl("xrChart18", false);
            xrChart18.DataSource = ncheckchart20;//Method from documentation you reffered
            xrChart18.SeriesTemplate.View = checkSeries;
            xrChart18.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart18.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart18.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart18.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart19 = (XRChart)report.FindControl("xrChart19", false);
            xrChart19.DataSource = ncheckchart21;//Method from documentation you reffered
            xrChart19.SeriesTemplate.View = checkSeries;
            xrChart19.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart19.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart19.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart19.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart20 = (XRChart)report.FindControl("xrChart20", false);
            xrChart20.DataSource = ncheckchart22;//Method from documentation you reffered
            xrChart20.SeriesTemplate.View = checkSeries;
            xrChart20.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart20.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart20.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart20.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart21 = (XRChart)report.FindControl("xrChart21", false);
            xrChart21.DataSource = ncheckchart23;//Method from documentation you reffered
            xrChart21.SeriesTemplate.View = checkSeries;
            xrChart21.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart21.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart21.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart21.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart22 = (XRChart)report.FindControl("xrChart22", false);
            xrChart22.DataSource = ncheckchart24;//Method from documentation you reffered
            xrChart22.SeriesTemplate.View = checkSeries;
            xrChart22.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart22.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart22.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart22.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart23 = (XRChart)report.FindControl("xrChart23", false);
            xrChart23.DataSource = ncheckchart25;//Method from documentation you reffered
            xrChart23.SeriesTemplate.View = checkSeries;
            xrChart23.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart23.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart23.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart23.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart24 = (XRChart)report.FindControl("xrChart24", false);
            xrChart24.DataSource = ncheckchart27;//Method from documentation you reffered
            xrChart24.SeriesTemplate.View = checkSeries;
            xrChart24.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart24.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart24.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart24.SeriesTemplate.ValueDataMembers.AddRange("Amount");
            //PdfExportOptions pdfOptions = report.ExportOptions.Pdf;
            //var xrChart25 = (XRChart)report.FindControl("xrChart25", false);
            //xrChart25.DataSource = ncheckchart27;//Method from documentation you reffered
            //xrChart25.SeriesTemplate.View = checkSeries;
            //xrChart25.SeriesTemplate.SeriesDataMember = "GridName";
            //xrChart25.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            //xrChart25.SeriesTemplate.ArgumentDataMember = "GroupText";
            //xrChart25.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            //pdfOptions.DocumentOptions.Application = "Fincheckup Application";
            //pdfOptions.DocumentOptions.Author = "Fincheckup Team";
            //pdfOptions.DocumentOptions.Keywords = "Fincheckup, Reporting, Finance";
            //pdfOptions.DocumentOptions.Producer = "";
            //pdfOptions.DocumentOptions.Subject = "Fincheckup Reporting";
            //pdfOptions.DocumentOptions.Title = "Finance Reporting";

            report.xrLblYear.Text = YearCurrent.ToString();
            report.xrlblYear1.Text = YearCurrent.ToString();
            report.xrlblYear3.Text = YearCurrent.ToString();
            report.xr1Label113.Text = YearCurrent.ToString();
            report.xr1Label122.Text = YearCurrent.ToString();
            report.xr1Label126.Text = YearCurrent.ToString();
            report.xr1Label128.Text = YearCurrent.ToString();
            report.xr1Label132.Text = YearCurrent.ToString();
            report.xr1Label136.Text = YearCurrent.ToString();
            report.xr1Label138.Text = YearCurrent.ToString();
            report.xr1Label142.Text = YearCurrent.ToString();
            report.xr1Label144.Text = YearCurrent.ToString();
            report.xr1Label146.Text = YearCurrent.ToString();
            report.xr1Label148.Text = YearCurrent.ToString();
            report.xr1Label150.Text = YearCurrent.ToString();
            report.xr1Label152.Text = YearCurrent.ToString();
            report.xr1Label154.Text = YearCurrent.ToString();
            report.xr1Label156.Text = YearCurrent.ToString();
            report.xr1Label158.Text = YearCurrent.ToString();
            report.xr1Label160.Text = YearCurrent.ToString();
            report.xr1Label162.Text = YearCurrent.ToString();
            report.xr1Label164.Text = YearCurrent.ToString();
            report.xrlblYear5.Text = YearCurrent.ToString();
            report.xr1Label166.Text = YearCurrent.ToString();
            report.xr1Label168.Text = YearCurrent.ToString();
            report.xr1Label170.Text = YearCurrent.ToString();
            report.xr1Label172.Text = YearCurrent.ToString();

            report.xr2Label117.Text = YearCurrentaTx.ToString();
            report.xr2Label123.Text = YearCurrentaTx.ToString();
            report.xr2Label127.Text = YearCurrentaTx.ToString();
            report.xr2Label131.Text = YearCurrentaTx.ToString();
            report.xr2Label133.Text = YearCurrentaTx.ToString();
            report.xr2Label137.Text = YearCurrentaTx.ToString();
            report.xr2Label141.Text = YearCurrentaTx.ToString();
            report.xr2Label143.Text = YearCurrentaTx.ToString();
            report.xr2Label145.Text = YearCurrentaTx.ToString();
            report.xr2Label147.Text = YearCurrentaTx.ToString();
            report.xr2Label149.Text = YearCurrentaTx.ToString();
            report.xr2Label151.Text = YearCurrentaTx.ToString();
            report.xr2Label153.Text = YearCurrentaTx.ToString();
            report.xr2Label155.Text = YearCurrentaTx.ToString();
            report.xrlblYer221a.Text = YearCurrentaTx.ToString();
            report.xr2Label157.Text = YearCurrentaTx.ToString();
            report.xr2Label159.Text = YearCurrentaTx.ToString();
            report.xr2Label161.Text = YearCurrentaTx.ToString();
            report.xr2Label163.Text = YearCurrentaTx.ToString();
            report.xr2Label163.Text = YearCurrentaTx.ToString();
            report.xr2Label165.Text = YearCurrentaTx.ToString();
            report.xr2Label167.Text = YearCurrentaTx.ToString();
            report.xr2Label169.Text = YearCurrentaTx.ToString();
            report.xrlblYer221a11.Text = YearCurrentaTx.ToString();
            report.xrlblYer221a21.Text = YearCurrentaTx.ToString();
            report.xrlblYer221a33.Text = YearCurrentaTx.ToString();
            report.xrlblYer221a.Text = YearCurrentaTx.ToString();
            report.xr2Label171.Text = YearCurrentaTx.ToString();
            report.xr2Label173.Text = YearCurrentaTx.ToString();
            return report;

        }

        public static FinansRaporub getReportb(long companyID, List<int> nyear, string nacceco, long usride_, List<int> nyearChkList, CompanyReportView grview, int chkMizan = 0)
        {
            YearCurrent = nyearChkList[0];
            YearCurrenta = nyearChkList[1];
            YearCurrentb = nyearChkList[2]; Companies.DataReportMainNace(nacceco, companyID); grview = Companies.Get_CompanyReportView(companyID);

           
            setReportZone(companyID, nyear, chkMizan);
            string metin = string.Empty;
            int maxyearTcmb = Companies.Get_LastTCMBReportYear();
            List<int> nyearchk = new List<int>();
            nyearchk.Add(YearCurrent);
            int chk = Companies.DataReportMainLastMonth(YearCurrentb, companyID);

            YearCurrentbTx = YearCurrentb.ToString() + " - " + chk.ToString();
            if (nyearChkList.Contains(maxyearTcmb))
            {
                metin = "<html><body>" + RepText1(nyearChkList, 4, nacceco);
                metin += "<br>" + RepText5(companyID, YearCurrent);
            }
            else
            {
                metin = RepText1(nyearChkList, 2, nacceco);
                metin += "<br>" + RepText4(companyID, YearCurrent);
            }
            metin += "</body></html>";

            ncheck = MainDash.DataReportMainQnbT(companyID);

            ncheck1 = ncheck.Where(x => x.MainTypeID == 1).ToList();

            ncheck3 = ncheck.Where(x => x.MainTypeID == 2).FirstOrDefault();
            //ncheck1 = reportZone.getReverse(ncheck1, ncheck3.Amount);


            ncheck5 = ncheck.Where(x => x.MainTypeID == 3).ToList();
            ncheck41 = ncheck.Where(x => x.MainTypeID == 4 && x.TypeID == 471).FirstOrDefault();
            ncheck43 = ncheck.Where(x => x.MainTypeID == 4 && x.TypeID == 473).FirstOrDefault();
            //ncheck3 = reportZone.getReverseSingle(ncheck3, ncheck43.Amount);
            //ncheck41 = reportZone.getReverseSingle(ncheck41, ncheck43.Amount);
            //ncheck5 = reportZone.getReverse(ncheck5, ncheck41.Amount);

            // 2.Sayfa

            ncheck7 = ncheck.Where(x => x.MainTypeID == 5).ToList();
            ncheck9 = ncheck.Where(x => x.MainTypeID == 7).ToList();
            ncheck11 = ncheck.Where(x => x.MainTypeID == 9).ToList();
            ncheck7b = ncheck.Where(x => x.MainTypeID == 6).FirstOrDefault();
            ncheck9b = ncheck.Where(x => x.MainTypeID == 8).FirstOrDefault();
            ncheck11b = ncheck.Where(x => x.TypeID == 951).FirstOrDefault();

            ncheck11c = ncheck.Where(x => x.TypeID == 953).FirstOrDefault();
            ncheck11d = ncheck.Where(x => x.TypeID == 955).FirstOrDefault();

            //ncheck7 = reportZone.getReverse(ncheck7, ncheck7b.Amount);
            //ncheck9 = reportZone.getReverse(ncheck9, ncheck9b.Amount);
            //ncheck11 = reportZone.getReverse(ncheck11, ncheck11b.Amount);

            //ncheck7b = reportZone.getReverseSingle(ncheck7b, ncheck11d.Amount);
            //ncheck9b = reportZone.getReverseSingle(ncheck9b, ncheck11d.Amount);
            //ncheck11b = reportZone.getReverseSingle(ncheck11b, ncheck11d.Amount);
            //ncheck11c = reportZone.getReverseSingle(ncheck11c, ncheck11d.Amount);


            //gelirler
            ncheckGelir = MainDash.DataReportMainQnbGelirT(companyID);
            ncheck13 = ncheckGelir.Where(x => x.MainTypeID == 13).ToList();
            ncheck13brut = ncheckGelir.Where(x => x.TypeID == 109).FirstOrDefault();

            ncheck15 = ncheckGelir.Where(x => x.TypeID == 111).FirstOrDefault();
            ncheck15a = ncheckGelir.Where(x => x.TypeID == 113).FirstOrDefault();

            ncheck17 = ncheckGelir.Where(x => x.TypeID == 115).FirstOrDefault();
            ncheck17a = ncheckGelir.Where(x => x.TypeID == 117).FirstOrDefault();

            ncheck13Check = ncheckGelir.Where(x => x.MainTypeID == 23).ToList();

            ncheck19 = ncheckGelir.Where(x => x.TypeID == 125).FirstOrDefault();

            ncheck23 = ncheckGelir.Where(x => x.MainTypeID == 27).ToList();


            ncheck25 = ncheckGelir.Where(x => x.TypeID == 133).FirstOrDefault();

            ncheck27 = ncheckGelir.Where(x => x.TypeID == 135).FirstOrDefault();

            //var tst = ncheck13.Where(x => x.MainTypeID == 13 && x.TypeID == 101).FirstOrDefault();
            //ncheck13 = reportZone.getReverse(ncheck13, ncheck25.Amount);
            //ncheck13brut = reportZone.getReverseSingle(ncheck13brut, ncheck25.Amount);
            //ncheck15 = reportZone.getReverseSingle(ncheck15, ncheck25.Amount);
            //ncheck15a = reportZone.getReverseSingle(ncheck15a, ncheck25.Amount);
            //ncheck17 = reportZone.getReverseSingle(ncheck17, ncheck25.Amount);
            //ncheck17a = reportZone.getReverseSingle(ncheck17a, ncheck25.Amount);

            //tst = reportZone.getReverseSingle(tst, tst.Amount);

            //ncheck13Check = reportZone.getReverse(ncheck13Check, ncheck25.Amount);

            //ncheck19 = reportZone.getReverseSingle(ncheck19, ncheck25.Amount);
            //ncheck23 = reportZone.getReverse(ncheck23, ncheck25.Amount);

            //ncheck25 = reportZone.getReverseSingle(ncheck25, ncheck25.Amount);
            // chartlar
            _ncheckzone = MainDash.DataReportMain1DynamicMain(companyID);
            ncheckchartzone = MainDash.DataReportMain1DynamicMainChart(companyID);
            _ncheck1 = _ncheckzone.Where(x => x.TypeID == 101).ToList();
            ncheckchart1 = ncheckchartzone.Where(x => x.TypeID == 101).ToList();

            _ncheck1.ToList().ForEach(i => i.Amount = i.Amount / 1000000); _ncheck1.ToList().ForEach(i => i.Amount1 = i.Amount1 / 1000000);
            _ncheck1.ToList().ForEach(i => i.Amount2 = i.Amount2 / 1000000);
            _ncheck1.ToList().ForEach(i => i.Amount3 = i.Amount3 / 1000000);
            _ncheck1.ToList().ForEach(i => i.Amount4 = i.Amount4 / 1000000);
            ncheckchart1.ToList().ForEach(i => i.Amount = i.Amount / 1000000);

            _ncheck2 = _ncheckzone.Where(x => x.TypeID == 103).ToList();
            ncheckchart2 = ncheckchartzone.Where(x => x.TypeID == 103).ToList();

            _ncheck3 = _ncheckzone.Where(x => x.TypeID == 105).ToList();
            ncheckchart3 = ncheckchartzone.Where(x => x.TypeID == 105).ToList();

            _ncheck4 = _ncheckzone.Where(x => x.TypeID == 104).ToList();
            ncheckchart4 = ncheckchartzone.Where(x => x.TypeID == 104).ToList();

            _ncheck5 = _ncheckzone.Where(x => x.TypeID == 107).ToList();
            ncheckchart5 = ncheckchartzone.Where(x => x.TypeID == 107).ToList();

            _ncheck7 = _ncheckzone.Where(x => x.TypeID == 125).ToList();
            ncheckchart7 = ncheckchartzone.Where(x => x.TypeID == 125).ToList();

            _ncheck8 = _ncheckzone.Where(x => x.TypeID == 109).ToList();
            ncheckchart8 = ncheckchartzone.Where(x => x.TypeID == 109).ToList();

            _ncheck9 = _ncheckzone.Where(x => x.TypeID == 111).ToList();
            ncheckchart9 = ncheckchartzone.Where(x => x.TypeID == 111).ToList();

            _ncheck10 = _ncheckzone.Where(x => x.TypeID == 113).ToList();
            ncheckchart10 = ncheckchartzone.Where(x => x.TypeID == 113).ToList();

            _ncheck11 = _ncheckzone.Where(x => x.TypeID == 115).ToList();
            ncheckchart11 = ncheckchartzone.Where(x => x.TypeID == 115).ToList();


            _ncheck13 = _ncheckzone.Where(x => x.TypeID == 117).ToList();
            ncheckchart13 = ncheckchartzone.Where(x => x.TypeID == 117).ToList();

            _ncheck14 = _ncheckzone.Where(x => x.TypeID == 119).ToList();
            ncheckchart14 = ncheckchartzone.Where(x => x.TypeID == 119).ToList();

            _ncheck15 = _ncheckzone.Where(x => x.TypeID == 121).ToList();
            ncheckchart15 = ncheckchartzone.Where(x => x.TypeID == 121).ToList();

            _ncheck16 = _ncheckzone.Where(x => x.TypeID == 123).ToList();
            ncheckchart16 = ncheckchartzone.Where(x => x.TypeID == 123).ToList();
            //125
            _ncheck17 = _ncheckzone.Where(x => x.TypeID == 127).ToList();
            ncheckchart17 = ncheckchartzone.Where(x => x.TypeID == 127).ToList();

            _ncheck18 = _ncheckzone.Where(x => x.TypeID == 129).ToList();
            ncheckchart18 = ncheckchartzone.Where(x => x.TypeID == 129).ToList();

            _ncheck18.ToList().ForEach(i => i.Amount = i.Amount / 1000000); _ncheck18.ToList().ForEach(i => i.Amount1 = i.Amount1 / 1000000);
            _ncheck18.ToList().ForEach(i => i.Amount2 = i.Amount2 / 1000000);
            _ncheck18.ToList().ForEach(i => i.Amount3 = i.Amount3 / 1000000);
            _ncheck18.ToList().ForEach(i => i.Amount4 = i.Amount4 / 1000000);
            ncheckchart18.ToList().ForEach(i => i.Amount = i.Amount / 1000000);

            _ncheck19 = _ncheckzone.Where(x => x.TypeID == 131).ToList();
            ncheckchart19 = ncheckchartzone.Where(x => x.TypeID == 131).ToList();

            _ncheck20 = _ncheckzone.Where(x => x.TypeID == 133).ToList();
            ncheckchart20 = ncheckchartzone.Where(x => x.TypeID == 133).ToList();

            _ncheck21 = _ncheckzone.Where(x => x.TypeID == 135).ToList();
            ncheckchart21 = ncheckchartzone.Where(x => x.TypeID == 135).ToList();

            _ncheck22 = _ncheckzone.Where(x => x.TypeID == 137).ToList();
            ncheckchart22 = ncheckchartzone.Where(x => x.TypeID == 137).ToList();

            _ncheck23 = _ncheckzone.Where(x => x.TypeID == 139).ToList(); 
            ncheckchart23 = ncheckchartzone.Where(x => x.TypeID == 139).ToList();
            _ncheck23= _ncheck23.Select(c => { c.Amount = float.Parse("365")/c.Amount; return c; }).ToList();
            _ncheck23 = _ncheck23.Select(c => { c.Amount1 = float.Parse("365") / c.Amount1; return c; }).ToList();
            _ncheck23 = _ncheck23.Select(c => { c.Amount2 = float.Parse("365") / c.Amount2; return c; }).ToList();
            _ncheck23 = _ncheck23.Select(c => { c.Amount3 = float.Parse("365") / c.Amount3; return c; }).ToList();
            ncheckchart23= ncheckchart23.Select(c => { c.Amount = float.Parse("365") / c.Amount; return c; }).ToList();

            _ncheck24 = _ncheckzone.Where(x => x.TypeID == 141).ToList();
            ncheckchart24 = ncheckchartzone.Where(x => x.TypeID == 141).ToList();

            _ncheck25 = _ncheckzone.Where(x => x.TypeID == 143).ToList();
            ncheckchart25 = ncheckchartzone.Where(x => x.TypeID == 143).ToList();

            _ncheck27 = _ncheckzone.Where(x => x.TypeID == 145).ToList();
            ncheckchart27 = ncheckchartzone.Where(x => x.TypeID == 145).ToList();
            _ncheck27.ToList().ForEach(i => i.Amount = i.Amount / 1000000); _ncheck27.ToList().ForEach(i => i.Amount1 = i.Amount1 / 1000000);
            _ncheck27.ToList().ForEach(i => i.Amount2 = i.Amount2 / 1000000);
            _ncheck27.ToList().ForEach(i => i.Amount3 = i.Amount3 / 1000000);
            _ncheck27.ToList().ForEach(i => i.Amount4 = i.Amount4 / 1000000);
            ncheckchart27.ToList().ForEach(i => i.Amount = i.Amount / 1000000);
            UserID = usride_;

            FinansRaporub report = new FinansRaporub();

            report.xrRichTxtMeitn.Html = metin;
            report.xr7CompanyName.Text = grview.CompanyName;
            report.xr7NaceKod.Text = grview.Code;
            report.xrSektorAna.Text = grview.MainDescription;
            report.xrSektorDetay.Text = grview.Description;
            //RichEditDocumentServer richEditDocumentServer = new RichEditDocumentServer();
            //richEditDocumentServer.RtfText = metin;
            //ApplyRTFModification(richEditDocumentServer);
            //report.xrRichTextMetin.Rtf = richEditDocumentServer.RtfText;


            ObjectDataSource objectDataSourceChrt1 = new ObjectDataSource();
            objectDataSourceChrt1.Name = "DataViewer";
            objectDataSourceChrt1.DataSource = _ncheck1;
            objectDataSourceChrt1.Fill();

            ObjectDataSource objectDataSourceChrt2 = new ObjectDataSource();
            objectDataSourceChrt2.Name = "DataViewerz";
            objectDataSourceChrt2.DataSource = _ncheck2;
            objectDataSourceChrt2.Fill();

            ObjectDataSource objectDataSourceChrt3 = new ObjectDataSource();
            objectDataSourceChrt3.Name = "DataViewerzz";
            objectDataSourceChrt3.DataSource = _ncheck3;
            objectDataSourceChrt3.Fill();

            ObjectDataSource objectDataSourceChrt4 = new ObjectDataSource();
            objectDataSourceChrt4.Name = "DataVi7ewerzz1";
            objectDataSourceChrt4.DataSource = _ncheck4;
            objectDataSourceChrt4.Fill();

            ObjectDataSource objectDataSourceChrt5 = new ObjectDataSource();
            objectDataSourceChrt5.Name = "DataViewersszz1";
            objectDataSourceChrt5.DataSource = _ncheck5;
            objectDataSourceChrt5.Fill();

            ObjectDataSource objectDataSource511 = new ObjectDataSource();
            objectDataSource511.Name = "DataViewersszz1";
            objectDataSource511.DataSource = ncheck41;
            objectDataSource511.Fill();


            ObjectDataSource objectDataSourceChrt7 = new ObjectDataSource();
            objectDataSourceChrt7.Name = "DataViewerzgz1";
            objectDataSourceChrt7.DataSource = _ncheck7;
            objectDataSourceChrt7.Fill();

            ObjectDataSource objectDataSourceChrt8 = new ObjectDataSource();
            objectDataSourceChrt8.Name = "DataViewerzfz1";
            objectDataSourceChrt8.DataSource = _ncheck8;
            objectDataSourceChrt8.Fill();


            ObjectDataSource objectDataSourceChrt9 = new ObjectDataSource();
            objectDataSourceChrt9.Name = "DataViewerczz1";
            objectDataSourceChrt9.DataSource = _ncheck9;
            objectDataSourceChrt9.Fill();


            ObjectDataSource objectDataSourceChrt10 = new ObjectDataSource();
            objectDataSourceChrt10.Name = "DataViedwerzz1";
            objectDataSourceChrt10.DataSource = _ncheck10;
            objectDataSourceChrt10.Fill();


            ObjectDataSource objectDataSourceChrt11 = new ObjectDataSource();
            objectDataSourceChrt11.Name = "DataVieweerzz1";
            objectDataSourceChrt11.DataSource = _ncheck11;
            objectDataSourceChrt11.Fill();

            ObjectDataSource objectDataSourceChrt13 = new ObjectDataSource();
            objectDataSourceChrt13.Name = "DataVeiewerzz1";
            objectDataSourceChrt13.DataSource = _ncheck13;
            objectDataSourceChrt13.Fill();

            ObjectDataSource objectDataSourceChrt14 = new ObjectDataSource();
            objectDataSourceChrt14.Name = "DatawViewerzz1";
            objectDataSourceChrt14.DataSource = _ncheck14;
            objectDataSourceChrt14.Fill();

            ObjectDataSource objectDataSourceChrt15 = new ObjectDataSource();
            objectDataSourceChrt15.Name = "DataViecwerzz1";
            objectDataSourceChrt15.DataSource = _ncheck15;
            objectDataSourceChrt15.Fill();


            ObjectDataSource objectDataSourceChrt16 = new ObjectDataSource();
            objectDataSourceChrt16.Name = "DatasViewerzz1";
            objectDataSourceChrt16.DataSource = _ncheck16;
            objectDataSourceChrt16.Fill();


            ObjectDataSource objectDataSourceChrt17 = new ObjectDataSource();
            objectDataSourceChrt17.Name = "DataViewesrzz1";
            objectDataSourceChrt17.DataSource = _ncheck17;
            objectDataSourceChrt17.Fill();



            ObjectDataSource objectDataSourceChrt18 = new ObjectDataSource();
            objectDataSourceChrt18.Name = "DataVi2ewerzz1";
            objectDataSourceChrt18.DataSource = _ncheck18;
            objectDataSourceChrt18.Fill();

            ObjectDataSource objectDataSourceChrt19 = new ObjectDataSource();
            objectDataSourceChrt19.Name = "DataView3erzz1";
            objectDataSourceChrt19.DataSource = _ncheck19;
            objectDataSourceChrt19.Fill();



            ObjectDataSource objectDataSourceChrt20 = new ObjectDataSource();
            objectDataSourceChrt20.Name = "DataViewe4rzz1";
            objectDataSourceChrt20.DataSource = _ncheck20;
            objectDataSourceChrt20.Fill();


            ObjectDataSource objectDataSourceChrt21 = new ObjectDataSource();
            objectDataSourceChrt21.Name = "Dat5aViewerzz1";
            objectDataSourceChrt21.DataSource = _ncheck21;
            objectDataSourceChrt21.Fill();

            ObjectDataSource objectDataSourceChrt22 = new ObjectDataSource();
            objectDataSourceChrt22.Name = "DataViewer6zz1";
            objectDataSourceChrt22.DataSource = _ncheck22;
            objectDataSourceChrt22.Fill();


            ObjectDataSource objectDataSourceChrt23 = new ObjectDataSource();
            objectDataSourceChrt23.Name = "DataV7iewerzz1";
            objectDataSourceChrt23.DataSource = _ncheck23;
            objectDataSourceChrt23.Fill();


            ObjectDataSource objectDataSourceChrt24 = new ObjectDataSource();
            objectDataSourceChrt24.Name = "DataViewe8rzz1";
            objectDataSourceChrt24.DataSource = _ncheck24;
            objectDataSourceChrt24.Fill();

            ObjectDataSource objectDataSourceChrt25 = new ObjectDataSource();
            objectDataSourceChrt25.Name = "DataViewer9zz1";
            objectDataSourceChrt25.DataSource = _ncheck25;
            objectDataSourceChrt25.Fill();


            ObjectDataSource objectDataSourceChrt27 = new ObjectDataSource();
            objectDataSourceChrt27.Name = "DataViewerz3z1";
            objectDataSourceChrt27.DataSource = _ncheck27;
            objectDataSourceChrt27.Fill();

            ObjectDataSource objectDataSource = new ObjectDataSource();
            objectDataSource.Name = "DataViewer1";
            objectDataSource.DataSource = ncheck1;

            objectDataSource.Fill();

            ObjectDataSource objectDataSource1 = new ObjectDataSource();
            objectDataSource1.Name = "DataViewer2";
            objectDataSource1.DataSource = ncheck3;

            objectDataSource1.Fill();

            ObjectDataSource objectDataSource3 = new ObjectDataSource();
            objectDataSource3.Name = "DataViewer3";
            objectDataSource3.DataSource = ncheck5;

            objectDataSource3.Fill();

            //ObjectDataSource objectDataSource5 = new ObjectDataSource();
            //objectDataSource5.Name = "DataViewer4";
            //objectDataSource5.DataSource = ncheck41;

            //objectDataSource5.Fill();


            ObjectDataSource objectDataSource7 = new ObjectDataSource();
            objectDataSource7.Name = "DataViewer5";
            objectDataSource7.DataSource = ncheck43;

            objectDataSource7.Fill();

            ObjectDataSource objectDataSource9 = new ObjectDataSource();
            objectDataSource9.Name = "DataViewer6";
            objectDataSource9.DataSource = ncheck7;

            objectDataSource9.Fill();


            ObjectDataSource objectDataSource9b = new ObjectDataSource();
            objectDataSource9b.Name = "DataViewer7";
            objectDataSource9b.DataSource = ncheck7b;

            objectDataSource9b.Fill();

            ObjectDataSource objectDataSource11 = new ObjectDataSource();
            objectDataSource11.Name = "DataViewer8";
            objectDataSource11.DataSource = ncheck9;

            objectDataSource11.Fill();


            ObjectDataSource objectDataSource11b = new ObjectDataSource();
            objectDataSource11b.Name = "DataViewer9";
            objectDataSource11b.DataSource = ncheck9b;

            objectDataSource11b.Fill();

            ObjectDataSource objectDataSource13 = new ObjectDataSource();
            objectDataSource13.Name = "DataViewer10";
            objectDataSource13.DataSource = ncheck11;

            objectDataSource13.Fill();


            ObjectDataSource objectDataSource13b = new ObjectDataSource();
            objectDataSource13b.Name = "DataViewer11";
            objectDataSource13b.DataSource = ncheck11b;

            objectDataSource13b.Fill();

            ObjectDataSource objectDataSource13b1 = new ObjectDataSource();
            objectDataSource13b1.Name = "DataViewer12";
            objectDataSource13b1.DataSource = ncheck11c;

            objectDataSource13b1.Fill();

            ObjectDataSource objectDataSource13b3 = new ObjectDataSource();
            objectDataSource13b3.Name = "DataViewer13";
            objectDataSource13b3.DataSource = ncheck11d;

            objectDataSource13b3.Fill();
            // Gelirler

            ObjectDataSource objectDataSource15 = new ObjectDataSource();
            objectDataSource15.Name = "DataViewer14";
            objectDataSource15.DataSource = ncheck13;

            objectDataSource15.Fill();

            ObjectDataSource objectDataSource15a = new ObjectDataSource();
            objectDataSource15a.Name = "DataViewer15";
            objectDataSource15a.DataSource = ncheck13brut;

            objectDataSource15a.Fill();

            ObjectDataSource objectDataSource17 = new ObjectDataSource();
            objectDataSource17.Name = "DataViewer16";
            objectDataSource17.DataSource = ncheck15;

            objectDataSource17.Fill();

            ObjectDataSource objectDataSource17a = new ObjectDataSource();
            objectDataSource17a.Name = "DataViewer17";
            objectDataSource17a.DataSource = ncheck15a;

            objectDataSource17a.Fill();


            ObjectDataSource objectDataSource19 = new ObjectDataSource();
            objectDataSource19.Name = "DataViewer18";
            objectDataSource19.DataSource = ncheck17;

            objectDataSource19.Fill();

            ObjectDataSource objectDataSource19a = new ObjectDataSource();
            objectDataSource19a.Name = "DataViewer19";
            objectDataSource19a.DataSource = ncheck17a;

            objectDataSource19a.Fill();

            ObjectDataSource objectDataSource13check = new ObjectDataSource();
            objectDataSource13check.Name = "DataViewer20";
            objectDataSource13check.DataSource = ncheck13Check;

            objectDataSource13check.Fill();

            ObjectDataSource objectDataSource21 = new ObjectDataSource();
            objectDataSource21.Name = "DataViewer21";
            objectDataSource21.DataSource = ncheck19;

            objectDataSource21.Fill();

            ObjectDataSource objectDataSource23 = new ObjectDataSource();
            objectDataSource23.Name = "DataViewer22";
            objectDataSource23.DataSource = ncheck21;

            objectDataSource23.Fill();

            ObjectDataSource objectDataSource25 = new ObjectDataSource();
            objectDataSource25.Name = "DataViewer23";
            objectDataSource25.DataSource = ncheck23;

            objectDataSource25.Fill();

            ObjectDataSource objectDataSource27 = new ObjectDataSource();
            objectDataSource27.Name = "DataViewer24";
            objectDataSource27.DataSource = ncheck25;

            objectDataSource27.Fill();
            checkSeries = new LineSeriesView();


            ObjectDataSource objectDataSource29 = new ObjectDataSource();
            objectDataSource29.Name = "DataViewer25";
            objectDataSource29.DataSource = ncheck27;
            objectDataSource29.Fill();

            DetailReportBand detailReport = report.Bands["DetailReport"] as DetailReportBand;
            detailReport.DataSource = objectDataSource;

            DetailReportBand detailReport1 = report.Bands["DetailReport2"] as DetailReportBand;
            detailReport1.DataSource = objectDataSource1;

            DetailReportBand detailReport3 = report.Bands["DetailReport1"] as DetailReportBand;
            detailReport3.DataSource = objectDataSource3;

            DetailReportBand detailReport5 = report.Bands["DetailReport3"] as DetailReportBand;
            detailReport5.DataSource = objectDataSource511;

            DetailReportBand detailReport7 = report.Bands["DetailReport4"] as DetailReportBand;
            detailReport7.DataSource = objectDataSource7;

            DetailReportBand detailReport9 = report.Bands["DetailReport6"] as DetailReportBand;
            detailReport9.DataSource = objectDataSource9;

            DetailReportBand detailReport9b = report.Bands["DetailReport7"] as DetailReportBand;
            detailReport9b.DataSource = objectDataSource9b;

            DetailReportBand detailReport11 = report.Bands["DetailReport8"] as DetailReportBand;
            detailReport11.DataSource = objectDataSource11;

            DetailReportBand detailReport11b = report.Bands["DetailReport9"] as DetailReportBand;
            detailReport11b.DataSource = objectDataSource11b;

            DetailReportBand detailReport13 = report.Bands["DetailReport10"] as DetailReportBand;
            detailReport13.DataSource = objectDataSource13;

            DetailReportBand detailReport13b = report.Bands["DetailReport11"] as DetailReportBand;
            detailReport13b.DataSource = objectDataSource13b;

            DetailReportBand detailReport13b1 = report.Bands["DetailReport12"] as DetailReportBand;
            detailReport13b1.DataSource = objectDataSource13b1;

            DetailReportBand detailReport13b2 = report.Bands["DetailReport13"] as DetailReportBand;
            detailReport13b2.DataSource = objectDataSource13b3;


            DetailReportBand detailReport15 = report.Bands["DetailReport14"] as DetailReportBand;
            detailReport15.DataSource = objectDataSource15;


            DetailReportBand detailReport15a = report.Bands["DetailReport15"] as DetailReportBand;
            detailReport15a.DataSource = objectDataSource15a;


            DetailReportBand detailReport17 = report.Bands["DetailReport16"] as DetailReportBand;
            detailReport17.DataSource = objectDataSource17;

            DetailReportBand detailReport17a = report.Bands["DetailReport17"] as DetailReportBand;
            detailReport17a.DataSource = objectDataSource17a;


            DetailReportBand detailReport19 = report.Bands["DetailReport18"] as DetailReportBand;
            detailReport19.DataSource = objectDataSource19;


            DetailReportBand detailReport19a = report.Bands["DetailReport19"] as DetailReportBand;
            detailReport19a.DataSource = objectDataSource19a;



            DetailReportBand detailReport13Check = report.Bands["DetailReport20"] as DetailReportBand;
            detailReport13Check.DataSource = objectDataSource13check;


            DetailReportBand detailReport21 = report.Bands["DetailReport21"] as DetailReportBand;
            detailReport21.DataSource = objectDataSource21;



            DetailReportBand detailReport25 = report.Bands["DetailReport23"] as DetailReportBand;
            detailReport25.DataSource = objectDataSource25;


            DetailReportBand detailReport27 = report.Bands["DetailReport24"] as DetailReportBand;
            detailReport27.DataSource = objectDataSource27;


            DetailReportBand detailReport29 = report.Bands["DetailReport25"] as DetailReportBand;
            detailReport29.DataSource = objectDataSource29;

            DetailReportBand detailReport22 = report.Bands["DetailReport22"] as DetailReportBand;
            detailReport22.DataSource = objectDataSourceChrt1;

            DetailReportBand detailReport30 = report.Bands["DetailReport29"] as DetailReportBand;
            detailReport30.DataSource = objectDataSourceChrt2;

            DetailReportBand detailReport31 = report.Bands["DetailReport31"] as DetailReportBand;
            detailReport31.DataSource = objectDataSourceChrt3;

            DetailReportBand detailReport33 = report.Bands["DetailReport33"] as DetailReportBand;
            detailReport33.DataSource = objectDataSourceChrt4;


            DetailReportBand detailReport35 = report.Bands["DetailReport35"] as DetailReportBand;
            detailReport35.DataSource = objectDataSourceChrt5;


            DetailReportBand detailReport37 = report.Bands["DetailReport37"] as DetailReportBand;
            detailReport37.DataSource = objectDataSourceChrt7;



            DetailReportBand detailReport39 = report.Bands["DetailReport39"] as DetailReportBand;
            detailReport39.DataSource = objectDataSourceChrt8;



            DetailReportBand detailReport41 = report.Bands["DetailReport41"] as DetailReportBand;
            detailReport41.DataSource = objectDataSourceChrt9;


            DetailReportBand detailReport43 = report.Bands["DetailReport43"] as DetailReportBand;
            detailReport43.DataSource = objectDataSourceChrt10;


            DetailReportBand detailReport45 = report.Bands["DetailReport45"] as DetailReportBand;
            detailReport45.DataSource = objectDataSourceChrt11;


            DetailReportBand detailReport47 = report.Bands["DetailReport47"] as DetailReportBand;
            detailReport47.DataSource = objectDataSourceChrt13;


            DetailReportBand detailReport49 = report.Bands["DetailReport49"] as DetailReportBand;
            detailReport49.DataSource = objectDataSourceChrt14;


            DetailReportBand detailReport51 = report.Bands["DetailReport51"] as DetailReportBand;
            detailReport51.DataSource = objectDataSourceChrt15;


            DetailReportBand detailReport53 = report.Bands["DetailReport53"] as DetailReportBand;
            detailReport53.DataSource = objectDataSourceChrt16;


            DetailReportBand detailReport55 = report.Bands["DetailReport55"] as DetailReportBand;
            detailReport55.DataSource = objectDataSourceChrt17;


            DetailReportBand detailReport57 = report.Bands["DetailReport57"] as DetailReportBand;
            detailReport57.DataSource = objectDataSourceChrt18;


            DetailReportBand detailReport59 = report.Bands["DetailReport59"] as DetailReportBand;
            detailReport59.DataSource = objectDataSourceChrt19;

            DetailReportBand detailReport61 = report.Bands["DetailReport63"] as DetailReportBand;
            detailReport61.DataSource = objectDataSourceChrt20;


            DetailReportBand detailReport63 = report.Bands["DetailReport65"] as DetailReportBand;
            detailReport63.DataSource = objectDataSourceChrt21;

            DetailReportBand detailReport65 = report.Bands["DetailReport67"] as DetailReportBand;
            detailReport65.DataSource = objectDataSourceChrt22;


            DetailReportBand detailReport67 = report.Bands["DetailReport69"] as DetailReportBand;
            detailReport67.DataSource = objectDataSourceChrt23;


            DetailReportBand detailReport69 = report.Bands["DetailReport71"] as DetailReportBand;
            detailReport69.DataSource = objectDataSourceChrt24;


            DetailReportBand detailReport71 = report.Bands["DetailReport73"] as DetailReportBand;
            detailReport71.DataSource = objectDataSourceChrt25;

            DetailReportBand detailReport715 = report.Bands["DetailReport75"] as DetailReportBand;
            detailReport715.DataSource = objectDataSourceChrt27;
            //DetailReportBand detailReport73 = report.Bands["DetailReport73"] as DetailReportBand;
            //detailReport73.DataSource = objectDataSourceChrt27;


            //DetailReportBand detailReport75 = report.Bands["DetailReport75"] as DetailReportBand;
            //detailReport75.DataSource = objectDataSourceChrt25;

            var chart1 = (XRChart)report.FindControl("xrChart1", false);

            chart1.DataSource = ncheckchart1;//Method from documentation you reffered
            chart1.SeriesTemplate.View = checkSeries;
            chart1.SeriesTemplate.SeriesDataMember = "GridName";
            chart1.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart1.SeriesTemplate.ValueDataMembers.AddRange("Amount");
            chart1.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

            var chart2 = (XRChart)report.FindControl("xrChart2", false);

            chart2.DataSource = ncheckchart2;//Method from documentation you reffered
            chart2.SeriesTemplate.View = checkSeries;
            chart2.SeriesTemplate.SeriesDataMember = "GridName";
            chart2.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart2.SeriesTemplate.ValueDataMembers.AddRange("Amount");
            chart2.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            var chart3 = (XRChart)report.FindControl("xrChart3", false);

            chart3.DataSource = ncheckchart3;//Method from documentation you reffered
            chart3.SeriesTemplate.View = checkSeries;
            chart3.SeriesTemplate.SeriesDataMember = "GridName";

            chart3.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart3.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart3.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var chart4 = (XRChart)report.FindControl("xrChart4", false);

            chart4.DataSource = ncheckchart4;//Method from documentation you reffered
            chart4.SeriesTemplate.View = checkSeries;
            chart4.SeriesTemplate.SeriesDataMember = "GridName";
            chart4.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart4.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart4.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var chart5 = (XRChart)report.FindControl("xrChart5", false);
            chart5.DataSource = ncheckchart5;//Method from documentation you reffered
            chart5.SeriesTemplate.View = checkSeries;
            chart5.SeriesTemplate.SeriesDataMember = "GridName";
            chart5.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart5.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart5.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var chart7 = (XRChart)report.FindControl("xrChart6", false);
            chart7.DataSource = ncheckchart7;//Method from documentation you reffered
            chart7.SeriesTemplate.View = checkSeries;
            chart7.SeriesTemplate.SeriesDataMember = "GridName";
            chart7.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart7.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart7.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var chart8 = (XRChart)report.FindControl("xrChart7", false);
            chart8.DataSource = ncheckchart8;//Method from documentation you reffered
            chart8.SeriesTemplate.View = checkSeries;
            chart8.SeriesTemplate.SeriesDataMember = "GridName";
            chart8.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart8.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart8.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var chart81 = (XRChart)report.FindControl("xrChart8", false);
            chart81.DataSource = ncheckchart9;//Method from documentation you reffered
            chart81.SeriesTemplate.View = checkSeries;
            chart81.SeriesTemplate.SeriesDataMember = "GridName";
            chart81.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart81.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart81.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var xrChart9 = (XRChart)report.FindControl("xrChart9", false);
            xrChart9.DataSource = ncheckchart10;//Method from documentation you reffered
            xrChart9.SeriesTemplate.View = checkSeries;
            xrChart9.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart9.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart9.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart9.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var xrChart10 = (XRChart)report.FindControl("xrChart10", false);
            xrChart10.DataSource = ncheckchart11;//Method from documentation you reffered
            xrChart10.SeriesTemplate.View = checkSeries;
            xrChart10.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart10.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart10.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart10.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart11 = (XRChart)report.FindControl("xrChart11", false);
            xrChart11.DataSource = ncheckchart13;//Method from documentation you reffered
            xrChart11.SeriesTemplate.View = checkSeries;
            xrChart11.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart11.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart11.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart11.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart12 = (XRChart)report.FindControl("xrChart12", false);
            xrChart12.DataSource = ncheckchart14;//Method from documentation you reffered
            xrChart12.SeriesTemplate.View = checkSeries;
            xrChart12.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart12.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart12.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart12.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart13 = (XRChart)report.FindControl("xrChart13", false);
            xrChart13.DataSource = ncheckchart15;//Method from documentation you reffered
            xrChart13.SeriesTemplate.View = checkSeries;
            xrChart13.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart13.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart13.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart13.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart14 = (XRChart)report.FindControl("xrChart14", false);
            xrChart14.DataSource = ncheckchart16;//Method from documentation you reffered
            xrChart14.SeriesTemplate.View = checkSeries;
            xrChart14.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart14.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart14.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart14.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart15 = (XRChart)report.FindControl("xrChart15", false);
            xrChart15.DataSource = ncheckchart17;//Method from documentation you reffered
            xrChart15.SeriesTemplate.View = checkSeries;
            xrChart15.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart15.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart15.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart15.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart16 = (XRChart)report.FindControl("xrChart16", false);
            xrChart16.DataSource = ncheckchart18;//Method from documentation you reffered
            xrChart16.SeriesTemplate.View = checkSeries;
            xrChart16.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart16.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart16.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart16.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart17 = (XRChart)report.FindControl("xrChart17", false);
            xrChart17.DataSource = ncheckchart19;//Method from documentation you reffered
            xrChart17.SeriesTemplate.View = checkSeries;
            xrChart17.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart17.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart17.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart17.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var xrChart18 = (XRChart)report.FindControl("xrChart18", false);
            xrChart18.DataSource = ncheckchart20;//Method from documentation you reffered
            xrChart18.SeriesTemplate.View = checkSeries;
            xrChart18.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart18.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart18.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart18.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart19 = (XRChart)report.FindControl("xrChart19", false);
            xrChart19.DataSource = ncheckchart21;//Method from documentation you reffered
            xrChart19.SeriesTemplate.View = checkSeries;
            xrChart19.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart19.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart19.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart19.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart20 = (XRChart)report.FindControl("xrChart20", false);
            xrChart20.DataSource = ncheckchart22;//Method from documentation you reffered
            xrChart20.SeriesTemplate.View = checkSeries;
            xrChart20.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart20.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart20.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart20.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart21 = (XRChart)report.FindControl("xrChart21", false);
            xrChart21.DataSource = ncheckchart23;//Method from documentation you reffered
            xrChart21.SeriesTemplate.View = checkSeries;
            xrChart21.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart21.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart21.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart21.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart22 = (XRChart)report.FindControl("xrChart22", false);
            xrChart22.DataSource = ncheckchart24;//Method from documentation you reffered
            xrChart22.SeriesTemplate.View = checkSeries;
            xrChart22.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart22.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart22.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart22.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart23 = (XRChart)report.FindControl("xrChart23", false);
            xrChart23.DataSource = ncheckchart25;//Method from documentation you reffered
            xrChart23.SeriesTemplate.View = checkSeries;
            xrChart23.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart23.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart23.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart23.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart24 = (XRChart)report.FindControl("xrChart24", false);
            xrChart24.DataSource = ncheckchart27;//Method from documentation you reffered
            xrChart24.SeriesTemplate.View = checkSeries;
            xrChart24.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart24.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart24.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart24.SeriesTemplate.ValueDataMembers.AddRange("Amount");
            //PdfExportOptions pdfOptions = report.ExportOptions.Pdf;
            //var xrChart25 = (XRChart)report.FindControl("xrChart25", false);
            //xrChart25.DataSource = ncheckchart27;//Method from documentation you reffered
            //xrChart25.SeriesTemplate.View = checkSeries;
            //xrChart25.SeriesTemplate.SeriesDataMember = "GridName";
            //xrChart25.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            //xrChart25.SeriesTemplate.ArgumentDataMember = "GroupText";
            //xrChart25.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            //pdfOptions.DocumentOptions.Application = "Fincheckup Application";
            //pdfOptions.DocumentOptions.Author = "Fincheckup Team";
            //pdfOptions.DocumentOptions.Keywords = "Fincheckup, Reporting, Finance";
            //pdfOptions.DocumentOptions.Producer = "";
            //pdfOptions.DocumentOptions.Subject = "Fincheckup Reporting";
            //pdfOptions.DocumentOptions.Title = "Finance Reporting";

            report.xrLblYear.Text = YearCurrent.ToString();
            report.xrlblYear1.Text = YearCurrent.ToString();
            report.xrlblYear3.Text = YearCurrent.ToString();
            report.xrlblYear1a1.Text = YearCurrent.ToString();
            report.xrlblYear1a3.Text = YearCurrent.ToString();
            report.xrlblYear1a31.Text = YearCurrent.ToString();
            report.xrlblYear1a3a.Text = YearCurrent.ToString();
            report.xrlblYear1a3bg.Text = YearCurrent.ToString();
            report.xrlblYear1a3ff.Text = YearCurrent.ToString();
            report.xrlblYear1a3h.Text = YearCurrent.ToString();
            report.xrlblYear1a3jk.Text = YearCurrent.ToString();
            report.xrlblYear1a3kk.Text = YearCurrent.ToString();
            report.xrlblYear1a3ll.Text = YearCurrent.ToString();
            report.xrlblYear1a3oo.Text = YearCurrent.ToString();
            report.xrlblYear1a3s.Text = YearCurrent.ToString();
            report.xrlblYear1a3t.Text = YearCurrent.ToString();
            report.xrlblYear1a3ww.Text = YearCurrent.ToString();
            report.xrlblYear1a3yy.Text = YearCurrent.ToString();
            report.xrlblYear311.Text = YearCurrent.ToString();
            report.xrlblYear32.Text = YearCurrent.ToString();
            report.xrlblYear31.Text = YearCurrent.ToString();
            report.xrlblYear4.Text = YearCurrent.ToString();
            report.xrlblYear5.Text = YearCurrent.ToString();
            report.xrlblYear6.Text = YearCurrent.ToString();
            report.xrlblYear7.Text = YearCurrent.ToString();
            report.xrlblYear8.Text = YearCurrent.ToString();
            report.xrlblYear9.Text = YearCurrent.ToString();

            report.xrlblYer21212a.Text = YearCurrenta.ToString();
            report.xrlblYer21212a1.Text = YearCurrenta.ToString();
            report.xrlblYer21212a2.Text = YearCurrenta.ToString();
            report.xrlblYer21212a3.Text = YearCurrenta.ToString();
            report.xrlblYer21212a5.Text = YearCurrenta.ToString();
            report.xrlblYer2212a.Text = YearCurrenta.ToString();
            report.xrlblYer2212a1.Text = YearCurrenta.ToString();
            report.xrlblYer2212a2.Text = YearCurrenta.ToString();
            report.xrlblYer2212a3.Text = YearCurrenta.ToString();
            report.xrlblYer2212a4.Text = YearCurrenta.ToString();
            report.xrlblYer2212a8.Text = YearCurrenta.ToString();
            report.xrlblYer2212a6.Text = YearCurrenta.ToString();
            report.xrlblYer2212a7.Text = YearCurrenta.ToString();
            report.xrlblYer2212a9.Text = YearCurrenta.ToString();
            report.xrlblYer221a.Text = YearCurrenta.ToString();
            report.xrlblYer221a1.Text = YearCurrenta.ToString();
            report.xrlblYer221a2.Text = YearCurrenta.ToString();
            report.xrlblYer221a3.Text = YearCurrenta.ToString();
            report.xrlblYer221a4.Text = YearCurrenta.ToString();
            report.xrlblYer221a5.Text = YearCurrenta.ToString();
            report.xrlblYer221a7.Text = YearCurrenta.ToString();
            report.xrlblYer221a8.Text = YearCurrenta.ToString();
            report.xrlblYer221a9.Text = YearCurrenta.ToString();
            report.xrlblYer221a11.Text = YearCurrenta.ToString();
            report.xrlblYer221a21.Text = YearCurrenta.ToString();
            report.xrlblYer221a33.Text = YearCurrenta.ToString();
            report.xrlblYer221a.Text = YearCurrenta.ToString();
            report.xrlblYer21212a5.Text = YearCurrenta.ToString();
            report.xrlblYer2212a5.Text = YearCurrenta.ToString();

            report.xr3Label113.Text = YearCurrentbTx.ToString();
            report.xr3Label123.Text = YearCurrentbTx.ToString();
            report.xr3Label126.Text = YearCurrentbTx.ToString();
            report.xr3Label127.Text = YearCurrentbTx.ToString();
            report.xr3Label128.Text = YearCurrentbTx.ToString();
            report.xr3Label131.Text = YearCurrentbTx.ToString();
            report.xr3Label132.Text = YearCurrentbTx.ToString();
            report.xr3Label133.Text = YearCurrentbTx.ToString();
            report.xr3Label138.Text = YearCurrentbTx.ToString();
            report.xr3Label136.Text = YearCurrentbTx.ToString();
            report.xr3Label137.Text = YearCurrentbTx.ToString();
            report.xr3Label141.Text = YearCurrentbTx.ToString();
            report.xr3Label142.Text = YearCurrentbTx.ToString();
            report.xr3Label143.Text = YearCurrentbTx.ToString();
            report.xr3Label144.Text = YearCurrentbTx.ToString();
            report.xr3Label145.Text = YearCurrentbTx.ToString();
            report.xr3Label146.Text = YearCurrentbTx.ToString();
            report.xr3Label147.Text = YearCurrentbTx.ToString();
            report.xr3Label148.Text = YearCurrentbTx.ToString();
            report.xr3Label149.Text = YearCurrentbTx.ToString();
            report.xr3Label150.Text = YearCurrentbTx.ToString();
            report.xr3Label151.Text = YearCurrentbTx.ToString();
            report.xr3Label152.Text = YearCurrentbTx.ToString();
            report.xr3Label153.Text = YearCurrentbTx.ToString();
            report.xr3Label154.Text = YearCurrentbTx.ToString();
            report.xr3Label155.Text = YearCurrentbTx.ToString();
            report.xr3Label157.Text = YearCurrentbTx.ToString();

            return report;

        }
        public static FinansRaporuc getReportc(long companyID, List<int> nyear, string nacceco, long usride_, List<int> nyearChkList, CompanyReportView grview, int chkMizan = 0)
        {
            Companies.DataReportMainNace(nacceco, companyID); grview = Companies.Get_CompanyReportView(companyID);
            YearCurrent = nyearChkList[0];
            YearCurrenta = nyearChkList[1];
            YearCurrentb = nyearChkList[2];
            YearCurrentc = nyearChkList[3];
            setReportZone(companyID, nyear, chkMizan);

            int chk = Companies.DataReportMainLastMonth(YearCurrentc, companyID);

            YearCurrentcTx = YearCurrentc.ToString() + " - " + chk.ToString();

            string metin = string.Empty;
            int maxyearTcmb = Companies.Get_LastTCMBReportYear();
            List<int> nyearchk = new List<int>();
            nyearchk.Add(YearCurrent);

            if (nyearChkList.Contains(maxyearTcmb))
            {
                metin = "<html><body>" + RepText1(nyearChkList, 4, nacceco);
                metin += "<br>" + RepText5(companyID, YearCurrent);
            }
            else
            {
                metin = RepText1(nyearChkList, 2, nacceco);
                metin += "<br>" + RepText4(companyID, YearCurrent);
            }
            metin += "</body></html>";



            ncheck = MainDash.DataReportMainQnbT(companyID);

            ncheck1 = ncheck.Where(x => x.MainTypeID == 1).ToList();

            ncheck3 = ncheck.Where(x => x.MainTypeID == 2).FirstOrDefault();
            //ncheck1 = reportZone.getReverse(ncheck1, ncheck3.Amount);


            ncheck5 = ncheck.Where(x => x.MainTypeID == 3).ToList();
            ncheck41 = ncheck.Where(x => x.MainTypeID == 4 && x.TypeID == 471).FirstOrDefault();
            ncheck43 = ncheck.Where(x => x.MainTypeID == 4 && x.TypeID == 473).FirstOrDefault();
            //ncheck3 = reportZone.getReverseSingle(ncheck3, ncheck43.Amount);
            //ncheck41 = reportZone.getReverseSingle(ncheck41, ncheck43.Amount);
            //ncheck5 = reportZone.getReverse(ncheck5, ncheck41.Amount);

            // 2.Sayfa

            ncheck7 = ncheck.Where(x => x.MainTypeID == 5).ToList();
            ncheck9 = ncheck.Where(x => x.MainTypeID == 7).ToList();
            ncheck11 = ncheck.Where(x => x.MainTypeID == 9).ToList();
            ncheck7b = ncheck.Where(x => x.MainTypeID == 6).FirstOrDefault();
            ncheck9b = ncheck.Where(x => x.MainTypeID == 8).FirstOrDefault();
            ncheck11b = ncheck.Where(x => x.TypeID == 951).FirstOrDefault();

            ncheck11c = ncheck.Where(x => x.TypeID == 953).FirstOrDefault();
            ncheck11d = ncheck.Where(x => x.TypeID == 955).FirstOrDefault();

            //ncheck7 = reportZone.getReverse(ncheck7, ncheck7b.Amount);
            //ncheck9 = reportZone.getReverse(ncheck9, ncheck9b.Amount);
            //ncheck11 = reportZone.getReverse(ncheck11, ncheck11b.Amount);

            //ncheck7b = reportZone.getReverseSingle(ncheck7b, ncheck11d.Amount);
            //ncheck9b = reportZone.getReverseSingle(ncheck9b, ncheck11d.Amount);
            //ncheck11b = reportZone.getReverseSingle(ncheck11b, ncheck11d.Amount);
            //ncheck11c = reportZone.getReverseSingle(ncheck11c, ncheck11d.Amount);


            //gelirler
            ncheckGelir = MainDash.DataReportMainQnbGelirT(companyID);
            ncheck13 = ncheckGelir.Where(x => x.MainTypeID == 13).ToList();
            ncheck13brut = ncheckGelir.Where(x => x.TypeID == 109).FirstOrDefault();

            ncheck15 = ncheckGelir.Where(x => x.TypeID == 111).FirstOrDefault();
            ncheck15a = ncheckGelir.Where(x => x.TypeID == 113).FirstOrDefault();

            ncheck17 = ncheckGelir.Where(x => x.TypeID == 115).FirstOrDefault();
            ncheck17a = ncheckGelir.Where(x => x.TypeID == 117).FirstOrDefault();

            ncheck13Check = ncheckGelir.Where(x => x.MainTypeID == 23).ToList();

            ncheck19 = ncheckGelir.Where(x => x.TypeID == 125).FirstOrDefault();

            ncheck23 = ncheckGelir.Where(x => x.MainTypeID == 27).ToList();


            ncheck25 = ncheckGelir.Where(x => x.TypeID == 133).FirstOrDefault();

            ncheck27 = ncheckGelir.Where(x => x.TypeID == 135).FirstOrDefault();

            //var tst = ncheck13.Where(x => x.MainTypeID == 13 && x.TypeID == 101).FirstOrDefault();
            //ncheck13 = reportZone.getReverse(ncheck13, ncheck25.Amount);
            //ncheck13brut = reportZone.getReverseSingle(ncheck13brut, ncheck25.Amount);
            //ncheck15 = reportZone.getReverseSingle(ncheck15, ncheck25.Amount);
            //ncheck15a = reportZone.getReverseSingle(ncheck15a, ncheck25.Amount);
            //ncheck17 = reportZone.getReverseSingle(ncheck17, ncheck25.Amount);
            //ncheck17a = reportZone.getReverseSingle(ncheck17a, ncheck25.Amount);

            //tst = reportZone.getReverseSingle(tst, tst.Amount);

            //ncheck13Check = reportZone.getReverse(ncheck13Check, ncheck25.Amount);

            //ncheck19 = reportZone.getReverseSingle(ncheck19, ncheck25.Amount);
            //ncheck23 = reportZone.getReverse(ncheck23, ncheck25.Amount);

            //ncheck25 = reportZone.getReverseSingle(ncheck25, ncheck25.Amount);
            // chartlar
            _ncheckzone = MainDash.DataReportMain1DynamicMain(companyID);
            ncheckchartzone = MainDash.DataReportMain1DynamicMainChart(companyID);
            _ncheck1 = _ncheckzone.Where(x => x.TypeID == 101).ToList();
            ncheckchart1 = ncheckchartzone.Where(x => x.TypeID == 101).ToList();

            _ncheck1.ToList().ForEach(i => i.Amount = i.Amount / 1000000);
            _ncheck1.ToList().ForEach(i => i.Amount1 = i.Amount1 / 1000000);
            _ncheck1.ToList().ForEach(i => i.Amount2 = i.Amount2 / 1000000);
            _ncheck1.ToList().ForEach(i => i.Amount3 = i.Amount3 / 1000000);
            _ncheck1.ToList().ForEach(i => i.Amount4 = i.Amount4 / 1000000);
            ncheckchart1.ToList().ForEach(i => i.Amount = i.Amount / 1000000);

            _ncheck2 = _ncheckzone.Where(x => x.TypeID == 103).ToList();
            ncheckchart2 = ncheckchartzone.Where(x => x.TypeID == 103).ToList();

            _ncheck3 = _ncheckzone.Where(x => x.TypeID == 105).ToList();
            ncheckchart3 = ncheckchartzone.Where(x => x.TypeID == 105).ToList();

            _ncheck4 = _ncheckzone.Where(x => x.TypeID == 104).ToList();
            ncheckchart4 = ncheckchartzone.Where(x => x.TypeID == 104).ToList();

            _ncheck5 = _ncheckzone.Where(x => x.TypeID == 107).ToList();
            ncheckchart5 = ncheckchartzone.Where(x => x.TypeID == 107).ToList();

            _ncheck7 = _ncheckzone.Where(x => x.TypeID == 125).ToList();
            ncheckchart7 = ncheckchartzone.Where(x => x.TypeID == 125).ToList();

            _ncheck8 = _ncheckzone.Where(x => x.TypeID == 109).ToList();
            ncheckchart8 = ncheckchartzone.Where(x => x.TypeID == 109).ToList();

            _ncheck9 = _ncheckzone.Where(x => x.TypeID == 111).ToList();
            ncheckchart9 = ncheckchartzone.Where(x => x.TypeID == 111).ToList();

            _ncheck10 = _ncheckzone.Where(x => x.TypeID == 113).ToList();
            ncheckchart10 = ncheckchartzone.Where(x => x.TypeID == 113).ToList();

            _ncheck11 = _ncheckzone.Where(x => x.TypeID == 115).ToList();
            ncheckchart11 = ncheckchartzone.Where(x => x.TypeID == 115).ToList(); 
        

            _ncheck13 = _ncheckzone.Where(x => x.TypeID == 117).ToList();
            ncheckchart13 = ncheckchartzone.Where(x => x.TypeID == 117).ToList();

            _ncheck14 = _ncheckzone.Where(x => x.TypeID == 119).ToList();
            ncheckchart14 = ncheckchartzone.Where(x => x.TypeID == 119).ToList();

            _ncheck15 = _ncheckzone.Where(x => x.TypeID == 121).ToList();
            ncheckchart15 = ncheckchartzone.Where(x => x.TypeID == 121).ToList();

            _ncheck16 = _ncheckzone.Where(x => x.TypeID == 123).ToList();
            ncheckchart16 = ncheckchartzone.Where(x => x.TypeID == 123).ToList();
            //125
            _ncheck17 = _ncheckzone.Where(x => x.TypeID == 127).ToList();
            ncheckchart17 = ncheckchartzone.Where(x => x.TypeID == 127).ToList();

            _ncheck18 = _ncheckzone.Where(x => x.TypeID == 129).ToList();
            ncheckchart18 = ncheckchartzone.Where(x => x.TypeID == 129).ToList();

            _ncheck18.ToList().ForEach(i => i.Amount = i.Amount / 1000000); _ncheck18.ToList().ForEach(i => i.Amount1 = i.Amount1 / 1000000);
            _ncheck18.ToList().ForEach(i => i.Amount2 = i.Amount2 / 1000000);
            _ncheck18.ToList().ForEach(i => i.Amount3 = i.Amount3 / 1000000);
            _ncheck18.ToList().ForEach(i => i.Amount4 = i.Amount4 / 1000000);
            ncheckchart18.ToList().ForEach(i => i.Amount = i.Amount / 1000000);
            _ncheck19 = _ncheckzone.Where(x => x.TypeID == 131).ToList();
            ncheckchart19 = ncheckchartzone.Where(x => x.TypeID == 131).ToList();

            _ncheck20 = _ncheckzone.Where(x => x.TypeID == 133).ToList();
            ncheckchart20 = ncheckchartzone.Where(x => x.TypeID == 133).ToList();

            _ncheck21 = _ncheckzone.Where(x => x.TypeID == 135).ToList();
            ncheckchart21 = ncheckchartzone.Where(x => x.TypeID == 135).ToList();

            _ncheck22 = _ncheckzone.Where(x => x.TypeID == 137).ToList();
            ncheckchart22 = ncheckchartzone.Where(x => x.TypeID == 137).ToList();

            _ncheck23 = _ncheckzone.Where(x => x.TypeID == 139).ToList();
            ncheckchart23 = ncheckchartzone.Where(x => x.TypeID == 139).ToList();
            _ncheck23 = _ncheck23.Select(c => { c.Amount = float.Parse("365") / c.Amount; return c; }).ToList();
            _ncheck23 = _ncheck23.Select(c => { c.Amount1 = float.Parse("365") / c.Amount1; return c; }).ToList();
            _ncheck23 = _ncheck23.Select(c => { c.Amount2 = float.Parse("365") / c.Amount2; return c; }).ToList();
            _ncheck23 = _ncheck23.Select(c => { c.Amount3 = float.Parse("365") / c.Amount3; return c; }).ToList();
            ncheckchart23 = ncheckchart23.Select(c => { c.Amount = float.Parse("365") / c.Amount; return c; }).ToList();

            _ncheck24 = _ncheckzone.Where(x => x.TypeID == 141).ToList();
            ncheckchart24 = ncheckchartzone.Where(x => x.TypeID == 141).ToList();

            _ncheck25 = _ncheckzone.Where(x => x.TypeID == 143).ToList();
            ncheckchart25 = ncheckchartzone.Where(x => x.TypeID == 143).ToList();

            _ncheck27 = _ncheckzone.Where(x => x.TypeID == 145).ToList();
            ncheckchart27 = ncheckchartzone.Where(x => x.TypeID == 145).ToList();
            _ncheck27.ToList().ForEach(i => i.Amount = i.Amount / 1000000); _ncheck27.ToList().ForEach(i => i.Amount1 = i.Amount1 / 1000000);
            _ncheck27.ToList().ForEach(i => i.Amount2 = i.Amount2 / 1000000);
            _ncheck27.ToList().ForEach(i => i.Amount3 = i.Amount3 / 1000000);
            _ncheck27.ToList().ForEach(i => i.Amount4 = i.Amount4 / 1000000);
            ncheckchart27.ToList().ForEach(i => i.Amount = i.Amount / 1000000);
            UserID = usride_;

            FinansRaporuc report = new FinansRaporuc();
            report.xr7CompanyName.Text = grview.CompanyName;
            report.xr7NaceKod.Text = grview.Code;
            report.xrSektorAna.Text = grview.MainDescription;
            report.xrSektorDetay.Text = grview.Description;


 

            report.xrRichTxtMeitn.Html = metin;    

            ObjectDataSource objectDataSourceChrt1 = new ObjectDataSource();
            objectDataSourceChrt1.Name = "DataViewer";
            objectDataSourceChrt1.DataSource = _ncheck1;
            objectDataSourceChrt1.Fill();

            ObjectDataSource objectDataSourceChrt2 = new ObjectDataSource();
            objectDataSourceChrt2.Name = "DataViewerz";
            objectDataSourceChrt2.DataSource = _ncheck2;
            objectDataSourceChrt2.Fill();

            ObjectDataSource objectDataSourceChrt3 = new ObjectDataSource();
            objectDataSourceChrt3.Name = "DataViewerzz";
            objectDataSourceChrt3.DataSource = _ncheck3;
            objectDataSourceChrt3.Fill();

            ObjectDataSource objectDataSourceChrt4 = new ObjectDataSource();
            objectDataSourceChrt4.Name = "DataViewer4zz1";
            objectDataSourceChrt4.DataSource = _ncheck4;
            objectDataSourceChrt4.Fill();

            ObjectDataSource objectDataSourceChrt5 = new ObjectDataSource();
            objectDataSourceChrt5.Name = "DataViewersszz1";
            objectDataSourceChrt5.DataSource = _ncheck5;
            objectDataSourceChrt5.Fill();

            ObjectDataSource objectDataSource511 = new ObjectDataSource();
            objectDataSource511.Name = "DataViewersszz1";
            objectDataSource511.DataSource = ncheck41;
            objectDataSource511.Fill();


            ObjectDataSource objectDataSourceChrt7 = new ObjectDataSource();
            objectDataSourceChrt7.Name = "Dat5aViewerzz1";
            objectDataSourceChrt7.DataSource = _ncheck7;
            objectDataSourceChrt7.Fill();

            ObjectDataSource objectDataSourceChrt8 = new ObjectDataSource();
            objectDataSourceChrt8.Name = "DataVie8werzz1";
            objectDataSourceChrt8.DataSource = _ncheck8;
            objectDataSourceChrt8.Fill();


            ObjectDataSource objectDataSourceChrt9 = new ObjectDataSource();
            objectDataSourceChrt9.Name = "DataView7erzz1";
            objectDataSourceChrt9.DataSource = _ncheck9;
            objectDataSourceChrt9.Fill();


            ObjectDataSource objectDataSourceChrt10 = new ObjectDataSource();
            objectDataSourceChrt10.Name = "DataViewe3rzz1";
            objectDataSourceChrt10.DataSource = _ncheck10;
            objectDataSourceChrt10.Fill();


            ObjectDataSource objectDataSourceChrt11 = new ObjectDataSource();
            objectDataSourceChrt11.Name = "DataVie4werzz1";
            objectDataSourceChrt11.DataSource = _ncheck11;
            objectDataSourceChrt11.Fill();

            ObjectDataSource objectDataSourceChrt13 = new ObjectDataSource();
            objectDataSourceChrt13.Name = "DataViewe5rzz1";
            objectDataSourceChrt13.DataSource = _ncheck13;
            objectDataSourceChrt13.Fill();

            ObjectDataSource objectDataSourceChrt14 = new ObjectDataSource();
            objectDataSourceChrt14.Name = "DataVie6werzz1";
            objectDataSourceChrt14.DataSource = _ncheck14;
            objectDataSourceChrt14.Fill();

            ObjectDataSource objectDataSourceChrt15 = new ObjectDataSource();
            objectDataSourceChrt15.Name = "DataViewe7rzz1";
            objectDataSourceChrt15.DataSource = _ncheck15;
            objectDataSourceChrt15.Fill();


            ObjectDataSource objectDataSourceChrt16 = new ObjectDataSource();
            objectDataSourceChrt16.Name = "Data5Viewerzz1";
            objectDataSourceChrt16.DataSource = _ncheck16;
            objectDataSourceChrt16.Fill();


            ObjectDataSource objectDataSourceChrt17 = new ObjectDataSource();
            objectDataSourceChrt17.Name = "DataViewerz1z1";
            objectDataSourceChrt17.DataSource = _ncheck17;
            objectDataSourceChrt17.Fill();



            ObjectDataSource objectDataSourceChrt18 = new ObjectDataSource();
            objectDataSourceChrt18.Name = "DataViewer2zz1";
            objectDataSourceChrt18.DataSource = _ncheck18;
            objectDataSourceChrt18.Fill();

            ObjectDataSource objectDataSourceChrt19 = new ObjectDataSource();
            objectDataSourceChrt19.Name = "DataViewer3zz1";
            objectDataSourceChrt19.DataSource = _ncheck19;
            objectDataSourceChrt19.Fill();



            ObjectDataSource objectDataSourceChrt20 = new ObjectDataSource();
            objectDataSourceChrt20.Name = "DataViewer4zz1";
            objectDataSourceChrt20.DataSource = _ncheck20;
            objectDataSourceChrt20.Fill();


            ObjectDataSource objectDataSourceChrt21 = new ObjectDataSource();
            objectDataSourceChrt21.Name = "DataViewer5zz1";
            objectDataSourceChrt21.DataSource = _ncheck21;
            objectDataSourceChrt21.Fill();

            ObjectDataSource objectDataSourceChrt22 = new ObjectDataSource();
            objectDataSourceChrt22.Name = "DataViewerz6z1";
            objectDataSourceChrt22.DataSource = _ncheck22;
            objectDataSourceChrt22.Fill();


            ObjectDataSource objectDataSourceChrt23 = new ObjectDataSource();
            objectDataSourceChrt23.Name = "DataViewer7zz1";
            objectDataSourceChrt23.DataSource = _ncheck23;
            objectDataSourceChrt23.Fill();


            ObjectDataSource objectDataSourceChrt24 = new ObjectDataSource();
            objectDataSourceChrt24.Name = "DataViewe8rzz1";
            objectDataSourceChrt24.DataSource = _ncheck24;
            objectDataSourceChrt24.Fill();

            ObjectDataSource objectDataSourceChrt25 = new ObjectDataSource();
            objectDataSourceChrt25.Name = "DataViewer9zz1";
            objectDataSourceChrt25.DataSource = _ncheck25;
            objectDataSourceChrt25.Fill();


            ObjectDataSource objectDataSourceChrt27 = new ObjectDataSource();
            objectDataSourceChrt27.Name = "DataVie5werzz1";
            objectDataSourceChrt27.DataSource = _ncheck27;
            objectDataSourceChrt27.Fill();

            ObjectDataSource objectDataSource = new ObjectDataSource();
            objectDataSource.Name = "DataViewer1";
            objectDataSource.DataSource = ncheck1;

            objectDataSource.Fill();

            ObjectDataSource objectDataSource1 = new ObjectDataSource();
            objectDataSource1.Name = "DataViewer2";
            objectDataSource1.DataSource = ncheck3;

            objectDataSource1.Fill();

            ObjectDataSource objectDataSource3 = new ObjectDataSource();
            objectDataSource3.Name = "DataViewer3";
            objectDataSource3.DataSource = ncheck5;

            objectDataSource3.Fill();

            //ObjectDataSource objectDataSource5 = new ObjectDataSource();
            //objectDataSource5.Name = "DataViewer4";
            //objectDataSource5.DataSource = ncheck41;

            //objectDataSource5.Fill();


            ObjectDataSource objectDataSource7 = new ObjectDataSource();
            objectDataSource7.Name = "DataViewer5";
            objectDataSource7.DataSource = ncheck43;

            objectDataSource7.Fill();

            ObjectDataSource objectDataSource9 = new ObjectDataSource();
            objectDataSource9.Name = "DataViewer6";
            objectDataSource9.DataSource = ncheck7;

            objectDataSource9.Fill();


            ObjectDataSource objectDataSource9b = new ObjectDataSource();
            objectDataSource9b.Name = "DataViewer7";
            objectDataSource9b.DataSource = ncheck7b;

            objectDataSource9b.Fill();

            ObjectDataSource objectDataSource11 = new ObjectDataSource();
            objectDataSource11.Name = "DataViewer8";
            objectDataSource11.DataSource = ncheck9;

            objectDataSource11.Fill();


            ObjectDataSource objectDataSource11b = new ObjectDataSource();
            objectDataSource11b.Name = "DataViewer9";
            objectDataSource11b.DataSource = ncheck9b;

            objectDataSource11b.Fill();

            ObjectDataSource objectDataSource13 = new ObjectDataSource();
            objectDataSource13.Name = "DataViewer10";
            objectDataSource13.DataSource = ncheck11;

            objectDataSource13.Fill();


            ObjectDataSource objectDataSource13b = new ObjectDataSource();
            objectDataSource13b.Name = "DataViewer11";
            objectDataSource13b.DataSource = ncheck11b;

            objectDataSource13b.Fill();

            ObjectDataSource objectDataSource13b1 = new ObjectDataSource();
            objectDataSource13b1.Name = "DataViewer12";
            objectDataSource13b1.DataSource = ncheck11c;

            objectDataSource13b1.Fill();

            ObjectDataSource objectDataSource13b3 = new ObjectDataSource();
            objectDataSource13b3.Name = "DataViewer13";
            objectDataSource13b3.DataSource = ncheck11d;

            objectDataSource13b3.Fill();
            // Gelirler

            ObjectDataSource objectDataSource15 = new ObjectDataSource();
            objectDataSource15.Name = "DataViewer14";
            objectDataSource15.DataSource = ncheck13;

            objectDataSource15.Fill();

            ObjectDataSource objectDataSource15a = new ObjectDataSource();
            objectDataSource15a.Name = "DataViewer15";
            objectDataSource15a.DataSource = ncheck13brut;

            objectDataSource15a.Fill();

            ObjectDataSource objectDataSource17 = new ObjectDataSource();
            objectDataSource17.Name = "DataViewer16";
            objectDataSource17.DataSource = ncheck15;

            objectDataSource17.Fill();

            ObjectDataSource objectDataSource17a = new ObjectDataSource();
            objectDataSource17a.Name = "DataViewer17";
            objectDataSource17a.DataSource = ncheck15a;

            objectDataSource17a.Fill();


            ObjectDataSource objectDataSource19 = new ObjectDataSource();
            objectDataSource19.Name = "DataViewer18";
            objectDataSource19.DataSource = ncheck17;

            objectDataSource19.Fill();

            ObjectDataSource objectDataSource19a = new ObjectDataSource();
            objectDataSource19a.Name = "DataViewer19";
            objectDataSource19a.DataSource = ncheck17a;

            objectDataSource19a.Fill();

            ObjectDataSource objectDataSource13check = new ObjectDataSource();
            objectDataSource13check.Name = "DataViewer20";
            objectDataSource13check.DataSource = ncheck13Check;

            objectDataSource13check.Fill();

            ObjectDataSource objectDataSource21 = new ObjectDataSource();
            objectDataSource21.Name = "DataViewer21";
            objectDataSource21.DataSource = ncheck19;

            objectDataSource21.Fill();

            ObjectDataSource objectDataSource23 = new ObjectDataSource();
            objectDataSource23.Name = "DataViewer22";
            objectDataSource23.DataSource = ncheck21;

            objectDataSource23.Fill();

            ObjectDataSource objectDataSource25 = new ObjectDataSource();
            objectDataSource25.Name = "DataViewer23";
            objectDataSource25.DataSource = ncheck23;

            objectDataSource25.Fill();

            ObjectDataSource objectDataSource27 = new ObjectDataSource();
            objectDataSource27.Name = "DataViewer24";
            objectDataSource27.DataSource = ncheck25;

            objectDataSource27.Fill();
            checkSeries = new LineSeriesView();


            ObjectDataSource objectDataSource29 = new ObjectDataSource();
            objectDataSource29.Name = "DataViewer25";
            objectDataSource29.DataSource = ncheck27;
            objectDataSource29.Fill();

            DetailReportBand detailReport = report.Bands["DetailReport"] as DetailReportBand;
            detailReport.DataSource = objectDataSource;

            DetailReportBand detailReport1 = report.Bands["DetailReport2"] as DetailReportBand;
            detailReport1.DataSource = objectDataSource1;

            DetailReportBand detailReport3 = report.Bands["DetailReport1"] as DetailReportBand;
            detailReport3.DataSource = objectDataSource3;

            DetailReportBand detailReport5 = report.Bands["DetailReport3"] as DetailReportBand;
            detailReport5.DataSource = objectDataSource511;

            DetailReportBand detailReport7 = report.Bands["DetailReport4"] as DetailReportBand;
            detailReport7.DataSource = objectDataSource7;

            DetailReportBand detailReport9 = report.Bands["DetailReport6"] as DetailReportBand;
            detailReport9.DataSource = objectDataSource9;

            DetailReportBand detailReport9b = report.Bands["DetailReport7"] as DetailReportBand;
            detailReport9b.DataSource = objectDataSource9b;

            DetailReportBand detailReport11 = report.Bands["DetailReport8"] as DetailReportBand;
            detailReport11.DataSource = objectDataSource11;

            DetailReportBand detailReport11b = report.Bands["DetailReport9"] as DetailReportBand;
            detailReport11b.DataSource = objectDataSource11b;

            DetailReportBand detailReport13 = report.Bands["DetailReport10"] as DetailReportBand;
            detailReport13.DataSource = objectDataSource13;

            DetailReportBand detailReport13b = report.Bands["DetailReport11"] as DetailReportBand;
            detailReport13b.DataSource = objectDataSource13b;

            DetailReportBand detailReport13b1 = report.Bands["DetailReport12"] as DetailReportBand;
            detailReport13b1.DataSource = objectDataSource13b1;

            DetailReportBand detailReport13b2 = report.Bands["DetailReport13"] as DetailReportBand;
            detailReport13b2.DataSource = objectDataSource13b3;


            DetailReportBand detailReport15 = report.Bands["DetailReport14"] as DetailReportBand;
            detailReport15.DataSource = objectDataSource15;


            DetailReportBand detailReport15a = report.Bands["DetailReport15"] as DetailReportBand;
            detailReport15a.DataSource = objectDataSource15a;


            DetailReportBand detailReport17 = report.Bands["DetailReport16"] as DetailReportBand;
            detailReport17.DataSource = objectDataSource17;

            DetailReportBand detailReport17a = report.Bands["DetailReport17"] as DetailReportBand;
            detailReport17a.DataSource = objectDataSource17a;


            DetailReportBand detailReport19 = report.Bands["DetailReport18"] as DetailReportBand;
            detailReport19.DataSource = objectDataSource19;


            DetailReportBand detailReport19a = report.Bands["DetailReport19"] as DetailReportBand;
            detailReport19a.DataSource = objectDataSource19a;



            DetailReportBand detailReport13Check = report.Bands["DetailReport20"] as DetailReportBand;
            detailReport13Check.DataSource = objectDataSource13check;


            DetailReportBand detailReport21 = report.Bands["DetailReport21"] as DetailReportBand;
            detailReport21.DataSource = objectDataSource21;



            DetailReportBand detailReport25 = report.Bands["DetailReport23"] as DetailReportBand;
            detailReport25.DataSource = objectDataSource25;


            DetailReportBand detailReport27 = report.Bands["DetailReport24"] as DetailReportBand;
            detailReport27.DataSource = objectDataSource27;


            DetailReportBand detailReport29 = report.Bands["DetailReport25"] as DetailReportBand;
            detailReport29.DataSource = objectDataSource29;

            DetailReportBand detailReport22 = report.Bands["DetailReport22"] as DetailReportBand;
            detailReport22.DataSource = objectDataSourceChrt1;

            DetailReportBand detailReport30 = report.Bands["DetailReport29"] as DetailReportBand;
            detailReport30.DataSource = objectDataSourceChrt2;

            DetailReportBand detailReport31 = report.Bands["DetailReport31"] as DetailReportBand;
            detailReport31.DataSource = objectDataSourceChrt3;

            DetailReportBand detailReport33 = report.Bands["DetailReport33"] as DetailReportBand;
            detailReport33.DataSource = objectDataSourceChrt4;


            DetailReportBand detailReport35 = report.Bands["DetailReport35"] as DetailReportBand;
            detailReport35.DataSource = objectDataSourceChrt5;


            DetailReportBand detailReport37 = report.Bands["DetailReport37"] as DetailReportBand;
            detailReport37.DataSource = objectDataSourceChrt7;



            DetailReportBand detailReport39 = report.Bands["DetailReport39"] as DetailReportBand;
            detailReport39.DataSource = objectDataSourceChrt8;



            DetailReportBand detailReport41 = report.Bands["DetailReport41"] as DetailReportBand;
            detailReport41.DataSource = objectDataSourceChrt9;


            DetailReportBand detailReport43 = report.Bands["DetailReport43"] as DetailReportBand;
            detailReport43.DataSource = objectDataSourceChrt10;


            DetailReportBand detailReport45 = report.Bands["DetailReport45"] as DetailReportBand;
            detailReport45.DataSource = objectDataSourceChrt11;


            DetailReportBand detailReport47 = report.Bands["DetailReport47"] as DetailReportBand;
            detailReport47.DataSource = objectDataSourceChrt13;


            DetailReportBand detailReport49 = report.Bands["DetailReport49"] as DetailReportBand;
            detailReport49.DataSource = objectDataSourceChrt14;


            DetailReportBand detailReport51 = report.Bands["DetailReport51"] as DetailReportBand;
            detailReport51.DataSource = objectDataSourceChrt15;


            DetailReportBand detailReport53 = report.Bands["DetailReport53"] as DetailReportBand;
            detailReport53.DataSource = objectDataSourceChrt16;


            DetailReportBand detailReport55 = report.Bands["DetailReport55"] as DetailReportBand;
            detailReport55.DataSource = objectDataSourceChrt17;


            DetailReportBand detailReport57 = report.Bands["DetailReport57"] as DetailReportBand;
            detailReport57.DataSource = objectDataSourceChrt18;


            DetailReportBand detailReport59 = report.Bands["DetailReport59"] as DetailReportBand;
            detailReport59.DataSource = objectDataSourceChrt19;

            DetailReportBand detailReport61 = report.Bands["DetailReport63"] as DetailReportBand;
            detailReport61.DataSource = objectDataSourceChrt20;


            DetailReportBand detailReport63 = report.Bands["DetailReport65"] as DetailReportBand;
            detailReport63.DataSource = objectDataSourceChrt21;

            DetailReportBand detailReport65 = report.Bands["DetailReport67"] as DetailReportBand;
            detailReport65.DataSource = objectDataSourceChrt22;


            DetailReportBand detailReport67 = report.Bands["DetailReport69"] as DetailReportBand;
            detailReport67.DataSource = objectDataSourceChrt23;


            DetailReportBand detailReport69 = report.Bands["DetailReport71"] as DetailReportBand;
            detailReport69.DataSource = objectDataSourceChrt24;


            DetailReportBand detailReport71 = report.Bands["DetailReport73"] as DetailReportBand;
            detailReport71.DataSource = objectDataSourceChrt25;

            DetailReportBand detailReport715 = report.Bands["DetailReport75"] as DetailReportBand;
            detailReport715.DataSource = objectDataSourceChrt27;
            //DetailReportBand detailReport73 = report.Bands["DetailReport73"] as DetailReportBand;
            //detailReport73.DataSource = objectDataSourceChrt27;


            //DetailReportBand detailReport75 = report.Bands["DetailReport75"] as DetailReportBand;
            //detailReport75.DataSource = objectDataSourceChrt25;

            var chart1 = (XRChart)report.FindControl("xrChart1", false);

            chart1.DataSource = ncheckchart1;//Method from documentation you reffered
            chart1.SeriesTemplate.View = checkSeries;
            chart1.SeriesTemplate.SeriesDataMember = "GridName";
            chart1.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart1.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart1.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var chart2 = (XRChart)report.FindControl("xrChart2", false);

            chart2.DataSource = ncheckchart2;//Method from documentation you reffered
            chart2.SeriesTemplate.View = checkSeries;
            chart2.SeriesTemplate.SeriesDataMember = "GridName";
            chart2.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart2.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart2.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var chart3 = (XRChart)report.FindControl("xrChart3", false);

            chart3.DataSource = ncheckchart3;//Method from documentation you reffered
            chart3.SeriesTemplate.View = checkSeries;
            chart3.SeriesTemplate.SeriesDataMember = "GridName";
            chart3.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart3.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart3.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var chart4 = (XRChart)report.FindControl("xrChart4", false);

            chart4.DataSource = ncheckchart4;//Method from documentation you reffered
            chart4.SeriesTemplate.View = checkSeries;
            chart4.SeriesTemplate.SeriesDataMember = "GridName";
            chart4.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart4.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart4.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var chart5 = (XRChart)report.FindControl("xrChart5", false);
            chart5.DataSource = ncheckchart5;//Method from documentation you reffered
            chart5.SeriesTemplate.View = checkSeries;
            chart5.SeriesTemplate.SeriesDataMember = "GridName";
            chart5.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart5.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart5.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var chart7 = (XRChart)report.FindControl("xrChart6", false);
            chart7.DataSource = ncheckchart7;//Method from documentation you reffered
            chart7.SeriesTemplate.View = checkSeries;
            chart7.SeriesTemplate.SeriesDataMember = "GridName";
            chart7.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart7.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart7.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var chart8 = (XRChart)report.FindControl("xrChart7", false);
            chart8.DataSource = ncheckchart8;//Method from documentation you reffered
            chart8.SeriesTemplate.View = checkSeries;
            chart8.SeriesTemplate.SeriesDataMember = "GridName";
            chart8.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart8.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart8.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var chart81 = (XRChart)report.FindControl("xrChart8", false);
            chart81.DataSource = ncheckchart9;//Method from documentation you reffered
            chart81.SeriesTemplate.View = checkSeries;
            chart81.SeriesTemplate.SeriesDataMember = "GridName";
            chart81.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            chart81.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart81.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var xrChart9 = (XRChart)report.FindControl("xrChart9", false);
            xrChart9.DataSource = ncheckchart10;//Method from documentation you reffered
            xrChart9.SeriesTemplate.View = checkSeries;
            xrChart9.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart9.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart9.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart9.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var xrChart10 = (XRChart)report.FindControl("xrChart10", false);
            xrChart10.DataSource = ncheckchart11;//Method from documentation you reffered
            xrChart10.SeriesTemplate.View = checkSeries;
            xrChart10.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart10.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart10.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart10.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart11 = (XRChart)report.FindControl("xrChart11", false);
            xrChart11.DataSource = ncheckchart13;//Method from documentation you reffered
            xrChart11.SeriesTemplate.View = checkSeries;
            xrChart11.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart11.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart11.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart11.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart12 = (XRChart)report.FindControl("xrChart12", false);
            xrChart12.DataSource = ncheckchart14;//Method from documentation you reffered
            xrChart12.SeriesTemplate.View = checkSeries;
            xrChart12.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart12.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart12.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart12.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart13 = (XRChart)report.FindControl("xrChart13", false);
            xrChart13.DataSource = ncheckchart15;//Method from documentation you reffered
            xrChart13.SeriesTemplate.View = checkSeries;
            xrChart13.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart13.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart13.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart13.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart14 = (XRChart)report.FindControl("xrChart14", false);
            xrChart14.DataSource = ncheckchart16;//Method from documentation you reffered
            xrChart14.SeriesTemplate.View = checkSeries;
            xrChart14.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart14.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart14.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart14.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart15 = (XRChart)report.FindControl("xrChart15", false);
            xrChart15.DataSource = ncheckchart17;//Method from documentation you reffered
            xrChart15.SeriesTemplate.View = checkSeries;
            xrChart15.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart15.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart15.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart15.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart16 = (XRChart)report.FindControl("xrChart16", false);
            xrChart16.DataSource = ncheckchart18;//Method from documentation you reffered
            xrChart16.SeriesTemplate.View = checkSeries;
            xrChart16.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart16.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart16.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart16.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart17 = (XRChart)report.FindControl("xrChart17", false);
            xrChart17.DataSource = ncheckchart19;//Method from documentation you reffered
            xrChart17.SeriesTemplate.View = checkSeries;
            xrChart17.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart17.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart17.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart17.SeriesTemplate.ValueDataMembers.AddRange("Amount");


            var xrChart18 = (XRChart)report.FindControl("xrChart18", false);
            xrChart18.DataSource = ncheckchart20;//Method from documentation you reffered
            xrChart18.SeriesTemplate.View = checkSeries;
            xrChart18.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart18.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart18.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart18.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart19 = (XRChart)report.FindControl("xrChart19", false);
            xrChart19.DataSource = ncheckchart21;//Method from documentation you reffered
            xrChart19.SeriesTemplate.View = checkSeries;
            xrChart19.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart19.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart19.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart19.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart20 = (XRChart)report.FindControl("xrChart20", false);
            xrChart20.DataSource = ncheckchart22;//Method from documentation you reffered
            xrChart20.SeriesTemplate.View = checkSeries;
            xrChart20.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart20.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart20.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart20.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart21 = (XRChart)report.FindControl("xrChart21", false);
            xrChart21.DataSource = ncheckchart23;//Method from documentation you reffered
            xrChart21.SeriesTemplate.View = checkSeries;
            xrChart21.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart21.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart21.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart21.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart22 = (XRChart)report.FindControl("xrChart22", false);
            xrChart22.DataSource = ncheckchart24;//Method from documentation you reffered
            xrChart22.SeriesTemplate.View = checkSeries;
            xrChart22.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart22.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart22.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart22.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart23 = (XRChart)report.FindControl("xrChart23", false);
            xrChart23.DataSource = ncheckchart25;//Method from documentation you reffered
            xrChart23.SeriesTemplate.View = checkSeries;
            xrChart23.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart23.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart23.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart23.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            var xrChart24 = (XRChart)report.FindControl("xrChart24", false);
            xrChart24.DataSource = ncheckchart27;//Method from documentation you reffered
            xrChart24.SeriesTemplate.View = checkSeries;
            xrChart24.SeriesTemplate.SeriesDataMember = "GridName";
            xrChart24.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            xrChart24.SeriesTemplate.ArgumentDataMember = "GroupText";
            xrChart24.SeriesTemplate.ValueDataMembers.AddRange("Amount");
            //PdfExportOptions pdfOptions = report.ExportOptions.Pdf;
            //var xrChart25 = (XRChart)report.FindControl("xrChart25", false);
            //xrChart25.DataSource = ncheckchart27;//Method from documentation you reffered
            //xrChart25.SeriesTemplate.View = checkSeries;
            //xrChart25.SeriesTemplate.SeriesDataMember = "GridName";
            //xrChart25.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            //xrChart25.SeriesTemplate.ArgumentDataMember = "GroupText";
            //xrChart25.SeriesTemplate.ValueDataMembers.AddRange("Amount");

            //pdfOptions.DocumentOptions.Application = "Fincheckup Application";
            //pdfOptions.DocumentOptions.Author = "Fincheckup Team";
            //pdfOptions.DocumentOptions.Keywords = "Fincheckup, Reporting, Finance";
            //pdfOptions.DocumentOptions.Producer = "";
            //pdfOptions.DocumentOptions.Subject = "Fincheckup Reporting";
            //pdfOptions.DocumentOptions.Title = "Finance Reporting";


            report.xr1Label10.Text = YearCurrent.ToString();
            report.xr1Label12.Text = YearCurrent.ToString();
            report.xr1Label127.Text = YearCurrent.ToString();
            report.xr1Label128.Text = YearCurrent.ToString();
            report.xr1Label131.Text = YearCurrent.ToString();
            report.xr1Label132.Text = YearCurrent.ToString();
            report.xr1Label133.Text = YearCurrent.ToString();
            report.xr1Label136.Text = YearCurrent.ToString();
            report.xr1Label137.Text = YearCurrent.ToString();
            report.xr1Label138.Text = YearCurrent.ToString();
            report.xr1Label141.Text = YearCurrent.ToString();
            report.xr1Label142.Text = YearCurrent.ToString();
            report.xr1Label143.Text = YearCurrent.ToString();
            report.xr1Label144.Text = YearCurrent.ToString();
            report.xr1Label145.Text = YearCurrent.ToString();
            report.xr1Label146.Text = YearCurrent.ToString();
            report.xr1Label147.Text = YearCurrent.ToString();
            report.xr1Label148.Text = YearCurrent.ToString();
            report.xr1Label149.Text = YearCurrent.ToString();
            report.xr1Label222.Text = YearCurrent.ToString();
            report.xr1Label225.Text = YearCurrent.ToString();
            report.xr1Label228.Text = YearCurrent.ToString();
            report.xr1Label231.Text = YearCurrent.ToString();
            report.xr1Label234.Text = YearCurrent.ToString();
            report.xr1Label237.Text = YearCurrent.ToString();
            report.xr1LblYear.Text = YearCurrent.ToString();
            report.xr1lblYear5.Text = YearCurrent.ToString();

            report.xr2Label12225.Text = YearCurrenta.ToString();
            report.xr2Label156.Text = YearCurrenta.ToString();
            report.xr2Label169.Text = YearCurrenta.ToString();
            report.xr2Label172.Text = YearCurrenta.ToString();
            report.xr2Label175.Text = YearCurrenta.ToString();
            report.xr2Label178.Text = YearCurrenta.ToString();
            report.xr2Label181.Text = YearCurrenta.ToString();
            report.xr2Label184.Text = YearCurrenta.ToString();
            report.xr2Label187.Text = YearCurrenta.ToString();
            report.xr2Label190.Text = YearCurrenta.ToString();
            report.xr2Label193.Text = YearCurrenta.ToString();
            report.xr2Label196.Text = YearCurrenta.ToString();
            report.xr2Label199.Text = YearCurrenta.ToString();
            report.xr2Label202.Text = YearCurrenta.ToString();
            report.xr2Label205.Text = YearCurrenta.ToString();
            report.xr2Label208.Text = YearCurrenta.ToString();
            report.xr2Label211.Text = YearCurrenta.ToString();
            report.xr2Label214.Text = YearCurrenta.ToString();
            report.xr2Label217.Text = YearCurrenta.ToString();
            report.xr2Label221.Text = YearCurrenta.ToString();
            report.xr2Label224.Text = YearCurrenta.ToString();
            report.xr2Label227.Text = YearCurrenta.ToString();
            report.xr2Label230.Text = YearCurrenta.ToString();
            report.xr2Label233.Text = YearCurrenta.ToString();
            report.xr2Label236.Text = YearCurrenta.ToString();
            report.xr2LblYer221a.Text = YearCurrenta.ToString();
            report.xr2LblYer221a11.Text = YearCurrenta.ToString();


            report.xr3Label113.Text = YearCurrentb.ToString();
            report.xr3Label123.Text = YearCurrentb.ToString();
            report.xr3Label126.Text = YearCurrentb.ToString();
            report.xr3Label157.Text = YearCurrentb.ToString();
            report.xr3Label170.Text = YearCurrentb.ToString();
            report.xr3Label173.Text = YearCurrentb.ToString();
            report.xr3Label176.Text = YearCurrentb.ToString();
            report.xr3Label179.Text = YearCurrentb.ToString();
            report.xr3Label182.Text = YearCurrentb.ToString();
            report.xr3Label185.Text = YearCurrentb.ToString();
            report.xr3Label188.Text = YearCurrentb.ToString();
            report.xr3Label191.Text = YearCurrentb.ToString();
            report.xr3Label194.Text = YearCurrentb.ToString();
            report.xr3Label197.Text = YearCurrentb.ToString();
            report.xr3Label200.Text = YearCurrentb.ToString();
            report.xr3Label203.Text = YearCurrentb.ToString();
            report.xr3Label206.Text = YearCurrentb.ToString();
            report.xr3Label209.Text = YearCurrentb.ToString();
            report.xr3Label212.Text = YearCurrentb.ToString();
            report.xr3Label215.Text = YearCurrentb.ToString();
            report.xr3Label218.Text = YearCurrentb.ToString();
            report.xr3Label220.Text = YearCurrentb.ToString();
            report.xr3Label223.Text = YearCurrentb.ToString();
            report.xr3Label226.Text = YearCurrentb.ToString();
            report.xr3Label229.Text = YearCurrentb.ToString();
            report.xr3Label232.Text = YearCurrentb.ToString();
            report.xr3Label235.Text = YearCurrentb.ToString();

            report.xr4Label117.Text = YearCurrentcTx.ToString();
            report.xr4Label150.Text = YearCurrentcTx.ToString();
            report.xr4Label151.Text = YearCurrentcTx.ToString();
            report.xr4Label152.Text = YearCurrentcTx.ToString();
            report.xr4Label153.Text = YearCurrentcTx.ToString();
            report.xr4Label154.Text = YearCurrentcTx.ToString();
            report.xr4Label155.Text = YearCurrentcTx.ToString();
            report.xr4Label162.Text = YearCurrentcTx.ToString();
            report.xr4Label166.Text = YearCurrentcTx.ToString();
            report.xr4Label168.Text = YearCurrentcTx.ToString();
            report.xr4Label171.Text = YearCurrentcTx.ToString();
            report.xr4Label174.Text = YearCurrentcTx.ToString();
            report.xr4Label177.Text = YearCurrentcTx.ToString();
            report.xr4Label180.Text = YearCurrentcTx.ToString();
            report.xr4Label183.Text = YearCurrentcTx.ToString();
            report.xr4Label186.Text = YearCurrentcTx.ToString();
            report.xr4Label189.Text = YearCurrentcTx.ToString();
            report.xr4Label192.Text = YearCurrentcTx.ToString();
            report.xr4Label195.Text = YearCurrentcTx.ToString();
            report.xr4Label198.Text = YearCurrentcTx.ToString();
            report.xr4Label201.Text = YearCurrentcTx.ToString();
            report.xr4Label204.Text = YearCurrentcTx.ToString();
            report.xr4Label207.Text = YearCurrentcTx.ToString();
            report.xr4Label210.Text = YearCurrentcTx.ToString();
            report.xr4Label213.Text = YearCurrentcTx.ToString();
            report.xr4Label216.Text = YearCurrentcTx.ToString();
            report.xr4Label219.Text = YearCurrentcTx.ToString();
            //report.xrLblYear.Text = YearCurrent.ToString();
            ////report.xrlblYear1.Text = YearCurrent.ToString();
            ////report.xrlblYear3.Text = YearCurrent.ToString();
            //report.xrlblYear1a1.Text = YearCurrent.ToString();
            //report.xrlblYear1a3.Text = YearCurrent.ToString();
            //report.xrlblYear1a31.Text = YearCurrent.ToString();
            //report.xrlblYear1a3a.Text = YearCurrent.ToString();
            //report.xrlblYear1a3bg.Text = YearCurrent.ToString();
            //report.xrlblYear1a3ff.Text = YearCurrent.ToString();
            //report.xrlblYear1a3h.Text = YearCurrent.ToString();
            //report.xrlblYear1a3jk.Text = YearCurrent.ToString();
            //report.xrlblYear1a3kk.Text = YearCurrent.ToString();
            //report.xrlblYear1a3ll.Text = YearCurrent.ToString();
            //report.xrlblYear1a3oo.Text = YearCurrent.ToString();
            //report.xrlblYear1a3s.Text = YearCurrent.ToString();
            //report.xrlblYear1a3t.Text = YearCurrent.ToString();
            //report.xrlblYear1a3ww.Text = YearCurrent.ToString();
            //report.xrlblYear1a3yy.Text = YearCurrent.ToString();
            //report.xrlblYear311.Text = YearCurrent.ToString();
            //report.xrlblYear32.Text = YearCurrent.ToString();
            //report.xrlblYear31.Text = YearCurrent.ToString();
            //report.xrlblYear4.Text = YearCurrent.ToString();
            //report.xrlblYear5.Text = YearCurrent.ToString();
            //report.xrlblYear6.Text = YearCurrent.ToString();
            //report.xrlblYear7.Text = YearCurrent.ToString();
            //report.xrlblYear8.Text = YearCurrent.ToString();
            //report.xrlblYear9.Text = YearCurrent.ToString();

            //report.xrlblYer21212a.Text = YearCurrenta.ToString();
            //report.xrlblYer21212a1.Text = YearCurrenta.ToString();
            //report.xrlblYer21212a2.Text = YearCurrenta.ToString();
            //report.xrlblYer21212a3.Text = YearCurrenta.ToString();
            //report.xrlblYer21212a5.Text = YearCurrenta.ToString();
            //report.xrlblYer2212a.Text = YearCurrenta.ToString();
            //report.xrlblYer2212a1.Text = YearCurrenta.ToString();
            //report.xrlblYer2212a2.Text = YearCurrenta.ToString();
            //report.xrlblYer2212a3.Text = YearCurrenta.ToString();
            //report.xrlblYer2212a4.Text = YearCurrenta.ToString();
            //report.xrlblYer2212a8.Text = YearCurrenta.ToString();
            //report.xrlblYer2212a6.Text = YearCurrenta.ToString();
            //report.xrlblYer2212a7.Text = YearCurrenta.ToString();
            //report.xrlblYer2212a9.Text = YearCurrenta.ToString();
            //report.xrlblYer221a.Text = YearCurrenta.ToString();
            //report.xrlblYer221a1.Text = YearCurrenta.ToString();
            //report.xrlblYer221a2.Text = YearCurrenta.ToString();
            //report.xrlblYer221a3.Text = YearCurrenta.ToString();
            //report.xrlblYer221a4.Text = YearCurrenta.ToString();
            //report.xrlblYer221a5.Text = YearCurrenta.ToString();
            //report.xrlblYer221a7.Text = YearCurrenta.ToString();
            //report.xrlblYer221a8.Text = YearCurrenta.ToString();
            //report.xrlblYer221a9.Text = YearCurrenta.ToString();
            //report.xrlblYer221a11.Text = YearCurrenta.ToString();
            //report.xrlblYer221a21.Text = YearCurrenta.ToString();
            //report.xrlblYer221a33.Text = YearCurrenta.ToString();
            //report.xrlblYer221a.Text = YearCurrenta.ToString();
            return report;

        }
    }
}
