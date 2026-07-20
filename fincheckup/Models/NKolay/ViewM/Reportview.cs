namespace fincheckup.Models.NKolay.ViewM
{
    public class Reportview
    {     //[TBLXMLSourceOne]   SP_TBLXMLSourceRep
        public int ID { get; set; }
        public byte TypeID { get; set; }
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string AccountMainEng { get; set; }
        public float Amount { get; set; }
        public string DebitCreditCode { get; set; }
        public long CompanyID { get; set; }
        public float AmountBakiye { get; set; }
        public int Year { get; set; }
        public byte SubTypeID { get; set; }
        public byte MainTypeID { get; set; }
        public bool IsNegative { get; set; }

    }

    public class ReportviewHeader
    {
        //[TBLXMLSourceChk]    SP_TBLXMLSourceRepZone
        public int ID { get; set; }
        public float Amount { get; set; }
        public long CompanyID { get; set; }
        public float AmountBakiye { get; set; }
        public int Year { get; set; }
        public byte SubTypeID { get; set; }
        public byte MainTypeID { get; set; }

    }
}
