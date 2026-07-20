using fincheckup.Models.NKolay.ENTITY.NwEntity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace fincheckup.ENTITY
{
    public class TBLXmlFile : BaseModel
    {
        public long ID { get; set; }
        public long TBLXmlID { get; set; }
        public string CsvName { get; set; }
        public string Test { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte Issetted { get; set; }
        public byte IsFinished { get; set; }

        public int SortID { get; set; }
        public int LastSettedCount { get; set; }
        public static TBLXmlFile GetNewFile()
        {
            return StaticQuery<TBLXmlFile>("UPDATE [TBLXmlFile]  SET IsSetted = 1 OUTPUT Inserted.* WHERE ID = (Select top 1 ID from [TBLXmlFile] where IsSetted = 0)").FirstOrDefault();
        }
        public static bool GetNewFileBool()
        {
            return StaticQuery<bool>("SELECT CASE WHEN EXISTS (Select top 1 ID from [TBLXmlFile] where IsSetted = 0) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END").FirstOrDefault();
        }
        public static IEnumerable<TBLXmlFile> Get_TBLXmlIDlist(long ide)
        {
            return StaticQuery<TBLXmlFile>("Select * From [TBLXmlFile] where TBLXmlID=@ID order by SortID", new { ID = ide });
        }
        public static IEnumerable<int> Get_UploadedYears(long ide)
        {
            return StaticQuery<int>("SELECT DISTINCT(YEAR([DocumentDate])) FROM [EDEFTERDB].[dbo].[TBLXml] where [CompanyID]=@ID", new { ID = ide });
        }
        public static IEnumerable<int> Get_UploadedYearsMizan(long ide)
        {
            return StaticQuery<int>("SELECT DISTINCT([Year]) FROM [EDEFTERDB].[dbo].[TBLMizan] where [CompanyID]=@ID", new { ID = ide });
        }
        //SELECT DISTINCT([Year] )   FROM [EDEFTERDB].[dbo].[TBLMizan] where [CompanyID]=10

        public static TBLXmlFile Get_TBLXmlFile(long ide, int sortid_)
        {
            return StaticQuery<TBLXmlFile>("Select top 1 *,(Select Count(*)  From [TBLXmlFile] where TBLXmlID=@ID and Issetted=0) as LastSettedCount From [TBLXmlFile] where TBLXmlID=@ID and SortID=@sortid", new { ID = ide, sortid = sortid_ }).FirstOrDefault();
        }
        public static IEnumerable<TBLXmlFile> _SetFirstSetted(long ide)
        {
            return StaticQuery<TBLXmlFile>("UPDATE  [TBLXmlFile] set Issetted=1 where ID=(Select top 1  ID  from [TBLXmlFile] where TBLXmlID=@ID order by ID asc) ", new { ID = ide });
        }
        public static List<TBLXMLSourceRow> getSettedXml(long ide,long docid)
        {

            string sqll = @"SELECT *
FROM dbo.TBLXMLSource WITH (NOLOCK)
WHERE CsvID = @csvvID
  AND CompanyDocumentId = @companyDocumentId
  AND IsOpener=0 ";
            return StaticQuery<TBLXMLSourceRow>(sqll, new { csvvID = ide , companyDocumentId = docid }).ToList();
        }
        public static List<TBLErrzoneInsideWordRow> getWordXml()
        {

            string sqll = @"SELECT  [ID]
      ,[ErrorInsideID]
      ,[Description]
  FROM [EDEFTERDB].[dbo].[TBLErrzoneInsideWord]";
            return StaticQuery<TBLErrzoneInsideWordRow>(sqll).ToList();
        }
        public static List<WzoneRow> getXmlList()
        {

            string sqll = @"SELECT ID, MainDescriptionID, MainDescription
FROM dbo.TBLWzone  ";
            return StaticQuery<WzoneRow>(sqll ).ToList();
        }
        public static int Delete_TBLXmlIDlist(long ide)
        {
            return StaticQuery<int>("Delete From [TBLXmlFile] where TBLXmlID=@ID ", new { ID = ide }).FirstOrDefault();
        }
        public void Save_TBLXmlFile()
        {
            string sql = @"  INSERT INTO [TBLXmlFile]
        ([CsvName] ,[TBLXmlID],SortID) 
           VALUES 
         (@CsvName,@TBLXmlID,@SortID)  ;select  Cast(SCOPE_IDENTITY() as Int) ";



            this.ID = Query<long>(sql, this).FirstOrDefault();
        }
        public bool Finish_TBLXmlFile()
        {
            try
            {
                string sql = "UPDATE   [TBLXmlFile] SET     [IsFinished]=1  WHERE [ID]=@ID";
                Execute(sql, this);
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool Update_TBLXmlFile()
        {
            try
            {
                string sql = "UPDATE   [TBLXmlFile] SET     [Issetted]=1  WHERE [ID]=@ID";
                Execute(sql, this);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
    public class TBLXml : BaseModel
    {

        public long ID { get; set; }
        public string CsvName { get; set; }
        public long CompanyID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DocumentDate { get; set; }
        public int Year { get; set; }
        public string XmlDocName { get; set; }

        public static IEnumerable<TBLXml> Get_TBLXml()
        {
            return StaticQuery<TBLXml>("Select * From [TBLXml]");
        }
        public static int GetComapnyIDByMonth(long compide, int monide, int yearide)
        {
            return StaticQuery<int>("Select ID From [TBLXml] where CompanyID=@ID and Year=@year and MONTH(DocumentDate)=@mon", new { ID = compide, year = yearide, mon = monide }).FirstOrDefault();
        }
        public static int GetMiissingByMonth(long compide)
        {
            return StaticQuery<int>("EXEC S_PCountMissing @compid", new { compid = compide}).FirstOrDefault();
        }
        public static int DeleteComapnyIDByMonth(long compide, int yearide, int monide)
        {
            StaticQuery<int>("DELETE From [TBLXMLSource] where CsvID in (Select ID From [TBLXml] where CompanyID=@ID and Year=@year and MONTH(DocumentDate)=@mon) ", new { ID = compide, year = yearide, mon = monide }).FirstOrDefault();
            return StaticQuery<int>("DELETE From [TBLXml] where CompanyID=@ID and Year=@year and MONTH(DocumentDate)=@mon", new { ID = compide, year = yearide, mon = monide }).FirstOrDefault();
        }
        public static int GetComapnyIDByMonthCount(long compide, int monide, int yearide)
        {
            return StaticQuery<int>("Select Count(ID) From [TBLXml] where CompanyID=@ID and Year=@year and MONTH(DocumentDate)=@mon", new { ID = compide, year = yearide, mon = monide }).FirstOrDefault();
        }
        public static int RESET_TBLXmlUpdate(long ide)
        {
            return StaticQuery<int>("EXEC RESETALL_byCSVIDUpdate @CsvID", new { CsvID = ide }).FirstOrDefault();
        }
        public static IEnumerable<TBLXml> Get_TBLXmlCompany(string ide)
        {
            return StaticQuery<TBLXml>("Select * From [TBLXml] where CompanyID=@ID ", new { ID = ide });
        }
        public static TBLXml GetRow_TBLXml(string ide)
        {
            return StaticQuery<TBLXml>("Select * From [TBLXml] where ID=@ID ", new { ID = ide }).FirstOrDefault();
        }
        public static int GetYearByComapnyID(long ide)
        {
            return StaticQuery<int>("Select COUNT(DISTINCT(Year)) From [TBLXml] where CompanyID=@ID ", new { ID = ide }).FirstOrDefault();
        }
        public static int GetYearByComapnyIDMizan(long ide)
        {
            return StaticQuery<int>("Select COUNT(DISTINCT(Year)) From [TBLMizan] where CompanyID=@ID ", new { ID = ide }).FirstOrDefault();
        }
        public static List<int> GetYearList(long ide)
        {
            return StaticQuery<int>("Select  DISTINCT([Year])  From [TBLXMLSourceOne] where CompanyID=@ID  and [Year]  not in (SELECT [Year] FROM [EDEFTERDB].[dbo].[TBLMNKTAKIS] where CompanyID=@ID ) order by [Year] ", new { ID = ide }).ToList();
        }

        public static int setCashFlow(long compide, int yearid)
        {
            StaticQuery<int>("EXEC  [SP_ANAKITAKISALL]  @compdID,@nyear", new { compdID = compide, nyear = yearid });
            return StaticQuery<int>("EXEC  [SP_ANAKITAKISTALL]  @compdID,@nyear", new { compdID = compide, nyear = yearid }).FirstOrDefault();
        }
        public static int RESET_TBLXml(long ide)
        {
            return StaticQuery<int>("EXEC RESETALL_byCSVID @CsvID", new { CsvID = ide }).FirstOrDefault();
        }
        public static int GetCountALL_byCompanyIDMulti(int _year, long _compID, int _monthID, long tblxmlID)
        {
            int checkco = StaticQuery<int>("Select Count(ID) FROM [dbo].[TBLXMLSource]   where  CsvID in (Select ID FROM TBLXml where CompanyID=@companyID and Year= @nyear and MONTH(DocumentDate)=@monD and ID<>@ide)", new { nyear = _year, companyID = _compID, monD = _monthID, ide = tblxmlID }).FirstOrDefault();
            return checkco;
        }
        public static int RESETALL_byCompanyIDMulti(int _year, long _compID, int _monthID, long tblxmlID)
        {
            //Select Count(ID) FROM [dbo].[TBLXMLSource]   where  CsvID in (Select ID FROM TBLXml where CompanyID=@companyID and Year= @nyear and MONTH(DocumentDate)=@monD and ID<>@ide)
            return StaticQuery<int>("EXEC RESETALL_byCompanyIDMulti @nyear, @companyID,@monD ,@ide", new { nyear = _year, companyID = _compID, monD = _monthID, ide = tblxmlID }).FirstOrDefault();
        }
        public static int RESETALL_byCompanyID(int _year, long _compID, int _monthID, long tblxmlID)
        {
            return StaticQuery<int>("EXEC RESETALL_byCompanyID @nyear, @companyID,@monD ,@ide", new { nyear = _year, companyID = _compID, monD = _monthID, ide = tblxmlID }).FirstOrDefault();
        }
        public void Save_TBLXml()
        {
            string sql = @"  INSERT INTO [TBLXml]
          (  
        [CsvName] ,
        [CompanyID] ,
        [CreatedDate] ,
DocumentDate ,XmlDocName,Year
          ) 
           VALUES 
         (  
        @CsvName ,
        @CompanyID ,
        @CreatedDate ,
@DocumentDate ,@XmlDocName,@Year
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<long>(sql, this).FirstOrDefault();
        }

        public bool Update_TBLXml()
        {
            try
            {
                string sql = "UPDATE   [TBLXml] SET     [CsvName]=@CsvName , [CompanyID]=@CompanyID , [CreatedDate]=@CreatedDate,DocumentDate=@DocumentDate, [Year]=@Year  WHERE [ID]=@ID";
                Execute(sql, this);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public void InsertTb(DataTable dt)
        {

            SqlConnection con = new SqlConnection(BaseModel.ConnectionString);
            SqlCommand com = new SqlCommand("SampleProcedure", con);
            com.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Sample";
            parameter.SqlDbType = System.Data.SqlDbType.Structured;
            parameter.Value = dt;
            com.Parameters.Add(parameter);
            con.Open();

            com.ExecuteNonQuery();
            con.Close();

        }
    }
}