using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.ViewM
{
    public class DataViewer
    {
        public string EntryNumber { get; set; }
        public string DocumentDate { get; set; }
        public string EnteredBy { get; set; }
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string AccountSubID { get; set; }
        public string AccountSubDescription { get; set; }
        public string DebitCreditCode { get; set; }
        public float Amount { get; set; }
        public string DetailComment { get; set; }
        public string PaymentMethod { get; set; }
        public string DocumentTypeDescription { get; set; }
        public string GroupName { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int ColorDesc { get; set; }
        public string DescriptionTax { get; set; }
        public int ColorDescTax { get; set; }
        public string DescriptionInside { get; set; }
        public int ColorDescInside { get; set; }
    }
    public class DataViewerError
    {
        public string ID { get; set; }
        public string companyid { get; set; }
        public string year { get; set; }
        public string MainDescription { get; set; }
        public string EntryNumber { get; set; }
        public string Description { get; set; }
        public string ColorDesc { get; set; }
        public string DescriptionTax { get; set; }
        public string ColorDescTax { get; set; }
        public string DescriptionInside { get; set; }
        public string ColorDescInside { get; set; }
    }

    public class DataViewerCheck
    {
        public string ID { get; set; }
        public string MainDescription { get; set; }
        public string DescriptionInfo { get; set; }
    }
    public class TBLErrColor
    {
        public string ID { get; set; }
        public string ColorDesc { get; set; }
    }


    public class DataViewerErroredCountCsv
    {
        public int EntryErrorCount { get; set; }
        public int TotalRow { get; set; }

    }
    public class DataViewerMain
    {
        public DataViewerMain()
        {
            EntryData = new List<DataViewer>();

        }

        public List<DataViewer> EntryData { get; set; }

        public int EntryCombinCount => EntryData.Select(c => c.EntryNumber).Distinct().Count();

        public string EntryCombinLast => EntryCombinCount > 0 ? EntryData.Where(x => x.EndDate.Month == EntryData.Max(x => x.EndDate.Month)).Select(c => c.EntryNumber).Distinct().Count().ToString() : "0";
        public string EntryCombinBefore => EntryCombinCount > 0 ? EntryData.Where(x => x.EndDate.Month != EntryData.Max(x => x.EndDate.Month)).Select(c => c.EntryNumber).Distinct().Count().ToString() : "0";

        public void SetDataViewer(List<DataViewer> mrequestEntryCount)
        {

            DataViewer nDash = new DataViewer();

            EntryData = mrequestEntryCount.Select(x => new DataViewer
            {
                GroupName = x.EntryNumber.ToString() + " Entry No",
                AccountMainDescription = x.AccountMainDescription,
                AccountMainID = x.AccountMainID,
                AccountSubDescription = x.AccountSubDescription,
                AccountSubID = x.AccountSubID,
                Amount = x.Amount,
                DetailComment = x.DetailComment,
                DebitCreditCode = x.DebitCreditCode,
                DocumentDate = x.DocumentDate,
                DocumentTypeDescription = x.DocumentTypeDescription,
                EnteredBy = x.EnteredBy,
                EntryNumber = x.EntryNumber,
                PaymentMethod = x.PaymentMethod,
                EndDate = x.EndDate,
                ColorDesc = x.ColorDesc,
                Description = x.Description,
                ColorDescTax = x.ColorDescTax,
                DescriptionTax = x.DescriptionTax,
                ColorDescInside = x.ColorDescInside,
                DescriptionInside = x.DescriptionInside,
            }).ToList();


            //for (int i = 0; i < mrequestEntryCount.Count(); i++)
            //{
            //    nDash = new DataViewer();
            //    nDash.GroupName = mrequestEntryCount[i].EntryNumber.ToString() + " Entry No";
            //    nDash.AccountMainDescription = mrequestEntryCount[i].AccountMainDescription;
            //    nDash.AccountMainID = mrequestEntryCount[i].AccountMainID;
            //    nDash.AccountSubDescription = mrequestEntryCount[i].AccountSubDescription;
            //    nDash.AccountSubID = mrequestEntryCount[i].AccountSubID;
            //    nDash.Amount = mrequestEntryCount[i].Amount;
            //    nDash.DetailComment = mrequestEntryCount[i].DetailComment;
            //    nDash.DebitCreditCode = mrequestEntryCount[i].DebitCreditCode;
            //    nDash.DocumentDate = mrequestEntryCount[i].DocumentDate;
            //    nDash.DocumentTypeDescription = mrequestEntryCount[i].DocumentTypeDescription;
            //    nDash.EnteredBy = mrequestEntryCount[i].EnteredBy;
            //    nDash.EntryNumber = mrequestEntryCount[i].EntryNumber;
            //    nDash.PaymentMethod = mrequestEntryCount[i].PaymentMethod;
            //    nDash.PaymentMethod = mrequestEntryCount[i].PaymentMethod;
            //    nDash.EndDate = mrequestEntryCount[i].EndDate;
            //    nDash.ColorDesc = mrequestEntryCount[i].ColorDesc;
            //    nDash.Description = mrequestEntryCount[i].Description;
            //    nDash.ColorDescTax = mrequestEntryCount[i].ColorDescTax;
            //    nDash.DescriptionTax = mrequestEntryCount[i].DescriptionTax;
            //    nDash.ColorDescInside = mrequestEntryCount[i].ColorDescInside;
            //    nDash.DescriptionInside = mrequestEntryCount[i].DescriptionInside;

            //    EntryData.Add(nDash);
            //}

        }
    }
}
