using EINvoice.New;
using fincheckup.Models.NKolay.ViewM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay.ENTITY
{
    public class TBLXmJournalFile : BaseModel
    {
        public long ID { get; set; }
        public string AccountMainID { get; set; }
        public string DebitCredit { get; set; }
        public long CompanyID { get; set; }
        public int Year { get; set; }
        public float Amount { get; set; }
        public static List<TBLXmJournalFile> Update_AllbyMainID(long compide_, int yearid_, string mainid_)
        {
            string sql = string.Empty;
            sql = @"Update [TBLXMLSourceOne] set Amount=MainAmountTotal,AmountBakiye=MainAmountTotal where CompanyID=@compide and [Year]=@yearid and AccountMainID=@mainid";
            return StaticQuery<TBLXmJournalFile>(sql, new { compide = compide_, yearid = yearid_, mainid = mainid_ }).ToList();
        }
        public static List<TBLXmJournalFile> Delete_AllbyCompanyID(long compide_, int yearid_)
        {
            string sql = string.Empty;
            sql = @"DELETE FROM [TBLXmJournalFile] where CompanyID=@compide and [Year]=@yearid";
            return StaticQuery<TBLXmJournalFile>(sql, new { compide = compide_, yearid = yearid_ }).ToList();
        }
        public static List<TBLXmJournalFile> Get_Allbycompz(int yearid_, long compide_)
        {
            string sql = string.Empty;
            sql = @"Select * FROM [TBLXmJournalFile] where CompanyID=@compide and [Year]=@yearid";
            return StaticQuery<TBLXmJournalFile>(sql, new { compide = compide_, yearid = yearid_ }).ToList();
        }
        public static List<MainCodeView> Get_AllbycompzCode(int yearid_, long compide_)
        {
            string sql = string.Empty;
            sql = @"SELECT  [AccountMainID]       ,[AccountMainDescription]    FROM [EDEFTERDB].[dbo].[TBLXMLSourceOne] where [CompanyID]=@compide and [Year]=@yearid";
            return StaticQuery<MainCodeView>(sql, new { compide = compide_, yearid = yearid_ }).ToList();
        }
        public static List<MainCodeView> Get_AllbycompzCodeMain(int yearid_, long compide_)
        {
          string  sql = @"Select  Code as 'AccountMainID' ,Code+'-('+TRIM(DebitCredit) +')-'+MainDescription as AccountMainDescription FROM MCodeZen where  Code<'800'  order by Code";
            return StaticQuery<MainCodeView>(sql, new { compide = compide_, yearid = yearid_ }).ToList();
            //      string sql = @" INSERT INTO [dbo].[TBLXMLSourceOne] ([TypeID]
            //,[AccountMainID]
            //,[AccountMainDescription]
            //,[AccountMainEng]
            //,[Amount]
            //,[DebitCreditCode]
            //,[CompanyID]
            //,[AmountBakiye]
            //,[Year]
            //,[SubTypeID]
            //,[MainTypeID]
            //,[IsNegative]
            //,[IsErrored]
            //,[MainAmountTotal]) Select top 1 [TypeID]
            //,Code
            //,MainDescription
            //,MainDescriptionEng
            //,0
            //,DebitCredit
            //,@checkCompanyID
            //,0
            //,@nyear
            //,[SubTypeID]
            //,[MainTypeID]
            //,IsNegatif
            //,0
            //,0 from MCodeZen where   Code='300'";
        }
        public static int Get_AllbycompzCodeInsert(int yearid_, long compide_, string code_)
        {



            string sqlaRvn = @"INSERT INTO [dbo].[TBLMRevenueMzn]
           ([AccountMainID]
           ,[AccountMainDescription]
           ,[DebitCreditCode]
           ,[Amount]
           ,[CompanyID]
           ,[Year]
           ,[GroupName]
           ,[CounterZone]
           ,[TypeID]
           ,[IsHidden]) Select top 1   Code
      ,MainDescription  
      ,DebitCredit 
      ,0
      ,@checkCompanyID
      ,@nyear
      ,@groupnme
      ,[SubTypeID]
      ,[SubTypeID]
      ,0  from MCodeZen where   Code=@ncode";

            string sqlbRvn = @"INSERT INTO [dbo].[TBLMRevenueMzn]
           ([AccountMainID]
           ,[AccountMainDescription]
           ,[DebitCreditCode]
           ,[Amount]
           ,[CompanyID]
           ,[Year]
           ,[GroupName]
           ,[CounterZone]
           ,[TypeID]
           ,[IsHidden]) Select top 1   Code
      ,MainDescription  
      ,DebitCredit 
      ,0
      ,@checkCompanyID  * -1000000
      ,@nyear
      ,@groupnme
      ,[SubTypeID]
      ,[SubTypeID]
      ,0  from MCodeZen where   Code=@ncode";

            string sqlabln = @"INSERT INTO [dbo].[TBLMSampleBlncoMzn]
           ([AccountMainID]
           ,[AccountMainDescription]
           ,[DebitCreditCode]
           ,[Amount]
           ,[CompanyID]
           ,[Year]
           ,[GroupName]
           ,[CounterZone]
           ,[TypeID]
           ,[IsHidden]
           ,[CreatedDate])
Select top 1   Code
      ,MainDescription  
      ,DebitCredit 
      ,0
      ,@checkCompanyID
      ,@nyear
      ,@groupnme
      ,[SubTypeID]
      ,[SubTypeID]
      ,0
      ,getdate() from MCodeZen where   Code=@ncode";

            string sqlbbln = @"INSERT INTO [dbo].[TBLMSampleBlncoMzn]
           ([AccountMainID]
           ,[AccountMainDescription]
           ,[DebitCreditCode]
           ,[Amount]
           ,[CompanyID]
           ,[Year]
           ,[GroupName]
           ,[CounterZone]
           ,[TypeID]
           ,[IsHidden]
           ,[CreatedDate])
Select top 1   Code
      ,MainDescription  
      ,DebitCredit 
      ,0
      ,@checkCompanyID  * -1000000
      ,@nyear
      ,@groupnme
      ,[SubTypeID]
      ,[SubTypeID]
      ,0
      ,getdate() from MCodeZen where   Code=@ncode";




            string sql = @"INSERT INTO [dbo].[TBLXMLSourceOne] ([TypeID]
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
      ,@checkCompanyID
      ,0
      ,@nyear
      ,[SubTypeID]
      ,[MainTypeID]
      ,IsNegatif
      ,0
      ,0 from MCodeZen where   Code=@ncode"
            ;

            string sql1 = @"INSERT INTO [dbo].[TBLXMLSourceOne] ([TypeID]
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
      ,@checkCompanyID * -1000000
      ,0
      ,@nyear
      ,[SubTypeID]
      ,[MainTypeID]
      ,IsNegatif
      ,0
      ,0 from MCodeZen where   Code=@ncode"
          ;
            string groupcod = "";
            if (Convert.ToInt32(code_) < 600)
            {
                groupcod = checkstrBln(code_);
                StaticQuery<int>(sqlbbln, new { checkCompanyID = compide_, nyear = yearid_, ncode = code_, groupnme = groupcod }).FirstOrDefault();
                StaticQuery<int>(sqlabln, new { checkCompanyID = compide_, nyear = yearid_, ncode = code_, groupnme = groupcod }).FirstOrDefault();
            }
            else
            {
                groupcod = checkstrRvn(code_);
                StaticQuery<int>(sqlaRvn, new { checkCompanyID = compide_, nyear = yearid_, ncode = code_, groupnme = groupcod }).FirstOrDefault();
                StaticQuery<int>(sqlbRvn, new { checkCompanyID = compide_, nyear = yearid_, ncode = code_, groupnme = groupcod }).FirstOrDefault();

            }


            StaticQuery<int>(sql1, new { checkCompanyID = compide_, nyear = yearid_, ncode = code_ }).FirstOrDefault();

            return StaticQuery<int>(sql, new { checkCompanyID = compide_, nyear = yearid_, ncode = code_ }).FirstOrDefault();
        }
        public static string checkstrRvn(string chk)
        {
            string retval = "";

            int chkint = Convert.ToInt32(chk);

            if (chkint > 599 && chkint < 610)
            {
                retval = "A-Brüt Satışlar";
            }
            else if (chkint > 619 && chkint < 630)
            {
                retval = "B-Satış Indirimleri(-)";
            }
            else if (chkint > 629 && chkint < 640)
            {
                retval = "D-Satışların Maliyeti (-)";
            }
            else if (chkint > 639 && chkint < 650)
            {
                retval = "K-DİĞER FAALİYETLERDEN OLAĞAN GELİR VE KARLAR";
            }
            else if (chkint > 649 && chkint < 660)
            {
                retval = "L-DİĞER FAALİYETLERDEN OLAĞAN GİDER VE ZARARLAR";
            }
            else if (chkint > 669 && chkint < 680)
            {
                retval = "V-OLAĞANDIŞI GELIR VE KARLAR";
            }
            else if (chkint > 679 && chkint < 690)
            {
                retval = "Y-OLAĞANDIŞI GİDER VE ZARARLAR";
            }
            else if (chkint > 689 && chkint < 700)
            {
                retval = "Z1-DÖNEM KARI VERGİ VE DİĞ.YASAL YÜKÜMLÜLÜK KARŞILIĞI";
            }
            else if (chkint > 709 && chkint < 745)
            {
                retval = "E-SMM Satışların Maliyeti (Mizanda 7'li Gruplarda Bekleyen)";
            }


            return retval;
        }
        public static string checkstrBln(string chk)
        {
            string retval = "";

            int chkint = Convert.ToInt32(chk);

            if (chkint > 99 && chkint < 110)
            {
                retval = "A-Hazır Değerler";
            }
            else if (chkint > 109 && chkint < 120)
            {
                retval = "A1-Menkul Kıymetler";
            }
            else if (chkint > 119 && chkint < 130)
            {
                retval = "A2-Ticari Alacaklar";
            }
            else if (chkint > 129 && chkint < 140)
            {
                retval = "A3-Diğer Alacaklar";
            }
            else if (chkint > 139 && chkint < 160)
            {
                retval = "A4-Stoklar";
            }
            else if (chkint > 159 && chkint < 180)
            {
                retval = "A4_- İnşaat ve Onarım";
            }
            else if (chkint > 179 && chkint < 190)
            {
                retval = "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları";
            }
            else if (chkint > 189 && chkint < 200)
            {
                retval = "A6-Diğer Dönen Varlıklar";
            }
            else if (chkint > 219 && chkint < 230)
            {
                retval = "B1-Ticari Alacaklar";
            }
            else if (chkint > 229 && chkint < 240)
            {
                retval = "B2- Diğer Alacaklar";
            }
            else if (chkint > 239 && chkint < 250)
            {
                retval = "B3-Mali Duran Varlıklar";
            }
            else if (chkint > 249 && chkint < 260)
            {
                retval = "B4-Maddi Duran Varlıklar";
            }
            else if (chkint > 259 && chkint < 270)
            {
                retval = "B5-Maddi Olmayan Duran Varlıklar";
            }
            else if (chkint > 269 && chkint < 280)
            {
                retval = "B6-Özel Tükenmeye Tabii Varlıklar";
            }
            else if (chkint > 279 && chkint < 290)
            {
                retval = "B7-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları";
            }
            else if (chkint > 289 && chkint < 300)
            {
                retval = "B8-Diğer Duran Varlıklar";
            }
            else if (chkint > 299 && chkint < 310)
            {
                retval = "C-Kısa Vadeli Yükümlülükler Mali Borçlar";
            }
            else if (chkint > 319 && chkint < 330)
            {
                retval = "C1-Ticari Borçlar";
            }
            else if (chkint > 329 && chkint < 340)
            {
                retval = "C2-Diğer Çeşitli  Borçlar";
            }
            else if (chkint > 339 && chkint < 350)
            {
                retval = "C3-Alınan Avanslar";
            }
            else if (chkint > 349 && chkint < 360)
            {
                retval = "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri";
            }
            else if (chkint > 359 && chkint < 370)
            {
                retval = "C4-Ödenencek Vergi ve Diğer Yükümlülükler";
            }
            else if (chkint > 369 && chkint < 380)
            {
                retval = "C5- Borç ve Gider Karşılıkları";
            }
            else if (chkint > 379 && chkint < 390)
            {
                retval = "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları";
            }
            else if (chkint > 399 && chkint < 410)
            {
                retval = "D1- Uzun Vadeli Yükümlülükler Mali Borçlar";
            }
            else if (chkint > 419 && chkint < 430)
            {
                retval = "D2-Ticari Borçlar";
            }
            else if (chkint > 429 && chkint < 440)
            {
                retval = "D3-Diğer Borçlar";
            }
            else if (chkint > 439 && chkint < 450)
            {
                retval = "D4-Maddi Duran Varlıklar";
            }
            else if (chkint > 469 && chkint < 480)
            {
                retval = "D5-Borç ve Gider Karşılıkları";
            }
            else if (chkint > 479 && chkint < 490)
            {
                retval = "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları";
            }
            else if (chkint > 499 && chkint < 510)
            {
                retval = "E1-ÖZKAYNAKLAR Ödenmiş Sermaye";
            }
            else if (chkint > 519 && chkint < 530)
            {
                retval = "E2-Sermaye Yedekleri";
            }
            else if (chkint > 539 && chkint < 550)
            {
                retval = "E3-Kar Yedekleri";
            }
            else if (chkint > 550 && chkint < 590)
            {
                retval = "E4-Geçmiş Yıl Kar/Zarar";
            }
            else if (chkint > 589 && chkint < 600)
            {
                retval = "E5-Dönem Kar/Zarar";
            }

            return retval;
        }
        public static List<TBLXmJournalFile> Delete_AllbyMainID(long compide_, int yearid_, string mainid_)
        {
            string sql = string.Empty;
            sql = @"DELETE FROM [TBLXmJournalFile] where CompanyID=@compide and [Year]=@yearid and AccountMainID=@mainid";
            return StaticQuery<TBLXmJournalFile>(sql, new { compide = compide_, yearid = yearid_, mainid = mainid_ }).ToList();
        }
        public void Save_()
        {
            string sql = @"  INSERT INTO [TBLXmJournalFile]
          (  
        [AccountMainID] ,
        [CompanyID] ,
        [Year] ,
        [Amount]  ,
        [DebitCredit] 
          ) 
           VALUES 
         (  
        @AccountMainID ,
        @CompanyID ,
        @Year ,
        @Amount  ,
        @DebitCredit 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<int>(sql, this).FirstOrDefault();

            string sqlt = @"UPDATE
                            [TBLXmJournalFile]
                            SET
                            [TBLXmJournalFile].IsNegatif=  ( CASE WHEN SI.DebitCredit = RAN.DebitCredit THEN 0 ELSE 1 END)
                            FROM
                                [TBLXmJournalFile] SI
                            INNER JOIN
                                [MCodeZen] RAN
                            ON 
                            SI.AccountMainID = RAN.Code where SI.ID=@ide";
            Query<int>(sqlt, new { ide = this.ID }).FirstOrDefault();

        }
    }
}
