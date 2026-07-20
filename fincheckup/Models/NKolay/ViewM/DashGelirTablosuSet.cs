using fincheckup.Models.ViewM;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay.ViewM
{
    public class DashGelirTablosuSet : BaseModel
    {
        public static List<DashBilancoView> Get_BrutStsT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header_Wcap @companyID, @nyear,101", new { nyear = _year, companyID = _compID }).ToList();//101 Toplam 
        }
        public static List<DashBilancoView> Get_BrutSts(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Wcap @companyID, @nyear,101", new { nyear = _year, companyID = _compID }).ToList();//101  TestMainOKynkBrutSts
        }
        public static List<DashBilancoView> Get_StsIndirimT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header_Wcap @companyID, @nyear,103", new { nyear = _year, companyID = _compID }).ToList();//103  TestMainOKynkStsIndirim
        }
        public static List<DashBilancoView> Get_StsIndirim(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Wcap @companyID, @nyear,103", new { nyear = _year, companyID = _compID }).ToList();//103 TOPLAM
        }
        public static List<DashBilancoView> Get_NetStsT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_WCAPNetStsT @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();// TBLWcapNetSatis Wcapid--103-- ++101++
        }
        public static List<DashBilancoView> Get_StsMlytT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header_Wcap @companyID, @nyear,105", new { nyear = _year, companyID = _compID }).ToList();//105 Toplam
        }
        public static List<DashBilancoView> Get_StsMlyt(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Wcap @companyID, @nyear,105", new { nyear = _year, companyID = _compID }).ToList();//105 Toplam
        }
        public static List<DashBilancoView> Get_BrutKarZararT(int _year, long _compID)
        {
            //   ""SPO_WcapBrutKarZarar
            return StaticQuery<DashBilancoView>("EXEC SPO_WcapBrutKarZararCheck @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList(); // WcapMainID 301-501 TBLWcapBrutKarZarar(TestMainOKynkBrutKarZarar)  [TBLXMLSourceMain]
        }
        public static List<DashBilancoView> Get_ESMMGenel(int _year, long _compID)
        {
            //   ""SPO_ESMM__Mizan
            return StaticQuery<DashBilancoView>("EXEC SPO_ESMM  @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList(); // WcapMainID 301-501 TBLWcapBrutKarZarar(TestMainOKynkBrutKarZarar)  [TBLXMLSourceMain]
        }
        public static List<DashBilancoView> Get_GenelYonGiderT(int _year, long _compID)
        { //   ""SPO_WcapGenelYonGiderTpl
            return StaticQuery<DashBilancoView>("EXEC SPO_WcapGenelYonGiderTpl @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();//---- +++('770','632') +++ ---('771' )  TestMainOKynkGenelYonGider(TBLWcapGenelYonGider)[TBLXMLSourceMain]
        }
        public static List<DashBilancoView> Get_PazarlamaGiderT(int _year, long _compID)
        {//   ""SPO_WcapPazarlamaGiderTpl
            return StaticQuery<DashBilancoView>("EXEC SPO_WcapPazarlamaGiderTpl @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();//--------++++('760','631') +++++  --('761')---TestMainOKynkPazarlamaGider(TBLWcapPazarlamaGider) [TBLXMLSourceMain]
        }
        public static List<DashBilancoView> Get_ArGeGiderT(int _year, long _compID)
        {//   ""SPO_WcapArGeGiderTpl
            return StaticQuery<DashBilancoView>("EXEC SPO_WcapArGeGiderTpl @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();//--------TestMainOKynkArGeGider(TBLWcapArGeGider) ++++('750','630') +++ ---('751')---
        }
        public static List<DashBilancoView> Get_EsasMaliyetKarZararT(int _year, long _compID)
        {//   ""SPO_WcapEsasMaliyetKarZararTpl
            return StaticQuery<DashBilancoView>("EXEC SPO_WcapEsasMaliyetKarZararTpl @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();//--------('760','631','770','632','750','630')-- +++('771', '761', '751')+++  TestMainEsasMaliyetKarZarar(TBLWcapEsasMaliyetKarZarar)

        }
        public static List<DashBilancoView> Get_DigerFalGelT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header_Wcap @companyID, @nyear,107", new { nyear = _year, companyID = _compID }).ToList(); // ---- 107 TestMainOKynkDigerFalGel 
        }
        public static List<DashBilancoView> Get_DigerFalGel(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Wcap @companyID, @nyear,107", new { nyear = _year, companyID = _compID }).ToList(); // 107 [TestMainC]
        }
        public static List<DashBilancoView> Get_DigerFalGidrT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header_Wcap @companyID, @nyear,109", new { nyear = _year, companyID = _compID }).ToList();// 109  Toplam  [TestMainC]  
        }
        public static List<DashBilancoView> Get_DigerFalGidr(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Wcap @companyID, @nyear,109", new { nyear = _year, companyID = _compID }).ToList();// 109     [TestMainC]  
        }
        public static List<DashBilancoView> Get_FaaliyetKarZaraT(int _year, long _compID)
        {//   ""SPO_WcapFaaliyetarZararTpl
            return StaticQuery<DashBilancoView>("EXEC SPO_WcapFaaliyetarZararTpl @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();// --- TestMainzFaaliyetKarZarar(TBLWcapFaaliyetKarZarar)=> ----109 Wcap---   +++107Wcap+++  =>TBLXMLSourceMain
        }
        public static List<DashBilancoView> Get_FinansmanGidrT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SPO_WcapFinansmanGiderTpl @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
            //  return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Wcap @companyID, @nyear,111", new { nyear = _year, companyID = _compID }).ToList();  // 111 --[TBLXMLSourceMain]
        }
        public static List<DashBilancoView> Get_OlaganKarZaraT(int _year, long _compID)
        {//   ""SPO_WcapOlaganKarZararTpl
            return StaticQuery<DashBilancoView>("EXEC SPO_WcapOlaganKarZararTpl @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();// ---111 Wcap---- ++++TestMainzFaaliyetKarZarar(TBLWcapFaaliyetKarZarar)++++  Table=>TestMainzOlaganKarZarar  ==> [TBLXMLSourceMain]
        }
        public static List<DashBilancoView> Get_OlaganDisiGelrT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header_Wcap @companyID, @nyear,113", new { nyear = _year, companyID = _compID }).ToList(); // 113 Toplam [TestMainC]
        }
        public static List<DashBilancoView> Get_OlaganDisiGelr(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Wcap @companyID, @nyear,113", new { nyear = _year, companyID = _compID }).ToList();// 113 [TestMainC]
        }
        public static List<DashBilancoView> Get_OlaganDisiGdrT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header_Wcap @companyID, @nyear,115", new { nyear = _year, companyID = _compID }).ToList();// 115
        }
        public static List<DashBilancoView> Get_OlaganDisiGdr(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Wcap @companyID, @nyear,115", new { nyear = _year, companyID = _compID }).ToList();// 115 Toplam
        }
        public static List<DashBilancoView> Get_DonemKarZaraT(int _year, long _compID)
        { //   ""SPO_WcapDonemKarZararTpl
            return StaticQuery<DashBilancoView>("EXEC SPO_WcapDonemKarZararTpl @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList(); //TestMainzOlaganKarZarar(TBLWcapOlaganKarZarar)+ 115 Wcap + 113 Wap
        }
        public static List<DashBilancoView> Get_OlaganDisiGdrYkmllk(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Wcap @companyID, @nyear,117", new { nyear = _year, companyID = _compID }).ToList();// 115 Toplam
        }
        public static List<DashBilancoView> Get_DonemKarZaraTNet(int _year, long _compID)
        { //   ""SPO_WcapDonemKarZararTpl
            return StaticQuery<DashBilancoView>("EXEC SPO_WcapDonemKarZararTplNet @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList(); //TestMainzOlaganKarZarar(TBLWcapOlaganKarZarar)+ 115 Wcap + 113 Wap -117
        }
    }
}
