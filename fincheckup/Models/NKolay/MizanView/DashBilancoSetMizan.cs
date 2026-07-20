using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay.MizanView
{
    public class DashBilancoSetMizan : BaseModel
    {
        public static int Set_ReportSetResetMizanKayitMnth(int _year, long _compID, int _mon)
        {
            //

            if (_mon == 0)
            {
                StaticQuery<int>("Delete FROM [TBLMizan] where CompanyID=@companyID and Year=@nyear   ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            }
            else
            {
                StaticQuery<int>("Delete FROM [TBLMizan] where CompanyID=@companyID and Year=@nyear  and MainMonth=@nmonth", new { nyear = _year, companyID = _compID, nmonth = _mon }).FirstOrDefault();

            }



            return 1;

        }
        public static int Set_ReportSetResetMizanKayitMonthAll(int _year, long _compID, int _mon)
        {
            //
            long companyidII = -1000000 * _compID;
            StaticQuery<int>("Delete FROM [SPO_TBMLAKTARMA] where [CompanyID]=@companyID and [YEAR]=@nyear ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            StaticQuery<int>("Delete FROM [TBLXMLSourceOne] where (CompanyID=@companyID or CompanyID=@CompanyidII) and Year=@nyear ", new { nyear = _year, companyID = _compID, CompanyidII = companyidII }).FirstOrDefault();
            StaticQuery<int>("Delete FROM [TBLXMLSourceOneBck] where CompanyID=@companyID and Year=@nyear  and MainMonth=@nmonth", new { nyear = _year, companyID = _compID, nmonth = _mon }).FirstOrDefault();
            StaticQuery<int>("delete FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn] where (CompanyID=@companyID or CompanyID=@CompanyidII) and [Year]=@nyear", new { nyear = _year, companyID = _compID, CompanyidII = companyidII }).FirstOrDefault();
            StaticQuery<int>("delete  FROM [EDEFTERDB].[dbo].[TBLMRevenueMzn] where (CompanyID=@companyID or CompanyID=@CompanyidII) and [Year]=@nyear;", new { nyear = _year, companyID = _compID, CompanyidII = companyidII }).FirstOrDefault();
            if (_mon == 0)
            {
                StaticQuery<int>("Delete FROM [TBLXMLSourceOneBck] where CompanyID=@companyID and Year=@nyear ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            }
            else
            {
                StaticQuery<int>("Delete FROM [TBLXMLSourceOneBck] where CompanyID=@companyID and Year=@nyear  and MainMonth=@nmonth", new { nyear = _year, companyID = _compID, nmonth = _mon }).FirstOrDefault();
            }

            string sqll = @"delete FROM [EDEFTERDB].[dbo].[TBMLREPOR01MZN] where CompanyID=@companyID and [Year]=@nyear;
delete   FROM [EDEFTERDB].[dbo].[TBMLREPOR01ZMZN] where CompanyID=@companyID and [Year]=@nyear;
delete   FROM [EDEFTERDB].[dbo].[TBMLREPOR01ZTMZN] where CompanyID=@companyID and [Year]=@nyear;
delete  FROM [EDEFTERDB].[dbo].[TBMLREPORT01AMZN] where CompanyID=@companyID and [Year]=@nyear;
delete  FROM [EDEFTERDB].[dbo].[TBMLREPORT01MZN] where CompanyID=@companyID and [Year]=@nyear;
delete    FROM [EDEFTERDB].[dbo].[TBMLREPORT031AMZN] where CompanyID=@companyID and [Year]=@nyear;
delete  FROM [EDEFTERDB].[dbo].[TBMLREPORT03MZN] where CompanyID=@companyID and [Year]=@nyear;
delete   FROM [EDEFTERDB].[dbo].[TBMLREPORT051AMZN] where CompanyID=@companyID and [Year]=@nyear;
delete    FROM [EDEFTERDB].[dbo].[TBMLREPORT051BMZN] where CompanyID=@companyID and [Year]=@nyear;
delete    FROM [EDEFTERDB].[dbo].[TBMLREPORT051CMZN] where CompanyID=@companyID and [Year]=@nyear;
delete   FROM [EDEFTERDB].[dbo].[TBMLREPORT05MZN] where CompanyID=@companyID and [Year]=@nyear;
delete  FROM [EDEFTERDB].[dbo].[TBMLREPORT07MZN] where CompanyID=@companyID and [Year]=@nyear;
 delete FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn] where CompanyID=@companyID and [Year]=@nyear; 
 delete  FROM [EDEFTERDB].[dbo].[TBLMRevenueMzn] where CompanyID=@companyID and [Year]=@nyear;
   delete  FROM  [EDEFTERDB].[dbo].[TTZDashBoardOranMzn] where CompanyID=@companyID and [Year]=@nyear;
   delete  FROM  [EDEFTERDB].[dbo].[TTZDashBoardOzetLikiditeMzn] where CompanyID=@companyID and [Year]=@nyear;
  delete  FROM  TTZDashBoardOzetMaliMzn where CompanyID=@companyID and [Year]=@nyear;
  delete  FROM   [TBLKarZararByMonthMizan] where CompanyID=@companyID and [Year]=@nyear;
  delete  FROM  TBLWcapArGeGiderMizan where CompanyID=@companyID and [Year]=@nyear;
  delete  FROM  TBLWcapBrutKarZararMizan where CompanyID=@companyID and [Year]=@nyear;
  delete  FROM  TBLWcapDonemKarZararMizan where CompanyID=@companyID and [Year]=@nyear;
  delete  FROM  TBLWcapDonemKarZararNetMizan where CompanyID=@companyID and [Year]=@nyear;
  delete  FROM  TBLWcapEsasMaliyetKarZararMizan where CompanyID=@companyID and [Year]=@nyear;
  delete  FROM  TBLWcapFaaliyetKarZararMizan where CompanyID=@companyID and [Year]=@nyear;
  delete  FROM  TBLWcapFinansmanGiderMizan where CompanyID=@companyID and [Year]=@nyear;
  delete  FROM  TBLWcapGenelYonGiderMizan where CompanyID=@companyID and [Year]=@nyear;
  delete  FROM  TBLWcapNetSatisMizan where CompanyID=@companyID and [Year]=@nyear;
  delete  FROM  TBLWcapOlaganKarZararMizan where CompanyID=@companyID and [Year]=@nyear;
  delete  FROM  TBLWcapPazarlamaGiderMizan where CompanyID=@companyID and [Year]=@nyear; 
  delete  FROM  SPO_TBMLAKTARMAFrst where CompanyID=@companyID and [YEAR]=@nyear;
  delete  FROM  TBLMDONUKACCNTCHKYEAR where CompanyID=@companyID and [Year]=@nyear;  
  delete  FROM  TBLXMLSCheckpdfMizan where CompanyID=@companyID and [Year]=@nyear;";

            StaticQuery<int>(sqll, new { nyear = _year, companyID = _compID }).FirstOrDefault();

            return StaticQuery<int>("Delete FROM [TBLXMLSourceOneT] where CompanyID=@companyID and Year=@nyear ", new { nyear = _year, companyID = _compID }).FirstOrDefault();

            //return StaticQuery<int>("EXEC [dbo].[SPO_DONUKCHK] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            //SPO_COMPANYMIZANERR  SPO_DONUKCHK  SPO_COMPANYMIZANERRMZN
        }

        public static int Set_ReportSetMainSMM(int _year, long _compID)
        {
            try
            {
                return StaticQuery<int>("EXEC SPO_REPOR00GENERALTOTAL @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }

            //SPO_COMPANYMIZANERR  SPO_DONUKCHK
        }

        public static int Set_ReportSetMizanKayit(int _year, long _compID)
        {
            //

            return StaticQuery<int>("EXEC [dbo].[SPO_COMPANYMIZANERRMZN] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();

            //return StaticQuery<int>("EXEC [dbo].[SPO_DONUKCHK] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            //SPO_COMPANYMIZANERR  SPO_DONUKCHK  SPO_COMPANYMIZANERRMZN
        }

        public static int Set_ReportSetResetMizanKayit(int _year, long _compID)
        {
            //
            StaticQuery<int>("Delete FROM [SPO_TBMLAKTARMA] where [CompanyID]=@companyID and [YEAR]=@nyear ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            StaticQuery<int>("Delete FROM [TBLXMLSourceOne] where CompanyID=@companyID and Year=@nyear ", new { nyear = _year, companyID = _compID }).FirstOrDefault(); 
            return StaticQuery<int>("Delete FROM [TBLXMLSourceOneT] where CompanyID=@companyID and Year=@nyear ", new { nyear = _year, companyID = _compID }).FirstOrDefault();

            //return StaticQuery<int>("EXEC [dbo].[SPO_DONUKCHK] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            //SPO_COMPANYMIZANERR  SPO_DONUKCHK  SPO_COMPANYMIZANERRMZN
        }
        public static int Set_ReportSetResetMizanKayitMOnth(int _year, long _compID, byte _mon)
        {

            return StaticQuery<int>("Delete FROM [TBLXMLSourceOneBck] where CompanyID=@companyID and Year=@nyear and IsBeyan=0 and MainMonth=@nmonth", new { nyear = _year, companyID = _compID, nmonth= _mon }).FirstOrDefault();
        
        }
        public static List<string> GetAccountList()
        {
            return StaticQuery<string>("SELECT  Code FROM  [dbo].[MCodeZen]").ToList();
        }
        public static List<string> GetAccountListSix()
        {
            return StaticQuery<string>("SELECT  Code FROM  [dbo].[MCodeZen] where SubTypeID=6").ToList();
        }
        public static List<DashBilancoViewMizan> SET_Stat(int _year, long _compID, int _noran)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC [SPP_SMMALL] @companyID, @nyear,@noran", new { nyear = _year, companyID = _compID, noran = _noran }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_HazirDegerT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_Header__Mizan] @companyID, @nyear,10", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_HazirDeger(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow__Mizan] @companyID, @nyear,10", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_MenkulKiymetT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_Header__Mizan] @companyID, @nyear,11", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_MenkulKiymet(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow__Mizan] @companyID, @nyear,11", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TicariAlacakT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,12", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TicariAlacak(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,12", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewMizan> Get_DigerAlacakT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,13", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_DigerAlacak(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,13", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_StokT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,15", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_Stok(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,15", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_InsaatT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,17", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_Insaat(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,17", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TahakkukT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,18", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_Tahakkuk(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,18", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_DigerDonenT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,19", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_DigerDonen(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,19", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewMizan> Get_TOPLAMTUMT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_HeaderMain__Mizan @companyID, @nyear,1", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TicAlacakT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,22", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TicAlacak(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,22", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_DigerAlacak1T(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,23", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_DigerAlacak1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,23", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_MaliDuranT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,24", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_MaliDuran(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,24", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_MaddiDuranT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,25", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_MaddiDuran(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,25", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_MaddiOlmayanDuranT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,26", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_MaddiOlmayanDuran(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,26", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewMizan> Get_TabiT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,27", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_Tabi(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,27", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_Tahakkuk1T(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,28", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_Tahakkuk1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,28", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_DigerDuranT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,29", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_DigerDuran(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,29", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewMizan> Get_TOPLAM1T(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_HeaderMain__Mizan @companyID, @nyear,2", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_MaliBorcT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,30", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewMizan> Get_MaliBorc(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_GrowMaliBorc__Mizan] @companyID, @nyear,30", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TicBorcT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,32", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TicBorc(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,32", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_DigerBorcT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,33", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_DigerBorc(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,33", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_AlinanAvansT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,34", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_AlinanAvans(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,34", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_InsaatOnarimHakedisT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,35", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_InsaatOnarimHakedis(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,35", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewMizan> Get_VergiYukT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,36", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_VergiYuk(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,36", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_BorcKarslkT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,37", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_BorcKarslk(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,37", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_KTahakkukT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,38", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewMizan> Get_KTahakkuk(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,38", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_YabKaynakT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,39", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_YabKaynak(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,39", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewMizan> Get_TOPLAMT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_HeaderMain__MizanV1Byn @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewMizan> Get_MaliBorcUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,40", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewMizan> Get_MaliBorcU(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_GrowMaliBorc__Mizan] @companyID, @nyear,40", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TicBorcUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,42", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TicBorcU(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,42", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_DigerBorcUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,43", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_DigerBorcU(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,43", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_AlinanAvansUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,44", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_AlinanAvansU(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,44", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_BorcKarslkUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,47", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_BorcKarslkU(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,47", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TahakkukUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,48", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TahakkukU(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,48", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewMizan> Get_YabKaynakUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,49", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_YabKaynakU(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,49", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewMizan> Get_TOPLAMTU(int _year, long _compID)
        {


            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_HeaderMain__MizanV1Byn @companyID, @nyear,4", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_OKynkOdSermayeT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,50", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_OKynkOdSermaye(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,50", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_OKynkOdSermayeTenzil(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__MizanTenzil @companyID, @nyear,50", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_OKynkSermayeYedekT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,52", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_OKynkSermayeYedek(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,52", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_OKynkKarYedekT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,54", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_OKynkKarYedek(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow__Mizan @companyID, @nyear,54", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_PrOKynkGcmsKZT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,57", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewMizan> Get_PrOKynkGcmsKZ(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_GrowMaliBorc__Mizan] @companyID, @nyear,57", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_OKynkDonemKZT(int _year, long _compID)
        {
            
            return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_HeaderMain__Mizan590] @companyID, @nyear,59", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_OKynkDonemKZTByn(int _year, long _compID)
        {

            return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_HeaderMain__Mizan590Byn] @companyID, @nyear,59", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TOPLAMPasif(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_HeaderMizanPasif @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TOPLAMPasifBynNw(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_HeaderMizanPasifByn @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TOPLAMPasifByn(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_HeaderMizanPasifByn @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TOPLAMPasifBynNzm(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_HeaderMizanPasif @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        //public static List<DashBilancoViewMizan> Get_TOPLAMPasifBynNzm(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_HeaderMizanPasifByn1 @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        //}
        //
        public static List<DashBilancoViewMizan> Get_TOPLAMAktif(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_HeaderMizanAktif @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TOPLAMOzKaynakUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_HeaderMain__MizanT590] @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_TOPLAMOzKaynakUTbyn(int _year, long _compID)
        {
            //return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_HeaderMain__MizanT590byn1] @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).ToList();
            return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_HeaderMain__MizanT590] @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).ToList();
        }
        
        public static List<DashBilancoViewMizan> Get_TOPLAMOzKaynakUTV3(int _year, long _compID)
        {
            //return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_HeaderMain__MizanT590V3] @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).ToList();
            return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_HeaderMain__MizanT590] @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).ToList();
        }

    }
}
