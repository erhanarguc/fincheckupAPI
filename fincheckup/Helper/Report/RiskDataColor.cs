using System.Collections.Generic;
using System;
using System.Linq;

namespace fincheckup.Helper.Report
{
    public class RiskDataColor
    {
        public int ncheck1Point { get; set; }
        public float ncheck1 { get; set; }
        public int ncheck2Point { get; set; }
        public float ncheck2 { get; set; } 
        public int ncheck3Point { get; set; }
        public float ncheck3 { get; set; } 
        public int ncheck4Point { get; set; }
        public float ncheck4 { get; set; } 
        public int ncheck5Point { get; set; }
        public float ncheck5 { get; set; }
        public int ncheck6Point { get; set; }
        public float ncheck6 { get; set; } 
        public int ncheck7Point { get; set; }
        public float ncheck7 { get; set; } 
        public int ncheck8Point { get; set; }
        public float ncheck8 { get; set; }
        public int ncheck9Point { get; set; }
        public float ncheck9 { get; set; }
        public int ncheck10Point { get; set; }
        public float ncheck10 { get; set; } 
        public int ncheck11Point { get; set; }
        public float ncheck11 { get; set; }
        public int ncheck12Point { get; set; }
        public float ncheck12 { get; set; }
        public int OrderID { get; set; }
        public static RiskDataColor getListedPoint(List<ReportMainItem> listData,int orderId,bool negatif, RiskDataColor riskData)
        {
          
            int yearlast = listData.Select(x => x.Year).Max();
            int count = listData.Count();
            int point = 0;
            float lastvalue = listData.Where(x => x.Year == yearlast).Select(z => z.TumYil).FirstOrDefault();
            float totalvalue = listData.Where(x => x.Year != yearlast).Sum(z => z.TumYil)/ count;
            float percntge =totalvalue!=0? lastvalue / totalvalue:0;
            if (negatif)
            {
                if (percntge < 0.1f) { point = 1; }
                else if (percntge < 0.05f) { point = 2; }  
                else if (percntge > 1.5) { point = 5; } 
                else if (percntge > 1) { point = 4; }
                else if (percntge > 0) { point = 3; }
            }
            else
            {
                if (percntge < 0.1f) { point = 5; }
                else if (percntge < 0.05f) { point = 4; }
                else if (percntge > 1.5) { point = 1; }
                else if (percntge > 1) { point = 2; }
                else if (percntge > 0) { point = 3; }
            }


            switch (orderId)
            {
                case 1:
                    riskData.ncheck1 = lastvalue; riskData.ncheck1Point = point;break;
                case 2:
                    riskData.ncheck2= lastvalue; riskData.ncheck2Point = point; break;
                case 3:
                    riskData.ncheck3 = lastvalue; riskData.ncheck3Point = point; break;
                case 4:
                    riskData.ncheck4 = lastvalue; riskData.ncheck4Point = point; break;
                case 5:
                    riskData.ncheck5 = lastvalue; riskData.ncheck5Point = point; break;
                case 6:
                    riskData.ncheck6 = lastvalue; riskData.ncheck6Point = point; break;
                case 7:
                    riskData.ncheck7 = lastvalue; riskData.ncheck7Point = point; break;
                case 8:
                    riskData.ncheck8 = lastvalue; riskData.ncheck8Point = point; break;
                case 9:
                    riskData.ncheck9 = lastvalue; riskData.ncheck9Point = point; break;
                case 10:
                    riskData.ncheck10 = lastvalue; riskData.ncheck10Point = point; break;
                case 11:
                    riskData.ncheck11 = lastvalue; riskData.ncheck11Point = point; break;
                case 12:
                    riskData.ncheck12 = lastvalue; riskData.ncheck12Point = point; break;
                default:
                    break;
            }
            return riskData;
        }
       
    }
}
