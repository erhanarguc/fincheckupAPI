using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay.MizanView
{
    public class DashGelirTablosuMizanDefter
    {
        public static List<DashBilancoViewMizan> getList(int _year, long _compID)
        {
            DashGelirTablosuViewT nCheckdefter = new DashGelirTablosuViewT();
            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_BrutStsT(_year, _compID), "A-Brüt Satışlar", 60, 1);
            nCheckdefter.SetBilanco(DashGelirTablosuSet.Get_BrutSts(_year, _compID), "A-Brüt Satışlar", 0);

            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_StsIndirimT(_year, _compID), "B-Satış Indirimleri(-)", 61, 1);
            nCheckdefter.SetBilanco(DashGelirTablosuSet.Get_StsIndirim(_year, _compID), "B-Satış Indirimleri(-)", 0);

            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_NetStsT(_year, _compID), "C-Net Satışlar", 111, 0);


            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_StsMlytT(_year, _compID), "D-Satışların Maliyeti (-)", 62, 1);
            nCheckdefter.SetBilanco(DashGelirTablosuSet.Get_StsMlyt(_year, _compID), "D-Satışların Maliyeti (-)", 0);

            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_BrutKarZararT(_year, _compID), "E-Brüt Kar/Zararı", 222, 0);
            nCheckdefter.SetBilanco(DashGelirTablosuSet.Get_ESMMGenel(_year, _compID), "E-SMM Satışların Maliyeti (Mizanda 7'li Gruplarda Bekleyen)", 0);

            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_GenelYonGiderTV3(_year, _compID), "F-Genel Yönetim Giderleri (-)", 333, 0);

            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_PazarlamaGiderT(_year, _compID), "G-Pazarlama Giderleri (-)", 444, 0);

            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_ArGeGiderT(_year, _compID), "H-Araştırma ve Geliştirme Giderleri (-)", 555, 0);

            //nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_FinansmanGiderT(_year, _compID), "I-Finasnman Giderleri", 777, 0);

            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_EsasMaliyetKarZararTV3(_year, _compID), "J-Esas Faaliyet Karı/Zararı", 888, 0);

            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_DigerFalGelT(_year, _compID), "K-DİĞER FAALİYETLERDEN OLAĞAN GELİR VE KARLAR", 999, 1);
            nCheckdefter.SetBilanco(DashGelirTablosuSet.Get_DigerFalGel(_year, _compID), "K-DİĞER FAALİYETLERDEN OLAĞAN GELİR VE KARLAR", 0);

            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_DigerFalGidrT(_year, _compID), "L-DİĞER FAALİYETLERDEN OLAĞAN GİDER VE ZARARLAR", 1111, 1);
            nCheckdefter.SetBilanco(DashGelirTablosuSet.Get_DigerFalGidr(_year, _compID), "L-DİĞER FAALİYETLERDEN OLAĞAN GİDER VE ZARARLAR", 0);

            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_FaaliyetKarZaraT(_year, _compID), "M-FİNANSMAN GİDERİ ÖNCESİ FAALİYET KARI ZARARI", 2222, 0);

            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_FinansmanGidrTV3(_year, _compID), "N-Finansman Giderleri", 3333, 0);

            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganKarZaraT(_year, _compID), "O-OLAĞAN KAR VEYA  ZARAR", 4444, 0);

            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganDisiGelrT(_year, _compID), "V-OLAĞANDIŞI GELIR VE KARLAR", 5555, 1);
            nCheckdefter.SetBilanco(DashGelirTablosuSet.Get_OlaganDisiGelr(_year, _compID), "V-OLAĞANDIŞI GELIR VE KARLAR", 0);

            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganDisiGdrT(_year, _compID), "Y-OLAĞANDIŞI GİDER VE ZARARLAR", 7777, 1);
            nCheckdefter.SetBilanco(DashGelirTablosuSet.Get_OlaganDisiGdr(_year, _compID), "Y-OLAĞANDIŞI GİDER VE ZARARLAR", 0);

            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_DonemKarZaraTV3(_year, _compID), "Z-DÖNEM KARI/ZARARI", 9991, 0);
            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganDisiGdrYkmllk(_year, _compID), "Z1-DÖNEM KARI VERGİ VE DİĞ.YASAL YÜKÜMLÜLÜK KARŞILIĞI", 9993, 0);
            nCheckdefter.SetBilancoHeaderT(DashGelirTablosuSet.Get_DonemKarZaraTNetV3(_year, _compID), "ZT-DÖNEM NET KARI/ZARARI", 9995, 0);

            return nCheckdefter.mrequestEntry;
        }
    }

    public class DashGelirTablosuBeyan
    {
        public static List<DashBilancoViewMizan> getList(int _year, long _compID)
        {
            DashGelirTablosuViewT nCheck = new DashGelirTablosuViewT();
            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_BrutStsT(_year, _compID), "A-Brüt Satışlar", 60, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_BrutSts(_year, _compID), "A-Brüt Satışlar", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_StsIndirimT(_year, _compID), "B-Satış Indirimleri(-)", 61, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_StsIndirim(_year, _compID), "B-Satış Indirimleri(-)", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_NetStsT(_year, _compID), "C-Net Satışlar", 111, 0);


            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_StsMlytT(_year, _compID), "D-Satışların Maliyeti (-)", 62, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_StsMlyt(_year, _compID), "D-Satışların Maliyeti (-)", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_BrutKarZararT(_year, _compID), "E-Brüt Kar/Zararı", 222, 0);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_ESMMGenel(_year, _compID), "E-SMM Satışların Maliyeti (Mizanda 7'li Gruplarda Bekleyen)", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_GenelYonGiderT(_year, _compID), "F-Genel Yönetim Giderleri (-)", 333, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_PazarlamaGiderT(_year, _compID), "G-Pazarlama Giderleri (-)", 444, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_ArGeGiderT(_year, _compID), "H-Araştırma ve Geliştirme Giderleri (-)", 555, 0);

            //nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_FinansmanGiderT(_year, _compID), "I-Finasnman Giderleri", 777, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_EsasMaliyetKarZararT(_year, _compID), "J-Esas Faaliyet Karı/Zararı", 888, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_DigerFalGelT(_year, _compID), "K-DİĞER FAALİYETLERDEN OLAĞAN GELİR VE KARLAR", 999, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_DigerFalGel(_year, _compID), "K-DİĞER FAALİYETLERDEN OLAĞAN GELİR VE KARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_DigerFalGidrT(_year, _compID), "L-DİĞER FAALİYETLERDEN OLAĞAN GİDER VE ZARARLAR", 1111, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_DigerFalGidr(_year, _compID), "L-DİĞER FAALİYETLERDEN OLAĞAN GİDER VE ZARARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_FaaliyetKarZaraT(_year, _compID), "M-FİNANSMAN GİDERİ ÖNCESİ FAALİYET KARI ZARARI", 2222, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_FinansmanGidrT(_year, _compID), "N-Finansman Giderleri", 3333, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganKarZaraT(_year, _compID), "O-OLAĞAN KAR VEYA  ZARAR", 4444, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganDisiGelrT(_year, _compID), "V-OLAĞANDIŞI GELIR VE KARLAR", 5555, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_OlaganDisiGelr(_year, _compID), "V-OLAĞANDIŞI GELIR VE KARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganDisiGdrT(_year, _compID), "Y-OLAĞANDIŞI GİDER VE ZARARLAR", 7777, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_OlaganDisiGdr(_year, _compID), "Y-OLAĞANDIŞI GİDER VE ZARARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_DonemKarZaraT(_year, _compID), "Z-DÖNEM KARI/ZARARI", 9991, 0);
            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganDisiGdrYkmllk(_year, _compID), "Z1-DÖNEM KARI VERGİ VE DİĞ.YASAL YÜKÜMLÜLÜK KARŞILIĞI", 9993, 0);
            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_DonemKarZaraTNet(_year, _compID), "ZT-DÖNEM NET KARI/ZARARI", 9995, 0);

            return nCheck.mrequestEntry;
        }
    }
    public class DashGelirTablosuSetMizan : BaseModel
    {
        public static List<DashBilancoViewMizan> Get_BrutStsT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header_Wcap__Mizan @companyID, @nyear,101", new { nyear = _year, companyID = _compID }).ToList();//101 Toplam 
        }
        public static List<DashBilancoViewMizan> Get_BrutSts(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Wcap__Mizan @companyID, @nyear,101", new { nyear = _year, companyID = _compID }).ToList();//101  TestMainOKynkBrutSts
        }
        public static List<DashBilancoViewMizan> Get_StsIndirimT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header_Wcap__Mizan @companyID, @nyear,103", new { nyear = _year, companyID = _compID }).ToList();//103  TestMainOKynkStsIndirim
        }
        public static List<DashBilancoViewMizan> Get_StsIndirim(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Wcap__Mizan @companyID, @nyear,103", new { nyear = _year, companyID = _compID }).ToList();//103 TOPLAM
        }
        public static List<DashBilancoViewMizan> Get_NetStsT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_WCAPNetStsT__Mizan @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();// TBLWcapNetSatis Wcapid--103-- ++101++
        }
        public static List<DashBilancoViewMizan> Get_StsMlytT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header_Wcap__Mizan @companyID, @nyear,105", new { nyear = _year, companyID = _compID }).ToList();//105 Toplam
        }
        public static List<DashBilancoViewMizan> Get_Amortisman(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header_Wcap__Mizan @companyID, @nyear,63", new { nyear = _year, companyID = _compID }).ToList();//105 Toplam
        }
        public static List<DashBilancoViewMizan> Get_StsMlyt(int _year, long _compID)
        {
            List<DashBilancoViewMizan> nlist = new List<DashBilancoViewMizan>();
            //   double t7212030 = Get_7102030t(_year, _compID);
            //double t40 = Get_740t(_year, _compID);
            nlist = StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_Wcap__Mizan] @companyID, @nyear,105", new { nyear = _year, companyID = _compID }).ToList();//105 Toplam

            //nlist= nlist.Where(c => c.AccountMainID == "620").Select(c => { c.Amount = c.Amount+ t7212030; return c; }).ToList();
            //nlist = nlist.Where(c => c.AccountMainID == "621").Select(c => { c.Amount = c.Amount + t40; return c; }).ToList();
            return nlist;
        }
        public static double Get_7102030t(int _year, long _compID)
        {
            return StaticQuery<double>("SELECT ISNULL(ABS(SUM(Amount)),0) AS 'January'  FROM TBLXMLSourceOne WITH (NOLOCK) where [CompanyID]=@companyID and [Year]=@nyear and AccountMainID in('710','720','730') ", new { nyear = _year, companyID = _compID }).FirstOrDefault();//105 Toplam
        }
        public static double Get_740t(int _year, long _compID)
        {
            return StaticQuery<double>("SELECT ISNULL(ABS(SUM(Amount)),0) AS 'January'  FROM TBLXMLSourceOne WITH (NOLOCK) where [CompanyID]=@companyID and [Year]=@nyear and AccountMainID in('740')", new { nyear = _year, companyID = _compID }).FirstOrDefault();//105 Toplam
        }
        public static List<DashBilancoViewMizan> Get_BrutKarZararT(int _year, long _compID)
        {
            //   ""SPO_WcapBrutKarZarar
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapBrutKarZarar__Mizan @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList(); // WcapMainID 301-501 TBLWcapBrutKarZarar(TestMainOKynkBrutKarZarar)  [TBLXMLSourceMain]
        }
        public static List<DashBilancoViewMizan> Get_ESMMGenel(int _year, long _compID)
        {
            //   ""SPO_ESMM__Mizan
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_ESMM__Mizan @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList(); // WcapMainID 301-501 TBLWcapBrutKarZarar(TestMainOKynkBrutKarZarar)  [TBLXMLSourceMain]
        }
        public static List<DashBilancoViewMizan> Get_GenelYonGiderT(int _year, long _compID)
        { //   ""SPO_WcapGenelYonGiderTpl
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapGenelYonGiderTpl__Mizan @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();//---- +++('770','632') +++ ---('771' )  TestMainOKynkGenelYonGider(TBLWcapGenelYonGider)[TBLXMLSourceMain]
        }
        public static List<DashBilancoViewMizan> Get_GenelYonGiderTV3(int _year, long _compID)
        { //   ""SPO_WcapGenelYonGiderTpl
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapGenelYonGiderTpl__MizanV3 @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();//---- +++('770','632') +++ ---('771' )  TestMainOKynkGenelYonGider(TBLWcapGenelYonGider)[TBLXMLSourceMain]
        }
        public static List<DashBilancoViewMizan> Get_PazarlamaGiderT(int _year, long _compID)
        {//   ""SPO_WcapPazarlamaGiderTpl
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapPazarlamaGiderTpl__Mizan @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();//--------++++('760','631') +++++  --('761')---TestMainOKynkPazarlamaGider(TBLWcapPazarlamaGider) [TBLXMLSourceMain]
        }
        public static List<DashBilancoViewMizan> Get_ArGeGiderT(int _year, long _compID)
        {//   ""SPO_WcapArGeGiderTpl
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapArGeGiderTpl__Mizan @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();//--------TestMainOKynkArGeGider(TBLWcapArGeGider) ++++('750','630') +++ ---('751')---
        }
        public static List<DashBilancoViewMizan> Get_EsasMaliyetKarZararT(int _year, long _compID)
        {//   ""SPO_WcapEsasMaliyetKarZararTpl
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapEsasMaliyetKarZararTpl__Mizan @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();//--------('760','631','770','632','750','630')-- +++('771', '761', '751')+++  TestMainEsasMaliyetKarZarar(TBLWcapEsasMaliyetKarZarar)

        }
        public static List<DashBilancoViewMizan> Get_EsasMaliyetKarZararTV3(int _year, long _compID)
        {//   ""SPO_WcapEsasMaliyetKarZararTpl
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapEsasMaliyetKarZararTpl__MizanV3 @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();//--------('760','631','770','632','750','630')-- +++('771', '761', '751')+++  TestMainEsasMaliyetKarZarar(TBLWcapEsasMaliyetKarZarar)

        }
        public static List<DashBilancoViewMizan> Get_DigerFalGelT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header_Wcap__Mizan @companyID, @nyear,107", new { nyear = _year, companyID = _compID }).ToList(); // ---- 107 TestMainOKynkDigerFalGel 
        }
        public static List<DashBilancoViewMizan> Get_DigerFalGel(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Wcap__Mizan @companyID, @nyear,107", new { nyear = _year, companyID = _compID }).ToList(); // 107 [TestMainC]
        }
        public static List<DashBilancoViewMizan> Get_DigerFalGidrT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header_Wcap__Mizan @companyID, @nyear,109", new { nyear = _year, companyID = _compID }).ToList();// 109  Toplam  [TestMainC]  
        }
        public static List<DashBilancoViewMizan> Get_DigerFalGidr(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Wcap__Mizan @companyID, @nyear,109", new { nyear = _year, companyID = _compID }).ToList();// 109     [TestMainC]  
        }
        public static List<DashBilancoViewMizan> Get_FaaliyetKarZaraT(int _year, long _compID)
        {//   ""SPO_WcapFaaliyetarZararTpl
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapFaaliyetarZararTpl__Mizan @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();// --- TestMainzFaaliyetKarZarar(TBLWcapFaaliyetKarZarar)=> ----109 Wcap---   +++107Wcap+++  =>TBLXMLSourceMain
        }
        public static List<DashBilancoViewMizan> Get_FinansmanGidrT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapFinansmanGiderTpl__Mizan @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
            //  return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Wcap__Mizan @companyID, @nyear,111", new { nyear = _year, companyID = _compID }).ToList();  // 111 --[TBLXMLSourceMain]
        }
        public static List<DashBilancoViewMizan> Get_FinansmanGidrTV3(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapFinansmanGiderTpl__MizanV3 @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
            //  return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Wcap__Mizan @companyID, @nyear,111", new { nyear = _year, companyID = _compID }).ToList();  // 111 --[TBLXMLSourceMain]
        }
        public static List<DashBilancoViewMizan> Get_OlaganKarZaraT(int _year, long _compID)
        {//   ""SPO_WcapOlaganKarZararTpl
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapOlaganKarZararTpl__Mizan @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();// ---111 Wcap---- ++++TestMainzFaaliyetKarZarar(TBLWcapFaaliyetKarZarar)++++  Table=>TestMainzOlaganKarZarar  ==> [TBLXMLSourceMain]
        }
        public static List<DashBilancoViewMizan> Get_OlaganKarZaraTByn(int _year, long _compID)
        {//   ""SPO_WcapOlaganKarZararTpl
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapDonemKarZararTpl__MizanByn @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();// ---111 Wcap---- ++++TestMainzFaaliyetKarZarar(TBLWcapFaaliyetKarZarar)++++  Table=>TestMainzOlaganKarZarar  ==> [TBLXMLSourceMain]
        }
        public static List<DashBilancoViewMizan> Get_OlaganDisiGelrT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header_Wcap__Mizan @companyID, @nyear,113", new { nyear = _year, companyID = _compID }).ToList(); // 113 Toplam [TestMainC]
        }
        public static List<DashBilancoViewMizan> Get_OlaganDisiGelr(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Wcap__Mizan @companyID, @nyear,113", new { nyear = _year, companyID = _compID }).ToList();// 113 [TestMainC]
        }
        public static List<DashBilancoViewMizan> Get_OlaganDisiGdrT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header_Wcap__Mizan @companyID, @nyear,115", new { nyear = _year, companyID = _compID }).ToList();// 115
        }
        public static List<DashBilancoViewMizan> Get_OlaganDisiGdr(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Wcap__Mizan @companyID, @nyear,115", new { nyear = _year, companyID = _compID }).ToList();// 115 Toplam
        }
        public static List<DashBilancoViewMizan> Get_DonemKarZaraT(int _year, long _compID)
        { //   ""SPO_WcapDonemKarZararTpl
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapDonemKarZararTpl__Mizan @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList(); //TestMainzOlaganKarZarar(TBLWcapOlaganKarZarar)+ 115 Wcap + 113 Wap
        }
        public static List<DashBilancoViewMizan> Get_DonemKarZaraTV3(int _year, long _compID)
        { //   ""SPO_WcapDonemKarZararTpl
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapDonemKarZararTpl__MizanV3 @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList(); //TestMainzOlaganKarZarar(TBLWcapOlaganKarZarar)+ 115 Wcap + 113 Wap
        }
        public static List<DashBilancoViewMizan> Get_DonemKarZaraTV1(int _year, long _compID)
        { //   ""SPO_WcapDonemKarZararTpl
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapDonemKarZararTpl__MizanV1 @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList(); //TestMainzOlaganKarZarar(TBLWcapOlaganKarZarar)+ 115 Wcap + 113 Wap
        }
        public static List<DashBilancoViewMizan> Get_OlaganDisiGdrYkmllk(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Wcap__Mizan @companyID, @nyear,117", new { nyear = _year, companyID = _compID }).ToList();// 115 Toplam
        }
        public static List<DashBilancoViewMizan> Get_DonemKarZaraTNet(int _year, long _compID)
        { //   ""SPO_WcapDonemKarZararTpl
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapDonemKarZararTplNet__Mizan @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList(); //TestMainzOlaganKarZarar(TBLWcapOlaganKarZarar)+ 115 Wcap + 113 Wap -117
        }
        public static List<DashBilancoViewMizan> Get_DonemKarZaraTNetByn(int _year, long _compID)
        { //   ""SPO_WcapDonemKarZararTpl
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapDonemKarZararTplNet__MizanByn @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList(); //TestMainzOlaganKarZarar(TBLWcapOlaganKarZarar)+ 115 Wcap + 113 Wap -117
        }
        public static List<DashBilancoViewMizan> Get_DonemKarZaraTNetV3(int _year, long _compID)
        { //   ""SPO_WcapDonemKarZararTpl
            return StaticQuery<DashBilancoViewMizan>("EXEC SPO_WcapDonemKarZararTplNet__MizanV3 @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList(); //TestMainzOlaganKarZarar(TBLWcapOlaganKarZarar)+ 115 Wcap + 113 Wap -117
        }
    }
    public class DashGelirTablosuViewTMizan
    {
        public DashGelirTablosuViewTMizan()
        {
            mrequestEntry = new List<DashBilancoViewMizan>();
            counter = 0;
        }
        public List<DashBilancoViewMizan> mrequestEntry { get; set; }
        public int counter { get; set; }

        public void SetBilanco(List<DashBilancoViewMizan> mrequestEntryCount, string tname, int ishidden)
        {
            DashBilancoViewMizan nDash = new DashBilancoViewMizan();
            for (int i = 0; i < mrequestEntryCount.Count(); i++)
            {
                counter++;
                nDash = new DashBilancoViewMizan();
                nDash.GroupName = tname;
                nDash.AccountMainDescription = mrequestEntryCount[i].AccountMainDescription;
                nDash.AccountMainID = mrequestEntryCount[i].AccountMainID;
                nDash.Amount = mrequestEntryCount[i].Amount;
                nDash.CompanyID = mrequestEntryCount[i].CompanyID;
                nDash.DebitCreditCode = mrequestEntryCount[i].DebitCreditCode;
                nDash.Year = mrequestEntryCount[i].Year;
                nDash.TypeID = 0;
                nDash.CounterZone = counter;
                nDash.IsHidden = ishidden;
                mrequestEntry.Add(nDash);
            }

        }

        public void SetBilancoHeaderT(List<DashBilancoViewMizan> mrequestEntryCount, string tname, int typeid_, int ishidden)
        {
            counter++;
            DashBilancoViewMizan nDash = new DashBilancoViewMizan();
            for (int i = 0; i < mrequestEntryCount.Count(); i++)
            {
                nDash = new DashBilancoViewMizan();
                nDash.GroupName = tname;
                nDash.AccountMainDescription = tname;
                nDash.AccountMainID = mrequestEntryCount[i].AccountMainID;
                nDash.Amount = mrequestEntryCount[i].Amount;
                nDash.CompanyID = mrequestEntryCount[i].CompanyID;
                nDash.DebitCreditCode = mrequestEntryCount[i].DebitCreditCode;
                nDash.Year = mrequestEntryCount[i].Year;
                nDash.TypeID = typeid_;
                nDash.IsHidden = ishidden;
                nDash.CounterZone = counter;

                mrequestEntry.Add(nDash);
            }
        }

    }
    public class DashGelirTablosuMizan
    {
        public static List<DashBilancoViewMizan> GetListBYN(int _year, long _compID)
        {
            DashGelirTablosuViewTMizan nCheck = new DashGelirTablosuViewTMizan();
            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_BrutStsT(_year, _compID), "A-Brüt Satışlar", 60, 1);
            nCheck.SetBilanco(DashGelirTablosuSetMizan.Get_BrutSts(_year, _compID), "A-Brüt Satışlar", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_StsIndirimT(_year, _compID), "B-Satış Indirimleri(-)", 61, 1);
            nCheck.SetBilanco(DashGelirTablosuSetMizan.Get_StsIndirim(_year, _compID), "B-Satış Indirimleri(-)", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_NetStsT(_year, _compID), "C-Net Satışlar", 111, 0);


            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_StsMlytT(_year, _compID), "D-Satışların Maliyeti (-)", 62, 1);
            nCheck.SetBilanco(DashGelirTablosuSetMizan.Get_StsMlyt(_year, _compID), "D-Satışların Maliyeti (-)", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_BrutKarZararT(_year, _compID), "E-Brüt Kar/Zararı", 222, 0);
            nCheck.SetBilanco(DashGelirTablosuSetMizan.Get_ESMMGenel(_year, _compID), "E-SMM Satışların Maliyeti (Mizanda 7'li Gruplarda Bekleyen)", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_GenelYonGiderT(_year, _compID), "F-Genel Yönetim Giderleri (-)", 333, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_PazarlamaGiderT(_year, _compID), "G-Pazarlama Giderleri (-)", 444, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_ArGeGiderT(_year, _compID), "H-Araştırma ve Geliştirme Giderleri (-)", 555, 0);
            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_Amortisman(_year, _compID), "I-Amortisman Giderleri (-)", 63, 0);
            //nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_FinansmanGiderT(_year, _compID), "I-Finasnman Giderleri", 777, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_EsasMaliyetKarZararT(_year, _compID), "J-Esas Faaliyet Karı/Zararı", 888, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_DigerFalGelT(_year, _compID), "K-DİĞER FAALİYETLERDEN OLAĞAN GELİR VE KARLAR", 999, 1);
            nCheck.SetBilanco(DashGelirTablosuSetMizan.Get_DigerFalGel(_year, _compID), "K-DİĞER FAALİYETLERDEN OLAĞAN GELİR VE KARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_DigerFalGidrT(_year, _compID), "L-DİĞER FAALİYETLERDEN OLAĞAN GİDER VE ZARARLAR", 1111, 1);
            nCheck.SetBilanco(DashGelirTablosuSetMizan.Get_DigerFalGidr(_year, _compID), "L-DİĞER FAALİYETLERDEN OLAĞAN GİDER VE ZARARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_FaaliyetKarZaraT(_year, _compID), "M-FİNANSMAN GİDERİ ÖNCESİ FAALİYET KARI ZARARI", 2222, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_FinansmanGidrT(_year, _compID), "N-Finansman Giderleri", 3333, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_OlaganKarZaraT(_year, _compID), "O-OLAĞAN KAR VEYA  ZARAR", 4444, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_OlaganDisiGelrT(_year, _compID), "V-OLAĞANDIŞI GELIR VE KARLAR", 5555, 1);
            nCheck.SetBilanco(DashGelirTablosuSetMizan.Get_OlaganDisiGelr(_year, _compID), "V-OLAĞANDIŞI GELIR VE KARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_OlaganDisiGdrT(_year, _compID), "Y-OLAĞANDIŞI GİDER VE ZARARLAR", 7777, 1);
            nCheck.SetBilanco(DashGelirTablosuSetMizan.Get_OlaganDisiGdr(_year, _compID), "Y-OLAĞANDIŞI GİDER VE ZARARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_OlaganKarZaraTByn(_year, _compID), "Z-DÖNEM KARI/ZARARI", 9991, 0);
            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_OlaganDisiGdrYkmllk(_year, _compID), "Z1-DÖNEM KARI VERGİ VE DİĞ.YASAL YÜKÜMLÜLÜK KARŞILIĞI", 9993, 0);
            nCheck.SetBilancoHeaderT(DashGelirTablosuSetMizan.Get_DonemKarZaraTNetByn(_year, _compID), "ZT-DÖNEM NET KARI/ZARARI", 9995, 0);

            return nCheck.mrequestEntry;
        }
        public static List<DashBilancoViewMizan> getListBYN(int _year, long _compID)
        {
            DashGelirTablosuViewT nCheck = new DashGelirTablosuViewT();
            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_BrutStsT(_year, _compID), "A-Brüt Satışlar", 60, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_BrutSts(_year, _compID), "A-Brüt Satışlar", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_StsIndirimT(_year, _compID), "B-Satış Indirimleri(-)", 61, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_StsIndirim(_year, _compID), "B-Satış Indirimleri(-)", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_NetStsT(_year, _compID), "C-Net Satışlar", 111, 0);


            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_StsMlytT(_year, _compID), "D-Satışların Maliyeti (-)", 62, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_StsMlyt(_year, _compID), "D-Satışların Maliyeti (-)", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_BrutKarZararT(_year, _compID), "E-Brüt Kar/Zararı", 222, 0);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_ESMMGenel(_year, _compID), "E-SMM Satışların Maliyeti (Mizanda 7'li Gruplarda Bekleyen)", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_GenelYonGiderT(_year, _compID), "F-Genel Yönetim Giderleri (-)", 333, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_PazarlamaGiderT(_year, _compID), "G-Pazarlama Giderleri (-)", 444, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_ArGeGiderT(_year, _compID), "H-Araştırma ve Geliştirme Giderleri (-)", 555, 0);

            //nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_FinansmanGiderT(_year, _compID), "I-Finasnman Giderleri", 777, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_EsasMaliyetKarZararT(_year, _compID), "J-Esas Faaliyet Karı/Zararı", 888, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_DigerFalGelT(_year, _compID), "K-DİĞER FAALİYETLERDEN OLAĞAN GELİR VE KARLAR", 999, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_DigerFalGel(_year, _compID), "K-DİĞER FAALİYETLERDEN OLAĞAN GELİR VE KARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_DigerFalGidrT(_year, _compID), "L-DİĞER FAALİYETLERDEN OLAĞAN GİDER VE ZARARLAR", 1111, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_DigerFalGidr(_year, _compID), "L-DİĞER FAALİYETLERDEN OLAĞAN GİDER VE ZARARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_FaaliyetKarZaraT(_year, _compID), "M-FİNANSMAN GİDERİ ÖNCESİ FAALİYET KARI ZARARI", 2222, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_FinansmanGidrT(_year, _compID), "N-Finansman Giderleri", 3333, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganKarZaraT(_year, _compID), "O-OLAĞAN KAR VEYA  ZARAR", 4444, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganDisiGelrT(_year, _compID), "V-OLAĞANDIŞI GELIR VE KARLAR", 5555, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_OlaganDisiGelr(_year, _compID), "V-OLAĞANDIŞI GELIR VE KARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganDisiGdrT(_year, _compID), "Y-OLAĞANDIŞI GİDER VE ZARARLAR", 7777, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_OlaganDisiGdr(_year, _compID), "Y-OLAĞANDIŞI GİDER VE ZARARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganKarZaraTByn(_year, _compID), "Z-DÖNEM KARI/ZARARI", 9991, 0);
            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganDisiGdrYkmllk(_year, _compID), "Z1-DÖNEM KARI VERGİ VE DİĞ.YASAL YÜKÜMLÜLÜK KARŞILIĞI", 9993, 0);
            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_DonemKarZaraTNetByn(_year, _compID), "ZT-DÖNEM NET KARI/ZARARI", 9995, 0);

            return nCheck.mrequestEntry;
        }
        public static List<DashBilancoViewMizan> getList(int _year, long _compID)
        {
            DashGelirTablosuViewT nCheck = new DashGelirTablosuViewT();
            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_BrutStsT(_year, _compID), "A-Brüt Satışlar", 60, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_BrutSts(_year, _compID), "A-Brüt Satışlar", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_StsIndirimT(_year, _compID), "B-Satış Indirimleri(-)", 61, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_StsIndirim(_year, _compID), "B-Satış Indirimleri(-)", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_NetStsT(_year, _compID), "C-Net Satışlar", 111, 0);


            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_StsMlytT(_year, _compID), "D-Satışların Maliyeti (-)", 62, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_StsMlyt(_year, _compID), "D-Satışların Maliyeti (-)", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_BrutKarZararT(_year, _compID), "E-Brüt Kar/Zararı", 222, 0);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_ESMMGenel(_year, _compID), "E-SMM Satışların Maliyeti (Mizanda 7'li Gruplarda Bekleyen)", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_GenelYonGiderT(_year, _compID), "F-Genel Yönetim Giderleri (-)", 333, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_PazarlamaGiderT(_year, _compID), "G-Pazarlama Giderleri (-)", 444, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_ArGeGiderT(_year, _compID), "H-Araştırma ve Geliştirme Giderleri (-)", 555, 0);

            //nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_FinansmanGiderT(_year, _compID), "I-Finasnman Giderleri", 777, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_EsasMaliyetKarZararT(_year, _compID), "J-Esas Faaliyet Karı/Zararı", 888, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_DigerFalGelT(_year, _compID), "K-DİĞER FAALİYETLERDEN OLAĞAN GELİR VE KARLAR", 999, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_DigerFalGel(_year, _compID), "K-DİĞER FAALİYETLERDEN OLAĞAN GELİR VE KARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_DigerFalGidrT(_year, _compID), "L-DİĞER FAALİYETLERDEN OLAĞAN GİDER VE ZARARLAR", 1111, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_DigerFalGidr(_year, _compID), "L-DİĞER FAALİYETLERDEN OLAĞAN GİDER VE ZARARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_FaaliyetKarZaraT(_year, _compID), "M-FİNANSMAN GİDERİ ÖNCESİ FAALİYET KARI ZARARI", 2222, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_FinansmanGidrT(_year, _compID), "N-Finansman Giderleri", 3333, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganKarZaraT(_year, _compID), "O-OLAĞAN KAR VEYA  ZARAR", 4444, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganDisiGelrT(_year, _compID), "V-OLAĞANDIŞI GELIR VE KARLAR", 5555, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_OlaganDisiGelr(_year, _compID), "V-OLAĞANDIŞI GELIR VE KARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganDisiGdrT(_year, _compID), "Y-OLAĞANDIŞI GİDER VE ZARARLAR", 7777, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_OlaganDisiGdr(_year, _compID), "Y-OLAĞANDIŞI GİDER VE ZARARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_DonemKarZaraT(_year, _compID), "Z-DÖNEM KARI/ZARARI", 9991, 0);
            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganDisiGdrYkmllk(_year, _compID), "Z1-DÖNEM KARI VERGİ VE DİĞ.YASAL YÜKÜMLÜLÜK KARŞILIĞI", 9993, 0);
            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_DonemKarZaraTNet(_year, _compID), "ZT-DÖNEM NET KARI/ZARARI", 9995, 0);

            return nCheck.mrequestEntry;
        }
    }
    public class DashGelirTablosuViewT
    {
        public DashGelirTablosuViewT()
        {
            mrequestEntry = new List<DashBilancoViewMizan>();
            counter = 0;
        }
        public List<DashBilancoViewMizan> mrequestEntry { get; set; }
        public int counter { get; set; }

        public void SetBilanco(List<DashBilancoViewMizan> mrequestEntryCount, string tname, int ishidden)
        {
            DashBilancoViewMizan nDash = new DashBilancoViewMizan();
            for (int i = 0; i < mrequestEntryCount.Count(); i++)
            {
                counter++;
                nDash = new DashBilancoViewMizan();
                nDash.GroupName = tname;
                nDash.AccountMainDescription = mrequestEntryCount[i].AccountMainDescription;
                nDash.AccountMainID = mrequestEntryCount[i].AccountMainID;
                nDash.Amount = mrequestEntryCount[i].Amount;
                nDash.CompanyID = mrequestEntryCount[i].CompanyID;
                nDash.DebitCreditCode = mrequestEntryCount[i].DebitCreditCode;
                nDash.Year = mrequestEntryCount[i].Year;
                nDash.TypeID = 0;
                nDash.CounterZone = counter;
                nDash.IsHidden = ishidden;
                mrequestEntry.Add(nDash);
            }

        }

        public void SetBilancoHeaderT(List<DashBilancoViewMizan> mrequestEntryCount, string tname, int typeid_, int ishidden)
        {
            counter++;
            DashBilancoViewMizan nDash = new DashBilancoViewMizan();
            for (int i = 0; i < mrequestEntryCount.Count(); i++)
            {
                nDash = new DashBilancoViewMizan();
                nDash.GroupName = tname;
                nDash.AccountMainDescription = tname;
                nDash.AccountMainID = mrequestEntryCount[i].AccountMainID;
                nDash.Amount = mrequestEntryCount[i].Amount;
                nDash.CompanyID = mrequestEntryCount[i].CompanyID;
                nDash.DebitCreditCode = mrequestEntryCount[i].DebitCreditCode;
                nDash.Year = mrequestEntryCount[i].Year;
                nDash.TypeID = typeid_;
                nDash.IsHidden = ishidden;
                nDash.CounterZone = counter;

                mrequestEntry.Add(nDash);
            }
        }

    }
}
