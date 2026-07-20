using DevExpress.Charts.Native;
using DevExpress.Pdf;
using fincheckup.ENTITY;
using fincheckup.Helper;
using fincheckup.Models;
using fincheckup.Models.Hvvn;
using fincheckup.Models.NKolay;
using fincheckup.Models.NKolay.ENTITY;
using fincheckup.Models.NKolay.ENTITY.Beyanname;
using fincheckup.Models.NKolay.json;
using fincheckup.Models.NKolay.MizanView;
using fincheckup.Models.ViewM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fincheckup.Controllers
{
    [Route("JsonService/Beyanname/[action]")]
    public class BeyannameController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;

        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [RequestSizeLimit(209715200)]
        public async Task<JsonResult> moodUpload(XMlook pageIndex)
        {

            var file = pageIndex.file;
            string filemonth = pageIndex.Caption.Split('_')[0];
            string fileyear = pageIndex.Caption.Split('_')[1];
            string filePath = string.Empty;
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));

            string checkvalt = string.Empty;
            string checkval = string.Empty;
            string checkval1 = string.Empty;
            bool chekSource = false;
            bool chekSource1 = false;
            if (file != null && file.Count > 0)
            {


            }
            else
            {
                return Json("nok");
            }
            string pathToXmlFile = string.Empty;



            foreach (var item in file)
            {
                filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".pdf");
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await item.CopyToAsync(fileStream).ConfigureAwait(false);
                }
            }

            pathToXmlFile = filePath;




            long CompID = Convert.ToInt64(pageIndex.ide);
            int nYear = Convert.ToInt32(fileyear);

            int nMonth = Convert.ToInt32(filemonth);

            DateTime docDate = new DateTime(nYear, nMonth, 1);

            try
            {

                var CHKgROUP = ReadPdfFile(filePath);


                List<ReadPdfPg> nliste = new List<ReadPdfPg>();
                List<ReadPdfPg> nliste1 = new List<ReadPdfPg>();



                ReadPdfPg chhhkt = CHKgROUP.Where(x => x.LineContent.Contains("GEÇİCİ VERGİ BEYANNAMESİ")).FirstOrDefault();

                if (chhhkt == null)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Hatalı PDF Yükleme  GEÇİCİ VERGİ BEYANNAMESİ  Olmalı "; lg.Save_AppLogs();
                    return Json("Hatalı PDF Yükleme   GEÇİCİ VERGİ BEYANNAMESİ   Olmalı");
                }



                ReadPdfPg chhhk1 = CHKgROUP.Where(x => x.LineContent.Contains("Yılı")).FirstOrDefault();
                ReadPdfPg chhhk1eposta = CHKgROUP.Where(x => x.LineContent.Contains("E-Posta Adresi")).FirstOrDefault();
                string vergino = CHKgROUP.Where(x => x.CounterNo == chhhk1eposta.CounterNo + 1).FirstOrDefault().LineContent;
                string txt1Yil = CHKgROUP.Where(x => x.CounterNo == 7).FirstOrDefault().LineContent;
                Companies mainComp = Companies.Get_Company(CompID);
                if (vergino.Trim() != mainComp.TaxID.Trim())
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Hatalı Vergi No  "; lg.Save_AppLogs();
                    return Json("Hatalı Vergi No ");
                }

                if (Convert.ToInt32(txt1Yil) != nYear)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Hatalı Yıl  "; lg.Save_AppLogs();
                    return Json("Hatalı Yıl  ");
                }



                CHKgROUP = CHKgROUP.Where(x => x.LineContent.Length > 11).ToList();
                for (int i = 0; i < CHKgROUP.Count; i++)
                {
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
                        checkval = CHKgROUP[i].LineContent.Length > 1   ? CHKgROUP[i].LineContent.Replace(". ", string.Empty).Substring(0, 1) : string.Empty;
                        if (!IsNumeric(checkval))
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

                    if ((CHKgROUP[i].LineContent != null && CHKgROUP[i].LineContent.Contains("GELİR TABLOSU") && (CHKgROUP[i].LineContent.Trim().Length > 23) == false))
                    {

                        chekSource1 = true;
                    }

                    if (CHKgROUP[i].LineContent.Contains("Dönem Net Karı veya Zararı"))
                    {
                        CHKgROUP[i].MainID = "Z";
                        CHKgROUP[i].SubID = "D";
                        CHKgROUP[i].IsRevenue = 1;
                        nliste.Add(CHKgROUP[i]);
                        chekSource1 = false;
                    }


                    if (chekSource1)
                    {
                        checkval = CHKgROUP[i].LineContent.Length > 1 ? CHKgROUP[i].LineContent.Replace(". ", string.Empty).Substring(0, 1) : string.Empty;
                        if (!IsNumeric(checkval))
                        {
                            checkval1 = checkval;
                        }
                        CHKgROUP[i].MainID = "Z";
                        CHKgROUP[i].SubID = checkval1;
                        CHKgROUP[i].IsRevenue = 1;
                        nliste.Add(CHKgROUP[i]);
                    }
                    if (CHKgROUP[i].LineContent.Contains("KAR DAĞITIM TABLOSU")  )
                    {
                         
                        break;
                    }
                }
                //var chkkGrp2 = BeyannameResult.Get_MizanResult();
                //var tt = CHKgROUP.Where(x => chkkGrp2.Any(z => x.LineContent.Trim().Replace(" ", string.Empty).Contains(z.MainDescription.Trim().Replace(" ", string.Empty))));






                BeyannameChkGecici btnchk = new BeyannameChkGecici();
                BeyannameChkGecici.Delete(-1 * CompID, nYear);
                foreach (var item in nliste)
                {
                    btnchk = new BeyannameChkGecici();
                    btnchk.AccountMainDescriptionChk = item.LineContent;
                    btnchk.CompanyID = -1 * CompID;
                    btnchk.IsRevenue = item.IsRevenue;
                    btnchk.SubID = item.SubID;
                    btnchk.MainID = item.MainID;
                    btnchk.Year = nYear;
                    btnchk.Save_Beyanname();
                    Thread.Sleep(50);
                }
                BeyannameChkGecici.DeleteLast(-1 * CompID, nYear);
                var chkkGrplst = BeyannameChkGecici.Get_BeyannameResultLst(-1 * CompID, nYear);

                foreach (var item in chkkGrplst)
                {
                    BeyannameChkGecici.LastSet(item.ID);
                }
                BeyannameChkGecici.LastFinished(-1 * CompID, nYear, nMonth);

                var nbeyanname = BeyannameChkGecici.Get_BeyannameResultMulti(-1 * CompID, nYear);



                TBLXml ncs = new TBLXml();
                ncs.CompanyID = CompID;
                ncs.CreatedDate = DateTime.Now;
                ncs.DocumentDate = docDate;
                ncs.Year = nYear;
                ncs.CsvName = pathToXmlFile;
                ncs.Save_TBLXml();

                var ttest = Dataz.SetValueFromBeyanname(nbeyanname, ncs.ID, docDate);
                ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();

                // dat.InsertTB(ttest);
                var objBulk = new BulkUploadToSql<Dataz>()
                {
                    InternalStore = ttest,
                    TableName = "[TBLXMLSource]",
                    CommitBatchSize = 50000,
                    ConnectionString = Database.ConnectionString
                };
                objBulk.Commit();
                //    List<DashBilancoView> nRequestList = DashBilancoViewMain.getList(fyear, comp.ID);
                //    var tlist = Data.SetBilancoFromList(nRequestList, comp.ID, fyear);
                //    Data.RESET_DashBilancoView(fyear, comp.ID);
                //    Data.InsertBilnco(tlist);
                List<DashBilancoView> nRequestListRvn = DashGelirTablosuViewMain.getList(nYear, comp.ID);
                var tlistRvn = Data.SetBilancoFromList(nRequestListRvn, comp.ID, nYear);
                Data.RESET_REVENUEView(nYear, comp.ID);
                var WCapitalViez = DashWCapitalViewMain.getList(nYear, comp.ID);
                var WCapitalVie = Data.SetBilancoFromList(WCapitalViez, comp.ID, nYear);
                var nLiqudity = DashLikiditeViewMain.getList(nYear, comp.ID);
                var WLiqudity = Data.SetBilancoFromList(nLiqudity, comp.ID, nYear);
                Data.InsertLiquidity(WLiqudity);
                Data.InsertWCapital(WCapitalVie);
                Data.InsertRvn(tlistRvn);
                DashRasyo.GetDashRasyoAnalizBeyanname(nYear, comp.ID);
                DashRasyo.GetDashLikiditeRiskTrend(nYear, comp.ID);
                DashRasyo.GetDashOzetMali(nYear, comp.ID, Convert.ToInt32(filemonth));

                return Json("ok");
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = comp.ID;
                lg.CsvID = 7777;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();

                return Json("nok");

            }

        }
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [RequestSizeLimit(209715200)]
        public async Task<JsonResult> moodUploadUpdate(XMlook pageIndex)
        {


            var file = pageIndex.file;
            string filemonth = pageIndex.Caption.Split('_')[0];
            string fileyear = pageIndex.Caption.Split('_')[1];
            string filePath = string.Empty;
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));


            if (file != null && file.Count > 0)
            {


            }
            else
            {
                return Json("nok");
            }
            string pathToXmlFile = string.Empty;



            foreach (var item in file)
            {
                filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".xml");
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await item.CopyToAsync(fileStream).ConfigureAwait(false);
                }
            }

            pathToXmlFile = filePath;




            long CompID = Convert.ToInt64(pageIndex.ide);
            int nYear = pageIndex.id;




            try
            {

                var CHKgROUP = ReadPdfFile(filePath);


                List<ReadPdfPg> nliste = new List<ReadPdfPg>();
                List<ReadPdfPg> nliste1 = new List<ReadPdfPg>();



                ReadPdfPg chhhkt = CHKgROUP.Where(x => x.LineContent.Contains("GEÇİCİ VERGİ BEYANNAMESİ")).FirstOrDefault();

                if (chhhkt == null)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Hatalı PDF Yükleme  GEÇİCİ VERGİ BEYANNAMESİ  Olmalı "; lg.Save_AppLogs();
                    return Json("Hatalı PDF Yükleme   GEÇİCİ VERGİ BEYANNAMESİ   Olmalı");
                }



                ReadPdfPg chhhk1 = CHKgROUP.Where(x => x.LineContent.Contains("Yıl ")).FirstOrDefault();
                ReadPdfPg chhhk1eposta = CHKgROUP.Where(x => x.LineContent.Contains("E-Posta Adresi")).FirstOrDefault();
                string vergino = CHKgROUP.Where(x => x.CounterNo == chhhk1eposta.CounterNo + 1).FirstOrDefault().LineContent;
                string txt1Yil = chhhk1.LineContent.Split(' ')[1].Trim();
                Companies mainComp = Companies.Get_Company(CompID);
                //if (vergino.Trim() != mainComp.TaxID.Trim())
                //{
                //    ERRLOG lg = new ERRLOG();
                //    lg.CompanyID = CompID;
                //    lg.CsvID = nYear;
                //    lg.ERLOG = "Hatalı Vergi No  "; lg.Save_AppLogs();
                //    return Json("Hatalı Vergi No ");
                //}

                if (Convert.ToInt32(txt1Yil) != nYear)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Hatalı Yıl  "; lg.Save_AppLogs();
                    return Json("Hatalı Yıl  ");
                }




                //string retval = XmlChecker.XmlCheck(IsZip, 1, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl);
                //if (retval != "nok")
                //{
                //    int fyear = Convert.ToInt32(fileyear);



                //    List<DashBilancoView> nRequestList = DashBilancoViewMain.getList(fyear, comp.ID);
                //    var tlist = Data.SetBilancoFromList(nRequestList, comp.ID, fyear);
                //    Data.RESET_DashBilancoView(fyear, comp.ID);
                //    Data.InsertBilnco(tlist);
                //    List<DashBilancoView> nRequestListRvn = DashGelirTablosuViewMain.getList(fyear, comp.ID);
                //    var tlistRvn = Data.SetBilancoFromList(nRequestListRvn, comp.ID, fyear);
                //    Data.RESET_REVENUEView(fyear, comp.ID);
                //    var WCapitalViez = DashWCapitalViewMain.getList(fyear, comp.ID);
                //    var WCapitalVie = Data.SetBilancoFromList(WCapitalViez, comp.ID, fyear);
                //    var nLiqudity = DashLikiditeViewMain.getList(fyear, comp.ID);
                //    var WLiqudity = Data.SetBilancoFromList(nLiqudity, comp.ID, fyear);
                //    Data.InsertLiquidity(WLiqudity);
                //    Data.InsertWCapital(WCapitalVie);
                //    Data.InsertRvn(tlistRvn);
                //    DashRasyo.GetDashRasyoAnaliz(fyear, comp.ID);
                //    DashRasyo.GetDashLikiditeRiskTrend(fyear, comp.ID);
                //    DashRasyo.GetDashOzetMali(fyear, comp.ID, Convert.ToInt32(filemonth));

                //}

                return Json("ok");
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
        public BeyannameController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }
        public JsonResult moodUploadBeyannameChk(XMlook pageIndex)
        {

            var file = pageIndex.file;
            List<string> nlistZipurl = new List<string>();
            string uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");


            long CompID = 0;
            int nYear = 0;

            try
            {

                //CompID = Convert.ToInt64(pageIndex.ide);
                //nYear = pageIndex.id;





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
        public async Task<JsonResult> moodUploadBeyannameChkz(XMlook pageIndex)
        {
            bool ISNoAdmin = true;
            var currentUser = Int64.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var isusrAdmn = HhvnUsers.GetRow_User(currentUser);
            if (isusrAdmn.UserTypeID == 1001)
            {
                ISNoAdmin = false;
            }
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
                    return Json("nok_Hatalı PDF Yükleme - KURUMLAR VERGİSİ BEYANNAMESİ - GEÇİCİ VERGİ BEYANNAMESİ - YILLIK GELİR VERGİSİ BEYANNAMESİ Olmalı");
                }

                if (chhhkt != null)
                {
                    ISGeciciVergi = true;
                }

                ReadPdfPg chhhk1 = CHKgROUP.Where(x => x.LineContent.Contains("Yıl ")).FirstOrDefault();
                string txt1Yil = string.Empty;
                string chkyil1 = string.Empty;
                string chkyil3 = string.Empty;

                if (ISGeciciVergi)
                {
                    chhhk1 = CHKgROUP.Where(x => x.LineContent.Contains("Yılı")).FirstOrDefault();
                    var chhhkyilt = CHKgROUP.Where(x => x.CounterNo == chhhk1.CounterNo + 2).FirstOrDefault();
                    chkyil1 = chhhkyilt.LineContent.Trim();
                    chkyil3 = chhhk1.LineContent.Split(' ')[chhhk1.LineContent.Split(' ').Length - 1].Trim();
                    var chhhk1yy = CHKgROUP.Where(x => x.LineContent.Contains("Onay Zamanı ")).FirstOrDefault();
                    txt1Yil = chhhk1yy.LineContent.Replace("Onay Zamanı", string.Empty).Replace(":", string.Empty).Split('-')[0].Trim().Split('.')[2];
                }
                else
                {
                    txt1Yil = chhhk1.LineContent.Split(' ')[1].Trim();
                }
                ReadPdfPg chhhk1eposta = CHKgROUP.Where(x => x.LineContent.Contains("E-Posta Adresi")).FirstOrDefault();
                string vergino = CHKgROUP.Where(x => x.CounterNo == chhhk1eposta.CounterNo + 1).FirstOrDefault().LineContent;



                if (ISNoAdmin)
                {
                    if (vergino.Trim() != mainComp.TaxID.Trim())
                    {
                        ERRLOG lg = new ERRLOG();
                        lg.CompanyID = CompID;
                        lg.CsvID = nYear;
                        lg.ERLOG = "Hatalı Vergi No  "; lg.Save_AppLogs();
                        return Json("nok_Hatalı Vergi No ");
                    }

                }



                if (chkyil1 != nYear.ToString())
                {
                    if (chkyil3 != nYear.ToString())
                    {

                        if (Convert.ToInt32(txt1Yil) != nYear)
                        {
                            ERRLOG lg = new ERRLOG();
                            lg.CompanyID = CompID;
                            lg.CsvID = nYear;
                            lg.ERLOG = "Hatalı Yıl  "; lg.Save_AppLogs();
                            return Json("nok_Hatalı Yıl  ");
                        }

                    }
                }

                //if (TBLMizan.DeleteComapnyCountMizanByn(CompID, nYear) > 3)
                //{
                //    //ERRLOG lg = new ERRLOG();
                //    //lg.CompanyID = CompID;
                //    //lg.CsvID = nYear;
                //    //lg.ERLOG = "_Yalnızca Kapalı Mizanlarda Beyanname Yüklenebilir  "; lg.Save_AppLogs();
                //    //return Json("nok_Yalnızca Kapalı Mizanlarda Beyanname Yüklenebilir");
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
               

                List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizan.getListBYN(nYear, CompID);
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
                }
                else
                {
                    BeyannameChk.LastFinishedChk(CompID, nYear, nmonth);
                    List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizan.getListBYN(nYear, CompID);
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
              
                var chk = CHKgROUP;



                //List<DashBilancoViewMizan> nRequestList1 = DashBilancoMizan.getListbynmizanPermanent(nYear, CompID);
                //var tlist1 = Data.SetBilancoFromListMizan(nRequestList1, CompID, nYear);
                //Data.RESET_DashBilancoViewMizan(nYear, CompID);
                //Data.InsertBilncoMzn(tlist1);
                //List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizan.getListBYN(nYear, CompID);
                //var tlistRvn1 = Data.SetBilancoFromListMizan(nRequestListRvn1, CompID, nYear);
                //Data.RESET_REVENUEViewMzn(nYear, CompID);
                //Data.InsertRvnMzn(tlistRvn1);
                //var WLikiditeViez = DashLikiditeViewMainMizan.getList(nYear, CompID);
                //var WCapitalViez = DashWCapitalViewMainMizan.getList(nYear, CompID);
                //var WCapitalVie = Data.SetBilancoFromListMizan(WCapitalViez, CompID, nYear);
                //var WLikiditeVie = Data.SetBilancoFromListMizan(WLikiditeViez, CompID, nYear);
                //Data.InsertWCapitalMzn(WCapitalVie);
                //Data.InsertLiquidityMzn(WLikiditeVie);
                //DashBilancoSetMizan.Set_ReportSetMainSMM(nYear, CompID);
                //DashRasyoMizan.GetDashRasyoAnaliz(nYear, CompID);
                //DashRasyoMizan.GetDashLikiditeRiskTrend(nYear, CompID);
                //DashRasyoMizan.GetDashOzetMali(nYear, CompID);






            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = CompID;
                lg.CsvID = nYear;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                return Json(ex.ToString());
            }

            return Json("ok_");




        } 
        public async Task<JsonResult> moodUploadBeyanname(XMlook pageIndex)
        {
            string chkTxt = "Enflasyon Düzeltmesi Sonrası";
            bool ISEnflasyon = false;
            bool ISNoAdmin = true;
            var currentUser = Int64.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var isusrAdmn = HhvnUsers.GetRow_User(currentUser);
            if (isusrAdmn.UserTypeID == 1001)
            {
                ISNoAdmin = false;
            }
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
                    return Json("Hatalı PDF Yükleme - KURUMLAR VERGİSİ BEYANNAMESİ - GEÇİCİ VERGİ BEYANNAMESİ - YILLIK GELİR VERGİSİ BEYANNAMESİ Olmalı");
                }

                if (chhhkt != null)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Hatalı PDF Yükleme - Yalnızca  KURUMLAR VERGİSİ BEYANNAMESİ Bu alandan Yüklenebilir"; lg.Save_AppLogs();
                    return Json("Hatalı PDF Yükleme - Yalnızca  KURUMLAR VERGİSİ BEYANNAMESİ Bu alandan Yüklenebilir");
                 
                }

                ReadPdfPg chhhk1 = CHKgROUP.Where(x => x.LineContent.Contains("Yıl ")).FirstOrDefault();
                ReadPdfPg chhhk1eposta = CHKgROUP.Where(x => x.LineContent.Contains("E-Posta Adresi")).FirstOrDefault();
                string vergino = CHKgROUP.Where(x => x.CounterNo == chhhk1eposta.CounterNo + 1).FirstOrDefault().LineContent;
                string txt1Yil = chhhk1.LineContent.Split(' ')[1].Trim();

                string chkyil1 = string.Empty;
                string chkyil3 = string.Empty;
                if (ISNoAdmin)
                {
                    if (vergino.Trim() != mainComp.TaxID.Trim())
                    {
                        ERRLOG lg = new ERRLOG();
                        lg.CompanyID = CompID;
                        lg.CsvID = nYear;
                        lg.ERLOG = "Hatalı Vergi No  "; lg.Save_AppLogs();
                        return Json("Hatalı Vergi No ");
                    }


                }


                if (ISGeciciVergi)
                {
                    chhhk1 = CHKgROUP.Where(x => x.LineContent.Contains("Yılı")).FirstOrDefault();
                    var chhhkyilt = CHKgROUP.Where(x => x.CounterNo == chhhk1.CounterNo + 2).FirstOrDefault();
                    chkyil1 = chhhkyilt.LineContent.Trim();
                    chkyil3 = chhhk1.LineContent.Split(' ')[chhhk1.LineContent.Split(' ').Length - 1].Trim();
                    var chhhk1yy = CHKgROUP.Where(x => x.LineContent.Contains("Onay Zamanı ")).FirstOrDefault();
                    txt1Yil = chhhk1yy.LineContent.Replace("Onay Zamanı", string.Empty).Replace(":", string.Empty).Split('-')[0].Trim().Split('.')[2];
                }
                else
                {
                    txt1Yil = chhhk1.LineContent.Split(' ')[1].Trim();
                }


                if (chkyil1 != nYear.ToString())
                {
                    if (chkyil3 != nYear.ToString())
                    {

                        if (Convert.ToInt32(txt1Yil) != nYear)
                        {
                            ERRLOG lg = new ERRLOG();
                            lg.CompanyID = CompID;
                            lg.CsvID = nYear;
                            lg.ERLOG = "Hatalı Yıl  "; lg.Save_AppLogs();
                            return Json("Hatalı Yıl  ");
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
                            if (!IsNumeric(checkval) && !CHKgROUP[i].LineContent.Contains("GELİR TABLOSU") && CHKgROUP[i].LineContent.Contains(".") &&  !CHKgROUP[i].LineContent.Contains("Enflasyon") && !CHKgROUP[i].LineContent.Contains("Açıklama") && !CHKgROUP[i].LineContent.Contains("Önceki Dönem") && !CHKgROUP[i].LineContent.Contains("Cari Dönem"))
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
                    if (CHKgROUP[i].LineContent.Contains("KAR DAĞITIM TABLOSU")  )
                    {
                         
                        break;
                    }
                }
               
                //var chkkGrp2 = BeyannameResult.Get_MizanResult();
                //var tt = CHKgROUP.Where(x => chkkGrp2.Any(z => x.LineContent.Trim().Replace(" ", string.Empty).Contains(z.MainDescription.Trim().Replace(" ", string.Empty))));
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
                BeyannameChk.LastFinished(CompID, nYear,nmonth);
                var chk = CHKgROUP;


                if (!ISGeciciVergi)
                {
                    List<DashBilancoViewMizan> nRequestList1 = DashBilancoBeyan.getList(nYear, CompID);
                    var tlist1 = Data.SetBilancoFromListMizan(nRequestList1, CompID, nYear);
                    Data.RESET_DashBilancoViewMizan(nYear, CompID);
                    Data.InsertBilncoMzn(tlist1);
                }

                List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizan.getListBYN(nYear, CompID);
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
                //DashOzetMaliMizan.OzetMali9(nYear, CompID);


                if (!ISGeciciVergi)
                {
                    List<DashBilancoViewMizan> nRequestList1a = DashBilancoBeyan.getList(nYear - 1, CompID);
                    if (nRequestList1a.Count < 1)
                    {
                        return Json("ok");
                    }
                    var tlist1a = Data.SetBilancoFromListMizan(nRequestList1a, CompID, nYear - 1);
                    Data.RESET_DashBilancoViewMizan(nYear - 1, CompID);
                    Data.InsertBilncoMzn(tlist1a);

                    List<DashBilancoViewMizan> nRequestListRvn1a = DashGelirTablosuMizan.getListBYN(nYear - 1, CompID);
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
                        DashRasyoMizan.GetDashOzetMaliByn(nYear - 1, CompID);
                        //DashOzetMaliMizan.OzetMali9(nYear - 1, CompID);
                    }
                }




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

        public async Task<JsonResult> moodUploadBeyannameUpdate(XMlook pageIndex)
        {
            string chkTxt = "Enflasyon Düzeltmesi Sonrası";
            bool ISEnflasyon = false;
            bool ISNoAdmin = true;
            var currentUser = Int64.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var isusrAdmn = HhvnUsers.GetRow_User(currentUser);
            if (isusrAdmn.UserTypeID == 1001)
            {
                ISNoAdmin = false;
            }
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
                    return Json("Hatalı PDF Yükleme - KURUMLAR VERGİSİ BEYANNAMESİ - GEÇİCİ VERGİ BEYANNAMESİ - YILLIK GELİR VERGİSİ BEYANNAMESİ Olmalı");
                }

                if (chhhkt != null)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Hatalı PDF Yükleme - Yalnızca  KURUMLAR VERGİSİ BEYANNAMESİ Bu alandan Yüklenebilir"; lg.Save_AppLogs();
                    return Json("Hatalı PDF Yükleme - Yalnızca  KURUMLAR VERGİSİ BEYANNAMESİ Bu alandan Yüklenebilir");
                
                }

                ReadPdfPg chhhk1 = CHKgROUP.Where(x => x.LineContent.Contains("Yıl ")).FirstOrDefault();
                ReadPdfPg chhhk1eposta = CHKgROUP.Where(x => x.LineContent.Contains("E-Posta Adresi")).FirstOrDefault();
                string vergino = CHKgROUP.Where(x => x.CounterNo == chhhk1eposta.CounterNo + 1).FirstOrDefault().LineContent;
                string txt1Yil = chhhk1.LineContent.Split(' ')[1].Trim();
                string chkyil1 = string.Empty;
                string chkyil3 = string.Empty;

                if (ISNoAdmin)
                {
                    if (vergino.Trim() != mainComp.TaxID.Trim())
                    {
                        ERRLOG lg = new ERRLOG();
                        lg.CompanyID = CompID;
                        lg.CsvID = nYear;
                        lg.ERLOG = "Hatalı Vergi No  "; lg.Save_AppLogs();
                        return Json("Hatalı Vergi No ");
                    }


                }


                if (ISGeciciVergi)
                {
                    chhhk1 = CHKgROUP.Where(x => x.LineContent.Contains("Yılı")).FirstOrDefault();
                    var chhhkyilt = CHKgROUP.Where(x => x.CounterNo == chhhk1.CounterNo + 2).FirstOrDefault();
                    chkyil1 = chhhkyilt.LineContent.Trim();
                    chkyil3 = chhhk1.LineContent.Split(' ')[chhhk1.LineContent.Split(' ').Length - 1].Trim();
                    var chhhk1yy = CHKgROUP.Where(x => x.LineContent.Contains("Onay Zamanı ")).FirstOrDefault();
                    txt1Yil = chhhk1yy.LineContent.Replace("Onay Zamanı", string.Empty).Replace(":", string.Empty).Split('-')[0].Trim().Split('.')[2];
                }
                else
                {
                    txt1Yil = chhhk1.LineContent.Split(' ')[1].Trim();
                }

                if (chkyil1 != nYear.ToString())
                {
                    if (chkyil3 != nYear.ToString())
                    {

                        if (Convert.ToInt32(txt1Yil) != nYear)
                        {
                            ERRLOG lg = new ERRLOG();
                            lg.CompanyID = CompID;
                            lg.CsvID = nYear;
                            lg.ERLOG = "Hatalı Yıl  "; lg.Save_AppLogs();
                            return Json("Hatalı Yıl  ");
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
                            checkval = CHKgROUP[i].LineContent.Length > 1? CHKgROUP[i].LineContent.Replace(". ", string.Empty).Substring(0, 1) : string.Empty;
                            if (!IsNumeric(checkval) && !CHKgROUP[i].LineContent.Contains("GELİR TABLOSU") && CHKgROUP[i].LineContent.Contains(".") && !CHKgROUP[i].LineContent.Contains("Enflasyon") && !CHKgROUP[i].LineContent.Contains("Açıklama") && !CHKgROUP[i].LineContent.Contains("Önceki Dönem") && !CHKgROUP[i].LineContent.Contains("Cari Dönem"))
                            {
                            if (!checkval.Contains('(')  )
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
                            checkval = CHKgROUP[i].LineContent.Length  > 1  ? CHKgROUP[i].LineContent.Replace(". ", string.Empty).Substring(0, 1) : string.Empty;
                            if (!IsNumeric(checkval) && !CHKgROUP[i].LineContent.Contains("GELİR TABLOSU") && CHKgROUP[i].LineContent.Contains(".") && !CHKgROUP[i].LineContent.Contains("Enflasyon") && !CHKgROUP[i].LineContent.Contains("Açıklama") && !CHKgROUP[i].LineContent.Contains("Önceki Dönem") && !CHKgROUP[i].LineContent.Contains("Cari Dönem"))
                            {
                            if (!checkval.Contains('(') )
                            {
                                checkval1 = checkval;
                            }
                          
                            }
                            CHKgROUP[i].MainID = "Z";
                            CHKgROUP[i].SubID = checkval1;
                            CHKgROUP[i].IsRevenue = 1;
                            nliste.Add(CHKgROUP[i]);
                        }
                    if (CHKgROUP[i].LineContent.Contains("KAR DAĞITIM TABLOSU")  )
                    {
                     
 
                        break;
                    }
                }

                //var chkkGrp2 = BeyannameResult.Get_MizanResult();

                //var tt = CHKgROUP.Where(x => chkkGrp2.Any(z => x.LineContent.Trim().Replace(" ", string.Empty).Contains(z.MainDescription.Trim().Replace(" ", string.Empty))));
                var chkssst = nliste;



                nliste.Select(c => { c.IsGecici = 0; return c; }).ToList();
                if (ISEnflasyon)
                {
                    nliste.Select(c => { c.IsEnflasyon = 1; return c; }).ToList();
                }


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
                BeyannameChk.LastFinished(CompID, nYear,nmonth);



                if (!ISGeciciVergi)
                {
                    List<DashBilancoViewMizan> nRequestList1 = DashBilancoBeyan.getList(nYear, CompID);
                    var tlist1 = Data.SetBilancoFromListMizan(nRequestList1, CompID, nYear);
                    Data.RESET_DashBilancoViewMizan(nYear, CompID);
                    Data.InsertBilncoMzn(tlist1);

                }


                List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizan.getListBYN(nYear, CompID);
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
                //DashOzetMaliMizan.OzetMali9(nYear, CompID);

                if (!ISGeciciVergi)
                {
                    List<DashBilancoViewMizan> nRequestList1a = DashBilancoBeyan.getList(nYear - 1, CompID);
                    if (nRequestList1a.Count < 1)
                    {
                        return Json("ok");
                    }
                    var tlist1a = Data.SetBilancoFromListMizan(nRequestList1a, CompID, nYear - 1);
                    Data.RESET_DashBilancoViewMizan(nYear - 1, CompID);
                    Data.InsertBilncoMzn(tlist1a);
                    List<DashBilancoViewMizan> nRequestListRvn1a = DashGelirTablosuMizan.getListBYN(nYear - 1, CompID);
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
                        DashRasyoMizan.GetDashOzetMaliByn(nYear - 1, CompID);
                        //DashOzetMaliMizan.OzetMali9(nYear - 1, CompID);
                    }



                }




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
        public static bool IsNumeric(object Expression)
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
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
    }
    public class ReadPdfPg
    {
        public string SubID { get; set; }
        public string MainID { get; set; }
        public int CounterNo { get; set; }
        public string LineContent { get; set; }
        public byte IsRevenue { get; set; }
        public byte IsGecici { get; set; }
        public byte IsEnflasyon { get; set; }
        public byte IsGeciciNew { get; set; }
    }

    public class ReadPdfMizan
    {

        //e.Columns[0].ColumnName = "AccountMainID";
        //    e.Columns[1].ColumnName = "AccountMainDescription";
        //    e.Columns[2].ColumnName = "DebitAmount";
        //    e.Columns[3].ColumnName = "CreditAmount";
        //    e.Columns[4].ColumnName = "AmountBakiye";
        public string AmountBakiye { get; set; }
        public string CreditAmount { get; set; }
        public string DebitAmount { get; set; }
        public string AccountMainDescription { get; set; }
        public string AccountMainID { get; set; }
        public int CounterNo { get; set; }
        public string LineContent { get; set; }
        public byte IsRevenue { get; set; }

    }
}
