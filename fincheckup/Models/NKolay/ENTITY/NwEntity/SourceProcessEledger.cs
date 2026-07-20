using System;

namespace fincheckup.Models.NKolay.ENTITY.NwEntity
{
    public class SourceProcessEledger
    {
    }
    public sealed class TBLXMLSourceRow
    {
        public int ID { get; set; }
        public string StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EnteredBy { get; set; }
        public string EnteredDate { get; set; }
        public string EntryNumber { get; set; }
        private string entryComment { get; set; }

        public string EntryComment
        {
            get { return entryComment; }
            set
            {
                if (value == null)
                {
                    entryComment = string.Empty;
                }
                else
                {
                    entryComment = value;
                }

            }
        }
        private string batchID { get; set; }
        public string BatchID
        {
            get { return batchID; }
            set
            {
                if (value == null)
                {
                    batchID = string.Empty;
                }
                else
                {
                    batchID = value;
                }

            }
        }

        private string batchDescription { get; set; }
        public string BatchDescription
        {
            get { return batchDescription; }
            set
            {
                if (value == null)
                {
                    batchDescription = string.Empty;
                }
                else
                {
                    batchDescription = value;
                }

            }
        }

        public double TotalDebit { get; set; }
        public double TotalCredit { get; set; }
        private string documentType { get; set; }

        public string DocumentType
        {
            get { return documentType; }
            set
            {
                if (value == null)
                {
                    documentType = string.Empty;
                }
                else
                {
                    documentType = value;
                }

            }
        }

        private string documentTypeDescription { get; set; }
        public string DocumentTypeDescription
        {
            get { return documentTypeDescription; }
            set
            {
                if (value == null)
                {
                    documentTypeDescription = string.Empty;
                }
                else
                {
                    documentTypeDescription = value;
                }

            }
        }
        private string documentNumber { get; set; }
        public string DocumentNumber
        {
            get { return documentNumber; }
            set
            {
                if (value == null)
                {
                    documentNumber = string.Empty;
                }
                else
                {
                    documentNumber = value;
                }

            }
        }

        public string DocumentDate { get; set; }

        private string paymentMethod { get; set; }
        public string PaymentMethod
        {
            get { return paymentMethod; }
            set
            {
                if (value == null)
                {
                    paymentMethod = string.Empty;
                }
                else
                {
                    paymentMethod = value;
                }

            }
        }
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string AccountSubDescription { get; set; }
        public string AccountSubID { get; set; }
        public double Amount { get; set; }
        public string DebitCreditCode { get; set; }
        public string PostingDate { get; set; }
        private string detailComment { get; set; }

        public string DetailComment
        {
            get { return detailComment; }
            set
            {
                if (value == null)
                {
                    detailComment = string.Empty;
                }
                else
                {
                    detailComment = value;
                }

            }
        }
        public long CsvID { get; set; }
        public int IsOpener { get; set; }
        public byte IsPassedEntry { get; set; }
        public byte IsFailed { get; set; }
        public bool ISChanged { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedDate { get; set; } 
        public long CompanyDocumentId { get; set; }
    }

    public sealed class WzoneRow
    {
        public int ID { get; set; }
        public int? MainDescriptionID { get; set; }
        public string MainDescription { get; set; }
    }
    public sealed class TBLErrzoneWord
    {  
        public int ID { get; set; }
        public int  ColorID { get; set; }
        public string MainDescription { get; set; }
        public string Description { get; set; }
        public string SecredWord { get; set; }
    }
    public record ErrzoneInsideDto(
    string EntryNumber,
    int ErrzoneInsideId,
    string DocumentDate,
    string EnteredBy,
    string AccountMainID,
    string AccountMainDescription,
    string AccountSubID,
    string AccountSubDescription,
    string DebitCreditCode,
    double Amount,
    string DetailComment,
    string PaymentMethod,
    string DocumentTypeDescription,
    DateTime EndDate,
    string EntryComment,
    byte ColorDescTax,
    string  DescriptionTax,
    byte ColorDescInside,
    string DescriptionInside
);
    public sealed class TBLErrzoneInsideWordRow
    {
        public int ID { get; set; }
        public int ErrorInsideID { get; set; } 
        public string Description { get; set; } 
    }
    public sealed class XmlChkSourceRow
    {
        public double TotalDebit { get; set; }
        public double  TotalCredit { get; set; }
        public string AccountMainID { get; set; }
        public long  CsvID { get; set; }
        public string EntryNumber { get; set; }
        public long CompanyDocumentId { get; set; }
    }
    public sealed class TBLErrzoneInsideXMLRow
    {
     
        public long  CsvID { get; set; }
        public string EntryNo { get; set; }
        public int ErrorInsideID { get; set; }
    }
    public sealed class XmlCheckGroupRow
    {
        public string EntryNumber { get; set; }
        public long CompanyDocumentId { get; set; }
        public double  TotalCredit { get; set; }
        public long  CsvID { get; set; }
        public string AccountMainIDList { get; set; }
        public bool IsFailed { get; set; }
    }

    public sealed class XmlCheckGroupMainRow
    {
        public string EntryNumber { get; set; }
        public long CompanyDocumentId { get; set; }
        public double  TotalCredit { get; set; }
        public long  CsvID { get; set; }
    }
}
