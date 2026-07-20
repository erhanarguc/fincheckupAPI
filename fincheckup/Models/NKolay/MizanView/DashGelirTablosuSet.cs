using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay.MizanView
{
    public class DashGelirTablosuSet : BaseModel
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
}
