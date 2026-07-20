using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.TaxError
{
    public class Tax102
    {
        public static List<TaxErrorcheckDataz> checkFrist(IEnumerable<TaxErrorcheckTest> getlist, List<TaxErrorcheckDataz> plist, IEnumerable<int> monthlist)
        {
            List<TaxErrorcheckDataz> setlist = new List<TaxErrorcheckDataz>();
            ArrayList narray = new ArrayList();
            if (getlist == null)
            {
                return setlist;
            }

            foreach (var itemz in getlist)
            {
                List<TaxErrorcheckDatazView> chklist = itemz.getOverZeroList();
                if (chklist.Count < 1)
                {
                    break;
                }

                for (int i = 1; i < chklist.Count; i++)
                {


                    if (!narray.Contains(chklist[i].MonthID) && !monthlist.Contains(chklist[i].MonthID))
                    {
                        narray.Add(chklist[i].MonthID);
                    }


                }

                setlist.AddRange(plist.Where(x => narray.Contains(x.EndDate.Month)).ToList());
                foreach (var item in setlist)
                {
                    item.ErrorIdentity = 3;
                    item.Amount = (float)chklist.Where(X => X.MonthID == item.EndDate.Month).FirstOrDefault().Amount;
                }

            }


            setlist.Select(c => { c.ErrorIdentity = 4; return c; }).ToList();

            return setlist;
        }
    }
}
