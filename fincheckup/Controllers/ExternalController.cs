using DevExpress.Pdf;
using fincheckup.ENTITY;
using fincheckup.Helper;
using fincheckup.Helper.Report;
using fincheckup.Models.DigiForm;
using fincheckup.Models.Hvvn;
using fincheckup.Models.Mizan;
using fincheckup.Models.NKolay;
using fincheckup.Models.NKolay.ENTITY;
using fincheckup.Models.NKolay.ENTITY.Beyanname;
using fincheckup.Models.NKolay.json;
using fincheckup.Models.NKolay.MizanView;
using fincheckup.Models.NKolay.QnbReport;
using fincheckup.Models.NKolay.UploadArea;
using fincheckup.Models.NKolay.ViewM;
using fincheckup.Models.ViewM;
using fincheckup.Models.ViewModel;
using fincheckup.Report;
using fincheckup.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fincheckup.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalController : ControllerBase
    {
        private readonly IWzoneSWRService _svc;

        private readonly IWChkSWRService _svcHk;

        private readonly IWChkWordSWRService _svcHkwrd;

        private readonly IWzonerSWRService _svcer;

        private IWebHostEnvironment _hostingEnvironment;

        private readonly FileUploadService _documentService;

        public ExternalController(IWebHostEnvironment environment, IWzoneSWRService svc, IWChkSWRService svcHk, IWChkWordSWRService svcHkwrd, IWzonerSWRService svcer)
        {
            _hostingEnvironment = environment;
            _svc = svc;
            _svcHk = svcHk;
            _svcHkwrd = svcHkwrd;
            _svcer = svcer;
        }

        string secretKey = "b403cc08-42e7-4a01-bf35-98a65bd5ded5";

        [HttpPost("eledgerupdateupload")]
        [RequestFormLimits(MultipartBodyLengthLimit = 9509715200)]
        [RequestSizeLimit(9509715200)]
        public async Task<JsonResult> moodUploadUpdate(XMlookReq pageIndex)
        {
            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
            var file = pageIndex.file;

            string orjinalname = file[0].FileName;
            string filemonth = pageIndex.Ay_Yil.Split('_')[0];
            string fileyear = pageIndex.Ay_Yil.Split('_')[1];
            ERRLOG lg = new ERRLOG();
            lg.CompanyID = 9;
            lg.CsvID = 3131;
            lg.ERLOG = filemonth + " " + fileyear + " ay-yıl " + orjinalname; lg.Save_AppLogs();
            string filePath = string.Empty;
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            List<string> nlistZipurl = new List<string>();
            Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.compid));

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
                return new JsonResult("nok");
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

            var cmlCheckList = await _svc.GetAllAsync();

            try
            {
                string retval = await XmlChecker.XmlCheck(IsZip, 1, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname, false, cmlCheckList.ToList());
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
                    return new JsonResult("ok");
                }

                return new JsonResult(retval);
            }
            catch (Exception ex)
            {
                  lg = new ERRLOG();
                lg.CompanyID = comp.ID;
                lg.CsvID = 7777;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;
                return new JsonResult("nok");
            }
        }

        [HttpPost("eledgerupload")]
        [RequestFormLimits(MultipartBodyLengthLimit = 9509715200)]
        [RequestSizeLimit(9509715200)]
        public async Task<JsonResult> moodUpload(XMlookReq pageIndex)
        {
            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
            var file = pageIndex.file;
            string orjinalname = file[0].FileName;
            string filemonth = pageIndex.Ay_Yil.Split('_')[0];
            string fileyear = pageIndex.Ay_Yil.Split('_')[1];

            ERRLOG lg = new ERRLOG();
            lg.CompanyID = 9;
            lg.CsvID = 3131;
            lg.ERLOG = filemonth+" "+ fileyear+" ay-yıl "+ orjinalname; lg.Save_AppLogs();

            //string flastmonth = pageIndex.Ay_Yil.Split('_')[2];
            string filePath = string.Empty;
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            List<string> nlistZipurl = new List<string>();
            Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.compid));
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
                return new JsonResult("nok");
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

            var cmlCheckList = await _svc.GetAllAsync();
            var errCheckList = await _svcHk.GetAllAsync();
            var wrdCheckList = await _svcHkwrd.GetAllAsync();
            var wrdErrChkist = await _svcer.GetAllAsync();
            try
            {
                string retval = string.Empty;
                if (TBLXml.GetComapnyIDByMonthCount(comp.ID, Convert.ToInt32(filemonth), Convert.ToInt32(fileyear)) > 0)
                {
                    retval = await XmlChecker.XmlCheck(IsZip, 1, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname, false, cmlCheckList.ToList(), wrdCheckList.ToList(), errCheckList.ToList(), wrdErrChkist.ToList());
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
                    return new JsonResult("ok");
                }

                return new JsonResult(retval);
            }
            catch (Exception ex)
            {
                  lg = new ERRLOG();
                lg.CompanyID = comp.ID;
                lg.CsvID = 7777;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;
                return new JsonResult("nok");

            }
        }

        [HttpPost("eledgermultiuploadnextpart")]
        [RequestFormLimits(MultipartBodyLengthLimit = 9509715200)]
        [RequestSizeLimit(9509715200)]
        public JsonResult moodUploadOneGoOn(XMlookReq pageIndex)
        {
            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));

            var file = pageIndex.file;
            string filemonth = pageIndex.Ay_Yil.Split('_')[0];
            string fileyear = pageIndex.Ay_Yil.Split('_')[1];

            List<string> nlistZipurl = new List<string>();
            Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.compid));

            try
            {
                string retval = XmlChecker.SapEntegratorSetUpon(comp.ID, filemonth, fileyear, Convert.ToInt32(pageIndex.eledgercounter));

                return new JsonResult(retval);
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = comp.ID;
                lg.CsvID = 7777;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;
                return new JsonResult("nok");

            }
        }

        [HttpPost("eledgermultiuploadlastpart")]
        [RequestFormLimits(MultipartBodyLengthLimit = 9509715200)]
        [RequestSizeLimit(9509715200)]
        public JsonResult moodUploadOneProcess(XMlookReq pageIndex)
        {
            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));

            var file = pageIndex.file;
            string filemonth = pageIndex.Ay_Yil.Split('_')[0];
            string fileyear = pageIndex.Ay_Yil.Split('_')[1];
            //string flastmonth = pageIndex.Ay_Yil.Split('_')[2];

            Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.compid));
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
                return new JsonResult(retval);
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = comp.ID;
                lg.CsvID = 7777;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;
                return new JsonResult("nok");

            }
        }

        [HttpPost("eledgermultiuploadfirst")]
        [RequestFormLimits(MultipartBodyLengthLimit = 9509715200)]
        [RequestSizeLimit(9509715200)]
        public async Task<JsonResult> moodUploadOne(XMlookReq pageIndex)
        {
            try
            {
                if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                    return new JsonResult(Unauthorized("No Header"));

                if (apiKey != secretKey)
                    return new JsonResult(Unauthorized("Invalid key"));

                var file = pageIndex.file;
                string filemonth = pageIndex.Ay_Yil.Split('_')[0];
                string fileyear = pageIndex.Ay_Yil.Split('_')[1];
                //string flastmonth = pageIndex.Ay_Yil.Split('_')[2];
                string filePath = string.Empty;
                string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                List<string> nlistZipurl = new List<string>();
                Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.compid));
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
                    return new JsonResult("nok");
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

                string retval = XmlChecker.SapEntegratorSet(IsZip, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname);

                return new JsonResult(retval);
            }
            catch (Exception ex)
            {
                try
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = Convert.ToInt32(pageIndex.compid);
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

                return new JsonResult("nok");

            }
        }

        [HttpPost("eledgermultiuploadupdatefirst")]
        [RequestFormLimits(MultipartBodyLengthLimit = 9509715200)]
        [RequestSizeLimit(9509715200)]
        public async Task<JsonResult> moodUploadOneUpdate(XMlookReq pageIndex)
        {
            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));

            try
            {
                var file = pageIndex.file;
                string filemonth = pageIndex.Ay_Yil.Split('_')[0];
                string fileyear = pageIndex.Ay_Yil.Split('_')[1];
                //string flastmonth = pageIndex.Ay_Yil.Split('_')[2];
                string orjinalname = file[0].FileName;
                string filePath = string.Empty;
                string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                List<string> nlistZipurl = new List<string>();
                Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.compid));

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
                    return new JsonResult("nok");
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

                string retval = XmlChecker.SapEntegratorSetUpdate(IsZip, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname);

                return new JsonResult(retval);
            }
            catch (Exception ex)
            {

                try
                {
                    Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.compid));
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = comp.ID;
                    lg.CsvID = 7777;
                    lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                    var chk = ex;
                    return new JsonResult("nok");
                }
                catch (Exception)
                {

                    ERRLOG lgt = new ERRLOG();
                    lgt.CompanyID = 0;
                    lgt.CsvID = 7777;
                    lgt.ERLOG = ex.ToString(); lgt.Save_AppLogs();
                    return new JsonResult("nok");
                }

            }
        }

        [HttpPost("eledgerliquidity")]
        public JsonResult Dataeledgerliquidity([FromBody] RequestEledger reg)
        {

            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));

            if (reg.IsForChart)
            {
                List<DashWCapitalShortViewChart> nRequestListViewChart = new List<DashWCapitalShortViewChart>();
                DashBilancoView wwn = DashLikidite.Get_LikiditeORANT(reg.Year, reg.CompanyID).FirstOrDefault();
                nRequestListViewChart = DashWCapitalShortViewList.getListDashWChart(wwn);

                return new JsonResult(nRequestListViewChart);
            }
            else
            {
                List<DashBilancoView> nRequestList = new List<DashBilancoView>();

                var chkkkt = DashLikidite.Get_MainList(reg.Year, reg.CompanyID);
                if (chkkkt.Count < 1)
                {
                    nRequestList = DashLikiditeViewMain.getList(reg.Year, reg.CompanyID);
                }
                else
                {
                    nRequestList = chkkkt;
                }

                return new JsonResult(nRequestList);
            }
        }

        [HttpPost("checksso")]
        public JsonResult DataRequestSso([FromBody] RequestSso reg)
        {

            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));

            HhvnUsers nuser3 = HhvnUsers.GetUserbyGuid(reg.sso);
            if (nuser3 != null)
            {

                var company = Companies.Get_CompanybyUserDefault(nuser3.ID);
                var listXml = TBLXmlFile.Get_UploadedYears(company.ID).ToList();
                var listExcel = TBLXmlFile.Get_UploadedYearsMizan(company.ID).ToList();
                int sourceID = 0;
                SsoReturn nreturn = new SsoReturn();
                if (listExcel.Any())
                {
                    sourceID = 3;
                    nreturn.uploadYears = listExcel;
                }

                if (listXml.Any())
                {
                    sourceID = 1;
                    nreturn.uploadYears = listXml;
                }
                nreturn.QnbUserId = nuser3.qnbUserId;
                nreturn.QnbCompanyId= company.qnbCorporateId;
                nreturn.UserID = nuser3.ID;
                nreturn.UserName = nuser3.FullName;
                nreturn.CompanyID = company.ID;
                nreturn.uploadDocumentType = sourceID;
                nreturn.CompanyName = company.CompanyName;
                return new JsonResult(nreturn);

            }

            return new JsonResult("nok");
        }

        [HttpPost("eledgerworkingcapital")]
        public JsonResult Dataeledgerworkingcapital([FromBody] RequestEledger reg)
        {

            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));

            if (reg.IsForChart)
            {
                DashYearlyResultWorkingCapital chk = ReportDash.Get_Data_WorkingCapital(reg.Year, reg.CompanyID);
                int lastmont = ReportDash.Get_LastMonthYear(reg.Year, reg.CompanyID);
                DashYearlyResultWorkingCapital chk1 = DashYearlyResultWorkingCapital.setProp(lastmont, chk);
                List<DashYearlyResultMain> nRequestListViewChart = DashYearlyResultChart.SetResultMain(chk1, reg.Year);

                return new JsonResult(nRequestListViewChart);
            }
            else
            {
                List<DashBilancoView> nRequestList = DashWCapital.Get_getDataWcapFINAL(reg.Year, reg.CompanyID);

                return new JsonResult(nRequestList);
            }
        }

        [HttpPost("eledgerrasyo")]
        public JsonResult Dataeledgerrasyo([FromBody] RequestEledgerRasyo reg)
        {

            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
            var RasyoAnalizView = new DashYearlyResultChart();
            var RasyoAnaliz = RasyoAnalizMain.RasyoAnalizTOTALFinal(reg.Year, reg.CompanyID);
            RasyoAnalizView.SetResult(RasyoAnaliz, reg.Year);
            if (reg.RasyoSortID == 1)
            {
                return new JsonResult(RasyoAnalizView.nresult.Where(x => x.TypeID == 1));
            }
            else if (reg.RasyoSortID == 3)
            {
                return new JsonResult(RasyoAnalizView.nresult.Where(x => x.TypeID == 2));
            }
            else if (reg.RasyoSortID == 5)
            {
                return new JsonResult(RasyoAnalizView.nresult.Where(x => x.TypeID == 3));
            }
            else if (reg.RasyoSortID == 7)
            {
                var OzetMaliView = new DashYearlyResultChart();
                List<DashYearlyResult> OzetMali = DashOzetMali.OzetMaliFinal(reg.Year, reg.CompanyID);
                OzetMaliView.SetResult(OzetMali, reg.Year);

                return new JsonResult(OzetMali);
            }
            else
            {
                var LikiditeRiskTrendView = new DashYearlyResultChart();
                List<DashYearlyResult> LikiditeRiskTrend = DashLikiditeRiskTrend.LikiditeRiskTrend21Final(reg.Year, reg.CompanyID);
                LikiditeRiskTrendView.SetResult(LikiditeRiskTrend, reg.Year);

                return new JsonResult(LikiditeRiskTrendView.nresult);
            }
        }

        [HttpPost("eledgerdashboard")]
        public JsonResult Dataeledgerdashboard([FromBody] RequestEledgerMain reg)
        {

            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
            YearlyErrorResultView mrequestEntryView;
            IEnumerable<Companies> mreqListCompany;
            IEnumerable<YearlyReportDash> dashEbitMarjin;
            IEnumerable<YearlyReportDash> dashGrossProfit;
            IEnumerable<YearlyReportDash> dashRevenue;
            IEnumerable<YearlyReportDash> dashDonemselKarzarar;
            IEnumerable<DashYearlyResultMain> dashWorkingCapital;
            IEnumerable<YearlyReportDashGraphic> dDashFrossViewMarjBrut;
            DashRep NetEbitMarjin;
            DashRep NetGrossProfit;
            DashRep NetRevenue;
            DashRep NetDonemselKarzarar;
            DashRep NetWorkingCapital;
            DashRep NetGrossProfitGraphic;
            string RetValGross;
            DashBilancoViewMarj dDashBilancoViewMarjBrut;
            DashBilancoViewMarj dDashBilancoViewMarjNet;
            dashGrossProfit = ReportDash.Get_Data_GrossProfit(reg.Year, reg.CompanyID);
            dashRevenue = ReportDash.Get_Data_Revenue(reg.Year, reg.CompanyID);
            dashDonemselKarzarar = ReportDash.Get_Data_DonemselKarzarar(reg.Year, reg.CompanyID);
            dashEbitMarjin = ReportDash.Get_Data_EbitMarjin(reg.Year, reg.CompanyID);
            // dashWorkingCapital = DashYearlyResultChart.SetResultMain(ReportDash.Get_Data_WorkingCapital(CurrentUser.SelectedYear, CompID));
            dDashFrossViewMarjBrut = ReportDash.Get_Data_GrossProfitGraphic(reg.Year, reg.CompanyID);

            DashYearlyResultWorkingCapital chk = ReportDash.Get_Data_WorkingCapital(reg.Year, reg.CompanyID);
            int lastmont = ReportDash.Get_LastMonthYear(reg.Year, reg.CompanyID);
            DashYearlyResultWorkingCapital chk1 = DashYearlyResultWorkingCapital.setProp(lastmont, chk);
            dashWorkingCapital = DashYearlyResultChart.SetResultMain(chk1, reg.Year);

            NetEbitMarjin = ReportDashViewWCap.getRealyVal(dashEbitMarjin);
            NetGrossProfit = ReportDashViewWCap.getRealyVal(dashGrossProfit);
            NetRevenue = ReportDashViewWCap.getRealyVal(dashRevenue);
            NetDonemselKarzarar = ReportDashViewWCap.getRealyVal(dashDonemselKarzarar);
            NetWorkingCapital = ReportDashViewWCap.getRealyValT(dashWorkingCapital);

            NetGrossProfitGraphic = new DashRep();
            NetGrossProfitGraphic.EntryCountTotal = Convert.ToDecimal(NetRevenue.EntryCountTotal) == 0 ? "0" : "% " + String.Format("{0:0.##}", (Convert.ToDecimal(NetGrossProfit.EntryCountTotal) / Convert.ToDecimal(NetRevenue.EntryCountTotal) * 100));
            NetGrossProfitGraphic.EntryCountBefore = Convert.ToDecimal(NetRevenue.EntryCountBefore) == 0 ? "0" : "% " + String.Format("{0:0.##}", (Convert.ToDecimal(NetGrossProfit.EntryCountBefore) / Convert.ToDecimal(NetRevenue.EntryCountBefore) * 100));
            NetGrossProfitGraphic.EntryCountLast = Convert.ToDecimal(NetRevenue.EntryCountLast) == 0 ? "0" : "% " + String.Format("{0:0.##}", (Convert.ToDecimal(NetGrossProfit.EntryCountLast) / Convert.ToDecimal(NetRevenue.EntryCountLast) * 100));

            int YearCount = TBLXml.GetYearByComapnyID(reg.Year);

            dDashBilancoViewMarjBrut = DashBilanco.Get_MAINBrutKarZarar(reg.Year, reg.CompanyID);
            dDashBilancoViewMarjNet = DashBilanco.Get_MAINNetSatis(reg.Year, reg.CompanyID);

            decimal docz = Convert.ToDecimal(NetRevenue.EntryCountTotal);
            decimal doc = Convert.ToDecimal(NetRevenue.EntryCountBefore.Replace(",", ""));
            decimal doc1 = Convert.ToDecimal(NetRevenue.EntryCountLast.Replace(",", ""));

            if (docz == 0) { docz = 1; }
            if (doc == 0) { doc = 1; }
            if (doc1 == 0) { doc1 = 1; }
            if (dDashBilancoViewMarjNet != null)
            {
                decimal valNet = dDashBilancoViewMarjNet.OverViewTotal;
                if (valNet == 0)
                {
                    valNet = 1;
                }

                RetValGross = "% " + String.Format("{0:0.##}", (Convert.ToDecimal(dDashBilancoViewMarjBrut.OverViewTotal) / Convert.ToDecimal(valNet)) * 100);
            }
            else
            {
                RetValGross = "% " + 0;
            }

            List<YearlyReportDashMain> nlist = new List<YearlyReportDashMain>();
            YearlyReportDashMain nYearlyReportDashMain = new YearlyReportDashMain();
            nYearlyReportDashMain.ChartTypeID = 1;
            nYearlyReportDashMain.yearlyReportDash = dashRevenue;
            nYearlyReportDashMain.dashRep = NetRevenue;
            nlist.Add(nYearlyReportDashMain);

            nYearlyReportDashMain = new YearlyReportDashMain();
            nYearlyReportDashMain.ChartTypeID = 3;
            nYearlyReportDashMain.yearlyReportDash = dashGrossProfit;
            nYearlyReportDashMain.dashRep = NetGrossProfit;
            nlist.Add(nYearlyReportDashMain);

            nYearlyReportDashMain = new YearlyReportDashMain();
            nYearlyReportDashMain.ChartTypeID = 5;
            nYearlyReportDashMain.yearlyReportDash = dashEbitMarjin;
            nYearlyReportDashMain.dashRep = NetEbitMarjin;
            nlist.Add(nYearlyReportDashMain);

            nYearlyReportDashMain = new YearlyReportDashMain();
            nYearlyReportDashMain.ChartTypeID = 7;
            nYearlyReportDashMain.yearlyReportDash = getMonthYearValue(dashWorkingCapital);
            nYearlyReportDashMain.dashRep = NetWorkingCapital;
            nlist.Add(nYearlyReportDashMain);

            nYearlyReportDashMain = new YearlyReportDashMain();
            nYearlyReportDashMain.ChartTypeID = 9;
            nYearlyReportDashMain.yearlyReportDash = dashDonemselKarzarar;
            nYearlyReportDashMain.dashRep = NetDonemselKarzarar;
            nlist.Add(nYearlyReportDashMain);

            IEnumerable<YearlyReportDashGraphic> mrequestResult_1 = ReportDash.Get_Data_GrossProfitGraphic(reg.Year, reg.CompanyID);

            nYearlyReportDashMain = new YearlyReportDashMain();
            nYearlyReportDashMain.ChartTypeID = 11;
            nYearlyReportDashMain.yearlyReportDash = getMonthYearValueNew(mrequestResult_1);
            nYearlyReportDashMain.dashRep = new DashRep();
            nlist.Add(nYearlyReportDashMain);

            return new JsonResult(nlist);
        }

        [HttpPost("eledgermizanreportlist")]
        public JsonResult Dataeledgerreportlist([FromBody] RequestMizanMain reg)
        {

            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
            List<CompanyQnbReport> reportList = CompanyQnbReport.Get_CompanyReportList(reg.CompanyID).OrderByDescending(x => x.ID).ToList();
            return new JsonResult(reportList);
        }

        [HttpPost("eledgermizangetreport")]
        public IActionResult Dataeledgergetreport([FromBody] RequestReport reg)
        {

            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
            var newRepName = CompanyQnbReport.Get_CompanyReport(reg.ReportID).ReportName;

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "FileContent", newRepName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var bytes = System.IO.File.ReadAllBytes(filePath);

            return PhysicalFile(filePath, "application/pdf", newRepName);
        }

        [HttpPost("eledgercreatereport")]
        public JsonResult Dataeledgercreatereport([FromBody] RequestCreateReport reg)
        {

            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
            int YearCountchk = TBLXml.GetYearByComapnyID(reg.CompanyID);

            if (YearCountchk < 1)
            {

                return new JsonResult("nok");
            }

            var codde = NaceCode.GetRow_NaceCodes(reg.NaceCode);

            IEnumerable<int> yearCount = Companies.Get_CompanyReportYear(reg.CompanyID);
            List<int> yearCountFull = Companies.Get_CompanyReportYearFull(reg.CompanyID);

            int repcount = CompanyQnbReport.Get_CompanyReportCount(reg.CompanyID);
            var curCompany = Companies.Get_CompanyRow(reg.CompanyID);
            var NewRepName = curCompany.TaxID.ToString() + "-FinReport-" + (repcount + 1).ToString("D4") + ".pdf";
            yearCount = yearCountFull.Except(yearCount);

            var FileDic = "wwwroot\\FileContent\\" + NewRepName;

            string filePathZ = WebHelper.path;
            string FilePath = System.IO.Path.Combine(filePathZ, FileDic);
            CompanyReportView grview = Companies.Get_CompanyReportView(reg.CompanyID);

            yearCountFull.Sort();
            try
            {
                switch (yearCountFull.Count)
                {
                    case 1:
                        FinansRaporu report = ReportCheckZone.getReport(reg.CompanyID, yearCount.ToList(), codde.ID.ToString(), 1111, yearCountFull[0], grview);
                        report.CreateDocument();
                        report.ExportToPdf(FilePath);
                        CompanyQnbReport.Set_Report(reg.CompanyID, 1111, NewRepName); break;
                    case 2:
                        FinansRaporua reporta = ReportCheckZone.getReporta(reg.CompanyID, yearCount.ToList(), codde.ID.ToString(), 1111, yearCountFull, grview);
                        reporta.CreateDocument();
                        reporta.ExportToPdf(FilePath);
                        CompanyQnbReport.Set_Report(reg.CompanyID, 1111, NewRepName); break;
                    case 3:
                        FinansRaporub reportb = ReportCheckZone.getReportb(reg.CompanyID, yearCount.ToList(), codde.ID.ToString(), 1111, yearCountFull, grview);
                        reportb.CreateDocument();
                        reportb.ExportToPdf(FilePath);
                        CompanyQnbReport.Set_Report(reg.CompanyID, 1111, NewRepName); break;
                    case 4:
                        FinansRaporuc reportc = ReportCheckZone.getReportc(reg.CompanyID, yearCount.ToList(), codde.ID.ToString(), 1111, yearCountFull, grview);
                        reportc.CreateDocument();
                        reportc.ExportToPdf(FilePath);
                        CompanyQnbReport.Set_Report(reg.CompanyID, 1111, NewRepName); break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {

                return new JsonResult(ex.Message);
            }

            return new JsonResult("ok");
        }

        public JsonResult moodUploadBeyannameChk(XMlook pageIndex)
        {
            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));

            var file = pageIndex.file;
            List<string> nlistZipurl = new List<string>();
            string uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            long CompID = 0;
            int nYear = 0;

            try
            {

                //CompID = Convert.ToInt64(pageIndex.compid);
                //nYear = pageIndex.id;

            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = CompID;
                lg.CsvID = nYear;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                return new JsonResult(ex.ToString());
            }

            return new JsonResult("ok");
        }

        [HttpPost("beyannamegecici")]
        public async Task<JsonResult> moodUploadBeyannameChkz(XMlookReq pageIndex)
        {
            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
            var file = pageIndex.file;
            string filePath = string.Empty;
            List<string> nlistZipurl = new List<string>();
            string uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            int nmonth = Convert.ToInt32(pageIndex.Ay_Yil.Split('_')[0]);
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

            long CompID = Convert.ToInt64(pageIndex.compid);
            int nYear = Convert.ToInt32(pageIndex.Ay_Yil.Split('_')[1]);
            try
            {

                Companies mainComp = Companies.Get_Company(CompID);
                bool ISGeciciVergi = false;
                bool ISGeciciVergiYeni = false;

                var CHKgROUP = ReadPdfFile(filePath);
                //for (int page = 1; page <= reader.NumberOfPages; page++)
                //{
                //    text  = PdfTextExtractor.GetTextFromPage(reader, page);
                //    nlist.Add(text);
                //}
                //reader.Close();
                string checkvalt = string.Empty;
                string checkval = string.Empty;
                string checkval1 = string.Empty;
                List<ReadPdfPg> nliste = new List<ReadPdfPg>();
                List<ReadPdfPg> nliste1 = new List<ReadPdfPg>();
                bool chekSource = false;
                bool chekSource1 = false;

                ReadPdfPg chhhk = CHKgROUP.Where(x => x.LineContent.Replace("İ", "I").Contains("KURUMLAR VERGISI BEYANNAMES")).FirstOrDefault();
                ReadPdfPg chhhkt = CHKgROUP.Where(x => x.LineContent.Replace("İ", "I").Replace("Ç", "C").Contains("GECICI VERGI BEYANNAMES")).FirstOrDefault();
                ReadPdfPg chhhkt1 = CHKgROUP.Where(x => x.LineContent.Replace("İ", "I").Contains("YILLIK GELIR VERGISI BEYANNAMES")).FirstOrDefault();

                if (chhhk == null && chhhkt == null && chhhkt1 == null)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Hatalı PDF Yükleme  -KURUMLAR VERGİSİ BEYANNAMESİ -GEÇİCİ VERGİ BEYANNAMESİ-YILLIK GELİR VERGİSİ BEYANNAMESİ Olmalı "; lg.Save_AppLogs();
                    return new JsonResult("nok_Hatalı PDF Yükleme - KURUMLAR VERGİSİ BEYANNAMESİ - GEÇİCİ VERGİ BEYANNAMESİ - YILLIK GELİR VERGİSİ BEYANNAMESİ Olmalı");
                }

                if (chhhkt != null)
                {
                    ISGeciciVergi = true;
                }
                ReadPdfPg chhhk1y = new ReadPdfPg();
                List<ReadPdfPg> chhhk1 = CHKgROUP.Where(x => x.LineContent.Contains("Yıl ")).ToList();
                string txt1Yil = chhhk1[0].LineContent.Split(' ')[1].Trim();
                string txt3Yil = "0";
                if (chhhk1.Count > 1)
                {
                    txt3Yil = chhhk1[1].LineContent.Split(' ')[1].Trim();
                }

                string chkyil1 = string.Empty;
                string chkyil3 = string.Empty;

                if (ISGeciciVergi)
                {
                    chhhk1y = CHKgROUP.Where(x => x.LineContent.Contains("Yılı")).FirstOrDefault();
                    var chhhkyilt = CHKgROUP.Where(x => x.CounterNo == chhhk1y.CounterNo + 2).FirstOrDefault();
                    chkyil1 = chhhkyilt.LineContent.Trim();
                    chkyil3 = chhhk1y.LineContent.Split(' ')[chhhk1y.LineContent.Split(' ').Length - 1].Trim();
                    var chhhk1yy = CHKgROUP.Where(x => x.LineContent.Contains("Onay Zamanı ")).FirstOrDefault();
                    txt1Yil = chhhk1yy.LineContent.Replace("Onay Zamanı", string.Empty).Replace(":", string.Empty).Split('-')[0].Trim().Split('.')[2];
                }
                else
                {
                    txt1Yil = chhhk1[0].LineContent.Split(' ')[1].Trim();
                }
                ReadPdfPg chhhk1eposta = CHKgROUP.Where(x => x.LineContent.Contains("E-Posta Adresi")).FirstOrDefault();
                ReadPdfPg chktext = CHKgROUP.Where(x => x.CounterNo == chhhk1eposta.CounterNo + 1).FirstOrDefault();

                if (chktext == null)
                {
                    chktext = new ReadPdfPg();
                }

                string vergino = chktext.LineContent;
                string vergino1 = chktext.LineContent;

                if (vergino.Trim() != mainComp.TaxID.Trim())
                {
                    if (vergino1.Trim() != mainComp.TaxID.Trim())
                    {
                        if (mainComp.State == null)
                        {
                            ERRLOG lg = new ERRLOG();
                            lg.CompanyID = CompID;
                            lg.CsvID = nYear;
                            lg.ERLOG = "Hatalı Vergi No  "; lg.Save_AppLogs();
                            return new JsonResult("nok_Hatalı Vergi No ");

                        }
                        else
                        {

                            if (vergino1.Trim() != mainComp.State.Trim())
                            {
                                if (vergino.Trim() != mainComp.State.Trim())
                                {
                                    ERRLOG lg = new ERRLOG();
                                    lg.CompanyID = CompID;
                                    lg.CsvID = nYear;
                                    lg.ERLOG = "Hatalı Vergi No  "; lg.Save_AppLogs();
                                    return new JsonResult("nok_Hatalı Vergi No ");
                                }
                            }
                        }
                    }
                }

                int result;
                if (chkyil1 != nYear.ToString())
                {

                    if (chkyil3 != nYear.ToString())
                    {

                        if (int.TryParse(txt1Yil, out result) && Convert.ToInt32(txt1Yil) != nYear)
                        {
                            if (int.TryParse(txt3Yil, out result) && Convert.ToInt32(txt3Yil) != nYear)
                            {
                                ERRLOG lg = new ERRLOG();
                                lg.CompanyID = CompID;
                                lg.CsvID = nYear;
                                lg.ERLOG = "Hatalı Yıl  "; lg.Save_AppLogs();
                                return new JsonResult("nok_Hatalı Yıl  ");
                            }
                        }

                    }

                }

                //if (TBLMizan.DeleteComapnyCountMizanByn(CompID, nYear) > 3)
                //{
                //    //ERRLOG lg = new ERRLOG();
                //    //lg.CompanyID = CompID;
                //    //lg.CsvID = nYear;
                //    //lg.ERLOG = "_Yalnızca Kapalı Mizanlarda Beyanname Yüklenebilir  "; lg.Save_AppLogs();
                //    //return new JsonResult("nok_Yalnızca Kapalı Mizanlarda Beyanname Yüklenebilir");
                //}

                TBLMizan ncs = new TBLMizan();
                ncs.CompanyID = CompID;
                ncs.CreatedDate = DateTime.Now;
                ncs.DocumentDate = new DateTime(nYear, 12, 12); ;
                ncs.CsvName = filePath;
                ncs.Year = nYear;
                ncs.MainMonth = nmonth;
                ncs.Save_TBLMizan();
                string nntxt = @"TEK DÜZEN HESAP PLANI AYRINTILI BİLANÇO";

                CHKgROUP = CHKgROUP.Where(x => x.LineContent.Length > 11).ToList();

                for (int i = 0; i < CHKgROUP.Count; i++)
                {
                    if (CHKgROUP[i].LineContent.Contains(nntxt))
                    {
                        ISGeciciVergiYeni = true;
                    }

                    if (CHKgROUP[i].LineContent.Contains("Dönen Varlıklar"))
                    {
                        checkvalt = "I";
                        chekSource = true;
                    }

                    if (CHKgROUP[i].LineContent.Contains("PASİF TOPLAMI"))
                    {
                        CHKgROUP[i].MainID = "I";
                        CHKgROUP[i].SubID = "PASİF TOPLAMI";
                        nliste.Add(CHKgROUP[i]);
                        chekSource = false;
                    }

                    if (chekSource || CHKgROUP[i].LineContent.Contains("Kayda Alınan Emtia Özel Karşılık"))
                    {
                        checkval = CHKgROUP[i].LineContent.Length > 1 ? CHKgROUP[i].LineContent.Replace(". ", string.Empty).Substring(0, 1) : string.Empty;
                        if (!IsNumeric(checkval) && !CHKgROUP[i].LineContent.Contains("GELİR TABLOSU"))
                        {

                            checkval1 = checkval;

                        }

                        CHKgROUP[i].SubID = checkval1;
                        if (CHKgROUP[i].LineContent.Contains("AKTİF TOPLAMI") || CHKgROUP[i].LineContent.Contains("II") || CHKgROUP[i].LineContent.Contains("III") || CHKgROUP[i].LineContent.Contains("IV") || CHKgROUP[i].LineContent.Contains("V."))
                        {
                            if (CHKgROUP[i].LineContent.Contains("III"))
                            {
                                checkvalt = "III";
                            }
                            else if (CHKgROUP[i].LineContent.Contains("II"))
                            {
                                checkvalt = "II";
                            }
                            else if (CHKgROUP[i].LineContent.Contains("IV"))
                            {
                                checkvalt = "IV";
                            }
                            else if (CHKgROUP[i].LineContent.Contains("V"))
                            {
                                checkvalt = "V";
                            }

                            CHKgROUP[i].SubID = RemoveEmpty(CHKgROUP[i].LineContent);
                        }
                        CHKgROUP[i].MainID = checkvalt;
                        nliste.Add(CHKgROUP[i]);
                    }

                    if (ISGeciciVergi)
                    {
                        if (CHKgROUP[i].LineContent != null && CHKgROUP[i].LineContent.Contains("GELİR TABLOSU") && !CHKgROUP[i].LineContent.Contains(nntxt))
                        {

                            chekSource1 = true;
                        }
                    }
                    else
                    {
                        if ((CHKgROUP[i].LineContent != null && CHKgROUP[i].LineContent.Contains("GELİR TABLOSU") && (CHKgROUP[i].LineContent.Trim().Length > 23) == false) && !CHKgROUP[i].LineContent.Contains(nntxt))
                        {

                            chekSource1 = true;
                        }
                    }

                    if (!ISGeciciVergi)
                    {
                        if (CHKgROUP[i].LineContent.Contains("Dönem Net Karı veya Zararı"))
                        {
                            CHKgROUP[i].MainID = "Z";
                            CHKgROUP[i].SubID = "D";
                            CHKgROUP[i].IsRevenue = 1;
                            nliste.Add(CHKgROUP[i]);
                            chekSource1 = false;
                        }
                    }

                    if (chekSource1)
                    {
                        checkval = CHKgROUP[i].LineContent.Length > 1 ? CHKgROUP[i].LineContent.Replace(". ", string.Empty).Substring(0, 1) : string.Empty;
                        if (!IsNumeric(checkval) && !CHKgROUP[i].LineContent.Contains("GELİR TABLOSU") && CHKgROUP[i].LineContent.Contains(".") && !CHKgROUP[i].LineContent.Contains("Enflasyon") && !CHKgROUP[i].LineContent.Contains("Açıklama") && !CHKgROUP[i].LineContent.Contains("Önceki Dönem") && !CHKgROUP[i].LineContent.Contains("Cari Dönem"))
                        {
                            if (!checkval.Contains('('))
                            {
                                checkval1 = checkval;
                            }

                        }
                        CHKgROUP[i].MainID = "Z";
                        CHKgROUP[i].SubID = checkval1;
                        CHKgROUP[i].IsRevenue = 1;
                        nliste.Add(CHKgROUP[i]);
                    }
                    if (CHKgROUP[i].LineContent.Contains("KAR DAĞITIM TABLOSU"))
                    {

                        break;
                    }

                }
                //var chkkGrp2 = BeyannameResult.Get_MizanResult();
                //var tt = CHKgROUP.Where(x => chkkGrp2.Any(z => x.LineContent.Trim().Replace(" ", string.Empty).Contains(z.MainDescription.Trim().Replace(" ", string.Empty))));
                var chkssst = nliste;

                nliste.Select(c => { c.IsGecici = 0; return c; }).ToList();
                //TBLMizan.DeleteComapnyCountMizanByn(CompID, nYear);
                BeyannameChk btnchk = new BeyannameChk();
                BeyannameChk.DeleteChk(CompID, nYear);

                if (ISGeciciVergiYeni)
                {

                    var distinctItems = nliste.Distinct();

                    foreach (var item in distinctItems)
                    {
                        btnchk = new BeyannameChk();
                        btnchk.IsGeciciNew = 1;
                        btnchk.AccountMainDescriptionChk = item.LineContent;
                        btnchk.CompanyID = CompID;
                        btnchk.IsRevenue = item.IsRevenue;
                        btnchk.SubID = item.SubID;
                        btnchk.MainID = item.MainID;
                        btnchk.Year = nYear;
                        btnchk.Save_BeyannameChk();
                        Thread.Sleep(50);
                    }
                }
                else
                {
                    if (ISGeciciVergi)
                    {
                        nliste.Select(c => { c.IsGecici = 1; return c; }).ToList();
                        foreach (var item in nliste)
                        {
                            btnchk = new BeyannameChk();
                            btnchk.IsGecici = item.IsGecici;
                            btnchk.AccountMainDescriptionChk = item.LineContent;
                            btnchk.CompanyID = CompID;
                            btnchk.IsRevenue = item.IsRevenue;
                            btnchk.SubID = item.SubID;
                            btnchk.MainID = item.MainID;
                            btnchk.Year = nYear;
                            btnchk.Save_BeyannameChk();
                            Thread.Sleep(50);
                        }
                    }
                    else
                    {
                        foreach (var item in nliste.Where(x => x.IsRevenue == 1))
                        {
                            btnchk = new BeyannameChk();
                            btnchk.AccountMainDescriptionChk = item.LineContent;
                            btnchk.CompanyID = CompID;
                            btnchk.IsRevenue = item.IsRevenue;
                            btnchk.SubID = item.SubID;
                            btnchk.MainID = item.MainID;
                            btnchk.Year = nYear;
                            btnchk.Save_BeyannameChk();
                            Thread.Sleep(50);
                        }

                    }
                }

                BeyannameChk.DeleteLastChk(CompID, nYear);
                var chkkGrplst = BeyannameChk.Get_BeyannameResultLstChk(CompID, nYear);

                foreach (var item in chkkGrplst)
                {
                    BeyannameChk.LastSetChk(item.ID);
                }

                if (ISGeciciVergiYeni)
                {
                    BeyannameChk.LastFinishedChkNew(CompID, nYear, nmonth);
                    List<DashBilancoViewMizan> nRequestList1 = DashBilancoBeyan.getList(nYear, CompID);
                    var tlist1 = Data.SetBilancoFromListMizan(nRequestList1, CompID, nYear);
                    Data.RESET_DashBilancoViewMizan(nYear, CompID);
                    Data.InsertBilncoMzn(tlist1);

                    List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizan.GetListBYN(nYear, CompID);
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
                    DashRasyoMizan.GetDashOzetMaliByn(nYear, CompID);
                    DashRasyoMizan.GetDashOzetMali1(nYear, CompID);
                }
                else
                {
                    BeyannameChk.LastFinishedChk(CompID, nYear, nmonth);
                    //BeyannameChk.LastFinishedChkNewTestMonth(CompID, nYear, false);
                    List<DashBilancoViewMizan> nRequestList1 = DashBilancoBeyan.getList(nYear, CompID);
                    var tlist1 = Data.SetBilancoFromListMizan(nRequestList1, CompID, nYear);
                    Data.RESET_DashBilancoViewMizan(nYear, CompID);
                    Data.InsertBilncoMzn(tlist1);

                    List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizan.GetListBYN(nYear, CompID);
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
                    DashRasyoMizan.GetDashOzetMali1(nYear, CompID);
                }

                var chk = CHKgROUP;

                if (CHKgROUP.Where(x => x.LineContent.Contains("Amortisman İtfa ve Tükenme")).Count() > 0)
                {

                    var personelvallue = CHKgROUP.Where(x => x.LineContent.Contains("Amortisman İtfa ve Tükenme")).FirstOrDefault();

                    string tpersonelvallue = "";
                    try
                    {
                        tpersonelvallue = personelvallue.LineContent.Substring(personelvallue.LineContent.LastIndexOf("Tükenme"));
                    }
                    catch (Exception)
                    {

                    }

                    if (personelvallue.LineContent.Contains(","))
                    {
                        tpersonelvallue = personelvallue.LineContent.Substring(0, personelvallue.LineContent.IndexOf(','));
                    }
                    string resultzzz = string.Empty;
                    foreach (var c in tpersonelvallue)
                    {
                        int ascii = (int)c;
                        if ((ascii >= 48 && ascii <= 57) || ascii == 44 || ascii == 46)
                            resultzzz += c;
                    }
                    tpersonelvallue = resultzzz;

                    tpersonelvallue = tpersonelvallue.Trim().Replace(".", "");
                    float apersonel = 0;
                    if (tpersonelvallue.Length > 3)
                    {
                        if (tpersonelvallue.EndsWith(","))
                        {
                            //tpersonelvallue.Remove(tpersonelvallue.Length - 1);
                            tpersonelvallue = tpersonelvallue.Substring(0, tpersonelvallue.Length - 1);

                        }

                        if (tpersonelvallue.EndsWith("."))
                        {
                            //tpersonelvallue.Remove(tpersonelvallue.Length - 1);
                            tpersonelvallue = tpersonelvallue.Substring(0, tpersonelvallue.Length - 1);
                        }
                        apersonel = float.Parse(tpersonelvallue);
                    }

                    if (apersonel == 0)
                    {

                        var personelvallue1 = CHKgROUP.Where(x => x.CounterNo == personelvallue.CounterNo + 1).FirstOrDefault();
                        if (personelvallue1 != null)
                        {
                            tpersonelvallue = personelvallue1.LineContent;
                            if (personelvallue1.LineContent.Contains(","))
                            {
                                tpersonelvallue = personelvallue1.LineContent.Substring(0, personelvallue1.LineContent.IndexOf(','));
                            }

                            resultzzz = string.Empty;
                            foreach (var c in tpersonelvallue)
                            {
                                int ascii = (int)c;
                                if ((ascii >= 48 && ascii <= 57) || ascii == 44 || ascii == 46)
                                    resultzzz += c;
                            }
                            tpersonelvallue = resultzzz.Trim();
                            tpersonelvallue = tpersonelvallue.Trim().Replace(".", "");
                            apersonel = 0;
                            if (tpersonelvallue.Length > 3)
                            {
                                if (tpersonelvallue.EndsWith(","))
                                {
                                    //tpersonelvallue.Remove(tpersonelvallue.Length - 1);
                                    tpersonelvallue = tpersonelvallue.Substring(0, tpersonelvallue.Length - 1);

                                }

                                if (tpersonelvallue.EndsWith("."))
                                {
                                    //tpersonelvallue.Remove(tpersonelvallue.Length - 1);
                                    tpersonelvallue = tpersonelvallue.Substring(0, tpersonelvallue.Length - 1);
                                }

                                apersonel = float.Parse(tpersonelvallue);
                            }
                        }

                    }

                    //Data.BayennameInsertAmorrtisman(nYear, CompID, apersonel);
                }

            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = CompID;
                lg.CsvID = nYear;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                return new JsonResult(ex.ToString());
            }

            return new JsonResult("ok_");
        }

        [HttpPost("beyannamekurumsal")]
        public async Task<JsonResult> moodUploadBeyanname(XMlookReq pageIndex)
        {
            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
            string chkTxt = "Enflasyon Düzeltmesi Sonrası";
            bool ISEnflasyon = false;
            //bool ISNoAdmin = true;

            var file = pageIndex.file;
            string filePath = string.Empty;
            List<string> nlistZipurl = new List<string>();
            string uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            int nmonth = Convert.ToInt32(pageIndex.Ay_Yil.Split('_')[0]);
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

            long CompID = Convert.ToInt64(pageIndex.compid);
            int nYear = Convert.ToInt32(pageIndex.Ay_Yil.Split('_')[1]);
            try
            {

                Companies mainComp = Companies.Get_Company(CompID);
                bool ISGeciciVergi = false;

                var CHKgROUP = ReadPdfFile(filePath);
                //for (int page = 1; page <= reader.NumberOfPages; page++)
                //{
                //    text  = PdfTextExtractor.GetTextFromPage(reader, page);
                //    nlist.Add(text);
                //}
                //reader.Close();
                string checkvalt = string.Empty;
                string checkval = string.Empty;
                string checkval1 = string.Empty;
                List<ReadPdfPg> nliste = new List<ReadPdfPg>();
                List<ReadPdfPg> nliste1 = new List<ReadPdfPg>();
                bool chekSource = false;
                bool chekSource1 = false;

                ReadPdfPg chhhk = CHKgROUP.Where(x => x.LineContent.Replace("İ", "I").Contains("KURUMLAR VERGISI BEYANNAMES")).FirstOrDefault();
                ReadPdfPg chhhkt = CHKgROUP.Where(x => x.LineContent.Replace("İ", "I").Replace("Ç", "C").Contains("GECICI VERGI BEYANNAMES")).FirstOrDefault();
                ReadPdfPg chhhkt1 = CHKgROUP.Where(x => x.LineContent.Replace("İ", "I").Contains("YILLIK GELIR VERGISI BEYANNAMES")).FirstOrDefault();

                if (chhhk == null && chhhkt == null && chhhkt1 == null)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Hatalı PDF Yükleme  -KURUMLAR VERGİSİ BEYANNAMESİ -GEÇİCİ VERGİ BEYANNAMESİ-YILLIK GELİR VERGİSİ BEYANNAMESİ Olmalı "; lg.Save_AppLogs();
                    return new JsonResult("nok_Hatalı PDF Yükleme - KURUMLAR VERGİSİ BEYANNAMESİ - GEÇİCİ VERGİ BEYANNAMESİ - YILLIK GELİR VERGİSİ BEYANNAMESİ Olmalı");
                }

                if (chhhkt != null)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Hatalı PDF Yükleme - Yalnızca  KURUMLAR VERGİSİ BEYANNAMESİ Bu alandan Yüklenebilir"; lg.Save_AppLogs();
                    return new JsonResult("nok_Hatalı PDF Yükleme - Yalnızca  KURUMLAR VERGİSİ BEYANNAMESİ Bu alandan Yüklenebilir");

                }
                ReadPdfPg chhhk1y = new ReadPdfPg();
                List<ReadPdfPg> chhhk1 = CHKgROUP.Where(x => x.LineContent.Contains("Yıl ")).ToList();
                ReadPdfPg chhhk1eposta = CHKgROUP.Where(x => x.LineContent.Contains("E-Posta Adresi")).FirstOrDefault();
                ReadPdfPg chktext = CHKgROUP.Where(x => x.CounterNo == chhhk1eposta.CounterNo + 1).FirstOrDefault();

                if (chktext == null)
                {
                    chktext = new ReadPdfPg();
                }

                string vergino = chktext.LineContent;
                string vergino1 = chktext.LineContent;
                string txt1Yil = chhhk1[0].LineContent.Split(' ')[1].Trim();
                string txt3Yil = "0";
                if (chhhk1.Count > 1)
                {
                    txt3Yil = chhhk1[1].LineContent.Split(' ')[1].Trim();
                }
                string chkyil1 = string.Empty;
                string chkyil3 = string.Empty;

                if (vergino.Trim() != mainComp.TaxID.Trim())
                {
                    if (vergino1.Trim() != mainComp.TaxID.Trim())
                    {
                        if (mainComp.State == null)
                        {
                            ERRLOG lg = new ERRLOG();
                            lg.CompanyID = CompID;
                            lg.CsvID = nYear;
                            lg.ERLOG = "Hatalı Vergi No  "; lg.Save_AppLogs();
                            return new JsonResult("nok_Hatalı Vergi No ");

                        }
                        else
                        {

                            if (vergino1.Trim() != mainComp.State.Trim())
                            {
                                if (vergino.Trim() != mainComp.State.Trim())
                                {
                                    ERRLOG lg = new ERRLOG();
                                    lg.CompanyID = CompID;
                                    lg.CsvID = nYear;
                                    lg.ERLOG = "Hatalı Vergi No  "; lg.Save_AppLogs();
                                    return new JsonResult("nok_Hatalı Vergi No ");
                                }
                            }
                        }
                    }
                }

                if (ISGeciciVergi)
                {
                    chhhk1y = CHKgROUP.Where(x => x.LineContent.Contains("Yılı")).FirstOrDefault();
                    var chhhkyilt = CHKgROUP.Where(x => x.CounterNo == chhhk1y.CounterNo + 2).FirstOrDefault();
                    chkyil1 = chhhkyilt.LineContent.Trim();
                    chkyil3 = chhhk1y.LineContent.Split(' ')[chhhk1y.LineContent.Split(' ').Length - 1].Trim();
                    var chhhk1yy = CHKgROUP.Where(x => x.LineContent.Contains("Onay Zamanı ")).FirstOrDefault();
                    txt1Yil = chhhk1yy.LineContent.Replace("Onay Zamanı", string.Empty).Replace(":", string.Empty).Split('-')[0].Trim().Split('.')[2];

                }
                else
                {
                    txt1Yil = chhhk1[0].LineContent.Split(' ')[1].Trim();
                }
                int result;

                if (chkyil1 != nYear.ToString())
                {
                    if (chkyil3 != nYear.ToString())
                    {

                        if (int.TryParse(txt1Yil, out result) && Convert.ToInt32(txt1Yil) != nYear)
                        {
                            if (int.TryParse(txt3Yil, out result) && Convert.ToInt32(txt3Yil) != nYear)
                            {
                                ERRLOG lg = new ERRLOG();
                                lg.CompanyID = CompID;
                                lg.CsvID = nYear;
                                lg.ERLOG = "Hatalı Yıl  "; lg.Save_AppLogs();
                                return new JsonResult("nok_Hatalı Yıl  ");
                            }
                        }

                    }
                }

                TBLMizan ncs = new TBLMizan();
                ncs.CompanyID = CompID;
                ncs.CreatedDate = DateTime.Now;
                ncs.DocumentDate = new DateTime(nYear, 12, 12); ;
                ncs.CsvName = filePath;
                ncs.Year = nYear;
                ncs.MainMonth = nmonth;
                ncs.Save_TBLMizan();

                CHKgROUP = CHKgROUP.Where(x => x.LineContent.Length > 11).ToList();

                for (int i = 0; i < CHKgROUP.Count; i++)
                {
                    if (CHKgROUP[i].LineContent.Contains(chkTxt))
                    {
                        ISEnflasyon = true;
                    }
                    if (CHKgROUP[i].LineContent.Contains("Dönen Varlıklar"))
                    {
                        checkvalt = "I";
                        chekSource = true;
                    }

                    if (CHKgROUP[i].LineContent.Contains("PASİF TOPLAMI"))
                    {
                        CHKgROUP[i].MainID = "I";
                        CHKgROUP[i].SubID = "PASİF TOPLAMI";
                        nliste.Add(CHKgROUP[i]);
                        chekSource = false;
                    }

                    if (chekSource || CHKgROUP[i].LineContent.Contains("Kayda Alınan Emtia Özel Karşılık"))
                    {
                        checkval = CHKgROUP[i].LineContent.Length > 1 ? CHKgROUP[i].LineContent.Replace(". ", string.Empty).Substring(0, 1) : string.Empty;
                        if (!IsNumeric(checkval) && !CHKgROUP[i].LineContent.Contains("GELİR TABLOSU") && CHKgROUP[i].LineContent.Contains(".") && !CHKgROUP[i].LineContent.Contains("Enflasyon") && !CHKgROUP[i].LineContent.Contains("Açıklama") && !CHKgROUP[i].LineContent.Contains("Önceki Dönem") && !CHKgROUP[i].LineContent.Contains("Cari Dönem"))
                        {
                            if (!checkval.Contains('('))
                            {
                                checkval1 = checkval;
                            }

                        }

                        CHKgROUP[i].SubID = checkval1;
                        if (CHKgROUP[i].LineContent.Contains("AKTİF TOPLAMI") || CHKgROUP[i].LineContent.Contains("II") || CHKgROUP[i].LineContent.Contains("III") || CHKgROUP[i].LineContent.Contains("IV") || CHKgROUP[i].LineContent.Contains("V."))
                        {
                            if (CHKgROUP[i].LineContent.Contains("III"))
                            {
                                checkvalt = "III";
                            }
                            else if (CHKgROUP[i].LineContent.Contains("II"))
                            {
                                checkvalt = "II";
                            }
                            else if (CHKgROUP[i].LineContent.Contains("IV"))
                            {
                                checkvalt = "IV";
                            }
                            else if (CHKgROUP[i].LineContent.Contains("V"))
                            {
                                checkvalt = "V";
                            }

                            CHKgROUP[i].SubID = RemoveEmpty(CHKgROUP[i].LineContent);
                        }
                        CHKgROUP[i].MainID = checkvalt;
                        nliste.Add(CHKgROUP[i]);
                    }

                    if (ISGeciciVergi)
                    {
                        if (CHKgROUP[i].LineContent != null && CHKgROUP[i].LineContent.Contains("GELİR TABLOSU"))
                        {

                            chekSource1 = true;
                        }
                    }
                    else
                    {
                        if ((CHKgROUP[i].LineContent != null && CHKgROUP[i].LineContent.Contains("GELİR TABLOSU") && (CHKgROUP[i].LineContent.Trim().Length > 23) == false))
                        {

                            chekSource1 = true;
                        }
                    }

                    if (!ISGeciciVergi)
                    {
                        if (CHKgROUP[i].LineContent.Contains("Dönem Net Karı veya Zararı"))
                        {
                            CHKgROUP[i].MainID = "Z";
                            CHKgROUP[i].SubID = "D";
                            CHKgROUP[i].IsRevenue = 1;
                            nliste.Add(CHKgROUP[i]);
                            chekSource1 = false;
                        }
                    }

                    if (chekSource1)
                    {
                        checkval = CHKgROUP[i].LineContent.Length > 1 ? CHKgROUP[i].LineContent.Replace(". ", string.Empty).Substring(0, 1) : string.Empty;
                        if (!IsNumeric(checkval) && !CHKgROUP[i].LineContent.Contains("GELİR TABLOSU") && CHKgROUP[i].LineContent.Contains(".") && !CHKgROUP[i].LineContent.Contains("Enflasyon") && !CHKgROUP[i].LineContent.Contains("Açıklama") && !CHKgROUP[i].LineContent.Contains("Önceki Dönem") && !CHKgROUP[i].LineContent.Contains("Cari Dönem"))
                        {
                            if (!checkval.Contains('('))
                            {
                                checkval1 = checkval;
                            }

                        }
                        CHKgROUP[i].MainID = "Z";
                        CHKgROUP[i].SubID = checkval1;
                        CHKgROUP[i].IsRevenue = 1;
                        nliste.Add(CHKgROUP[i]);
                    }

                    if (CHKgROUP[i].LineContent.Contains("KAR DAĞITIM TABLOSU"))
                    {
                        break;
                    }

                }

                var chkkGrp2 = BeyannameResult.Get_MizanResult();
                var tt = CHKgROUP.Where(x => chkkGrp2.Any(z => x.LineContent.Trim().Replace(" ", string.Empty).Contains(z.MainDescription.Trim().Replace(" ", string.Empty))));
                var chkssst = nliste;

                if (ISEnflasyon)
                {
                    nliste.Select(c => { c.IsEnflasyon = 1; return c; }).ToList();
                }

                nliste.Select(c => { c.IsGecici = 0; return c; }).ToList();

                BeyannameChk btnchk = new BeyannameChk();
                BeyannameChk.Delete(CompID, nYear);
                if (ISGeciciVergi)
                {
                    nliste.Select(c => { c.IsGecici = 1; return c; }).ToList();
                    foreach (var item in nliste)
                    {
                        btnchk = new BeyannameChk();
                        btnchk.IsGecici = item.IsGecici;
                        btnchk.AccountMainDescriptionChk = item.LineContent;
                        btnchk.IsEnflasyon = item.IsEnflasyon;
                        btnchk.CompanyID = CompID;
                        btnchk.IsRevenue = item.IsRevenue;
                        btnchk.SubID = item.SubID;
                        btnchk.MainID = item.MainID;
                        btnchk.Year = nYear;
                        btnchk.Save_Beyanname();
                        Thread.Sleep(50);
                    }
                }
                else
                {
                    foreach (var item in nliste)
                    {
                        btnchk = new BeyannameChk();
                        btnchk.AccountMainDescriptionChk = item.LineContent;
                        btnchk.IsEnflasyon = item.IsEnflasyon;
                        btnchk.CompanyID = CompID;
                        btnchk.IsRevenue = item.IsRevenue;
                        btnchk.SubID = item.SubID;
                        btnchk.MainID = item.MainID;
                        btnchk.Year = nYear;
                        btnchk.Save_Beyanname();
                        Thread.Sleep(50);
                    }

                }

                //BeyannameChk btnchk = new BeyannameChk();
                //BeyannameChk.Delete(CompID, nYear);
                //foreach (var item in nliste)
                //{
                //    btnchk = new BeyannameChk();
                //    btnchk.AccountMainDescriptionChk = item.LineContent;
                //    btnchk.CompanyID = CompID;
                //    btnchk.IsRevenue = item.IsRevenue;
                //    btnchk.SubID = item.SubID;
                //    btnchk.MainID = item.MainID;
                //    btnchk.Year = nYear;
                //    btnchk.Save_Beyanname();
                //    Thread.Sleep(50);
                //}
                BeyannameChk.DeleteLast(CompID, nYear);
                var chkkGrplst = BeyannameChk.Get_BeyannameResultLst(CompID, nYear);

                foreach (var item in chkkGrplst)
                {
                    BeyannameChk.LastSet(item.ID);
                }
                BeyannameChk.LastFinished(CompID, nYear, nmonth);
                var chk = CHKgROUP;

                // BeyannameChk.LastFinishedChkNewTestYear(CompID, nYear, false);
                if (!ISGeciciVergi)
                {

                    List<DashBilancoViewMizan> nRequestList1 = DashBilancoBeyan.getList(nYear, CompID);
                    var tlist1 = Data.SetBilancoFromListMizan(nRequestList1, CompID, nYear);
                    Data.RESET_DashBilancoViewMizan(nYear, CompID);
                    Data.InsertBilncoMzn(tlist1);

                }

                List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizan.GetListBYN(nYear, CompID);
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

                DashRasyoMizan.GetDashOzetMali1(nYear, CompID);

                if (!ISGeciciVergi)
                {
                    if (nYear != DateTime.Now.Year - 5)
                    {
                        TBLMizan ncs1 = new TBLMizan();
                        ncs1.CompanyID = CompID;
                        ncs1.CreatedDate = DateTime.Now;
                        ncs1.DocumentDate = new DateTime(nYear - 1, 12, 12); ;
                        ncs1.CsvName = filePath;
                        ncs1.Year = nYear - 1;
                        ncs1.MainMonth = nmonth;
                        ncs1.Save_TBLMizan();
                        //BeyannameChk.LastFinishedChkNewTestYear(CompID, nYear-1, true);
                        List<DashBilancoViewMizan> nRequestList1a = DashBilancoBeyan.getList(nYear - 1, CompID);
                        if (nRequestList1a.Count < 1)
                        {
                            return new JsonResult("ok_");
                        }
                        var tlist1a = Data.SetBilancoFromListMizan(nRequestList1a, CompID, nYear - 1);
                        Data.RESET_DashBilancoViewMizan(nYear - 1, CompID);
                        Data.InsertBilncoMzn(tlist1a);

                        List<DashBilancoViewMizan> nRequestListRvn1a = DashGelirTablosuMizan.GetListBYN(nYear - 1, CompID);
                        var tlistRvn1a = Data.SetBilancoFromListMizan(nRequestListRvn1a, CompID, nYear - 1);
                        Data.RESET_REVENUEViewMzn(nYear - 1, CompID);
                        Data.InsertRvnMzn(tlistRvn1a);
                        var WLikiditeVieza = DashLikiditeViewMainMizan.getList(nYear - 1, CompID);
                        var WCapitalVieza = DashWCapitalViewMainMizan.getList(nYear - 1, CompID);
                        var WCapitalViea = Data.SetBilancoFromListMizan(WCapitalVieza, CompID, nYear - 1);
                        var WLikiditeViea = Data.SetBilancoFromListMizan(WLikiditeVieza, CompID, nYear - 1);

                        if (WCapitalViea.Count > 0)
                        {
                            Data.InsertWCapitalMzn(WCapitalViea);
                            Data.InsertLiquidityMzn(WLikiditeViea);
                            DashBilancoSetMizan.Set_ReportSetMainSMM(nYear - 1, CompID);
                            DashRasyoMizan.GetDashRasyoAnaliz(nYear - 1, CompID);
                            DashRasyoMizan.GetDashLikiditeRiskTrend(nYear - 1, CompID);
                            DashRasyoMizan.GetDashOzetMali(nYear - 1, CompID);

                        }
                        DashRasyoMizan.GetDashOzetMali1(nYear - 1, CompID);
                    }
                    else
                    {
                        DashBilancoSetMizan.Set_ReportSetResetMizanKayitMnth(nYear - 1, CompID, 0);
                        DashBilancoSetMizan.Set_ReportSetResetMizanKayitMonthAll(nYear - 1, CompID, 0);
                    }
                }

                if (CHKgROUP.Where(x => x.LineContent.Contains("amortisman giderleri ile itfa")).Count() > 0)
                {

                    var personelvallue = CHKgROUP.Where(x => x.LineContent.Contains("amortisman giderleri ile itfa")).FirstOrDefault();

                    string tpersonelvallue = "";
                    try
                    {
                        tpersonelvallue = personelvallue.LineContent.Substring(personelvallue.LineContent.LastIndexOf("itfa"));
                    }
                    catch (Exception)
                    {

                    }

                    if (personelvallue.LineContent.Contains(","))
                    {
                        tpersonelvallue = personelvallue.LineContent.Substring(0, personelvallue.LineContent.IndexOf(','));
                    }
                    string resultzzz = string.Empty;
                    foreach (var c in tpersonelvallue)
                    {
                        int ascii = (int)c;
                        if ((ascii >= 48 && ascii <= 57) || ascii == 44 || ascii == 46)
                            resultzzz += c;
                    }
                    tpersonelvallue = resultzzz;

                    tpersonelvallue = tpersonelvallue.Trim().Replace(".", "");
                    float apersonel = 0;
                    if (tpersonelvallue.Length > 3)
                    {
                        if (tpersonelvallue.EndsWith(","))
                        {
                            //tpersonelvallue.Remove(tpersonelvallue.Length - 1);
                            tpersonelvallue = tpersonelvallue.Substring(0, tpersonelvallue.Length - 1);

                        }

                        if (tpersonelvallue.EndsWith("."))
                        {
                            //tpersonelvallue.Remove(tpersonelvallue.Length - 1);
                            tpersonelvallue = tpersonelvallue.Substring(0, tpersonelvallue.Length - 1);
                        }
                        apersonel = float.Parse(tpersonelvallue);
                    }

                    if (apersonel == 0)
                    {

                        var personelvallue1 = CHKgROUP.Where(x => x.CounterNo == personelvallue.CounterNo + 1).FirstOrDefault();
                        if (personelvallue1 != null)
                        {
                            tpersonelvallue = personelvallue1.LineContent;

                            if (personelvallue1.LineContent.Contains(","))
                            {
                                tpersonelvallue = personelvallue1.LineContent.Substring(0, personelvallue1.LineContent.IndexOf(','));
                            }
                            resultzzz = string.Empty;
                            foreach (var c in tpersonelvallue)
                            {
                                int ascii = (int)c;
                                if ((ascii >= 48 && ascii <= 57) || ascii == 44 || ascii == 46)
                                    resultzzz += c;
                            }
                            tpersonelvallue = resultzzz.Trim();
                            tpersonelvallue = tpersonelvallue.Trim().Replace(".", "");
                            apersonel = 0;
                            if (tpersonelvallue.Length > 3)
                            {
                                if (tpersonelvallue.EndsWith(","))
                                {
                                    //tpersonelvallue.Remove(tpersonelvallue.Length - 1);
                                    tpersonelvallue = tpersonelvallue.Substring(0, tpersonelvallue.Length - 1);

                                }

                                if (tpersonelvallue.EndsWith("."))
                                {
                                    //tpersonelvallue.Remove(tpersonelvallue.Length - 1);
                                    tpersonelvallue = tpersonelvallue.Substring(0, tpersonelvallue.Length - 1);
                                }

                                apersonel = float.Parse(tpersonelvallue);
                            }
                        }

                    }
                    //Data.BayennameInsertAmorrtisman(nYear, CompID, apersonel);
                }

            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = CompID;
                lg.CsvID = nYear;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                return new JsonResult(ex.ToString());
            }

            return new JsonResult("ok_");
        }

        [HttpPost("beyannamekurumsalupdate")]
        public async Task<JsonResult> moodUploadBeyannameUpdate(XMlookReq pageIndex)
        {
            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
            string chkTxt = "Enflasyon Düzeltmesi Sonrası";
            bool ISEnflasyon = false;

            var file = pageIndex.file;
            string filePath = string.Empty;
            List<string> nlistZipurl = new List<string>();
            string uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            int nmonth = Convert.ToInt32(pageIndex.Ay_Yil.Split('_')[0]);
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

            long CompID = Convert.ToInt64(pageIndex.compid);
            int nYear = Convert.ToInt32(pageIndex.Ay_Yil.Split('_')[1]);
            try
            {

                Companies mainComp = Companies.Get_Company(CompID);
                bool ISGeciciVergi = false;

                var CHKgROUP = ReadPdfFile(filePath);
                //for (int page = 1; page <= reader.NumberOfPages; page++)
                //{
                //    text  = PdfTextExtractor.GetTextFromPage(reader, page);
                //    nlist.Add(text);KURUMLAR VERGİSİ BEYANNAMESİ
                //}
                //reader.Close();
                string checkvalt = string.Empty;
                string checkval = string.Empty;
                string checkval1 = string.Empty;
                List<ReadPdfPg> nliste = new List<ReadPdfPg>();
                List<ReadPdfPg> nliste1 = new List<ReadPdfPg>();
                bool chekSource = false;
                bool chekSource1 = false;
                ReadPdfPg chhhk = CHKgROUP.Where(x => x.LineContent.Replace("İ", "I").Contains("KURUMLAR VERGISI BEYANNAMES")).FirstOrDefault();
                ReadPdfPg chhhkt = CHKgROUP.Where(x => x.LineContent.Replace("İ", "I").Replace("Ç", "C").Contains("GECICI VERGI BEYANNAMES")).FirstOrDefault();
                ReadPdfPg chhhkt1 = CHKgROUP.Where(x => x.LineContent.Replace("İ", "I").Contains("YILLIK GELIR VERGISI BEYANNAMES")).FirstOrDefault();

                if (chhhk == null && chhhkt == null && chhhkt1 == null)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Hatalı PDF Yükleme  -KURUMLAR VERGİSİ BEYANNAMESİ -GEÇİCİ VERGİ BEYANNAMESİ-YILLIK GELİR VERGİSİ BEYANNAMESİ Olmalı "; lg.Save_AppLogs();
                    return new JsonResult("nok_Hatalı PDF Yükleme - KURUMLAR VERGİSİ BEYANNAMESİ - GEÇİCİ VERGİ BEYANNAMESİ - YILLIK GELİR VERGİSİ BEYANNAMESİ Olmalı");
                }

                if (chhhkt != null)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Hatalı PDF Yükleme - Yalnızca  KURUMLAR VERGİSİ BEYANNAMESİ Bu alandan Yüklenebilir"; lg.Save_AppLogs();
                    return new JsonResult("nok_Hatalı PDF Yükleme - Yalnızca  KURUMLAR VERGİSİ BEYANNAMESİ Bu alandan Yüklenebilir");

                }
                ReadPdfPg chhhk1y = new ReadPdfPg();
                List<ReadPdfPg> chhhk1 = CHKgROUP.Where(x => x.LineContent.Contains("Yıl ")).ToList();

                ReadPdfPg chhhk1eposta = CHKgROUP.Where(x => x.LineContent.Contains("E-Posta Adresi")).FirstOrDefault();
                ReadPdfPg chktext = CHKgROUP.Where(x => x.CounterNo == chhhk1eposta.CounterNo + 1).FirstOrDefault();

                if (chktext == null)
                {
                    chktext = new ReadPdfPg();
                }

                string vergino = chktext.LineContent;
                string vergino1 = chktext.LineContent;
                string txt1Yil = chhhk1[0].LineContent.Split(' ')[1].Trim();
                string txt3Yil = "0";
                if (chhhk1.Count > 1)
                {
                    txt3Yil = chhhk1[1].LineContent.Split(' ')[1].Trim();
                }
                string chkyil1 = string.Empty;
                string chkyil3 = string.Empty;

                if (vergino.Trim() != mainComp.TaxID.Trim())
                {
                    if (vergino1.Trim() != mainComp.TaxID.Trim())
                    {
                        if (mainComp.State == null)
                        {
                            ERRLOG lg = new ERRLOG();
                            lg.CompanyID = CompID;
                            lg.CsvID = nYear;
                            lg.ERLOG = "Hatalı Vergi No  "; lg.Save_AppLogs();
                            return new JsonResult("nok_Hatalı Vergi No ");

                        }
                        else
                        {

                            if (vergino1.Trim() != mainComp.State.Trim())
                            {
                                if (vergino.Trim() != mainComp.State.Trim())
                                {
                                    ERRLOG lg = new ERRLOG();
                                    lg.CompanyID = CompID;
                                    lg.CsvID = nYear;
                                    lg.ERLOG = "Hatalı Vergi No  "; lg.Save_AppLogs();
                                    return new JsonResult("nok_Hatalı Vergi No ");
                                }
                            }
                        }
                    }
                }

                if (ISGeciciVergi)
                {
                    chhhk1y = CHKgROUP.Where(x => x.LineContent.Contains("Yılı")).FirstOrDefault();
                    var chhhkyilt = CHKgROUP.Where(x => x.CounterNo == chhhk1y.CounterNo + 2).FirstOrDefault();
                    chkyil1 = chhhkyilt.LineContent.Trim();
                    chkyil3 = chhhk1y.LineContent.Split(' ')[chhhk1y.LineContent.Split(' ').Length - 1].Trim();
                    var chhhk1yy = CHKgROUP.Where(x => x.LineContent.Contains("Onay Zamanı ")).FirstOrDefault();
                    txt1Yil = chhhk1yy.LineContent.Replace("Onay Zamanı", string.Empty).Replace(":", string.Empty).Split('-')[0].Trim().Split('.')[2];
                }
                else
                {
                    txt1Yil = chhhk1[0].LineContent.Split(' ')[1].Trim();
                }

                int result;
                if (chkyil1 != nYear.ToString())
                {

                    if (chkyil3 != nYear.ToString())
                    {

                        if (int.TryParse(txt1Yil, out result) && Convert.ToInt32(txt1Yil) != nYear)
                        {
                            if (int.TryParse(txt3Yil, out result) && Convert.ToInt32(txt3Yil) != nYear)
                            {
                                ERRLOG lg = new ERRLOG();
                                lg.CompanyID = CompID;
                                lg.CsvID = nYear;
                                lg.ERLOG = "Hatalı Yıl  "; lg.Save_AppLogs();
                                return new JsonResult("nok_Hatalı Yıl  ");
                            }
                        }

                    }

                }

                TBLMizan ncs = new TBLMizan();
                ncs.CompanyID = CompID;
                ncs.CreatedDate = DateTime.Now;
                ncs.DocumentDate = new DateTime(nYear, 12, 12); ;
                ncs.CsvName = filePath;
                ncs.Year = nYear;
                ncs.MainMonth = nmonth;
                ncs.Save_TBLMizan();

                CHKgROUP = CHKgROUP.Where(x => x.LineContent.Length > 11).ToList();
                for (int i = 0; i < CHKgROUP.Count; i++)
                {
                    if (CHKgROUP[i].LineContent.Contains(chkTxt))
                    {
                        ISEnflasyon = true;
                    }
                    if (CHKgROUP[i].LineContent.Contains("Dönen Varlıklar"))
                    {
                        checkvalt = "I";
                        chekSource = true;
                    }

                    if (CHKgROUP[i].LineContent.Contains("PASİF TOPLAMI"))
                    {
                        CHKgROUP[i].MainID = "I";
                        CHKgROUP[i].SubID = "PASİF TOPLAMI";
                        nliste.Add(CHKgROUP[i]);
                        chekSource = false;
                    }

                    if (chekSource || CHKgROUP[i].LineContent.Contains("Kayda Alınan Emtia Özel Karşılık"))
                    {
                        checkval = CHKgROUP[i].LineContent.Length > 1 ? CHKgROUP[i].LineContent.Replace(". ", string.Empty).Substring(0, 1) : string.Empty;
                        if (!IsNumeric(checkval) && !CHKgROUP[i].LineContent.Contains("GELİR TABLOSU") && CHKgROUP[i].LineContent.Contains(".") && !CHKgROUP[i].LineContent.Contains("Enflasyon") && !CHKgROUP[i].LineContent.Contains("Açıklama") && !CHKgROUP[i].LineContent.Contains("Önceki Dönem") && !CHKgROUP[i].LineContent.Contains("Cari Dönem"))
                        {
                            if (!checkval.Contains('('))
                            {
                                checkval1 = checkval;
                            }

                        }

                        CHKgROUP[i].SubID = checkval1;
                        if (CHKgROUP[i].LineContent.Contains("AKTİF TOPLAMI") || CHKgROUP[i].LineContent.Contains("II") || CHKgROUP[i].LineContent.Contains("III") || CHKgROUP[i].LineContent.Contains("IV") || CHKgROUP[i].LineContent.Contains("V."))
                        {
                            if (CHKgROUP[i].LineContent.Contains("III"))
                            {
                                checkvalt = "III";
                            }
                            else if (CHKgROUP[i].LineContent.Contains("II"))
                            {
                                checkvalt = "II";
                            }
                            else if (CHKgROUP[i].LineContent.Contains("IV"))
                            {
                                checkvalt = "IV";
                            }
                            else if (CHKgROUP[i].LineContent.Contains("V"))
                            {
                                checkvalt = "V";
                            }

                            CHKgROUP[i].SubID = RemoveEmpty(CHKgROUP[i].LineContent);
                        }
                        CHKgROUP[i].MainID = checkvalt;
                        nliste.Add(CHKgROUP[i]);
                    }

                    if (ISGeciciVergi)
                    {
                        if (CHKgROUP[i].LineContent != null && CHKgROUP[i].LineContent.Contains("GELİR TABLOSU"))
                        {

                            chekSource1 = true;
                        }
                    }
                    else
                    {
                        if ((CHKgROUP[i].LineContent != null && CHKgROUP[i].LineContent.Contains("GELİR TABLOSU") && (CHKgROUP[i].LineContent.Trim().Length > 23) == false))
                        {

                            chekSource1 = true;
                        }
                    }

                    if (!ISGeciciVergi)
                    {
                        if (CHKgROUP[i].LineContent.Contains("Dönem Net Karı veya Zararı"))
                        {
                            CHKgROUP[i].MainID = "Z";
                            CHKgROUP[i].SubID = "D";
                            CHKgROUP[i].IsRevenue = 1;
                            nliste.Add(CHKgROUP[i]);
                            chekSource1 = false;
                        }
                    }

                    if (chekSource1)
                    {
                        checkval = CHKgROUP[i].LineContent.Length > 1 ? CHKgROUP[i].LineContent.Replace(". ", string.Empty).Substring(0, 1) : string.Empty;
                        if (!IsNumeric(checkval) && !CHKgROUP[i].LineContent.Contains("GELİR TABLOSU") && CHKgROUP[i].LineContent.Contains(".") && !CHKgROUP[i].LineContent.Contains("Enflasyon") && !CHKgROUP[i].LineContent.Contains("Açıklama") && !CHKgROUP[i].LineContent.Contains("Önceki Dönem") && !CHKgROUP[i].LineContent.Contains("Cari Dönem"))
                        {
                            if (!checkval.Contains('('))
                            {
                                checkval1 = checkval;
                            }

                        }
                        CHKgROUP[i].MainID = "Z";
                        CHKgROUP[i].SubID = checkval1;
                        CHKgROUP[i].IsRevenue = 1;
                        nliste.Add(CHKgROUP[i]);
                    }
                    if (CHKgROUP[i].LineContent.Contains("KAR DAĞITIM TABLOSU"))
                    {
                        break;
                    }
                }

                var chkkGrp2 = BeyannameResult.Get_MizanResult();
                var tt = CHKgROUP.Where(x => chkkGrp2.Any(z => x.LineContent.Trim().Replace(" ", string.Empty).Contains(z.MainDescription.Trim().Replace(" ", string.Empty))));
                var chkssst = nliste;

                if (ISEnflasyon)
                {
                    nliste.Select(c => { c.IsEnflasyon = 1; return c; }).ToList();
                }
                nliste.Select(c => { c.IsGecici = 0; return c; }).ToList();

                BeyannameChk btnchk = new BeyannameChk();
                BeyannameChk.Delete(CompID, nYear);
                if (ISGeciciVergi)
                {
                    nliste.Select(c => { c.IsGecici = 1; return c; }).ToList();
                    foreach (var item in nliste)
                    {
                        btnchk = new BeyannameChk();
                        btnchk.IsGecici = item.IsGecici;
                        btnchk.AccountMainDescriptionChk = item.LineContent;
                        btnchk.CompanyID = CompID;
                        btnchk.IsRevenue = item.IsRevenue;
                        btnchk.SubID = item.SubID;
                        btnchk.MainID = item.MainID;
                        btnchk.IsEnflasyon = item.IsEnflasyon;
                        btnchk.Year = nYear;
                        btnchk.Save_Beyanname();
                        Thread.Sleep(50);
                    }
                }
                else
                {
                    foreach (var item in nliste)
                    {
                        btnchk = new BeyannameChk();
                        btnchk.AccountMainDescriptionChk = item.LineContent;
                        btnchk.CompanyID = CompID;
                        btnchk.IsRevenue = item.IsRevenue;
                        btnchk.SubID = item.SubID;
                        btnchk.MainID = item.MainID;
                        btnchk.IsEnflasyon = item.IsEnflasyon;
                        btnchk.Year = nYear;
                        btnchk.Save_Beyanname();
                        Thread.Sleep(50);
                    }

                }

                BeyannameChk.DeleteLast(CompID, nYear);
                var chkkGrplst = BeyannameChk.Get_BeyannameResultLst(CompID, nYear);

                foreach (var item in chkkGrplst)
                {
                    BeyannameChk.LastSet(item.ID);
                }
                BeyannameChk.LastFinished(CompID, nYear, nmonth);

                //BeyannameChk.LastFinishedChkNewTestYear(CompID, nYear, false);
                if (!ISGeciciVergi)
                {
                    List<DashBilancoViewMizan> nRequestList1 = DashBilancoBeyan.getList(nYear, CompID);
                    var tlist1 = Data.SetBilancoFromListMizan(nRequestList1, CompID, nYear);
                    Data.RESET_DashBilancoViewMizan(nYear, CompID);
                    Data.InsertBilncoMzn(tlist1);

                }

                List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizan.GetListBYN(nYear, CompID);
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

                DashRasyoMizan.GetDashOzetMali1(nYear, CompID);

                if (!ISGeciciVergi)
                {
                    if (nYear != DateTime.Now.Year - 5)
                    {
                        TBLMizan ncs1 = new TBLMizan();
                        ncs1.CompanyID = CompID;
                        ncs1.CreatedDate = DateTime.Now;
                        ncs1.DocumentDate = new DateTime(nYear - 1, 12, 12); ;
                        ncs1.CsvName = filePath;
                        ncs1.Year = nYear - 1;
                        ncs1.MainMonth = nmonth;
                        ncs1.Save_TBLMizan();

                        //BeyannameChk.LastFinishedChkNewTestYear(CompID, nYear-1, true);
                        List<DashBilancoViewMizan> nRequestList1a = DashBilancoBeyan.getList(nYear - 1, CompID);
                        if (nRequestList1a.Count < 1)
                        {
                            return new JsonResult("ok_");
                        }
                        var tlist1a = Data.SetBilancoFromListMizan(nRequestList1a, CompID, nYear - 1);
                        Data.RESET_DashBilancoViewMizan(nYear - 1, CompID);
                        Data.InsertBilncoMzn(tlist1a);
                        List<DashBilancoViewMizan> nRequestListRvn1a = DashGelirTablosuMizan.GetListBYN(nYear - 1, CompID);
                        var tlistRvn1a = Data.SetBilancoFromListMizan(nRequestListRvn1a, CompID, nYear - 1);
                        Data.RESET_REVENUEViewMzn(nYear - 1, CompID);
                        Data.InsertRvnMzn(tlistRvn1a);
                        var WLikiditeVieza = DashLikiditeViewMainMizan.getList(nYear - 1, CompID);
                        var WCapitalVieza = DashWCapitalViewMainMizan.getList(nYear - 1, CompID);
                        var WCapitalViea = Data.SetBilancoFromListMizan(WCapitalVieza, CompID, nYear - 1);
                        var WLikiditeViea = Data.SetBilancoFromListMizan(WLikiditeVieza, CompID, nYear - 1);

                        if (WCapitalViea.Count > 0)
                        {
                            Data.InsertWCapitalMzn(WCapitalViea);
                            Data.InsertLiquidityMzn(WLikiditeViea);
                            DashBilancoSetMizan.Set_ReportSetMainSMM(nYear - 1, CompID);
                            DashRasyoMizan.GetDashRasyoAnaliz(nYear - 1, CompID);
                            DashRasyoMizan.GetDashLikiditeRiskTrend(nYear - 1, CompID);
                            DashRasyoMizan.GetDashOzetMali(nYear - 1, CompID);

                        }

                        DashRasyoMizan.GetDashOzetMali1(nYear - 1, CompID);
                    }
                    else
                    {
                        DashBilancoSetMizan.Set_ReportSetResetMizanKayitMnth(nYear - 1, CompID, 0);
                        DashBilancoSetMizan.Set_ReportSetResetMizanKayitMonthAll(nYear - 1, CompID, 0);
                    }
                }

                if (CHKgROUP.Where(x => x.LineContent.Contains("amortisman giderleri ile itfa")).Count() > 0)
                {

                    var personelvallue = CHKgROUP.Where(x => x.LineContent.Contains("amortisman giderleri ile itfa")).FirstOrDefault();

                    string tpersonelvallue = "";
                    try
                    {
                        tpersonelvallue = personelvallue.LineContent.Substring(personelvallue.LineContent.LastIndexOf("itfa"));
                    }
                    catch (Exception)
                    {

                    }
                    if (personelvallue.LineContent.Contains(","))
                    {
                        tpersonelvallue = personelvallue.LineContent.Substring(0, personelvallue.LineContent.IndexOf(','));
                    }
                    string resultzzz = string.Empty;
                    foreach (var c in tpersonelvallue)
                    {
                        int ascii = (int)c;
                        if ((ascii >= 48 && ascii <= 57) || ascii == 44 || ascii == 46)
                            resultzzz += c;
                    }
                    tpersonelvallue = resultzzz;

                    tpersonelvallue = tpersonelvallue.Trim().Replace(".", "");
                    float apersonel = 0;
                    if (tpersonelvallue.Length > 3)
                    {
                        if (tpersonelvallue.EndsWith(","))
                        {
                            //tpersonelvallue.Remove(tpersonelvallue.Length - 1);
                            tpersonelvallue = tpersonelvallue.Substring(0, tpersonelvallue.Length - 1);

                        }

                        if (tpersonelvallue.EndsWith("."))
                        {
                            //tpersonelvallue.Remove(tpersonelvallue.Length - 1);
                            tpersonelvallue = tpersonelvallue.Substring(0, tpersonelvallue.Length - 1);
                        }
                        apersonel = float.Parse(tpersonelvallue);
                    }

                    if (apersonel == 0)
                    {

                        var personelvallue1 = CHKgROUP.Where(x => x.CounterNo == personelvallue.CounterNo + 1).FirstOrDefault();
                        if (personelvallue1 != null)
                        {
                            tpersonelvallue = personelvallue1.LineContent;
                            if (personelvallue1.LineContent.Contains(","))
                            {
                                tpersonelvallue = personelvallue1.LineContent.Substring(0, personelvallue1.LineContent.IndexOf(','));
                            }
                            resultzzz = string.Empty;
                            foreach (var c in tpersonelvallue)
                            {
                                int ascii = (int)c;
                                if ((ascii >= 48 && ascii <= 57) || ascii == 44 || ascii == 46)
                                    resultzzz += c;
                            }
                            tpersonelvallue = resultzzz.Trim();
                            tpersonelvallue = tpersonelvallue.Trim().Replace(".", "");
                            apersonel = 0;
                            if (tpersonelvallue.Length > 3)
                            {
                                if (tpersonelvallue.EndsWith(","))
                                {
                                    //tpersonelvallue.Remove(tpersonelvallue.Length - 1);
                                    tpersonelvallue = tpersonelvallue.Substring(0, tpersonelvallue.Length - 1);

                                }

                                if (tpersonelvallue.EndsWith("."))
                                {
                                    //tpersonelvallue.Remove(tpersonelvallue.Length - 1);
                                    tpersonelvallue = tpersonelvallue.Substring(0, tpersonelvallue.Length - 1);
                                }

                                apersonel = float.Parse(tpersonelvallue);
                            }
                        }

                    }
                    //Data.BayennameInsertAmorrtisman(nYear, CompID, apersonel);
                }

            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = CompID;
                lg.CsvID = nYear;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                return new JsonResult(ex.ToString());
            }

            return new JsonResult("ok_");
        }
        [HttpPost("eledgeruploadpagelist")]
        public JsonResult Dataeledgeruploadpagelist([FromBody] RequestEledgerMain reg)
        {

            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));

 

            var currentUploadM = UploadMain.Get_Data(reg.Year, reg.CompanyID).OrderBy(x => x.MainMonth);
        

            return new JsonResult(currentUploadM);
        }
        [HttpPost("mizanuploadpagelist")]
        public JsonResult Datamizanuploadpagelist([FromBody] RequestEledgerMain reg)
        {

            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));

            List<int> chkInt = new List<int>() { 3, 6, 9, 12 };
            List<int> chkErrormonthIDChk = MainDash.Get_DatabyMOnthMizan(reg.Year, reg.CompanyID);

            var uploadedlist = TBLXMLSCheckpdfMizan.GetMizanUploded(reg.CompanyID, reg.Year);
            

            return new JsonResult(uploadedlist);
        }

        [HttpPost("mizanliquidity")]
        public JsonResult Datamizanliquidity([FromBody] RequestMizan reg)
        {

            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
            List<DashBilancoViewMizan> nRequestList = new List<DashBilancoViewMizan>();
            if (reg.IsForChart)
            {
                List<DashBilancoViewMizan> nRequestLista = DashLikiditeMizan.Get_MainList(reg.CompanyID);
                return new JsonResult(nRequestLista);
            }
            else
            {
                nRequestList = DashLikiditeMizan.Get_MainList(reg.CompanyID);
                return new JsonResult(nRequestList);
            }
        }

        [HttpPost("uploadmizanupdatepdf")]
        public async Task<JsonResult> UploadMznCkeckPDFUpdate(XMlookReq pageIndex)
        {
            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
            long CompID = Convert.ToInt64(pageIndex.compid);
            var file = pageIndex.file;
            string filePath = string.Empty;
            List<string> nlistZipurl = new List<string>();
            string uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            byte nmonth = Convert.ToByte(pageIndex.Ay_Yil.Split('_')[0]);
            Random rnd = new Random();
            int rndmonth = rnd.Next(10000000, 99999999);
            int nYear = Convert.ToInt32(pageIndex.Ay_Yil.Split('_')[1]);
            string fileDocNumber = pageIndex.compid + nYear.ToString().Substring(2) + nmonth.ToString();
            int fileDocNumberInt = Convert.ToInt32(fileDocNumber);
            if (file != null && file.Count > 0)
            {
                foreach (var item in file)
                {

                    filePath = System.IO.Path.Combine(uploads, rndmonth.ToString() + "-" + nYear.ToString() + System.IO.Path.GetExtension(item.FileName));

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream).ConfigureAwait(false);
                    }

                }

            }

            try
            {
                Thread.Sleep(500);
                string base64File = "";
                try
                {

                    base64File = ApiHelper.ConvertFileToBase64(filePath);
                }
                catch (Exception ex)
                {
                    var chkdhkd = ex.Message;
                    throw;
                }

                DigiRequestMizan nrequest = new DigiRequestMizan(base64File, fileDocNumber);
                var result = await _documentService.UploadFileMizanAsync(nrequest);
                int DocumentIdRet = 0;
                DigiResponseMizan nreultapi = new DigiResponseMizan();
                if (result != null)
                {
                    if (result.ResultCode == 0)
                    {
                        while (DocumentIdRet != 2)
                        {
                            nreultapi = await _documentService.GetDocumentResultAsync(fileDocNumberInt);

                            DocumentIdRet = nreultapi.DocumentStateId;
                            Thread.Sleep(1500);
                        }

                    }

                }

                var cjkjkj = nreultapi;

                TBLMizan ncs = new TBLMizan();
                ncs.CompanyID = CompID;
                ncs.CreatedDate = DateTime.Now;
                ncs.DocumentDate = new DateTime(nYear, nmonth, 12);
                ncs.CsvName = filePath;
                ncs.Year = nYear;
                ncs.MainMonth = nmonth;
                ncs.Save_TBLMizan();
                DashBilancoSetMizan.Set_ReportSetResetMizanKayit(nYear, CompID);
                DashBilancoSetMizan.Set_ReportSetResetMizanKayitMOnth(nYear, CompID, nmonth);

                IEnumerable<XmlExcel> nlist = ExcelHelper.CheckColumnPdfExcelFromJson(nreultapi.Data.ToList());
                nlist = nlist.Select(c => { c.AccountMainID = c.AccountMainID.Replace(",", ".").Replace("-", ".").Replace("_", "."); return c; }).ToList();

                List<string> nnlist = DashBilancoSetMizan.GetAccountList();

                nlist = nlist.Where(x => nnlist.Contains(x.AccountMainIDMain)).OrderBy(x => x.AccountMainID).ToList();
                List<string> chkList = nlist.Where(y => y.CreditBakiye != null && y.CreditBakiye != "").Select(x => x.CreditBakiye).ToList();

                List<string> uniquechkList = chkList.Distinct().ToList();

                if ((chkList.Count / 10) > uniquechkList.Count)
                {
                    foreach (XmlExcel cust in nlist)
                    {
                        cust.CreditBakiye = "0";
                    }
                }

                List<XmlExcel> cchklist = nlist.Where(x => x.TextCount == 3).ToList();
                cchklist = cchklist.GroupBy(i => i.AccountMainID)
                                   .Select(g => g.First())
                                   .ToList();

                List<XmlExcel> cchklist1 = nlist.Where(x => x.TextCount >= 6).ToList();

                var tlist = Data.SetBilancoFromListMizanExcel(cchklist, CompID, nYear, nmonth);
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

                if (cchklist1.Count > 0)
                {
                    var tlistsub = Data.SetBilancoFromListMizanExcelSub(cchklist1, CompID, nYear);
                    Data.InsertDataMizanSub(tlistsub);
                    ReportSetMainAktarma.Set_MizanSubSetfirst(nYear, CompID);
                }

                if (tlist.Count > 0)
                {
                    Data.InsertDataMizan(tlist);
                }
                else
                {
                    //Data.SET_MIZANHEADER(nYear, CompID);
                }

                //}
                List<DashBilancoViewMizan> nRequestList1 = DashBilancoMizan.getList(nYear, CompID);
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

                var resuktCount = DashRasyoMizan.GetCheckMizanStatus(nYear, CompID, nmonth);
                if (resuktCount < 5)
                {

                    return new JsonResult("nok");
                }
            }
            catch (Exception ex)
            {
                var tyty = ex;

                return new JsonResult(ex.Message);
            }

            return new JsonResult("ok");
        }

        [HttpPost("uploadmizanprdf")]
        public async Task<JsonResult> UploadMznCkeckPDF(XMlookReq pageIndex)
        {
            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
            string filePath = string.Empty;

            var file = pageIndex.file;
            List<string> nlistZipurl = new List<string>();
            Random rnd = new Random();
            int rndmonth = rnd.Next(10000000, 99999999);
            string uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            byte nmonth = Convert.ToByte(pageIndex.Ay_Yil.Split('_')[0]);

            long CompID = Convert.ToInt64(pageIndex.compid);
            int nYear = Convert.ToInt32(pageIndex.Ay_Yil.Split('_')[0]);
            string fileDocNumber = pageIndex.compid + nYear.ToString().Substring(2) + nmonth.ToString();
            int fileDocNumberInt = Convert.ToInt32(fileDocNumber);
            List<List<string>> pdfxcllista = new List<List<string>>();
            List<string> pdfxcllist = new List<string>();

            if (file != null && file.Count > 0)
            {
                foreach (var item in file)
                {

                    filePath = System.IO.Path.Combine(uploads, rndmonth.ToString() + "-" + nYear.ToString() + System.IO.Path.GetExtension(item.FileName));

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream).ConfigureAwait(false);
                    }

                }

            }

            try
            {
                Thread.Sleep(500);
                string base64File = "";
                try
                {

                    base64File = ApiHelper.ConvertFileToBase64(filePath);
                }
                catch (Exception ex)
                {
                    var chkdhkd = ex.Message;
                    throw;
                }

                DigiRequestMizan nrequest = new DigiRequestMizan(base64File, fileDocNumber);
                var result = await _documentService.UploadFileMizanAsync(nrequest);
                int DocumentIdRet = 0; string resultsstr = "";
                DigiResponseMizan nreultapi = new DigiResponseMizan();
                if (result != null)
                {
                    if (result.ResultCode == 0)
                    {
                        while (DocumentIdRet != 2)
                        {
                            nreultapi = await _documentService.GetDocumentResultAsync(fileDocNumberInt);

                            DocumentIdRet = nreultapi.DocumentStateId;
                            Thread.Sleep(1500);
                        }

                    }

                }

                var cjkjkj = nreultapi;

                TBLMizan ncs = new TBLMizan();
                ncs.CompanyID = CompID;
                ncs.CreatedDate = DateTime.Now;
                ncs.DocumentDate = new DateTime(nYear, nmonth, 12);
                ncs.CsvName = filePath;
                ncs.Year = nYear;
                ncs.MainMonth = nmonth;
                ncs.Save_TBLMizan();
                DashBilancoSetMizan.Set_ReportSetResetMizanKayit(nYear, CompID);
                DashBilancoSetMizan.Set_ReportSetResetMizanKayitMOnth(nYear, CompID, nmonth);

                //DataTable dt = ExcelHelper.ExcelToDataTableFull(itemz);
                IEnumerable<XmlExcel> nlist = ExcelHelper.CheckColumnPdfExcelFromJson(nreultapi.Data.ToList());
                nlist = nlist.Select(c => { c.AccountMainID = c.AccountMainID.Replace(",", ".").Replace("-", ".").Replace("_", "."); return c; }).ToList();

                List<string> nnlist = DashBilancoSetMizan.GetAccountList();
                //   var tlista = nlist.Where(x => (x.CreditAmountFloat == x.AmountBakiyeFloat) && x.CreditAmountFloat == 0).ToList();

                nlist = nlist.Where(x => nnlist.Contains(x.AccountMainIDMain)).OrderBy(x => x.AccountMainID).ToList();
                List<string> chkList = nlist.Where(y => y.CreditBakiye != null && y.CreditBakiye != "").Select(x => x.CreditBakiye).ToList();

                List<string> uniquechkList = chkList.Distinct().ToList();

                if ((chkList.Count / 10) > uniquechkList.Count)
                {
                    foreach (XmlExcel cust in nlist)
                    {
                        cust.CreditBakiye = "0";
                        //cust.DebitBakiye = "0";
                    }
                }
                //nlist = nlist.Except(tlista);
                List<XmlExcel> cchklist = nlist.Where(x => x.TextCount == 3).ToList();
                cchklist = cchklist.GroupBy(i => i.AccountMainID)
                                   .Select(g => g.First())
                                   .ToList();

                List<XmlExcel> cchklist1 = nlist.Where(x => x.TextCount >= 6).ToList();

                //cchklist = cchklist.OrderBy(x => x.AccountMainID).ToList();
                //cchklist1 = cchklist1.Where(x =>  (x.CreditAmountFloat == x.DebitAmountFloat )&&  x.CreditAmountFloat == 0).ToList();
                //cchklist = cchklist.Where(x =>  (x.CreditAmountFloat == x.DebitAmountFloat) && x.CreditAmountFloat == 0).ToList();
                var tlist = Data.SetBilancoFromListMizanExcel(cchklist, CompID, nYear, nmonth);
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

                if (cchklist1.Count > 0)
                {
                    var tlistsub = Data.SetBilancoFromListMizanExcelSub(cchklist1, CompID, nYear);
                    Data.InsertDataMizanSub(tlistsub);
                    ReportSetMainAktarma.Set_MizanSubSetfirst(nYear, CompID);
                }

                if (tlist.Count > 0)
                {
                    Data.InsertDataMizan(tlist);
                }
                else
                {
                    //Data.SET_MIZANHEADER(nYear, CompID);
                }

                List<DashBilancoViewMizan> nRequestList1 = DashBilancoMizan.getList(nYear, CompID);
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
                var resuktCount = DashRasyoMizan.GetCheckMizanStatus(nYear, CompID, nmonth);
                if (resuktCount < 5)
                {

                    return new JsonResult("nok");
                }

            }
            catch (Exception ex)
            {
                var tyty = ex;
                return new JsonResult(ex.Message);
            }

            return new JsonResult("ok");
        }

        public async Task<JsonResult> UploadMznCkeck(XMlookReq pageIndex)
        {
            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
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

            long CompID = Convert.ToInt64(pageIndex.compid);
            int nYear = Convert.ToInt32(pageIndex.Ay_Yil.Split('_')[1]);
            try
            {
                TBLMizan ncs = new TBLMizan();
                ncs.CompanyID = CompID;
                ncs.CreatedDate = DateTime.Now;
                ncs.DocumentDate = new DateTime(nYear, 12, 12); ;
                ncs.CsvName = filePath;
                ncs.Year = nYear;
                ncs.Save_TBLMizan();

                DataTable dt = ExcelHelper.ExcelToDataTable(filePath);

                IEnumerable<XmlExcel> nlist = ExcelHelper.CheckColumn(dt);

                // IEnumerable<XmlExcel> nlist = ExcelHelper.ChangeColumName(dt);
                nlist = nlist.Select(c => { c.AccountMainID = c.AccountMainID.Replace(",", ".").Replace("-", ".").Replace("_", "."); return c; }).ToList();
                List<string> nnlist = DashBilancoSetMizan.GetAccountList();
                List<string> nnlistsix = DashBilancoSetMizan.GetAccountListSix();
                //   var tlista = nlist.Where(x => (x.CreditAmountFloat == x.AmountBakiyeFloat) && x.CreditAmountFloat == 0).ToList();
                nlist = nlist.Where(x => nnlist.Contains(x.AccountMainIDMain));
                List<string> chkList = nlist.Where(y => y.CreditBakiye != null && y.CreditBakiye != "").Select(x => x.CreditBakiye).ToList();

                List<string> uniquechkList = chkList.Distinct().ToList();

                if ((chkList.Count / 10) > uniquechkList.Count)
                {
                    foreach (XmlExcel cust in nlist)
                    {
                        cust.CreditBakiye = "0";
                        //cust.DebitBakiye = "0";
                    }
                }
                List<XmlExcel> cchklist = nlist.Where(x => x.TextCount == 3).ToList();
                List<XmlExcel> cchklist1 = nlist.Where(x => x.TextCount >= 5).ToList();

                int fcount = cchklist.Where(x => x.CreditAmountFloat == 0).Count();

                int tcount = cchklist.Where(x => x.DebitAmountFloat == 0).Count();
                int chkcount = cchklist.Count();

                if (chkcount == tcount && chkcount > 1)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Mizan Şablon Hatası"; lg.Save_AppLogs();
                    return new JsonResult("lock");
                }

                if (chkcount == fcount && chkcount > 1)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Mizan Şablon Hatası"; lg.Save_AppLogs();
                    return new JsonResult("lock");
                }
                //  6 lı gruplarda değer var mı kontrol et
                //  2 den büyük ve 
                //var tlist = cchklist.Where(x => nnlistsix.Contains(x.AccountMainID) && (x.CreditAmountFloat - x.DebitAmountFloat) != 0 ).ToList();
                List<string> nnlistcheck = cchklist.Where(x => nnlistsix.Contains(x.AccountMainID) && x.AmountBakiye != "0").Select(x => x.AccountMainID).ToList();
                if (nnlistcheck.Count < 4 && chkcount > 1)
                {
                    List<string> mslist = new List<string>() { "690", "691", "692" };
                    List<string> ttchek = nnlistcheck.Except(mslist).ToList();

                    if (ttchek.Count < 1)
                    {
                        ERRLOG lg = new ERRLOG();
                        lg.CompanyID = CompID;
                        lg.CsvID = nYear;
                        lg.ERLOG = "Kesin Mizan Hatası"; lg.Save_AppLogs();
                        return new JsonResult("nok");
                    }

                }

            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = CompID;
                lg.CsvID = nYear;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                return new JsonResult("nok");
            }

            return new JsonResult("ok");
        }

        [HttpPost("uploadmizan")]
        public async Task<JsonResult> UploadMzn(XMlookReq pageIndex)
        {
            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));

            var file = pageIndex.file;
            string filePath = string.Empty;
            List<string> nlistZipurl = new List<string>();
            string uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            int nmonth = Convert.ToInt32(pageIndex.Ay_Yil.Split('_')[0]);
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

            long CompID = Convert.ToInt64(pageIndex.compid);
            int nYear = Convert.ToInt32(pageIndex.Ay_Yil.Split('_')[1]);
            try
            {
                TBLMizan ncs = new TBLMizan();
                ncs.CompanyID = CompID;
                ncs.CreatedDate = DateTime.Now;
                ncs.DocumentDate = new DateTime(nYear, 12, 12); ;
                ncs.CsvName = filePath;
                ncs.Year = nYear;
                ncs.MainMonth = nmonth;
                ncs.Save_TBLMizan();

                DataTable dt = ExcelHelper.ExcelToDataTable(filePath);
                IEnumerable<XmlExcel> nlist = ExcelHelper.CheckColumn(dt);
                nlist = nlist.Select(c => { c.AccountMainID = c.AccountMainID.Replace(",", ".").Replace("-", ".").Replace("_", ".").Trim(); return c; }).ToList();
                List<string> nnlist = DashBilancoSetMizan.GetAccountList();
                //   var tlista = nlist.Where(x => (x.CreditAmountFloat == x.AmountBakiyeFloat) && x.CreditAmountFloat == 0).ToList();
                nlist = nlist.Where(x => nnlist.Contains(x.AccountMainIDMain));
                List<string> chkList = nlist.Where(y => y.CreditBakiye != null && y.CreditBakiye != "").Select(x => x.CreditBakiye).ToList();

                List<string> uniquechkList = chkList.Distinct().ToList();

                if ((chkList.Count / 10) > uniquechkList.Count)
                {
                    foreach (XmlExcel cust in nlist)
                    {
                        cust.CreditBakiye = "0";
                        //cust.DebitBakiye = "0";
                    }
                }
                List<XmlExcel> cchklist = nlist.Where(x => x.TextCount == 3).ToList();
                cchklist = cchklist.GroupBy(i => i.AccountMainID)
                               .Select(g => g.First())
                               .ToList();
                List<XmlExcel> cchklist1 = nlist.Where(x => x.TextCount >= 5).ToList();

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

                //List<string> tcheck= nnlistcheck.ex(x=> nnlistsix.Contains())
                //cchklist1 = cchklist1.Where(x =>  (x.CreditAmountFloat == x.DebitAmountFloat )&&  x.CreditAmountFloat == 0).ToList();
                //cchklist = cchklist.Where(x =>  (x.CreditAmountFloat == x.DebitAmountFloat) && x.CreditAmountFloat == 0).ToList();
                var tlist = Data.SetBilancoFromListMizanExcel(cchklist, CompID, nYear, nmonth);

                if (cchklist1.Count > 0)
                {
                    var tlistsub = Data.SetBilancoFromListMizanExcelSub(cchklist1, CompID, nYear);
                    Data.InsertDataMizanSub(tlistsub);
                    ReportSetMainAktarma.Set_MizanSubSetfirst(nYear, CompID);
                }

                if (tlist.Count > 0)
                {
                    Data.InsertDataMizan(tlist);
                }
                else
                {
                    Data.SET_MIZANHEADER(nYear, CompID);
                }

                ReportSetMainAktarma.Set_ReportTBAFirst(nYear, CompID);
                ReportSetMainAktarma.Set_ReportTBAFirstMonthly(nYear, CompID);
                List<DashBilancoViewMizan> nRequestList1 = DashBilancoMizan.getList(nYear, CompID);
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
                var resuktCount = DashRasyoMizan.GetCheckMizanStatus(nYear, CompID, nmonth);
                if (resuktCount < 5)
                {

                    return new JsonResult("nok");
                }
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = CompID;
                lg.CsvID = nYear;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                return new JsonResult(ex.ToString());
            }

            return new JsonResult("ok");
        }

        [HttpPost("uploadmizanupdate")]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [RequestSizeLimit(209715200)]
        public async Task<JsonResult> moodUploadUpdateMzn(XMlookReq pageIndex)
        {
            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));

            long CompID = Convert.ToInt64(pageIndex.compid);

            var file = pageIndex.file;
            string filePath = string.Empty;
            string uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            int nmonth = Convert.ToInt32(pageIndex.Ay_Yil.Split('_')[0]);
            int nYear = Convert.ToInt32(pageIndex.Ay_Yil.Split('_')[1]);
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

                TBLMizan ncs = new TBLMizan();
                ncs.CompanyID = CompID;
                ncs.CreatedDate = DateTime.Now;
                ncs.DocumentDate = new DateTime(nYear, 12, 12);
                ncs.CsvName = filePath;
                ncs.Year = nYear;
                ncs.MainMonth = nmonth;
                ncs.Save_TBLMizan();
                DataTable dt = ExcelHelper.ExcelToDataTable(filePath);
                IEnumerable<XmlExcel> nlist = ExcelHelper.CheckColumn(dt);
                nlist = nlist.Select(c => { c.AccountMainID = c.AccountMainID.Replace(",", ".").Replace("-", ".").Replace("_", "."); return c; }).ToList();

                List<string> nnlist = DashBilancoSetMizan.GetAccountList();
                //   var tlista = nlist.Where(x => (x.CreditAmountFloat == x.AmountBakiyeFloat) && x.CreditAmountFloat == 0).ToList();

                nlist = nlist.Where(x => nnlist.Contains(x.AccountMainIDMain)).OrderBy(x => x.AccountMainID).ToList();
                List<string> chkList = nlist.Where(y => y.CreditBakiye != null && y.CreditBakiye != "").Select(x => x.CreditBakiye).ToList();

                List<string> uniquechkList = chkList.Distinct().ToList();

                if ((chkList.Count / 10) > uniquechkList.Count)
                {
                    foreach (XmlExcel cust in nlist)
                    {
                        cust.CreditBakiye = "0";
                        //cust.DebitBakiye = "0";
                    }
                }
                //nlist = nlist.Except(tlista);
                List<XmlExcel> cchklist = nlist.Where(x => x.TextCount == 3).ToList();
                cchklist = cchklist.GroupBy(i => i.AccountMainID)
                                   .Select(g => g.First())
                                   .ToList();

                List<XmlExcel> cchklist1 = nlist.Where(x => x.TextCount >= 5).ToList();

                //cchklist = cchklist.OrderBy(x => x.AccountMainID).ToList();
                //cchklist1 = cchklist1.Where(x =>  (x.CreditAmountFloat == x.DebitAmountFloat )&&  x.CreditAmountFloat == 0).ToList();
                //cchklist = cchklist.Where(x =>  (x.CreditAmountFloat == x.DebitAmountFloat) && x.CreditAmountFloat == 0).ToList();
                var tlist = Data.SetBilancoFromListMizanExcel(cchklist, CompID, nYear, nmonth);
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
                    ReportSetMainAktarma.Set_MizanSubSetfirst(nYear, CompID);
                }

                if (tlist.Count > 0)
                {
                    Data.InsertDataMizan(tlist);
                }
                else
                {
                    Data.SET_MIZANHEADER(nYear, CompID);
                }
                ReportSetMainAktarma.Set_ReportTBAFirst(nYear, CompID);
                ReportSetMainAktarma.Set_ReportTBAFirstMonthly(nYear, CompID);
                List<DashBilancoViewMizan> nRequestList1 = DashBilancoMizan.getList(nYear, CompID);
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
                var resuktCount = DashRasyoMizan.GetCheckMizanStatus(nYear, CompID, nmonth);
                if (resuktCount < 5)
                {

                    return new JsonResult("nok");
                }

            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = CompID;
                lg.CsvID = nYear;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                return new JsonResult(ex.Message.ToString());
            }

            return new JsonResult("ok");
        }

        [HttpPost("mizancreatereport")]
        public JsonResult Datmizancreatereport([FromBody] RequestCreateReport reg)
        {

            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));

            string compnacecode = "2790";
            try
            {
                Companies curCompany = Companies.Get_CompanyRow(reg.CompanyID);
                List<int> curCompanyYearList = Companies.Get_CompanyReportYearMainMizan(reg.CompanyID);
                curCompanyYearList.Sort();
                int nyear = curCompanyYearList.Max();

                var codde = NaceCode.GetRow_NaceCodes(reg.NaceCode);
                if (!string.IsNullOrEmpty(curCompany.NaceCode) && !string.IsNullOrWhiteSpace(curCompany.NaceCode))
                {
                    compnacecode = curCompany.NaceCode.Replace(".", "").Substring(0, 4);
                }
                var str = DateTime.Now.ToString("yyyyMMddHHmm");
                string NewRepName = "FinansalDurumRapor-" + str + curCompany.TaxID.ToString() + ".pdf";
                var FileDocz = "FileContent/" + NewRepName;
                var FileDic = "wwwroot\\FileContent\\" + NewRepName;

                string filePathZ = WebHelper.path;
                string FilePath = System.IO.Path.Combine(filePathZ, FileDic);

                if (curCompanyYearList.Count >= 4)
                {
                    DynamicReportfour report = ReportCheckZoneMain.getReportMizanFour(curCompany.ID, codde.ID.ToString(), 111, curCompanyYearList);
                    report.CreateDocument();
                    report.ExportToPdf(FilePath);

                    CompanyQnbReport.Set_Report(reg.CompanyID, 1111, NewRepName);
                }
                else
                {
                    DynamicReport report = ReportCheckZoneMain.getReportMizan(curCompany.ID, codde.ID.ToString(), 111, curCompanyYearList);
                    report.CreateDocument();
                    report.ExportToPdf(FilePath);

                    CompanyQnbReport.Set_Report(reg.CompanyID, 1111, NewRepName);
                }

            }
            catch (Exception ex)
            {

                return new JsonResult(ex.Message);
            }

            return new JsonResult("ok");
        }

        [HttpPost("mizandashboard")]
        public JsonResult Datamizandashboard([FromBody] RequestMizanMain reg)
        {

            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
            IEnumerable<YearlyReportDashMizan> dashEbitMarjin;
            string CompName;
            IEnumerable<YearlyReportDashMizan> dashGrossProfit;
            IEnumerable<YearlyReportDashMizan> dashRevenue;
            IEnumerable<YearlyReportDashMizan> dashDonemselKarzarar;
            IEnumerable<YearlyReportDashMizan> dashWorkingCapital;
            IEnumerable<YearlyReportDashMizanGrap> dDashFrossViewMarjBrut;
            dashGrossProfit = ReportDashMizan.Get_Data_GrossProfit(reg.CompanyID).Where(x => x.Amount != 0);
            dashRevenue = ReportDashMizan.Get_Data_Revenue(reg.CompanyID).Where(x => x.Amount != 0);
            dashDonemselKarzarar = ReportDashMizan.Get_Data_DonemselKarzarar(reg.CompanyID).Where(x => x.Amount != 0);
            dashEbitMarjin = ReportDashMizan.Get_Data_EbitMarjin(reg.CompanyID).Where(x => x.Amount != 0);
            dashWorkingCapital = ReportDashMizan.Get_Data_WorkingCapital(reg.CompanyID).Where(x => x.Amount != 0);
            dDashFrossViewMarjBrut = ReportDashMizan.Get_Data_GrossProfitGraphic(reg.CompanyID).Where(x => x.Amount != 0);
            List<YearlyReportDashMizanMain> nlist = new List<YearlyReportDashMizanMain>();
            nlist.Add(new YearlyReportDashMizanMain(dashRevenue, 1));
            nlist.Add(new YearlyReportDashMizanMain(dashGrossProfit, 3));
            nlist.Add(new YearlyReportDashMizanMain(dashEbitMarjin, 5));
            nlist.Add(new YearlyReportDashMizanMain(dashWorkingCapital, 7));
            nlist.Add(new YearlyReportDashMizanMain(dashDonemselKarzarar, 9));
            nlist.Add(new YearlyReportDashMizanMain(getLongYearValueNew(dDashFrossViewMarjBrut), 11));
            return new JsonResult(nlist);
        }

        [HttpPost("mizanworkingcapital")]
        public JsonResult Datamizanworkingcapital([FromBody] RequestMizan reg)
        {

            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
            List<DashBilancoViewMizan> nRequestList = new List<DashBilancoViewMizan>();
            if (reg.IsForChart)
            {
                List<YearlyReportDashMizan> nRequestLista = ReportDashMizan.Get_Data_WorkingCapital(reg.CompanyID).ToList();
                return new JsonResult(nRequestLista);
            }
            else
            {
                nRequestList = DashWCapitalMizan.Get_getDataWcapFINALMain(reg.CompanyID);
                return new JsonResult(nRequestList);
            }
        }

        [HttpPost("mizanrasyo")]
        public JsonResult Dataelmizanrasyo([FromBody] RequestMizanRasyo reg)
        {

            if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
                return new JsonResult(Unauthorized("No Header"));

            if (apiKey != secretKey)
                return new JsonResult(Unauthorized("Invalid key"));
            List<DashYearlyResultMizan> RasyoAnaliz = RasyoAnalizMainMizan.RasyoAnalizTOTALFinal(2025, reg.CompanyID);
            if (reg.RasyoSortID == 1)
            {
                return new JsonResult(RasyoAnaliz.Where(x => x.TypeID == 1));
            }
            else if (reg.RasyoSortID == 3)
            {
                return new JsonResult(RasyoAnaliz.Where(x => x.TypeID == 2));
            }
            else if (reg.RasyoSortID == 5)
            {
                return new JsonResult(RasyoAnaliz.Where(x => x.TypeID == 3));
            }
            else if (reg.RasyoSortID == 7)
            {

                List<DashYearlyResultMizan> OzetMali = DashOzetMaliMizan.OzetMaliFinal(reg.CompanyID);

                return new JsonResult(OzetMali);
            }
            else
            {
                List<DashYearlyResultMizan> LikiditeRiskTrend = DashLikiditeRiskTrendMizan.LikiditeRiskTrend21Final(reg.CompanyID);
                return new JsonResult(LikiditeRiskTrend);
            }
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {

            return Ok("API working");
        }

        public IEnumerable<YearlyReportDash> getMonthYearValue(IEnumerable<DashYearlyResultMain> nlist)
        {
            var result = nlist.Select(x => new YearlyReportDash(x.Month.Month, Convert.ToInt64(x.Value
                ), x.DocumentMonthTr)).ToList();

            return result;
        }

        public IEnumerable<YearlyReportDash> getMonthYearValueNew(IEnumerable<YearlyReportDashGraphic> nlist)
        {
            var result = nlist.Select(x => new YearlyReportDash(x.MainMonth, Convert.ToInt64(x.TotalGelir
                ), x.DocumentMonthTr)).ToList();

            return result;
        }

        public IEnumerable<YearlyReportDashMizan> getLongYearValueNew(IEnumerable<YearlyReportDashMizanGrap> nlist)
        {
            var result = nlist.Select(x => new YearlyReportDashMizan(x.Year, x.CompanyID, Convert.ToInt64(x.Amount
                ))).ToList();

            return result;
        }

        public List<ReadPdfPg> ReadPdfFile(string fileName)
        {
            List<ReadPdfPg> nlist = new List<ReadPdfPg>();
            ReadPdfPg chkPdf = new ReadPdfPg();
            PdfDocumentProcessor pdfDocumentProcessor = new PdfDocumentProcessor();
            pdfDocumentProcessor.LoadDocument(fileName);
            string[] words;
            string line;
            int countPg = pdfDocumentProcessor.Document.Pages.Count;
            string firstPageText = string.Empty;
            int countre = 0;
            for (int i = 1; i <= countPg; i++)
            {

                firstPageText = pdfDocumentProcessor.GetPageText(i, new PdfTextExtractionOptions { ClipToCropBox = false });

                words = firstPageText.Split('\n');
                for (int j = 0, len = words.Length; j < len; j++)
                {
                    chkPdf = new ReadPdfPg();
                    countre++;
                    line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j]));
                    chkPdf.LineContent = line.Replace("\r", string.Empty);
                    chkPdf.CounterNo = countre;
                    nlist.Add(chkPdf);
                }

            }

            return nlist;
        }

        private static void CopyContentsUntilNull(string filePath)
        {

            string ctrlChar = "\0";
            var xml = System.IO.File.ReadAllText(filePath);
            var fixedXml = xml.Replace(ctrlChar, "").Replace(((char)0x14).ToString(), "");
            System.IO.File.WriteAllText(filePath, fixedXml);
        }

        public static bool IsNumeric(object Expression)
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public static string RemoveEmpty(string str)
        {
            List<string> nlist = str.Split(" ").ToList();
            if (nlist.Count < 3)
            {
                return string.Empty;
            }

            nlist.RemoveAt(nlist.Count - 1);
            nlist.RemoveAt(nlist.Count - 1);
            string s = String.Join(" ", nlist.ToArray());

            if (s.Substring(0, 2) == ". ")
            {
                s = s.Substring(2);
            }

            return s;
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

        public static double RemoveNonNumeric2(string str)
        {
            string[] nlist = str.Split(" ");

            string s = nlist[nlist.Length - 1];

            CultureInfo ci = CultureInfo.GetCultureInfo("tr-TR");
            string chk = string.Empty;
            chk = string.Concat(s?.Where(c => char.IsNumber(c) || c == '.' || c == ',' || c == '-' || c == '(' || c == ')') ?? string.Empty);

            if (chk.Trim().Length < 2 && (chk.Trim() == "-" || chk.Trim() == ")" || chk.Trim() == "(") || chk.Trim().Length < 1)
            {
                chk = "0";
            }

            if (chk.IndexOf("(") >= 0 && chk.IndexOf(")") >= 0)
            {
                chk = chk.Replace("(", "-").Replace(")", string.Empty);

            }
            string addedPoint = string.Empty;
            string addedDecimal = string.Empty;
            chk = chk.Trim();
            if (chk.Length < 2 && chk == "-" || chk.Length < 1)
            {
                chk = "0";
            }

            if (chk.Length >= 2 && chk.Substring(chk.Length - 2, 1) == ",")
            {
                addedPoint = ",";
                addedDecimal = chk.Substring(chk.Length - 1);
                chk = chk.Substring(0, chk.Length - 2);

            }

            if (chk.Length >= 3 && chk.Substring(chk.Length - 3, 1) == ",")
            {
                addedPoint = ",";
                addedDecimal = chk.Substring(chk.Length - 2);
                chk = chk.Substring(0, chk.Length - 3);

            }

            if (chk.Length >= 2 && chk.Substring(chk.Length - 2, 1) == ".")
            {
                addedPoint = ".";
                addedDecimal = chk.Substring(chk.Length - 1);
                chk = chk.Substring(0, chk.Length - 2);

            }

            if (chk.Length >= 3 && chk.Substring(chk.Length - 3, 1) == ".")
            {
                addedPoint = ".";
                addedDecimal = chk.Substring(chk.Length - 2);
                chk = chk.Substring(0, chk.Length - 3);

            }

            chk = chk.Replace(",", string.Empty).Replace(".", string.Empty);
            chk = chk + addedPoint + addedDecimal;
            if (addedPoint.Length > 0)
            {
                chk = chk.Replace(addedPoint,
CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalSeparator);
            }

            try
            {

                var result = double.Parse(chk, NumberStyles.AllowDecimalPoint | NumberStyles.Number, CultureInfo.InvariantCulture);
                return result;
                // return chk.ToDecimalInvariant();// Convert.ToDouble(chk,CultureInfo.InvariantCulture.NumberFormat);

            }
            catch
            {
                var tt = chk;
                return 0;
            }
        }
    }

    public class VknRequestSupplier
    {
        public string Vkn { get; set; }
    }

    public class VknRequestCustomer
    {
        public string Vkn { get; set; }

        public bool IsVolume { get; set; }
    }

    public class RequestEledger
    {
        public long CompanyID { get; set; }

        public int Year { get; set; }

        public bool IsForChart { get; set; }
    }

    public class RequestSso
    {
        public string sso { get; set; }
    }

    public class RequestEledgerRasyo
    {
        public long CompanyID { get; set; }

        public int Year { get; set; }

        public int RasyoSortID { get; set; }
    }

    public class RequestMizanRasyo
    {
        public long CompanyID { get; set; }

        public int RasyoSortID { get; set; }
    }

    public class RequestMizan
    {
        public long CompanyID { get; set; }

        public bool IsForChart { get; set; }
    }

    public class XMlookReq
    {
        public string compid { get; set; }

        public string eledgercounter { get; set; }

        public List<IFormFile> file { get; set; } = new List<IFormFile>();

        public string Ay_Yil { get; set; }
    }

    public class RequestEledgerMain
    {
        public long CompanyID { get; set; }

        public int Year { get; set; }
    }

    public class RequestCreateReport
    {
        public int NaceCode { get; set; }

        public long CompanyID { get; set; }
    }

    public class RequestMizanMain
    {
        public long CompanyID { get; set; }
    }

    public class RequestReport
    {
        public int ReportID { get; set; }
    }
}
