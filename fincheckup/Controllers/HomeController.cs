using DevExpress.Office.Utils;
using fincheckup.ENTITY;
using fincheckup.Helper;
using fincheckup.Models.Mizan;
using fincheckup.Models.NKolay;
using fincheckup.Models.NKolay.ENTITY;
using fincheckup.Models.NKolay.ENTITY.NwEntity;
using fincheckup.Models.NKolay.json;
using fincheckup.Models.NKolay.MizanView;
using fincheckup.Models.NKolay.ViewM;
using fincheckup.Models.ViewM;
using fincheckup.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace fincheckup.Controllers
{
    [Route("JsonService/Main/[action]")]
    public class HomeController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;
        private readonly IWzoneSWRService _svc;
        private readonly IWChkSWRService _svcHk;
        private readonly IWChkWordSWRService _svcHkwrd;
        private readonly IWzonerSWRService _svcer;
        
        public HomeController(IWebHostEnvironment environment, IWzoneSWRService svc, IWChkSWRService svcHk, IWChkWordSWRService svcHkwrd , IWzonerSWRService  svcer)
        {
            _hostingEnvironment = environment;
            _svc = svc;
            _svcHk = svcHk;
            _svcHkwrd = svcHkwrd; 
            _svcer = svcer;
        }


        public JsonResult moodUpdate(XMlookUpdate pageIndex)
        {
            if (!ModelState.IsValid)
            {

                return Json("nok");
            }

            try
            {
                var chka = TBLXml.GetComapnyIDByMonth(pageIndex.companyid, pageIndex.month, pageIndex.year);
                var test = Data.Get_AllbyCsvIDataz(chka, pageIndex.month);
                var retval = XmlChecker.UpdateChek(chka, test, pageIndex.month, pageIndex.companyid);
                if (retval != "nok")
                {
                    int fyear = pageIndex.year;

                    List<DashBilancoView> nRequestList = DashBilancoViewMain.getList(fyear, pageIndex.companyid);
                    var tlist = Data.SetBilancoFromList(nRequestList, pageIndex.companyid, fyear);
                    Data.RESET_DashBilancoView(fyear, pageIndex.companyid);
                    Data.InsertBilnco(tlist);
                    List<DashBilancoView> nRequestListRvn = DashGelirTablosuViewMain.getList(fyear, pageIndex.companyid);
                    var tlistRvn = Data.SetBilancoFromList(nRequestListRvn, pageIndex.companyid, fyear);
                    Data.RESET_REVENUEView(fyear, pageIndex.companyid);
                    var WCapitalViez = DashWCapitalViewMain.getList(fyear, pageIndex.companyid);

                    var WCapitalVie = Data.SetBilancoFromList(WCapitalViez, pageIndex.companyid, fyear);
                    var nLiqudity = DashLikiditeViewMain.getList(fyear, pageIndex.companyid);
                    var WLiqudity = Data.SetBilancoFromList(nLiqudity, pageIndex.companyid, fyear);
                    Data.InsertLiquidity(WLiqudity);
                    Data.InsertWCapital(WCapitalVie);

                    Data.InsertRvn(tlistRvn);
                    DashRasyo.GetDashRasyoAnaliz(fyear, pageIndex.companyid);
                    DashRasyo.GetDashLikiditeRiskTrend(fyear, pageIndex.companyid);
                    DashRasyo.GetDashOzetMali(fyear, pageIndex.companyid, pageIndex.month);
                    MainDash.Get_DatabyErrorV1(fyear, pageIndex.companyid, pageIndex.month);

                }
            }
            catch (Exception ex)
            {

                return Json("nok_" + ex.ToString());
            }



            return Json("ok");


        }
        [RequestFormLimits(MultipartBodyLengthLimit = 9509715200)]
        [RequestSizeLimit(9509715200)]
        public async Task<JsonResult> moodUpload(XMlook pageIndex)
        {


            var file = pageIndex.file;
            string orjinalname = file[0].FileName;
            string filemonth = pageIndex.Caption.Split('_')[0];
            string fileyear = pageIndex.Caption.Split('_')[1];
            //string flastmonth = pageIndex.Caption.Split('_')[2];
            string filePath = string.Empty;
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            List<string> nlistZipurl = new List<string>();
            Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));
            bool IsZip = false;
            if (file != null && file.Count > 0)
            {
                string ext = System.IO.Path.GetExtension(file[0].FileName);
                if (ext.ToLower().Contains("zip"))
                {
                    IsZip = true;
                }
            }
            else
            {
                return Json("nok");
            }

            string pathToXmlFile = string.Empty;
            if (IsZip)
            {

                foreach (var item in file)
                {
                    filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".zip");
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream).ConfigureAwait(false);
                    }
                    nlistZipurl.Add(filePath);
                }

                pathToXmlFile = uploads;
            }
            else
            {

                foreach (var item in file)
                {
                    filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".xml");
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream).ConfigureAwait(false);
                    }
                    CopyContentsUntilNull(filePath);
                    nlistZipurl.Add(filePath);
                }

                pathToXmlFile = filePath;

            }

            long UserID = Int64.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            //bool lastmonthchk = filemonth == flastmonth ? true : false;
            var cmlCheckList = await _svc.GetAllAsync();
            var errCheckList = await _svcHk.GetAllAsync();
            var wrdCheckList = await _svcHkwrd.GetAllAsync();
            var wrdErrChkist = await _svcer.GetAllAsync();
            try
            {
                string retval = string.Empty;
                if (TBLXml.GetComapnyIDByMonthCount(comp.ID, Convert.ToInt32(filemonth), Convert.ToInt32(fileyear)) > 0)
                {
                    retval = await XmlChecker.XmlCheck(IsZip, 1, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname, false, cmlCheckList.ToList(),wrdCheckList.ToList(), errCheckList.ToList(), wrdErrChkist.ToList());
                }
                else
                {
                    retval = await XmlChecker.XmlCheck(IsZip, 0, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname, false, cmlCheckList.ToList(), wrdCheckList.ToList(), errCheckList.ToList(), wrdErrChkist.ToList());

                }

                if (retval != "nok")
                {

                    int fyear = Convert.ToInt32(fileyear);



                    List<DashBilancoView> nRequestList = DashBilancoViewMain.getList(fyear, comp.ID);
                    var tlist = Data.SetBilancoFromList(nRequestList, comp.ID, fyear);
                    Data.RESET_DashBilancoView(fyear, comp.ID);
                    Data.InsertBilnco(tlist);
                    List<DashBilancoView> nRequestListRvn = DashGelirTablosuViewMain.getList(fyear, comp.ID);
                    Data.RESET_REVENUEView(fyear, comp.ID);
                    var tlistRvn = Data.SetBilancoFromList(nRequestListRvn, comp.ID, fyear);
                    var WCapitalViez = DashWCapitalViewMain.getList(fyear, comp.ID);
                    var WCapitalVie = Data.SetBilancoFromList(WCapitalViez, comp.ID, fyear);
                    var nLiqudity = DashLikiditeViewMain.getList(fyear, comp.ID);
                    var WLiqudity = Data.SetBilancoFromList(nLiqudity, comp.ID, fyear);
                    Data.InsertLiquidity(WLiqudity);
                    Data.InsertWCapital(WCapitalVie);
                    Data.InsertRvn(tlistRvn);
                    DashRasyo.GetDashRasyoAnaliz(fyear, comp.ID);
                    DashRasyo.GetDashLikiditeRiskTrend(fyear, comp.ID);
                    DashRasyo.GetDashOzetMali(fyear, comp.ID, Convert.ToInt32(filemonth));
                    MainDash.Get_DatabyErrorV1(fyear, comp.ID, Convert.ToInt32(filemonth));


                }

                return Json(retval);
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = comp.ID;
                lg.CsvID = 7777;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;
                return Json("nok");

            }





        }
        [RequestFormLimits(MultipartBodyLengthLimit = 9509715200)]
        [RequestSizeLimit(9509715200)]
        public async Task<JsonResult> moodUploadChk(XMlook pageIndex)
        {


            var file = pageIndex.file;
            string orjinalname = file[0].FileName;
            string filemonth = pageIndex.Caption.Split('_')[0];
            string fileyear = pageIndex.Caption.Split('_')[1];
            //string flastmonth = pageIndex.Caption.Split('_')[2];
            string filePath = string.Empty;
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            List<string> nlistZipurl = new List<string>();
            Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));
            bool IsZip = false;
            if (file != null && file.Count > 0)
            {
                string ext = System.IO.Path.GetExtension(file[0].FileName);
                if (ext.ToLower().Contains("zip"))
                {
                    IsZip = true;
                }
            }
            else
            {
                return Json("nok");
            }

            string pathToXmlFile = string.Empty;
            if (IsZip)
            {

                foreach (var item in file)
                {
                    filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".zip");
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream).ConfigureAwait(false);
                    }
                    nlistZipurl.Add(filePath);
                }

                pathToXmlFile = uploads;
            }
            else
            {

                foreach (var item in file)
                {
                    filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".xml");
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream).ConfigureAwait(false);
                    }
                    CopyContentsUntilNull(filePath);
                    nlistZipurl.Add(filePath);
                }

                pathToXmlFile = filePath;

            }

            long UserID = Int64.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            //bool lastmonthchk = filemonth == flastmonth ? true : false;


            try
            {
                string retval = string.Empty;
                if (TBLXml.GetComapnyIDByMonthCount(comp.ID, Convert.ToInt32(filemonth), Convert.ToInt32(fileyear)) > 0)
                {
                    retval = await XmlChecker.XmlCheckChk(IsZip, 1, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname, false );
                }
                else
                {
                    retval = await XmlChecker.XmlCheckChk(IsZip, 0, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname, false );

                }

                if (retval != "nok")
                {

                    int fyear = Convert.ToInt32(fileyear);



                    List<DashBilancoView> nRequestList = DashBilancoViewMain.getList(fyear, comp.ID);
                    var tlist = Data.SetBilancoFromList(nRequestList, comp.ID, fyear);
                    Data.RESET_DashBilancoView(fyear, comp.ID);
                    Data.InsertBilnco(tlist);
                    List<DashBilancoView> nRequestListRvn = DashGelirTablosuViewMain.getList(fyear, comp.ID);
                    Data.RESET_REVENUEView(fyear, comp.ID);
                    var tlistRvn = Data.SetBilancoFromList(nRequestListRvn, comp.ID, fyear);
                    var WCapitalViez = DashWCapitalViewMain.getList(fyear, comp.ID);
                    var WCapitalVie = Data.SetBilancoFromList(WCapitalViez, comp.ID, fyear);
                    var nLiqudity = DashLikiditeViewMain.getList(fyear, comp.ID);
                    var WLiqudity = Data.SetBilancoFromList(nLiqudity, comp.ID, fyear);
                    Data.InsertLiquidity(WLiqudity);
                    Data.InsertWCapital(WCapitalVie);
                    Data.InsertRvn(tlistRvn);
                    DashRasyo.GetDashRasyoAnaliz(fyear, comp.ID);
                    DashRasyo.GetDashLikiditeRiskTrend(fyear, comp.ID);
                    DashRasyo.GetDashOzetMali(fyear, comp.ID, Convert.ToInt32(filemonth));
                    MainDash.Get_DatabyErrorV1(fyear, comp.ID, Convert.ToInt32(filemonth));


                }

                return Json(retval);
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = comp.ID;
                lg.CsvID = 7777;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;
                return Json("nok");

            }





        }

        public async Task<JsonResult> moodUploadNwMizan(XMlook pageIndex)
        {
            string filemonth = pageIndex.Caption.Split('_')[0];
            string fileyear = pageIndex.Caption.Split('_')[1];
            Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));
            var file = pageIndex.file;
            string filePath = string.Empty;
            List<string> nlistZipurl = new List<string>();
            string uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            if (file != null && file.Count > 0)
            {
                foreach (var item in file)
                {
                    filePath = System.IO.Path.Combine(uploads, Guid.NewGuid().ToString() + System.IO.Path.GetExtension(item.FileName));
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream).ConfigureAwait(false);
                    }

                }

            }
            int monID = Convert.ToInt32(filemonth);
            long CompID = Convert.ToInt64(pageIndex.ide);
            int nYear = Convert.ToInt32(fileyear);
            try
            {


                TBLXml ncs = new TBLXml();
                ncs.CompanyID = CompID;
                ncs.CreatedDate = DateTime.Now;
                ncs.DocumentDate = new DateTime(nYear, monID, 21); ;
                ncs.CsvName = filePath;
                ncs.Year = nYear;
                ncs.XmlDocName = file[0].FileName;
                ncs.Save_TBLXml();

                DataTable dt = ExcelHelper.ExcelToDataTable(filePath);
                IEnumerable<XmlExcel> nlist = ExcelHelper.CheckColumn(dt);
                nlist = nlist.Select(c => { c.AccountMainID = c.AccountMainID.Replace(",", ".").Replace("-", ".").Replace("_", ".").Trim(); return c; }).ToList();
                List<string> nnlist = DashBilancoSetMizan.GetAccountList();
                //   var tlista = nlist.Where(x => (x.CreditAmountFloat == x.AmountBakiyeFloat) && x.CreditAmountFloat == 0).ToList();
                nlist = nlist.Where(x => nnlist.Contains(x.AccountMainIDMain));
                List<XmlExcel> cchklist = nlist.Where(x => x.TextCount == 3).ToList();
                cchklist = cchklist.GroupBy(i => i.AccountMainID)
                               .Select(g => g.First())
                               .ToList();
                List<XmlExcel> cchklist1 = nlist.Where(x => x.TextCount >= 6).ToList();

                foreach (var item in cchklist1)
                {
                    try
                    {
                        if (item.AmountBakiye != (ConvertDec(item.DebitAmount) - Math.Abs(ConvertDec(item.CreditAmount))).ToString("n2"))
                        {
                            item.AmountBakiye = (ConvertDec(item.DebitAmount) - Math.Abs(ConvertDec(item.CreditAmount))).ToString("n2");
                        }
                    }
                    catch (Exception ex)
                    {

                        var chk = ex;
                    }



                }


                var tlist = Data.SetBilancoFromListMizanExcelNew(cchklist, CompID, nYear);

                if (cchklist1.Count > 0)
                {
                    var tlistsub = Data.SetBilancoFromListMizanExcelSub(cchklist1, CompID, nYear);
                    Data.InsertDataMizanSub(tlistsub);
                }

                if (tlist.Count > 0)
                {
                    foreach (XmlExcel us in tlist)
                    {
                        us.MainMonth = monID;
                        us.CsvID = ncs.ID;
                    }

                    Data.InsertDataMizanNew(tlist);
                }
                else
                {
                    Data.SET_MIZANHEADER(nYear, CompID);
                }



                //Data.SetOpener(ncs.ID, monID.ToString());

                Data dtx = new Data();

                dtx.SetHataLast(ncs.ID);

                dtx.SetHataLastz(ncs.ID);


                dtx.SetHataLastza(Convert.ToInt32(ncs.CompanyID), nYear);


                return Json("nok");

#pragma warning disable CS0162 // Unreachable code detected
                List<DashBilancoViewMizan> nRequestList1 = DashBilancoMizan.getList(nYear, CompID);
#pragma warning restore CS0162 // Unreachable code detected
                var tlist1 = Data.SetBilancoFromListMizan(nRequestList1, CompID, nYear);
                Data.RESET_DashBilancoViewMizan(nYear, CompID);
                Data.InsertBilncoMzn(tlist1);
                List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizan.getList(nYear, CompID);
                var tlistRvn1 = Data.SetBilancoFromListMizan(nRequestListRvn1, CompID, nYear);
                Data.RESET_REVENUEViewMzn(nYear, CompID);
                Data.InsertRvnMzn(tlistRvn1);
                var WLikiditeViez = DashLikiditeViewMainMizan.getList(nYear, CompID);
                var WCapitalViez = DashWCapitalViewMainMizan.getList(nYear, CompID);
                var WCapitalVie = Data.SetBilancoFromListMizan(WCapitalViez, CompID, nYear);
                var WLikiditeVie = Data.SetBilancoFromListMizan(WLikiditeViez, CompID, nYear);
                Data.InsertWCapitalMzn(WCapitalVie);
                Data.InsertLiquidityMzn(WLikiditeVie);
                DashBilancoSetMizan.Set_ReportSetMainSMM(nYear, CompID);
                DashRasyoMizan.GetDashRasyoAnaliz(nYear, CompID);
                DashRasyoMizan.GetDashLikiditeRiskTrend(nYear, CompID);
                DashRasyoMizan.GetDashOzetMali(nYear, CompID);
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = CompID;
                lg.CsvID = nYear;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                return Json(ex.ToString());
            }

#pragma warning disable CS0162 // Unreachable code detected
            return Json("ok");
#pragma warning restore CS0162 // Unreachable code detected




        }
        public async Task<JsonResult> moodUploadNwUpdateMizan(XMlook pageIndex)
        {

            string filemonth = pageIndex.Caption.Split('_')[0];
            string fileyear = pageIndex.Caption.Split('_')[1];



            var file = pageIndex.file;
            string filePath = string.Empty;
            string uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            int monID = Convert.ToInt32(filemonth);
            long CompID = Convert.ToInt64(pageIndex.ide);
            int nYear = Convert.ToInt32(fileyear);
            if (file != null && file.Count > 0)
            {
                foreach (var item in file)
                {
                    filePath = System.IO.Path.Combine(uploads, Guid.NewGuid().ToString() + System.IO.Path.GetExtension(item.FileName));
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream).ConfigureAwait(false);
                    }

                }

            }
            try
            {
                TBLXml ncs = new TBLXml();
                ncs.CompanyID = CompID;
                ncs.CreatedDate = DateTime.Now;
                ncs.DocumentDate = new DateTime(nYear, monID, 21); ;
                ncs.CsvName = filePath;
                ncs.Year = nYear;
                ncs.XmlDocName = file[0].FileName;
                ncs.Save_TBLXml();

                TBLXml.RESETALL_byCompanyID(nYear, CompID, monID, ncs.ID);

                DataTable dt = ExcelHelper.ExcelToDataTable(filePath);
                IEnumerable<XmlExcel> nlist = ExcelHelper.CheckColumn(dt);
                nlist = nlist.Select(c => { c.AccountMainID = c.AccountMainID.Replace(",", ".").Replace("-", ".").Replace("_", "."); return c; }).ToList();

                List<string> nnlist = DashBilancoSetMizan.GetAccountList();
                //   var tlista = nlist.Where(x => (x.CreditAmountFloat == x.AmountBakiyeFloat) && x.CreditAmountFloat == 0).ToList();

                nlist = nlist.Where(x => nnlist.Contains(x.AccountMainIDMain)).OrderBy(x => x.AccountMainID).ToList();

                //nlist = nlist.Except(tlista);
                List<XmlExcel> cchklist = nlist.Where(x => x.TextCount == 3).ToList();
                cchklist = cchklist.GroupBy(i => i.AccountMainID)
                                   .Select(g => g.First())
                                   .ToList();

                List<XmlExcel> cchklist1 = nlist.Where(x => x.TextCount >= 6).ToList();

                var tlist = Data.SetBilancoFromListMizanExcelNew(cchklist, CompID, nYear);
                foreach (var item in cchklist1)
                {
                    try
                    {
                        if (item.AmountBakiye != (ConvertDec(item.DebitAmount) - Math.Abs(ConvertDec(item.CreditAmount))).ToString("n2"))
                        {
                            item.AmountBakiye = (ConvertDec(item.DebitAmount) - Math.Abs(ConvertDec(item.CreditAmount))).ToString("n2");
                        }
                    }
                    catch (Exception ex)
                    {

                        var chk = ex;
                    }

                }

                DashBilancoSetMizan.Set_ReportSetResetMizanKayit(nYear, CompID);
                if (cchklist1.Count > 0)
                {
                    var tlistsub = Data.SetBilancoFromListMizanExcelSub(cchklist1, CompID, nYear);
                    Data.InsertDataMizanSub(tlistsub);
                }

                if (tlist.Count > 0)
                {
                    foreach (XmlExcel us in tlist)
                    {
                        us.MainMonth = monID;
                        us.CsvID = ncs.ID;
                    }
                    Data.InsertDataMizanNew(tlist);
                }
                else
                {
                    Data.SET_MIZANHEADER(nYear, CompID);
                }
                return Json("nok");
#pragma warning disable CS0162 // Unreachable code detected
                List<DashBilancoViewMizan> nRequestList1 = DashBilancoMizan.getList(nYear, CompID);
#pragma warning restore CS0162 // Unreachable code detected
                var tlist1 = Data.SetBilancoFromListMizan(nRequestList1, CompID, nYear);
                Data.RESET_DashBilancoViewMizan(nYear, CompID);
                Data.InsertBilncoMzn(tlist1);
                List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizan.getList(nYear, CompID);
                var tlistRvn1 = Data.SetBilancoFromListMizan(nRequestListRvn1, CompID, nYear);
                Data.RESET_REVENUEViewMzn(nYear, CompID);
                Data.InsertRvnMzn(tlistRvn1);
                var WLikiditeViez = DashLikiditeViewMainMizan.getList(nYear, CompID);
                var WCapitalViez = DashWCapitalViewMainMizan.getList(nYear, CompID);
                var WCapitalVie = Data.SetBilancoFromListMizan(WCapitalViez, CompID, nYear);
                var WLikiditeVie = Data.SetBilancoFromListMizan(WLikiditeViez, CompID, nYear);
                Data.InsertWCapitalMzn(WCapitalVie);
                Data.InsertLiquidityMzn(WLikiditeVie);
                DashBilancoSetMizan.Set_ReportSetMainSMM(nYear, CompID);
                DashRasyoMizan.GetDashRasyoAnaliz(nYear, CompID);
                DashRasyoMizan.GetDashLikiditeRiskTrend(nYear, CompID);
                DashRasyoMizan.GetDashOzetMali(nYear, CompID);

            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = CompID;
                lg.CsvID = nYear;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                return Json(ex.ToString());
            }
             
   



        }

        [RequestFormLimits(MultipartBodyLengthLimit = 9509715200)]
        [RequestSizeLimit(9509715200)]
        public JsonResult moodUploadOneProcess(XMlook pageIndex)
        {

            var file = pageIndex.file;
            string filemonth = pageIndex.Caption.Split('_')[0];
            string fileyear = pageIndex.Caption.Split('_')[1]; 
            //string flastmonth = pageIndex.Caption.Split('_')[2];
            long UserID = Int64.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));
            //bool lastmonthchk = filemonth == flastmonth ? true : false;

            try
            {
                string retval = "ok";

                int fyear = Convert.ToInt32(fileyear);

                int fmonth = Convert.ToInt32(filemonth);
                int xmlid = TBLXml.GetComapnyIDByMonth(comp.ID, fmonth, fyear);
                Data.SetOpener(xmlid, filemonth, false);

                Data dtx = new Data();

                dtx.SetHataLast(xmlid);

                dtx.SetHataLastz(xmlid);


                dtx.SetHataLastza(comp.ID, fyear);
                List<DashBilancoView> nRequestList = DashBilancoViewMain.getList(fyear, comp.ID);
                var tlist = Data.SetBilancoFromList(nRequestList, comp.ID, fyear);
                Data.RESET_DashBilancoView(fyear, comp.ID);
                Data.InsertBilnco(tlist);
                List<DashBilancoView> nRequestListRvn = DashGelirTablosuViewMain.getList(fyear, comp.ID);
                var tlistRvn = Data.SetBilancoFromList(nRequestListRvn, comp.ID, fyear);
                Data.RESET_REVENUEView(fyear, comp.ID);
                var WCapitalViez = DashWCapitalViewMain.getList(fyear, comp.ID);
                var WCapitalVie = Data.SetBilancoFromList(WCapitalViez, comp.ID, fyear);
                var nLiqudity = DashLikiditeViewMain.getList(fyear, comp.ID);
                var WLiqudity = Data.SetBilancoFromList(nLiqudity, comp.ID, fyear);
                Data.InsertLiquidity(WLiqudity);
                Data.InsertWCapital(WCapitalVie);
                Data.InsertRvn(tlistRvn);
                DashRasyo.GetDashRasyoAnaliz(fyear, comp.ID);
                DashRasyo.GetDashLikiditeRiskTrend(fyear, comp.ID);
                DashRasyo.GetDashOzetMali(fyear, comp.ID, Convert.ToInt32(filemonth));
                MainDash.Get_DatabyErrorV1(fyear, comp.ID, Convert.ToInt32(filemonth));
                return Json(retval);
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = comp.ID;
                lg.CsvID = 7777;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;
                return Json("nok");

            }
             
        }
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 9509715200)]
        [RequestSizeLimit(9509715200)]
        public async Task<JsonResult> moodUploadOne(XMlook pageIndex)
        {
            try
            {

                var file = pageIndex.file;
                string filemonth = pageIndex.Caption.Split('_')[0];
                string fileyear = pageIndex.Caption.Split('_')[1]; 
                //string flastmonth = pageIndex.Caption.Split('_')[2];
                string filePath = string.Empty;
                string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                List<string> nlistZipurl = new List<string>();
                Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));
                string orjinalname = file[0].FileName;
                bool IsZip = false;
                if (file != null && file.Count > 0)
                {
                    string ext = System.IO.Path.GetExtension(file[0].FileName);
                    if (ext.ToLower().Contains("zip"))
                    {
                        IsZip = true;
                    }
                }
                else
                {
                    return Json("nok");
                }

                string pathToXmlFile = string.Empty;
                if (IsZip)
                {
                    foreach (var item in file)
                    {
                        filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".zip");
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await item.CopyToAsync(fileStream).ConfigureAwait(false);
                        }
                        nlistZipurl.Add(filePath);
                    }
                }
                else
                {
                    foreach (var item in file)
                    {
                        filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".xml");
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await item.CopyToAsync(fileStream).ConfigureAwait(false);
                        }
                        CopyContentsUntilNull(filePath);
                        nlistZipurl.Add(filePath);
                    }
                }


                pathToXmlFile = uploads;


                long UserID = Int64.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));


                string retval = XmlChecker.SapEntegratorSet(IsZip, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname);


                return Json(retval);
            }
            catch (Exception ex)
            {
                try
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = Convert.ToInt32(pageIndex.ide);
                    lg.CsvID = 7777;
                    lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                    var chk = ex;
                }
                catch (Exception)
                {

                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = 0;
                    lg.CsvID = 7777;
                    lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                    var chk = ex;
                }

                return Json("nok");

            }





        }
        [RequestFormLimits(MultipartBodyLengthLimit = 9509715200)]
        [RequestSizeLimit(9509715200)]
        public async Task<JsonResult> moodUploadOneUpdate(XMlook pageIndex)
        {




            try
            {
                var file = pageIndex.file;
                string filemonth = pageIndex.Caption.Split('_')[0];
                string fileyear = pageIndex.Caption.Split('_')[1];
                //string flastmonth = pageIndex.Caption.Split('_')[2];
                string orjinalname = file[0].FileName;
                string filePath = string.Empty;
                string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                List<string> nlistZipurl = new List<string>();
                Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));

                bool IsZip = false;
                if (file != null && file.Count > 0)
                {
                    string ext = System.IO.Path.GetExtension(file[0].FileName);
                    if (ext.ToLower().Contains("zip"))
                    {
                        IsZip = true;
                    }
                }
                else
                {
                    return Json("nok");
                }


                string pathToXmlFile = string.Empty;

                if (IsZip)
                {
                    foreach (var item in file)
                    {
                        filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".zip");
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await item.CopyToAsync(fileStream).ConfigureAwait(false);
                        }
                        nlistZipurl.Add(filePath);
                    }
                }
                else
                {
                    foreach (var item in file)
                    {
                        filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".xml");
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await item.CopyToAsync(fileStream).ConfigureAwait(false);
                        }
                        CopyContentsUntilNull(filePath);
                        nlistZipurl.Add(filePath);
                    }
                }

                pathToXmlFile = uploads;


                long UserID = Int64.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                string retval = XmlChecker.SapEntegratorSetUpdate(IsZip, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname);


                return Json(retval);
            }
            catch (Exception ex)
            {

                try
                {
                    Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = comp.ID;
                    lg.CsvID = 7777;
                    lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                    var chk = ex;
                    return Json("nok");
                }
                catch (Exception)
                {

                    ERRLOG lgt = new ERRLOG();
                    lgt.CompanyID = 0;
                    lgt.CsvID = 7777;
                    lgt.ERLOG = ex.ToString(); lgt.Save_AppLogs();
                    return Json("nok");
                }


            }





        }
                                                      
        [RequestFormLimits(MultipartBodyLengthLimit = 9509715200)]
        [RequestSizeLimit(9509715200)]
        public async Task<JsonResult> moodUploadOneNew(XMlook pageIndex)
        { 
            try
            {
                String wwayusrl = @"C:\inetpub\vhosts\fincheckup.ai\apizen.fincheckup.ai\content";
                var file = pageIndex.file;
                string filemonth = pageIndex.Caption.Split('_')[0];
                string fileyear = pageIndex.Caption.Split('_')[1];
                //string flastmonth = pageIndex.Caption.Split('_')[2];
                string orjinalname = file[0].FileName;
                string filePath = string.Empty;
                string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                List<string> nlistZipurl = new List<string>();
                List<string> nlistFilename = new List<string>();
                Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));

                string uploadsNew = Path.Combine(wwayusrl, comp.TaxID.ToString());


                bool exists = System.IO.Directory.Exists(uploadsNew);

                if (!exists)
                    System.IO.Directory.CreateDirectory(uploadsNew);
                bool IsZip = false;
                if (file != null && file.Count > 0)
                {
                    string ext = System.IO.Path.GetExtension(file[0].FileName);
                    if (ext.ToLower().Contains("zip"))
                    {
                        IsZip = true;
                    }
                }
                else
                {
                    return Json("nok");
                }


                string pathToXmlFile = string.Empty;

                if (IsZip)
                {
                    foreach (var item in file)
                    {
                        filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".zip");
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await item.CopyToAsync(fileStream).ConfigureAwait(false);
                        }
                        nlistZipurl.Add(filePath);
                        nlistFilename.Add(item.FileName); 

                        string uploadsNew1 = Path.Combine(uploadsNew, Path.GetFileName(item.FileName));
                        if (System.IO.File.Exists(uploadsNew1))
                        {
                            System.IO.File.Delete(uploadsNew1);
                        }
                        System.IO.File.Copy(filePath, uploadsNew1);
                    }
                }
                else
                {
                    foreach (var item in file)
                    {
                        filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".xml");
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await item.CopyToAsync(fileStream).ConfigureAwait(false);
                        }
                        CopyContentsUntilNull(filePath);
                        nlistFilename.Add(item.FileName);
                        nlistZipurl.Add(filePath);
                        string uploadsNew1 = Path.Combine(uploadsNew, Path.GetFileName(item.FileName));
                        if (System.IO.File.Exists(uploadsNew1))
                        {
                            System.IO.File.Delete(uploadsNew1);
                        }

                        System.IO.File.Copy(filePath, uploadsNew1);
                    }
                }

                pathToXmlFile = uploads;


                long UserID = Int64.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

             
                foreach (var item in nlistFilename)
                {
                     
                    var tbmfolderfile = new TBLXmlFolderFile(item, comp.ID,Convert.ToInt32(fileyear), Convert.ToByte(filemonth), 0,true);
                    tbmfolderfile.Save_TBLXmlFolderFile();
                }

                return Json("ok");
            }
            catch (Exception ex)
            {

                try
                {
                    Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = comp.ID;
                    lg.CsvID = 7777;
                    lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                    var chk = ex;
                    return Json("nok");
                }
                catch (Exception)
                {

                    ERRLOG lgt = new ERRLOG();
                    lgt.CompanyID = 0;
                    lgt.CsvID = 7777;
                    lgt.ERLOG = ex.ToString(); lgt.Save_AppLogs();
                    return Json("nok");
                }


            }





        }
        [RequestFormLimits(MultipartBodyLengthLimit = 9509715200)]
        [RequestSizeLimit(9509715200)]
        public JsonResult moodUploadOneGoOn(XMlook pageIndex)
        {

            var file = pageIndex.file;
            string filemonth = pageIndex.Caption.Split('_')[0];
            string fileyear = pageIndex.Caption.Split('_')[1];

            List<string> nlistZipurl = new List<string>();
            Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));

            long UserID = Int64.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            try
            {
                string retval = XmlChecker.SapEntegratorSetUpon(comp.ID, filemonth, fileyear, Convert.ToInt32(pageIndex.idexml));


                return Json(retval);
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = comp.ID;
                lg.CsvID = 7777;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;
                return Json("nok");

            }

        }
        private string ConvertDatum(string datta)
        {
            string[] listo = datta.Substring(0, 10).Replace("-", ".").Replace("/", ".").Split('.');
            return listo[0] + "." + listo[2] + '.' + listo[1];
        }
        [RequestFormLimits(MultipartBodyLengthLimit = 9509715200)]
        [RequestSizeLimit(9509715200)]
        public async Task<JsonResult> moodUploadUpdate(XMlook pageIndex)
        {


            var file = pageIndex.file;

            string orjinalname = file[0].FileName;
            string filemonth = pageIndex.Caption.Split('_')[0];
            string fileyear = pageIndex.Caption.Split('_')[1];
            //string flastmonth = pageIndex.Caption.Split('_')[2];
            string filePath = string.Empty;
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            List<string> nlistZipurl = new List<string>();
            Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));

            bool IsZip = false;
            if (file != null && file.Count > 0)
            {
                string ext = System.IO.Path.GetExtension(file[0].FileName);
                if (ext.ToLower().Contains("zip"))
                {
                    IsZip = true;
                }
            }
            else
            {
                return Json("nok");
            }
            string pathToXmlFile = string.Empty;

            if (IsZip)
            {

                foreach (var item in file)
                {
                    filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".zip");
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream).ConfigureAwait(false);
                    }
                    nlistZipurl.Add(filePath);
                }

                pathToXmlFile = uploads;
            }
            else
            {

                foreach (var item in file)
                {
                    filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".xml");
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream).ConfigureAwait(false);
                    }
                    CopyContentsUntilNull(filePath);
                    nlistZipurl.Add(filePath);
                }

                pathToXmlFile = filePath;


            }

            long UserID = Int64.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            //bool lastmonthchk = filemonth == flastmonth ? true : false;
            var cmlCheckList = await _svc.GetAllAsync();

            try
            {
                string retval =  await XmlChecker.XmlCheck(IsZip, 1, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname, false, cmlCheckList.ToList());
                if (retval != "nok")
                {
                    int fyear = Convert.ToInt32(fileyear);



                    //List<DashBilancoView> nRequestList = DashBilancoViewMain.getList(fyear, comp.ID);
                    //var tlist = Data.SetBilancoFromList(nRequestList, comp.ID, fyear);
                    //Data.RESET_DashBilancoView(fyear, comp.ID);
                    //Data.InsertBilnco(tlist);
                    //List<DashBilancoView> nRequestListRvn = DashGelirTablosuViewMain.getList(fyear, comp.ID);
                    //var tlistRvn = Data.SetBilancoFromList(nRequestListRvn, comp.ID, fyear);
                    //Data.RESET_REVENUEView(fyear, comp.ID);
                    //var WCapitalViez = DashWCapitalViewMain.getList(fyear, comp.ID);
                    //var WCapitalVie = Data.SetBilancoFromList(WCapitalViez, comp.ID, fyear);
                    //var nLiqudity = DashLikiditeViewMain.getList(fyear, comp.ID);
                    //var WLiqudity = Data.SetBilancoFromList(nLiqudity, comp.ID, fyear);
                    //Data.InsertLiquidity(WLiqudity);
                    //Data.InsertWCapital(WCapitalVie);
                    //Data.InsertRvn(tlistRvn);
                    //DashRasyo.GetDashRasyoAnaliz(fyear, comp.ID);
                    //DashRasyo.GetDashLikiditeRiskTrend(fyear, comp.ID);
                    //DashRasyo.GetDashOzetMali(fyear, comp.ID, Convert.ToInt32(filemonth));
                    //MainDash.Get_DatabyErrorV1(fyear, comp.ID, Convert.ToInt32(filemonth));
                }

                return Json(retval);
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = comp.ID;
                lg.CsvID = 7777;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;
                return Json("nok");
            }


        }


        public JsonResult moodUpdateTax(XMlookUpdate pageIndex)
        {
            if (!ModelState.IsValid)
            {

                return Json("nok");
            }

            try
            {
                int csvId = MainDash.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);
                ErrorCheckMain.Set_ReportSet(csvId);
            }
            catch (Exception ex)
            {

                return Json("nok_" + ex.ToString());
            }



            return Json("ok");


        }
        public JsonResult moodUpdateReport(XMlookUpdate pageIndex)
        {
            if (!ModelState.IsValid)
            {

                return Json("nok");
            }

            try
            {
                int csvId = MainDash.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);
                ErrorCheckMain.Set_ReportSet(csvId);
            }
            catch (Exception ex)
            {

                return Json("nok_" + ex.ToString());
            }



            return Json("ok");


        }
        private static void CopyContentsUntilNull(string filePath)
        {

            string ctrlChar = "\0";
            var xml = System.IO.File.ReadAllText(filePath);
            var fixedXml = xml.Replace(ctrlChar, "").Replace(((char)0x14).ToString(), "");
            System.IO.File.WriteAllText(filePath, fixedXml);





        }
        public JsonResult moodUpdateBalance(XMlookUpdate pageIndex)
        {
            if (!ModelState.IsValid)
            {

                return Json("nok");
            }

            try
            {
                ReportSetMain.Set_ReportSet(pageIndex.year, pageIndex.companyid);
                // int csvId = MainDash.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);

            }
            catch (Exception ex)
            {

                return Json("nok_" + ex.ToString());
            }



            return Json("ok");


        }
        public JsonResult moodUpdateKonsol(XMlookUpdate pageIndex)
        {
            if (!ModelState.IsValid)
            {

                return Json("nok");
            }

            try
            {
                ReportSetMain.Set_ReportSetKon(pageIndex.year, pageIndex.companyid);
                // int csvId = MainDash.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);

            }
            catch (Exception ex)
            {

                return Json("nok_" + ex.ToString());
            }



            return Json("ok");


        }

        public JsonResult moodUpdateKonsolMizan(XMlookUpdate pageIndex)
        {
            if (!ModelState.IsValid)
            {

                return Json("nok");
            }

            try
            {
                ReportSetMain.Set_ReportSetKonM(pageIndex.year, pageIndex.companyid);
                // int csvId = MainDash.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);

            }
            catch (Exception ex)
            {

                return Json("nok_" + ex.ToString());
            }



            return Json("ok");


        }
        public JsonResult moodUpdateAccountCheck(XMlookUpdate pageIndex)
        {
            

            try
            {
                // ReportSetMain.Set_ReportSet(pageIndex.year, pageIndex.companyid);
                int csvId = MainDash.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);

                String dbConnStr = BaseModel.ConnectionString;
                SqlConnection cnn = new SqlConnection(dbConnStr);

                try
                {


                    //  MainStrPro1zA

                    var filelist = TBLXmlFile.Get_TBLXmlIDlist(csvId);
                    foreach (var item in filelist)
                    {
                        cnn = new SqlConnection(dbConnStr);
                        SqlCommand sqlCmd1 = new SqlCommand("setFirst", cnn);
                        sqlCmd1.CommandType = CommandType.StoredProcedure;
                        sqlCmd1.Parameters.AddWithValue("@csvvID", csvId);
                        sqlCmd1.Parameters.AddWithValue("@companyDocumentId", item.ID);
                        sqlCmd1.CommandTimeout = 0;
                        //sqlCmd1.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cnn.Open();
                        object obb = sqlCmd1.ExecuteScalar();
                        cnn.Close();
                        Thread.Sleep(1000);
                    }
                    
                    DashOzetMali.SetErrored(pageIndex.year, pageIndex.companyid, pageIndex.month);
                    MainDash.Get_DatabyErrorV1(pageIndex.year, pageIndex.companyid, pageIndex.month);
                    List<DataViewer> ncheck = new List<DataViewer>();
                    List<DataViewer> ncheckzone = new List<DataViewer>();
                    foreach (var item in filelist)
                    {
                        ncheck = MainDash.DataViewerMainSourceT(pageIndex.year, pageIndex.companyid, pageIndex.month,item.ID);
                        ncheckzone.AddRange(ncheck);
                        Thread.Sleep(1000);
                    }
                    List<DataViewer> ncheckMain = ErrorCheckMain.Get_ReportSetAll(pageIndex.year, pageIndex.companyid, pageIndex.month);
                    ncheckzone.AddRange(ncheckMain);

                    if (ncheckzone.Count < 1)
                    {
                        return new JsonResult("yok");
                    }
                }
                catch (Exception ex)
                {

                    var chk = ex;
                }
                finally
                {
               
                }


            }
            catch (Exception ex)
            {

                return Json("nok_" + ex.ToString());
            }



            return Json("ok");


        }
        public JsonResult moodUpdateReportmain(XMlookUpdate pageIndex)
        {
            if (!ModelState.IsValid)
            {

                return Json("nok");
            }

            try
            {
                ReportSetMain.Set_ReportSetMain(pageIndex.year, pageIndex.companyid);
                // int csvId = MainDash.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);

            }
            catch (Exception ex)
            {

                return Json("nok_" + ex.ToString());
            }



            return Json("ok");


        }


        public JsonResult moodUpdateReportmainQnb(XMlookUpdate pageIndex)
        {
            if (!ModelState.IsValid)
            {

                return Json("nok");
            }

            try
            {

                List<DashBilancoViewQnb> nRequestList = DashBilancoViewMainQnb.getList(pageIndex.year, pageIndex.companyid);
                var tlist = Data.SetBilancoFromListQnb(nRequestList, pageIndex.companyid, pageIndex.year, 1);

                List<DashBilancoViewQnb> nRequestLista = DashBilancoViewMainQnb.getListToplam(pageIndex.year, pageIndex.companyid);
                var tlista = Data.SetBilancoFromListQnb(nRequestLista, pageIndex.companyid, pageIndex.year, 2);

                List<DashBilancoViewQnb> nRequestList1 = DashBilancoViewMainQnb.getListA(pageIndex.year, pageIndex.companyid);
                var tlist1 = Data.SetBilancoFromListQnb(nRequestList1, pageIndex.companyid, pageIndex.year, 3);

                List<DashBilancoViewQnb> nRequestList1a = DashBilancoViewMainQnb.getListAToplam(pageIndex.year, pageIndex.companyid);
                var tlist1a = Data.SetBilancoFromListQnb(nRequestList1a, pageIndex.companyid, pageIndex.year, 4);

                List<DashBilancoViewQnb> nRequestList3 = DashBilancoViewMainQnb.getListB(pageIndex.year, pageIndex.companyid);
                var tlist3 = Data.SetBilancoFromListQnb(nRequestList3, pageIndex.companyid, pageIndex.year, 5);

                List<DashBilancoViewQnb> nRequestList3a = DashBilancoViewMainQnb.getListBToplam(pageIndex.year, pageIndex.companyid);
                var tlist3a = Data.SetBilancoFromListQnb(nRequestList3a, pageIndex.companyid, pageIndex.year, 6);

                List<DashBilancoViewQnb> nRequestList5 = DashBilancoViewMainQnb.getListC(pageIndex.year, pageIndex.companyid);
                var tlist5 = Data.SetBilancoFromListQnb(nRequestList5, pageIndex.companyid, pageIndex.year, 7);

                List<DashBilancoViewQnb> nRequestList5a = DashBilancoViewMainQnb.getListCToplam(pageIndex.year, pageIndex.companyid);
                var tlist5a = Data.SetBilancoFromListQnb(nRequestList5a, pageIndex.companyid, pageIndex.year, 8);

                List<DashBilancoViewQnb> nRequestList7 = DashBilancoViewMainQnb.getListD(pageIndex.year, pageIndex.companyid);
                var tlist7 = Data.SetBilancoFromListQnb(nRequestList7, pageIndex.companyid, pageIndex.year, 9);

                List<DashBilancoViewQnb> nRequestList7a = DashBilancoViewMainQnb.getListDToplam(pageIndex.year, pageIndex.companyid);
                var tlist7a = Data.SetBilancoFromListQnb(nRequestList7a, pageIndex.companyid, pageIndex.year, 11);


                tlist.AddRange(tlista);
                tlist.AddRange(tlist1);
                tlist.AddRange(tlist1a);
                tlist.AddRange(tlist3);
                tlist.AddRange(tlist3a);
                tlist.AddRange(tlist5);
                tlist.AddRange(tlist5a);
                tlist.AddRange(tlist7);
                tlist.AddRange(tlist7a);
                Data.InsertBilncoQnb(tlist);



                List<DashBilancoViewQnb> nRequestList21 = DashBilancoViewMainQnbGelir.getList(pageIndex.year, pageIndex.companyid);
                var tlist21 = Data.SetBilancoFromListQnb(nRequestList21, pageIndex.companyid, pageIndex.year, 13);

                List<DashBilancoViewQnb> nRequestList21a = DashBilancoViewMainQnbGelir.getListA(pageIndex.year, pageIndex.companyid);
                var tlist21a = Data.SetBilancoFromListQnb(nRequestList21a, pageIndex.companyid, pageIndex.year, 15);

                List<DashBilancoViewQnb> nRequestList21b = DashBilancoViewMainQnbGelir.getListB(pageIndex.year, pageIndex.companyid);
                var tlist21b = Data.SetBilancoFromListQnb(nRequestList21b, pageIndex.companyid, pageIndex.year, 17);

                List<DashBilancoViewQnb> nRequestList21c = DashBilancoViewMainQnbGelir.getListC(pageIndex.year, pageIndex.companyid);
                var tlist21c = Data.SetBilancoFromListQnb(nRequestList21c, pageIndex.companyid, pageIndex.year, 19);

                List<DashBilancoViewQnb> nRequestList21d = DashBilancoViewMainQnbGelir.getListD(pageIndex.year, pageIndex.companyid);
                var tlist21d = Data.SetBilancoFromListQnb(nRequestList21d, pageIndex.companyid, pageIndex.year, 21);

                List<DashBilancoViewQnb> nRequestList21e = DashBilancoViewMainQnbGelir.getListE(pageIndex.year, pageIndex.companyid);
                var tlist21e = Data.SetBilancoFromListQnb(nRequestList21e, pageIndex.companyid, pageIndex.year, 23);


                List<DashBilancoViewQnb> nRequestList21f = DashBilancoViewMainQnbGelir.getListF(pageIndex.year, pageIndex.companyid);
                var tlist21f = Data.SetBilancoFromListQnb(nRequestList21f, pageIndex.companyid, pageIndex.year, 25);

                List<DashBilancoViewQnb> nRequestList21g = DashBilancoViewMainQnbGelir.getListG(pageIndex.year, pageIndex.companyid);
                var tlist21g = Data.SetBilancoFromListQnb(nRequestList21g, pageIndex.companyid, pageIndex.year, 27);

                List<DashBilancoViewQnb> nRequestList21h = DashBilancoViewMainQnbGelir.getListH(pageIndex.year, pageIndex.companyid);
                var tlist21h = Data.SetBilancoFromListQnb(nRequestList21h, pageIndex.companyid, pageIndex.year, 29);

                List<DashBilancoViewQnb> nRequestList21i = DashBilancoViewMainQnbGelir.getListI(pageIndex.year, pageIndex.companyid);
                var tlist21i = Data.SetBilancoFromListQnb(nRequestList21i, pageIndex.companyid, pageIndex.year, 31);

                tlist21.AddRange(tlist21a);
                tlist21.AddRange(tlist21b);
                tlist21.AddRange(tlist21c);
                tlist21.AddRange(tlist21d);
                tlist21.AddRange(tlist21e);
                tlist21.AddRange(tlist21f);
                tlist21.AddRange(tlist21g);
                tlist21.AddRange(tlist21h);
                tlist21.AddRange(tlist21i);
                Data.InsertBilncoQnbGelir(tlist21);
                DashBilancoViewMainQnbGelir.setListSektor(pageIndex.year, pageIndex.companyid);
                //ReportSetMain.Set_ReportSetMain(pageIndex.year, pageIndex.companyid);
                // int csvId = MainDash.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);

            }
            catch (Exception ex)
            {

                return Json("nok_" + ex.ToString());
            }



            return Json("ok");


        }
        public JsonResult GetHtml([FromBody] int pageIndex)
        {
            bulten blt = bulten.Get_bulten(Convert.ToInt32(pageIndex));
            if (blt == null)
            {
                blt = bulten.Get_bulten(1);
            }
            return Json(blt);
        }

        [RequestFormLimits(MultipartBodyLengthLimit = 9509715200)]
        [RequestSizeLimit(9509715200)]
        public async Task<JsonResult> moodUploadUpdateChk(XMlook pageIndex)
        {


            var file = pageIndex.file;

            string orjinalname = file[0].FileName;
            string filemonth = pageIndex.Caption.Split('_')[0];
            string fileyear = pageIndex.Caption.Split('_')[1];
            //string flastmonth = pageIndex.Caption.Split('_')[2];
            string filePath = string.Empty;
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            List<string> nlistZipurl = new List<string>();
            Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));

            bool IsZip = false;
            if (file != null && file.Count > 0)
            {
                string ext = System.IO.Path.GetExtension(file[0].FileName);
                if (ext.ToLower().Contains("zip"))
                {
                    IsZip = true;
                }
            }
            else
            {
                return Json("nok");
            }
            string pathToXmlFile = string.Empty;

            if (IsZip)
            {

                foreach (var item in file)
                {
                    filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".zip");
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream).ConfigureAwait(false);
                    }
                    nlistZipurl.Add(filePath);
                }

                pathToXmlFile = uploads;
            }
            else
            {

                foreach (var item in file)
                {
                    filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".xml");
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream).ConfigureAwait(false);
                    }
                    CopyContentsUntilNull(filePath);
                    nlistZipurl.Add(filePath);
                }

                pathToXmlFile = filePath;


            }

            long UserID = Int64.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            //bool lastmonthchk = filemonth == flastmonth ? true : false;


            try
            {
                string retval = await XmlChecker.XmlCheckChk(IsZip, 1, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname, false);
                if (retval != "nok")
                {
                    int fyear = Convert.ToInt32(fileyear);



                    List<DashBilancoView> nRequestList = DashBilancoViewMain.getList(fyear, comp.ID);
                    var tlist = Data.SetBilancoFromList(nRequestList, comp.ID, fyear);
                    Data.RESET_DashBilancoView(fyear, comp.ID);
                    Data.InsertBilnco(tlist);
                    List<DashBilancoView> nRequestListRvn = DashGelirTablosuViewMain.getList(fyear, comp.ID);
                    var tlistRvn = Data.SetBilancoFromList(nRequestListRvn, comp.ID, fyear);
                    Data.RESET_REVENUEView(fyear, comp.ID);
                    var WCapitalViez = DashWCapitalViewMain.getList(fyear, comp.ID);
                    var WCapitalVie = Data.SetBilancoFromList(WCapitalViez, comp.ID, fyear);
                    var nLiqudity = DashLikiditeViewMain.getList(fyear, comp.ID);
                    var WLiqudity = Data.SetBilancoFromList(nLiqudity, comp.ID, fyear);
                    Data.InsertLiquidity(WLiqudity);
                    Data.InsertWCapital(WCapitalVie);
                    Data.InsertRvn(tlistRvn);
                    DashRasyo.GetDashRasyoAnaliz(fyear, comp.ID);
                    DashRasyo.GetDashLikiditeRiskTrend(fyear, comp.ID);
                    DashRasyo.GetDashOzetMali(fyear, comp.ID, Convert.ToInt32(filemonth));
                    MainDash.Get_DatabyErrorV1(fyear, comp.ID, Convert.ToInt32(filemonth));
                }

                return Json(retval);
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = comp.ID;
                lg.CsvID = 7777;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;
                return Json("nok");
            }


        }
        private double ConvertDec(string datta)
        {
            double numvalue;
            bool isNumber = double.TryParse(datta, out numvalue);


            if (isNumber)
            {
                return numvalue;
            }
            else
            {
                return 0;
            }
        }
    }
}

// MOOD UPLOAD 
//defter result = new defter();
//XmlSerializer serializerz = new XmlSerializer(typeof(defter)); 

//using (FileStream fileStream = new FileStream(pathToXmlFile, FileMode.Open))
//{
//    result = (defter)serializerz.Deserialize(fileStream);
//}


//TBLXml ncs = new TBLXml();
//ncs.CompanyID = 1;
//ncs.CompanyName =" test";
//ncs.CreatedDate =DateTime.Now;
//ncs.DocumentDate = DateTime.Now;
// ncs.Save_TBLXml();
//var ttest = Dataz.SetValueFromXMlIsbank(result, ncs.ID);
//string mMonth = ttest[0].EndDate.Month.ToString();
//string myear = ttest[0].EndDate.Year.ToString();
//ncs.Year = ttest[0].EndDate.Year;
//ncs.DocumentDate = ttest[0].EndDate;
//ncs.Update_TBLXml();


//defter result = new defter();
//XmlSerializer serializerz = new XmlSerializer(typeof(defter));

//using (FileStream fileStream = new FileStream(pathToXmlFile, FileMode.Open))
//{
//    result = (defter)serializerz.Deserialize(fileStream);
//}


//string mMonth = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Month.ToString();
//string myear = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Year.ToString();




//if (mMonth == filemonth && myear== fileyear)
//{
//    TBLXml ncs = new TBLXml();
//    ncs.CompanyID = 3; 
//    ncs.CreatedDate = DateTime.Now;
//    ncs.DocumentDate = DateTime.Now;
//    ncs.Save_TBLXml();
//    var ttest = Dataz.SetValueFromXMluyumsoft(result, ncs.ID);

//    ncs.Year = ttest[0].EndDate.Year;
//    ncs.DocumentDate = ttest[0].EndDate;
//    ncs.Update_TBLXml();

//    Data dat = new Data();
//    dat.InsertTB(ttest);
//    if (mMonth=="1" || mMonth == "01")
//    {
//        Data.SetOpener(ncs.ID);
//    }
//    Data jjj = new Data();
//    int set1 = jjj.SetFirstZone(ncs.ID);
//    try
//    {


//        while (set1 > 0)
//        {


//            set1 = jjj.SetFirstZone(ncs.ID);
//        }

//        Data dtx = new Data();

//        dtx.SetHataLast(ncs.ID);

//        dtx.SetHataLastz(ncs.ID);


//        dtx.SetHataLastza(Convert.ToInt32(ncs.CompanyID), ttest[0].EndDate.Year);

//        dtx.SetHataLast();
//    }
//    catch (Exception ex)
//    {
//        var chk = ex;
//        throw;
//    }
//    DataViewerErroredCountCsv SetCounteR = MainDash.Get_DatabyErrorbyCsv(ncs.ID);

//    return Json(ncs.ID.ToString()+"_"+ SetCounteR.TotalRow.ToString()+"_"+SetCounteR.EntryErrorCount.ToString());
//}
//else
//{
//    return Json("nok");
//}

// MOOD UPLOAD UPDATE
//var file = pageIndex.file; 
//string filemonth = pageIndex.Caption.Split('_')[0];
//string fileyear = pageIndex.Caption.Split('_')[1];
//string filePath = "";
//string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
//Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));
//List<string> nlistZipurl = new List<string>();
//if (comp.XmlSourceID==5)
//{
//    if (file != null && file.Count > 0)
//    {
//        foreach (var item in file)
//        {
//            filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".zip");

//            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
//            {
//                await item.CopyToAsync(fileStream).ConfigureAwait(false);
//            }
//        }


//        //using (Stream fileStream = new FileStream(filePath, FileMode.Create))
//        //{
//        //    await file.CopyToAsync(fileStream).ConfigureAwait(false);
//        //}
//    }
//}
//else
//{
//    if (file != null && file.Count > 0)
//    {
//        foreach (var item in file)
//        {
//            filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".xml");
//            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
//            {
//                await item.CopyToAsync(fileStream).ConfigureAwait(false);
//            }
//        }
//    }
//}

//var pathToXmlFile = filePath;
//defter result = new defter();
//XmlSerializer serializerz = new XmlSerializer(typeof(defter));

//using (FileStream fileStream = new FileStream(pathToXmlFile, FileMode.Open))
//{
//    result = (defter)serializerz.Deserialize(fileStream);
//}


//string mMonth = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Month.ToString();
//string myear = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Year.ToString();



//if (mMonth == filemonth && myear == fileyear)
//{

//    TBLXml ncs = new TBLXml();
//    ncs.CompanyID = 3; 
//    ncs.CreatedDate = DateTime.Now;
//    ncs.DocumentDate = DateTime.Now;
//    ncs.Save_TBLXml();
//    var ttest = Dataz.SetValueFromXMluyumsoft(result, ncs.ID);
//    ncs.DocumentDate = ttest[0].EndDate;
//    ncs.Year = ttest[0].EndDate.Year;
//    ncs.Update_TBLXml();
//    TBLXml ncs1 = TBLXml.Get_TBLXmlCompany(ncs.CompanyID.ToString()).Where(x => x.DocumentDate.Year == ttest[0].EndDate.Year && x.DocumentDate.Month == ttest[0].EndDate.Month && x.ID != ncs.ID).FirstOrDefault();
//    TBLXml.RESET_TBLXml(ncs1.ID);


//    Data dat = new Data();
//    dat.InsertTB(ttest);
//    if (mMonth == "1" || mMonth == "01")
//    {
//        Data.SetOpener(ncs.ID);
//    }
//    Data jjj = new Data();
//    int set1 = jjj.SetFirstZone(ncs.ID);
//    try
//    {


//        while (set1 > 0)
//        {


//            set1 = jjj.SetFirstZone(ncs.ID);
//        }


//        Data dtx = new Data();

//        dtx.SetHataLast(ncs.ID);

//        dtx.SetHataLastz(ncs.ID);


//        dtx.SetHataLastza(Convert.ToInt32(ncs.CompanyID), ttest[0].EndDate.Year);

//        dtx.SetHataLast();
//    }
//    catch (Exception ex)
//    {
//        var chk = ex;
//        throw;
//    }

//    DataViewerErroredCountCsv SetCounteR = MainDash.Get_DatabyErrorbyCsv(ncs.ID);

//    return Json(ncs.ID.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString());
//}
//else
//{
