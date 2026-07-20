using EINvoice.New;
using fincheckup.Models.ViewM;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay.ViewM
{
    public class DashBilancoSetQnbGelir : BaseModel
    {
        public static List<DashBilancoViewQnb> Get_1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,97", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_3(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,99", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_5(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,101", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewQnb> Get_7(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,103", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_9(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,105", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_11(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbSatisMaliyet] @companyID, @nyear,107", new { nyear = _year, companyID = _compID }).ToList();
        }
    }

    public class DashBilancoSetQnbGelirA : BaseModel
    {
        public static List<DashBilancoViewQnb> Get_1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbSubTypeBrut] @companyID, @nyear,109", new { nyear = _year, companyID = _compID }).ToList();
        }
    }
    public class DashBilancoSetQnbGelirB : BaseModel
    {
        public static List<DashBilancoViewQnb> Get_1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbFaaliyet] @companyID, @nyear,111", new { nyear = _year, companyID = _compID }).ToList();

        }
        public static List<DashBilancoViewQnb> Get_3(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbSubTypEsasFaaliyet] @companyID, @nyear,113", new { nyear = _year, companyID = _compID }).ToList();
        }
    }
    public class DashBilancoSetQnbGelirC : BaseModel
    {
        public static List<DashBilancoViewQnb> Get_1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbFinansman] @companyID, @nyear,115", new { nyear = _year, companyID = _compID }).ToList();
        }
    }
    public class DashBilancoSetQnbGelirD : BaseModel
    {
        public static List<DashBilancoViewQnb> Get_1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,117", new { nyear = _year, companyID = _compID }).ToList();
        }
    }
    public class DashBilancoSetQnbGelirE : BaseModel
    {
        public static List<DashBilancoViewQnb> Get_1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbSubTypeDigerFaaliyet] @companyID, @nyear,119", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_3(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,121", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_5(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,123", new { nyear = _year, companyID = _compID }).ToList();
        }
    }
    public class DashBilancoSetQnbGelirF : BaseModel
    {
        public static List<DashBilancoViewQnb> Get_1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbSubTypeVergionce] @companyID, @nyear,125", new { nyear = _year, companyID = _compID }).ToList();
        }
    }
    public class DashBilancoSetQnbGelirG : BaseModel
    {
        public static List<DashBilancoViewQnb> Get_1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbSubTypeOlaganDisi] @companyID, @nyear,127", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_3(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,129", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_5(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,131", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_7(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,132", new { nyear = _year, companyID = _compID }).ToList();
        }
    }
    public class DashBilancoSetQnbGelirH : BaseModel
    {
        public static List<DashBilancoViewQnb> Get_1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbSubTypeDonemKar] @companyID, @nyear,133", new { nyear = _year, companyID = _compID }).ToList();
        }
    }
    public class DashBilancoSetQnbGelirI : BaseModel
    {
        public static List<DashBilancoViewQnb> Get_1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_QnbRepor27Ebitda] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> SetSektor(int _year, long _compID)
        {
            var chk = StaticQuery<DashBilancoViewQnb>("EXEC [SP_QnbReporALL] @companyID, @nyear ", new { nyear = _year, companyID = _compID }).ToList();
            StaticQuery<int>(" update  [EDEFTERDB].[dbo].[TBLXml] set  [IsReported]=1 where CompanyID=@companyID and Year=@nyear ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            //    
            StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbRATIO0ALL] @companyID ", new { companyID = _compID }).ToList();
            StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbRATIOChartAll] @companyID ", new { companyID = _compID }).ToList();
            StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbRATIOChrtLat] @companyID  ", new { companyID = _compID }).ToList();
            StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbReportLat] @companyID  ", new { companyID = _compID }).ToList();
            return chk;
        }
        public static List<DashBilancoViewQnb> SetSektorMizan(int _year, long _compID)
        {
            var chk = StaticQuery<DashBilancoViewQnb>("EXEC [SP_QnbReporALL] @companyID, @nyear ", new { nyear = _year, companyID = _compID }).ToList();
            StaticQuery<int>(" update  [EDEFTERDB].[dbo].[TBLMizan] set  [IsReported]=1 where CompanyID=@companyID and Year=@nyear ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            //    
            StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbRATIO0ALL] @companyID ", new { companyID = _compID }).ToList();
            StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbRATIOChartAll] @companyID ", new { companyID = _compID }).ToList();
            StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbRATIOChrtLat] @companyID  ", new { companyID = _compID }).ToList();
            StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbReportLatMizan] @companyID  ", new { companyID = _compID }).ToList();
            return chk;
        }
    }
    public class DashBilancoSetQnb : BaseModel
    {
        public static List<DashBilancoViewQnb> Get_HazirDegerT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,1", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_MenkulKiymetT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_TicariAlacakT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,5", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewQnb> Get_AlicilarT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,7", new { nyear = _year, companyID = _compID }).ToList();
        } 
        public static List<DashBilancoViewQnb> Get_AlinanCeklerT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,9", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_SupheliTicariT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,11", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_StoklarT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,13", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_HammaddeT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,15", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_YariMamulT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,17", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_TicariMalT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,19", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewQnb> Get_VerilenSiparisT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,21", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_insaatT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,23", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_OrtakalacakT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,25", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_DigerAlacakT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,27", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_GelecekAyT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,29", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_DigerDonenT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,31", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_Toplam(int _year, long _compID)
        {
            List<DashBilancoViewQnb> nnnn = StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnbSubType @companyID, @nyear,1", new { nyear = _year, companyID = _compID }).ToList();
            if (nnnn == null)
            {
                nnnn = new List<DashBilancoViewQnb>();
                DashBilancoViewQnb ll = new DashBilancoViewQnb();
                nnnn.Add(ll);
            }

            return nnnn;
        }
    }

    public class DashBilancoSetQnbA : BaseModel
    {
        public static List<DashBilancoViewQnb> Get_1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,33", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_2(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,35", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_3(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,37", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewQnb> Get_4(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,39", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_5(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,41", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_6(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,43", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_7(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,45", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_8(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,47", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewQnb> Get_Toplam(int _year, long _compID)
        {
            List<DashBilancoViewQnb> nnnn = StaticQuery<DashBilancoViewQnb>("EXEC  SP_Main_Grow_HeaderQnbSubType @companyID, @nyear,2", new { nyear = _year, companyID = _compID }).ToList();

            if (nnnn == null)
            {
                nnnn = new List<DashBilancoViewQnb>();
                DashBilancoViewQnb ll = new DashBilancoViewQnb();
                nnnn.Add(ll);
            }

            return nnnn;
        }
        public static List<DashBilancoViewQnb> Get_ToplamA(int _year, long _compID)
        {
            List<DashBilancoViewQnb> nnnn = StaticQuery<DashBilancoViewQnb>("EXEC  SP_Main_Grow_HeaderQnbSubTypeA @companyID, @nyear,2", new { nyear = _year, companyID = _compID }).ToList();

            if (nnnn == null)
            {
                nnnn = new List<DashBilancoViewQnb>();
                DashBilancoViewQnb ll = new DashBilancoViewQnb();
                nnnn.Add(ll);
            }

            return nnnn;
        }

    }
    public class DashBilancoSetQnbB : BaseModel
    {
        public static List<DashBilancoViewQnb> Get_1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,49", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_2(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,51", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_3(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,53", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewQnb> Get_4(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,55", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_5(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,57", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_6(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,59", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_7(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,61", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_8(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,63", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_9(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,65", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_10(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,67", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewQnb> Get_11(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,69", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_12(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,71", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_13(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,711", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_Toplam(int _year, long _compID)
        {
            List<DashBilancoViewQnb> nnnn = StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnbSubType @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).ToList();


            if (nnnn == null)
            {
                nnnn = new List<DashBilancoViewQnb>();
                DashBilancoViewQnb ll = new DashBilancoViewQnb();
                nnnn.Add(ll);
            }

            return nnnn;
        }

    }

    public class DashBilancoSetQnbC : BaseModel
    {
        public static List<DashBilancoViewQnb> Get_1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,73", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_2(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,75", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_3(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,77", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewQnb> Get_4(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,79", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_5(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,81", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_6(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,83", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_7(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,85", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewQnb> Get_Toplam(int _year, long _compID)
        {
            List<DashBilancoViewQnb> nnnn = StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnbSubType @companyID, @nyear,4", new { nyear = _year, companyID = _compID }).ToList();

            if (nnnn == null)
            {
                nnnn = new List<DashBilancoViewQnb>();
                DashBilancoViewQnb ll = new DashBilancoViewQnb();
                nnnn.Add(ll);
            }

            return nnnn;
        }
    }

    public class DashBilancoSetQnbD : BaseModel
    {
        public static List<DashBilancoViewQnb> Get_1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,87", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_2(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,89", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_3(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,91", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewQnb> Get_4(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,93", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewQnb> Get_5(int _year, long _compID)
        {

            List<DashBilancoViewQnb> nlist = StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,95", new { nyear = _year, companyID = _compID }).ToList();

            if (nlist==null || nlist[0].Amount==0)
            {
                
                    List<DashBilancoViewQnb> nlist1 = StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbSubTypeDonemKar] @companyID, @nyear,95", new { nyear = _year, companyID = _compID }).ToList();

                if (nlist1 == null || nlist1[0].Amount != 0)
                {
                    string sqll = @"  IF NOT EXISTS (select top 1 * from [TBLXMLSourceOne] where AccountMainID='590' and CompanyID=@companyID and [Year]=@nyear)
   BEGIN
       INSERT INTO [dbo].[TBLXMLSourceOne] ([TypeID] ,[AccountMainID] ,[AccountMainDescription] ,[AccountMainEng] ,[Amount] ,[DebitCreditCode] ,[CompanyID] ,[AmountBakiye] ,[Year] ,[SubTypeID] ,[MainTypeID] ,[IsNegative] ,[IsErrored] ,[MainAmountTotal] ,[Debit] ,[Credit]) select top 1 [TypeID] ,[AccountMainID] ,[AccountMainDescription] ,[AccountMainEng] ,@amount ,[DebitCreditCode] ,@companyID ,@amount *-1  ,@nyear ,[SubTypeID] ,[MainTypeID] ,[IsNegative] ,[IsErrored] ,@amount ,0 ,0 from [TBLXMLSourceOne] where AccountMainID='590' order by ID desc
   END
   ELSE
   BEGIN
   UPDATE TBLXMLSourceOne set AmountBakiye=@amount *-1,Amount=@amount,MainAmountTotal=@amount  where AccountMainID='590' and CompanyID=@companyID and [Year]=@nyear
   END";
                     StaticQuery<DashBilancoViewQnb>(sqll, new { nyear = _year, companyID = _compID, amount= nlist1[0].Amount }).ToList();
                    return nlist1;
                }
                else
                {
                    return nlist1;
                }
                //INSERT INTO [dbo].[TBLXMLSourceOne] ([TypeID] ,[AccountMainID] ,[AccountMainDescription] ,[AccountMainEng] ,[Amount] ,[DebitCreditCode] ,[CompanyID] ,[AmountBakiye] ,[Year] ,[SubTypeID] ,[MainTypeID] ,[IsNegative] ,[IsErrored] ,[MainAmountTotal] ,[Debit] ,[Credit]) select top 1 [TypeID] ,[AccountMainID] ,[AccountMainDescription] ,[AccountMainEng] ,@amount ,[DebitCreditCode] ,@companyID ,@amount*-1 ,@year ,[SubTypeID] ,[MainTypeID] ,[IsNegative] ,[IsErrored] ,@amount ,0 ,0 from [TBLXMLSourceOne] where AccountMainID='590' order by ID desc
            }
            else
            {
                return nlist;
            }

            
        }

        public static List<DashBilancoViewQnb> Get_Toplam(int _year, long _compID)
        {
            List<DashBilancoViewQnb> nnnn = StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnbSubType @companyID, @nyear,5", new { nyear = _year, companyID = _compID }).ToList();
            if (nnnn == null)
            {
                nnnn = new List<DashBilancoViewQnb>();
                DashBilancoViewQnb ll = new DashBilancoViewQnb();
                nnnn.Add(ll);
            }

            return nnnn;


        }
        public static List<DashBilancoViewQnb> Get_ToplamA(int _year, long _compID)
        {
            List<DashBilancoViewQnb> nnnn = StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnbSubTypeB @companyID, @nyear,5", new { nyear = _year, companyID = _compID }).ToList();

            if (nnnn == null)
            {
                nnnn = new List<DashBilancoViewQnb>();
                DashBilancoViewQnb ll = new DashBilancoViewQnb();
                nnnn.Add(ll);
            }

            return nnnn;

        }
        public static List<DashBilancoViewQnb> Get_ToplamB(int _year, long _compID)
        {
            List<DashBilancoViewQnb> nnnn = StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnbSubTypeC @companyID, @nyear,5", new { nyear = _year, companyID = _compID }).ToList();

            if (nnnn == null)
            {
                nnnn = new List<DashBilancoViewQnb>();
                DashBilancoViewQnb ll = new DashBilancoViewQnb();
                nnnn.Add(ll);
            }

            return nnnn;


        }
    }
    public class DashBilancoSet : BaseModel
    {
        public static List<DashBilancoView> Get_HazirDegerT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC [SP_Main_Grow_Header] @companyID, @nyear,10", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_HazirDeger(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC [SP_Main_Grow] @companyID, @nyear,10", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_MenkulKiymetT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC [SP_Main_Grow_Header] @companyID, @nyear,11", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_MenkulKiymet(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC [SP_Main_Grow] @companyID, @nyear,11", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TOPLAMAktif(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_HeaderMainAktif @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TicariAlacakT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,12", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TicariAlacak(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,12", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_DigerAlacakT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,13", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_DigerAlacak(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,13", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_StokT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,15", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_Stok(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,15", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_InsaatT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,17", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_Insaat(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,17", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TahakkukT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,18", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_Tahakkuk(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,18", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_DigerDonenT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,19", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_DigerDonen(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,19", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TOPLAMTUMT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_HeaderMain @companyID, @nyear,1", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TicAlacakT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,22", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TicAlacak(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,22", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_DigerAlacak1T(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,23", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_DigerAlacak1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,23", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_MaliDuranT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,24", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_MaliDuran(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,24", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_MaddiDuranT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,25", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_MaddiDuran(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,25", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_MaddiOlmayanDuranT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,26", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_MaddiOlmayanDuran(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,26", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_TabiT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,27", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_Tabi(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,27", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_Tahakkuk1T(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,28", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_Tahakkuk1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,28", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_DigerDuranT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,29", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_DigerDuran(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,29", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_TOPLAM1T(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_HeaderMain @companyID, @nyear,2", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_MaliBorcT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,30", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_MaliBorc(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC [SP_Main_GrowMaliBorc] @companyID, @nyear,30", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TicBorcT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,32", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TicBorc(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,32", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_DigerBorcT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,33", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_DigerBorc(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,33", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_AlinanAvansT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,34", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_AlinanAvans(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,34", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_InsaatOnarimHakedisT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,35", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_InsaatOnarimHakedis(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,35", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_VergiYukT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,36", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_VergiYuk(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,36", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_BorcKarslkT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,37", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_BorcKarslk(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,37", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_KTahakkukT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,38", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_KTahakkuk(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,38", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_YabKaynakT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,39", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_YabKaynak(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,39", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TOPLAMT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_HeaderMainV1 @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_MaliBorcUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,40", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_MaliBorcU(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC [SP_Main_GrowMaliBorc] @companyID, @nyear,40", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TicBorcUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,42", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TicBorcU(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,42", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_DigerBorcUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,43", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_DigerBorcU(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,43", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_AlinanAvansUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,44", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_AlinanAvansU(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,44", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_BorcKarslkUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,47", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_BorcKarslkU(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,47", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TahakkukUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,48", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TahakkukU(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,48", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_YabKaynakUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,49", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_YabKaynakU(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,49", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TOPLAMTU(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_HeaderMainV1 @companyID, @nyear,4", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_OKynkOdSermayeT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,50", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_OKynkOdSermaye(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,50", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_OKynkSermayeYedekT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,52", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_OKynkSermayeYedek(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,52", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_OKynkKarYedekT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,54", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_OKynkKarYedek(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow @companyID, @nyear,54", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_PrOKynkGcmsKZT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,57", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_PrOKynkGcmsKZ(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC [SP_Main_GrowMaliBorc] @companyID, @nyear,57", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_OKynkDonemKZT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,59", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_TOPLAMOzKaynakUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_HeaderMainT @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TOPLAMPasif(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_HeaderMainPasif @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
    }
}
