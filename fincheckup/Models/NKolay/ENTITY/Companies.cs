using fincheckup.Models.AImodel;
using fincheckup.Models.Hvvn;
using fincheckup.Models.NKolay.ENTITY.Mizan;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;

namespace fincheckup.ENTITY
{ 

    public class Companies : BaseModel
    {
        public long ID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactMail { get; set; }
        public string ContactGSM { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Şehir Bilgisi Seçilmelidir ")]
        public string City { get; set; }
        public int CityID { get; set; }
        public string State { get; set; }
        public string NaceCode { get; set; }
        public string Adress { get; set; }
        public string TaxID { get; set; }
        public string TaxOffice { get; set; }
        public string Notes { get; set; }
        public int MainCompanyID { get; set; }
        public int XmlSourceID { get; set; }
        public int IsDefault { get; set; }
        public bool IsDeleted { get; set; }
        public int NaceID { get; set; }
        public string qnbUserId { get; set; }
        public string qnbCorporateId { get; set; }
        public string pidNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string mainPlatform { get; set; }
        public string applicationId { get; set; }
        public DateTime LastLogin { get; set; }
        public byte  IsEledger { get; set; }
        
        public static List<Companies> Get_ReportCompanyQnb()
        {
            string sqll = @"  Select MAX(k.LastLogin) as LastLogin,k.ID,k.TaxID,k.qnbCorporateId,k.applicationId,k.Adress,k.CompanyName,k.CreatedDate,k.ContactName,k.ContactMail,k.ContactGSM,k.qnbUserId from
 (  select ul.CreatedDate as LastLogin ,c.ID,c.TaxID,c.qnbCorporateId,c.applicationId,c.Adress,c.CompanyName,c.CreatedDate,c.ContactName,c.ContactMail,c.ContactGSM,u.qnbUserId  from  [EDEFTERDB].[dbo].[Company] c
    LEFT JOIN [EDEFTERDB].[dbo].UserCompany uc on uc.CompanyID=c.ID
   LEFT JOIN [EDEFTERDB].[dbo].[User] u on u.ID=uc.UserID
   LEFT JOIN [EDEFTERDB].[dbo].[UserLogin] ul on ul.UserID=u.ID
   
   where c.ID in(select [CompanyID]  FROM [EDEFTERDB].[dbo].[TBLXml] group by [CompanyID]) and c.ID>136 and [applicationId] is not null   )k group by  k.ID,k.TaxID,k.qnbCorporateId,k.applicationId,k.Adress,k.CompanyName,k.CreatedDate,k.ContactGSM,k.ContactMail,k.ContactName,k.qnbUserId";

            return StaticQuery<Companies>(sqll).ToList();
        }
        //ID,CompanyName,ContactName,ContactMail,ContactGSM,Adress,qnbUserId,qnbCorporateId,CreatedDate
        public static int UpdateCompanyIsEledger(byte typeId_, long _compID)
        {
            string sql = @"UPDATE [dbo].[Company] set IsEledger=@typeId   where  ID=@companyID ";
            var ttt = StaticQuery<int>(sql, new { typeId = typeId_, companyID = _compID }).FirstOrDefault();
            return ttt;
        }
        public static List<Companies> Get_LimitedCompanyQnb()
        {
            return StaticQuery<Companies>("select ID,CompanyName,ContactName,ContactMail,ContactGSM,Adress,qnbUserId,qnbCorporateId,CreatedDate from  [EDEFTERDB].[dbo].[Company] where ID>139 and (UPPER(CompanyName) like '%LIMI%' or UPPER(CompanyName) like '%LİMİ%' or UPPER(CompanyName) like '%LTD%')  order by ID desc").ToList();
        }
        public static List<Companies> Get_ASCompaniesQnb()
        {
            return StaticQuery<Companies>("select ID,CompanyName,ContactName,ContactMail,ContactGSM,Adress,qnbUserId,qnbCorporateId,CreatedDate from  [EDEFTERDB].[dbo].[Company] where ID>139 and (UPPER(CompanyName) like '%A.S%' or UPPER(CompanyName) like '%A.Ş%'or UPPER(CompanyName) like '%ANO%')   order by ID desc").ToList();
        }
        public static IEnumerable<XmlSourceTB> GetCompany_Entegrator()
        {
            //StaticQuery<int>("UPDATE   [dbo].[Company] set XmlSourceID=3 where XmlSourceID=5");
            XmlSourceTB nnew = new XmlSourceTB(1, "E-defter");
            XmlSourceTB nnew1 = new XmlSourceTB(3, "Mizan-Beyanname");
            List<XmlSourceTB> nlist = new List<XmlSourceTB> { nnew, nnew1 };
            return nlist;
        }
        public static IEnumerable<Companies> Get_ConsoleAll(long ide)
        {
            return StaticQuery<Companies>("SELECT Company.* ,Cities.City  FROM [dbo].[Company] LEFT JOIN Cities on Company.CityID = Cities.ID  where  Company.MainCompanyID=@ID", new { ID = ide });
        }
        public static IEnumerable<Companies> UpdateStat_Console(long ide)
        {
            return StaticQuery<Companies>("UPDATE   [dbo].[Company] set MainCompanyID=0 where ID=@ID", new { ID = ide });
        }
        public static Companies Get_Company(long ide)
        {
            return StaticQuery<Companies>("SELECT Company.* ,Cities.City  FROM [dbo].[Company] LEFT JOIN Cities on Company.CityID = Cities.ID  where  Company.ID=@ID", new { ID = ide }).FirstOrDefault();
        }
        public static Companies Get_CompanyRow(long ide)
        {
            return StaticQuery<Companies>("SELECT *  FROM [dbo].[Company] where ID=@ID", new { ID = ide }).FirstOrDefault();
        }
        public static IEnumerable<int> Get_CompanyReportYear(long ide)
        {
            //SELECT    DISTINCT([Year])         FROM [EDEFTERDB].[dbo].[TBMLREPOR01] where  CompanyID=@ID
            return StaticQuery<int>("SELECT    DISTINCT([Year])         FROM [EDEFTERDB].[dbo].[TBMLREPOR01] where  CompanyID=@ID and TypeID=11 and TumYil is not null", new { ID = ide }).ToList();
        }
        public static  int  Get_CompanyReportMaxYear(long ide)
        {
            return StaticQuery<int>("SELECT    DISTINCT([Year])         FROM [EDEFTERDB].[dbo].[TBMLREPOR01] where  CompanyID=@ID and TypeID=11 and TumYil is not null", new { ID = ide }).FirstOrDefault();
        }
        public static List<int> Get_CompanyReportYearMain(long ide)
        {
            return StaticQuery<int>("SELECT DISTINCT([Year]) from  [TBLXml] where CompanyID=@ID  and MONTH([DocumentDate])>2 ", new { ID = ide }).ToList();
        }
        public static List<int> Get_CompanyReportYearMainReport(long ide)
        {
            return StaticQuery<int>("SELECT DISTINCT([Year]) from  [TBLXml] where CompanyID=@ID and MONTH([DocumentDate])=12", new { ID = ide }).ToList();
        }
        public static List<int> Get_CompanyReportYearMainMizanReport(long ide)
        {
            return StaticQuery<int>("SELECT DISTINCT([Year]) from  [TBLMizan] where CompanyID=@ID and MainMonth=12", new { ID = ide }).ToList();
        }
        public static List<int> Get_CompanyReportYearMainMizan(long ide)
        {
            return StaticQuery<int>("SELECT  DISTINCT([Year])  FROM  [dbo].TBLMSampleBlncoMzn where CompanyID=@ID ", new { ID = ide }).ToList();
        }
        public static float Get_ReportREELPUAN(long ide)
        {
            return StaticQuery<float>("Select SUM(REELPUAN) FROM  [dbo].[TBLMQnbReportRatioView] where CompanyID=@ID ", new { ID = ide }).FirstOrDefault();
        }
        //  Select SUM([AreaValue])-SUM([SectorValue])FROM [EDEFTERDB].[dbo].[TBLMQnbReportRatioView] where CompanyID=9 and SectorValue<>0
        public static float Get_ReportTrendSectorPerc(long ide)
        {
            return StaticQuery<float>(" Select CASE WHEN ISNULL(SUM([SectorValue]),0)=0 then 0 else (ISNULL(SUM([AreaValue]),0)/ISNULL(SUM([SectorValue]),0)) *100 end FROM [EDEFTERDB].[dbo].[TBLMQnbReportRatioView] where CompanyID=@ID  and SectorValue<>0", new { ID = ide }).FirstOrDefault();
        }
        public static float Get_ReportSectorTrendPerc(long ide)
        {
            return StaticQuery<float>("Select CASE WHEN ISNULL(SUM([AreaValue]),0)=0 then 0 else (ISNULL(SUM([SectorValue]),0)/ISNULL(SUM([AreaValue]),0))*100 end FROM [EDEFTERDB].[dbo].[TBLMQnbReportRatioView] where CompanyID=@ID  and SectorValue<>0", new { ID = ide }).FirstOrDefault();
        }
        public static List<RepUstKalemPuan> Get_UstKalemPuan(long ide)
        {
            return StaticQuery<RepUstKalemPuan>(" Select MainID,[USTKALEMPUAN]  FROM [EDEFTERDB].[dbo].[TBLMQnbReportRatioView] where CompanyID=@ID  and [MainID]<>111 group by  MainID,[USTKALEMPUAN]", new { ID = ide }).ToList();
        }
        public static int Get_LastTCMBReportYear()
        {
            return StaticQuery<int>("SELECT TOP 1 [YIL]   FROM [EDEFTERDB].[dbo].[TBLF11NAKITORAN] order by YIL desc").FirstOrDefault();
        }
        public static List<int> Get_CompanyReportYearFull(long ide)
        {
            return StaticQuery<int>("SELECT top 4  [Year]  from  [TBLXml] where CompanyID=@ID group by [Year]  order by [Year] desc ", new { ID = ide }).ToList();
        }
        public static List<int> Get_CompanyReportYearFullMizan(long ide)
        {
            return StaticQuery<int>("SELECT top 4  [Year]  from  [TBLMizan] where CompanyID=@ID group by [Year]  order by [Year] desc ", new { ID = ide }).ToList();
        }
        public static CompanyReportView Get_CompanyReportView(long ide)
        {
            return StaticQuery<CompanyReportView>(" SELECT t.[CompanyName]   , t.[NaceID] , o.Code, o.[Description], o.MainDescription FROM [EDEFTERDB].[dbo].[Company] t LEFT JOIN NACECODEMain o on t.NaceID= o.ID where t.ID=@ID", new { ID = ide }).FirstOrDefault();
        }

        //( Select MAX(LastMonth) FROM   [dbo].[TBLMRevenueRast] where [CompanyID]=@CompID and [Year]=@year )  SELECT  top 1 [CompanyID]   FROM [EDEFTERDB].[dbo].[UserCompany] where UserID=9999 and IsDefault=1

        public static int  DataReportMainLastMonth(int _year, long _compID)
        { 
            string sql = @"Select ISNULL(MAX(LastMonth),0) FROM   [dbo].[TBLMRevenueRast] where [CompanyID]=@companyID and [Year]=@nyear";
            int ttt = StaticQuery<int>(sql, new { nyear = _year, companyID = _compID }).FirstOrDefault();

            if (ttt == 0) {
                 sql = @"SELECt  ISNULL(MAX([MainMonth]),0)   FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneBck]  where [CompanyID]=@companyID and [Year]=@nyear";
                 ttt = StaticQuery<int>(sql, new { nyear = _year, companyID = _compID }).FirstOrDefault();
                
            }
             
            return ttt;
        }
        public static int DataReportMainNace(string _nace, long _compID)
        {
            string sql = @"UPDATE [dbo].[Company] set NaceID=@nnace ,NaceCode=(Select ManCode from NACECODEMain where ID=@nnace) where  ID=@companyID ";
            var ttt = StaticQuery<int>(sql, new { nnace = _nace, companyID = _compID }).FirstOrDefault();
            return ttt;
        }
        public static IEnumerable<Companies> Get_All()
        {
            return StaticQuery<Companies>("SELECT Company.* ,Cities.City  FROM [dbo].[Company] LEFT JOIN Cities on Company.CityID = Cities.ID");
        }
        public static   Companies Get_CompanybyUserDefault(long ide)
        {
            return StaticQuery<Companies>("SELECT *  FROM [dbo].[Company]    where   ID=(sELECT  top 1 [CompanyID]   FROM [EDEFTERDB].[dbo].[UserCompany] where UserID=@ID and IsDefault=1)", new { ID = ide }).FirstOrDefault();
        }
        //( Select MAX(LastMonth) FROM   [dbo].[TBLMRevenueRast] where [CompanyID]=@CompID and [Year]=@year )  SELECT  top 1 [CompanyID]   FROM [EDEFTERDB].[dbo].[UserCompany] where UserID=9999 and IsDefault=1
        public static IEnumerable<Companies> Get_CompanyNames(long ide)
        {
            return StaticQuery<Companies>("SELECT Company.* ,Cities.City  FROM [dbo].[Company] LEFT JOIN Cities on Company.CityID = Cities.ID  where  ID=@ID", new { ID = ide });
        }
        public static IEnumerable<Companies> Get_CompanyNamesT(long ide)
        {
            return StaticQuery<Companies>("SELECT Company.* ,Cities.City  FROM [dbo].[Company] LEFT JOIN Cities on Company.CityID = Cities.ID  where  MainCompanyID=@ID", new { ID = ide });
        }
        public static IEnumerable<Companies> Getby_User(long ide)
        {
            //string sql = @"SELECT t.ID,t.CompanyName ,c.City,u.IsDefault  FROM [dbo].[Company] as t LEFT JOIN Cities as c on t.CityID = c.ID  JOIN UserCompany as u on t.ID=u.CompanyID where u.UserID=@userid";

            return StaticQuery<Companies>("SELECT t.ID,t.CompanyName ,t.NaceID,t.TaxID ,t.NaceCode  ,c.City,u.IsDefault  FROM [dbo].[Company] as t LEFT JOIN Cities as c on t.CityID = c.ID  JOIN UserCompany as u on t.ID=u.CompanyID where u.UserID=@userid", new { userid = ide });
        }
        public static List<DashMizanResult> GetCompanyAktarmaResult(long ide , int yeare_)
        {
            return StaticQuery<DashMizanResult>("SELECT [Message] as Description, [Value] as Amount      FROM [EDEFTERDB].[dbo].[SPO_TBMLAKTARMA] where [IsChecked]=1 and [Value]!=0 and  [CompanyID]=@comid  and [YEAR]=@year", new { comid = ide, year = yeare_ }).ToList();
        }
        public static List<DashMizanResult> GetCompanyAktarmaDonuk(long ide, int yeare_)
        {
            return StaticQuery<DashMizanResult>("SELECT AccountSubDescription as Description , Amount     FROM [EDEFTERDB].[dbo].TBLMDONUKACCNTCHKYEAR where   [CompanyID]=@comid   and [YEAR]=@year", new { comid = ide, year = yeare_ }).ToList();
        }
        public static List<int> GetCompanyAktarma(long ide)
        { 
            return StaticQuery<int>("SELECT DISTINCT([YEAR])  FROM [EDEFTERDB].[dbo].[SPO_TBMLAKTARMA] where  [CompanyID]=@comid ", new { comid = ide }).ToList();
        }
        public static IEnumerable<CsvDynamic> GetDynamic(long ide,int type_)
        { 

            return StaticQuery<CsvDynamic>("EXEC SA_GetCompanyReportCsv @companyID,@type", new { companyID = ide, type=type_ });
        }
        public static IEnumerable<CsvDynamicII> GetDynamicII(long ide, int type_)
        {

            return StaticQuery<CsvDynamicII>("EXEC SA_GetCompanyReportCsv @companyID,@type", new { companyID = ide, type = type_ });
        }

        public static IEnumerable<CsvDynamicIII> GetDynamicIII(long ide, int type_)
        {

            return StaticQuery<CsvDynamicIII>("EXEC SA_GetCompanyReportCsv @companyID,@type", new { companyID = ide, type = type_ });
        }
        public static IEnumerable<CsvDynamicIIII> GetDynamicIIII(long ide, int type_)
        {

            return StaticQuery<CsvDynamicIIII>("EXEC SA_GetCompanyReportCsv @companyID,@type", new { companyID = ide, type = type_ });
        }
        public void Save_Company()
        {
            string sql = @"  INSERT INTO [Company]
          (  
        [CompanyName] ,
        [ContactName] ,
        [ContactMail] ,
        [ContactGSM] ,
        [CityID] ,
        [State] ,
        [Adress] ,
        [TaxID] ,
        [TaxOffice] ,
        [Notes] ,NaceCode,
        MainCompanyID,XmlSourceID
          ) 
           VALUES 
         (  
        @CompanyName ,
        @ContactName ,
        @ContactMail ,
        @ContactGSM ,
        @CityID ,
        @State ,
        @Adress ,
        @TaxID ,
        @TaxOffice ,
        @Notes ,@NaceCode,
        @MainCompanyID,@XmlSourceID

         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<int>(sql, this).FirstOrDefault();

            List<int> userMaterID = HhvnUsers.Get_AllMAsters();
            UserCompany nusercomp = new UserCompany();
            foreach (var item in userMaterID)
            {
                nusercomp = new UserCompany();
                nusercomp.CompanyID = this.ID;
                nusercomp.UserID = item;
                nusercomp.IsDefault = 0;
                nusercomp.Save_User();
            }

        }

        public bool Update_Company()
        {
            try
            {
                string sql = "UPDATE   [Company] SET    [CompanyName]=@CompanyName , [ContactName]=@ContactName , [ContactMail]=@ContactMail , [ContactGSM]=@ContactGSM , [CityID]=@CityID , [State]=@State , [Adress]=@Adress , [TaxID]=@TaxID , [TaxOffice]=@TaxOffice , [Notes]=@Notes,XmlSourceID=@XmlSourceID,NaceCode=@NaceCode  WHERE [ID]=@ID";
                Execute(sql, this);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public static Companies Get_CompanybyTax(string ide)
        {
            return StaticQuery<Companies>("SELECT  *  FROM  [Company]    where  TaxID=@ID", new { ID = ide }).FirstOrDefault();
        }
    }

    public class XmlSourceTB
    {
        public int ID { get; set; }
        public string XmlSource { get; set; }
        public XmlSourceTB(int Id, string XmlSource_) { ID = Id; XmlSource = XmlSource_; }
    }

    public class RepUstKalemPuan
    {
        public int MainID { get; set; }
        public float USTKALEMPUAN { get; set; }
    }


    public class CompanyReportView
    {
        public string Code { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string MainDescription { get; set; }
    }



}