using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.TaxError
{
    public class Tax254
    {
        public static List<TaxErrorcheckDataz> checkFrist(TaxErrorcheckTest getlist, List<TaxErrorcheckDataz> plist)
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



            setlist.Select(c => { c.ErrorIdentity = 12; return c; }).ToList();

            return setlist;
        }
    }
}
