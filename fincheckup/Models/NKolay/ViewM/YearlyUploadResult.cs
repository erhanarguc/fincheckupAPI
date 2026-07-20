using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.ViewM
{
    public class YearlyUploadResult
    {
        public int MainYear { get; set; }
        public int MainMonth { get; set; }
        public long CsvID { get; set; }
        public int ErrorCount { get; set; }
        public string DocumentMonth { get; set; }
        public string DocumentMonthTr { get; set; }
        public string TxResult { get; set; }
        public string XmlDocName { get; set; }
        public bool IsUplodedMonth=> ErrorCount<0?false:true;
        public string TxResultShort => MainMonth.ToString() + "_" + MainYear.ToString();
    }
    public class SourceOneT
    {
        public long ID { get; set; }
        public string AccountSubMain { get; set; }
        public string AccountMainID { get; set; }
        public string AccountSubID { get; set; }
        public string AccountSubDescription { get; set; }
        public long CompanyID { get; set; }
        public int Year { get; set; }
        public double? AmountBakiye { get; set; }
        public string DebitCreditCode { get; set; }
    }
    public class DebitCreditResult
    {
        public string MVal { get; set; }
        public string MText { get; set; }

        public static IEnumerable<DebitCreditResult> getValue()
        {
            List<DebitCreditResult> nresult = new List<DebitCreditResult>();


            DebitCreditResult nval = new DebitCreditResult();
            nval.MVal = "D";
            nval.MText = "(D)-Debit";
            nresult.Add(nval);
            nval = new DebitCreditResult();
            nval.MVal = "C";
            nval.MText = "(C)-Credit";
            nresult.Add(nval);
            return nresult;
        }
    }

    public class SourceResult
    {
        public int MYear { get; set; }
        public string MText { get; set; }

		public string ShortText { get; set; }
		public static IEnumerable<SourceResult> getValue()
        {
            List<SourceResult> nresult = new List<SourceResult>();


            SourceResult nval = new SourceResult();
            nval.MYear = 0;
            nval.MText = "Bilgisayarımdan";
            nval.ShortText = "PC";
            nresult.Add(nval);

            nval = new SourceResult();
            nval.MYear = 1;
            nval.MText = "Qnb E-Finans";
			nval.ShortText = "QN";
			nresult.Add(nval);
            //nval = new SourceResult();
            //nval.MYear = 2;
            //nval.MText = "Mikro-Zirve";
            //nresult.Add(nval);

   //         nval = new SourceResult();
   //         nval.MYear = 3;
   //         nval.MText = "Uyumsoft ";
			//nval.ShortText = "US";
			//nresult.Add(nval);

   //         nval = new SourceResult();
   //         nval.MYear = 5;
   //         nval.MText = "Sovos";
			//nval.ShortText = "SV";
			//nresult.Add(nval);

			//nval = new SourceResult();
			//nval.MYear = 7;
			//nval.MText = "Uyumsoft Kurumsal ";
			//nval.ShortText = "UB";
			//nresult.Add(nval);

			//nval = new SourceResult();
			//nval.MYear = 9;
			//nval.MText = "Turkcell e-Şirket ";
			//nval.ShortText = "TE";
			//nresult.Add(nval);

			//nval = new SourceResult();
			//nval.MYear = 11;
			//nval.MText = "Mysoft ";
			//nval.ShortText = "MD";
			//nresult.Add(nval);

			//nval = new SourceResult();
			//nval.MYear = 13;
			//nval.MText = "İzibiz ";
			//nval.ShortText = "IT";
			//nresult.Add(nval);

			//nval = new SourceResult();
			//nval.MYear = 15;
			//nval.MText = "Bien Teknoloji ";
			//nval.ShortText = "BT";
			//nresult.Add(nval);

			//nval = new SourceResult();
			//nval.MYear = 17;
			//nval.MText = "Hızlı Bilişim ";
			//nval.ShortText = "HB";
			//nresult.Add(nval);

			//nval = new SourceResult();
			//nval.MYear = 19;
			//nval.MText = "Crssoft ";
			//nval.ShortText = "CT";
			//nresult.Add(nval);


			//nval = new SourceResult();
			//nval.MYear = 21;
			//nval.MText = "Park Entegrasyon ";
			//nval.ShortText = "PE";
			//nresult.Add(nval);


			//nval = new SourceResult();
			//nval.MYear = 23;
			//nval.MText = "Kolaysoft ";
			//nval.ShortText = "KT";
			//nresult.Add(nval);

			return nresult.OrderBy(x => x.MYear);
        }
        public static IEnumerable<SourceResult> getValueNom()
        {
            List<SourceResult> nresult = new List<SourceResult>();


            SourceResult nval = new SourceResult();
            nval.MYear = 0;
            nval.MText = "Bilgisayarımdan";
            nresult.Add(nval);

            SourceResult nval1 = new SourceResult();
            nval1.MYear = 4;
            nval1.MText = "Mikro-Zirve";
            nresult.Add(nval1);
            return nresult.OrderBy(x => x.MYear);
        }
    }
    public class YearResult
    {
        public int MYear { get; set; }
        public string MText { get; set; }

        public static IEnumerable<YearResult> getValue()
        {
            List<YearResult> nresult = new List<YearResult>();
            int fyear = DateTime.Now.AddYears(-5).Year;
            int lyear = DateTime.Now.Year;
            for (int i = fyear; i <= lyear; i++)
            {
                YearResult nval = new YearResult();
                nval.MYear = i;
                nval.MText = i.ToString();
                nresult.Add(nval);
            }
            return nresult.OrderBy(x => x.MYear);
        }

        public static IEnumerable<YearResult> getValuemonth()
        {
            List<YearResult> nresult = new List<YearResult>();
     
            for (int i = 1; i <= 12; i++)
            {
                YearResult nval = new YearResult();
                nval.MYear = i;
                nval.MText = i.ToString();
                nresult.Add(nval);
            }
            return nresult.OrderBy(x => x.MYear);
        }
    }
}
