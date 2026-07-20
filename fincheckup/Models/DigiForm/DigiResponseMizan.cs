namespace fincheckup.Models.DigiForm
{
    public class DigiResponseMizan
    {

        public int DocumentId { get; set; }
        public int DocumentStateId { get; set; }
        public Datum[] Data { get; set; }
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }

    }
    public class SPO_TBMLAKTARMAMtchView
    {
        public long ID { get; set; }
        public string AccountNo { get; set; }
        public string AccountNoII { get; set; }
        public long Value { get; set; }
        public char DebitCredit { get; set; }
        public long ValueII { get; set; }
    }
    public class Datum
    {
        public int PageNo { get; set; }
        public string HesapKodu { get; set; }
        public string HesapAdi { get; set; }
        public double Borc { get; set; }
        public double Alacak { get; set; }
        public double BorcBakiye { get; set; }
        public double AlacakBakiye { get; set; }
    }
    public class DigiRequestMizan
    {
        public string documentId { get; set; }
        public string documentCode { get; set; }
        public string contentBase64 { get; set; } // Base64 encoded file

        public DigiRequestMizan(string contentBase64, string docnumber)
        {
            this.contentBase64 = contentBase64;
            this.documentId = docnumber;
            this.documentCode = DigiApiConstant.DocumentMizanCODE;
        }
    }
    public class DigiGenericResult
    {
        public int ResultCode { get; set; }
        public string? ResultMessage { get; set; }
    }
    public class DigiRequestBeyanname
    {
        public string documentId { get; set; }
        public string documentCode { get; set; }
        public string contentBase64 { get; set; } // Base64 encoded file

        public DigiRequestBeyanname(string contentBase64, string docNumber)
        {
            this.contentBase64 = contentBase64;
            this.documentId = docNumber;
            this.documentCode = DigiApiConstant.DocumentBeyannameCODE;
        }
    }
    public class DigiApiConstant
    {
        public static string DocumentMizanCODE { get { return "MIZAN"; } }
        public static string DocumentBeyannameCODE { get { return "BEYANNAME"; } }
    }
} 
