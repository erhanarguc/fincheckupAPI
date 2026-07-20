using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.TaxError
{
    public class Tax195
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
                    if (chklist[i].MonthID - chklist[i - 1].Amount == 0)
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

    public class Tax195a
    {
        public static List<TaxErrorcheckDataz> checkFrist(IEnumerable<TaxErrorcheckDataz> getlist, List<TaxErrorcheckDataz> plist)
        {
            List<TaxErrorcheckDataz> setlist = new List<TaxErrorcheckDataz>();
            ArrayList narray = new ArrayList();
            if (getlist == null)
            {
                return setlist;
            }


            IEnumerable<TaxErrorcheckDataz> nlist = null;
            List<int> mnlist = getlist.Select(x => x.EndDate.Month).Distinct().ToList();
            mnlist.Sort();


            foreach (var itemz in getlist)
            {


                //List<TaxErrorcheckDatazView> chklist = itemz.getOverZeroList();
                //if (chklist.Count < 1)
                //{
                //    break;
                //}
                for (int i = 0; i < mnlist.Count(); i++)
                {

                    nlist = getlist.Where(x => x.EndDate.Month == mnlist[i]);
                    //if (chklist[i].MonthID - chklist[i - 1].Amount == 0)
                    //{
                    //    if (!narray.Contains(chklist[i].MonthID))
                    //    {
                    //        narray.Add(chklist[i].MonthID);
                    //    }

                    //    if (!narray.Contains(chklist[i - 1].MonthID))
                    //    {
                    //        narray.Add(chklist[i - 1].MonthID);
                    //    }
                    //}



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

        public static void checkAccount(IEnumerable<TaxErrorcheckDataz> getlist)
        {
            //setlist.AddRange(plist.Where(x => narray.Contains(x.EndDate.Month)).ToList());
            //foreach (var item in setlist)
            //{
            //    item.ErrorIdentity = 3;
            //    item.Amount = (float)chklist.Where(X => X.MonthID == item.EndDate.Month).FirstOrDefault().Amount;
            //}

        }



    }
}
