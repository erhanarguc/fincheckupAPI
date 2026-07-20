using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace fincheckup.Models.NKolay.MizanView
{
    public class DashAktarma : BaseModel
    {
        public long ID { get; set; }
        public long CompanyID { get; set; }
        public int YEAR { get; set; }
        public long Value { get; set; }
        public string Message { get; set; }
        public bool ISInclude { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TypeID { get; set; }
        public int? CheckValue { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string AccountNoII { get; set; }
        public string AccountNameII { get; set; }
        public byte IsChecked { get; set; }
        

        public static List<DashAktarma> AddSMMM(List<DashAktarma> nlist)
        {

            return nlist;
        }

        public static List<DashAktarma> Get_MAINRESULTMultiMain(long _compID)
        {
            return StaticQuery<DashAktarma>("Select * from  SPO_TBMLAKTARMA WITH (NOLOCK) Where CompanyID=@companyID  ", new { companyID = _compID }).ToList();
        }

        public static  int UpdateIsChecked(long _compID, long _year, int[] _type)
        {
            StaticQuery<int>("UPDATE SPO_TBMLAKTARMA  SET IsChecked=0 Where CompanyID=@companyID  and [YEAR]=@year", new { companyID = _compID, year = _year}).FirstOrDefault();
            return StaticQuery<int>("UPDATE SPO_TBMLAKTARMA  SET IsChecked=1 Where CompanyID=@companyID  and [YEAR]=@year  and [TypeID] in @typid ", new { companyID = _compID, year = _year, typid= _type }).FirstOrDefault();
        }

    }
}
