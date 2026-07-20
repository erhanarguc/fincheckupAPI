using fincheckup.Helper;
using fincheckup.Models.NKolay.ENTITY.Beyanname;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.ENTITY
{
    public class Dataz
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
        public byte IsPassedEntry { get; set; } = 0;
        public bool ISChanged { get; set; }
        public string Status { get; set; }
        public bool IsFailed { get; set; }  =false;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public long CompanyDocumentId { get; set; }
        
        public static Dataz FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            Dataz dailyValues = new Dataz();
            dailyValues.StartDate = values[0].ToString();
            dailyValues.EndDate = Convert.ToDateTime(values[1].ToString());
            dailyValues.EnteredBy = values[2].ToString();
            dailyValues.EnteredDate = values[3].ToString();
            dailyValues.EntryNumber = values[4].ToString();
            dailyValues.EntryComment = values[5].ToString();
            dailyValues.BatchID = values[6].ToString();
            dailyValues.BatchDescription = values[7].ToString();
            dailyValues.TotalDebit = Convert.ToDouble(values[8]);
            dailyValues.TotalCredit = Convert.ToDouble(values[9]);
            dailyValues.DocumentType = values[10].ToString();
            dailyValues.DocumentTypeDescription = values[11].ToString();
            dailyValues.DocumentNumber = values[12].ToString();
            dailyValues.DocumentDate = values[13].ToString();
            dailyValues.PaymentMethod = values[14].ToString();
            dailyValues.AccountMainID = values[15].ToString();
            dailyValues.AccountMainDescription = values[16].ToString();
            dailyValues.AccountSubDescription = values[17].ToString();
            dailyValues.AccountSubID = values[18].ToString();
            dailyValues.Amount = Convert.ToDouble(values[19]);
            dailyValues.DebitCreditCode = values[20].ToString();
            dailyValues.PostingDate = values[21].ToString();
            dailyValues.DetailComment = values[22].ToString();
            return dailyValues;
        }

        public static DataCollection SetValueFromXMlIsbank(defter ndefter, long csvid)
        {

            DataCollection nlist = new DataCollection();
            Dataz dt = new Dataz();
            foreach (var item in ndefter.xbrl.accountingEntries.entryHeader)
            {

                foreach (var itemz in item.entryDetail)
                {
                    dt = new Dataz();
                    dt.AccountMainDescription = itemz.account.accountMainDescription.Value.ToString();
                    dt.AccountMainID = itemz.account.accountMainID.Value.ToString();
                    dt.AccountSubDescription = itemz.account.accountSub.accountSubDescription.Value.ToString();
                    dt.AccountSubID = itemz.account.accountSub.accountSubID.Value.ToString();
                    dt.Amount = (double)itemz.amount.Value;
                    dt.BatchID = itemz.documentReference.Value.ToString();
                    dt.BatchDescription = string.Empty;
                    dt.CsvID = csvid;
                    dt.DebitCreditCode = itemz.debitCreditCode.Value.ToString();
                    dt.DetailComment = itemz.detailComment == null ? string.Empty : itemz.detailComment.Value;
                    dt.DocumentDate = item.enteredDate.Value.ToString();
                    dt.DocumentNumber = item.entryNumber.Value.ToString();
                    dt.DocumentType = itemz.documentType == null ? string.Empty : itemz.documentType.Value;
                    dt.DocumentTypeDescription = itemz.documentTypeDescription == null ? string.Empty : itemz.documentTypeDescription.Value;
                    dt.EndDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
                    dt.EnteredBy = item.enteredBy.Value;
                    dt.EnteredDate = item.enteredDate.Value.ToString();
                    dt.EntryComment = item.entryComment.Value.ToString();
                    dt.EntryNumber = item.entryNumber.Value.ToString();
                    dt.PaymentMethod = itemz.paymentMethod == null ? string.Empty : itemz.paymentMethod.Value;
                    dt.PostingDate = itemz.postingDate.Value.ToString();
                    dt.StartDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredStart.Value.ToString();
                    dt.TotalCredit = (double)item.totalCredit.Value;
                    dt.TotalDebit = (double)item.totalDebit.Value;
                    dt.UpdatedDate = DateTime.Now;
                    nlist.Add(dt);
                }


            }





            return nlist;



        }

        public static List<Dataz> SetValueFromNominal(fincheckup.Models.NominalXML.defter ndefter, long csvid, long documentID)
        {

            List<Dataz> nlist = new List<Dataz>();
            Dataz dt = new Dataz();
            foreach (var item in ndefter.xbrl.accountingEntries.entryHeader)
            {


                nlist.AddRange(item.entryDetail.Select(x => new Dataz()
                {

                    AccountMainDescription = x.account.accountMainDescription.Value,
                    AccountMainID = x.account.accountMainID.Value,
                    AccountSubID = x.account.accountSub == null ? x.account.accountMainID.Value + ".000" : x.account.accountSub.accountSubID.Value,
                    AccountSubDescription = x.account.accountSub == null ? "000" : x.account.accountSub.accountSubDescription.Value,
                    Amount = (double)x.amount.Value,
                    BatchID = x.documentReference == null ? string.Empty : x.documentReference.Value,
                    batchDescription = string.Empty,
                    DebitCreditCode = x.debitCreditCode.Value,
                    DetailComment = x.detailComment == null ? string.Empty : x.detailComment.Value,
                    DocumentDate = x.documentDate == null ? string.Empty : x.documentDate.Value.ToString(),
                    DocumentNumber = x.documentNumber == null ? string.Empty : x.documentNumber.Value,
                    DocumentType = x.documentType == null ? string.Empty : x.documentType.Value,
                    DocumentTypeDescription = x.detailComment == null ? string.Empty : x.detailComment.Value,
                    EndDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value,
                    EnteredBy = item.enteredBy == null ? string.Empty : item.enteredBy.Value,
                    EnteredDate = item.enteredDate == null ? string.Empty : item.enteredDate.Value.ToString(),
                    EntryComment = item.entryComment == null ? string.Empty : item.entryComment.Value,
                    EntryNumber = item.entryNumber == null ? string.Empty : item.entryNumber.Value.ToString(),
                    PaymentMethod = x.paymentMethod == null ? string.Empty : x.paymentMethod.Value,
                    PostingDate = x.postingDate == null ? string.Empty : x.postingDate.Value.ToString(),
                    StartDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredStart.Value.ToString(),
                    TotalCredit = (double)item.totalCredit.Value,
                    TotalDebit = (double)item.totalDebit.Value,
                    CsvID = csvid,
                    UpdatedDate = DateTime.Now,
                    CompanyDocumentId=documentID,
                    IsFailed = false,
                    IsPassedEntry = 0,
                    IsOpener =0
                }));


            }





            return nlist;



        }

        public static List<Dataz> SetValueFromBeyanname(List<BeyannameGeciciView> ndefter, long csvid, DateTime datum)
        {

            List<Dataz> nlist = new List<Dataz>();
            Dataz dt = new Dataz();



            nlist.AddRange(ndefter.Select(x => new Dataz()
            {

                AccountMainDescription = x.AccountMainDescription,
                AccountMainID = x.AccountMainID,
                AccountSubID = x.AccountMainID,
                AccountSubDescription = x.AccountMainDescription,
                Amount = x.Amount,
                BatchID = string.Empty,
                batchDescription = string.Empty,
                DebitCreditCode = string.Empty,
                DetailComment = string.Empty,
                DocumentDate = datum.ToShortDateString(),
                DocumentNumber = string.Empty,
                DocumentType = string.Empty,
                DocumentTypeDescription = string.Empty,
                EndDate = datum,
                EnteredBy = string.Empty,
                EnteredDate = string.Empty,
                EntryComment = string.Empty,
                EntryNumber = string.Empty,
                PaymentMethod = string.Empty,
                PostingDate = datum.ToShortDateString(),
                StartDate = datum.ToShortDateString(),
                TotalCredit = x.Amount,
                TotalDebit = x.Amount,
                CsvID = csvid,
                UpdatedDate = DateTime.Now

            }));








            return nlist;



        }

        public static DataCollection SetValueFromXMluyumsoft(fincheckup.Models.NKolayUyumsoft.defter ndefter, long csvid)
        {

            DataCollection nlist = new DataCollection();
            Dataz dt = new Dataz();
            foreach (var item in ndefter.xbrl.accountingEntries.entryHeader)
            {

                foreach (var itemz in item.entryDetail)
                {
                    dt = new Dataz();
                    dt.AccountMainDescription = itemz.account.accountMainDescription.Value.ToString();
                    dt.AccountMainID = itemz.account.accountMainID.Value.ToString();
                    dt.AccountSubDescription = itemz.account.accountSub.accountSubDescription.Value.ToString();
                    dt.AccountSubID = itemz.account.accountSub.accountSubID.Value.ToString();
                    dt.Amount = (double)itemz.amount.Value;
                    dt.BatchID = itemz.documentReference.Value.ToString();
                    dt.BatchDescription = string.Empty;
                    dt.CsvID = csvid;
                    dt.DebitCreditCode = itemz.debitCreditCode.Value.ToString();
                    dt.DetailComment = itemz.detailComment == null ? string.Empty : itemz.detailComment.Value;
                    dt.DocumentDate = item.enteredDate.Value.ToString();
                    dt.DocumentNumber = item.entryNumber.Value.ToString();
                    dt.DocumentType = itemz.documentType == null ? string.Empty : itemz.documentType.Value;
                    dt.DocumentTypeDescription = itemz.documentTypeDescription == null ? string.Empty : itemz.documentTypeDescription.Value;
                    dt.EndDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
                    dt.EnteredBy = item.enteredBy.Value;
                    dt.EnteredDate = item.enteredDate.Value.ToString();
                    dt.EntryComment = item.entryNumber == null ? string.Empty : item.entryNumber.Value.ToString();
                    dt.EntryNumber = item.entryNumber.Value.ToString();
                    dt.PaymentMethod = itemz.paymentMethod == null ? string.Empty : itemz.paymentMethod.Value;
                    dt.PostingDate = itemz.postingDate.Value.ToString();
                    dt.StartDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredStart.Value.ToString();
                    dt.TotalCredit = (double)item.totalCredit.Value;
                    dt.TotalDebit = (double)item.totalDebit.Value;
                    dt.UpdatedDate = DateTime.Now;
                    nlist.Add(dt);
                }


            }





            return nlist;



        }

        public static List<DataCollection> SetValueFromXMlSapEntegrator(fincheckup.Models.NominalXML.defter ndefter, long csvid)
        {
            List<DataCollection> zlist = new List<DataCollection>();
            DataCollection nlist = new DataCollection();
            Dataz dt = new Dataz();
            int counter = 0;
            foreach (var item in ndefter.xbrl.accountingEntries.entryHeader)
            {

                foreach (var itemz in item.entryDetail)
                {
                    counter++;
                    dt = new Dataz();
                    dt.AccountMainDescription = itemz.account.accountMainDescription.Value;
                    dt.AccountMainID = itemz.account.accountMainID.Value;
                    dt.AccountSubID = itemz.account.accountSub.accountSubID.Value;
                    dt.AccountSubDescription = itemz.account.accountSub.accountSubDescription.Value;
                    dt.Amount = (double)itemz.amount.Value;
                    dt.BatchID = itemz.documentReference == null ? string.Empty : itemz.documentReference.Value;
                    dt.batchDescription = string.Empty;
                    dt.DebitCreditCode = itemz.debitCreditCode.Value;
                    dt.DetailComment = itemz.detailComment == null ? string.Empty : itemz.detailComment.Value;
                    dt.DocumentDate = itemz.documentDate == null ? string.Empty : itemz.documentDate.Value.ToString();
                    dt.DocumentNumber = itemz.documentNumber == null ? string.Empty : itemz.documentNumber.Value;
                    dt.DocumentType = itemz.documentType == null ? string.Empty : itemz.documentType.Value;
                    dt.DocumentTypeDescription = itemz.detailComment == null ? string.Empty : itemz.detailComment.Value;
                    dt.EndDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
                    dt.EnteredBy = item.enteredBy == null ? string.Empty : item.enteredBy.Value;
                    dt.EnteredDate = item.enteredDate == null ? string.Empty : item.enteredDate.Value.ToString();
                    dt.EntryComment = item.entryComment == null ? string.Empty : item.entryComment.Value;
                    dt.EntryNumber = item.entryNumber.Value.ToString();
                    dt.PaymentMethod = itemz.paymentMethod == null ? string.Empty : itemz.paymentMethod.Value;
                    dt.PostingDate = itemz.postingDate == null ? string.Empty : itemz.postingDate.Value.ToString();
                    dt.StartDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredStart.Value.ToString();
                    dt.TotalCredit = (double)item.totalCredit.Value;
                    dt.TotalDebit = (double)item.totalDebit.Value;
                    dt.CsvID = csvid;
                    dt.UpdatedDate = DateTime.Now;
                    nlist.Add(dt);
                    if (counter > 100000)
                    {
                        counter = 0;
                        zlist.Add(nlist);
                        nlist = new DataCollection();
                    }
                }


            }

            if (nlist.Count > 0)
            {
                zlist.Add(nlist);
            }



            return zlist;



        }
        //public static List<Dataz> Get_AllbyCsvID(string ide)
        //{
        //    return StaticQuery<Dataz>("Select StartDate ,EndDate ,EnteredBy ,EnteredDate ,EntryNumber ,EntryComment ,BatchID ,BatchDescription ,TotalDebit ,TotalCredit ,DocumentType ,DocumentTypeDescription ,DocumentNumber ,DocumentDate ,PaymentMethod ,AccountMainID ,AccountMainDescription ,AccountSubDescription ,AccountSubID ,Amount ,DebitCreditCode ,PostingDate ,DetailComment   From [TBLXMLSource] where CsvID=@ID", new { ID = ide }).ToList();
        //}
        //        public void Save_Edefter()
        //        {
        //            string sql = @"  INSERT INTO [TBLXMLSource]
        //          (  
        //        [StartDate] ,
        //        [EndDate] ,
        //        [EnteredBy] ,
        //        [EnteredDate] ,
        //        [EntryNumber] ,
        //        [EntryComment] ,
        //        [BatchID] ,
        //        [BatchDescription] ,
        //        [TotalDebit] ,
        //        [TotalCredit] ,
        //        [DocumentType] ,
        //        [DocumentTypeDescription] ,
        //        [DocumentNumber] ,
        //        [DocumentDate] ,
        //        [PaymentMethod] ,
        //        [AccountMainID] ,
        //        [AccountMainDescription] ,
        //        [AccountSubDescription] ,
        //        [AccountSubID] ,
        //        [Amount] ,
        //        [DebitCreditCode] ,
        //        [PostingDate] ,
        //        [DetailComment] ,
        //CsvID,
        //ISChanged,
        //UpdatedDate,
        //Status
        //          ) 
        //           VALUES 
        //         (  
        //        @StartDate ,
        //        @EndDate ,
        //        @EnteredBy ,
        //        @EnteredDate ,
        //        @EntryNumber ,
        //        @EntryComment ,
        //        @BatchID ,
        //        @BatchDescription ,
        //        @TotalDebit ,
        //        @TotalCredit ,
        //        @DocumentType ,
        //        @DocumentTypeDescription ,
        //        @DocumentNumber ,
        //        @DocumentDate ,
        //        @PaymentMethod ,
        //        @AccountMainID ,
        //        @AccountMainDescription ,
        //        @AccountSubDescription ,
        //        @AccountSubID ,
        //        @Amount ,
        //        @DebitCreditCode ,
        //        @PostingDate ,
        //        @DetailComment ,
        //@CsvID,
        // @ISChanged,
        //@UpdatedDate,
        //@Status
        //         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
        //            this.ID = Query<int>(sql, this).FirstOrDefault();
        //        }

        //public bool Update_()
        //{
        //    try
        //    {
        //        string sql = "UPDATE   [TBLXMLSource] SET    [StartDate]=@StartDate , [EndDate]=@EndDate , [EnteredBy]=@EnteredBy , [EnteredDate]=@EnteredDate , [EntryNumber]=@EntryNumber , [EntryComment]=@EntryComment , [BatchID]=@BatchID , [BatchDescription]=@BatchDescription , [TotalDebit]=@TotalDebit , [TotalCredit]=@TotalCredit , [DocumentType]=@DocumentType , [DocumentTypeDescription]=@DocumentTypeDescription , [DocumentNumber]=@DocumentNumber , [DocumentDate]=@DocumentDate , [PaymentMethod]=@PaymentMethod , [AccountMainID]=@AccountMainID , [AccountMainDescription]=@AccountMainDescription , [AccountSubDescription]=@AccountSubDescription , [AccountSubID]=@AccountSubID , [Amount]=@Amount , [DebitCreditCode]=@DebitCreditCode , [PostingDate]=@PostingDate , [DetailComment]=@DetailComment, ISChanged=@ISChanged,UpdatedDate=@UpdatedDate,Status=@Status  WHERE [ID]=@ID";
        //        Execute(sql, this);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
    public class TBLXMLSourceMain : BaseModel
    {
        public int ID { get; set; }
        public DateTime EndDate { get; set; }
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string AccountSubID { get; set; }
        public string AccountSubDescription { get; set; }
        public string DebitCreditCode { get; set; }

        public float Amount { get; set; }

        public long CsvID { get; set; }


        public static IEnumerable<TBLXMLSourceMain> Get_AllCompany(int _year, long _compID)
        {
            return StaticQuery<TBLXMLSourceMain>("Select * From [TBLXMLSourceMain] Where CsvID in ( Select ID From [TBLXml] where   CompanyID=@companyID and [Year]=@nyear)", new { companyID = _compID, nyear = _year });
        }
        public static IEnumerable<TBLXMLSourceMain> Get_AllCompanyByCode(int _csvID, string _code)
        {
            return StaticQuery<TBLXMLSourceMain>("Select * From [TBLXMLSourceMain] Where   CsvID=@csvID and AccountMainID=@code", new { csvID = _csvID, code = _code });
        }
        
        public static IEnumerable<TBLXMLSourceMain> Get_AllCompanyLast(int _year, long _compID)
        {
            return StaticQuery<TBLXMLSourceMain>("Select * From [TBLXMLSourceSub] Where CsvID in ( Select ID From [TBLXml] where   CompanyID=@companyID and [Year]=@nyear)", new { companyID = _compID, nyear = _year });
        }

        public static IEnumerable<TBLXMLSourceMain> Get_AllCompanyLastCode(int _csvID, string _code)
        {
            return StaticQuery<TBLXMLSourceMain>("Select * From [TBLXMLSourceSub] Where    CsvID=@csvID and AccountMainID=@code", new { csvID = _csvID, code = _code });
        }

    }
    //public static List<Dataz> SetValueFromNominalT(fincheckup.Models.NominalXML.defter ndefter, int csvid)
    //{

    //    List<Dataz> nlist = new List<Dataz>();
    //    Dataz dt = new Dataz();
    //    foreach (var item in ndefter.xbrl.accountingEntries.entryHeader)
    //    {


    //        nlist.AddRange(item.entryDetail.Select(x => new Dataz()
    //        {

    //            AccountMainDescription = x.account.accountMainDescription.Value,
    //            AccountMainID = x.account.accountMainID.Value,
    //            AccountSubID = x.account.accountSub.accountSubID.Value,
    //            AccountSubDescription = x.account.accountSub.accountSubDescription.Value,
    //            Amount = (double)x.amount.Value,
    //            BatchID = x.documentReference == null ? "" : x.documentReference.Value,
    //            batchDescription = "",
    //            DebitCreditCode = x.debitCreditCode.Value,
    //            DetailComment = x.detailComment == null ? "" : x.detailComment.Value,
    //            DocumentDate = x.documentDate == null ? "" : x.documentDate.Value.ToString(),
    //            DocumentNumber = x.documentNumber == null ? "" : x.documentNumber.Value,
    //            DocumentType = x.documentType == null ? "" : x.documentType.Value,
    //            DocumentTypeDescription = x.detailComment == null ? "" : x.detailComment.Value,
    //            EndDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value,
    //            EnteredBy = item.enteredBy == null ? "" : item.enteredBy.Value,
    //            EnteredDate = item.enteredDate == null ? "" : item.enteredDate.Value.ToString(),
    //            EntryComment = item.entryComment == null ? "" : item.entryComment.Value,
    //            EntryNumber = item.entryNumber.Value.ToString(),
    //            PaymentMethod = x.paymentMethod == null ? "" : x.paymentMethod.Value,
    //            PostingDate = x.postingDate == null ? "" : x.postingDate.Value.ToString(),
    //            StartDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredStart.Value.ToString(),
    //            TotalCredit = (double)item.totalCredit.Value,
    //            TotalDebit = (double)item.totalDebit.Value,
    //            CsvID = csvid,
    //            UpdatedDate = DateTime.Now

    //        }));


    //    }





    //    return nlist;



    //}
    //public static DataCollection SetValueFromNominalC(fincheckup.Models.NominalXML.defter ndefter, int csvid)
    //{

    //    DataCollection nlist = new DataCollection();
    //    Dataz dt = new Dataz();
    //    foreach (var item in ndefter.xbrl.accountingEntries.entryHeader)
    //    {


    //        nlist.AddRange(item.entryDetail.Select(x => new Dataz()
    //        {

    //            AccountMainDescription = x.account.accountMainDescription.Value,
    //            AccountMainID = x.account.accountMainID.Value,
    //            AccountSubID = x.account.accountSub.accountSubID.Value,
    //            AccountSubDescription = x.account.accountSub.accountSubDescription.Value,
    //            Amount = (double)x.amount.Value,
    //            BatchID = x.documentReference == null ? "" : x.documentReference.Value,
    //            batchDescription = "",
    //            DebitCreditCode = x.debitCreditCode.Value,
    //            DetailComment = x.detailComment == null ? "" : x.detailComment.Value,
    //            DocumentDate = x.documentDate == null ? "" : x.documentDate.Value.ToString(),
    //            DocumentNumber = x.documentNumber == null ? "" : x.documentNumber.Value,
    //            DocumentType = x.documentType == null ? "" : x.documentType.Value,
    //            DocumentTypeDescription = x.detailComment == null ? "" : x.detailComment.Value,
    //            EndDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value,
    //            EnteredBy = item.enteredBy == null ? "" : item.enteredBy.Value,
    //            EnteredDate = item.enteredDate == null ? "" : item.enteredDate.Value.ToString(),
    //            EntryComment = item.entryComment == null ? "" : item.entryComment.Value,
    //            EntryNumber = item.entryNumber.Value.ToString(),
    //            PaymentMethod = x.paymentMethod == null ? "" : x.paymentMethod.Value,
    //            PostingDate = x.postingDate == null ? "" : x.postingDate.Value.ToString(),
    //            StartDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredStart.Value.ToString(),
    //            TotalCredit = (double)item.totalCredit.Value,
    //            TotalDebit = (double)item.totalDebit.Value,
    //            CsvID = csvid,
    //            UpdatedDate = DateTime.Now

    //        }));


    //    }





    //    return nlist;



    //}
}
