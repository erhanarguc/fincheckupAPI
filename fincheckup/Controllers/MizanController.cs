using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.Pdf;
using fincheckup.ENTITY;
using fincheckup.Helper;
using fincheckup.Models.Apinet;
using fincheckup.Models.EarlyWarning.Response;
using fincheckup.Models.Mizan;
using fincheckup.Models.NKolay;
using fincheckup.Models.NKolay.ENTITY;
using fincheckup.Models.NKolay.ENTITY.Beyanname;
using fincheckup.Models.NKolay.json;
using fincheckup.Models.NKolay.MizanView;
using fincheckup.Models.NKolay.ViewM;
using fincheckup.Models.txtsharp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace fincheckup.Controllers
{
    [Route("JsonService/Mizan/[action]")]
    public class MizanController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;

        public MizanController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }
       
        public async Task<JsonResult> moodUploadMznCkeckPDFUpdate(XMlook pageIndex)
        {
            long CompID = Convert.ToInt64(pageIndex.ide);
            var file = pageIndex.file;
            string filePath = string.Empty;
            string folderPath = string.Empty;
            string folderPathsub = string.Empty;
            string filePathzet = string.Empty;
            List<string> nlistZipurl = new List<string>();
            string uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            byte nmonth = Convert.ToByte(pageIndex.Caption.Split('_')[0]);
            Random rnd = new Random();
            int month = rnd.Next(10000000, 99999999);
            int nYear = pageIndex.id;
            if (file != null && file.Count > 0)
            {
                foreach (var item in file)
                {
                    //filePath = System.IO.Path.Combine(uploads, Guid.NewGuid().ToString() + System.IO.Path.GetExtension(item.FileName)); tables
                    filePath = System.IO.Path.Combine(uploads, month.ToString() + "-"+ nYear.ToString() + System.IO.Path.GetExtension(item.FileName));
                    folderPath = System.IO.Path.Combine(uploads, month.ToString() + "-" + nYear.ToString());
                    folderPathsub = System.IO.Path.Combine(folderPath, "tables");
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    if (System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.Delete(folderPath);
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                        System.IO.Directory.CreateDirectory(folderPathsub);
                    }
                    //filePathzet = System.IO.Path.Combine(uploads, Guid.NewGuid().ToString()) + ".pdf";
                    filePathzet = System.IO.Path.Combine(uploads, month.ToString() + "-"+  nYear.ToString() + ".zip");
                    if (System.IO.File.Exists(filePathzet))
                    {
                        System.IO.File.Delete(filePathzet);
                    }
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream).ConfigureAwait(false);
                    }

                }

            }

            try
            {
                ConnectApi ntake = new ConnectApi();
                var result = await ntake.SendApi(pageIndex, filePath);
                var resulrret = await ntake.getFileApi(month.ToString() + "-" + nYear.ToString() + ".zip");
                var reminderAccount = JsonConvert.DeserializeObject<ReturnMainPDF>(resulrret);

                System.IO.File.WriteAllBytes(filePathzet, Convert.FromBase64String(reminderAccount.payload.ToString()));
                using (ZipArchive archive = ZipFile.OpenRead(filePathzet))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        entry.ExtractToFile(System.IO.Path.Combine(folderPath, entry.FullName));
                    }
                }
              
                string[] files = Directory.GetFiles(folderPath, "*.xlsx", SearchOption.AllDirectories);
                ///folderPath
                //folderPath = @"C:\PRO\fincheckup\fincheckup\wwwroot\uploads\65073418-2023\tables";
                ////string[] files = Directory.GetFiles(folderPath, "*.xlsx", SearchOption.AllDirectories);
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

                foreach (var itemz in files)
                {

                    DataTable dt = ExcelHelper.ExcelToDataTable(itemz);
                    IEnumerable<XmlExcel> nlist = ExcelHelper.CheckColumnPdfExcel(dt);
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
                    }


                    if (tlist.Count > 0)
                    {
                        Data.InsertDataMizan(tlist);
                    }
                    else
                    {
                        //Data.SET_MIZANHEADER(nYear, CompID);
                    }



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

            }
            catch (Exception ex)
            {
                var tyty = ex;
                throw;
            }
           

           
            return Json("ok");
            ////int nYear = pageIndex.id; List<List<string>> pdfxcllista = new List<List<string>>();
            //List<string> pdfxcllist = new List<string>();
            //try
            //{
            //    //var ttttt = ReadPdfFile(filePath);

            //    //foreach (var item in ttttt)
            //    //{
            //    //    string chkkkkssd = item.LineContent;
            //    //    string sep = "\t";
            //    //    string[] splitContent = chkkkkssd.Split(sep.ToCharArray());
            //    //    string[] chklist = chkkkkssd.Split(' ');

            //    //}

            //    //var CHKgROUP = ReadPdfFile(filePath, CompID, nYear, nmonth);

            //    var ttttt = ReadPdfFile(filePath);

            //    foreach (var item in ttttt)
            //    {
            //        string chkkkkssd = item.LineContent;
            //        string sep = "\t";
            //        string[] splitContent = chkkkkssd.Split(sep.ToCharArray());
            //        //string[] chklist = chkkkkssd.Split(' ');
            //        pdfxcllist = new List<string>();
            //        pdfxcllist = chkkkkssd.Split(' ').ToList();
            //        pdfxcllista.Add(pdfxcllist);
            //    }

            //    List<TBLXMLSCheckpdfMizan> ndroor = new List<TBLXMLSCheckpdfMizan>();

            //    foreach (var item in pdfxcllista)
            //    {
            //        ndroor.Add(checkStrList(item));
            //    }
            //    var tt = ndroor;
            //    //

            //    ndroor.Select(c => { c.CompanyID = CompID; return c; }).ToList();
            //    ndroor.Select(c => { c.MainMonth = nmonth; return c; }).ToList();
            //    ndroor.Select(c => { c.Year = nYear; return c; }).ToList();
            //    var chkyyyu = Data.SetBilancoFromListMizanExcelPdf(ndroor);

          
            //    Data.InsertDataMizanPdf(chkyyyu);
            //    List<TBLXMLSCheckpdfMizan> ndroorcheck = TBLXMLSCheckpdfMizan.Get_TBLXMLSCheckpdfMizanCount(CompID, nYear, nmonth);
            //    int countal = ndroorcheck.Count();
            //    int counemty = ndroorcheck.Where(x => x.Amount1 == 0 && x.Amount2 == 0).Count();
            //    if (counemty != 0 && countal != 0 && counemty > (countal / 4))
            //    {
            //        var CHKgROUP = ReadPdfFile(filePath, CompID, nYear, nmonth);
            //    }
            //    else
            //    {
            //        TBLXMLSCheckpdfMizan.LastRepByCompanyIDn(nYear, CompID, nmonth, 3);

            //    }


            //    TBLMizan ncs = new TBLMizan();
            //    ncs.CompanyID = CompID;
            //    ncs.CreatedDate = DateTime.Now;
            //    ncs.DocumentDate = new DateTime(nYear, 12, 12); ;
            //    ncs.CsvName = filePath;
            //    ncs.MainMonth = nmonth;
            //    ncs.Year = nYear;
            //    ncs.Save_TBLMizan();


            //    List<DashBilancoViewMizan> nRequestList1 = DashBilancoMizan.getList(nYear, CompID);
            //    var tlist1 = Data.SetBilancoFromListMizan(nRequestList1, CompID, nYear);
            //    Data.RESET_DashBilancoViewMizan(nYear, CompID);
            //    Data.InsertBilncoMzn(tlist1);
            //    List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizan.getList(nYear, CompID);
            //    var tlistRvn1 = Data.SetBilancoFromListMizan(nRequestListRvn1, CompID, nYear);
            //    Data.RESET_REVENUEViewMzn(nYear, CompID);
            //    Data.InsertRvnMzn(tlistRvn1);
            //    var WLikiditeViez = DashLikiditeViewMainMizan.getList(nYear, CompID);
            //    var WCapitalViez = DashWCapitalViewMainMizan.getList(nYear, CompID);
            //    var WCapitalVie = Data.SetBilancoFromListMizan(WCapitalViez, CompID, nYear);
            //    var WLikiditeVie = Data.SetBilancoFromListMizan(WLikiditeViez, CompID, nYear);
            //    Data.InsertWCapitalMzn(WCapitalVie);
            //    Data.InsertLiquidityMzn(WLikiditeVie);
            //    DashBilancoSetMizan.Set_ReportSetMainSMM(nYear, CompID);
            //    DashRasyoMizan.GetDashRasyoAnaliz(nYear, CompID);
            //    DashRasyoMizan.GetDashLikiditeRiskTrend(nYear, CompID);
            //    DashRasyoMizan.GetDashOzetMali(nYear, CompID);



            //}
            //catch (Exception ex)
            //{
            //    ERRLOG lg = new ERRLOG();
            //    lg.CompanyID = CompID;
            //    lg.CsvID = nYear;
            //    lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
            //    return Json("nok");
            //}

            //return Json("ok");




        }



        public async Task<JsonResult> moodUploadMznCkeckPDF(XMlook pageIndex)
        {
            string filePath = string.Empty;
            string folderPath = string.Empty;
            string folderPathsub = string.Empty;
            string filePathzet = string.Empty;
            var file = pageIndex.file;
            List<string> nlistZipurl = new List<string>();
            Random rnd = new Random();
            int rndmonth = rnd.Next(10000000, 99999999);
            string uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            byte nmonth = Convert.ToByte(pageIndex.Caption.Split('_')[0]);
            //if (file != null && file.Count > 0)
            //{
            //    foreach (var item in file)
            //    {
            //        filePath = System.IO.Path.Combine(uploads, Guid.NewGuid().ToString() + System.IO.Path.GetExtension(item.FileName));
            //        filePathzet = System.IO.Path.Combine(uploads, Guid.NewGuid().ToString()) + ".pdf";
            //        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            //        {
            //            await item.CopyToAsync(fileStream).ConfigureAwait(false);
            //        }

            //    }

            //}

            long CompID = Convert.ToInt64(pageIndex.ide);
            int nYear = pageIndex.id; List<List<string>> pdfxcllista = new List<List<string>>();
            List<string> pdfxcllist = new List<string>();

            if (file != null && file.Count > 0)
            {
                foreach (var item in file)
                {
                    //filePath = System.IO.Path.Combine(uploads, Guid.NewGuid().ToString() + System.IO.Path.GetExtension(item.FileName)); tables
                    filePath = System.IO.Path.Combine(uploads, rndmonth.ToString() + "-" + nYear.ToString() + System.IO.Path.GetExtension(item.FileName));
                    folderPath = System.IO.Path.Combine(uploads, rndmonth.ToString() + "-" + nYear.ToString());
                    folderPathsub = System.IO.Path.Combine(folderPath, "tables");
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    if (System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.Delete(folderPath);
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                        System.IO.Directory.CreateDirectory(folderPathsub);
                    }
                    //filePathzet = System.IO.Path.Combine(uploads, Guid.NewGuid().ToString()) + ".pdf";
                    filePathzet = System.IO.Path.Combine(uploads, rndmonth.ToString() + "-" + nYear.ToString() + ".zip");
                    if (System.IO.File.Exists(filePathzet))
                    {
                        System.IO.File.Delete(filePathzet);
                    }
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream).ConfigureAwait(false);
                    }

                }

            }

            try
            {
                ConnectApi ntake = new ConnectApi();
                var result = await ntake.SendApi(pageIndex, filePath);
                var resulrret = await ntake.getFileApi(rndmonth.ToString() + "-" + nYear.ToString() + ".zip");
                var reminderAccount = JsonConvert.DeserializeObject<ReturnMainPDF>(resulrret);

                System.IO.File.WriteAllBytes(filePathzet, Convert.FromBase64String(reminderAccount.payload.ToString()));
                using (ZipArchive archive = ZipFile.OpenRead(filePathzet))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        entry.ExtractToFile(System.IO.Path.Combine(folderPath, entry.FullName));
                    }
                }

                string[] files = Directory.GetFiles(folderPath, "*.xlsx", SearchOption.AllDirectories);
                ///folderPath
                //folderPath = @"C:\PRO\fincheckup\fincheckup\wwwroot\uploads\65073418-2023\tables";
                ////string[] files = Directory.GetFiles(folderPath, "*.xlsx", SearchOption.AllDirectories);
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
                foreach (var itemz in files)
                {

                    DataTable dt = ExcelHelper.ExcelToDataTable(itemz);
                    IEnumerable<XmlExcel> nlist = ExcelHelper.CheckColumnPdfExcel(dt);
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
                    }


                    if (tlist.Count > 0)
                    {
                        Data.InsertDataMizan(tlist);
                    }
                    else
                    {
                        //Data.SET_MIZANHEADER(nYear, CompID);
                    }



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

            }
            catch (Exception ex)
            {
                var tyty = ex;
                throw;
            }
            //try
            //{
            //    //var ttttt = ReadPdfFile(filePath);

            //    //foreach (var item in ttttt)
            //    //{
            //    //    string chkkkkssd = item.LineContent;
            //    //    string sep = "\t";
            //    //    string[] splitContent = chkkkkssd.Split(sep.ToCharArray());
            //    //    string[] chklist = chkkkkssd.Split(' ');

            //    //}

            //    //var CHKgROUP = ReadPdfFile(filePath, CompID, nYear, nmonth);

            //    var ttttt = ReadPdfFile(filePath);

            //    foreach (var item in ttttt)
            //    {
            //        string chkkkkssd = item.LineContent;
            //        string sep = "\t";
            //        string[] splitContent = chkkkkssd.Split(sep.ToCharArray());
            //        //string[] chklist = chkkkkssd.Split(' ');
            //        pdfxcllist = new List<string>();
            //        pdfxcllist = chkkkkssd.Split(' ').ToList();
            //        pdfxcllista.Add(pdfxcllist);
            //    }

            //    List<TBLXMLSCheckpdfMizan> ndroor = new List<TBLXMLSCheckpdfMizan>();

            //    foreach (var item in pdfxcllista)
            //    {
            //        ndroor.Add(checkStrList(item));
            //    }
            //    var tt = ndroor;
            //    //

            //    ndroor.Select(c => { c.CompanyID = CompID; return c; }).ToList();
            //    ndroor.Select(c => { c.MainMonth = nmonth; return c; }).ToList();
            //    ndroor.Select(c => { c.Year = nYear; return c; }).ToList();
            //    var chkyyyu = Data.SetBilancoFromListMizanExcelPdf(ndroor);


            //    Data.InsertDataMizanPdf(chkyyyu);
            //    List<TBLXMLSCheckpdfMizan> ndroorcheck = TBLXMLSCheckpdfMizan.Get_TBLXMLSCheckpdfMizanCount(CompID, nYear, nmonth);
            //    int countal = ndroorcheck.Count();
            //    int counemty = ndroorcheck.Where(x => x.Amount1 == 0 && x.Amount2 == 0).Count();
            //    if (counemty != 0 && countal != 0 && counemty > (countal / 4))
            //    {
            //        var CHKgROUP = ReadPdfFile(filePath, CompID, nYear, nmonth);
            //    }
            //    else
            //    {
            //        TBLXMLSCheckpdfMizan.LastRepByCompanyIDn(nYear, CompID, nmonth, 3);

            //    }




            //    TBLMizan ncs = new TBLMizan();
            //    ncs.CompanyID = CompID;
            //    ncs.CreatedDate = DateTime.Now;
            //    ncs.DocumentDate = new DateTime(nYear, 12, 12); ;
            //    ncs.CsvName = filePath;
            //    ncs.Year = nYear; ncs.MainMonth = nmonth;
            //    ncs.Save_TBLMizan();

            //    List<DashBilancoViewMizan> nRequestList1 = DashBilancoMizan.getList(nYear, CompID);
            //    var tlist1 = Data.SetBilancoFromListMizan(nRequestList1, CompID, nYear);
            //    Data.RESET_DashBilancoViewMizan(nYear, CompID);
            //    Data.InsertBilncoMzn(tlist1);
            //    List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizan.getList(nYear, CompID);
            //    var tlistRvn1 = Data.SetBilancoFromListMizan(nRequestListRvn1, CompID, nYear);
            //    Data.RESET_REVENUEViewMzn(nYear, CompID);
            //    Data.InsertRvnMzn(tlistRvn1);
            //    var WLikiditeViez = DashLikiditeViewMainMizan.getList(nYear, CompID);
            //    var WCapitalViez = DashWCapitalViewMainMizan.getList(nYear, CompID);
            //    var WCapitalVie = Data.SetBilancoFromListMizan(WCapitalViez, CompID, nYear);
            //    var WLikiditeVie = Data.SetBilancoFromListMizan(WLikiditeViez, CompID, nYear);
            //    Data.InsertWCapitalMzn(WCapitalVie);
            //    Data.InsertLiquidityMzn(WLikiditeVie);
            //    DashBilancoSetMizan.Set_ReportSetMainSMM(nYear, CompID);
            //    DashRasyoMizan.GetDashRasyoAnaliz(nYear, CompID);
            //    DashRasyoMizan.GetDashLikiditeRiskTrend(nYear, CompID);
            //    DashRasyoMizan.GetDashOzetMali(nYear, CompID);




            //}
            //catch (Exception ex)
            //{
            //    ERRLOG lg = new ERRLOG();
            //    lg.CompanyID = CompID;
            //    lg.CsvID = nYear;
            //    lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
            //    return Json("nok");
            //}

            return Json("ok");




        }

        public async Task<JsonResult> moodUploadMznCkeck(XMlook pageIndex)
        {

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

            long CompID = Convert.ToInt64(pageIndex.ide);
            int nYear = pageIndex.id;
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
                List<XmlExcel> cchklist = nlist.Where(x => x.TextCount == 3).ToList();
                List<XmlExcel> cchklist1 = nlist.Where(x => x.TextCount >= 6).ToList();

                int fcount = cchklist.Where(x => x.CreditAmountFloat == 0).Count();

                int tcount = cchklist.Where(x => x.DebitAmountFloat == 0).Count();
                int chkcount = cchklist.Count();

                if (chkcount == tcount && chkcount > 1)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Mizan Şablon Hatası"; lg.Save_AppLogs();
                    return Json("lock");
                }

                if (chkcount == fcount && chkcount > 1)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Mizan Şablon Hatası"; lg.Save_AppLogs();
                    return Json("lock");
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
                        return Json("nok");
                    }

                }



            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = CompID;
                lg.CsvID = nYear;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                return Json("nok");
            }

            return Json("ok");




        }
        public async Task<JsonResult> moodUploadMzn(XMlook pageIndex)
        {

            var file = pageIndex.file;
            string filePath = string.Empty;
            List<string> nlistZipurl = new List<string>();
            string uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            int nmonth = Convert.ToInt32(pageIndex.Caption.Split('_')[0]);
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

            long CompID = Convert.ToInt64(pageIndex.ide);
            int nYear = pageIndex.id;
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

                //List<string> tcheck= nnlistcheck.ex(x=> nnlistsix.Contains())
                //cchklist1 = cchklist1.Where(x =>  (x.CreditAmountFloat == x.DebitAmountFloat )&&  x.CreditAmountFloat == 0).ToList();
                //cchklist = cchklist.Where(x =>  (x.CreditAmountFloat == x.DebitAmountFloat) && x.CreditAmountFloat == 0).ToList();
                var tlist = Data.SetBilancoFromListMizanExcel(cchklist, CompID, nYear,nmonth);
               
                if (cchklist1.Count > 0)
                {
                    var tlistsub = Data.SetBilancoFromListMizanExcelSub(cchklist1, CompID, nYear);
                    Data.InsertDataMizanSub(tlistsub);
                }

                if (tlist.Count > 0)
                {
                    Data.InsertDataMizan(tlist);
                }
                else
                {
                    Data.SET_MIZANHEADER(nYear, CompID);
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
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = CompID;
                lg.CsvID = nYear;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                return Json(ex.ToString());
            }

            return Json("ok");




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


        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [RequestSizeLimit(209715200)]
        public async Task<JsonResult> moodUploadUpdateMzn(XMlook pageIndex)
        {



            long CompID = Convert.ToInt64(pageIndex.ide);
            int nYear = pageIndex.id;
            var file = pageIndex.file;
            string filePath = string.Empty;
            string uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            int nmonth = Convert.ToInt32(pageIndex.Caption.Split('_')[0]);
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

                DashBilancoSetMizan.Set_ReportSetResetMizanKayit(nYear, CompID);
                if (cchklist1.Count > 0)
                {
                    var tlistsub = Data.SetBilancoFromListMizanExcelSub(cchklist1, CompID, nYear);
                    Data.InsertDataMizanSub(tlistsub);
                }


                if (tlist.Count > 0)
                {
                    Data.InsertDataMizan(tlist);
                }
                else
                {
                    Data.SET_MIZANHEADER(nYear, CompID);
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

            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = CompID;
                lg.CsvID = nYear;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                return Json(ex.ToString());
            }

            return Json("ok");



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
        private string ConvertDatum(string datta)
        {
            string[] listo = datta.Substring(0, 10).Replace("-", ".").Replace("/", ".").Split('.');
            return listo[0] + "." + listo[2] + '.' + listo[1];
        }
        public JsonResult moodUpdatesmm(XMlookUpdate pageIndex)
        {
            if (!ModelState.IsValid)
            {

                return Json("nok");
            }

            try
            {

                DashBilancoSetMizan.SET_Stat(pageIndex.year, pageIndex.companyid, pageIndex.month);
                List<DashBilancoViewMizan> nRequestList = DashBilancoMizan.getList(pageIndex.year, -1 * pageIndex.companyid);
                var tlist = Data.SetBilancoFromListMizan(nRequestList, -1 * pageIndex.companyid, pageIndex.year);
                Data.RESET_DashBilancoViewMizan(pageIndex.year, -1 * pageIndex.companyid);
                Data.InsertBilncoMzn(tlist);
                List<DashBilancoViewMizan> nRequestListRvn = DashGelirTablosuMizan.getList(pageIndex.year, -1 * pageIndex.companyid);
                var tlistRvn = Data.SetBilancoFromListMizan(nRequestListRvn, -1 * pageIndex.companyid, pageIndex.year);
                Data.RESET_REVENUEViewMzn(pageIndex.year, -1 * pageIndex.companyid);
                Data.InsertRvnMzn(tlistRvn);


                List<DashBilancoViewMizan> nRequestList1 = DashBilancoMizan.getList(pageIndex.year, pageIndex.companyid);
                var tlist1 = Data.SetBilancoFromListMizan(nRequestList1, pageIndex.companyid, pageIndex.year);
                Data.RESET_DashBilancoViewMizan(pageIndex.year, pageIndex.companyid);
                Data.InsertBilncoMzn(tlist1);
                List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizan.getList(pageIndex.year, pageIndex.companyid);
                var tlistRvn1 = Data.SetBilancoFromListMizan(nRequestListRvn1, pageIndex.companyid, pageIndex.year);
                Data.RESET_REVENUEViewMzn(pageIndex.year, pageIndex.companyid);
                Data.InsertRvnMzn(tlistRvn1);
                DashBilancoSetMizan.Set_ReportSetMainSMM(pageIndex.year, -1 * pageIndex.companyid);
            }
            catch (Exception ex)
            {

                return Json("nok_" + ex.ToString());
            }



            return Json("ok");


        }
        public JsonResult moodUpdatesaktarma(XMlookUpdate pageIndex)
        {
            if (!ModelState.IsValid)
            {

                return Json("nok");
            }

            try
            {

                ReportSetMain.StartCompanyAktarma(pageIndex.year, pageIndex.companyid);

                return Json("ok");
            }
            catch (Exception ex)
            {

                return Json("nok_" + ex.ToString());
            }





        }
        public JsonResult moodUpdatesaktarmamzn(XMlookUpdate pageIndex)
        {
            if (!ModelState.IsValid)
            {

                return Json("nok");
            }

            try
            {

                ReportSetMain.StartCompanyAktarmaMizan(pageIndex.year, pageIndex.companyid);

                return Json("ok");
            }
            catch (Exception ex)
            {

                return Json("nok_" + ex.ToString());
            }





        }


        public JsonResult moodUpdatesaktarmaselected(XMlookUpdate pageIndex)
        {
            if (!ModelState.IsValid)
            {

                return Json("nok");
            }

            try
            {

                if (pageIndex.caplist == null)
                {
                    return Json("nok");

                }

                string[] nlist = pageIndex.caplist.Split(',');

                if (nlist.Length < 1)
                {
                    return Json("nok");

                }

                List<int> nlistint = nlist.Select(int.Parse).ToList();
                var currentUploadM = ReportSetMain.Get_CompanyAktarmaResult(pageIndex.year, pageIndex.companyid);
                var lastlist = currentUploadM.Where(x => nlistint.Contains(x.TypeID));
                var checklist = lastlist.Where(x => x.CheckValue != null && x.CheckValue != 0).ToList();
                List<DashAktarma> lastset = lastlist.Where(x => x.Value != 0).ToList();
                lastset.AddRange(checklist);

                List<int> nlistintlast = lastset.Select(x => x.TypeID).Distinct().ToList();

                DashAktarma.UpdateIsChecked(pageIndex.companyid, pageIndex.year,  nlistintlast.ToArray());
                ReportSetMainAktarma.Set_ReportStartAktarma(pageIndex.year, pageIndex.companyid, nlistintlast);
                TBLXmJournalFile.Delete_AllbyCompanyID(pageIndex.companyid, pageIndex.year);
                long ide = -1000000 * pageIndex.companyid;
                int chk = BeyannameChk.Get_BeyannameCountChk(pageIndex.companyid, pageIndex.year);
                List<DashBilancoViewMizan> nRequestList = DashBilancoMizanDefter.getList(pageIndex.year, ide, chk);
                var tlist = Data.SetBilancoFromListMizan(nRequestList, ide, pageIndex.year);
                Data.RESET_DashBilancoViewMizan(pageIndex.year, ide);
                Data.InsertBilncoMzn(tlist);
                List<DashBilancoViewMizan> nRequestListRvn = DashGelirTablosuMizanDefter.getList(pageIndex.year, ide);
                var tlistRvn = Data.SetBilancoFromListMizan(nRequestListRvn, ide, pageIndex.year);
                Data.RESET_REVENUEViewMzn(pageIndex.year, ide);
                Data.InsertRvnMzn(tlistRvn);
                 
                List<DashBilancoViewMizan> nRequestList1 = DashBilancoMizanDefter.getList(pageIndex.year, pageIndex.companyid, chk);
                var tlist1 = Data.SetBilancoFromListMizan(nRequestList1, pageIndex.companyid, pageIndex.year);
                Data.RESET_DashBilancoViewMizan(pageIndex.year, pageIndex.companyid);
                Data.InsertBilncoMzn(tlist1);
                List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizanDefter.getList(pageIndex.year, pageIndex.companyid);
                var tlistRvn1 = Data.SetBilancoFromListMizan(nRequestListRvn1, pageIndex.companyid, pageIndex.year);
                Data.RESET_REVENUEViewMzn(pageIndex.year, pageIndex.companyid);
                Data.InsertRvnMzn(tlistRvn1);
                DashOzetMaliMizan.ClearFibaPr(pageIndex.companyid);

                return Json("ok");
            }
            catch (Exception ex)
            {

                return Json("nok_" + ex.ToString());
            }





        } 
        public JsonResult moodUpdatesaktarmaselectedmzn(XMlookUpdate pageIndex)
        {
            if (!ModelState.IsValid)
            {

                return Json("nok");
            }

            try
            {

                if (pageIndex.caplist == null)
                {
                    return Json("nok");

                }

                string[] nlist = pageIndex.caplist.Split(',');

                if (nlist.Length < 1)
                {
                    return Json("nok");

                }

                List<int> nlistint = nlist.Select(int.Parse).ToList();
                var currentUploadM = ReportSetMain.Get_CompanyAktarmaResult(pageIndex.year, pageIndex.companyid);
                var lastlist = currentUploadM.Where(x => nlistint.Contains(x.TypeID));
                var checklist = lastlist.Where(x => x.CheckValue != null && x.CheckValue != 0).ToList();
                List<DashAktarma> lastset = lastlist.Where(x => x.Value != 0).ToList();
                lastset.AddRange(checklist);

                List<int> nlistintlast = lastset.Select(x => x.TypeID).Distinct().ToList();
                //ReportSetMainAktarma.Set_ReportSetfirst(pageIndex.year, pageIndex.companyid);
                ReportSetMainAktarma.Set_ReportStartAktarma(pageIndex.year, pageIndex.companyid, nlistintlast);
                List<DashBilancoViewMizan> nRequestList = new List<DashBilancoViewMizan>();
                TBLXmJournalFile.Delete_AllbyCompanyID(pageIndex.companyid, pageIndex.year);
                long ide = -1000000 * pageIndex.companyid;
                int chk = BeyannameChk.Get_BeyannameCountChk(pageIndex.companyid, pageIndex.year);
                if (chk > 0)
                {
                    nRequestList = DashBilancoMizan.getListbynmizan(pageIndex.year, ide);
                }
                else
                {
                    nRequestList = DashBilancoMizan.getListbynmizan(pageIndex.year, ide, 1);
                }

                var tlist = Data.SetBilancoFromListMizan(nRequestList, ide, pageIndex.year);
                Data.RESET_DashBilancoViewMizan(pageIndex.year, ide);
                Data.InsertBilncoMzn(tlist);
                List<DashBilancoViewMizan> nRequestListRvn = DashGelirTablosuMizan.getList(pageIndex.year, ide);
                var tlistRvn = Data.SetBilancoFromListMizan(nRequestListRvn, ide, pageIndex.year);
                Data.RESET_REVENUEViewMzn(pageIndex.year, ide);
                Data.InsertRvnMzn(tlistRvn);

                //List<DashBilancoViewMizan> nRequestList1 = DashBilancoMizan.getList(pageIndex.year, pageIndex.companyid);
                //var tlist1 = Data.SetBilancoFromListMizan(nRequestList1, pageIndex.companyid, pageIndex.year);
                //Data.RESET_DashBilancoViewMizan(pageIndex.year, pageIndex.companyid);
                //Data.InsertBilncoMzn(tlist1);
                //List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizan.getList(pageIndex.year, pageIndex.companyid);
                //var tlistRvn1 = Data.SetBilancoFromListMizan(nRequestListRvn1, pageIndex.companyid, pageIndex.year);
                //Data.RESET_REVENUEViewMzn(pageIndex.year, pageIndex.companyid);
                //Data.InsertRvnMzn(tlistRvn1);

                return Json("ok");
            }
            catch (Exception ex)
            {

                return Json("nok_" + ex.ToString());
            }





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
        public List<ReadPdfMizan> ReadPdfFile(string fileName, long compid, int nyear, byte nmonth)
        {
            List<ReadPdfMizan> nlist = new List<ReadPdfMizan>();
            ReadPdfMizan chkPdf = new ReadPdfMizan();
            PdfDocumentProcessor pdfDocumentProcessor = new PdfDocumentProcessor();
            pdfDocumentProcessor.LoadDocument(fileName);
            string[] words; string[] wordschk;
            string line;
            int chrCtountere = 0;
            int countPg = pdfDocumentProcessor.Document.Pages.Count;
            string firstPageText = string.Empty;
            int countre = 0;
            bool nvrnmnd = false;
            //PSDocument document = PSDocument.load(fileName);
            //PDFTextStripper stripper = new PDFTextStripper();
            //stripper.setSortByPosition(true);
            //var chkk = stripper.getText(document);
            //string firstPageTextx = "";
            List<Checkpdf> nlisttttt = new List<Checkpdf>();
            List<List<Checkpdf>> nlistttttM = new List<List<Checkpdf>>();
            Checkpdf cp = new Checkpdf();
            bool omklyop = false;
            using (PdfDocumentProcessor processor = new PdfDocumentProcessor())
            {
                processor.LoadDocument(fileName);

                string ttxta = "";
                for (int i = 0; i < countPg; i++)
                {
                    nlisttttt = new List<Checkpdf>();
                    using (PdfDocumentProcessor target = new PdfDocumentProcessor())
                    {
                        if (System.IO.File.Exists(@"ExtractedFirstPage.pdf"))
                        {
                            System.IO.File.Delete(@"ExtractedFirstPage.pdf");
                        }

                        target.CreateEmptyDocument("ExtractedFirstPage.pdf");
                        target.Document.Pages.Add(processor.Document.Pages[i]);

                        PdfWord currentWord = target.NextWord();
                        while (currentWord != null)
                        {
                            cp = new Checkpdf();


                            if (currentWord != null)
                            {
                                cp.txtWord = currentWord.Text.ToString();
                                cp.txtLeft = currentWord.Rectangles[0].Left;
                                cp.txtTop = currentWord.Rectangles[0].Top;
                                nlisttttt.Add(cp);
                            }
                            currentWord = target.NextWord();

                        }
                    }
                    nlistttttM.Add(nlisttttt);
                }
            }
            double chkVal = nlistttttM[0][0].txtTop;
            //double difVall1 = 0;
            //double difVall2 = 0;
            //double difVall3 = 0;
            //double difValltt = 0;
            //double difVallttzz = nlistttttM[0][0].txtLeft;
            //double lastTxtLeft = 0;
            //double lastval1 = 0;
            //double lastval2 = 0;
            //double lastval3 = 0;
            //double lastval4 = 0;
            //int counter = 0;
            // int counterTxt = 0;

            double dif1 = 0;
            double dif2 = 0;
            double dif3 = 0;
            double dif4 = 0;
            //double dif5 = 0;
            //double len2 = 0;
            //double len1 = 0;
            nlisttttt = new List<Checkpdf>();
            //List<TBLXMLSCheckpdfMizan> nListMizan = new List<TBLXMLSCheckpdfMizan>();
            List<string> toDoList = new List<string>();
            //string toCheck = "";
            List<string> toDoList1 = new List<string>();
            //string toCheck1 = "";
            TBLXMLSCheckpdfMizan nMizan = new TBLXMLSCheckpdfMizan();

            float[] limitCoordinates = null;



            List<string> nteytey = new List<string>();
            string currentText1 = "";
            List<TBLXMLSCheckpdfMizancHK> zztlista = new List<TBLXMLSCheckpdfMizancHK>();
            List<TBLXMLSCheckpdfMizancHK> zztlistb = new List<TBLXMLSCheckpdfMizancHK>();
            for (int page = 1; page <= countPg; page++)
            {
                var lineText = LineUsingCoordinates.getLineText(fileName, page, limitCoordinates);

                if (lineText.Where(x => x.Contains("100")).Count() > 0)
                {
                    var chkfdsegw = lineText;
                }

                foreach (var row in lineText)
                {
                    if (row.Count > 1)
                    {
                        for (var col = 0; col < row.Count; col++)
                        {
                            string trimmedValue = row[col].Trim();
                            if (trimmedValue != "")
                            {
                                currentText1 += "ß" + trimmedValue + "ß";
                            }
                        }
                        nteytey.Add(currentText1);
                        currentText1 = "";
                    }
                }
                zztlista.AddRange(getSplistedt(nteytey));
                zztlista.Select(c => { c.pageID = page; return c; }).ToList();
                zztlistb.AddRange(zztlista);
                nteytey = new List<string>();
                zztlista = new List<TBLXMLSCheckpdfMizancHK>();
            }



            List<TBLXMLSCheckpdfMizan> zonelastlist = new List<TBLXMLSCheckpdfMizan>();
            List<TBLXMLSCheckpdfMizan> zztlist = TBLXMLSCheckpdfMizancHK.getlimited(zztlistb);
            zztlist.Select(c => { c.CompanyID = compid; return c; }).ToList();
            zztlist.Select(c => { c.MainMonth = nmonth; return c; }).ToList();
            zztlist.Select(c => { c.Year = nyear; return c; }).ToList();
            TBLXMLSCheckpdfMizan.DeleteByCompanyIDn(compid, nyear, nmonth);

            string amount1 = "";
            string amount2 = "";
            string amount3 = "";
            string amount4 = "";
            string mainide = "";
            string txtFinitto = "";
            string chkzone = "";
            for (int a = 0; a < nlistttttM.Count; a++)
            {
                var itemz = nlistttttM[a];
                //nlisttttt = itemz;
                //var chkslist = nlisttttt.GroupBy(x => x.txtTop);
                var pagelist = zztlist.Where(x => x.PageID == a + 1).ToList();

                var groupedchksList = itemz
    .GroupBy(u => u.txtTop)
    .Select(grp => grp.ToList())
    .ToList();

                for (int t = 1; t < groupedchksList.Count; t++)
                {

                    nlisttttt = groupedchksList[t];
                    for (int i = 0; i < nlisttttt.Count; i++)
                    {
                        if (nlisttttt[i].txtTop == chkVal)
                        {
                            List<string> wordstt = nlisttttt.Select(x => x.txtWord).ToList();
                            string chkmn = string.Join("-", wordstt);
                            //dif1 = nlisttttt[i].txtLeft - nlisttttt[i - 1].txtLeft;

                            txtFinitto += nlisttttt[i].txtWord;

                            //if (txtFinitto.Contains("100"))
                            //{
                            //    var jhcjhc = mainide;
                            //}

                            if (pagelist.Where(x => x.AccountMainZet == txtFinitto.Trim()).Count() > 0)
                            {
                                mainide = txtFinitto.Trim();

                                //if (mainide.Contains("sermaye"))
                                //{
                                //    var jhcjhc = mainide;
                                //}
                                txtFinitto = "";
                                var resultItem = pagelist.Where(x => x.AccountMainZet == mainide).FirstOrDefault();
                                amount1 = resultItem.Amount1.ToString().Replace(",", "").Replace(".", "");
                                amount2 = resultItem.Amount2.ToString().Replace(",", "").Replace(".", "");
                                amount3 = resultItem.Amount3.ToString().Replace(",", "").Replace(".", "");
                                amount4 = resultItem.Amount4.ToString().Replace(",", "").Replace(".", "");

                            }

                            if (txtFinitto != "" && (amount1 != "" || amount2 != "" || amount3 != "" || amount4 != ""))
                            {
                                chkzone = RemoveNonNumeric2(txtFinitto).ToString().Replace(",", "").Replace(".", "");

                                if (amount1 == chkzone)
                                {
                                    dif1 = nlisttttt[i].txtLeft;
                                    txtFinitto = "";
                                    pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount1Diff = Convert.ToInt32(dif1); return c; }).ToList();

                                    amount1 = "";
                                }
                                else if (amount1 == "" && amount2 == chkzone)
                                {
                                    dif2 = nlisttttt[i].txtLeft;
                                    txtFinitto = "";
                                    pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount2Diff = Convert.ToInt32(dif2); return c; }).ToList();
                                    amount2 = "";
                                }
                                else if (amount1 == "" && amount2 == "" && amount3 == chkzone)
                                {
                                    dif3 = nlisttttt[i].txtLeft;
                                    txtFinitto = "";
                                    pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount3Diff = Convert.ToInt32(dif3); return c; }).ToList();
                                    amount3 = "";
                                }
                                else if (amount1 == "" && amount2 == "" && amount3 == "" && amount4 == chkzone)
                                {
                                    dif4 = nlisttttt[i].txtLeft;
                                    txtFinitto = "";
                                    pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount4Diff = Convert.ToInt32(dif4); return c; }).ToList();
                                    amount4 = "";
                                }
                            }


                        }
                        else
                        {
                            //if (txtFinitto.Trim()!="")
                            //{
                            //    chkzone = RemoveNonNumeric2(txtFinitto).ToString().Replace(",", "").Replace(".", "");
                            //    if (mainide.Replace(",", "").Replace(".", "").Replace(" ", "").Contains(chkzone))
                            //    {

                            //    }

                            //}


                            mainide = "";
                            txtFinitto = nlisttttt[i].txtWord;
                            chkVal = nlisttttt[i].txtTop;
                            amount1 = "";
                            amount2 = "";
                            amount3 = "";
                            amount4 = "";
                        }
                    }



                }

                zonelastlist.AddRange(pagelist);
            }

            var chkyyyu = Data.SetBilancoFromListMizanExcelPdf(zonelastlist);
            Data.InsertDataMizanPdf(chkyyyu);

            List<TBLXMLSCheckpdfMizan> zonelastlistCheck = TBLXMLSCheckpdfMizan.Get_TBLXMLSCheckpdfMizanLast(compid, nyear);
            zonelastlist = new List<TBLXMLSCheckpdfMizan>();
            for (int a = 0; a < nlistttttM.Count; a++)
            {
                var itemz = nlistttttM[a];
                //nlisttttt = itemz;
                //var chkslist = nlisttttt.GroupBy(x => x.txtTop);
                var pagelist = zonelastlistCheck.Where(x => x.PageID == a + 1).ToList();

                var groupedchksList = itemz
    .GroupBy(u => u.txtTop)
    .Select(grp => grp.ToList())
    .ToList();
                if (pagelist.Count > 0)
                {
                    for (int t = 1; t < groupedchksList.Count; t++)
                    {

                        nlisttttt = groupedchksList[t];
                        List<string> wordstt = nlisttttt.Select(x => x.txtWord).ToList();
                        string chkmn = string.Join("-", wordstt);
                        for (int i = 0; i < nlisttttt.Count; i++)
                        {
                            if (nlisttttt[i].txtTop == chkVal)
                            {

                                //dif1 = nlisttttt[i].txtLeft - nlisttttt[i - 1].txtLeft;

                                txtFinitto += nlisttttt[i].txtWord;

                                //if (txtFinitto.Contains("FAİZ"))
                                //{
                                //    var jhcjhc = mainide;
                                //}

                                var longestLenght = pagelist.Min(r => r.AccountMainZet.Length);

                                if (txtFinitto.Length > longestLenght)
                                {
                                    foreach (var item in pagelist)
                                    {

                                        if (CompareStrings(item.AccountMainZet, txtFinitto.Trim()) > 93)
                                        {
                                            if (txtFinitto.Length > item.AccountMainZet.Length)
                                            {
                                                string ntry = "";
                                                //double cfsa = RemoveNonNumeric2(nlisttttt[i + 1].txtWord);
                                                //if (RemoveNonNumeric2(nlisttttt[i+1].txtWord)==0)
                                                //{
                                                //    ntry = nlisttttt[i + 1].txtWord;
                                                //}
                                                List<int> nchutn = new List<int>();
                                                //List<Checkpdf> nlistsaa =new List<Checkpdf>();
                                                for (int y = i + 1; y < nlisttttt.Count; y++)
                                                {
                                                    //nlistsaa.Add(nlisttttt[y]);
                                                    if (item.AccountMainDescription.Replace(" ", "").Contains(nlisttttt[y].txtWord))
                                                    {
                                                        nchutn.Add(y);
                                                        ntry += nlisttttt[y].txtWord;
                                                    }
                                                }


                                                //var nlistsaa= nlisttttt.Where()

                                                //for (int u = 0; u < nlistsaa.Count(); u++)
                                                //{

                                                //}


                                                string sttr = RemoveStringDiff(txtFinitto.Trim() + ntry, item.AccountMainZet);

                                                mainide = item.AccountMainZet;

                                                var resultItem = pagelist.Where(x => x.AccountMainZet == mainide).FirstOrDefault();
                                                amount1 = resultItem.Amount1.ToString().Replace(",", "").Replace(".", "");
                                                amount2 = resultItem.Amount2.ToString().Replace(",", "").Replace(".", "");
                                                amount3 = resultItem.Amount3.ToString().Replace(",", "").Replace(".", "");
                                                amount4 = resultItem.Amount4.ToString().Replace(",", "").Replace(".", "");
                                                txtFinitto = sttr;
                                            }

                                        }

                                    }
                                }



                                //if (pagelist.Where(x => txtFinitto.Trim().Contains(x.AccountMainZet)).Count() > 0)
                                //{
                                //    string chjk = pagelist.Where(x => txtFinitto.Trim().Contains(x.AccountMainZet)).Select(x=>x.AccountMainZet).FirstOrDefault();
                                //    mainide = chjk;
                                //     string  rpplcedstr = txtFinitto.Trim().Replace(chjk,"");
                                //    //if (mainide.Contains("FAİZ"))
                                //    //{
                                //    //    var jhcjhc = mainide;
                                //    //}
                                //    txtFinitto = rpplcedstr;
                                //    var resultItem = pagelist.Where(x => x.AccountMainZet == mainide).FirstOrDefault();
                                //    amount1 = resultItem.Amount1.ToString().Replace(",", "").Replace(".", "");
                                //    amount2 = resultItem.Amount2.ToString().Replace(",", "").Replace(".", "");
                                //    amount3 = resultItem.Amount3.ToString().Replace(",", "").Replace(".", "");
                                //    amount4 = resultItem.Amount4.ToString().Replace(",", "").Replace(".", "");

                                //}

                                if (txtFinitto != "" && (amount1 != "" || amount2 != "" || amount3 != "" || amount4 != ""))
                                {
                                    chkzone = RemoveNonNumeric2(txtFinitto).ToString().Replace(",", "").Replace(".", "");

                                    if (amount1 == chkzone)
                                    {
                                        dif1 = nlisttttt[i].txtLeft;
                                        txtFinitto = "";
                                        pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount1Diff = Convert.ToInt32(dif1); return c; }).ToList();

                                        amount1 = "";
                                    }
                                    else if (amount1 == "" && amount2 == chkzone)
                                    {
                                        dif2 = nlisttttt[i].txtLeft;
                                        txtFinitto = "";
                                        pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount2Diff = Convert.ToInt32(dif2); return c; }).ToList();
                                        amount2 = "";
                                    }
                                    else if (amount1 == "" && amount2 == "" && amount3 == chkzone)
                                    {
                                        dif3 = nlisttttt[i].txtLeft;
                                        txtFinitto = "";
                                        pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount3Diff = Convert.ToInt32(dif3); return c; }).ToList();
                                        amount3 = "";
                                    }
                                    else if (amount1 == "" && amount2 == "" && amount3 == "" && amount4 == chkzone)
                                    {
                                        dif4 = nlisttttt[i].txtLeft;
                                        txtFinitto = "";
                                        pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount4Diff = Convert.ToInt32(dif4); return c; }).ToList();
                                        amount4 = "";
                                    }
                                }


                            }
                            else
                            {


                                mainide = "";
                                txtFinitto = nlisttttt[i].txtWord;
                                chkVal = nlisttttt[i].txtTop;
                                amount1 = "";
                                amount2 = "";
                                amount3 = "";
                                amount4 = "";
                            }
                        }



                    }

                    zonelastlist.AddRange(pagelist);
                }

            }
            var chk = zonelastlist;
            foreach (var item in zonelastlist)
            {
                item.Update_TBLXMLSCheckpdfMizan();
                Thread.Sleep(100);
            }



            zonelastlistCheck = TBLXMLSCheckpdfMizan.Get_TBLXMLSCheckpdfMizanLast(compid, nyear);
            zonelastlist = new List<TBLXMLSCheckpdfMizan>();
            for (int a = 0; a < nlistttttM.Count; a++)
            {
                var itemz = nlistttttM[a];
                var pagelist = zonelastlistCheck.Where(x => x.PageID == a + 1).ToList();

                var groupedchksList = itemz
    .GroupBy(u => u.txtTop)
    .Select(grp => grp.ToList())
    .ToList();
                if (pagelist.Count > 0)
                {
                    for (int t = 1; t < groupedchksList.Count; t++)
                    {

                        nlisttttt = groupedchksList[t];
                        List<string> wordstt = nlisttttt.Select(x => x.txtWord).ToList();


                        string chkmn = string.Join("-", wordstt);
                        //if (chkmn.Contains("PETROL")) {
                        //    string kmkm = "";
                        //}
                        for (int i = 0; i < nlisttttt.Count; i++)
                        {
                            if (nlisttttt[i].txtTop == chkVal)
                            {



                                txtFinitto += nlisttttt[i].txtWord;


                                var longestLenght = pagelist.Min(r => r.AccountMainZet.Length);

                                if (txtFinitto.Length > longestLenght)
                                {
                                    foreach (var item in pagelist)
                                    {

                                        if (CompareStrings(item.AccountMainZet, txtFinitto.Trim()) > 80)
                                        {
                                            if (txtFinitto.Length > item.AccountMainZet.Length)
                                            {
                                                string ntry = "";

                                                List<int> nchutn = new List<int>();
                                                for (int y = i + 1; y < nlisttttt.Count; y++)
                                                {
                                                    //nlistsaa.Add(nlisttttt[y]);
                                                    if (item.AccountMainDescription.Replace(" ", "").Contains(nlisttttt[y].txtWord))
                                                    {
                                                        nchutn.Add(y);
                                                        ntry += nlisttttt[y].txtWord;
                                                    }
                                                }
                                                int zetnt = i;
                                                if (nchutn.Count > 0)
                                                {
                                                    zetnt = nchutn.Max();
                                                }

                                                string chku = "";
                                                string chkuchk = "";
                                                string fullapp = "";
                                                for (int r = 0; r <= zetnt; r++)
                                                {
                                                    chku = nlisttttt[r].txtWord;
                                                    if (item.AccountMainZet.Contains(chkuchk + chku))
                                                    {
                                                        chkuchk += chku;
                                                    }
                                                    else
                                                    {
                                                        fullapp += chku;
                                                    }

                                                }
                                                i = zetnt;

                                                //string sttr = RemoveStringDiff(txtFinitto.Trim() + ntry, item.AccountMainZet);

                                                mainide = item.AccountMainZet;

                                                var resultItem = pagelist.Where(x => x.AccountMainZet == mainide).FirstOrDefault();
                                                amount1 = resultItem.Amount1.ToString().Replace(",", "").Replace(".", "");
                                                amount2 = resultItem.Amount2.ToString().Replace(",", "").Replace(".", "");
                                                amount3 = resultItem.Amount3.ToString().Replace(",", "").Replace(".", "");
                                                amount4 = resultItem.Amount4.ToString().Replace(",", "").Replace(".", "");
                                                txtFinitto = fullapp;
                                            }

                                        }

                                    }
                                }




                                if (txtFinitto != "" && (amount1 != "" || amount2 != "" || amount3 != "" || amount4 != ""))
                                {
                                    chkzone = RemoveNonNumeric2(txtFinitto).ToString().Replace(",", "").Replace(".", "");

                                    if (amount1 == chkzone)
                                    {
                                        dif1 = nlisttttt[i].txtLeft;
                                        txtFinitto = "";
                                        pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount1Diff = Convert.ToInt32(dif1); return c; }).ToList();

                                        amount1 = "";
                                    }
                                    else if (amount1 == "" && amount2 == chkzone)
                                    {
                                        dif2 = nlisttttt[i].txtLeft;
                                        txtFinitto = "";
                                        pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount2Diff = Convert.ToInt32(dif2); return c; }).ToList();
                                        amount2 = "";
                                    }
                                    else if (amount1 == "" && amount2 == "" && amount3 == chkzone)
                                    {
                                        dif3 = nlisttttt[i].txtLeft;
                                        txtFinitto = "";
                                        pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount3Diff = Convert.ToInt32(dif3); return c; }).ToList();
                                        amount3 = "";
                                    }
                                    else if (amount1 == "" && amount2 == "" && amount3 == "" && amount4 == chkzone)
                                    {
                                        dif4 = nlisttttt[i].txtLeft;
                                        txtFinitto = "";
                                        pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount4Diff = Convert.ToInt32(dif4); return c; }).ToList();
                                        amount4 = "";
                                    }
                                }


                            }
                            else
                            {


                                mainide = "";
                                txtFinitto = nlisttttt[i].txtWord;
                                chkVal = nlisttttt[i].txtTop;
                                amount1 = "";
                                amount2 = "";
                                amount3 = "";
                                amount4 = "";
                            }
                        }



                    }

                    zonelastlist.AddRange(pagelist);
                }

            }
            var chkvn = zonelastlist;
            foreach (var item in zonelastlist)
            {
                item.Update_TBLXMLSCheckpdfMizan();
                Thread.Sleep(100);
            }
            TBLXMLSCheckpdfMizan.LastRepByCompanyIDn(nyear, compid,nmonth, 1);
            //foreach (var item in nlisttttt)
            //{
            //    txtFinitto += item.txtWord;



            //}
            //var teyteyyy = zztlist;

            return new List<ReadPdfMizan>();


            //return nlist;
        }
        public double CompareStrings(string str1, string str2)
        {
            List<string> pairs1 = WordLetterPairs(str1.ToUpper());
            List<string> pairs2 = WordLetterPairs(str2.ToUpper());

            int intersection = 0;
            int union = pairs1.Count + pairs2.Count;

            for (int i = 0; i < pairs1.Count; i++)
            {
                for (int j = 0; j < pairs2.Count; j++)
                {
                    if (pairs1[i] == pairs2[j])
                    {
                        intersection++;
                        pairs2.RemoveAt(j);//Must remove the match to prevent "AAAA" from appearing to match "AA" with 100% success
                        break;
                    }
                }
            }

            return (2.0 * intersection * 100) / union; //returns in percentage
                                                       //return (2.0 * intersection) / union; //returns in score from 0 to 1
        }

        public string RemoveStringDiff(string str1, string str2)
        {
            int countrr = 0;
            string lastret = "";
            string nret = "";
            int obara = 0;
            int fan = str1.Length - str2.Length;



            try
            {
                string rpplcedstr = str1.Trim().Replace(str2, "");
                if (rpplcedstr != str1.Trim())
                {
                    return rpplcedstr;

                }

                for (int i = str1.Length - 1; i >= 0; i--)
                {
                    if (str1[i] == str2[i - fan])
                    {
                        lastret += str1[i];
                    }
                    else
                    {
                        break;
                    }

                }

                for (int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] != str2[i])
                    {
                        countrr = i;
                        break;
                        nret += str1[i];
                    }
                }
                char[] charArray = lastret.ToCharArray();
                Array.Reverse(charArray);
                string lastchek = new string(charArray);
                string ttetet = str1.Substring(countrr);
                var chk = lastret;
                var chkss = nret;
                nret = ttetet.Trim().Replace(lastchek, "");

                return nret;

            }
            catch (Exception ex)
            {

                var chkzzz = ex;
            }



            return nret;
        }

        private List<string> WordLetterPairs(string str)
        {
            List<string> AllPairs = new List<string>();

            // Tokenize the string and put the tokens/words into an array
            string[] Words = Regex.Split(str, @"\s");

            // For each word
            for (int w = 0; w < Words.Length; w++)
            {
                if (!string.IsNullOrEmpty(Words[w]))
                {
                    // Find the pairs of characters
                    String[] PairsInWord = LetterPairs(Words[w]);

                    for (int p = 0; p < PairsInWord.Length; p++)
                    {
                        AllPairs.Add(PairsInWord[p]);
                    }
                }
            }
            return AllPairs;
        }

        
        private string[] LetterPairs(string str)
        {
            int numPairs = str.Length - 1;
            string[] pairs = new string[numPairs];

            for (int i = 0; i < numPairs; i++)
            {
                pairs[i] = str.Substring(i, 2);
            }
            return pairs;
        }
        string GetDataConvertedData(string textFromPage)
        {
            var texts = textFromPage.Split(new[] { "\n" }, StringSplitOptions.None)
                                    .Where(text => text.Contains("Tj")).ToList();

            return texts.Aggregate(string.Empty, (current, t) => current +
                       t.TrimStart('(')
                        .TrimEnd('j')
                        .TrimEnd('T')
                        .TrimEnd(')'));
        }
        string GetgetSterlin(Double count)
        {
            string txt = string.Empty;
            for (int i = 0; i < count; i++)
            {
                txt += "£";
            }
            return txt;
        }

        public List<TBLXMLSCheckpdfMizancHK> getSplistedt(List<string> dodo)
        {
            List<TBLXMLSCheckpdfMizancHK> nmizamna = new List<TBLXMLSCheckpdfMizancHK>();
            TBLXMLSCheckpdfMizancHK nmizamn = new TBLXMLSCheckpdfMizancHK();
            foreach (var item in dodo)
            {


                nmizamn = new TBLXMLSCheckpdfMizancHK();
                String ntcxt = item.Substring(1);
                ntcxt = ntcxt.Remove(ntcxt.Length - 1, 1).Replace("ßß", "ß");
                List<string> flist = ntcxt.Split('ß').ToList();
                if (flist.Count > 0 && flist[0].Length<3)
                {
                    flist.RemoveAt(0);
                }

                if (flist.Count>0 && flist[0].Length < 3)
                {
                    flist.RemoveAt(0);
                }

                

                if (flist.Count == 6)
                {
                    nmizamn.AccountMainID = flist[0];
                    nmizamn.AccountMainDescription = flist[1];
                    nmizamn.Amount4 = RemoveNonNumeric2(flist[5]);
                    nmizamn.Amount3 = RemoveNonNumeric2(flist[4]);
                    nmizamn.Amount2 = RemoveNonNumeric2(flist[3]);
                    nmizamn.Amount1 = RemoveNonNumeric2(flist[2]);
                }
                else if (flist.Count == 5)
                {
                    nmizamn.AccountMainID = flist[0];
                    nmizamn.AccountMainDescription = flist[1];
                    nmizamn.Amount3 = RemoveNonNumeric2(flist[4]);
                    nmizamn.Amount2 = RemoveNonNumeric2(flist[3]);
                    nmizamn.Amount1 = RemoveNonNumeric2(flist[2]);

                }
                else if (flist.Count == 4)
                {
                    nmizamn.AccountMainID = flist[0];
                    nmizamn.AccountMainDescription = flist[1];
                    nmizamn.Amount2 = RemoveNonNumeric2(flist[3]);
                    nmizamn.Amount1 = RemoveNonNumeric2(flist[2]);

                }
                else if (flist.Count == 3)
                {

                    nmizamn.AccountMainID = flist[0];
                    nmizamn.AccountMainDescription = flist[1];
                    nmizamn.Amount1 = RemoveNonNumeric2(flist[2]);
                }
                else if (flist.Count == 2)
                {

                    nmizamn.AccountMainID = flist[0];
                    nmizamn.AccountMainDescription = flist[1];
                }
                nmizamna.Add(nmizamn);
            }


            //float f;
            //int t;
            //bool numeric = false;
            ////List<double> flist = new List<double>();
            //int countre = 0;
            //bool ntec = true;
            //for (int i = dodo.Length - 1; i >= 0; i--)
            //{
            //    countre++;

            //    if (float.TryParse(dodo[i].Replace(",", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty), out f) && ntec == true)
            //    {
            //        flist.Add(RemoveNonNumeric2(dodo[i]));
            //    }
            //    else
            //    {
            //        ntec = false;
            //        nmizamn.lineMainDescription += dodo[i] + ' ';
            //    }
            //}

            //string[] strlist = nmizamn.lineMainDescription.Split(' ');
            //ntec = true;
            //for (int i = strlist.Length - 1; i >= 0; i--)
            //{
            //    if (int.TryParse(strlist[i].Replace(",", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty), out t) && ntec == true)
            //    {

            //        nmizamn.AccountMainID += strlist[i] + ".";


            //    }
            //    else
            //    {
            //        if (nmizamn.AccountMainID.Length > 0)
            //        {
            //            nmizamn.AccountMainID = nmizamn.AccountMainID.Remove(nmizamn.AccountMainID.Length - 1, 1);
            //        }

            //        ntec = false;
            //        nmizamn.AccountMainDescription += strlist[i] + ' ';
            //    }
            //}

            //pdfReader = new PdfReader(fileName);
            //StringBuilder text = new StringBuilder();
            //for (int page = 1; page <= pdfReader.NumberOfPages; page++)
            //{
            //    ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
            //    PdfWord currentWord = processor.NextWord();
            //    string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, its);

            //    currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.UTF8.GetBytes(currentText)));
            //    var chkkku = GetDataConvertedData(currentText);

            //    var ttty = chkkku.Split('\n');
            //    text.Append(currentText);

            //}
            //pdfReader.Close();
            //wordschk = text.ToString().Split('\n');
            //List<TBLXMLSCheckpdfMizancHK> zzlist = new List<TBLXMLSCheckpdfMizancHK>();
            //for (int i = 1; i <= countPg; i++)
            //{
            //    var tttff = pdfDocumentProcessor.GetMarkupAnnotationData(i);
            //    firstPageText = pdfDocumentProcessor.GetPageText(i, new PdfTextExtractionOptions { ClipToCropBox = true });

            //    words = firstPageText.Split('\n');
            //    for (int j = 0, len = words.Length; j < len; j++)
            //    {
            //        chkPdf = new ReadPdfMizan();
            //        countre++;
            //        line = ASCIIEncoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j]));
            //        chkPdf.LineContent = line.Replace("\r", string.Empty);
            //        string[] nlista = chkPdf.LineContent.Split(' ');
            //        zzlist.Add(getSplisted(nlista));
            //        chkPdf.CounterNo = countre;
            //        nlist.Add(chkPdf);
            //    }

            //}
            //var chkwwwww = toDoList1;
            //var groupsww = toDoList;
            //var groups = nListMizan;
            //var chhhswet = zzlist;
            //var chhh = nlist;
            //var listyn = getListPdf(nlist);

            //foreach (var item in listyn)
            //{
            //    item.Save_TBLXMLSCheckpdfMizan();
            //    Thread.Sleep(100);
            //}
            //string kcjkcjkk = string.Empty;


            //foreach (var item in nlisttttt)
            //{






            //    if (item.txtTop == chkVal)
            //    {
            //        string tttxxt = GetgetSterlin(item.txtLeft - difVallttzz);
            //        toCheck += item.txtWord + tttxxt;
            //        counter++;
            //        if (counter == 1)
            //        {
            //            counterTxt++;

            //        }

            //        bool checkResult = int.TryParse(item.txtWord.Replace(",", "").Replace(".", "").Replace("-", ""), out int age);
            //        if (checkResult == true && item.txtLeft - difVall3 < 17)
            //        {
            //            if (counterTxt == 1)
            //            {
            //                nMizan.AccountMainID += item.txtWord;
            //            }
            //            else
            //            {

            //                if (item.txtLeft - difVall1 > 390)
            //                {
            //                    lastTxtLeft = 0;
            //                    if (item.txtLeft - lastval4 < 17)
            //                    {
            //                        nMizan.diff43 = item.txtLeft - difVall1;
            //                        nMizan.Value4 += item.txtWord;
            //                    }
            //                    else
            //                    {
            //                        nMizan.diff23 = item.txtLeft - difVall1;
            //                        nMizan.Value3 += item.txtWord;
            //                    }
            //                    lastval4 = item.txtLeft;
            //                }
            //                else if (item.txtLeft - difVall1 > 320)
            //                {
            //                    lastTxtLeft = 0;
            //                    if (item.txtLeft - lastval3 < 17)
            //                    {
            //                        nMizan.diff23 = item.txtLeft - difVall1;
            //                        nMizan.Value3 += item.txtWord;
            //                    }
            //                    else
            //                    {
            //                        nMizan.diff21 = item.txtLeft - difVall1;
            //                        nMizan.Value2 += item.txtWord;
            //                    }

            //                    lastval3 = item.txtLeft;
            //                }
            //                else if (item.txtLeft - difVall1 > 250)
            //                {
            //                    lastTxtLeft = 0;
            //                    if (item.txtLeft - lastval2 < 17)
            //                    {
            //                        nMizan.diff21 = item.txtLeft - difVall1;
            //                        nMizan.Value2 += item.txtWord;
            //                    }
            //                    else
            //                    {
            //                        nMizan.Value1 += item.txtWord;

            //                    }



            //                    lastval2 = item.txtLeft;
            //                }
            //                else
            //                {
            //                    if (item.txtLeft - lastval1 < 17)
            //                    {
            //                        nMizan.Value1 += item.txtWord;
            //                    }
            //                    else
            //                    {
            //                        nMizan.diff21 = item.txtLeft - difVall1;
            //                        nMizan.Value2 += item.txtWord;
            //                    }
            //                    lastTxtLeft = 0;
            //                    //nMizan.Value1 += item.txtWord;
            //                    lastval1 = item.txtLeft;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            nMizan.AccountMainDescription += item.txtWord;
            //            if (counterTxt == 1)
            //            {
            //                difVall1 = item.txtLeft;
            //            }
            //            difVall3 = item.txtLeft;
            //            counterTxt++;
            //        }

            //        difVallttzz = item.txtLeft;
            //    }
            //    else
            //    {
            //        nListMizan.Add(nMizan);
            //        toDoList.Add(toCheck);
            //        nMizan = new TBLXMLSCheckpdfMizan();
            //        if (item.txtLeft - lastTxtLeft < 17)
            //        {

            //            nMizan.AccountMainID += item.txtWord;

            //        }
            //        else
            //        {
            //            nMizan.AccountMainID += item.txtWord;
            //        }

            //        difVallttzz = item.txtLeft;
            //        toCheck = "";
            //        counterTxt = 0;
            //        counter = 0;
            //        chkVal = item.txtTop;
            //        toCheck += item.txtWord;
            //        lastTxtLeft = item.txtLeft;
            //    }

            //}
            return nmizamna;
        }
        public TBLXMLSCheckpdfMizancHK getSplisted(string[] dodo)
        {
            TBLXMLSCheckpdfMizancHK nmizamn = new TBLXMLSCheckpdfMizancHK();
            float f;
            int t;
            bool numeric = false;
            List<double> flist = new List<double>();
            int countre = 0;
            bool ntec = true;
            for (int i = dodo.Length - 1; i >= 0; i--)
            {
                countre++;

                if (float.TryParse(dodo[i].Replace(",", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty), out f) && ntec == true)
                {
                    flist.Add(RemoveNonNumeric2(dodo[i]));
                }
                else
                {
                    ntec = false;
                    nmizamn.lineMainDescription += dodo[i] + ' ';
                }
            }

            string[] strlist = nmizamn.lineMainDescription.Split(' ');
            ntec = true;
            for (int i = strlist.Length - 1; i >= 0; i--)
            {
                if (int.TryParse(strlist[i].Replace(",", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty), out t) && ntec == true)
                {

                    nmizamn.AccountMainID += strlist[i] + ".";


                }
                else
                {
                    if (nmizamn.AccountMainID.Length > 0)
                    {
                        nmizamn.AccountMainID = nmizamn.AccountMainID.Remove(nmizamn.AccountMainID.Length - 1, 1);
                    }

                    ntec = false;
                    nmizamn.AccountMainDescription += strlist[i] + ' ';
                }
            }

            if (flist.Count == 4)
            {
                nmizamn.Amount4 = flist[0];
                nmizamn.Amount3 = flist[1];
                nmizamn.Amount2 = flist[2];
                nmizamn.Amount1 = flist[3];
            }
            else if (flist.Count == 3)
            {
                nmizamn.Amount3 = flist[0];
                nmizamn.Amount2 = flist[1];
                nmizamn.Amount1 = flist[2];

            }
            else if (flist.Count == 2)
            {

                nmizamn.Amount2 = flist[0];
                nmizamn.Amount1 = flist[1];

            }
            else if (flist.Count == 1)
            {

                nmizamn.Amount1 = flist[0];
            }
            return nmizamn;
        }
        public List<TBLXMLSCheckpdfMizan> getListPdf(List<ReadPdfMizan> nchek)
        {
            List<TBLXMLSCheckpdfMizan> nli = new List<TBLXMLSCheckpdfMizan>();
            TBLXMLSCheckpdfMizan nd = new TBLXMLSCheckpdfMizan();
            int counter = 0;
            int mncheck = 0;
            foreach (var item in nchek)
            {
                counter = 0;
                nd = new TBLXMLSCheckpdfMizan();
                string[] llist = item.LineContent.Split(' ');
                for (int i = 0; i < llist.Count(); i++)
                {

                    if (i == 0 || i == 1 || i == 2)
                    {
                        bool checkResult = int.TryParse(llist[i].Replace(",", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty), out int age);
                        if (checkResult)
                        {
                            nd.AccountMainID += " " + llist[i];
                        }
                        else
                        {
                            nd.AccountMainDescription += " " + llist[i];
                        }
                    }
                    else
                    {


                        var checkResult = RemoveNonNumeric2(llist[i]);
                        if (checkResult != 0)
                        {
                            int cnhk = llist.Count() - i;
                            if (counter != 0)
                            {
                                mncheck = llist.Count() - mncheck;
                            }

                            try
                            {
                                if (cnhk == 4)
                                {
                                    nd.Amount4 = checkResult;
                                }
                                else if (cnhk == 3)
                                {
                                    nd.Amount3 = checkResult;
                                }
                                else if (cnhk == 2)
                                {
                                    nd.Amount2 = checkResult;
                                }
                                else
                                {
                                    nd.Amount1 = checkResult;
                                }
                            }
                            catch
                            {


                            }
                            counter = 0;
                        }
                        else
                        {
                            mncheck = 0;
                            counter = i;
                            nd.AccountMainDescription += " " + llist[i];

                        }

                    }

                }
                nli.Add(nd);

            }

            //foreach (var itemz in nlistttttM)
            //{
            //    nlisttttt= itemz;
            //    var chkslist = nlisttttt.GroupBy(x => x.txtTop);

            //    for (int i = 1; i < nlisttttt.Count-1; i++)
            //    {

            //        if (nlisttttt[i].txtTop == chkVal)
            //        {

            //            dif1 = nlisttttt[i].txtLeft - nlisttttt[i - 1].txtLeft;
            //            dif2 = nlisttttt[i+1].txtLeft - nlisttttt[i].txtLeft;

            //            len2 = nlisttttt[i].txtWord.Length*2.1;
            //            len1 = nlisttttt[i-1].txtWord.Length * 2.1;
            //            bool checkResult = int.TryParse(nlisttttt[i].txtWord.Replace(",", "").Replace(".", "").Replace("-", ""), out int age);
            //            bool checkResultz = int.TryParse(nlisttttt[i - 1].txtWord.Replace(",", "").Replace(".", "").Replace("-", ""), out int ages);
            //            if ((dif1 - len1)< dif2-len2 )
            //            {

            //                if (checkResult && (nlisttttt[i].txtWord.Contains('.') || nlisttttt[i].txtWord.Contains(',')) )
            //                {

            //                    if (checkResultz && (nlisttttt[i - 1].txtWord.Contains('.') || nlisttttt[i - 1].txtWord.Contains(',')))
            //                    {
            //                        toCheck1 += nlisttttt[i].txtWord;
            //                    }
            //                    else
            //                    {
            //                        if (checkResult = false && checkResultz == false)
            //                        {
            //                            toCheck1 += " "+nlisttttt[i].txtWord;
            //                        }
            //                        else
            //                        {
            //                            toCheck1 += "£#" + (Convert.ToInt32(dif1) - Convert.ToInt32(len1)).ToString() + "£#" + nlisttttt[i].txtWord;
            //                        }


            //                    }

            //                }
            //                else
            //                {
            //                    toCheck1 += nlisttttt[i].txtWord + ' ';
            //                }
            //            }
            //            else
            //            {

            //                if (nlisttttt[i - 1].txtWord.Length == 4)
            //                {

            //                    if (checkResult && (nlisttttt[i].txtWord.Contains('.') || nlisttttt[i].txtWord.Contains(',')))
            //                    {

            //                        if (checkResultz)
            //                        {
            //                            toCheck1 +=  nlisttttt[i].txtWord;
            //                        }
            //                        else
            //                        {
            //                            if (checkResult = false && checkResultz == false)
            //                            {
            //                                toCheck1 += " " + nlisttttt[i].txtWord;
            //                            }
            //                            else
            //                            {
            //                                toCheck1 += "£#" + (Convert.ToInt32(dif1) - Convert.ToInt32(len1)).ToString() + "£#" + nlisttttt[i].txtWord;
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        toCheck1 += nlisttttt[i].txtWord + ' ';
            //                    }

            //                }
            //                else
            //                {
            //                    if ((Convert.ToInt32(dif1) - Convert.ToInt32(len1))<21)
            //                    {
            //                        toCheck1 +=   " " + nlisttttt[i].txtWord;
            //                    }
            //                    else
            //                    {
            //                        if (checkResult=false&& checkResultz==false)
            //                        {
            //                            toCheck1 += " " + nlisttttt[i].txtWord;
            //                        }
            //                        else
            //                        {
            //                            toCheck1 += "£#" + (Convert.ToInt32(dif1) - Convert.ToInt32(len1)).ToString() + "£#" + nlisttttt[i].txtWord;
            //                        }

            //                    }

            //                }

            //            }

            //        }
            //        else
            //        {

            //            toDoList1.Add(toCheck1);
            //            chkVal = nlisttttt[i].txtTop;
            //            toCheck1 = nlisttttt[i].txtWord +' ';
            //        }
            //    }




            //}






            //var groupst = nlistttttM;
            return nli;
        }



        public JsonResult moodUpdateBalance(XMlookUpdate pageIndex)
        {
            if (!ModelState.IsValid)
            {

                return Json("nok");
            }

            try
            {
                DashBilancoSetMizan.Set_ReportSetMizanKayit(pageIndex.year, pageIndex.companyid);
                // int csvId = MainDash.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);

            }
            catch (Exception ex)
            {

                return Json("nok_" + ex.ToString());
            }



            return Json("ok");


        }

        private TBLXMLSCheckpdfMizan checkStrList(List<string> nmon)
        {

            TBLXMLSCheckpdfMizan nlistitem = new TBLXMLSCheckpdfMizan();

            int nm = nmon.Count;
            if (nmon.Count >= 6)
            {
                List<int> tlist = new List<int>() { 0, nm - 1, nm - 2, nm - 3, nm - 4 };

                nlistitem.AccountMainID = nmon[0];
                nlistitem.Amount1 = RemoveNonNumeric2(nmon[nm - 4]);
                nlistitem.Amount2 = RemoveNonNumeric2(nmon[nm - 3]);
                nlistitem.Amount3 = RemoveNonNumeric2(nmon[nm - 2]);
                nlistitem.Amount4 = RemoveNonNumeric2(nmon[nm - 1]);
                for (int i = 1; i < nmon.Count; i++)
                {
                    if (!tlist.Contains(i))
                    {
                        nlistitem.AccountMainDescription += nmon[i] + ' ';
                    }

                }

            }

            return nlistitem;

        }

    }
    public class Checkpdf
    {
        public string txtWord;
        public double txtTop;
        public double txtLeft;
    }
    public class CheckpdfMini
    {
        public string txtWord;
        public double txtLeft;
    }

}
