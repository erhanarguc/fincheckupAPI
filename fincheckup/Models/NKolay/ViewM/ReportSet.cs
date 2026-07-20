using fincheckup.Models.DigiForm;
using fincheckup.Models.NKolay.ENTITY.Beyanname;
using fincheckup.Models.NKolay.MizanView;
using fincheckup.Models.ViewM;
using fincheckup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace fincheckup.Models.NKolay.ViewM
{
    public class ReportSet
    {
        public int TypeID { get; set; }
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string AccountSubDescription { get; set; }
        
        public string AccountMainEng { get; set; }
        public long Amount { get; set; }
        public long BorcBakiye { get; set; }
        public long AlacakBakiye { get; set; }
        public long AmountMzn { get; set; }
        public long MainAmountTotal { get; set; }
        public long MainAmountTotalMzn { get; set; }
        public string DebitCreditCode { get; set; }
        public long AmountBakiye { get; set; }
        public long AmountBakiyeMzn { get; set; }
        public long Debit { get; set; }
        public long Credit { get; set; }
        public int SubTypeID { get; set; }
        public int Year { get; set; }
        public int MainTypeID { get; set; }
        public bool IsErrored { get; set; }
        public bool IsBeyan { get; set; }
        public int MainMonth { get; set; }


    }


    public class ReportSetMainAktarma : BaseModel
    {
        public static int Set_ReportTBAFirstMonthly(int _year, long _compID)
        {


            bool ISOnlyNegatifPoz = false;

            bool ISOnlyNegatifNeg = false;
            int valueMizanMonth = StaticQuery<int>("SELECT ISNULL(MAX([MainMonth]),0) FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where [Year]=@nyear and [CompanyID]=@companyID and IsBeyan=0 ", new { nyear = _year, companyID = _compID }).FirstOrDefault();

            int valueBeyannameMonth = StaticQuery<int>(" SELECT ISNULL(MAX([MainMonth]),0) FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where [Year]=@nyear and [CompanyID]=@companyID  and IsBeyan=1 ", new { nyear = _year, companyID = _compID }).FirstOrDefault();

            if (valueBeyannameMonth > valueMizanMonth)
            {
                return 0;
            }

            //if (valueBeyannameMonth  >9)
            //{
            //    return 0;
            //}





            string sqllpositiveMonthly = @"SELECT SUM(t.DebitBakiyeMain) as 'Value',t.[AccountMainID]  as 'AccountNo',tn.AccountNoII,SUM(t.CreditBakiyeMain) as 'ValueII'   FROM [EDEFTERDB].[dbo].[TBLXMLSourceOne] t   
LEFT JOIN SPO_TBMLAKTARMAVal as tn on t.AccountMainID=tn.AccountNo
 where t.CompanyID=@companyID and t.[Year]=@nyear and  (t.CreditBakiyeMain<>0 and t.DebitBakiyeMain<>0) and ABS(t.CreditBakiyeMain)>5 and ABS(t.DebitBakiyeMain)>5  and t.AccountMainID in (Select [AccountNo] from [dbo].[SPO_TBMLAKTARMAVal] where 	[DebitCredit]='D')  group by t.[AccountMainID],tn.AccountNoII";

            string sqllnegativeMonthly = @" SELECT SUM(t.CreditBakiyeMain) as 'Value',t.[AccountMainID]  as 'AccountNo',tn.AccountNoII,SUM(t.DebitBakiyeMain) as 'ValueII'   FROM [EDEFTERDB].[dbo].[TBLXMLSourceOne] t   
LEFT JOIN SPO_TBMLAKTARMAVal as tn on t.AccountMainID=tn.AccountNo
 where t.CompanyID=@companyID and t.[Year]=@nyear and  (t.CreditBakiyeMain<>0 and t.DebitBakiyeMain<>0) and ABS(t.CreditBakiyeMain)>5 and ABS(t.DebitBakiyeMain)>5  and t.AccountMainID in (Select [AccountNo] from [dbo].[SPO_TBMLAKTARMAVal] where 	[DebitCredit]='C')  group by t.[AccountMainID],tn.AccountNoII";

            List<SPO_TBMLAKTARMAMtchView> nlistpozMonthlyFirst = new List<SPO_TBMLAKTARMAMtchView>();
            List<SPO_TBMLAKTARMAMtchView> nlistpozMonthlyLast = new List<SPO_TBMLAKTARMAMtchView>();

            List<SPO_TBMLAKTARMAMtchView> nlistNEGMonthlyFirst = new List<SPO_TBMLAKTARMAMtchView>();
            List<SPO_TBMLAKTARMAMtchView> nlistNEGMonthlyLast = new List<SPO_TBMLAKTARMAMtchView>();

            List<SPO_TBMLAKTARMAMtchView> nlistpozMonthly = StaticQuery<SPO_TBMLAKTARMAMtchView>(sqllpositiveMonthly, new { nyear = _year, companyID = _compID }).ToList();



            //            if (nlistpozMonthly.Count < 1)
            //            {
            //                sqllpositiveMonthly = @"SELECT SUM(t.AmountBakiye) as 'Value',t.[AccountMainID]  as 'AccountNo',tn.AccountNoII    FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneT] t 
            //LEFT JOIN SPO_TBMLAKTARMAMtch as tn on t.AccountMainID=tn.AccountNo
            //LEFT JOIN  
            //  (Select MAX(LEN(AccountSubID)) as GroupLength,[AccountMainID] as groupId FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneT] where CompanyID=@companyID and [Year]=@nyear and CAST(AmountBakiye as bigint)<0 and AccountMainID in (Select [AccountNo] from [dbo].[SPO_TBMLAKTARMAMtch] where 	[DebitCredit]='D')
            // group by 
            //[AccountMainID] )x on t.AccountMainID=x.groupId where t.CompanyID=@companyID and t.[Year]=@nyear and CAST(t.AmountBakiye as bigint)<0 and t.AccountMainID in (Select [AccountNo] from [dbo].[SPO_TBMLAKTARMAMtch] where 	[DebitCredit]='D') and LEN(AccountSubID)>=x.GroupLength -1 group by 
            //[AccountMainID] ,tn.AccountNoII";
            //                nlistpozMonthly = StaticQuery<SPO_TBMLAKTARMAMtchView>(sqllpositiveMonthly, new { nyear = _year, companyID = _compID }).ToList();
            //            }



            List<SPO_TBMLAKTARMAMtchView> nlistnefMonthly = StaticQuery<SPO_TBMLAKTARMAMtchView>(sqllnegativeMonthly, new { nyear = _year, companyID = _compID }).ToList();

            //            if (nlistnefMonthly.Count < 1)
            //            {
            //                sqllnegativeMonthly = @"SELECT SUM(t.AmountBakiye) as 'Value',t.[AccountMainID]  as 'AccountNo',tn.AccountNoII    FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneT] t 
            //LEFT JOIN SPO_TBMLAKTARMAMtch as tn on t.AccountMainID=tn.AccountNo
            //LEFT JOIN  
            //  (Select MAX(LEN(AccountSubID)) as GroupLength,[AccountMainID] as groupId FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneT] where CompanyID=@companyID and [Year]=@nyear and CAST(AmountBakiye as bigint)>0 and AccountMainID in (Select [AccountNo] from [dbo].[SPO_TBMLAKTARMAMtch] where 	[DebitCredit]='C')
            // group by 
            //[AccountMainID] )x on t.AccountMainID=x.groupId where t.CompanyID=@companyID and t.[Year]=@nyear and CAST(t.AmountBakiye as bigint)>0 and t.AccountMainID in (Select [AccountNo] from [dbo].[SPO_TBMLAKTARMAMtch] where 	[DebitCredit]='C') and LEN(AccountSubID)>=x.GroupLength -1 group by 
            //[AccountMainID] ,tn.AccountNoII";
            //                nlistnefMonthly = StaticQuery<SPO_TBMLAKTARMAMtchView>(sqllnegativeMonthly, new { nyear = _year, companyID = _compID }).ToList();
            //            }


            List<string> nlistnefAstrMinus = nlistnefMonthly.Select(x => x.AccountNoII).ToList();
            nlistpozMonthlyFirst = nlistpozMonthly.Where(x => nlistnefAstrMinus.Contains(x.AccountNo)).ToList();
            nlistpozMonthlyLast = nlistpozMonthly.Where(x => !nlistnefAstrMinus.Contains(x.AccountNo)).ToList();

            nlistNEGMonthlyFirst = nlistnefMonthly.Where(x => nlistnefAstrMinus.Contains(x.AccountNo)).ToList();
            nlistNEGMonthlyLast = nlistnefMonthly.Where(x => !nlistnefAstrMinus.Contains(x.AccountNo)).ToList();
            foreach (var item in nlistnefMonthly)
            {

                var vallue = nlistpozMonthlyFirst.Where(x => x.AccountNo == item.AccountNoII).Select(y => y.ValueII).FirstOrDefault();

                nlistnefMonthly.Where(w => w.AccountNoII == item.AccountNoII).ToList().ForEach(i => i.Value += vallue);
            }


            foreach (var entry in nlistpozMonthlyFirst)
            {
                // The key is a tuple, so you can deconstruct it.

                //if (entry.ValueII==0)
                //{
                //    CheckRealValuePozFirstMonthlyOne(_year, _compID, entry.AccountNo, entry.Value, entry.AccountNoII );
                //}
                //else
                //{


                CheckRealValuePozFirstMonthly(_year, _compID, entry.AccountNo, entry.Value, entry.AccountNoII, entry.ValueII);
                //}


                Thread.Sleep(100);
            }

            foreach (var entry in nlistNEGMonthlyFirst)
            {

                //if (entry.ValueII == 0)
                //{
                //    CheckRealValueNegFirstMonthlyOne(_year, _compID, entry.AccountNo, entry.Value, entry.AccountNoII );
                //}
                //else
                //{
                CheckRealValueNegFirstMonthly(_year, _compID, entry.AccountNo, entry.Value, entry.AccountNoII, entry.ValueII);
                //}
                Thread.Sleep(100);
            }

            foreach (var entry in nlistNEGMonthlyLast)
            {

                //if (entry.ValueII == 0)
                //{
                //    CheckRealValueNegFirstMonthlyOne(_year, _compID, entry.AccountNo, entry.Value, entry.AccountNoII );
                //}
                //else
                //{
                CheckRealValueNegFirstMonthly(_year, _compID, entry.AccountNo, entry.Value, entry.AccountNoII, entry.ValueII);
                //}
                Thread.Sleep(100);
            }

            foreach (var entry in nlistpozMonthlyLast)
            {
                // The key is a tuple, so you can deconstruct it.
                //if (entry.ValueII == 0)
                //{
                //    CheckRealValuePozFirstMonthlyOne(_year, _compID, entry.AccountNo, entry.Value, entry.AccountNoII);
                //}
                //else
                //{
                CheckRealValuePozFirstMonthly(_year, _compID, entry.AccountNo, entry.Value, entry.AccountNoII, entry.ValueII);
                //}
                Thread.Sleep(100);
            }
            return 0;
        }
        public static int CheckRealValuePozFirstMonthly(int _year, long _compID, String code_, long value_, String code2_, long valueII_)
        {
            if (value_ == 0)
            {
                return 0;
            }

            long chakValueBeyan = StaticQuery<long>("SELECT ISNULL(SUM(AmountBakiye),0)  FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]=@nyear and IsBeyan=1 and MainMonth=(Select MAX(MainMonth) from [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]=@nyear  and IsBeyan=1 ) and AccountMainID in (@accountNo) group by AccountMainID", new { nyear = _year, companyID = _compID, accountNo = code_ }).FirstOrDefault();

            long chakValueMizan = StaticQuery<long>("SELECT ISNULL(SUM(AmountBakiye),0)  FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]=@nyear and IsBeyan=0 and MainMonth=(Select MAX(MainMonth) from [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]=@nyear  and IsBeyan=0) and AccountMainID in (@accountNo) group by AccountMainID", new { nyear = _year, companyID = _compID, accountNo = code_ }).FirstOrDefault();


            //int controlvalue = 0;
            //if (Math.Abs(chakValueBeyanII) < Math.Abs(value_))
            //{
            //    var chkValuue = ((Convert.ToDouble(Math.Abs(value_)) - Convert.ToDouble(Math.Abs(chakValueBeyanII))) / Convert.ToDouble(Math.Abs(value_))) * 100;
            //    controlvalue = Convert.ToInt32(chkValuue);
            //}
            //else
            //{
            //    if (Math.Abs(chakValueBeyanII) != 0)
            //    {
            //        var chkValuue = ((Convert.ToDouble(Math.Abs(chakValueBeyanII)) - Convert.ToDouble(Math.Abs(value_))) / Convert.ToDouble(Math.Abs(chakValueBeyanII))) * 100;
            //        controlvalue = Convert.ToInt32(chkValuue);
            //    }
            //    else
            //    {
            //        controlvalue = 15;
            //    }
            //}




            if ((Math.Abs(chakValueMizan) + Math.Abs(value_)) - Math.Abs(chakValueBeyan) < 100)
            {
                return 0;

            }
            else
            {
                string sqll = @"UPDATE TBLXMLSourceOne set  [Amount]=@vallue,[AmountBakiye]=@vallue ,[MainAmountTotal]=@vallue
                  where CompanyID=@compID and [Year]=@nyear  and AccountMainID in (@accountNo)";
                int result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, vallue = value_, accountNo = code_ }).FirstOrDefault();
                BeyannameChk.CheckCodeCompanyIdYear(_year, _compID, code2_);
                sqll = @"UPDATE TBLXMLSourceOne set  [Amount]=Amount-@vallue,[AmountBakiye]=AmountBakiye-@vallue ,[MainAmountTotal]=MainAmountTotal-@vallue
                  where CompanyID=@compID and [Year]=@nyear  and AccountMainID in (@accountNo)";
                result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, vallue = Math.Abs(valueII_), accountNo = code2_ }).FirstOrDefault();


                sqll = @"DELETE FROM SPO_TBMLAKTARMAFrst where  CompanyID=@compID and [Year]=@nyear  and TypeID=3 and AccountNo=@accountNo;INSERT INTO SPO_TBMLAKTARMAFrst([CompanyID], [YEAR], [Value], [Message], TypeID, AccountNo, AccountName, AccountNoII, AccountNameII,CheckValue)
                  Select @compID, @nyear , @val ,@description,@typeid,@accountNo, @accountNoHesap ,@accountNo2,@accountNoHesap2, @valII";
                result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, val = value_, description = "(ACL) " + code_ + " Hesap Kodu-" + code2_, accountNo = code_, accountNo2 = code2_, accountNoHesap = "(ACL) " + code_ + " Hesap Kodu", accountNoHesap2 = "(ACL) " + code2_ + " Nolu Hesap İşlemleri", typeid = "3", valII = valueII_ }).FirstOrDefault();
            }

            return 0;
        }
        public static int CheckRealValueNegFirstMonthly(int _year, long _compID, String code_, long value_, String code2_, long valueII_)
        {
            if (value_ == 0)
            {
                return 0;
            }

            long chakValueBeyan = StaticQuery<long>("SELECT ISNULL(SUM(AmountBakiye),0)  FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]=@nyear and IsBeyan=1 and MainMonth=(Select MAX(MainMonth) from [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]=@nyear  and IsBeyan=1 ) and AccountMainID in (@accountNo) group by AccountMainID", new { nyear = _year, companyID = _compID, accountNo = code_ }).FirstOrDefault();

            long chakValueMizan = StaticQuery<long>("SELECT ISNULL(SUM(AmountBakiye),0)  FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]=@nyear and IsBeyan=0 and MainMonth=(Select MAX(MainMonth) from [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]=@nyear  and IsBeyan=0) and AccountMainID in (@accountNo) group by AccountMainID", new { nyear = _year, companyID = _compID, accountNo = code_ }).FirstOrDefault();




            //int controlvalue = 0;
            //if (Math.Abs(chakValueBeyanII) < Math.Abs(value_))
            //{
            //    var chkValuue = ((Convert.ToDouble(Math.Abs(value_)) - Convert.ToDouble(Math.Abs(chakValueBeyanII))) / Convert.ToDouble(Math.Abs(value_))) * 100;
            //    controlvalue = Convert.ToInt32(chkValuue);
            //}
            //else
            //{
            //    if (Math.Abs(chakValueBeyanII) != 0)
            //    {
            //        var chkValuue = ((Convert.ToDouble(Math.Abs(chakValueBeyanII)) - Convert.ToDouble(Math.Abs(value_))) / Convert.ToDouble(Math.Abs(chakValueBeyanII))) * 100;
            //        controlvalue = Convert.ToInt32(chkValuue);
            //    }
            //    else
            //    {
            //        controlvalue = 15;
            //    }
            //}




            if ((Math.Abs(chakValueMizan) + Math.Abs(value_)) - Math.Abs(chakValueBeyan) < 100)
            {
                return 0;

            }
            else
            {
                string sqll = @"UPDATE TBLXMLSourceOne set  [Amount]=@vallue,[AmountBakiye]=@vallue ,[MainAmountTotal]=@vallue
                  where CompanyID=@compID and [Year]=@nyear  and AccountMainID in (@accountNo)";
                int result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, vallue = value_ * -1, accountNo = code_ }).FirstOrDefault();
                BeyannameChk.CheckCodeCompanyIdYear(_year, _compID, code2_);
                sqll = @"UPDATE TBLXMLSourceOne set  [Amount]=Amount+@vallue,[AmountBakiye]=AmountBakiye+@vallue ,[MainAmountTotal]=MainAmountTotal+@vallue
                  where CompanyID=@compID and [Year]=@nyear  and AccountMainID in (@accountNo)";
                result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, vallue = Math.Abs(valueII_), accountNo = code2_ }).FirstOrDefault();


                sqll = @"DELETE FROM SPO_TBMLAKTARMAFrst where  CompanyID=@compID and [Year]=@nyear  and TypeID=3 and AccountNo=@accountNo; INSERT INTO SPO_TBMLAKTARMAFrst([CompanyID], [YEAR], [Value], [Message], TypeID, AccountNo, AccountName, AccountNoII, AccountNameII,CheckValue)
                  Select @compID, @nyear , @val ,@description,@typeid,@accountNo, @accountNoHesap ,@accountNo2,@accountNoHesap2, @valII";
                result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, val = value_, description = "(ACL) " + code_ + " Hesap Kodu-" + code2_, accountNo = code_, accountNo2 = code2_, accountNoHesap = "(ACL) " + code_ + " Hesap Kodu", accountNoHesap2 = "(ACL) " + code2_ + " Nolu Hesap İşlemleri", typeid = "3", valII = valueII_ }).FirstOrDefault();
            }

            return 0;
        }
        public static int Set_ReportTBAFirst(int _year, long _compID)
        {
            long companyidII = -1000000 * _compID;

            StaticQuery<int>("delete FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn] where (CompanyID=@CompanyidII) and [Year]=@nyear", new { nyear = _year, CompanyidII = companyidII }).FirstOrDefault();
            StaticQuery<int>("delete  FROM [EDEFTERDB].[dbo].[TBLMRevenueMzn] where (CompanyID=@CompanyidII) and [Year]=@nyear;", new { nyear = _year, CompanyidII = companyidII }).FirstOrDefault();
            StaticQuery<int>("Delete FROM [TBLXMLSourceOne] where CompanyID=@CompanyidII and Year=@nyear ", new { nyear = _year, CompanyidII = companyidII }).FirstOrDefault();

            int valueMizanMonth = StaticQuery<int>(" SELECT ISNULL(MAX([MainMonth]),0) FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where [Year]=@nyear and [CompanyID]=@companyID and IsBeyan=0 ", new { nyear = _year, companyID = _compID }).FirstOrDefault();

            int valueBeyannameMonth = StaticQuery<int>(" SELECT ISNULL(MAX([MainMonth]),0) FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where [Year]=@nyear and [CompanyID]=@companyID  and IsBeyan=1 ", new { nyear = _year, companyID = _compID }).FirstOrDefault();

            if (valueBeyannameMonth > valueMizanMonth)
            {
                return 0;
            }


            List<string> nlistpozAstr = new List<string>();
            List<string> nlistnefAstr = new List<string>();

            //if (valueMizanMonth < 12)
            //{


            string sqllpositiveMonthly = @"SELECT ABS(SUM(t.DebitBakiyeMain)) as 'Value',t.[AccountMainID]  as 'AccountNo',tn.AccountNoII,SUM(ABS(t.CreditBakiyeMain)) as 'ValueII'   FROM [EDEFTERDB].[dbo].[TBLXMLSourceOne] t   
LEFT JOIN SPO_TBMLAKTARMAVal as tn on t.AccountMainID=tn.AccountNo
 where t.CompanyID=@companyID and t.[Year]=@nyear and  (t.CreditBakiyeMain<>0 and t.DebitBakiyeMain<>0)  and t.AccountMainID in (Select [AccountNo] from [dbo].[SPO_TBMLAKTARMAVal] where 	[DebitCredit]='D')  group by t.[AccountMainID],tn.AccountNoII";

            string sqllnegativeMonthly = @" SELECT ABS(SUM(t.CreditBakiyeMain)) as 'Value',t.[AccountMainID]  as 'AccountNo',tn.AccountNoII,ABS(SUM(t.DebitBakiyeMain)) as 'ValueII'   FROM [EDEFTERDB].[dbo].[TBLXMLSourceOne] t   
LEFT JOIN SPO_TBMLAKTARMAVal as tn on t.AccountMainID=tn.AccountNo
 where t.CompanyID=@companyID and t.[Year]=@nyear and  (t.CreditBakiyeMain<>0 and t.DebitBakiyeMain<>0)  and t.AccountMainID in (Select [AccountNo] from [dbo].[SPO_TBMLAKTARMAVal] where 	[DebitCredit]='C')  group by t.[AccountMainID],tn.AccountNoII";



            List<SPO_TBMLAKTARMAMtchView> nlistpozMonthly = StaticQuery<SPO_TBMLAKTARMAMtchView>(sqllpositiveMonthly, new { nyear = _year, companyID = _compID }).ToList();

            List<SPO_TBMLAKTARMAMtchView> nlistnefMonthly = StaticQuery<SPO_TBMLAKTARMAMtchView>(sqllnegativeMonthly, new { nyear = _year, companyID = _compID }).ToList();
            nlistpozAstr = nlistpozMonthly.Select(x => x.AccountNo).ToList();
            nlistnefAstr = nlistnefMonthly.Select(x => x.AccountNo).ToList();


            //}



            string sqllpositive = @"SELECT ABS(SUM(t.AmountBakiye)) as 'Value',t.[AccountMainID]  as 'AccountNo',tn.AccountNoII    FROM [EDEFTERDB].[dbo].[TBLXMLSourceOne] t 
LEFT JOIN SPO_TBMLAKTARMAVal as tn on t.AccountMainID=tn.AccountNo
 where t.CompanyID=@companyID and t.[Year]=@nyear and CAST(t.AmountBakiye as bigint)<0 and t.AccountMainID in (Select [AccountNo] from [dbo].[SPO_TBMLAKTARMAVal] where 	[DebitCredit]='D')   group by 
[AccountMainID] ,tn.AccountNoII";

            string sqllnegative = @"SELECT ABS(SUM(t.AmountBakiye)) as 'Value',t.[AccountMainID]  as 'AccountNo',tn.AccountNoII    FROM [EDEFTERDB].[dbo].[TBLXMLSourceOne] t 
LEFT JOIN SPO_TBMLAKTARMAVal as tn on t.AccountMainID=tn.AccountNo 
where t.CompanyID=@companyID and t.[Year]=@nyear and CAST(t.AmountBakiye as bigint)>0 and t.AccountMainID in (Select [AccountNo] from [dbo].[SPO_TBMLAKTARMAVal] where 	[DebitCredit]='C')  group by t.[AccountMainID]  ,tn.AccountNoII";

            List<SPO_TBMLAKTARMAMtchView> nlistpoz = StaticQuery<SPO_TBMLAKTARMAMtchView>(sqllpositive, new { nyear = _year, companyID = _compID }).ToList();

            List<SPO_TBMLAKTARMAMtchView> nlistnef = StaticQuery<SPO_TBMLAKTARMAMtchView>(sqllnegative, new { nyear = _year, companyID = _compID }).ToList();

            //if (valueMizanMonth < 12)
            //{
            nlistpoz = nlistpoz.Where(x => !nlistpozAstr.Contains(x.AccountNo)).ToList();
            nlistnef = nlistnef.Where(x => !nlistnefAstr.Contains(x.AccountNo)).ToList();
            List<string> nstrList = nlistnef.Select(x => x.AccountNoII).ToList();
            List<string> nstrPozList = nlistpoz.Select(x => x.AccountNoII).ToList();
            //}

            var nlistpozfir = nlistpoz.Where(x => !nstrList.Contains(x.AccountNo)).ToList();
            var nlistpozlas = nlistpoz.Where(x => nstrList.Contains(x.AccountNo)).ToList();
            var nlistnefChek = nlistnef.Where(x => nstrPozList.Contains(x.AccountNo)).ToList();

            foreach (var item in nlistpozlas)
            {
                var chkItem = nlistnefChek.Where(x => x.AccountNo == item.AccountNoII).FirstOrDefault();
                nlistpozlas.Where(w => w.AccountNoII == chkItem.AccountNo).ToList().ForEach(i => i.ValueII = chkItem.Value);
            }
            nlistnef = nlistnef.Where(x => !nstrPozList.Contains(x.AccountNo)).ToList();

            foreach (var entry in nlistpozfir)
            {
                // The key is a tuple, so you can deconstruct it.



                CheckRealValuePozFirst(_year, _compID, entry.AccountNo, entry.Value, entry.AccountNoII);
                Thread.Sleep(100);
            }

            foreach (var entry in nlistnef)
            {
                CheckRealValueNegFirst(_year, _compID, entry.AccountNo, entry.Value, entry.AccountNoII);
                Thread.Sleep(100);
            }
            foreach (var entry in nlistpozlas)
            {
                // The key is a tuple, so you can deconstruct it.



                CheckRealValuePozNomina(_year, _compID, entry.AccountNo, entry.Value, entry.AccountNoII, entry.ValueII);
                Thread.Sleep(100);
            }


            return 0;
        }
        public static int CheckRealValuePozNomina(int _year, long _compID, String code_, long value_, String code2_, long valueII_)
        {
            if (value_ == 0)
            {
                return 0;
            }

            long chakValueMizanDebitvalue = StaticQuery<long>("SELECT ABS(ISNULL(SUM(t.DebitBakiyeMain),0)) as 'Value' FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneT] t LEFT JOIN SPO_TBMLAKTARMAMtch as tn on t.AccountMainID=tn.AccountNo LEFT JOIN     (Select MAX(LEN([AccountSubID]) - CHARINDEX('.',REVERSE([AccountSubID]))) as GroupLength,[AccountMainID] as groupId FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneT] where CompanyID=@companyID and [Year]=@nyear and CAST(AmountBakiye as bigint)>0 and AccountMainID=@accountNo  group by  [AccountMainID] )x on t.AccountMainID=x.groupId where t.CompanyID=@companyID and t.[Year]=@nyear and CAST(t.AmountBakiye as bigint)>0 and t.AccountMainID=@accountNo  and LEN(AccountSubID)>=x.GroupLength +2  group by  [AccountMainID] ,tn.AccountNoII", new { nyear = _year, companyID = _compID, accountNo = code_ }).FirstOrDefault();


            long chakValueMizanCreditvalue = StaticQuery<long>("SELECT ABS(ISNULL(SUM(t.CreditBakiyeMain),0)) as 'Value' FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneT] t LEFT JOIN SPO_TBMLAKTARMAMtch as tn on t.AccountMainID=tn.AccountNo LEFT JOIN     (Select MAX(LEN([AccountSubID]) - CHARINDEX('.',REVERSE([AccountSubID]))) as GroupLength,[AccountMainID] as groupId FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneT] where CompanyID=@companyID and [Year]=@nyear and CAST(AmountBakiye as bigint)<0 and AccountMainID=@accountNo  group by  [AccountMainID] )x on t.AccountMainID=x.groupId where t.CompanyID=@companyID and t.[Year]=@nyear and CAST(t.AmountBakiye as bigint)<0 and t.AccountMainID=@accountNo  and LEN(AccountSubID)>=x.GroupLength +2  group by  [AccountMainID] ,tn.AccountNoII", new { nyear = _year, companyID = _compID, accountNo = code2_ }).FirstOrDefault();

            string sqll = @"UPDATE TBLXMLSourceOne set  [Amount]=@vallue,[AmountBakiye]=@vallue ,[MainAmountTotal]=@vallue
                  where CompanyID=@compID and [Year]=@nyear  and AccountMainID in (@accountNo)";
            int result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, vallue = -1 * (Math.Abs(value_ + chakValueMizanCreditvalue + chakValueMizanDebitvalue)), accountNo = code2_ }).FirstOrDefault();

            BeyannameChk.CheckCodeCompanyIdYear(_year, _compID, code2_);
            sqll = @"UPDATE TBLXMLSourceOne set  [Amount]= @vallue,[AmountBakiye]= @vallue ,[MainAmountTotal]= @vallue
                  where CompanyID=@compID and [Year]=@nyear  and AccountMainID in (@accountNo)";
            result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, vallue = Math.Abs(valueII_) + Math.Abs(chakValueMizanDebitvalue) + Math.Abs(chakValueMizanCreditvalue), accountNo = code_ }).FirstOrDefault();
            //string sqll = @"UPDATE TBLXMLSourceOne set  [Amount]=@vallue,[AmountBakiye]=@vallue ,[MainAmountTotal]=@vallue
            //      where CompanyID=@compID and [Year]=@nyear  and AccountMainID in (@accountNo)";
            //    int result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, vallue = 0, accountNo = code_ }).FirstOrDefault();



            sqll = @"DELETE FROM SPO_TBMLAKTARMAFrst where  CompanyID=@compID and [Year]=@nyear  and TypeID=1 and AccountNo=@accountNo; INSERT INTO SPO_TBMLAKTARMAFrst([CompanyID], [YEAR], [CheckValue], [Message], TypeID, AccountNo, AccountName, AccountNoII, AccountNameII,Value)
                  Select @compID, @nyear , @val ,@description,@typeid,@accountNo, @accountNoHesap ,@accountNo2,@accountNoHesap2,0";
            result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, val = Math.Abs(value_), description = "(ACL) " + code_ + " Hesap Kodu-" + code2_, accountNo = code_, accountNo2 = code2_, accountNoHesap = "(ACL) " + code_ + " Hesap Kodu", accountNoHesap2 = "(ACL) " + code2_ + " Nolu Hesap İşlemleri", typeid = "1" }).FirstOrDefault();




            return 0;
        }
        public static int CheckRealValuePozFirst(int _year, long _compID, String code_, long value_, String code2_)
        {
            if (value_ == 0)
            {
                return 0;
            }

            long chakValueBeyan = StaticQuery<long>("SELECT ISNULL(SUM(AmountBakiye),0)  FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]=@nyear and IsBeyan=1 and MainMonth=(Select MAX(MainMonth) from [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]=@nyear  and IsBeyan=1 ) and AccountMainID in (@accountNo) group by AccountMainID", new { nyear = _year, companyID = _compID, accountNo = code_ }).FirstOrDefault();

            long chakValueMizan = StaticQuery<long>("SELECT ISNULL(SUM(AmountBakiye),0)  FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]=@nyear and IsBeyan=0 and MainMonth=(Select MAX(MainMonth) from [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]=@nyear  and IsBeyan=0) and AccountMainID in (@accountNo) group by AccountMainID", new { nyear = _year, companyID = _compID, accountNo = code_ }).FirstOrDefault();

            long chakValueMizanDebitvalue = StaticQuery<long>("SELECT ABS(ISNULL(SUM(t.DebitBakiyeMain),0)) as 'Value' FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneT] t LEFT JOIN SPO_TBMLAKTARMAMtch as tn on t.AccountMainID=tn.AccountNo LEFT JOIN     (Select MAX(LEN([AccountSubID]) - CHARINDEX('.',REVERSE([AccountSubID]))) as GroupLength,[AccountMainID] as groupId FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneT] where CompanyID=@companyID and [Year]=@nyear and CAST(AmountBakiye as bigint)>0 and AccountMainID=@accountNo  group by  [AccountMainID] )x on t.AccountMainID=x.groupId where t.CompanyID=@companyID and t.[Year]=@nyear and CAST(t.AmountBakiye as bigint)>0 and t.AccountMainID=@accountNo  and LEN(AccountSubID)>=x.GroupLength +2  group by  [AccountMainID] ,tn.AccountNoII", new { nyear = _year, companyID = _compID, accountNo = code_ }).FirstOrDefault();


            if (chakValueMizanDebitvalue == 0)
            {
               
                string sqll = @"UPDATE TBLXMLSourceOne set  [Amount]=@vallue,[AmountBakiye]=@vallue ,[MainAmountTotal]=@vallue
                  where CompanyID=@compID and [Year]=@nyear  and AccountMainID in (@accountNo)";
                int result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, vallue = 0, accountNo = code_ }).FirstOrDefault();
                BeyannameChk.CheckCodeCompanyIdYear(_year, _compID, code2_);
                sqll = @"UPDATE TBLXMLSourceOne set  [Amount]=Amount-@vallue,[AmountBakiye]=AmountBakiye-@vallue ,[MainAmountTotal]=MainAmountTotal-@vallue
                  where CompanyID=@compID and [Year]=@nyear  and AccountMainID in (@accountNo)";
                result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, vallue = Math.Abs(value_), accountNo = code2_ }).FirstOrDefault();

                sqll = @"DELETE FROM SPO_TBMLAKTARMAFrst where  CompanyID=@compID and [Year]=@nyear  and TypeID=1 and AccountNo=@accountNo; INSERT INTO SPO_TBMLAKTARMAFrst([CompanyID], [YEAR], [CheckValue], [Message], TypeID, AccountNo, AccountName, AccountNoII, AccountNameII,Value)
                  Select @compID, @nyear , @val ,@description,@typeid,@accountNo, @accountNoHesap ,@accountNo2,@accountNoHesap2,0";
                result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, val = Math.Abs(value_), description = "(ACL) " + code_ + " Hesap Kodu-" + code2_, accountNo = code_, accountNo2 = code2_, accountNoHesap = "(ACL) " + code_ + " Hesap Kodu", accountNoHesap2 = "(ACL) " + code2_ + " Nolu Hesap İşlemleri", typeid = "1" }).FirstOrDefault();


            }
            else
            {



                string sqll = @"UPDATE TBLXMLSourceOne set  [Amount]=@vallue,[AmountBakiye]=@vallue ,[MainAmountTotal]=@vallue
                  where CompanyID=@compID and [Year]=@nyear  and AccountMainID in (@accountNo)";
                int result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, vallue = chakValueMizanDebitvalue, accountNo = code_ }).FirstOrDefault();
                BeyannameChk.CheckCodeCompanyIdYear(_year, _compID, code2_);
                sqll = @"UPDATE TBLXMLSourceOne set  [Amount]=Amount-@vallue,[AmountBakiye]=AmountBakiye-@vallue ,[MainAmountTotal]=MainAmountTotal-@vallue
                  where CompanyID=@compID and [Year]=@nyear  and AccountMainID in (@accountNo)";
                result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, vallue = Math.Abs(chakValueMizanDebitvalue) + Math.Abs(value_), accountNo = code2_ }).FirstOrDefault();

                sqll = @"DELETE FROM SPO_TBMLAKTARMAFrst where  CompanyID=@compID and [Year]=@nyear  and TypeID=3 and AccountNo=@accountNo; INSERT INTO SPO_TBMLAKTARMAFrst([CompanyID], [YEAR], [Value], [Message], TypeID, AccountNo, AccountName, AccountNoII, AccountNameII,CheckValue)
                  Select @compID, @nyear , @val ,@description,@typeid,@accountNo, @accountNoHesap ,@accountNo2,@accountNoHesap2,@valII";
                result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, val = chakValueMizanDebitvalue, description = "(ACL) " + code_ + " Hesap Kodu-" + code2_, accountNo = code_, accountNo2 = code2_, accountNoHesap = "(ACL) " + code_ + " Hesap Kodu", accountNoHesap2 = "(ACL) " + code2_ + " Nolu Hesap İşlemleri", typeid = "3", valII = Math.Abs(chakValueMizanDebitvalue) + Math.Abs(value_) }).FirstOrDefault();
                 
            }


            return 0;
        }
        public static int CheckRealValueNegFirst(int _year, long _compID, String code_, long value_, String code2_)
        {
            if (value_ == 0)
            {
                return 0;
            }

            long chakValueBeyan = StaticQuery<long>("SELECT ISNULL(SUM(AmountBakiye),0)  FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]=@nyear and IsBeyan=1 and MainMonth=(Select MAX(MainMonth) from [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]=@nyear  and IsBeyan=1 ) and AccountMainID in (@accountNo) group by AccountMainID", new { nyear = _year, companyID = _compID, accountNo = code_ }).FirstOrDefault();

            long chakValueMizan = StaticQuery<long>("SELECT ISNULL(SUM(AmountBakiye),0)  FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]=@nyear and IsBeyan=0 and MainMonth=(Select MAX(MainMonth) from [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]=@nyear  and IsBeyan=0) and AccountMainID in (@accountNo) group by AccountMainID", new { nyear = _year, companyID = _compID, accountNo = code_ }).FirstOrDefault();
            long chakValueMizanCreditvalue = StaticQuery<long>("SELECT ABS(SUM(t.CreditBakiyeMain)) as 'Value'     FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneT] t LEFT JOIN SPO_TBMLAKTARMAMtch as tn on t.AccountMainID=tn.AccountNo LEFT JOIN     (Select MAX(LEN([AccountSubID]) - CHARINDEX('.',REVERSE([AccountSubID]))) as GroupLength,[AccountMainID] as groupId FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneT] where CompanyID=@companyID and [Year]=@nyear and CAST(AmountBakiye as bigint)<0 and AccountMainID=@accountNo  group by  [AccountMainID] )x on t.AccountMainID=x.groupId where t.CompanyID=@companyID and t.[Year]=@nyear and CAST(t.AmountBakiye as bigint)<0 and t.AccountMainID=@accountNo  and LEN(AccountSubID)>=x.GroupLength +2   group by  [AccountMainID] ,tn.AccountNoII", new { nyear = _year, companyID = _compID, accountNo = code_ }).FirstOrDefault();
            

            if (chakValueMizanCreditvalue == 0)
            {
                 
                string sqll = @"UPDATE TBLXMLSourceOne set  [Amount]=@vallue,[AmountBakiye]=@vallue ,[MainAmountTotal]=@vallue
                  where CompanyID=@compID and [Year]=@nyear  and AccountMainID in (@accountNo)";
                int result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, vallue = 0, accountNo = code_ }).FirstOrDefault();
                BeyannameChk.CheckCodeCompanyIdYear(_year, _compID, code2_);
                sqll = @"UPDATE TBLXMLSourceOne set  [Amount]=Amount+@vallue,[AmountBakiye]=AmountBakiye+@vallue ,[MainAmountTotal]=MainAmountTotal+@vallue
                  where CompanyID=@compID and [Year]=@nyear  and AccountMainID in (@accountNo)";
                result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, vallue = Math.Abs(value_), accountNo = code2_ }).FirstOrDefault();

                sqll = @"DELETE FROM SPO_TBMLAKTARMAFrst where  CompanyID=@compID and [Year]=@nyear  and TypeID=1 and AccountNo=@accountNo; INSERT INTO SPO_TBMLAKTARMAFrst([CompanyID], [YEAR], [CheckValue], [Message], TypeID, AccountNo, AccountName, AccountNoII, AccountNameII,Value)
                  Select @compID, @nyear , @val ,@description,@typeid,@accountNo, @accountNoHesap ,@accountNo2,@accountNoHesap2,0";
                result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, val = Math.Abs(value_), description = "(ACL) " + code_ + " Hesap Kodu-" + code2_, accountNo = code_, accountNo2 = code2_, accountNoHesap = "(ACL) " + code_ + " Hesap Kodu", accountNoHesap2 = "(ACL) " + code2_ + " Nolu Hesap İşlemleri", typeid = "1" }).FirstOrDefault();
            }
            else
            {


                string sqll = @"UPDATE TBLXMLSourceOne set  [Amount]=@vallue,[AmountBakiye]=@vallue ,[MainAmountTotal]=@vallue
                  where CompanyID=@compID and [Year]=@nyear  and AccountMainID in (@accountNo)";
                int result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, vallue = Math.Abs(chakValueMizanCreditvalue) * -1, accountNo = code_ }).FirstOrDefault();
                BeyannameChk.CheckCodeCompanyIdYear(_year, _compID, code2_);
                sqll = @"UPDATE TBLXMLSourceOne set  [Amount]=Amount+@vallue,[AmountBakiye]=AmountBakiye+@vallue ,[MainAmountTotal]=MainAmountTotal+@vallue
                  where CompanyID=@compID and [Year]=@nyear  and AccountMainID in (@accountNo)";
                result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, vallue = Math.Abs(chakValueMizanCreditvalue) + Math.Abs(value_), accountNo = code2_ }).FirstOrDefault();

                sqll = @"DELETE FROM SPO_TBMLAKTARMAFrst where  CompanyID=@compID and [Year]=@nyear  and TypeID=3 and AccountNo=@accountNo; INSERT INTO SPO_TBMLAKTARMAFrst([CompanyID], [YEAR], [Value], [Message], TypeID, AccountNo, AccountName, AccountNoII, AccountNameII,CheckValue)
                  Select @compID, @nyear , @val ,@description,@typeid,@accountNo, @accountNoHesap ,@accountNo2,@accountNoHesap2,@ValII";
                result = StaticQuery<int>(sqll, new { nyear = _year, compID = _compID, val = chakValueMizanCreditvalue, description = "(ACL) " + code_ + " Hesap Kodu-" + code2_, accountNo = code_, accountNo2 = code2_, accountNoHesap = "(ACL) " + code_ + " Hesap Kodu", accountNoHesap2 = "(ACL) " + code2_ + " Nolu Hesap İşlemleri", typeid = "3", ValII = Math.Abs(chakValueMizanCreditvalue) + Math.Abs(value_) }).FirstOrDefault();
                
            }



            return 0;
        }


        public static async Task<int> Set_MizanSubSetfirst(int _year, long _compID)
        {
            try
            {
                StaticQuery<object>("EXEC SampleMizanExcelSubA @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
                var nlist = RasyoAnalizMain.MizanAnalizStart(_year, _compID);

                MizanService service = new MizanService(nlist);

                var ListPlus = service.CalculatePlus();
                var ListMinus = service.CalculateMinus();
                ListPlus.AddRange(ListMinus);
                StaticQuery<int>("DELETE FROM CustomerCheck where CompanyID= @compdID and  [Year]=@nyear", new { nyear = _year, compdID = _compID }).FirstOrDefault();

                await service.BulkInsertSourceOneTAsync(ListPlus);

                return 1;
            }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
        }
        public static string Set_ReportStartAktarma(int _year, long _compID, List<int> typelist)
        {

            if (typelist.Contains(1))
            {
                Set_ReportSet1(_year, _compID);
            }

            if (typelist.Contains(2))
            {
                Set_ReportSet2(_year, _compID);
            }

            if (typelist.Contains(3))
            {
                Set_ReportSet3(_year, _compID);
            }

            if (typelist.Contains(4))
            {
                Set_ReportSet4(_year, _compID);
            }

            if (typelist.Contains(41))
            {
                Set_ReportSet41(_year, _compID);
            }

            if (typelist.Contains(5))
            {
                Set_ReportSet5(_year, _compID);
            }


            if (typelist.Contains(7))
            {
                Set_ReportSet7(_year, _compID);
            }

            if (typelist.Contains(8))
            {
                Set_ReportSet8(_year, _compID);
            }

            if (typelist.Contains(9))
            {
                Set_ReportSet9(_year, _compID);
            }

            if (typelist.Contains(91))
            {
                Set_ReportSet91(_year, _compID);
            }

            if (typelist.Contains(93))
            {
                Set_ReportSet93(_year, _compID);
            }

            if (typelist.Contains(51))
            {
                Set_ReportSet001(_year, _compID);
            }

            if (typelist.Contains(141))
            {
                Set_ReportSet141(_year, _compID);
            }

            if (typelist.Intersect(new List<int>() { 11, 13, 130, 131, 133, 135, 137, 139, 41, 14, 141, 143, 145, 15, 17, 18, 181, 19, 401, 403, 404, 405, 407, 408, 409, 411, 413, 415, 417, 419, 421, 911, 95, 97, 51, 55 }).Count() > 0)
            {
                var nlist = typelist.Intersect(new List<int>() { 11, 13, 130, 131, 133, 135, 137, 139, 41, 14, 141, 143, 145, 15, 17, 18, 181, 19, 401, 403, 404, 405, 407, 408, 409, 411, 413, 415, 417, 419, 421, 911, 95, 97, 51, 55 });
                foreach (int i in nlist) { Set_ReportSetNew(_year, _compID, i); Thread.Sleep(100); }

            }
            return "ok";
        }

        public static int Set_ReportSetNew(int _year, long _compID, int _num)
        {

            string queery = String.Format("EXEC [SPAKT_PROCT{0}] @companyID, @nyear", _num);


            try
            {

                return StaticQuery<int>(queery, new { nyear = _year, companyID = _compID }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
        }
        public static int Set_ReportSetfirst(int _year, long _compID)
        {
            try
            { return StaticQuery<int>("EXEC SPAKT_PROCT000First @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
        }
        public static int Set_ReportSet001(int _year, long _compID)
        {
            try
            { return StaticQuery<int>("EXEC SPAKT_PROCT001 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
        }
        public static int Set_ReportSet141(int _year, long _compID)
        {
            try
            { return StaticQuery<int>("EXEC [SPAKT_PROCT51] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
        }
        public static int Set_ReportSet1(int _year, long _compID)
        {
            try
            { return StaticQuery<int>("EXEC SPAKT_PROCT1 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
        }
        public static int Set_ReportSet2(int _year, long _compID)
        {
            try
            { return StaticQuery<int>("EXEC SPAKT_PROCT2 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
        }
        public static int Set_ReportSet3(int _year, long _compID)
        {
            try
            { return StaticQuery<int>("EXEC SPAKT_PROCT3 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
        }
        public static int Set_ReportSet4(int _year, long _compID)
        {
            try
            { return StaticQuery<int>("EXEC SPAKT_PROCT4 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
        }
        public static int Set_ReportSet41(int _year, long _compID)
        {
            try
            { return StaticQuery<int>("EXEC SPAKT_PROCT41 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
        }
        public static int Set_ReportSet5(int _year, long _compID)
        {
            try
            { return StaticQuery<int>("EXEC SPAKT_PROCT5 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
        }
        public static int Set_ReportSet7(int _year, long _compID)
        {
            try
            { return StaticQuery<int>("EXEC SPAKT_PROCT7 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
        }
        public static int Set_ReportSet8(int _year, long _compID)
        {
            try
            { return StaticQuery<int>("EXEC SPAKT_PROCT8 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
        }
        public static int Set_ReportSet9(int _year, long _compID)
        {
            try
            { return StaticQuery<int>("EXEC SPAKT_PROCT9 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
        }
        public static int Set_ReportSet91(int _year, long _compID)
        {
            try
            { return StaticQuery<int>("EXEC SPAKT_PROCT91 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
        }
        public static int Set_ReportSet93(int _year, long _compID)
        {
            try
            { return StaticQuery<int>("EXEC SPAKT_PROCT93 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
        }
    }
    public class ReportSetMain : BaseModel
    {

        public static int Set_ReportSetMain(int _year, long _compID)
        {
            try
            {
                return StaticQuery<int>("EXEC SPO_REPOR00GENERALTOTAL @companyID, @nyear,1", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }

            //SPO_COMPANYMIZANERR  SPO_DONUKCHK
        }
        public static int Set_ReportSetMulti(int _year, long _compID)
        {

            StaticQuery<int>("EXEC [dbo].[SP_TBLXMLSourceRepV3] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            StaticQuery<int>("EXEC [dbo].[SPO_COMPANYMIZANERR] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            return StaticQuery<int>("EXEC [dbo].[SPO_DONUKCHK] @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            //SPO_COMPANYMIZANERR  SPO_DONUKCHK  SPO_COMPANYMIZANERRMZN
        }
        public static int Set_ReportSet(int _year, long _compID)
        {

            StaticQuery<int>("EXEC [dbo].[SP_TBLXMLSourceRep] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            StaticQuery<int>("EXEC [dbo].[SPO_COMPANYMIZANERR] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();

            return StaticQuery<int>("EXEC [dbo].[SPO_DONUKCHK] @companyID, @nyear,1", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            //SPO_COMPANYMIZANERR  SPO_DONUKCHK  SPO_COMPANYMIZANERRMZN
        }
        public static int Set_ReportSetKon(int _year, long _compID)
        {


            return StaticQuery<int>("EXEC [dbo].[SPAKT_KONSOL_ALL] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            //SPO_COMPANYMIZANERR  SPO_DONUKCHK  SPO_COMPANYMIZANERRMZN
        }
        public static int Set_ReportSetKonM(int _year, long _compID)
        {


            return StaticQuery<int>("EXEC [dbo].[SPAKT_KONSOL_ALLM] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            //SPO_COMPANYMIZANERR  SPO_DONUKCHK  SPO_COMPANYMIZANERRMZN
        }
        public static List<YearlyErrorResult> Get_StatbyCompany(long _compID)
        {
            return StaticQuery<YearlyErrorResult>("EXEC SPOT_MIZANREPORTCOUNT @companyID", new { companyID = _compID }).ToList();
        }
        public static List<YearlyErrorResult> Get_StatbyCompanyConsole(long _compID)
        {
            return StaticQuery<YearlyErrorResult>("EXEC SPOT_MAINKONSOLCOUNT @companyID", new { companyID = _compID }).ToList();
        }
        public static List<YearlyErrorResult> Get_StatbyCompanyConsoleM(long _compID)
        {
            return StaticQuery<YearlyErrorResult>("EXEC SPOT_MAINKONSOLCOUNTM @companyID", new { companyID = _compID }).ToList();
        }
        public static List<YearlyErrorResult> Get_StatbyCompanyAktarmaMizan(long _compID)
        {
            return StaticQuery<YearlyErrorResult>("EXEC  SPOT_MAINREPORTCOUNTAKTRMMIZAN @companyID", new { companyID = _compID }).ToList();
        }
        public static List<YearlyErrorResult> Get_StatbyCompanyAktarma(long _compID)
        {
            return StaticQuery<YearlyErrorResult>("EXEC  SPOT_MAINREPORTCOUNTAKTRM @companyID", new { companyID = _compID }).ToList();
        }
        public static List<DashAktarma> Get_CompanyAktarmaResult(int _year, long _compID)
        {
            return StaticQuery<DashAktarma>("Select * from [SPO_TBMLAKTARMA] where CompanyID=@companyID and [YEAR]=@nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<YearlyErrorResult> StartCompanyAktarma(int _year, long _compID)
        {
            return StaticQuery<YearlyErrorResult>("EXEC  SPAKT_PROCALL @companyID, @nyear,1", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<YearlyErrorResult> StartCompanyAktarmaMizan(int _year, long _compID)
        {
            return StaticQuery<YearlyErrorResult>("EXEC  SPAKT_PROCALL @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<YearlyErrorResult> Get_StatbyCompanyAktarmaMZN(long _compID)
        {
            return StaticQuery<YearlyErrorResult>("EXEC  SPOT_MIZANREPORTCOUNTAKTRMExcel @companyID", new { companyID = _compID }).ToList();
        }
        public static List<YearlyErrorResult> Get_StatbyCompanyExcel(long _compID)
        {
            return StaticQuery<YearlyErrorResult>("EXEC SPOT_MIZANREPORTCOUNTExcel @companyID", new { companyID = _compID }).ToList();
        }
        public static List<YearlyErrorResult> Get_StatbyCompanyMain(long _compID)
        {
            return StaticQuery<YearlyErrorResult>("EXEC SPOT_MAINREPORTCOUNT @companyID", new { companyID = _compID }).ToList();
        }

        public static List<YearlyErrorResult> Get_StatbyCompanyMainQNB(long _compID)
        {
            return StaticQuery<YearlyErrorResult>("EXEC SPOT_MAINREPORTCOUNTQnb @companyID", new { companyID = _compID }).ToList();
        }

        public static List<ReportSet> Get_ReportSetBilanco(int _year, long _compID)
        {
            string sql = @"SELECT  
       [TypeID]
      ,[AccountMainID]
      ,[AccountMainDescription]
      ,[AccountMainEng]
      ,Cast([Amount] as bigint) as  Amount
      ,[DebitCreditCode] 
	  ,Cast([AmountBakiye] as bigint)  'AmountBakiye'
      ,CASE when [DebitCreditCode]='D'  and AccountMainID<>'692' THEN Cast([AmountBakiye] as bigint)
            when [DebitCreditCode]='C'  and Cast([AmountBakiye] as bigint)>0 THEN Cast([AmountBakiye] as bigint)ELSE 0 END as  BorcBakiye 
	  ,CASE when [DebitCreditCode]='C'  and AccountMainID<>'692'  and Cast([AmountBakiye] as bigint)<0  THEN Cast([AmountBakiye] as bigint) 
            when [DebitCreditCode]='D'  and AccountMainID ='692' THEN Cast([Credit] as bigint) 
            when [DebitCreditCode]='D'  and Cast([AmountBakiye] as bigint)=0 THEN 0 ELSE 0 END as  AlacakBakiye 
      ,[SubTypeID]
      ,[MainTypeID] 
      ,[IsErrored]
      ,Cast([MainAmountTotal] as bigint) as  MainAmountTotal,Cast([Debit] as bigint) as Debit ,Cast([Credit] as bigint) as Credit
  FROM [dbo].[TBLXMLSourceOne] where CompanyID=@companyID and  [Year]=@nyear and AccountMainID<800  order by AccountMainID";

            return StaticQuery<ReportSet>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<ReportSet> Get_ReportSetFiba(long _compID)
        {
            string sql = @"EXEC [dbo].[SP_A_MIZANHEADERChk] @comp";

            return StaticQuery<ReportSet>(sql, new { comp = _compID }).ToList();
        }
        public static List<ReportSet> Get_ReportSetBilancoMzn(int _year, long _compID)
        {
            string sql = @"EXEC [SPP_SMMMZN] @companyID,@nyear";

            return StaticQuery<ReportSet>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportSet> Get_ReportSetBilancoAkt(int _year, long _compID)
        {
            string sql = @"EXEC [SPP_SMMMZNAKT] @companyID,@nyear";

            return StaticQuery<ReportSet>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<ReportSet> Get_ReportSetBilancoAktJRNL(int _year, long _compID)
        {
            string sql = @"EXEC [SPP_SMMMZNAKTJRNL] @companyID,@nyear";

            return StaticQuery<ReportSet>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
    }
}
