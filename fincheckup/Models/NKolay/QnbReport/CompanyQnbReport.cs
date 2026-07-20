using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay.QnbReport
{
    public class CompanyQnbReport : BaseModel
    {
        public int ID { get; set; }
        public long UserID { get; set; }
        public long CompanyID { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsUpdated { get; set; }
        public string ReportName { get; set; }

        public static CompanyQnbReport Get_CompanyReport(long reportide)
        {

            return StaticQuery<CompanyQnbReport>("SELECT * FROM CompanyQnbReport  where   ID=@ID", new { ID = reportide }).FirstOrDefault();
        }
        public static List<CompanyQnbReport> Get_CompanyReportList(long comide)
        {

            return StaticQuery<CompanyQnbReport>("SELECT * FROM CompanyQnbReport  where   CompanyID=@ID", new { ID = comide }).ToList();
        }
        public static int Get_CompanyReportCount(long reportide)
        {
            return StaticQuery<int>("SELECT COUNT(*) FROM CompanyQnbReport  where  CompanyID=@ID", new { ID = reportide }).FirstOrDefault();
        }
        public static int Set_Report(long compide, long useride, string reportname)
        {
            return StaticQuery<int>("EXEC SPP_SaveReportDocument @CompID,@UserID,@fileName", new { CompID = compide, UserID = useride, fileName = reportname }).FirstOrDefault();
        }
    }
}
