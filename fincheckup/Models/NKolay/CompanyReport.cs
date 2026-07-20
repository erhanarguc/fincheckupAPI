using fincheckup.Models.NKolay.QnbReport;
using System.Collections.Generic;
using System.Linq;
using System;

namespace fincheckup.Models.NKolay
{
    public class CompanyReport : BaseModel
    {
        public int ID { get; set; }
        public long UserID { get; set; }
        public long CompanyID { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte FileTypeID { get; set; }
        public byte ReportTypeID { get; set; }
        public string ReportName { get; set; }
        public int MainMonth { get; set; }
        public int MainYear { get; set; }
        public int MainCount { get; set; }
 
        public static CompanyReport Get_CompanyReport(long reportide)
        {

            return StaticQuery<CompanyReport>("SELECT * FROM CompanyReport  where   ID=@ID", new { ID = reportide }).FirstOrDefault();
        }
        public static List<CompanyReport> Get_CompanyReportList(long comide)
        {

            return StaticQuery<CompanyReport>("SELECT * FROM CompanyReport  where   CompanyID=@ID", new { ID = comide }).ToList();
        }
      
        public static int Set_Report(long compide, long useride, string reportname,byte filetype_, byte reporttype_, int mainmonth_, int mainyear_, int maincount_)
        {
            return StaticQuery<int>("EXEC SPP_SaveComReportDocument @CompID,@UserID,@fileName,@filetype  ,@reporttype  ,@mainmonth ,@mainyear  ,@maincount ", new { CompID = compide, UserID = useride, fileName = reportname, filetype= filetype_, reporttype = reporttype_, mainmonth = mainmonth_, mainyear = mainyear_, maincount = maincount_ }).FirstOrDefault();

            
        }
    }
}
