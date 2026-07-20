using fincheckup.ENTITY;
using fincheckup.Models.NKolay.ViewM;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace fincheckup.Models.NKolay.ENTITY.Beyanname
{

    public class BeyannameGeciciView
    {
        public long ID { get; set; }
        public string AccountMainID { get; set; }
        public string AccountMainDescription;
        public string AccountMainDescriptionChk { get; set; }
        public double Amount;
        public double AmountBefore;
        public string MainID { get; set; }
        public string SubID { get; set; }
        public long CompanyID { get; set; }
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte IsRevenue { get; set; }
    }

    public class BeyannameChkGecici : BaseModel
    {

        public long ID { get; set; }
        public string AccountMainID { get; set; }
        public string AccountMainDescription => RemoveEmpty(this.AccountMainDescriptionChk);
        public string AccountMainDescriptionChk { get; set; }
        public double Amount => RemoveNonNumeric2(this.AccountMainDescriptionChk);
        public double AmountBefore => RemoveNonNumeric1(this.AccountMainDescriptionChk);
        public string MainID { get; set; }
        public string SubID { get; set; }
        public long CompanyID { get; set; }
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte IsRevenue { get; set; }


        public static List<BeyannameChkGecici> Get_BeyannameResult(long companyid_, int year_)
        {
            return StaticQuery<BeyannameChkGecici>("SELECT * FROM [dbo].[TBLXMLSourceByn]  where CompanyID=@compID and Year=@nyear", new { compID = companyid_, nyear = year_ }).ToList();
        }
        public static List<BeyannameGeciciView> Get_BeyannameResultMulti(long companyid_, int year_)
        {
            return StaticQuery<BeyannameGeciciView>("SELECT * FROM [dbo].[TBLXMLSourceByn]  where CompanyID=@compID and Year=@nyear", new { compID = companyid_, nyear = year_ }).ToList();
        }
        public static List<BeyannameChkGecici> Get_BeyannameResultLst(long companyid_, int year_)
        {
            return StaticQuery<BeyannameChkGecici>("SELECT * FROM [EDEFTERDB].[dbo].[TBLXMLSourceByn] where SubID not in (Select DISTINCT(SubID) from [TBLBeyanname])  and CompanyID=@compID and Year=@nyear", new { compID = companyid_, nyear = year_ }).ToList();
        }
        public static int LastSet(long ide_)
        {
            return StaticQuery<int>("UPDATE   [EDEFTERDB].[dbo].[TBLXMLSourceByn] set  SubID=(SELECT SubID FROM [EDEFTERDB].[dbo].[TBLXMLSourceByn] where  ID = (select top 1 ID from [TBLXMLSourceByn] Where ID<@ide order by ID desc)) where ID=@ide", new { ide = ide_ }).FirstOrDefault();
        }
        public static int LastFinished(long companyid_, int year_, int nmonth_)
        {
            return StaticQuery<int>("EXEC [SampleMizanBynLst] @compID,@nyear,@nmonth", new { compID = companyid_, nyear = year_, nmonth = nmonth_ }).FirstOrDefault();
        }
        public static int Delete(long companyid_, int year_)
        {
            return StaticQuery<int>("Delete from TBLXMLSourceByn where CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ }).FirstOrDefault();
        }
        public static int DeleteLast(long companyid_, int year_)
        {
            StaticQuery<int>("Delete FROM [EDEFTERDB].[dbo].[TBLXMLSourceByn] where [AccountMainDescription]='' and CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ }).FirstOrDefault();
            return StaticQuery<int>("Delete FROM [EDEFTERDB].[dbo].[TBLXMLSourceByn] where [Amount]=0 and [AmountBefore]=0 and CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ }).FirstOrDefault();
        }
        public void Save_Beyanname()
        {
            string sql = @" 

INSERT INTO [TBLXMLSourceByn]
          (  
        [AccountMainID] ,
        [AccountMainDescription] ,
        [Amount] ,
AmountBefore,
        [CompanyID] ,
        [Year]  ,IsRevenue,SubID,MainID
          ) 
           VALUES 
         (  
       @AccountMainID  ,
       @AccountMainDescription ,
       @Amount  ,
@AmountBefore,
       @CompanyID ,
       @Year  ,@IsRevenue,@SubID,@MainID

         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }

        public static string RemoveEmpty(string str)
        {
            List<string> nlist = str.Split(" ").ToList();
            if (nlist.Count < 3)
            {
                return string.Empty;
            }

            nlist.RemoveAt(nlist.Count - 1);
            string s = String.Join(" ", nlist.ToArray());

            if (s.Substring(0, 2) == ". ")
            {
                s = s.Substring(2);
            }

            return s;


        }
        public static double RemoveNonNumeric1(string str)
        {

            string[] nlist = str.Split(" ");
            if (nlist.Length < 3)
            {
                return 0;
            }
            string s = nlist[nlist.Length - 2];




            CultureInfo ci = CultureInfo.GetCultureInfo("tr-TR");
            string chk = string.Empty;
            chk = string.Concat(s?.Where(c => char.IsNumber(c) || c == '.' || c == ',' || c == '-' || c == '(' || c == ')') ?? string.Empty);

            if (chk.Trim().Length < 2 && (chk.Trim() == "-" || chk.Trim() == ")" || chk.Trim() == "(") || chk.Trim().Length < 1)
            {
                chk = "0";
            }

            if (chk.IndexOf("(") >= 0 && chk.IndexOf(")") >= 0)
            {
                chk = chk.Replace("(", "-").Replace(")", string.Empty);

            }
            string addedPoint = string.Empty;
            string addedDecimal = string.Empty;
            chk = chk.Trim();
            if (chk.Length < 2 && chk == "-" || chk.Length < 1)
            {
                chk = "0";
            }

            if (chk.Length >= 2 && chk.Substring(chk.Length - 2, 1) == ",")
            {
                addedPoint = ",";
                addedDecimal = chk.Substring(chk.Length - 1);
                chk = chk.Substring(0, chk.Length - 2);

            }


            if (chk.Length >= 3 && chk.Substring(chk.Length - 3, 1) == ",")
            {
                addedPoint = ",";
                addedDecimal = chk.Substring(chk.Length - 2);
                chk = chk.Substring(0, chk.Length - 3);

            }

            if (chk.Length >= 2 && chk.Substring(chk.Length - 2, 1) == ".")
            {
                addedPoint = ".";
                addedDecimal = chk.Substring(chk.Length - 1);
                chk = chk.Substring(0, chk.Length - 2);

            }


            if (chk.Length >= 3 && chk.Substring(chk.Length - 3, 1) == ".")
            {
                addedPoint = ".";
                addedDecimal = chk.Substring(chk.Length - 2);
                chk = chk.Substring(0, chk.Length - 3);

            }

            chk = chk.Replace(",", string.Empty).Replace(".", string.Empty);
            chk = chk + addedPoint + addedDecimal;
            if (addedPoint.Length > 0)
            {
                chk = chk.Replace(addedPoint,
CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalSeparator);
            }



            try
            {


                var result = double.Parse(chk, NumberStyles.AllowDecimalPoint | NumberStyles.Number, CultureInfo.InvariantCulture);
                return result;
                // return chk.ToDecimalInvariant();// Convert.ToDouble(chk,CultureInfo.InvariantCulture.NumberFormat);

            }
            catch
            {
                var tt = chk;
                return 0;
            }

        }
        public static double RemoveNonNumeric2(string str)
        {
            string[] nlist = str.Split(" ");

            string s = nlist[nlist.Length - 1];


            CultureInfo ci = CultureInfo.GetCultureInfo("tr-TR");
            string chk = string.Empty;
            chk = string.Concat(s?.Where(c => char.IsNumber(c) || c == '.' || c == ',' || c == '-' || c == '(' || c == ')') ?? string.Empty);

            if (chk.Trim().Length < 2 && (chk.Trim() == "-" || chk.Trim() == ")" || chk.Trim() == "(") || chk.Trim().Length < 1)
            {
                chk = "0";
            }

            if (chk.IndexOf("(") >= 0 && chk.IndexOf(")") >= 0)
            {
                chk = chk.Replace("(", "-").Replace(")", string.Empty);

            }
            string addedPoint = string.Empty;
            string addedDecimal = string.Empty;
            chk = chk.Trim();
            if (chk.Length < 2 && chk == "-" || chk.Length < 1)
            {
                chk = "0";
            }

            if (chk.Length >= 2 && chk.Substring(chk.Length - 2, 1) == ",")
            {
                addedPoint = ",";
                addedDecimal = chk.Substring(chk.Length - 1);
                chk = chk.Substring(0, chk.Length - 2);

            }


            if (chk.Length >= 3 && chk.Substring(chk.Length - 3, 1) == ",")
            {
                addedPoint = ",";
                addedDecimal = chk.Substring(chk.Length - 2);
                chk = chk.Substring(0, chk.Length - 3);

            }

            if (chk.Length >= 2 && chk.Substring(chk.Length - 2, 1) == ".")
            {
                addedPoint = ".";
                addedDecimal = chk.Substring(chk.Length - 1);
                chk = chk.Substring(0, chk.Length - 2);

            }


            if (chk.Length >= 3 && chk.Substring(chk.Length - 3, 1) == ".")
            {
                addedPoint = ".";
                addedDecimal = chk.Substring(chk.Length - 2);
                chk = chk.Substring(0, chk.Length - 3);

            }



            chk = chk.Replace(",", string.Empty).Replace(".", string.Empty);
            chk = chk + addedPoint + addedDecimal;
            if (addedPoint.Length > 0)
            {
                chk = chk.Replace(addedPoint,
CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalSeparator);
            }



            try
            {


                var result = double.Parse(chk, NumberStyles.AllowDecimalPoint | NumberStyles.Number, CultureInfo.InvariantCulture);
                return result;
                // return chk.ToDecimalInvariant();// Convert.ToDouble(chk,CultureInfo.InvariantCulture.NumberFormat);

            }
            catch
            {
                var tt = chk;
                return 0;
            }

        }
    }

    public class BeyannameChk : BaseModel
    {
        public BeyannameChk()
        { }
        public long ID { get; set; }
        public string AccountMainID { get; set; }
        public string AccountMainDescription => RemoveEmpty(this.AccountMainDescriptionChk, this.IsGecici, this.IsEnflasyon,this.IsGeciciNew);
        public string AccountMainDescriptionChk { get; set; }
        public double Amount => RemoveNonNumeric2(this.AccountMainDescriptionChk);
        public double AmountBefore => RemoveNonNumeric1(this.AccountMainDescriptionChk, this.IsGecici, this.IsEnflasyon, this.IsRevenue);
        public string MainID { get; set; }
        public string SubID { get; set; }
        public long CompanyID { get; set; }
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte IsRevenue { get; set; }
        public byte IsGecici { get; set; }
        public byte IsGeciciNew { get; set; }
        public byte IsEnflasyon { get; set; }

        public static List<BeyannameChk> Get_BeyannameResult(long companyid_, int year_)
        {
            return StaticQuery<BeyannameChk>("SELECT * FROM [dbo].[TBLXMLSourceByn]  where CompanyID=@compID and Year=@nyear", new { compID = companyid_, nyear = year_ }).ToList();
        }
        public static void CheckCodeCompanyIdYear(int _year, long _compID, string code_)
        {
            string sqllCount = @"select Count(*)  from TBLXMLSourceOne where AccountMainID=@code and CompanyID=@companyID and [Year]=@nyear";
            int nCount = StaticQuery<int>(sqllCount, new { nyear = _year, companyID = _compID, code = code_ }).FirstOrDefault();
            if (nCount < 1)
            {

                string sqll = @"INSERT INTO [dbo].[TBLXMLSourceOne] ([TypeID]
      ,[AccountMainID]
      ,[AccountMainDescription]
      ,[AccountMainEng]
      ,[Amount]
      ,[DebitCreditCode]
      ,[CompanyID]
      ,[AmountBakiye]
      ,[Year]
      ,[SubTypeID]
      ,[MainTypeID]
      ,[IsNegative]
      ,[IsErrored]
      ,[MainAmountTotal]) Select top 1 [TypeID]
      ,Code
      ,MainDescription
      ,MainDescriptionEng
      ,0
      ,DebitCredit
      ,@companyID
      ,0
      ,@nyear
      ,[SubTypeID]
      ,[MainTypeID]
      ,IsNegatif
      ,0
      ,0 from MCodeZen where   Code=@code ";

                StaticQuery<int>(sqll, new { nyear = _year, companyID = _compID, code = code_ }).FirstOrDefault();
            }
        }
        public static int Get_BeyannameCountChk(long companyid_, int year_)
        {
            ReportSet  tet= StaticQuery<ReportSet>("SELECT top 1 * FROM [dbo].[TBLXMLSourceOneBck]  where CompanyID=@compID and Year=@nyear  order by ID desc", new { compID = companyid_, nyear = year_ }).FirstOrDefault();

            if (tet.IsBeyan && tet.MainMonth==12)
            {
                return 1;
            }
            else
            {
                return 0;
            }
           
        }
        public static List<BeyannameChk> Get_BeyannameResultLst(long companyid_, int year_)
        {
            return StaticQuery<BeyannameChk>("SELECT * FROM [EDEFTERDB].[dbo].[TBLXMLSourceByn] where SubID not in (Select DISTINCT(SubID) from [TBLBeyanname])  and CompanyID=@compID and Year=@nyear", new { compID = companyid_, nyear = year_ }).ToList();
        }
        public static List<BeyannameChk> Get_BeyannameResultLstChk(long companyid_, int year_)
        {
            return StaticQuery<BeyannameChk>("SELECT * FROM [EDEFTERDB].[dbo].[TBLXMLSourceBynChk] where SubID not in (Select DISTINCT(SubID) from [TBLBeyanname])  and CompanyID=@compID and Year=@nyear", new { compID = companyid_, nyear = year_ }).ToList();
        }
        public static int LastSet(long ide_)
        {
            return StaticQuery<int>("UPDATE   [EDEFTERDB].[dbo].[TBLXMLSourceByn] set  SubID=(SELECT SubID FROM [EDEFTERDB].[dbo].[TBLXMLSourceByn] where  ID = (select top 1 ID from [TBLXMLSourceByn] Where ID<@ide order by ID desc)) where ID=@ide", new { ide = ide_ }).FirstOrDefault();
        }
        public static int LastSetChk(long ide_)
        {
            return StaticQuery<int>("UPDATE   [EDEFTERDB].[dbo].[TBLXMLSourceBynChk] set  SubID=(SELECT SubID FROM [EDEFTERDB].[dbo].[TBLXMLSourceBynChk] where  ID = (select top 1 ID from [TBLXMLSourceByn] Where ID<@ide order by ID desc)) where ID=@ide", new { ide = ide_ }).FirstOrDefault();
        }
        public static int LastFinished(long companyid_, int year_, int  nmonth_ )
        {
            return StaticQuery<int>("EXEC [SampleMizanBynLst] @compID,@nyear,@nmonth", new { compID = companyid_, nyear = year_, nmonth = nmonth_ }).FirstOrDefault();
        }
        public static int LastFinishedChk(long companyid_, int year_, int nmonth_)
        {
            return StaticQuery<int>("EXEC [SampleMizanBynLstChk] @compID,@nyear,@nmonth", new { compID = companyid_, nyear = year_, nmonth = nmonth_ }).FirstOrDefault();
        }
        public static int LastFinishedChkNew(long companyid_, int year_, int nmonth_)
        {
            return StaticQuery<int>("EXEC [SampleMizanBynLstChkNew] @compID,@nyear,@nmonth", new { compID = companyid_, nyear = year_, nmonth = nmonth_ }).FirstOrDefault();
        }
         
        public static int Delete(long companyid_, int year_)
        {
            return StaticQuery<int>("Delete from TBLXMLSourceByn where CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ }).FirstOrDefault();
        }
        public static int DeleteChk(long companyid_, int year_)
        {
            return StaticQuery<int>("Delete from TBLXMLSourceBynChk where CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ }).FirstOrDefault();
        }
        public static int DeleteLast(long companyid_, int year_)
        {
            StaticQuery<int>("Delete FROM [EDEFTERDB].[dbo].[TBLXMLSourceByn] where [AccountMainDescription]='' and CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ }).FirstOrDefault();
            return StaticQuery<int>("Delete FROM [EDEFTERDB].[dbo].[TBLXMLSourceByn] where [Amount]=0 and [AmountBefore]=0 and CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ }).FirstOrDefault();
        }
        public static int DeleteLastChk(long companyid_, int year_)
        {
            StaticQuery<int>("Delete FROM [EDEFTERDB].[dbo].[TBLXMLSourceBynChk] where [AccountMainDescription]='' and CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ }).FirstOrDefault();
            return StaticQuery<int>("Delete FROM [EDEFTERDB].[dbo].[TBLXMLSourceBynChk] where [Amount]=0 and [AmountBefore]=0 and CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ }).FirstOrDefault();
        }
        public void Save_BeyannameChk()
        {
            try
            {
                string sql = @" 

INSERT INTO [TBLXMLSourceBynChk]
          (  
        [AccountMainID] ,
        [AccountMainDescription] ,
        [Amount] ,
AmountBefore,
        [CompanyID] ,
        [Year]  ,IsRevenue,SubID,MainID
          ) 
           VALUES 
         (  
       @AccountMainID  ,
       @AccountMainDescription ,
       @Amount  ,
@AmountBefore,
       @CompanyID ,
       @Year  ,@IsRevenue,@SubID,@MainID

         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
                this.ID = Query<int>(sql, this).FirstOrDefault();
            }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }

        }
        public void Save_Beyanname()
        {
            try
            {
                string sql = @" 

INSERT INTO [TBLXMLSourceByn]
          (  
        [AccountMainID] ,
        [AccountMainDescription] ,
        [Amount] ,
AmountBefore,
        [CompanyID] ,
        [Year]  ,IsRevenue,SubID,MainID
          ) 
           VALUES 
         (  
       @AccountMainID  ,
       @AccountMainDescription ,
       @Amount  ,
@AmountBefore,
       @CompanyID ,
       @Year  ,@IsRevenue,@SubID,@MainID

         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
                this.ID = Query<int>(sql, this).FirstOrDefault();
            }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }

        }

        public static string RemoveEmpty(string str, byte isreve, byte isenflasyon, byte isgecicinew)
        {
            string s = "";
            List<string> nlist = new List<string>();
            try
            {
                nlist= str.Split(" ").ToList();
                if (nlist.Count < 3 || str.Contains("Enflasyon Düzeltmesi Sonrası") || str.Contains("AYRINTILI GELİR TABLOSU"))
                {
                    return string.Empty;
                }

                nlist.RemoveAt(nlist.Count - 1);
                if (isreve < 1 && isgecicinew==0)
                {
                    nlist.RemoveAt(nlist.Count - 1);

                    if (isenflasyon > 0)
                    {
                        nlist.RemoveAt(nlist.Count - 1);
                    }
                }


                  s = String.Join(" ", nlist.ToArray());

                if (s.Length>1 && s.Substring(0, 2) == ". ")
                {
                    s = s.Substring(2);
                }

            }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }
          
            return s;


        }
        public static double RemoveNonNumeric1(string str, byte isgeci, byte isenf, byte isreve)
        {
            if (isgeci > 0)
            {
                return 0;
            }


            string[] nlist = str.Split(" ");
            if (nlist.Length < 3)
            {
                return 0;
            }
            string s = nlist[nlist.Length - 2];
            if (isenf > 0 && isreve<1)
            {
                s = nlist[nlist.Length - 3];
            }



            CultureInfo ci = CultureInfo.GetCultureInfo("tr-TR");
            string chk = string.Empty;
            chk = string.Concat(s?.Where(c => char.IsNumber(c) || c == '.' || c == ',' || c == '-' || c == '(' || c == ')') ?? string.Empty);

            if (chk.Trim().Length < 2 && (chk.Trim() == "-" || chk.Trim() == ")" || chk.Trim() == "(") || chk.Trim().Length < 1)
            {
                chk = "0";
            }

            if (chk.IndexOf("(") >= 0 && chk.IndexOf(")") >= 0)
            {
                chk = chk.Replace("(", "-").Replace(")", string.Empty);

            }
            string addedPoint = string.Empty;
            string addedDecimal = string.Empty;
            chk = chk.Trim();
            if (chk.Length < 2 && chk == "-" || chk.Length < 1)
            {
                chk = "0";
            }

            if (chk.Length >= 2 && chk.Substring(chk.Length - 2, 1) == ",")
            {
                addedPoint = ",";
                addedDecimal = chk.Substring(chk.Length - 1);
                chk = chk.Substring(0, chk.Length - 2);

            }


            if (chk.Length >= 3 && chk.Substring(chk.Length - 3, 1) == ",")
            {
                addedPoint = ",";
                addedDecimal = chk.Substring(chk.Length - 2);
                chk = chk.Substring(0, chk.Length - 3);

            }

            if (chk.Length >= 2 && chk.Substring(chk.Length - 2, 1) == ".")
            {
                addedPoint = ".";
                addedDecimal = chk.Substring(chk.Length - 1);
                chk = chk.Substring(0, chk.Length - 2);

            }


            if (chk.Length >= 3 && chk.Substring(chk.Length - 3, 1) == ".")
            {
                addedPoint = ".";
                addedDecimal = chk.Substring(chk.Length - 2);
                chk = chk.Substring(0, chk.Length - 3);

            }

            chk = chk.Replace(",", string.Empty).Replace(".", string.Empty);
            chk = chk + addedPoint + addedDecimal;
            if (addedPoint.Length > 0)
            {
                chk = chk.Replace(addedPoint,
CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalSeparator);
            }


            try
            {


                var result = double.Parse(chk, NumberStyles.AllowDecimalPoint | NumberStyles.Number, CultureInfo.InvariantCulture);
                return result;
                // return chk.ToDecimalInvariant();// Convert.ToDouble(chk,CultureInfo.InvariantCulture.NumberFormat);

            }
            catch
            {
                var tt = chk;
                return 0;
            }

        }
        public static double RemoveNonNumeric2(string str )
        {
            //            string[] nlist = str.Split(" ");
            //            string s = nlist[nlist.Length - 1];



            //            CultureInfo ci = CultureInfo.GetCultureInfo("tr-TR");
            //            string chk = string.Empty;
            //            chk = string.Concat(s?.Where(c => char.IsNumber(c) || c == '.' || c == ',' || c == '-' || c == '(' || c == ')') ?? string.Empty);

            //            if (chk.Trim().Length < 2 && (chk.Trim() == "-" || chk.Trim() == ")" || chk.Trim() == "(") || chk.Trim().Length < 1)
            //            {
            //                chk = "0";
            //            }

            //            if (chk.IndexOf("(") >= 0 && chk.IndexOf(")") >= 0)
            //            {
            //                chk = chk.Replace("(", "-").Replace(")", string.Empty);

            //            }
            //            string addedPoint = string.Empty;
            //            string addedDecimal = string.Empty;
            //            chk = chk.Trim();
            //            if (chk.Length < 2 && chk == "-" || chk.Length < 1)
            //            {
            //                chk = "0";
            //            }

            //            if (chk.Length >= 2 && chk.Substring(chk.Length - 2, 1) == ",")
            //            {
            //                addedPoint = ",";
            //                addedDecimal = chk.Substring(chk.Length - 1);
            //                chk = chk.Substring(0, chk.Length - 2);

            //            }


            //            if (chk.Length >= 3 && chk.Substring(chk.Length - 3, 1) == ",")
            //            {
            //                addedPoint = ",";
            //                addedDecimal = chk.Substring(chk.Length - 2);
            //                chk = chk.Substring(0, chk.Length - 3);

            //            }

            //            if (chk.Length >= 2 && chk.Substring(chk.Length - 2, 1) == ".")
            //            {
            //                addedPoint = ".";
            //                addedDecimal = chk.Substring(chk.Length - 1);
            //                chk = chk.Substring(0, chk.Length - 2);

            //            }


            //            if (chk.Length >= 3 && chk.Substring(chk.Length - 3, 1) == ".")
            //            {
            //                addedPoint = ".";
            //                addedDecimal = chk.Substring(chk.Length - 2);
            //                chk = chk.Substring(0, chk.Length - 3);

            //            }



            //            chk = chk.Replace(",", string.Empty).Replace(".", string.Empty);
            //            chk = chk + addedPoint + addedDecimal;
            //            if (addedPoint.Length > 0)
            //            {
            //                chk = chk.Replace(addedPoint,
            //CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalSeparator);
            //            }

            string[] nlist = str.Split(" ");

            string s = nlist[nlist.Length - 1];

            s = s.Replace(".-", "");
            CultureInfo ci = CultureInfo.GetCultureInfo("tr-TR");
            string chk = string.Empty;




            chk = string.Concat(s?.Where(c => char.IsNumber(c) || c == '.' || c == ',' || c == '-' || c == '(' || c == ')') ?? string.Empty);

            if (chk.Trim().Length < 2 && (chk.Trim() == "-" || chk.Trim() == ")" || chk.Trim() == "(") || chk.Trim().Length < 1)
            {
                chk = "0";
            }

            if (chk.IndexOf("(") >= 0 && chk.IndexOf(")") >= 0)
            {
                chk = chk.Replace("(", "-").Replace(")", string.Empty);

            }
            string addedPoint = string.Empty;
            string addedDecimal = string.Empty;
            chk = chk.Trim();
            if (chk.Length < 2 && chk == "-" || chk.Length < 1)
            {
                chk = "0";
            }

            if (chk.Length >= 2 && chk.Substring(chk.Length - 2, 1) == ",")
            {
                addedPoint = ",";
                addedDecimal = chk.Substring(chk.Length - 1);
                chk = chk.Substring(0, chk.Length - 2);

            }


            if (chk.Length >= 3 && chk.Substring(chk.Length - 3, 1) == ",")
            {
                addedPoint = ",";
                addedDecimal = chk.Substring(chk.Length - 2);
                chk = chk.Substring(0, chk.Length - 3);

            }

            if (chk.Length >= 2 && chk.Substring(chk.Length - 2, 1) == ".")
            {
                addedPoint = ".";
                addedDecimal = chk.Substring(chk.Length - 1);
                chk = chk.Substring(0, chk.Length - 2);

            }


            if (chk.Length >= 3 && chk.Substring(chk.Length - 3, 1) == ".")
            {
                addedPoint = ".";
                addedDecimal = chk.Substring(chk.Length - 2);
                chk = chk.Substring(0, chk.Length - 3);

            }



            chk = chk.Replace(",", string.Empty).Replace(".", string.Empty);
            chk = chk + addedPoint + addedDecimal;
            if (addedPoint.Length > 0)
            {
                chk = chk.Replace(addedPoint,
CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalSeparator);
            }



            try
            {


                var result = double.Parse(chk, NumberStyles.AllowDecimalPoint | NumberStyles.Number, CultureInfo.InvariantCulture);
                return result;
                // return chk.ToDecimalInvariant();// Convert.ToDouble(chk,CultureInfo.InvariantCulture.NumberFormat);

            }
            catch
            {
                var tt = chk;
                return 0;
            }

        }
    }


}
