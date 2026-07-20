using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Helper.Report
{
    public class RiskData
    {
        public int CariRatePoint { get; set; }
        public float CariRate { get; set; }

        public int TotalDebttoEquityRatioPoint { get; set; }
        public float TotalDebttoEquityRatio { get; set; }

        public int LiquidityRatioPoint { get; set; }
        public float LiquidityRatio { get; set; }

        public int TotalBankBorrowingsVelocityPoint { get; set; }
        public float TotalBankBorrowingsVelocity { get; set; }

        public int CashAssetRatioPoint { get; set; }
        public float CashAssetRatio { get; set; }

        public int EquityPoint { get; set; }
        public float Equity { get; set; }

        public float ToplamAlacak171Devir  { get; set; }

        public static RiskData getListedPoint(IEnumerable<ReportMainItem> listData)
        {
            RiskData riskData = new RiskData();

            riskData.CariRate= listData.Where(x => x.TypeID == 11).FirstOrDefault() == null ? 0: listData.Where(x => x.TypeID == 11).FirstOrDefault().TumYil;

            riskData.TotalDebttoEquityRatio = listData.Where(x => x.TypeID == 141).FirstOrDefault() == null ? 0 : listData.Where(x => x.TypeID == 141).FirstOrDefault().TumYil;
            riskData.LiquidityRatio = listData.Where(x => x.TypeID == 33).FirstOrDefault() == null ? 0 : listData.Where(x => x.TypeID == 33).FirstOrDefault().TumYil;

            riskData.TotalBankBorrowingsVelocity = listData.Where(x => x.TypeID == 161).FirstOrDefault() == null ? 0 : listData.Where(x => x.TypeID == 161).FirstOrDefault().TumYil;
            riskData.CashAssetRatio = listData.Where(x => x.TypeID == 55).FirstOrDefault() == null ? 0 : listData.Where(x => x.TypeID == 55).FirstOrDefault().TumYil;
            riskData.ToplamAlacak171Devir = listData.Where(x => x.TypeID == 171).FirstOrDefault() == null ? 0 : listData.Where(x => x.TypeID == 171).FirstOrDefault().TumYil;
            riskData.Equity = listData.Where(x => x.TypeID == 201).FirstOrDefault() == null ? 0 : listData.Where(x => x.TypeID == 201).FirstOrDefault().TumYil;
            return riskData;
        }
        public static RiskData getPoint(RiskData riskData) {
            Random rand = new Random();
            if (riskData.CariRate< ReportRatioConstant.CariOran11Min)
            {
                if (riskData.CariRate< ReportRatioConstant.CariOranFailMax)
                {
                    riskData.CariRatePoint = 7;
                }
                else
                {
                    if (riskData.CariRate > 0.95f)
                    {
                        riskData.CariRatePoint = 2;
                    }
                    else if (riskData.CariRate > 0.9f) {
                        riskData.CariRatePoint = 3;
                    }
                    else if (riskData.CariRate > 0.85f)
                    {
                        riskData.CariRatePoint = 4;
                    }
                    else if (riskData.CariRate > 0.8f)
                    {
                        riskData.CariRatePoint = 5;
                    }
                    else
                    {
                        riskData.CariRatePoint = 6;
                    }
    
                }
            }
            else
            {
                riskData.CariRatePoint = 1;
            }



            if (riskData.LiquidityRatio < ReportRatioConstant.LikitideOran33Min)
            {
                if (riskData.LiquidityRatio < ReportRatioConstant.LikitideOranFailMax)
                {
                    riskData.LiquidityRatioPoint = 7;
                }
                else
                {
                    if (riskData.LiquidityRatio > 0.95f)
                    {
                        riskData.LiquidityRatioPoint = 2;
                    }
                    else if (riskData.LiquidityRatio > 0.9f)
                    {
                        riskData.LiquidityRatioPoint = 3;
                    }
                    else if (riskData.LiquidityRatio > 0.85f)
                    {
                        riskData.LiquidityRatioPoint = 4;
                    }
                    else if (riskData.LiquidityRatio > 0.8f)
                    {
                        riskData.LiquidityRatioPoint = 5;
                    }
                    else
                    {
                        riskData.LiquidityRatioPoint = 6;
                    }
                }
            }
            else
            {
                riskData.LiquidityRatioPoint = 1;
            }


        

            if (riskData.CashAssetRatio < ReportRatioConstant.NakitOran55Min || riskData.CashAssetRatio  > ReportRatioConstant.NakitOran55Max)
            {
                if (riskData.CashAssetRatio < ReportRatioConstant.NakitOran55MinFail || riskData.CashAssetRatio > ReportRatioConstant.NakitOran55MaxFail)
                {
                    riskData.CashAssetRatioPoint = 7;
                }
                else
                {
                    riskData.CashAssetRatioPoint = rand.Next(2, 7);
                }
            }
            else
            {
                riskData.CashAssetRatioPoint = 1;
            }



           

            if (riskData.TotalBankBorrowingsVelocity < riskData.ToplamAlacak171Devir && riskData.TotalBankBorrowingsVelocity!=0)
            {
                if (riskData.ToplamAlacak171Devir - riskData.TotalBankBorrowingsVelocity>10)
                {
                    riskData.TotalBankBorrowingsVelocityPoint = 7;
                }
                else
                {
                    riskData.TotalBankBorrowingsVelocityPoint = rand.Next(2, 7);
                }
            }
            else
            {
                riskData.TotalBankBorrowingsVelocityPoint = 1;
            }



            if (riskData.TotalDebttoEquityRatio >ReportRatioConstant.ToplamBorcOzsermayeOran141Max)
            {
                if (riskData.TotalDebttoEquityRatio > ReportRatioConstant.ToplamBorcOzsermayeOranFailMin )
                {
                    riskData.TotalDebttoEquityRatioPoint = 7;
                }
                else
                {
                    if (riskData.TotalDebttoEquityRatio < 0.25f)
                    {
                        riskData.TotalDebttoEquityRatioPoint = 2;
                    }
                    else if (riskData.TotalDebttoEquityRatio < 0.3f)
                    {
                        riskData.TotalDebttoEquityRatioPoint = 3;
                    }
                    else if (riskData.TotalDebttoEquityRatio < 0.35f)
                    {
                        riskData.TotalDebttoEquityRatioPoint = 4;
                    }
                    else if (riskData.TotalDebttoEquityRatio < 0.4f)
                    {
                        riskData.TotalDebttoEquityRatioPoint = 5;
                    }
                    else
                    {
                        riskData.TotalDebttoEquityRatioPoint = 6;
                    }
                    
                }
            }
            else
            {
                riskData.TotalDebttoEquityRatioPoint = 1;
            }


            if (riskData.Equity < ReportRatioConstant.OzkaynakAktifToplamOran201Min)
            {
                if (riskData.Equity < ReportRatioConstant.OzkaynakAktifToplamOran201MinFail)
                {
                    riskData.EquityPoint = 7;
                }
                else
                {
                    if (riskData.Equity > -0.9f)
                    {
                        riskData.EquityPoint = 2;
                    }
                    else if (riskData.Equity > -0.85f)
                    {
                        riskData.EquityPoint = 3;
                    }
                    else if (riskData.Equity > -0.8f)
                    {
                        riskData.EquityPoint = 4;
                    }
                    else if (riskData.Equity > -0.7f)
                    {
                        riskData.EquityPoint = 5;
                    }
                    else
                    {
                        riskData.EquityPoint = 6;
                    }
                  
                }
            }
            else
            {
                riskData.EquityPoint = 1;
            }
            return riskData;
        }


    }
}
