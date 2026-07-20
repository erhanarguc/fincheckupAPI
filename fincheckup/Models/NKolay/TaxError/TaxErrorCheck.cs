using fincheckup.ENTITY;
using fincheckup.Models.ViewM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.TaxError
{
    public class TaxErrorCheck
    {
        public TaxErrorCheck()
        {
            taxchecklist = new List<TaxErrorCheck>();
        }
        public long ID { get; set; }
        public string EnteredDate { get; set; }
        public string EntryNumber { get; set; }
        public string EntryComment { get; set; }
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string AccountSubDescription { get; set; }
        public string AccountSubID { get; set; }
        public float Amount { get; set; }
        public string DebitCreditCode { get; set; }
        public string DocumentDate { get; set; }
        public string DetailComment { get; set; }
        public long CsvID { get; set; }
        public DateTime PostingDate_ => Convert.ToDateTime(DocumentDate);
        public int Day => PostingDate_.Day;
        public int Month => PostingDate_.Month;
        public int Year => PostingDate_.Year;
        public int ErrorIdentity { get; set; }
        public List<TaxErrorCheck> taxchecklist { get; set; }

        public void checklist(List<Data> chklist)
        {

            taxchecklist = chklist.Select(x => new TaxErrorCheck()
            {
                ID = x.ID,
                EnteredDate = x.EnteredDate,
                EntryNumber = x.EntryNumber,
                CsvID = x.CsvID,
                DetailComment = x.DetailComment,
                DocumentDate = x.DocumentDate,
                DebitCreditCode = x.DebitCreditCode,
                Amount = x.Amount,
                AccountSubID = x.AccountSubID,
                AccountMainID = x.AccountMainID,
                AccountMainDescription = x.AccountMainDescription,
                AccountSubDescription = x.AccountSubDescription,
                EntryComment = x.EntryComment

            }).ToList();





        }

    }

    public class TaxErrorcheckTest
    {

        public TaxErrorcheckTest()
        {
            taxchecklist = new List<TaxErrorcheckTest>();
        }
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string AccountSubID { get; set; }
        public string AccountSubDescription { get; set; }
        public string DebitCreditCode { get; set; }
        public double January { get; set; }
        public double February { get; set; }
        public double March { get; set; }
        public double April { get; set; }
        public double May { get; set; }
        public double June { get; set; }
        public double July { get; set; }
        public double August { get; set; }
        public double September { get; set; }
        public double October { get; set; }
        public double November { get; set; }
        public double December { get; set; }

        public long CompanyID { get; set; }
        public double JanuaryTx => January;
        public double FebruaryTx => February != 0 ? (January + February) : 0;
        public double MarchTx => March != 0 ? (FebruaryTx + March) : 0;
        public double AprilTx => April != 0 ? (MarchTx + April) : 0;
        public double MayTx => May != 0 ? (AprilTx + May) : 0;
        public double JuneTx => June != 0 ? (MayTx + June) : 0;
        public double JulyTx => July != 0 ? (JuneTx + July) : 0;
        public double AugustTx => August != 0 ? (JulyTx + August) : 0;
        public double SeptemberTx => September != 0 ? (AugustTx + September) : 0;
        public double OctoberTx => October != 0 ? (SeptemberTx + October) : 0;
        public double NovemberTx => November != 0 ? (OctoberTx + November) : 0;
        public double DecemberTx => December != 0 ? (NovemberTx + December) : 0;

        public double JanuaryTxa => January;
        public double FebruaryTxa => February != 0 ? January + February : 0;
        public double MarchTxa => March != 0 ? January + February + March : 0;
        public double AprilTxa => April != 0 ? January + February + March + April : 0;
        public double MayTxa => May != 0 ? January + February + March + April + May : 0;
        public double JuneTxa => June != 0 ? January + February + March + April + May + June : 0;
        public double JulyTxa => July != 0 ? January + February + March + April + May + June + July : 0;
        public double AugustTxa => August != 0 ? January + February + March + April + May + June + July + August : 0;
        public double SeptemberTxa => September != 0 ? January + February + March + April + May + June + July + August + September : 0;
        public double OctoberTxa => October != 0 ? January + February + March + April + May + June + July + August + September + October : 0;
        public double NovemberTxa => November != 0 ? January + February + March + April + May + June + July + August + September + October + November : 0;
        public double DecemberTxa => December != 0 ? January + February + March + April + May + June + July + August + September + October + November + December : 0;


        public int mainCkValue = 7500;
        public List<TaxErrorcheckDatazView> getOverList()
        {
            List<TaxErrorcheckDatazView> nlist = new List<TaxErrorcheckDatazView>();
            if (JanuaryTx > mainCkValue) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 1, Amount = JanuaryTx }); }
            if (FebruaryTx > mainCkValue) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 2, Amount = FebruaryTx }); }
            if (MarchTx > mainCkValue) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 3, Amount = MarchTx }); }
            if (AprilTx > mainCkValue) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 4, Amount = AprilTx }); }
            if (MayTx > mainCkValue) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 5, Amount = MayTx }); }
            if (JuneTx > mainCkValue) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 6, Amount = JuneTx }); }
            if (JulyTx > mainCkValue) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 7, Amount = JulyTx }); }
            if (AugustTx > mainCkValue) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 8, Amount = AugustTx }); }
            if (SeptemberTx > mainCkValue) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 9, Amount = SeptemberTx }); }
            if (OctoberTx > mainCkValue) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 10, Amount = OctoberTx }); }
            if (NovemberTx > mainCkValue) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 11, Amount = NovemberTx }); }
            if (DecemberTx > mainCkValue) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 12, Amount = DecemberTx }); }
            ;
            return nlist.OrderBy(x => x.MonthID).ToList();
        }

        public List<TaxErrorcheckDatazView> getMinusList()
        {
            List<TaxErrorcheckDatazView> nlist = new List<TaxErrorcheckDatazView>();
            if (JanuaryTx < 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 1, Amount = JanuaryTx }); }
            if (FebruaryTx < 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 2, Amount = FebruaryTx }); }
            if (MarchTx < 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 3, Amount = MarchTx }); }
            if (AprilTx < 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 4, Amount = AprilTx }); }
            if (MayTx < 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 5, Amount = MayTx }); }
            if (JuneTx < 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 6, Amount = JuneTx }); }
            if (JulyTx < 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 7, Amount = JulyTx }); }
            if (AugustTx < 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 8, Amount = AugustTx }); }
            if (SeptemberTx < 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 9, Amount = SeptemberTx }); }
            if (OctoberTx < 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 10, Amount = OctoberTx }); }
            if (NovemberTx < 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 11, Amount = NovemberTx }); }
            if (DecemberTx < 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 12, Amount = DecemberTx }); }

            return nlist.OrderBy(x => x.MonthID).ToList();
        }

        public List<TaxErrorcheckDatazView> getOverZeroList()
        {
            List<TaxErrorcheckDatazView> nlist = new List<TaxErrorcheckDatazView>();
            if (JanuaryTx > 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 1, Amount = JanuaryTx }); }
            if (FebruaryTx > 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 2, Amount = FebruaryTx }); }
            if (MarchTx > 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 3, Amount = MarchTx }); }
            if (AprilTx > 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 4, Amount = AprilTx }); }
            if (MayTx > 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 5, Amount = MayTx }); }
            if (JuneTx > 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 6, Amount = JuneTx }); }
            if (JulyTx > 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 7, Amount = JulyTx }); }
            if (AugustTx > 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 8, Amount = AugustTx }); }
            if (SeptemberTx > 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 9, Amount = SeptemberTx }); }
            if (OctoberTx > 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 10, Amount = OctoberTx }); }
            if (NovemberTx > 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 11, Amount = NovemberTx }); }
            if (DecemberTx > 0) { nlist.Add(new TaxErrorcheckDatazView() { MonthID = 12, Amount = DecemberTx }); }

            return nlist.OrderBy(x => x.MonthID).ToList();
        }
        public void checklist(List<DashBilancoView> chklist)
        {

            taxchecklist = chklist.Select(x => new TaxErrorcheckTest()
            {
                AccountMainID = x.AccountMainID,
                AccountMainDescription = x.AccountMainDescription,
                DebitCreditCode = x.DebitCreditCode,
                January = x.January,
                February = x.February,
                March = x.March,
                April = x.April,
                May = x.May,
                June = x.June,
                July = x.July,
                August = x.August,
                September = x.September,
                October = x.October,
                November = x.November,
                December = x.December,
                CompanyID = x.CompanyID,

            }).ToList();
        }

        public void checklistLast(IEnumerable<TaxErrorcheckDataz> chklist)
        {

            IEnumerable<TaxErrorcheckDataz> tlist = null;
            TaxErrorcheckTest btest = new TaxErrorcheckTest();
            IEnumerable<string> subidlist = chklist.Select(x => x.AccountSubID);
            foreach (var item in subidlist)
            {
                tlist = chklist.Where(x => x.AccountSubID == item);
                foreach (var itemz in tlist)
                {
                    btest = new TaxErrorcheckTest();
                    btest.AccountMainID = itemz.AccountMainID;
                    btest.AccountMainDescription = itemz.AccountMainDescription;
                    btest.AccountSubID = itemz.AccountSubID;
                    btest.AccountSubDescription = itemz.AccountSubDescription;

                    switch (itemz.EndDate.Month)
                    {
                        case 1: btest.January = itemz.Amount; break;
                        case 2: btest.February = itemz.Amount; break;
                        case 3: btest.March = itemz.Amount; break;
                        case 4: btest.April = itemz.Amount; break;
                        case 5: btest.May = itemz.Amount; break;
                        case 6: btest.June = itemz.Amount; break;
                        case 7: btest.July = itemz.Amount; break;
                        case 8: btest.August = itemz.Amount; break;
                        case 9: btest.September = itemz.Amount; break;
                        case 10: btest.October = itemz.Amount; break;
                        case 11: btest.November = itemz.Amount; break;
                        case 12: btest.December = itemz.Amount; break;
                        default:
                            break;
                    }


                }
                taxchecklist.Add(btest);
            }


        }
        public List<TaxErrorcheckTest> taxchecklist { get; set; }



    }
    public class TaxErrorcheckDatazView
    {
        public int MonthID { get; set; }
        public double Amount { get; set; }

    }
    public class TaxErrorcheckDataz
    {

        public TaxErrorcheckDataz()
        {
            taxchecklist = new List<TaxErrorcheckDataz>();
        }
        public long CsvID { get; set; }
        public DateTime EndDate { get; set; }
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string AccountSubID { get; set; }
        public string AccountSubDescription { get; set; }
        public string DebitCreditCode { get; set; }
        public float Amount { get; set; }
        public int ErrorIdentity { get; set; }


        public void checklist(List<TBLXMLSourceMain> chklist)
        {

            taxchecklist = chklist.Select(x => new TaxErrorcheckDataz()
            {
                CsvID = x.CsvID,
                DebitCreditCode = x.DebitCreditCode,
                Amount = x.Amount,
                EndDate = x.EndDate,
                AccountSubID = x.AccountSubID,
                AccountMainID = x.AccountMainID,
                AccountMainDescription = x.AccountMainDescription,
                AccountSubDescription = x.AccountSubDescription

            }).ToList();





        }
        public List<TaxErrorcheckDataz> taxchecklist { get; set; }
    }
}