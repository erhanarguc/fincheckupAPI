using System;
using System.Globalization;
using System.Linq;

namespace fincheckup.Models.Mizan
{
    public class XmlExcelCheck
    {

        private string accountMainID { get; set; }
        public string AccountMainID
        {
            get { return accountMainID; }
            set
            {
                if (value == null)
                {
                    accountMainID = string.Empty;
                }
                else
                {
                    accountMainID = value;

                }
            }
        }

        public string AccountMainDescription { get; set; }
        public string DebitAmount { get; set; }
        public string CreditAmount { get; set; }
        public string AmountBakiye { get; set; }

    }
    public class XmlExcel
    {
        public long CompanyID { get; set; }
        public int Year { get; set; }
        public int MainMonth { get; set; }
        public long CsvID { get; set; }
        private string accountMainID { get; set; }
        public string AccountMainID
        {
            get { return accountMainID; }
            set
            {
                if (value == null)
                {
                    accountMainID = string.Empty;
                }
                else
                {
                    accountMainID = value;

                }
            }
        }

        public string AccountMainDescription { get; set; }
        public string DebitAmount { get; set; }
        public string CreditAmount { get; set; }
        public string AmountBakiye { get; set; }
        public string DebitBakiye { get; set; }
        public string CreditBakiye { get; set; }
        public string AccountMainIDMain => AccountMainID != null && AccountMainID.Length > 2 ? AccountMainID.Substring(0, 3) : string.Empty;
        private double amountBakiyeFloatmain { get; set; }
        private double debitAmountFloatmain { get; set; }
        private double creditAmountFloatmain { get; set; }
        private string AmountBakiyeTxa { get; set; }
        private string creditAmountTxa { get; set; }
        private string DebitAmountTxa { get; set; }
        public string AmountBakiyeTx => AmountBakiye == null ? "0" : AmountBakiye.Replace(" ", string.Empty);
        public string creditAmountTx => CreditAmount == null ? "0" : CreditAmount.Replace(" ", string.Empty);
        public string DebitAmountTx => DebitAmount == null ? "0" : DebitAmount.Replace(" ", string.Empty);
        public string DebitBakiyeMainFloatTx => DebitBakiye == null ? "0" : DebitBakiye.Replace(" ", string.Empty);
        public string CreditBakiyeMainFloatTx => CreditBakiye == null ? "0" : CreditBakiye.Replace(" ", string.Empty);
        public double AmountBakiyeFloat => RemoveNonNumeric2(AmountBakiyeTx);

        public double CreditAmountFloat => RemoveNonNumeric2(creditAmountTx);

        public double DebitAmountFloat => RemoveNonNumeric2(DebitAmountTx);
        public double DebitBakiyeMainFloat => RemoveNonNumeric2(DebitBakiyeMainFloatTx);
        public double CreditBakiyeMainFloat => RemoveNonNumeric2(CreditBakiyeMainFloatTx);

        public string AmountCredit { get; set; }
        public int DotSplitCount => AccountMainID != null ? AccountMainID.Split('.').Count() : 0;
        public int TextCount => AccountMainID != null ? AccountMainID.Replace(" ", string.Empty).Replace(".", string.Empty).Trim().Count() : 0;
        public static double RemoveNonNumeric2(string s)
        {
            CultureInfo ci = CultureInfo.GetCultureInfo("tr-TR");
            string chk = string.Empty;
            chk = string.Concat(s?.Where(c => char.IsNumber(c) || c == '.' || c == ',' || c == '-' || c == '(' || c == ')') ?? string.Empty);

            if (chk.Trim().Length < 2 && chk.Trim() == "-" || chk.Trim().Length < 1)
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
            catch (Exception)
            {

                return chk.ToDecimalInvariant();
            }

        }
    }
    public static class StringExtensions
    {
        public static double ToDecimalInvariant(this string value)
        {
            string chhkz = value.Replace(".", "").Replace(" ", "").Replace("-", "").Replace(",", "");
            if (string.IsNullOrEmpty(chhkz))
            {
                return 0;
            }
            return double.Parse(value, CultureInfo.InvariantCulture);
        }
    }
}
