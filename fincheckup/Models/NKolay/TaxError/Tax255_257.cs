using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.TaxError
{
    public class Tax255_257
    {
        public static List<TaxErrorcheckDataz> checkFrist(IEnumerable<TaxErrorcheckTest> getlist, List<TaxErrorcheckDataz> plist)
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
                    if (chklist[i].Amount - chklist[i - 1].Amount == 0)
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

                setlist.AddRange(plist.Where(x => narray.Contains(x.EndDate.Month)).ToList());
                //foreach (var item in setlist)
                //{
                //    item.ErrorIdentity = 3;
                //    item.Amount = (float)chklist.Where(X => X.MonthID == item.EndDate.Month).FirstOrDefault().Amount;
                //}

            }


            setlist.Select(c => { c.ErrorIdentity = 7; return c; }).ToList();

            return setlist;
        }
    }
}
