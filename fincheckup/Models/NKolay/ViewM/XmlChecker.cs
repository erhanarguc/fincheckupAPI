using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using fincheckup.ENTITY;
using fincheckup.Models.NKolay;
using fincheckup.Models.NKolay.ENTITY.NwEntity;
using fincheckup.Models.NKolay.ViewM;
using fincheckup.Services;

namespace fincheckup.Models.ViewM
{
    public class XmlChecker
    {
        public static async Task<string> XmlCheck(bool xmltypeid, int isupdate, long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string orjinalName,bool IsLastMOnth, List<WzoneRow> chkXmlList = null, List<TBLErrzoneInsideWordRow> chkWrdList = null, List<ErrorCheckSet> errChkList = null, List<TBLErrzoneRow> chkXmlerList = null)
        {

            switch (xmltypeid)
            {

                case false:
                    if (isupdate == 0)
                    {
                        return await NominalCheck(compid, pathfile, filemonth, fileyear, fzip, orjinalName, IsLastMOnth, chkXmlList, chkWrdList, errChkList);
                        // return IsbankCheck(compid, pathfile, filemonth, fileyear);
                    }
                    else
                    {
                        return await NominalCheckUpdate(compid, pathfile, filemonth, fileyear, fzip, orjinalName, IsLastMOnth, chkXmlList, chkWrdList, errChkList);
                        //  return IsbankCheckUpdate(compid, pathfile, filemonth, fileyear);

                    };
                case true:
                    if (isupdate == 0)
                    {
                        return SapEntegratorCheck(compid, pathfile, filemonth, fileyear, fzip, orjinalName, IsLastMOnth);
                        //return UyumsoftCheck(compid, pathfile, filemonth, fileyear);
                    }
                    else
                    {
                        return SapEntegratorCheckUpdate(compid, pathfile, filemonth, fileyear, fzip, orjinalName, IsLastMOnth);
                        // return UyumsoftCheckUpdate(compid, pathfile, filemonth, fileyear);

                    }
                   ;


            }

        }
        public static async Task<string> XmlCheckChk(bool xmltypeid, int isupdate, long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string orjinalName, bool IsLastMOnth)
        {

            switch (xmltypeid)
            {

                case false:
                    if (isupdate == 0)
                    {
                        return await NominalCheckChk(compid, pathfile, filemonth, fileyear, fzip, orjinalName, IsLastMOnth);
                        // return IsbankCheck(compid, pathfile, filemonth, fileyear);
                    }
                    else
                    {
                        return await NominalCheckUpdateChk(compid, pathfile, filemonth, fileyear, fzip, orjinalName, IsLastMOnth);
                        //  return IsbankCheckUpdate(compid, pathfile, filemonth, fileyear);

                    }
                    ;
                case true:
                    if (isupdate == 0)
                    {
                        return SapEntegratorCheck(compid, pathfile, filemonth, fileyear, fzip, orjinalName, IsLastMOnth);
                        //return UyumsoftCheck(compid, pathfile, filemonth, fileyear);
                    }
                    else
                    {
                        return SapEntegratorCheckUpdate(compid, pathfile, filemonth, fileyear, fzip, orjinalName, IsLastMOnth);
                        // return UyumsoftCheckUpdate(compid, pathfile, filemonth, fileyear);

                    }
                   ;


            }

        }
        public static async Task<string> NominalCheck(long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string filenameorjinal
          , bool IsLastMOnth, List<WzoneRow> chkXmlList = null,List<TBLErrzoneInsideWordRow> chkWrdList=null, List<ErrorCheckSet> errChkList=null, List<TBLErrzoneRow> chkXmlerList = null)
        {
            List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader> resultt = new List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader>();
            fincheckup.Models.NominalXML.defter result = new fincheckup.Models.NominalXML.defter();
            XmlSerializer serializerz = new XmlSerializer(typeof(fincheckup.Models.NominalXML.defter));

            try
            {
                for (int i = 0; i < fzip.Count; i++)
                {
                    using (FileStream fileStream = new FileStream(fzip[i], FileMode.Open))
                    {
                        result = (fincheckup.Models.NominalXML.defter)serializerz.Deserialize(fileStream);
                    }
                    resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
                }
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = 9999;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;
                return "nok";
            }
            var chkkky1 = resultt;

            result.xbrl.accountingEntries.entryHeader = chkkky1.ToArray();

            string mMonth = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Month.ToString();
            string myear = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Year.ToString();
            long csidemain = 0;
            TBLXmlFile nfile = new TBLXmlFile();
            if (mMonth == filemonth && myear == fileyear)
            {
                try
                {
                    string filename = Path.GetFileName(fzip[0]);
                    TBLXml ncs = new TBLXml();
                    ncs.CompanyID = compid;
                    ncs.CreatedDate = DateTime.Now;
                    ncs.DocumentDate = DateTime.Now;
                    ncs.CsvName = filename;
                    ncs.XmlDocName = filenameorjinal;
                    ncs.Save_TBLXml();
                    csidemain = ncs.ID;

                    nfile = new TBLXmlFile();
                    nfile.CsvName = fzip[0];
                    nfile.SortID = 1;
                    nfile.TBLXmlID = csidemain;
                    nfile.Save_TBLXmlFile();

                    var ttest = Dataz.SetValueFromNominal(result, ncs.ID, nfile.ID);

                    ncs.Year = ttest[0].EndDate.Year;
                    ncs.DocumentDate = ttest[0].EndDate;
                    ncs.Update_TBLXml();

                    Data dat = new Data();





                
                     List<ErrorCheckSet> errorStList = errChkList;
                     List<TBLErrzoneInsideWordRow> xmlWordList = chkWrdList;
                     List<WzoneRow> wZoneList = chkXmlList;
                    List<TBLErrzoneRow> chkXmlerListchk = chkXmlerList;

                    if (wZoneList == null) 
                      wZoneList = TBLXmlFile.getXmlList();

                    if (xmlWordList == null) 
                        xmlWordList = TBLXmlFile.getWordXml();
                    
                    if (errorStList == null)
                      errorStList = ErrorCheckMain.Get_ReportSet();

                    if (chkXmlerListchk == null)
                        chkXmlerListchk = ErrorCheckMain.Get_ReportErrSet();

                    var rule  = new XmlOpener(ttest, Convert.ToInt32(mMonth));
                    ttest = await rule.ProcessXmlGroup();
                    var chkTest = ttest.Where(x => (x.IsOpener == 0 || x.IsPassedEntry == 0)).ToList();
                    
                    var ruleAudit = new XmlPipelineAudit(chkTest, errorStList, xmlWordList);
                    var controlList=  await ruleAudit.RunAllAndPersistAsync(Database.ConnectionString, ncs.ID);
                    var rule1 = new XmlPipeline(ttest, wZoneList, controlList.Select(x=>x.EntryNo).ToList());
                    var resultLast=   await rule1.ProcessXmlGroup(); 

                    var objBulk = new BulkUploadToSql<Dataz>()
                    {
                        InternalStore = resultLast,
                        TableName = "[TBLXMLSource]",
                        CommitBatchSize = 50000,
                        ConnectionString = Database.ConnectionString
                    };
                    objBulk.Commit();

                    Data dtx = new Data();

                    dtx.SetHataLast(ncs.ID);

                    dtx.SetHataLastz(ncs.ID);


                    dtx.SetHataLastza(Convert.ToInt32(ncs.CompanyID), ttest[0].EndDate.Year);
                    DataViewerErroredCountCsv SetCounteR = MainDash.Get_DatabyErrorbyCsv(ncs.ID);

                    return ncs.ID.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
                }
                catch (Exception ex)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = compid;
                    lg.CsvID = csidemain;
                    lg.ERLOG = ex.ToString();
                    lg.Save_AppLogs();
                    var chk = ex;
                    TBLXml.RESET_TBLXml(csidemain);
                    return "nok";
                }

            }
            else
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = 5555;
                lg.ERLOG = filemonth + "  " + fileyear + " tarihli";
                lg.Save_AppLogs();
                return "nok";
            }

        }

        public static async Task<string> NominalCheckWithAudit(long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string filenameorjinal
  , bool IsLastMOnth, List<WzoneRow> chkXmlList = null, List<TBLErrzoneInsideWordRow> chkWrdList = null, List<ErrorCheckSet> errChkList = null, List<TBLErrzoneRow> chkXmlerList = null)
        {
            List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader> resultt = new List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader>();
            fincheckup.Models.NominalXML.defter result = new fincheckup.Models.NominalXML.defter();
            XmlSerializer serializerz = new XmlSerializer(typeof(fincheckup.Models.NominalXML.defter));

            try
            {
                for (int i = 0; i < fzip.Count; i++)
                {
                    using (FileStream fileStream = new FileStream(fzip[i], FileMode.Open))
                    {
                        result = (fincheckup.Models.NominalXML.defter)serializerz.Deserialize(fileStream);
                    }
                    resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
                }
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = 9999;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;
                return "nok";
            }
            var chkkky1 = resultt;

            result.xbrl.accountingEntries.entryHeader = chkkky1.ToArray();

            string mMonth = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Month.ToString();
            string myear = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Year.ToString();
            long csidemain = 0;
            TBLXmlFile nfile = new TBLXmlFile();
            if (mMonth == filemonth && myear == fileyear)
            {
                try
                {
                    string filename = Path.GetFileName(fzip[0]);
                    TBLXml ncs = new TBLXml();
                    ncs.CompanyID = compid;
                    ncs.CreatedDate = DateTime.Now;
                    ncs.DocumentDate = DateTime.Now;
                    ncs.CsvName = filename;
                    ncs.XmlDocName = filenameorjinal;
                    ncs.Save_TBLXml();
                    csidemain = ncs.ID;

                    nfile = new TBLXmlFile();
                    nfile.CsvName = fzip[0];
                    nfile.SortID = 1;
                    nfile.TBLXmlID = csidemain;
                    nfile.Save_TBLXmlFile();

                    var ttest = Dataz.SetValueFromNominal(result, ncs.ID, nfile.ID);

                    ncs.Year = ttest[0].EndDate.Year;
                    ncs.DocumentDate = ttest[0].EndDate;
                    ncs.Update_TBLXml();

                    Data dat = new Data();






                    List<ErrorCheckSet> errorStList = errChkList;
                    List<TBLErrzoneInsideWordRow> xmlWordList = chkWrdList;
                    List<WzoneRow> wZoneList = chkXmlList;
                    List<TBLErrzoneRow> chkXmlerListchk = chkXmlerList;

                    if (wZoneList == null)
                        wZoneList = TBLXmlFile.getXmlList();

                    if (xmlWordList == null)
                        xmlWordList = TBLXmlFile.getWordXml();

                    if (errorStList == null)
                        errorStList = ErrorCheckMain.Get_ReportSet();

                    if (chkXmlerListchk == null)
                        chkXmlerListchk = ErrorCheckMain.Get_ReportErrSet();

                    var rule = new XmlOpener(ttest, Convert.ToInt32(mMonth));
                    ttest = await rule.ProcessXmlGroup();
                    var chkTest = ttest.Where(x => (x.IsOpener == 0 || x.IsPassedEntry == 0)).ToList();

                    var ruleAudit = new XmlPipelineAudit(chkTest, errorStList, xmlWordList);
                    var controlList = await ruleAudit.RunAllAndPersistAsync(Database.ConnectionString, ncs.ID);
                    var rule1 = new XmlPipeline(ttest, wZoneList, controlList.Select(x => x.EntryNo).ToList());
                    var resultLast = await rule1.ProcessXmlGroup();
                    var chkkontorll = new XmlControlResult(resultLast, controlList, errorStList, chkXmlerListchk);
                    var chkte1 = await chkkontorll.ProcessXmlGroup(ncs.ID);
                    var chkte2 = await chkkontorll.ProcessXmlGroupA(ncs.ID);
                    var chkte3 = await chkkontorll.ProcessXmlGroupII(ncs.ID);
                    var chkte4 = await chkkontorll.ProcessXmlGroupIIA(ncs.ID);

                    var objBulk = new BulkUploadToSql<Dataz>()
                    {
                        InternalStore = resultLast,
                        TableName = "[TBLXMLSource]",
                        CommitBatchSize = 50000,
                        ConnectionString = Database.ConnectionString
                    };
                    objBulk.Commit();

                    Data dtx = new Data();

                    //dtx.SetHataLast(ncs.ID);

                    //dtx.SetHataLastz(ncs.ID);


                    //dtx.SetHataLastza(Convert.ToInt32(ncs.CompanyID), ttest[0].EndDate.Year);
                    DataViewerErroredCountCsv SetCounteR = MainDash.Get_DatabyErrorbyCsv(ncs.ID);

                    return ncs.ID.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
                }
                catch (Exception ex)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = compid;
                    lg.CsvID = csidemain;
                    lg.ERLOG = ex.ToString();
                    lg.Save_AppLogs();
                    var chk = ex;
                    TBLXml.RESET_TBLXml(csidemain);
                    return "nok";
                }

            }
            else
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = 5555;
                lg.ERLOG = filemonth + "  " + fileyear + " tarihli";
                lg.Save_AppLogs();
                return "nok";
            }

        }

        public static async Task<string> NominalCheckChk(long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string filenameorjinal
  , bool IsLastMOnth)
        {
            List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader> resultt = new List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader>();
            fincheckup.Models.NominalXML.defter result = new fincheckup.Models.NominalXML.defter();
            XmlSerializer serializerz = new XmlSerializer(typeof(fincheckup.Models.NominalXML.defter));

            try
            {
                for (int i = 0; i < fzip.Count; i++)
                {
                    using (FileStream fileStream = new FileStream(fzip[i], FileMode.Open))
                    {
                        result = (fincheckup.Models.NominalXML.defter)serializerz.Deserialize(fileStream);
                    }
                    resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
                }
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = 9999;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;
                return "nok";
            }
            var chkkky1 = resultt;

            result.xbrl.accountingEntries.entryHeader = chkkky1.ToArray();

            string mMonth = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Month.ToString();
            string myear = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Year.ToString();
            long csidemain = 0;
            TBLXmlFile nfile = new TBLXmlFile();
            if (mMonth == filemonth && myear == fileyear)
            {
                try
                {
                    string filename = Path.GetFileName(fzip[0]);
                    TBLXml ncs = new TBLXml();
                    ncs.CompanyID = compid;
                    ncs.CreatedDate = DateTime.Now;
                    ncs.DocumentDate = DateTime.Now;
                    ncs.CsvName = filename;
                    ncs.XmlDocName = filenameorjinal;
                    ncs.Save_TBLXml();
                    csidemain = ncs.ID;

                    nfile = new TBLXmlFile();
                    nfile.CsvName = fzip[0];
                    nfile.SortID = 1;
                    nfile.TBLXmlID = csidemain;
                    nfile.Save_TBLXmlFile();

                    var ttest = Dataz.SetValueFromNominal(result, ncs.ID, nfile.ID);

                    ncs.Year = ttest[0].EndDate.Year;
                    ncs.DocumentDate = ttest[0].EndDate;
                    ncs.Update_TBLXml();

                    Data dat = new Data();

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
                    Data.SetOpener(ncs.ID, mMonth, IsLastMOnth);

                    Data dtx = new Data();

                    dtx.SetHataLast(ncs.ID);

                    dtx.SetHataLastz(ncs.ID);


                    dtx.SetHataLastza(Convert.ToInt32(ncs.CompanyID), ttest[0].EndDate.Year);

                    //var cmlCheckList = TBLXmlFile.getSettedXml(ncs.ID, nfile.ID);

                    //var wZoneList = TBLXmlFile.getXmlList();
                    //var xmlWordList = TBLXmlFile.getWordXml();
                    //var errorStList = ErrorCheckMain.Get_ReportSet();
                    //var rule1 = new XmlPipeline(cmlCheckList, wZoneList);
                    //var ruleAudit = new XmlPipelineAudit(cmlCheckList, errorStList, xmlWordList);
                    //await rule1.ProcessXmlGroup(ncs.ID, nfile.ID);
                    //await ruleAudit.RunAllAndPersistAsync(Database.ConnectionString, ncs.ID);

                    DataViewerErroredCountCsv SetCounteR = MainDash.Get_DatabyErrorbyCsv(ncs.ID);

                    return ncs.ID.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
                }
                catch (Exception ex)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = compid;
                    lg.CsvID = csidemain;
                    lg.ERLOG = ex.ToString();
                    lg.Save_AppLogs();
                    var chk = ex;
                    TBLXml.RESET_TBLXml(csidemain);
                    return "nok";
                }

            }
            else
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = 5555;
                lg.ERLOG = filemonth + "  " + fileyear + " tarihli";
                lg.Save_AppLogs();
                return "nok";
            }

        }
        public static string UpdateChek(int CsvID, List<Dataz> ttest, int monthid, long compid)
        {
            try
            {

                TBLXml.RESET_TBLXmlUpdate(CsvID);


                Data dat = new Data();
                // dat.InsertTB(ttest);
                var objBulk = new BulkUploadToSql<Dataz>()
                {
                    InternalStore = ttest,
                    TableName = "[TBLXMLSource]",
                    CommitBatchSize = 100000,
                    ConnectionString = Database.ConnectionString
                };
                objBulk.Commit();
                //Data.SetOpener(CsvID, monthid.ToString());






                Data dtx = new Data();

                dtx.SetHataLast(CsvID);

                dtx.SetHataLastz(CsvID);


                dtx.SetHataLastza(Convert.ToInt32(compid), ttest[0].EndDate.Year);



                DataViewerErroredCountCsv SetCounteR = MainDash.Get_DatabyErrorbyCsv(CsvID);

                return CsvID.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = CsvID;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;

                return "nok";
            }



        }
        public static async Task<string> NominalCheckUpdate(long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string filenameorjinal, bool IsLastMOnth, List<WzoneRow> chkXmlList = null, List<TBLErrzoneInsideWordRow> chkWrdList = null, List<ErrorCheckSet> errChkList = null, List<TBLErrzoneRow> chkXmlerList = null)
        {
            List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader> resultt = new List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader>();
            fincheckup.Models.NominalXML.defter result = new fincheckup.Models.NominalXML.defter();
            XmlSerializer serializerz = new XmlSerializer(typeof(fincheckup.Models.NominalXML.defter));
            try
            {
                for (int i = 0; i < fzip.Count; i++)
                {
                    using (FileStream fileStream = new FileStream(fzip[i], FileMode.Open))
                    {
                        result = (fincheckup.Models.NominalXML.defter)serializerz.Deserialize(fileStream);
                    }
                    resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
                }
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = 9999;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();

                return "nok";
            }


            var chkkky1 = resultt;

            result.xbrl.accountingEntries.entryHeader = chkkky1.ToArray();
            string mMonth = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Month.ToString();
            string myear = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Year.ToString();
            long csidemain = 0;
            TBLXmlFile nfile = new TBLXmlFile();
            if (mMonth == filemonth && myear == fileyear)
            {
                try
                {
                    string filename = Path.GetFileName(fzip[0]);
                    TBLXml ncs = new TBLXml();
                    ncs.CompanyID = compid;
                    ncs.CreatedDate = DateTime.Now;
                    ncs.DocumentDate = DateTime.Now;
                    ncs.CsvName = filename;
                    ncs.XmlDocName = filenameorjinal;
                    ncs.Save_TBLXml();
                    csidemain = ncs.ID;
                    nfile = new TBLXmlFile();
                    nfile.CsvName = fzip[0];
                    nfile.SortID = 1;
                    nfile.TBLXmlID = csidemain;
                    nfile.Save_TBLXmlFile();

                    var ttest = Dataz.SetValueFromNominal(result, ncs.ID, nfile.ID);

                    ncs.Year = ttest[0].EndDate.Year;
                    ncs.DocumentDate = ttest[0].EndDate;
                    ncs.Update_TBLXml();
                    //var nlistMon = TBLXml.Get_TBLXmlCompany(ncs.CompanyID.ToString()).Where(x => x.DocumentDate.Year == Convert.ToInt32(fileyear) && x.DocumentDate.Month == Convert.ToInt32(filemonth) && x.ID != ncs.ID) ;
                    //foreach (var item in nlistMon)
                    //{
                    //    TBLXml.RESET_TBLXml(item.ID);
                    //}
                    TBLXml.RESETALL_byCompanyID(Convert.ToInt32(fileyear), compid, Convert.ToInt32(mMonth), ncs.ID);

                    List<ErrorCheckSet> errorStList = errChkList;
                    List<TBLErrzoneInsideWordRow> xmlWordList = chkWrdList;
                    List<WzoneRow> wZoneList = chkXmlList;
                    List<TBLErrzoneRow> wZonErrList = chkXmlerList;
                    

                    if (chkXmlList == null)
                        wZoneList = TBLXmlFile.getXmlList();

                    if (xmlWordList == null)
                        xmlWordList = TBLXmlFile.getWordXml();

                    if (errChkList == null)
                        errorStList = ErrorCheckMain.Get_ReportSet();

                    if (chkXmlerList == null)
                        chkXmlerList = ErrorCheckMain.Get_ReportErrSet();


                    var rule = new XmlOpener(ttest, Convert.ToInt32(mMonth));
                    ttest = await rule.ProcessXmlGroup();
                    var chkTest = ttest.Where(x => (x.IsOpener == 0 || x.IsPassedEntry == 0)).ToList();
                   
                    var ruleAudit = new XmlPipelineAudit(chkTest, errorStList, xmlWordList);
                    var controlList=  await ruleAudit.RunAllAndPersistAsync(Database.ConnectionString, ncs.ID);
                    var rule1 = new XmlPipeline(ttest, wZoneList, controlList.Select(x=>x.EntryNo).ToList());
                    var resultLast = await rule1.ProcessXmlGroup();

                 

                    var objBulk = new BulkUploadToSql<Dataz>()
                    {
                        InternalStore = resultLast,
                        TableName = "[TBLXMLSource]",
                        CommitBatchSize = 50000,
                        ConnectionString = Database.ConnectionString
                    };
                    objBulk.Commit();

                    Data dtx = new Data();

                    dtx.SetHataLast(ncs.ID);

                    dtx.SetHataLastz(ncs.ID);


                    dtx.SetHataLastza(Convert.ToInt32(ncs.CompanyID), ttest[0].EndDate.Year);
                    DataViewerErroredCountCsv SetCounteR = MainDash.Get_DatabyErrorbyCsv(ncs.ID);

                    return ncs.ID.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
                }
                catch (Exception ex)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = compid;
                    lg.CsvID = csidemain;
                    lg.ERLOG = ex.ToString();
                    TBLXml.RESET_TBLXml(csidemain); lg.Save_AppLogs();
                    return "nok";
                }

            }
            else
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = 5555;
                lg.ERLOG = filemonth + "  " + fileyear + " tarihli";
                lg.Save_AppLogs();
                return "nok";
            }

        }

        public static async Task<string> NominalCheckUpdateWithAudit(long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string filenameorjinal, bool IsLastMOnth, List<WzoneRow> chkXmlList = null, List<TBLErrzoneInsideWordRow> chkWrdList = null, List<ErrorCheckSet> errChkList = null, List<TBLErrzoneRow> chkXmlerList = null)
        {
            List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader> resultt = new List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader>();
            fincheckup.Models.NominalXML.defter result = new fincheckup.Models.NominalXML.defter();
            XmlSerializer serializerz = new XmlSerializer(typeof(fincheckup.Models.NominalXML.defter));
            try
            {
                for (int i = 0; i < fzip.Count; i++)
                {
                    using (FileStream fileStream = new FileStream(fzip[i], FileMode.Open))
                    {
                        result = (fincheckup.Models.NominalXML.defter)serializerz.Deserialize(fileStream);
                    }
                    resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
                }
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = 9999;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();

                return "nok";
            }


            var chkkky1 = resultt;

            result.xbrl.accountingEntries.entryHeader = chkkky1.ToArray();
            string mMonth = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Month.ToString();
            string myear = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Year.ToString();
            long csidemain = 0;
            TBLXmlFile nfile = new TBLXmlFile();
            if (mMonth == filemonth && myear == fileyear)
            {
                try
                {
                    string filename = Path.GetFileName(fzip[0]);
                    TBLXml ncs = new TBLXml();
                    ncs.CompanyID = compid;
                    ncs.CreatedDate = DateTime.Now;
                    ncs.DocumentDate = DateTime.Now;
                    ncs.CsvName = filename;
                    ncs.XmlDocName = filenameorjinal;
                    ncs.Save_TBLXml();
                    csidemain = ncs.ID;
                    nfile = new TBLXmlFile();
                    nfile.CsvName = fzip[0];
                    nfile.SortID = 1;
                    nfile.TBLXmlID = csidemain;
                    nfile.Save_TBLXmlFile();

                    var ttest = Dataz.SetValueFromNominal(result, ncs.ID, nfile.ID);

                    ncs.Year = ttest[0].EndDate.Year;
                    ncs.DocumentDate = ttest[0].EndDate;
                    ncs.Update_TBLXml();
                    //var nlistMon = TBLXml.Get_TBLXmlCompany(ncs.CompanyID.ToString()).Where(x => x.DocumentDate.Year == Convert.ToInt32(fileyear) && x.DocumentDate.Month == Convert.ToInt32(filemonth) && x.ID != ncs.ID) ;
                    //foreach (var item in nlistMon)
                    //{
                    //    TBLXml.RESET_TBLXml(item.ID);
                    //}
                    TBLXml.RESETALL_byCompanyID(Convert.ToInt32(fileyear), compid, Convert.ToInt32(mMonth), ncs.ID);

                    List<ErrorCheckSet> errorStList = errChkList;
                    List<TBLErrzoneInsideWordRow> xmlWordList = chkWrdList;
                    List<WzoneRow> wZoneList = chkXmlList;
                    List<TBLErrzoneRow> wZonErrList = chkXmlerList;


                    if (chkXmlList == null)
                        wZoneList = TBLXmlFile.getXmlList();

                    if (xmlWordList == null)
                        xmlWordList = TBLXmlFile.getWordXml();

                    if (errChkList == null)
                        errorStList = ErrorCheckMain.Get_ReportSet();

                    if (chkXmlerList == null)
                        chkXmlerList = ErrorCheckMain.Get_ReportErrSet();


                    var rule = new XmlOpener(ttest, Convert.ToInt32(mMonth));
                    ttest = await rule.ProcessXmlGroup();
                    var chkTest = ttest.Where(x => (x.IsOpener == 0 || x.IsPassedEntry == 0)).ToList();

                    var ruleAudit = new XmlPipelineAudit(chkTest, errorStList, xmlWordList);
                    var controlList = await ruleAudit.RunAllAndPersistAsync(Database.ConnectionString, ncs.ID);
                    var rule1 = new XmlPipeline(ttest, wZoneList, controlList.Select(x => x.EntryNo).ToList());
                    var resultLast = await rule1.ProcessXmlGroup();

                    var chkkontorll = new XmlControlResult(resultLast, controlList, errorStList, chkXmlerList);
                    var chkte1 = await chkkontorll.ProcessXmlGroup(ncs.ID);
                    var chkte2 = await chkkontorll.ProcessXmlGroupA(ncs.ID);
                    var chkte3 = await chkkontorll.ProcessXmlGroupII(ncs.ID);
                    var chkte4 = await chkkontorll.ProcessXmlGroupIIA(ncs.ID);

                    var objBulk = new BulkUploadToSql<Dataz>()
                    {
                        InternalStore = resultLast,
                        TableName = "[TBLXMLSource]",
                        CommitBatchSize = 50000,
                        ConnectionString = Database.ConnectionString
                    };
                    objBulk.Commit();

                    Data dtx = new Data();

                    //dtx.SetHataLast(ncs.ID);

                    //dtx.SetHataLastz(ncs.ID);


                    //dtx.SetHataLastza(Convert.ToInt32(ncs.CompanyID), ttest[0].EndDate.Year);
                    DataViewerErroredCountCsv SetCounteR = MainDash.Get_DatabyErrorbyCsv(ncs.ID);

                    return ncs.ID.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
                }
                catch (Exception ex)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = compid;
                    lg.CsvID = csidemain;
                    lg.ERLOG = ex.ToString();
                    TBLXml.RESET_TBLXml(csidemain); lg.Save_AppLogs();
                    return "nok";
                }

            }
            else
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = 5555;
                lg.ERLOG = filemonth + "  " + fileyear + " tarihli";
                lg.Save_AppLogs();
                return "nok";
            }

        }
        public static async Task<string> NominalCheckUpdateChk(long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string filenameorjinal, bool IsLastMOnth)
        {
            List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader> resultt = new List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader>();
            fincheckup.Models.NominalXML.defter result = new fincheckup.Models.NominalXML.defter();
            XmlSerializer serializerz = new XmlSerializer(typeof(fincheckup.Models.NominalXML.defter));
            try
            {
                for (int i = 0; i < fzip.Count; i++)
                {
                    using (FileStream fileStream = new FileStream(fzip[i], FileMode.Open))
                    {
                        result = (fincheckup.Models.NominalXML.defter)serializerz.Deserialize(fileStream);
                    }
                    resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
                }
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = 9999;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();

                return "nok";
            }


            var chkkky1 = resultt;

            result.xbrl.accountingEntries.entryHeader = chkkky1.ToArray();
            string mMonth = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Month.ToString();
            string myear = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Year.ToString();
            long csidemain = 0;
            TBLXmlFile nfile = new TBLXmlFile();
            if (mMonth == filemonth && myear == fileyear)
            {
                try
                {
                    string filename = Path.GetFileName(fzip[0]);
                    TBLXml ncs = new TBLXml();
                    ncs.CompanyID = compid;
                    ncs.CreatedDate = DateTime.Now;
                    ncs.DocumentDate = DateTime.Now;
                    ncs.CsvName = filename;
                    ncs.XmlDocName = filenameorjinal;
                    ncs.Save_TBLXml();
                    csidemain = ncs.ID;
                    nfile = new TBLXmlFile();
                    nfile.CsvName = fzip[0];
                    nfile.SortID = 1;
                    nfile.TBLXmlID = csidemain;
                    nfile.Save_TBLXmlFile();

                    var ttest = Dataz.SetValueFromNominal(result, ncs.ID, nfile.ID);

                    ncs.Year = ttest[0].EndDate.Year;
                    ncs.DocumentDate = ttest[0].EndDate;
                    ncs.Update_TBLXml();
                    //var nlistMon = TBLXml.Get_TBLXmlCompany(ncs.CompanyID.ToString()).Where(x => x.DocumentDate.Year == Convert.ToInt32(fileyear) && x.DocumentDate.Month == Convert.ToInt32(filemonth) && x.ID != ncs.ID) ;
                    //foreach (var item in nlistMon)
                    //{
                    //    TBLXml.RESET_TBLXml(item.ID);
                    //}
                    TBLXml.RESETALL_byCompanyID(Convert.ToInt32(fileyear), compid, Convert.ToInt32(mMonth), ncs.ID);

                    ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();


                    Data dat = new Data();
                    // dat.InsertTB(ttest);
                    var objBulk = new BulkUploadToSql<Dataz>()
                    {
                        InternalStore = ttest,
                        TableName = "[TBLXMLSource]",
                        CommitBatchSize = 100000,
                        ConnectionString = Database.ConnectionString
                    };
                    objBulk.Commit();


                    Data.SetOpener(ncs.ID, mMonth, IsLastMOnth);







                    Data dtx = new Data();

                    dtx.SetHataLast(ncs.ID);

                    dtx.SetHataLastz(ncs.ID);


                    dtx.SetHataLastza(Convert.ToInt32(ncs.CompanyID), ttest[0].EndDate.Year);


                    //var cmlCheckList = TBLXmlFile.getSettedXml(ncs.ID, nfile.ID);

                    //var wZoneList = TBLXmlFile.getXmlList();
                    //var xmlWordList = TBLXmlFile.getWordXml();
                    //var errorStList = ErrorCheckMain.Get_ReportSet();
                    //var rule1 = new XmlPipeline(cmlCheckList, wZoneList);
                    //var ruleAudit = new XmlPipelineAudit(cmlCheckList, errorStList, xmlWordList);
                    //await rule1.ProcessXmlGroup(ncs.ID, nfile.ID);
                    //await ruleAudit.RunAllAndPersistAsync(Database.ConnectionString, ncs.ID);
                    DataViewerErroredCountCsv SetCounteR = MainDash.Get_DatabyErrorbyCsv(ncs.ID);

                    return ncs.ID.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
                }
                catch (Exception ex)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = compid;
                    lg.CsvID = csidemain;
                    lg.ERLOG = ex.ToString();
                    TBLXml.RESET_TBLXml(csidemain); lg.Save_AppLogs();
                    return "nok";
                }

            }
            else
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = 5555;
                lg.ERLOG = filemonth + "  " + fileyear + " tarihli";
                lg.Save_AppLogs();
                return "nok";
            }

        }
        public static string SapEntegratorSet(bool isZip, long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string orjinalname)
        {

            List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader> resultt = new List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader>();
            fincheckup.Models.NominalXML.defter result = new fincheckup.Models.NominalXML.defter();
            XmlSerializer serializerz = new XmlSerializer(typeof(fincheckup.Models.NominalXML.defter));
            List<ZipArchiveEntry> nlistZip = new List<ZipArchiveEntry>();
            string uploadsurl = pathfile;
            TBLXmlFile nfile = new TBLXmlFile();
            //  System.Diagnostics.Process.Start(filenameToStart,username,password,domain);
            String wwayusrl = @"C:\inetpub\vhosts\fincheckup.ai\apizen.fincheckup.ai\content";
            int countre = 0;
            long csidemain = 0;
            string mMonth = string.Empty;
            string myear = string.Empty;
            try
            {

                if (isZip)
                {
                    for (int i = 0; i < fzip.Count(); i++)
                    {
                        using (ZipArchive archive = ZipFile.OpenRead(fzip[i]))
                        {
                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {
                                string filepathz = Path.Combine(uploadsurl, fzip[i].Substring(0, fzip[i].Length - 3) + "xml");
                                entry.ExtractToFile(filepathz);
                                countre++;
                                if (countre == 1)
                                {


                                    using (FileStream fileStream = new FileStream(filepathz, FileMode.Open))
                                    {
                                        result = (fincheckup.Models.NominalXML.defter)serializerz.Deserialize(fileStream);

                                    }

                                    DateTime selectedDate = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
                                    mMonth = selectedDate.Month.ToString();
                                    myear = selectedDate.Year.ToString();
                                    TBLXml.DeleteComapnyIDByMonth(compid, selectedDate.Year, selectedDate.Month);
                                    TBLXml ncs = new TBLXml();
                                    ncs.CompanyID = compid;
                                    ncs.CreatedDate = DateTime.Now;
                                    ncs.DocumentDate = selectedDate;
                                    ncs.Year = selectedDate.Year;
                                    ncs.CsvName = filepathz;
                                    ncs.XmlDocName = orjinalname;
                                    ncs.Save_TBLXml();
                                    csidemain = ncs.ID;
                                    nfile = new TBLXmlFile();
                                    nfile.SortID = countre;
                                    nfile.CsvName = filepathz;
                                    nfile.TBLXmlID = csidemain;
                                    nfile.Save_TBLXmlFile();
                                    var ttest = Dataz.SetValueFromNominal(result, ncs.ID, nfile.ID);


                                    Data dat = new Data();
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
                                    //foreach (var item in ttest)
                                    //{

                                    //dat.InsertTB(ttest);
                                    //}

                                    //var ttest = Dataz.SetValueFromNominal(result, ncs.ID);

                                    ////ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();

                                    //var objBulk = new BulkUploadToSql<Dataz>()
                                    //{
                                    //    InternalStore = ttest,
                                    //    TableName = "[TBLXMLSource]",
                                    //    CommitBatchSize = 100000,
                                    //    ConnectionString = Database.ConnectionString
                                    //};
                                    //objBulk.Commit();

                                    MainDash.Get_DatabyErrorV1(selectedDate.Year, compid, selectedDate.Month);
                                }
                                else
                                {
                                    nfile = new TBLXmlFile();
                                    nfile.SortID = countre;
                                    nfile.CsvName = filepathz;
                                    nfile.TBLXmlID = csidemain;
                                    nfile.Save_TBLXmlFile();
                                }
                              
                            }

                        }
                    }
                }
                else
                {
                    for (int i = 0; i < fzip.Count(); i++)
                    {
                        countre++;
                        if (countre == 1)
                        {
                            using (FileStream fileStream = new FileStream(fzip[i], FileMode.Open))
                            {
                                result = (fincheckup.Models.NominalXML.defter)serializerz.Deserialize(fileStream);

                            }

                            DateTime selectedDate = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
                            mMonth = selectedDate.Month.ToString();
                            myear = selectedDate.Year.ToString();
                            TBLXml.DeleteComapnyIDByMonth(compid, selectedDate.Year, selectedDate.Month);
                            TBLXml ncs = new TBLXml();
                            ncs.CompanyID = compid;
                            ncs.CreatedDate = DateTime.Now;
                            ncs.DocumentDate = selectedDate;
                            ncs.Year = selectedDate.Year;
                            ncs.CsvName = fzip[i];
                            ncs.XmlDocName = orjinalname;
                            ncs.Save_TBLXml();
                            csidemain = ncs.ID;
                            nfile = new TBLXmlFile();
                            nfile.SortID = countre;
                            nfile.CsvName = fzip[i];
                            nfile.TBLXmlID = csidemain;
                            nfile.Save_TBLXmlFile();
                            var ttest = Dataz.SetValueFromNominal(result, ncs.ID, nfile.ID);


                            Data dat = new Data();
                            //foreach (var item in ttest)
                            //{

                            //dat.InsertTB(ttest);
                            //}
                            ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();


                            var objBulk = new BulkUploadToSql<Dataz>()
                            {
                                InternalStore = ttest,
                                TableName = "[TBLXMLSource]",
                                CommitBatchSize = 50000,
                                ConnectionString = Database.ConnectionString
                            };
                            objBulk.Commit();


                        }
                        else
                        {
                            nfile = new TBLXmlFile();
                            nfile.SortID = countre;
                            nfile.CsvName = fzip[i];
                            nfile.TBLXmlID = csidemain;
                            nfile.Save_TBLXmlFile();

                        }
                          
                    }
                }



            }
            catch (Exception ex)
            {

                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = csidemain;
                lg.ERLOG = ex.ToString();
                lg.Save_AppLogs();
                return "nok";
            }

            TBLXmlFile uploadsTBLXmlFile = TBLXmlFile.Get_TBLXmlFile(csidemain, 1);
            uploadsTBLXmlFile.Update_TBLXmlFile();

            uploadsTBLXmlFile.Finish_TBLXmlFile();
            return "2_" + (uploadsTBLXmlFile.LastSettedCount).ToString();

        }

        public static string SapEntegratorSetUpon(long compid, string filemonth, string fileyear, int sortide_ )
        {
            int txmlid = TBLXml.GetComapnyIDByMonth(compid, Convert.ToInt32(filemonth), Convert.ToInt32(fileyear));

            List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader> resultt = new List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader>();
            fincheckup.Models.NominalXML.defter result = new fincheckup.Models.NominalXML.defter();
            XmlSerializer serializerz = new XmlSerializer(typeof(fincheckup.Models.NominalXML.defter));
            List<ZipArchiveEntry> nlistZip = new List<ZipArchiveEntry>();
            TBLXmlFile uploadsTBLXmlFile = TBLXmlFile.Get_TBLXmlFile(txmlid, sortide_);
            TBLXmlFile nfile = new TBLXmlFile();



            string mMonth = string.Empty;
            string myear = string.Empty;
            try
            {



                string filepathz = uploadsTBLXmlFile.CsvName;


                using (FileStream fileStream = new FileStream(filepathz, FileMode.Open))
                {
                    result = (fincheckup.Models.NominalXML.defter)serializerz.Deserialize(fileStream);

                }

                DateTime selectedDate = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
                mMonth = selectedDate.Month.ToString();
                myear = selectedDate.Year.ToString();
                if (mMonth != filemonth || myear != fileyear)
                {
                    return "nok";
                }
                else
                {

                    var ttest = Dataz.SetValueFromNominal(result, txmlid, uploadsTBLXmlFile.ID);


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

                    //var ttest = Dataz.SetValueFromNominal(result, txmlid); 
                    //ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();

                    //var objBulk = new BulkUploadToSql<Dataz>()
                    //{
                    //    InternalStore = ttest,
                    //    TableName = "[TBLXMLSource]",
                    //    CommitBatchSize = 100000,
                    //    ConnectionString = Database.ConnectionString
                    //};
                    //objBulk.Commit();

                }

                uploadsTBLXmlFile.Update_TBLXmlFile();

                uploadsTBLXmlFile.Finish_TBLXmlFile();


            }
            catch (Exception ex)
            {

                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = txmlid;
                lg.ERLOG = ex.ToString();
                return "nok";
            }


            return (sortide_ + 1).ToString() + "_" + (uploadsTBLXmlFile.LastSettedCount).ToString();

        }
        public static string SapEntegratorSetUpdate(bool iszzip, long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string orjinalname)
        {
            long txmlid = TBLXml.GetComapnyIDByMonth(compid, Convert.ToInt32(filemonth), Convert.ToInt32(fileyear));

            String wwayusrl = @"C:\inetpub\vhosts\fincheckup.ai\apizen.fincheckup.ai\content";
            List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader> resultt = new List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader>();
            fincheckup.Models.NominalXML.defter result = new fincheckup.Models.NominalXML.defter();
            XmlSerializer serializerz = new XmlSerializer(typeof(fincheckup.Models.NominalXML.defter));
            List<ZipArchiveEntry> nlistZip = new List<ZipArchiveEntry>();
            string uploadsurl = pathfile;
            TBLXmlFile nfile = new TBLXmlFile();


            int countre = 0;
            string mMonth = string.Empty;
            string myear = string.Empty;
            try
            {
                if (iszzip)
                {

                    for (int i = 0; i < fzip.Count(); i++)
                    {
                        using (ZipArchive archive = ZipFile.OpenRead(fzip[i]))
                        {
                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {
                                string filepathz = Path.Combine(uploadsurl, fzip[i].Substring(0, fzip[i].Length - 3) + "xml");
                                entry.ExtractToFile(filepathz);
                                countre++;
                                if (countre == 1)
                                {
                                    using (FileStream fileStream = new FileStream(filepathz, FileMode.Open))
                                    {
                                        result = (fincheckup.Models.NominalXML.defter)serializerz.Deserialize(fileStream);

                                    }

                                    DateTime selectedDate = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
                                    mMonth = selectedDate.Month.ToString();
                                    myear = selectedDate.Year.ToString();
                                    if (mMonth != filemonth || myear != fileyear)
                                    {
                                        return "nok";
                                    }
                                    else
                                    {
                                        TBLXmlFile.Delete_TBLXmlIDlist(txmlid);
                                        TBLXml ncs = new TBLXml();
                                        ncs.CompanyID = compid;
                                        ncs.CreatedDate = DateTime.Now;
                                        ncs.DocumentDate = selectedDate;
                                        ncs.Year = selectedDate.Year;
                                        ncs.CsvName = filepathz;
                                        ncs.XmlDocName = orjinalname;
                                        ncs.Save_TBLXml();
                                        txmlid = ncs.ID;
                                        nfile = new TBLXmlFile();
                                        nfile.CsvName = filepathz;
                                        nfile.SortID = countre;
                                        nfile.TBLXmlID = txmlid;
                                        nfile.Save_TBLXmlFile();
                                        //var ttest = Dataz.SetValueFromNominal(result, txmlid);
                                        TBLXml.RESETALL_byCompanyIDMulti(Convert.ToInt32(fileyear), compid, Convert.ToInt32(mMonth), ncs.ID);
                                        var ttest = Dataz.SetValueFromNominal(result, ncs.ID, nfile.ID);


                                        Data dat = new Data();

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
                                        //Data dat = new Data();
                                        //foreach (var item in ttest)
                                        //{

                                        //    dat.InsertTB(item);
                                        //}
                                        //ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();

                                        //var objBulk = new BulkUploadToSql<Dataz>()
                                        //{
                                        //    InternalStore = ttest,
                                        //    TableName = "[TBLXMLSource]",
                                        //    CommitBatchSize = 100000,
                                        //    ConnectionString = Database.ConnectionString
                                        //};
                                        //objBulk.Commit();
                                    }
                                }
                                else
                                {
                                    nfile = new TBLXmlFile();
                                    nfile.CsvName = filepathz;
                                    nfile.SortID = countre;
                                    nfile.TBLXmlID = txmlid;
                                    nfile.Save_TBLXmlFile();
                                }
                                    //  resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
                                 
                            }

                        }
                    }

                }
                else
                {
                    for (int i = 0; i < fzip.Count(); i++)
                    {



                        countre++;
                        if (countre == 1)
                        {
                            using (FileStream fileStream = new FileStream(fzip[i], FileMode.Open))
                            {
                                result = (fincheckup.Models.NominalXML.defter)serializerz.Deserialize(fileStream);

                            }

                            DateTime selectedDate = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
                            mMonth = selectedDate.Month.ToString();
                            myear = selectedDate.Year.ToString();
                            if (mMonth != filemonth || myear != fileyear)
                            {
                                return "nok";
                            }
                            else
                            {
                                TBLXmlFile.Delete_TBLXmlIDlist(txmlid);
                                TBLXml ncs = new TBLXml();
                                ncs.CompanyID = compid;
                                ncs.CreatedDate = DateTime.Now;
                                ncs.DocumentDate = selectedDate;
                                ncs.Year = selectedDate.Year;
                                ncs.CsvName = fzip[i];
                                ncs.XmlDocName = orjinalname;
                                ncs.Save_TBLXml();
                                txmlid = ncs.ID;

                                //var ttest = Dataz.SetValueFromNominal(result, txmlid);
                                TBLXml.RESETALL_byCompanyIDMulti(Convert.ToInt32(fileyear), compid, Convert.ToInt32(mMonth), ncs.ID);

                                int chkeson = 3;


                                while (chkeson > 1)
                                {
                                    chkeson = TBLXml.GetCountALL_byCompanyIDMulti(Convert.ToInt32(fileyear), compid, Convert.ToInt32(mMonth), ncs.ID);
                                    Thread.Sleep(500);
                                }
                                nfile = new TBLXmlFile();
                                nfile.CsvName = fzip[i];
                                nfile.SortID = countre;
                                nfile.TBLXmlID = txmlid;
                                nfile.Save_TBLXmlFile();

                                var ttest = Dataz.SetValueFromNominal(result, ncs.ID,nfile.ID);


                                Data dat = new Data();

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
                                //ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();

                                //var objBulk = new BulkUploadToSql<Dataz>()
                                //{
                                //    InternalStore = ttest,
                                //    TableName = "[TBLXMLSource]",
                                //    CommitBatchSize = 100000,
                                //    ConnectionString = Database.ConnectionString
                                //};
                                //objBulk.Commit();
                            }
                        }
                        else
                        {
                            nfile = new TBLXmlFile();
                            nfile.CsvName = fzip[i];
                            nfile.SortID = countre;
                            nfile.TBLXmlID = txmlid;
                            nfile.Save_TBLXmlFile();
                        }
                            //  resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
                        

                    }
                }
                //TBLXmlFile._SetFirstSetted(txmlid);
                TBLXmlFile uploadsTBLXmlFile = TBLXmlFile.Get_TBLXmlFile(txmlid, 1);
                uploadsTBLXmlFile.Update_TBLXmlFile();

                uploadsTBLXmlFile.Finish_TBLXmlFile();
                return "2_" + (uploadsTBLXmlFile.LastSettedCount).ToString();

            }
            catch (Exception ex)
            {

                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = txmlid;
                lg.ERLOG = ex.ToString();
                return "nok";
            }



        }

        public static string SapEntegratorCheck(long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string filenameorjinal, bool IsLastMOnth)
        {
            List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader> resultt = new List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader>();
            fincheckup.Models.NominalXML.defter result = new fincheckup.Models.NominalXML.defter();
            XmlSerializer serializerz = new XmlSerializer(typeof(fincheckup.Models.NominalXML.defter));
            List<ZipArchiveEntry> nlistZip = new List<ZipArchiveEntry>();
            string uploadsurl = pathfile;

            try
            {
                //    using (ZipArchive archive = ZipFile.OpenRead(pathfile))
                //{
                //    foreach (ZipArchiveEntry entry in archive.Entries)
                //    {
                //        if (entry.FullName.Contains("Yevmiyeler", StringComparison.OrdinalIgnoreCase) && entry.FullName.Contains("Defterler", StringComparison.OrdinalIgnoreCase) && !entry.FullName.EndsWith(".xslt", StringComparison.OrdinalIgnoreCase))
                //        {
                //            filepath = Path.Combine(uploadsurl, Guid.NewGuid().ToString() + ".zip");
                //            nlistZip.Add(entry);

                //                    entry.ExtractToFile(filepath);
                //                    nlistZipurl.Add(filepath);






                //        }
                //    }
                //}

                for (int i = 0; i < fzip.Count(); i++)
                {
                    using (ZipArchive archive = ZipFile.OpenRead(fzip[i]))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            string filepathz = Path.Combine(uploadsurl, fzip[i].Substring(0, fzip[i].Length - 3) + "xml");
                            entry.ExtractToFile(filepathz);
                            using (FileStream fileStream = new FileStream(filepathz, FileMode.Open))
                            {
                                result = (fincheckup.Models.NominalXML.defter)serializerz.Deserialize(fileStream);

                            }
                            resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
                        }

                    }
                }



            }
            catch (Exception ex)
            {

                var chk = ex;
                return "nok";
            }
            var chkkky1 = resultt;

            result.xbrl.accountingEntries.entryHeader = chkkky1.ToArray();




            //try
            //{
            //    using (FileStream fileStream = new FileStream(pathfile, FileMode.Open))
            //    {
            //        result = (fincheckup.Models.NKolaySapEntegrator.defter)serializerz.Deserialize(fileStream);
            //    }
            //}
            //catch
            //{


            //    return "nok";
            //}
            DateTime selectedDate = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
            string mMonth = selectedDate.Month.ToString();
            string myear = selectedDate.Year.ToString();
            long csidemain = 0;
            TBLXmlFile nfile=   new TBLXmlFile();
            //return "nok";
            if (mMonth == filemonth && myear == fileyear)
            {
                try
                {
                    string filename = Path.GetFileName(fzip[0]);
                    TBLXml ncs = new TBLXml();
                    ncs.CompanyID = compid;
                    ncs.CreatedDate = DateTime.Now;
                    ncs.DocumentDate = DateTime.Now; ncs.CsvName = filename;
                    ncs.XmlDocName = filenameorjinal;
                    ncs.Save_TBLXml();
                    csidemain = ncs.ID;

                    nfile = new TBLXmlFile();
                    nfile.CsvName = fzip[0];
                    nfile.SortID = 1;
                    nfile.TBLXmlID = csidemain;
                    nfile.Save_TBLXmlFile();

                    var ttest = Dataz.SetValueFromNominal(result, ncs.ID, nfile.ID);

                    ncs.Year = selectedDate.Year;
                    ncs.DocumentDate = selectedDate;
                    ncs.Update_TBLXml();
                    //Data dat = new Data();

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
                    //foreach (var item in ttest)
                    //{

                    //   dat.InsertTB(item);
                    //}



                    Data.SetOpener(ncs.ID, mMonth, IsLastMOnth);






                    Data dtx = new Data();

                    dtx.SetHataLast(ncs.ID);

                    dtx.SetHataLastz(ncs.ID);


                    dtx.SetHataLastza(Convert.ToInt32(ncs.CompanyID), Convert.ToInt32(fileyear));



                    DataViewerErroredCountCsv SetCounteR = MainDash.Get_DatabyErrorbyCsv(ncs.ID);

                    return ncs.ID.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
                }
                catch (Exception ex)
                {
                    var chh = ex;
                    TBLXml.RESET_TBLXml(csidemain);
                    return "nok";
                }

            }
            else
            {
                return "nok";
            }

        }

        public static string SapEntegratorCheckUpdate(long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string filenameorjinal, bool IsLastMOnth)
        {
            //fincheckup.Models.NKolaySapEntegrator.defter result = new fincheckup.Models.NKolaySapEntegrator.defter();
            //List<fincheckup.Models.NKolaySapEntegrator.accountingEntriesEntryHeader> resultt = new List<fincheckup.Models.NKolaySapEntegrator.accountingEntriesEntryHeader>();
            //XmlSerializer serializerz = new XmlSerializer(typeof(fincheckup.Models.NKolayUyumsoft.defter));
            //string uploadsurl = pathfile;
            //List<ZipArchiveEntry> nlistZip = new List<ZipArchiveEntry>();
            //string filepath = "";
            //List<string> nlistZipurl = new List<string>();
            //try
            //{

            //    for (int i = 0; i < fzip.Count(); i++)
            //{
            //    using (ZipArchive archive = ZipFile.OpenRead(fzip[i]))
            //    {
            //        foreach (ZipArchiveEntry entry in archive.Entries)
            //        {
            //            string filepathz = Path.Combine(uploadsurl, fzip[i].Substring(0, fzip[i].Length - 3) + "xml");
            //            entry.ExtractToFile(filepathz);
            //            using (FileStream fileStream = new FileStream(filepathz, FileMode.Open))
            //            {
            //                result = (fincheckup.Models.NKolaySapEntegrator.defter)serializerz.Deserialize(fileStream);

            //            }
            //            resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
            //        }

            //    }
            //}


            //}
            //catch(Exception ex)
            //{
            //    var chh = ex;

            //    return "nok";
            //}


            List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader> resultt = new List<fincheckup.Models.NominalXML.accountingEntriesEntryHeader>();
            fincheckup.Models.NominalXML.defter result = new fincheckup.Models.NominalXML.defter();
            XmlSerializer serializerz = new XmlSerializer(typeof(fincheckup.Models.NominalXML.defter));
            List<ZipArchiveEntry> nlistZip = new List<ZipArchiveEntry>();
            string uploadsurl = pathfile;

            try
            {


                for (int i = 0; i < fzip.Count(); i++)
                {
                    using (ZipArchive archive = ZipFile.OpenRead(fzip[i]))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            string filepathz = Path.Combine(uploadsurl, fzip[i].Substring(0, fzip[i].Length - 3) + "xml");
                            entry.ExtractToFile(filepathz);
                            using (FileStream fileStream = new FileStream(filepathz, FileMode.Open))
                            {
                                result = (fincheckup.Models.NominalXML.defter)serializerz.Deserialize(fileStream);

                            }
                            resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
                        }

                    }
                }



            }
            catch (Exception ex)
            {

                var chk = ex;
                return "nok";
            }
            var chkkky1 = resultt;

            result.xbrl.accountingEntries.entryHeader = chkkky1.ToArray();

            DateTime selectedDate = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
            string mMonth = selectedDate.Month.ToString();
            string myear = selectedDate.Year.ToString();
            long csidemain = 0;
            TBLXmlFile nfile = new TBLXmlFile();
            if (mMonth == filemonth && myear == fileyear)
            {
                try
                {
                    string filename = Path.GetFileName(fzip[0]);
                    TBLXml ncs = new TBLXml();
                    ncs.CompanyID = compid;
                    ncs.CreatedDate = DateTime.Now;
                    ncs.DocumentDate = DateTime.Now; ncs.CsvName = filename;
                    ncs.XmlDocName = filenameorjinal;
                    ncs.Save_TBLXml();
                    csidemain = ncs.ID;

                    nfile = new TBLXmlFile();
                    nfile.CsvName = fzip[0];
                    nfile.SortID = 1;
                    nfile.TBLXmlID = csidemain;
                    nfile.Save_TBLXmlFile();

                    var ttest = Dataz.SetValueFromNominal(result, ncs.ID, nfile.ID);

                    ncs.Year = selectedDate.Year;
                    ncs.DocumentDate = selectedDate;
                    ncs.Update_TBLXml();
                    //TBLXml ncs1 = TBLXml.Get_TBLXmlCompany(ncs.CompanyID.ToString()).Where(x => x.DocumentDate.Year == ttest[0][0].EndDate.Year && x.DocumentDate.Month == ttest[0][0].EndDate.Month && x.ID != ncs.ID).FirstOrDefault();

                    //TBLXml.RESET_TBLXml(ncs1.ID);
                    TBLXml.RESETALL_byCompanyID(Convert.ToInt32(fileyear), compid, Convert.ToInt32(mMonth), ncs.ID);


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
                    //Data dat = new Data();
                    //foreach (var item in ttest)
                    //{
                    //    dat.InsertTB(item);

                    //}


                    Data.SetOpener(ncs.ID, mMonth , IsLastMOnth);







                    Data dtx = new Data();

                    dtx.SetHataLast(ncs.ID);

                    dtx.SetHataLastz(ncs.ID);


                    dtx.SetHataLastza(Convert.ToInt32(ncs.CompanyID), selectedDate.Year);


                    DataViewerErroredCountCsv SetCounteR = MainDash.Get_DatabyErrorbyCsv(ncs.ID);

                    return ncs.ID.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
                }
                catch
                {
                    TBLXml.RESET_TBLXml(csidemain);
                    return "nok";
                }

            }
            else
            {
                return "nok";
            }


        }

        #region old types
        //public static string IsbankCheck(int compid, string pathfile, string filemonth, string fileyear)
        //{
        //    fincheckup.Helper.defter result = new fincheckup.Helper.defter();
        //    XmlSerializer serializerz = new XmlSerializer(typeof(fincheckup.Helper.defter));

        //    try
        //    {
        //        using (FileStream fileStream = new FileStream(pathfile, FileMode.Open))
        //        {
        //            result = (fincheckup.Helper.defter)serializerz.Deserialize(fileStream);
        //        }
        //    }
        //    catch
        //    {
        //        return "nok";

        //        throw;
        //    }

        //    string mMonth = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Month.ToString();
        //    string myear = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Year.ToString();
        //    long csidemain = 0;
        //    if (mMonth == filemonth && myear == fileyear)
        //    {
        //        try
        //        {
        //            TBLXml ncs = new TBLXml();
        //            ncs.CompanyID = compid;
        //            ncs.CreatedDate = DateTime.Now;
        //            ncs.DocumentDate = DateTime.Now; ncs.CsvName = pathfile;
        //            ncs.Save_TBLXml();
        //            csidemain = ncs.ID;
        //            var ttest = Dataz.SetValueFromXMlIsbank(result, ncs.ID);

        //            ncs.Year = ttest[0].EndDate.Year;
        //            ncs.DocumentDate = ttest[0].EndDate;
        //            ncs.Update_TBLXml();

        //            Data dat = new Data();
        //            dat.InsertTB(ttest);

        //            Data.SetOpener(ncs.ID, mMonth);






        //            Data dtx = new Data();

        //            dtx.SetHataLast(ncs.ID);

        //            dtx.SetHataLastz(ncs.ID);


        //            dtx.SetHataLastza(Convert.ToInt32(ncs.CompanyID), ttest[0].EndDate.Year);



        //            DataViewerErroredCountCsv SetCounteR = MainDash.Get_DatabyErrorbyCsv(ncs.ID);

        //            return ncs.ID.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
        //        }
        //        catch
        //        {
        //            TBLXml.RESET_TBLXml(csidemain);
        //            return "nok";
        //        }


        //    }
        //    else
        //    {
        //        return "nok";
        //    }

        //}
        //public static string IsbankCheckUpdate(int compid, string pathfile, string filemonth, string fileyear)
        //{
        //    fincheckup.Helper.defter result = new fincheckup.Helper.defter();
        //    XmlSerializer serializerz = new XmlSerializer(typeof(fincheckup.Helper.defter));

        //    try
        //    {
        //        using (FileStream fileStream = new FileStream(pathfile, FileMode.Open))
        //        {
        //            result = (fincheckup.Helper.defter)serializerz.Deserialize(fileStream);
        //        }
        //    }
        //    catch
        //    {
        //        return "nok";

        //        throw;
        //    }
        //    string mMonth = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Month.ToString();
        //    string myear = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Year.ToString();
        //    long csidemain = 0;
        //    if (mMonth == filemonth && myear == fileyear)
        //    {
        //        try
        //        {
        //            TBLXml ncs = new TBLXml();
        //            ncs.CompanyID = compid;
        //            ncs.CreatedDate = DateTime.Now;
        //            ncs.DocumentDate = DateTime.Now; ncs.CsvName = pathfile;
        //            ncs.Save_TBLXml();
        //            csidemain = ncs.ID;
        //            var ttest = Dataz.SetValueFromXMlIsbank(result, ncs.ID);
        //            TBLXml ncs1 = TBLXml.Get_TBLXmlCompany(ncs.CompanyID.ToString()).Where(x => x.DocumentDate.Year == ttest[0].EndDate.Year && x.DocumentDate.Month == ttest[0].EndDate.Month && x.ID != ncs.ID).FirstOrDefault();
        //            TBLXml.RESET_TBLXml(ncs1.ID);
        //            ncs.Year = ttest[0].EndDate.Year;
        //            ncs.DocumentDate = ttest[0].EndDate;
        //            ncs.Update_TBLXml();

        //            Data dat = new Data();
        //            dat.InsertTB(ttest);

        //            Data.SetOpener(ncs.ID, mMonth);





        //            Data dtx = new Data();

        //            dtx.SetHataLast(ncs.ID);

        //            dtx.SetHataLastz(ncs.ID);


        //            dtx.SetHataLastza(Convert.ToInt32(ncs.CompanyID), ttest[0].EndDate.Year);



        //            DataViewerErroredCountCsv SetCounteR = MainDash.Get_DatabyErrorbyCsv(ncs.ID);

        //            return ncs.ID.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
        //        }
        //        catch
        //        {
        //            TBLXml.RESET_TBLXml(csidemain);

        //            return "nok";
        //        }


        //    }
        //    else
        //    {
        //        return "nok";
        //    }

        //}
        //public static string UyumsoftCheck(int compid, string pathfile, string filemonth, string fileyear)
        //{
        //    fincheckup.Models.NKolayUyumsoft.defter result = new fincheckup.Models.NKolayUyumsoft.defter();
        //    XmlSerializer serializerz = new XmlSerializer(typeof(fincheckup.Models.NKolayUyumsoft.defter));

        //    try
        //    {
        //        using (FileStream fileStream = new FileStream(pathfile, FileMode.Open))
        //        {
        //            result = (fincheckup.Models.NKolayUyumsoft.defter)serializerz.Deserialize(fileStream);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        var chk = ex;
        //        return "nok";
        //    }

        //    string mMonth = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Month.ToString();
        //    string myear = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Year.ToString();
        //    long csidemain = 0;
        //    if (mMonth == filemonth && myear == fileyear)
        //    {
        //        try
        //        {
        //            TBLXml ncs = new TBLXml();
        //            ncs.CompanyID = compid;
        //            ncs.CreatedDate = DateTime.Now;
        //            ncs.DocumentDate = DateTime.Now;
        //            ncs.Save_TBLXml();
        //            csidemain = ncs.ID;
        //            var ttest = Dataz.SetValueFromXMluyumsoft(result, ncs.ID);

        //            ncs.Year = ttest[0].EndDate.Year;
        //            ncs.DocumentDate = ttest[0].EndDate;
        //            ncs.Update_TBLXml();

        //            Data dat = new Data();
        //            dat.InsertTB(ttest);

        //            Data.SetOpener(ncs.ID, mMonth);






        //            Data dtx = new Data();

        //            dtx.SetHataLast(ncs.ID);

        //            dtx.SetHataLastz(ncs.ID);


        //            dtx.SetHataLastza(Convert.ToInt32(ncs.CompanyID), ttest[0].EndDate.Year);



        //            DataViewerErroredCountCsv SetCounteR = MainDash.Get_DatabyErrorbyCsv(ncs.ID);

        //            return ncs.ID.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
        //        }
        //        catch
        //        {
        //            TBLXml.RESET_TBLXml(csidemain);
        //            return "nok";
        //        }

        //    }
        //    else
        //    {
        //        return "nok";
        //    }

        //}
        //public static string UyumsoftCheckUpdate(int compid, string pathfile, string filemonth, string fileyear)
        //{
        //    fincheckup.Models.NKolayUyumsoft.defter result = new fincheckup.Models.NKolayUyumsoft.defter();
        //    XmlSerializer serializerz = new XmlSerializer(typeof(fincheckup.Models.NKolayUyumsoft.defter));
        //    try
        //    {
        //        using (FileStream fileStream = new FileStream(pathfile, FileMode.Open))
        //        {
        //            result = (fincheckup.Models.NKolayUyumsoft.defter)serializerz.Deserialize(fileStream);
        //        }
        //    }
        //    catch
        //    {


        //        return "nok";
        //    }

        //    string mMonth = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Month.ToString();
        //    string myear = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Year.ToString();
        //    long csidemain = 0;
        //    if (mMonth == filemonth && myear == fileyear)
        //    {
        //        try
        //        {
        //            TBLXml ncs = new TBLXml();
        //            ncs.CompanyID = compid;
        //            ncs.CreatedDate = DateTime.Now;
        //            ncs.DocumentDate = DateTime.Now;
        //            ncs.Save_TBLXml();
        //            csidemain = ncs.ID;
        //            var ttest = Dataz.SetValueFromXMluyumsoft(result, ncs.ID);

        //            ncs.Year = ttest[0].EndDate.Year;
        //            ncs.DocumentDate = ttest[0].EndDate;
        //            ncs.Update_TBLXml();
        //            TBLXml ncs1 = TBLXml.Get_TBLXmlCompany(ncs.CompanyID.ToString()).Where(x => x.DocumentDate.Year == ttest[0].EndDate.Year && x.DocumentDate.Month == ttest[0].EndDate.Month && x.ID != ncs.ID).FirstOrDefault();
        //            TBLXml.RESET_TBLXml(ncs1.ID);
        //            Data dat = new Data();
        //            dat.InsertTB(ttest);

        //            Data.SetOpener(ncs.ID, mMonth);







        //            Data dtx = new Data();

        //            dtx.SetHataLast(ncs.ID);

        //            dtx.SetHataLastz(ncs.ID);


        //            dtx.SetHataLastza(Convert.ToInt32(ncs.CompanyID), ttest[0].EndDate.Year);



        //            DataViewerErroredCountCsv SetCounteR = MainDash.Get_DatabyErrorbyCsv(ncs.ID);

        //            return ncs.ID.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
        //        }
        //        catch
        //        {
        //            TBLXml.RESET_TBLXml(csidemain);
        //            return "nok";
        //        }

        //    }
        //    else
        //    {
        //        return "nok";
        //    }

        //}

        #endregion
    }
}
