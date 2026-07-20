using System;
using System.Collections.Generic;

namespace fincheckup.Models.ViewModel
{
    public class ReportFilterView
    {
        public ReportFilterView()
        {
            FirstDate = DateTime.Now;

        }
        public long CompanyID { get; set; }
        public string SearchValue { get; set; }
        public DateTime FirstDate { get; set; }
    }

    public class CashflowView
    {
        public float TypeID { get; set; }
        public long CompanyID { get; set; }
        public float Amount { get; set; }
        public string MainDesc { get; set; }
        public int Year { get; set; }
    }
    public class SsoReturn
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string QnbUserId { get; set; }
        public string QnbCompanyId { get; set; }
        public long CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int uploadDocumentType { get; set; } 
        public List<int> uploadYears { get; set; }=new List<int>();    
    }
    public class StockInFilterView
    {
        public int OrderRequestID { get; set; }
        public int VendorID { get; set; }
        public string SearchValue { get; set; }
    }

    public class StockInReportFilterView
    {
        public StockInReportFilterView()
        {

            FirstDate = DateTime.Now;
            LastDate = DateTime.Now;
        }

        public int VendorID { get; set; }
        public DateTime FirstDate { get; set; }

        public DateTime LastDate { get; set; }
    }

    public class OrderReportFilterView
    {
        public OrderReportFilterView()
        {

            FirstDate = DateTime.Now;
            LastDate = DateTime.Now;
        }
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public DateTime FirstDate { get; set; }
        public int VendorID { get; set; }
        public DateTime LastDate { get; set; }
    }

    //PR.OrderRequestsMainID  ,ord.ItemName,ord.EstimatedCost ,ord.VendorID,ord.QuantityChecked,SUM(ord.QuantityChecked*ord.EstimatedCost) as Total




}
