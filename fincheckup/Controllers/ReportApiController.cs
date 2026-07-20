using DevExtreme.AspNet.Mvc;
using fincheckup.ENTITY;
using fincheckup.Models.EarlyWarning.Response;
using fincheckup.Models.EarlyWarning;
using fincheckup.Models.Qnb;
using fincheckup.Models.ViewM;
using fincheckup.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Controllers
{
    [Route("ReportApi/[action]")]
    public class ReportApiController : Controller
    {
        ReportFilterView nReportFilterView = new ReportFilterView();
        IEnumerable<DataViewer> nlist;
        DataViewerMain mrequestDataViewer;
        public JsonResult GetList(DataSourceLoadOptions loadOptions, string userData)
        {
            mrequestDataViewer = new DataViewerMain();
            var md = JsonConvert.DeserializeObject<ReportFilterView>(userData);

            if (md.CompanyID == 0)
            {
                nlist = Data.Get_AllbyCsvIDEntryNoNope();
            }
            else
            {
                int _csvid = TBLXml.GetComapnyIDByMonth(md.CompanyID, md.FirstDate.Month, md.FirstDate.Year);
                nlist = Data.Get_AllbyCsvIDEntryNo(_csvid, md.SearchValue);
            }

            mrequestDataViewer.SetDataViewer(nlist.ToList());
            //ReportViewList = new List<ReportView>();   //OrderRequestsMain.GetReportView();
            //if (md.DepartmentID != 0)
            //{
            //    ReportViewList = ReportViewList.Where(x => x.DepartmentID == md.DepartmentID);
            //}

            //if (md.VendorID != 0)
            //{
            //    ReportViewList = ReportViewList.Where(x => x.VendorID == md.VendorID);
            //}

            //if (md.FirstDate.Date != DateTime.Now.Date)
            //{
            //    ReportViewList = ReportViewList.Where(x => x.RequestedDate.Date >= md.FirstDate.Date);
            //}


            //if (md.LastDate.Date != DateTime.Now.Date)
            //{
            //    ReportViewList = ReportViewList.Where(x => x.RequestedDate.Date <= md.LastDate.Date);
            //}

            //return Json(ReportViewList);

            return Json(mrequestDataViewer.EntryData);
        }


        [HttpPut]
        public IActionResult PutOrderItem(int key, string values)
        {
            long UserID = 0;
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var t = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);

                if (t != null)
                {

                    UserID = Convert.ToInt32(@t.Value);

                }
            }
            //var orderCheck = OrderItems.GetRowOrderCheck(key);
            //var order = OrderItems.GetRow(key);
            //JsonConvert.PopulateObject(values, order);

            //if (!TryValidateModel(order))
            //    return BadRequest("nok");
            //int getItemCount = order.QuantityGet - orderCheck.QuantityGet;

            //if (getItemCount > 0)
            //{
            //    order.Upsert();
            //    Product prd = Product.GetRow(orderCheck.ProductID);

            //    Stock stck = Stock.GetbyBarcode(prd.PartNo);
            //    stck.StockID = 0;
            //    stck.UserID = UserID;
            //    stck.StoreID = orderCheck.StoreID;
            //    stck.LocationID = orderCheck.LocationID;
            //    stck.Piece = getItemCount;
            //    int stckID = stck.Upsert();


            //    JsonConvert.PopulateObject(values, orderCheck);
            //    OrderCheckIn orchkin = new OrderCheckIn();
            //    orchkin.InvoiceNumber = orderCheck.BillNumber;
            //    orchkin.ModifiedDate = DateTime.Now;
            //    orchkin.OrderItemID = orderCheck.OrderItemID;
            //    orchkin.ProductID = orderCheck.ProductID;
            //    orchkin.IsCash = order.IsCash;
            //    orchkin.Quantity = getItemCount;
            //    orchkin.VendorID = orderCheck.VendorID;
            //    orchkin.StoreID = orderCheck.StoreID;
            //    orchkin.StockID = stckID;
            //    orchkin.OrderPrice = order.EstimatedCost;
            //    orchkin.ListPrice = order.ListPrice;
            //    orchkin.Save();

            //    // var ordermain = OrderRequestsMain.GetRow(order.OrderRequestMainID);

            //    // orchkin.StoreID = ordermain.StoreID;

            //    // orchkin.StockID = ordermain.st;
            //}




            return Ok();
        }

        public JsonResult GetListOrderItem(DataSourceLoadOptions loadOptions, string userData)
        {
            var md = JsonConvert.DeserializeObject<StockInFilterView>(userData);

            //List<OrderItems> OrderItemsList = OrderItems.GetbyOrderIDCheck(md.OrderRequestID);



            //if (md.VendorID != 0)
            //{
            //    OrderItemsList = OrderItemsList.Where(x => x.VendorID == md.VendorID).ToList();
            //}

            //OrderItemsList = OrderItemsList.Where(x => x.IsBoughtFull == false).ToList();

            //return Json(OrderItemsList);
            return Json("ok");
        }

        public JsonResult GetListDailyInOrderItem(DataSourceLoadOptions loadOptions, string userData)
        {
            var md = JsonConvert.DeserializeObject<StockInReportFilterView>(userData);

            //List<OrderCheckIn> OrderCheckInList = OrderCheckIn.GetbyDate(md.FirstDate, md.LastDate);
            //if (md.VendorID != 0)
            //{
            //    OrderCheckInList = OrderCheckInList.Where(x => x.VendorID == md.VendorID).ToList();
            //}

            //return Json(OrderCheckInList);
            return Json("ok");
        }
        public JsonResult GetListItemMain(DataSourceLoadOptions loadOptions, string userData)
        {
            //var md = JsonConvert.DeserializeObject<OrderReportFilterView>(userData);
            //ReportViewMonthlyList = OrderRequestsMain.GetReportViewItemMain(md.FirstDate, md.LastDate, md.ProductID);



            //ReportViewMonthlyList = ReportViewMonthlyList.Count() < 1 ? new List<ReportViewMonthly>() : ReportViewMonthlyList;




            //return Json(ReportViewMonthlyList);
            return Json("ok");
        }
        public JsonResult GetListItem(DataSourceLoadOptions loadOptions, string userData)
        {
            var md = JsonConvert.DeserializeObject<ReportFilterView>(userData);
            //ReportViewMonthlyList = OrderRequestsMain.GetReportViewItemMonth(md.FirstDate.Year, md.FirstDate.Month);
            //if (md.DepartmentID != 0)
            //{
            //    ReportViewMonthlyList = ReportViewMonthlyList.Where(x => x.DepartmentID == md.DepartmentID).ToList();
            //}

            //if (md.VendorID != 0)
            //{
            //    ReportViewMonthlyList = ReportViewMonthlyList.Where(x => x.VendorID == md.VendorID).ToList();
            //}

            //ReportViewMonthlyList = ReportViewMonthlyList.Count() < 1 ? new List<ReportViewMonthly>() : ReportViewMonthlyList;




            //return Json(ReportViewMonthlyList);
            return Json("ok");
        }
        public JsonResult GetListChart(DataSourceLoadOptions loadOptions, string userData)
        {
            //var md = JsonConvert.DeserializeObject<ReportFilterView>(userData);
            //var ReportViewChartLista = OrderRequestsMain.GetReportChart();
            //ReportViewChartLista = ReportViewChartLista.Where(x => x.OrderYear == md.FirstDate.Year).ToList();
            //return Json(ReportViewChartLista);
            return Json("ok");
        }

        [HttpGet]
        public object VendorLookup(DataSourceLoadOptions loadOptions)
        {
            //var lookup = Vendor.ToList;
            //return DataSourceLoader.Load(lookup, loadOptions);
            return Json("ok");
        }

        public JsonResult GetListChartVen(DataSourceLoadOptions loadOptions, string userData)
        {
            //var md = JsonConvert.DeserializeObject<ReportFilterView>(userData);
            //var ReportViewChartLista = OrderRequestsMain.GetReportChartVen();
            //ReportViewChartLista = ReportViewChartLista.Where(x => x.OrderYear == md.FirstDate.Year).ToList();


            //if (md.VendorID != 0)
            //{
            //    ReportViewChartLista = ReportViewChartLista.Where(x => x.ItemID == md.VendorID).ToList();
            //}

            //return Json(ReportViewChartLista);
            return Json("ok");
        }
        public JsonResult GetListChartVenItem(DataSourceLoadOptions loadOptions, string userData)
        {
            //var md = JsonConvert.DeserializeObject<OrderReportFilterView>(userData);
            //var ReportViewChartLista = OrderRequestsMain.GetReportChartVenItem(md.FirstDate, md.LastDate, md.ProductID);


            //if (md.VendorID != 0)
            //{
            //    ReportViewChartLista = ReportViewChartLista.Where(x => x.ItemID == md.VendorID).ToList();
            //}

            //return Json(ReportViewChartLista);
            return Json("ok");
        }
        public JsonResult GetListChartItem(DataSourceLoadOptions loadOptions, string userData)
        {
            //var md = JsonConvert.DeserializeObject<OrderReportFilterView>(userData);
            //var ReportViewChartLista = OrderRequestsMain.GetReportChartItem(md.FirstDate, md.LastDate, md.ProductID);
            //return Json(ReportViewChartLista);
            return Json("ok");
        }
        public JsonResult GetListChartDep(DataSourceLoadOptions loadOptions, string userData)
        {
            //var md = JsonConvert.DeserializeObject<ReportFilterView>(userData);
            //var ReportViewChartLista = OrderRequestsMain.GetReportChartDep();
            //ReportViewChartLista = ReportViewChartLista.Where(x => x.OrderYear == md.FirstDate.Year).ToList();



            //if (md.DepartmentID != 0)
            //{
            //    ReportViewChartLista = ReportViewChartLista.Where(x => x.ItemID == md.DepartmentID).ToList();
            //}

            //return Json(ReportViewChartLista);
            return Json("ok");
        }
        public Object GetListOrder(DataSourceLoadOptions loadOptions, int key, int vendorid)
        {

            //if (key == 0)
            //{
            //    return Json(new List<ReportViewItem>());
            //}



            //ReportViewListtem = OrderRequestsMain.GetReportViewItem(key);
            //var returnList = ReportViewListtem.Where(x => x.VendorID == vendorid);
            //return DataSourceLoader.Load(returnList, loadOptions);
            return Json("ok");
        }
        public JsonResult FormAccountPost(ReminderAccount model)
        {
            
            if (ModelState.IsValid)
            {  

                  model.Save_ReminderAccount();
                return Json("ok");
            }
            return Json("nok");
        }

        public JsonResult FormAccountPut(ReminderAccount model)
        {
          
            if (ModelState.IsValid)
            {
               

                var result = model.Update_ReminderAccount();
                return Json(result);
            }
            return Json("nok");
        }
        public JsonResult FormAccountGroupPost(ReminderAccountGroup  model)
        {
           
            if (ModelState.IsValid)
            {
                

                 model.Save_ReminderAccountGroup();
                return Json("ok");
            }
            return Json("nok");
        }
        public JsonResult FormAccountGroupPut(ReminderAccountGroup  model)
        {
           
            if (ModelState.IsValid)
            {
                

                var result = model.Update_ReminderAccountGroup();
                return Json(result);
            }
            return Json("nok");
        }
        public JsonResult FormRulePost(ReminderRule model)
        {
           
            if (ModelState.IsValid)
            {
             

                model.Save_ReminderRule();
                return Json("ok");
            }
            return Json("nok");
        }
        public JsonResult FormRuleJobPost(ReminderRuleJob model)
        {
      
            if (ModelState.IsValid)
            {
               

               model.Save_ReminderRuleJob();
                return Json("ok");
            }
            return Json("nok");
        }
        public JsonResult FormRuleJobCompanyPost(ReminderRuleJob  model)
        {
           
            if (ModelState.IsValid)
            {
                model.Save_ReminderRuleJob();
                return Json("ok");
            }
            return Json("nok");
        }
    }
}
