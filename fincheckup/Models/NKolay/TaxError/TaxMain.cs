using fincheckup.ENTITY;
using fincheckup.Models.ViewM;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.TaxError
{
    public class TaxMain
    {
        public List<TaxErrorCheck> ttdash { get; set; }
        public List<TaxErrorcheckTest> ttdash1 { get; set; }
        public List<TaxErrorcheckDataz> ttdash3 { get; set; }
        public TaxErrorCheck ttdashChk { get; set; }
        public TaxErrorcheckTest ttdashTest { get; set; }
        public TaxErrorcheckDataz ttdashDataz { get; set; }

        public TaxMain()
        {
            ttdashChk = new TaxErrorCheck();
            ttdashTest = new TaxErrorcheckTest();
            ttdashDataz = new TaxErrorcheckDataz();
        }
        public List<TaxErrorCheck> checkedFirst()
        {
            int csvid = 00;
            var ttdashchk = Data.Get_AllCompanyByCode(csvid, "100").ToList();
            ttdashChk.checklist(ttdashchk);
            ttdash = ttdashChk.taxchecklist;
            return Tax100.checkFirst(ttdash);
        }


        public List<TaxErrorcheckDataz> checkedSecond(int year, long companyid)
        {
            int csvid = 00;
            var ttdashchk1 = TBLXMLSourceMain.Get_AllCompanyByCode(csvid, "100").ToList();
            ttdashDataz.checklist(ttdashchk1);
            ttdash3 = ttdashDataz.taxchecklist;

            var tttttt = DashGelirTablosu.Get_MAINTAXCheck(year, companyid).ToList();
            ttdashTest.checklist(tttttt);
            ttdash1 = ttdashTest.taxchecklist;

            return Tax100.checkSecond(ttdash1.FirstOrDefault(), ttdash3);
        }
        public List<TaxErrorcheckDataz> checkedThird(int year, long companyid)
        {
            int csvid = 00;
            var ttdashchk1 = TBLXMLSourceMain.Get_AllCompanyByCode(csvid, "100").ToList();
            ttdashDataz.checklist(ttdashchk1);
            ttdash3 = ttdashDataz.taxchecklist;

            var tttttt = DashGelirTablosu.Get_MAINTAXCheck(year, companyid).ToList();
            ttdashTest.checklist(tttttt);
            ttdash1 = ttdashTest.taxchecklist;

            return Tax100.checkThird(ttdash1.FirstOrDefault(), ttdash3);
        }

        public List<TaxErrorcheckDataz> checkedFour()
        {
            int csvid = 00;
            var ttdashchk3 = TBLXMLSourceMain.Get_AllCompanyLastCode(csvid, "102").ToList();
            var ttdashchk3Int = TBLXMLSourceMain.Get_AllCompanyLastCode(csvid, "646") .Distinct().ToList();
            var ttdashchk3Int656 = TBLXMLSourceMain.Get_AllCompanyLastCode(csvid, "656").Distinct().ToList();
            ttdashchk3Int.AddRange(ttdashchk3Int656);
            var laslist = ttdashchk3Int.Select(x=>x.EndDate.Month).Distinct();
          var ttdashchk1 = ttdashchk3.Where(x => (x.AccountSubDescription.ToLower().Contains("usd") || x.AccountSubDescription.ToLower().Contains("eur") || x.AccountSubDescription.ToLower().Contains("gbp") || x.AccountSubDescription.ToLower().Contains("cny"))).ToList();


            ttdashDataz.checklist(ttdashchk1);
            ttdash3 = ttdashDataz.taxchecklist;

            ttdashTest.checklistLast(ttdash3);
            ttdash1 = ttdashTest.taxchecklist;


            return Tax102.checkFrist(ttdash1, ttdash3, laslist);
        }

        public List<TaxErrorcheckDataz> checkedFive()
        {
            int csvid = 00;
            var ttdashchk3 = TBLXMLSourceMain.Get_AllCompanyLastCode(csvid, "397").ToList();
            var ttdashchk3a = TBLXMLSourceMain.Get_AllCompanyLastCode(csvid, "950").ToList();
            var ttdashchk3b = TBLXMLSourceMain.Get_AllCompanyLastCode(csvid, "951").ToList();
            ttdashchk3a.AddRange(ttdashchk3b);
            var ttdashchk3Int = ttdashchk3a.Select(y => y.EndDate.Month).Distinct();

            ttdashDataz.checklist(ttdashchk3);
            ttdash3 = ttdashDataz.taxchecklist;

            ttdashTest.checklistLast(ttdash3);
            ttdash1 = ttdashTest.taxchecklist;
            return Tax197_397.checkFrist(ttdash1, ttdash3, ttdashchk3Int);
        }

        public List<TaxErrorcheckDataz> checkedSix()
        {
            int csvid = 00;
            var ttdashchk3 = TBLXMLSourceMain.Get_AllCompanyLastCode(csvid, "180").ToList();
            var ttdashchk3b = TBLXMLSourceMain.Get_AllCompanyLastCode(csvid, "280").ToList();
            ttdashchk3.AddRange(ttdashchk3b);





            ttdashDataz.checklist(ttdashchk3);
            ttdash3 = ttdashDataz.taxchecklist;

            ttdashTest.checklistLast(ttdash3);
            ttdash1 = ttdashTest.taxchecklist;


            return Tax180_280.checkFrist(ttdash1, ttdash3);
        }

        public List<TaxErrorcheckDataz> checkedSeven()
        {
            int csvid = 00;
            var ttdashchk3 = TBLXMLSourceMain.Get_AllCompanyLastCode(csvid, "257").ToList();





            ttdashDataz.checklist(ttdashchk3);
            ttdash3 = ttdashDataz.taxchecklist;

            ttdashTest.checklistLast(ttdash3);
            ttdash1 = ttdashTest.taxchecklist;


            return Tax255_257.checkFrist(ttdash1, ttdash3);
        }

        public List<TaxErrorcheckDataz> checkedEight()
        {
            int csvid = 00;
            var ttdashchk3 = TBLXMLSourceMain.Get_AllCompanyLastCode(csvid, "257").ToList();





            ttdashDataz.checklist(ttdashchk3);
            ttdash3 = ttdashDataz.taxchecklist;

            ttdashTest.checklistLast(ttdash3);
            ttdash1 = ttdashTest.taxchecklist;


            return Tax601.checkFrist(ttdash1.FirstOrDefault(), ttdash3);
        }

        public List<TaxErrorcheckDataz> checkedNine(int year, long companyid)
        {

            var ttdashchk3 = TBLXMLSourceMain.Get_AllCompanyLast(year, companyid).Where(x => (x.AccountMainID == "300" && x.EndDate.Month == 12)).ToList();





            ttdashDataz.checklist(ttdashchk3);
            ttdash3 = ttdashDataz.taxchecklist;

            ttdashTest.checklistLast(ttdash3);
            ttdash1 = ttdashTest.taxchecklist;


            return Tax300.checkFrist(ttdash1.FirstOrDefault(), ttdash3);
        }
        public List<TaxErrorcheckDataz> checkedTen()
        {
            int csvid = 00;
            var ttdashchk3 = TBLXMLSourceMain.Get_AllCompanyLastCode(csvid, "500").ToList();





            ttdashDataz.checklist(ttdashchk3);
            ttdash3 = ttdashDataz.taxchecklist;

            ttdashTest.checklistLast(ttdash3);
            ttdash1 = ttdashTest.taxchecklist;


            return Tax500.checkFrist(ttdash1, ttdash3);
        }
        public List<TaxErrorcheckDataz> checkedEleven()
        {
            int csvid = 00;
            var ttdashchk3 = TBLXMLSourceMain.Get_AllCompanyLastCode(csvid, "500").ToList();





            ttdashDataz.checklist(ttdashchk3);
            ttdash3 = ttdashDataz.taxchecklist;

            ttdashTest.checklistLast(ttdash3);
            ttdash1 = ttdashTest.taxchecklist;


            return Tax602.checkFrist(ttdash1.FirstOrDefault(), ttdash3);
        }

        public List<TaxErrorcheckDataz> checkedTwelve()
        {
            int csvid = 00;
            var ttdashchk3 = TBLXMLSourceMain.Get_AllCompanyLastCode(csvid, "254").ToList(); 





            ttdashDataz.checklist(ttdashchk3);
            ttdash3 = ttdashDataz.taxchecklist;

            ttdashTest.checklistLast(ttdash3);
            ttdash1 = ttdashTest.taxchecklist;


            return Tax254.checkFrist(ttdash1.FirstOrDefault(), ttdash3);
        }

        public List<TaxErrorcheckDataz> checkedThirteen()
        {

            int csvid = 00;
            var ttdashchk3 = TBLXMLSourceMain.Get_AllCompanyLastCode(csvid, "195").ToList();





            ttdashDataz.checklist(ttdashchk3);
            ttdash3 = ttdashDataz.taxchecklist;

            ttdashTest.checklistLast(ttdash3);
            ttdash1 = ttdashTest.taxchecklist;


            return Tax254.checkFrist(ttdash1.FirstOrDefault(), ttdash3);
        }
    }
}
