using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay.ENTITY.Mizan
{
    public class MizanResult : BaseModel
    {
        public static List<DashMizanResult> Get_MizanResult(int _year, long _compID)
        {
            return StaticQuery<DashMizanResult>("SELECT * FROM [dbo].[TBLMizanErrzoneResult]  where CompanyID=@companyID and [Year]=@nyear ", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashDonukView> Get_DonuChk(int _year, long _compID)
        {
            return StaticQuery<DashDonukView>("SELECT * from [dbo].[TBLMDONUKACCNTCHK]  where  OrderID<4 and  CompanyID=@companyID and [Year]=@nyear order by OrderID", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashMizanResult> Get_TicariAlıcı(int _year, long _compID)
        {
            return StaticQuery<DashMizanResult>("SELECT top 5 [AccountSubDescription] as Description  , ABS(SUM([AmountBakiye])) as Amount FROM [dbo].[TBLXMLSourceOneT] where   [CompanyId]=@companyID and MainYear=@nyear and [MainMonth]=@month  and AccountMainID = '120' and DebitCreditCode = 'D' group by [AccountSubDescription] order by SUM([AmountBakiye])  desc", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashMizanResult> Get_TicariBorclu(int _year, long _compID)
        {
            return StaticQuery<DashMizanResult>(" SELECT top 5 [AccountSubDescription] as Description  , ABS(SUM(CreditBakiyeMain)) as Amount FROM [dbo].[TBLXMLSourceOneT] where   [CompanyId]=@companyID and MainYear=@nyear and [MainMonth]=@month  and AccountMainID = '320' and DebitCreditCode = 'C' group by [AccountSubDescription] order by SUM(CreditBakiyeMain)  desc", new { nyear = _year, companyID = _compID }).ToList();
            return StaticQuery<DashMizanResult>(" SELECT top 5 [AccountSubDescription] as Description  , ABS(SUM(CreditBakiyeMain)) as Amount FROM [dbo].[TBLXMLSourceOneT] where   [CompanyId]=@companyID and MainYear=@nyear and [MainMonth]=@month  and AccountMainID = '320' and DebitCreditCode = 'C' group by [AccountSubDescription] order by SUM(CreditBakiyeMain)  desc", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashMizanResult> Get_TicariAlıcıMizan(int _year, long _compID)
        {
            return StaticQuery<DashMizanResult>("  SELECT top 5 [AccountSubDescription] as Description  , SUM([Amount]) as Amount FROM [dbo].[TBLXMLSourceOneT] where   CompanyID=@companyID and Year=@nyear  and AccountMainID = '120' and DebitCreditCode = 'D' group by[AccountSubDescription] order by SUM([Amount] ) desc", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashMizanResult> Get_TicariBorcluMizan(int _year, long _compID)
        {
            return StaticQuery<DashMizanResult>("SELECT top 5 [AccountSubDescription] as Description , SUM([Amount]) as  Amount FROM [dbo].[TBLXMLSourceOneT] where   CompanyID=@companyID and Year = @nyear  and AccountMainID = '320' and DebitCreditCode = 'C' group by[AccountSubDescription] order by SUM([Amount] ) desc", new { nyear = _year, companyID = _compID }).ToList();
        }






    }
    public class DashMizanResult
    {
        public string Description { get; set; }
        public byte ColorDesc { get; set; }
        public double Amount { get; set; }

        public long CompanyID { get; set; }
        public int Year { get; set; }

    }
    public class DashDonukView
    {
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string AccountSubID { get; set; }
        public string AccountSubDescription { get; set; }
        public string DebitCreditCode { get; set; }
        public double Acilis { get; set; }
        public double March { get; set; }
        public double April { get; set; }
        public double September { get; set; }
        public double December { get; set; }

        public long CompanyID { get; set; }
        public int Year { get; set; }
        public string GroupName { get; set; }
        public int OrderID { get; set; }

    }
}
