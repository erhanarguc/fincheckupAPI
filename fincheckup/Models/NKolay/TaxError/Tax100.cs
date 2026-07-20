using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.TaxError
{
    public static class Tax100
    {


        public static List<TaxErrorCheck> checkFirst(List<TaxErrorCheck> getlist)
        {
            List<TaxErrorCheck> setlist = new List<TaxErrorCheck>();
            if (getlist == null)
            {
                return setlist;
            }

            List<TaxErrorCheck> sells = getlist
    .GroupBy(x => new { x.DocumentDate, x.CsvID })
    .Select(cl => new TaxErrorCheck
    {
        CsvID = cl.First().CsvID,
        DocumentDate = cl.First().DocumentDate,
        Amount = cl.Sum(c => c.Amount)
    }).Where(x => x.Amount > 7500).ToList();

            sells.Select(c => { c.ErrorIdentity = 1; return c; }).ToList();
            setlist.AddRange(sells);
            return setlist;
        }
        public static List<TaxErrorcheckDataz> checkSecond(TaxErrorcheckTest getlist, List<TaxErrorcheckDataz> plist)
        {
            List<TaxErrorcheckDataz> setlist = new List<TaxErrorcheckDataz>();
            List<TaxErrorcheckDatazView> chklist = getlist.getOverList();
            if (getlist == null || chklist.Count < 2)
            {
                return setlist;
            }
            ArrayList narray = new ArrayList();

            for (int i = 1; i < chklist.Count; i++)
            {
                if (chklist[i].MonthID - chklist[i - 1].MonthID == 1)
                {
                    if (!narray.Contains(chklist[i].MonthID))
                    {
                        narray.Add(chklist[i].MonthID);
                    }

                    if (!narray.Contains(chklist[i - 1].MonthID))
                    {
                        narray.Add(chklist[i - 1].MonthID);
                    }
                }

            }
            setlist = plist.Where(x => narray.Contains(x.EndDate.Month)).ToList();

            foreach (var item in setlist)
            {
                item.ErrorIdentity = 2;
                item.Amount = (float)chklist.Where(X => X.MonthID == item.EndDate.Month).FirstOrDefault().Amount;
            }

            setlist.Select(c => { c.ErrorIdentity = 2; return c; }).ToList();

            return setlist;
        }

        public static List<TaxErrorcheckDataz> checkThird(TaxErrorcheckTest getlist, List<TaxErrorcheckDataz> plist)
        {
            List<TaxErrorcheckDataz> setlist = new List<TaxErrorcheckDataz>();
            List<TaxErrorcheckDatazView> chklist = getlist.getMinusList();
            if (getlist == null || chklist.Count < 1)
            {
                return setlist;
            }
            ArrayList narray = new ArrayList();

            for (int i = 0; i < chklist.Count; i++)
            {


                if (!narray.Contains(chklist[i].MonthID))
                {
                    narray.Add(chklist[i].MonthID);
                }


            }
            setlist = plist.Where(x => narray.Contains(x.EndDate.Month)).ToList();

            foreach (var item in setlist)
            {

                item.Amount = (float)chklist.Where(X => X.MonthID == item.EndDate.Month).FirstOrDefault().Amount;
            }

            setlist.Select(c => { c.ErrorIdentity = 3; return c; }).ToList();

            return setlist;
        }
    }

}
