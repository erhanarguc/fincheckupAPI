using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay
{
    public class TBLXmlFolderFile : BaseModel
    { 
    
        public long ID { get; set; }
        public long TBLXmlID { get; set; }
        public string CsvName { get; set; }
        public string Test { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte Issetted { get; set; } = 0;
        public byte IsFinished { get; set; } = 0;
        public bool IsLedger { get; set; }
        public int SortID { get; set; }
        public int LastSettedCount { get; set; }
        public long CompanyID { get; set; }
        public int MainYear { get; set; }
        public byte MainMonth { get; set; }
        public TBLXmlFolderFile()
        {

        }
        public TBLXmlFolderFile(string csvName, long companyID, int mainYear, byte mainMonth, int sortID, bool isLedger)
        {
            CsvName = csvName;
            CompanyID = companyID;
            MainYear = mainYear;
            MainMonth = mainMonth;
            SortID = sortID;
            IsLedger = isLedger;
        }

        public static List<TBLXmlFolderFile> GetList(long _ID)
        {
            return StaticQuery<TBLXmlFolderFile>("Select [CompanyID],[MainMonth],[MainYear],[Issetted] FROM [EDEFTERDB].[dbo].[TBLXmlFolderFile] where [CompanyID]=@ID and IsLedger=1  and [CreatedDate]> DATEADD(MINUTE,-130, GETDATE()) order by ID ", new { ID = _ID }).ToList();
        }

        public static List<TBLXmlFolderFile> GetList(long _comID,int _year,int nmonth_)
        {
            return StaticQuery<TBLXmlFolderFile>("Select * FROM [EDEFTERDB].[dbo].[TBLXmlFolderFile] where [CompanyID]=@ID and IsLedger=1  and [MainYear]=@nyear and MainMonth=@nmonth", new { ID = _comID, nyear= _year, nmonth = nmonth_ }).ToList();
        }
        public static List<ViewSortlist> GetListSort(long _ID)
        {
            string sql = @"  SELECT SUM(t.AllSet) as 'AllSet',SUM(t.AllWait) as  'AllWait',SUM(t.AllRecord) as  'AllRecord',t.MainYear from
  (Select 
  Case When [Issetted]=1 Then COUNT(*) ELSE 0 END as 'AllSet',
  Case When [Issetted]=0 Then COUNT(*) ELSE 0 END as  'AllWait',
  Count(*) as  'AllRecord', [MainYear]
   FROM [EDEFTERDB].[dbo].[TBLXmlFolderFile] where [CompanyID]=@ID and IsLedger=1  group by [Issetted],[MainYear],[CompanyID])t group by t.MainYear";

            return StaticQuery<ViewSortlist>(sql, new { ID = _ID }).ToList();
        }
        public void Save_TBLXmlFolderFile()
        {

            string sql21 = @"DELETE FROM TBLXMLSource where CsvID= (Select top 1 TBLXmlID from [TBLXmlFolderFile] where CsvName=@CsvName) and FolderFileID=(Select top 1 ID  from  [TBLXmlFolderFile] where CsvName=@CsvName)";
            Query<int>(sql21, this).FirstOrDefault();

            string sql1 = @"DELETE FROM [TBLXmlFolderFile] where CsvName=@CsvName ";
           Query<int>(sql1, this).FirstOrDefault();

            this.SortID = Query<int>("Select COUNT(*) FROM [TBLXmlFolderFile] where CompanyID=@CompanyID and MainYear=MainYear and  MainMonth=@MainMonth and IsFinished=0 and IsLedger=1", this).FirstOrDefault();
            this.SortID++;
           string sql = @"INSERT INTO [TBLXmlFolderFile]
          ( 
        CsvName ,
         CompanyID,
        MainYear  ,MainMonth,SortID,IsLedger
          ) 
           VALUES 
         ( 
        @CsvName ,
         @CompanyID,
        @MainYear  ,@MainMonth,@SortID,@IsLedger
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }
    }

    public class ViewSortlist
    {
        public int AllSet { get; set; }
        public int AllWait { get; set; }
        public int AllRecord { get; set; }
        public int MainYear { get; set; }
    }
}
