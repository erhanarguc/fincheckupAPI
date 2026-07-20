using System.Collections.Generic;

namespace fincheckup.Models.NKolay
{
    public class DashFinansmanGelirKambiyo : BaseModel
    {
        public string AccountMainDescription { get; set; }
        public decimal Acilis { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
        public long CompanyID { get; set; }
        public static IEnumerable<DashFinansmanGelirKambiyo> Get_List(int id = 1)
        {
            string sql = @"EXEC SPFinansmanGelirKambiyo @compid";
            return StaticQuery<DashFinansmanGelirKambiyo>(sql, new { compid = id });
        }


    }
    public class DashFinansmanGelirFaiz : BaseModel
    {
        public string AccountSubDescription { get; set; }
        public decimal Acilis { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
        public long CompanyID { get; set; }



    }

    public class DashFinansmanGider : BaseModel
    {
        public string AccountMainDescription { get; set; }
        public decimal Acilis { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
        public long CompanyID { get; set; }
        public static IEnumerable<DashFinansmanGider> Get_List(int id = 1)
        {
            string sql = @"EXEC SPFinansmanGiderKambiyo @compid";
            return StaticQuery<DashFinansmanGider>(sql, new { compid = id });
        }


    }
    public class DashMonthlyMain
    {
        public string AccountMainDescription { get; set; }
        public decimal Acilis { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
        public long CompanyID { get; set; }

        public static List<DashMonthlyMain> GetlistFromSub(IEnumerable<DashMonthlySub> nlist)
        {
            List<DashMonthlyMain> flist = new List<DashMonthlyMain>();
            DashMonthlyMain fitem = new DashMonthlyMain();
            foreach (var item in nlist)
            {
                fitem = new DashMonthlyMain();
                fitem.AccountMainDescription = item.AccountSubDescription;
                fitem.Acilis = item.Acilis;
                fitem.April = item.April;
                fitem.August = item.August;
                fitem.CompanyID = item.CompanyID;
                fitem.December = item.December;
                fitem.February = item.February;
                fitem.January = item.January;
                fitem.July = item.July;
                fitem.June = item.June;
                fitem.March = item.March;
                fitem.May = item.May;
                fitem.November = item.November;
                fitem.October = item.October;
                fitem.September = item.September;
                flist.Add(fitem);
            }
            return flist;


        }


    }
    public class DashMonthlySub
    {
        public string AccountSubDescription { get; set; }
        public decimal Acilis { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
        public long CompanyID { get; set; }



    }
    public class DashFinansmanGiderFaiz : BaseModel
    {
        public string AccountSubDescription { get; set; }
        public decimal Acilis { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
        public long CompanyID { get; set; }



    }
    public class DashFinansmanGiderToplam : BaseModel
    {
        public string AccountMainDescription { get; set; }
        public decimal Acilis { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
        public long CompanyID { get; set; }



    }
}
