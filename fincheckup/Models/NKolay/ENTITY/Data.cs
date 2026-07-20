using EINvoice.New;
using fincheckup.Models.Mizan;
using fincheckup.Models.NKolay;
using fincheckup.Models.NKolay.MizanView;
using fincheckup.Models.ViewM;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace fincheckup.ENTITY
{
    public class Data : BaseModel
    {
        public long ID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string EnteredBy { get; set; }
        public string EnteredDate { get; set; }
        public string EntryNumber { get; set; }
        public string EntryComment { get; set; }
        public string BatchID { get; set; }
        public string BatchDescription { get; set; }
        public float TotalDebit { get; set; }
        public float TotalCredit { get; set; }
        public string DocumentType { get; set; }
        public string DocumentTypeDescription { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string AccountSubDescription { get; set; }
        public string AccountSubID { get; set; }
        public float Amount { get; set; }
        public string DebitCreditCode { get; set; }
        public string PostingDate { get; set; }
        public string DetailComment { get; set; }
        public long CsvID { get; set; }
        public bool IsFailed { get; set; }
        public bool IsOpener { get; set; }
        public int IsPassedEntry { get; set; }


        public static Data FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            Data dailyValues = new Data();
            dailyValues.StartDate = values[0].ToString();
            dailyValues.EndDate = values[1].ToString();
            dailyValues.EnteredBy = values[2].ToString();
            dailyValues.EnteredDate = values[3].ToString();
            dailyValues.EntryNumber = values[4].ToString();
            dailyValues.EntryComment = values[5].ToString();
            dailyValues.BatchID = values[6].ToString();
            dailyValues.BatchDescription = values[7].ToString();
            dailyValues.TotalDebit = (float)Convert.ToDecimal(values[8]);
            dailyValues.TotalCredit = (float)Convert.ToDecimal(values[9]);
            dailyValues.DocumentType = values[10].ToString();
            dailyValues.DocumentTypeDescription = values[11].ToString();
            dailyValues.DocumentNumber = values[12].ToString();
            dailyValues.DocumentDate = values[13].ToString();
            dailyValues.PaymentMethod = values[14].ToString();
            dailyValues.AccountMainID = values[15].ToString();
            dailyValues.AccountMainDescription = values[16].ToString();
            dailyValues.AccountSubDescription = values[17].ToString();
            dailyValues.AccountSubID = values[18].ToString();
            dailyValues.Amount = (float)Convert.ToDecimal(values[19]);
            dailyValues.DebitCreditCode = values[20].ToString();
            dailyValues.PostingDate = values[21].ToString();
            dailyValues.DetailComment = values[22].ToString();
            return dailyValues;
        }
        public static IEnumerable<Data> Get_All()
        {
            return StaticQuery<Data>("Select * From [TBLXMLSource]");
        }
        public static List<Dataz> Get_AllbyCsvIDataz(int ide, int monthid)
        {
            string sql = @"  Select  StartDate                      
             ,EndDate                        
             ,EnteredBy                      
             ,EnteredDate                    
             ,EntryNumber                    
             ,EntryComment                   
             ,BatchID                        
             ,BatchDescription               
             ,TotalDebit                     
             ,TotalCredit                    
             ,DocumentType                   
             ,DocumentTypeDescription        
             ,DocumentNumber                 
             ,DocumentDate                   
             ,PaymentMethod                  
             ,AccountMainID                  
             ,AccountMainDescription         
             ,AccountSubDescription          
             ,AccountSubID                   
             ,Amount                         
             ,DebitCreditCode                
             ,PostingDate                    
             ,DetailComment ,CsvID FROM [TBLXMLSource] where CsvID=@ID";

            if (monthid == 12)
            {
                sql = @"Select  * FROM [TBLXMLSource] where CsvID=@ID";
            }

            return StaticQuery<Dataz>(sql, new { ID = ide }).ToList();
        }
        public static IEnumerable<Data> Get_AllCompany(int _year, long _compID)
        {
            return StaticQuery<Data>("Select * From [TBLXMLSource] Where CsvID in ( Select ID From [TBLXml] where   CompanyID=@companyID and [Year]=@nyear)", new { companyID = _compID, nyear = _year });
        }

        public static IEnumerable<Data> Get_AllCompanyByCode(int _csvID, string _code)
        {
            return StaticQuery<Data>("Select * From [TBLXMLSource] Where CsvID=@csvID and AccountMainID=@code", new { csvID = _csvID, code = _code });
        }
        public static void SetOpener(long ide, string mMonth,bool islast)
        {

            if (mMonth == "1" || mMonth == "01")
            {
                StaticQuery<int>(" UPDATE  [dbo].[TBLXMLSource] set IsPassedEntry=1 where CsvID=@ID and ID in (select ID from  [dbo].[TBLXMLSource] where CsvID=@ID and (AccountMainID LIKE '9%'  or  AccountMainID LIKE '8%'))", new { ID = ide }).FirstOrDefault();

                StaticQuery<int>("EXEC [SP_BOpener] @ID ", new { ID = ide }).FirstOrDefault();
            }
            else
            {
                StaticQuery<int>(" UPDATE  [dbo].[TBLXMLSource] set IsPassedEntry=1 where CsvID=@ID and ID in (select ID from  [dbo].[TBLXMLSource] where CsvID=@ID and (AccountMainID LIKE '9%'  or  AccountMainID LIKE '8%'))", new { ID = ide }).FirstOrDefault();
            }


            if (mMonth == "12" || islast==true)
            {
                StaticQuery<int>(" UPDATE  [dbo].[TBLXMLSource] set IsPassedEntry=1 where CsvID=@ID and  EntryNumber in (select EntryNumber from  [dbo].[TBLXMLSource] where CsvID=@ID and ( EntryComment  LIKE '%Kapanış%' or EntryComment  LIKE '%KAPANIŞ%' or EntryComment  LIKE '%kapanış%' or EntryComment like '%Mali Yılın devri%' or  DetailComment LIKE '%KAPANIŞ%' or  DetailComment LIKE '%KAPATIL%' or  DetailComment LIKE '%KPNS%' or DetailComment LIKE '%kapanış%' or DetailComment LIKE '%KPNŞ%' or  DetailComment LIKE '%Kpns%' or    DetailComment LIKE '%kapanis%'  or  DetailComment LIKE '%KAPANİS%' or DetailComment LIKE '%Kapaniş%'  or  DetailComment LIKE '%Kapanış%'))", new { ID = ide }).FirstOrDefault();

                StaticQuery<int>(" UPDATE  [dbo].[TBLXMLSource] set IsPassedEntry=0 where CsvID=@ID and  IsPassedEntry=1 and  EntryNumber in (select EntryNumber from  [dbo].[TBLXMLSource] where CsvID=@ID     and  IsPassedEntry=1 and (DetailComment LIKE '%BAKİYE KAPANIŞI%'  or  DetailComment LIKE '%BAKIYE KAPANISI%'  ))", new { ID = ide }).FirstOrDefault();
                String dbConnStr = BaseModel.ConnectionString;
                SqlConnection cnn = new SqlConnection(dbConnStr);



                //  MainStrPro1zA

                SqlCommand sqlCmd1 = new SqlCommand("SPO_FNLMRPRT", cnn);
                sqlCmd1.CommandType = CommandType.StoredProcedure;
                sqlCmd1.Parameters.AddWithValue("@csvid", ide);
                sqlCmd1.CommandTimeout = 0;
                //sqlCmd1.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cnn.Open();
                object obb = sqlCmd1.ExecuteScalar();
                //StaticQuery<int>(" EXEC SPO_FNLMRPRT @csvid", new { ID = ide }).FirstOrDefault();
                cnn.Close();
            }

        }
        public static List<int> RESET_DashBilancoViewMulti(int _year, long _compID)
        {



            StaticQuery<int>("EXEC [dbo].[SP_TBLXMLSourceRepV3] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            StaticQuery<int>("EXEC [dbo].[SP_TBLXMLSourceRepSubV1] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();

            return StaticQuery<int>("DELETE from  TBLMSampleBlnco Where CompanyID=@companyID and [Year]=@nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<int> RESET_DashBilancoView(int _year, long _compID)
        {



            StaticQuery<int>("EXEC [dbo].[SP_TBLXMLSourceRep] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            StaticQuery<int>("EXEC [dbo].[SP_TBLXMLSourceRepSubV1] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();

            return StaticQuery<int>("DELETE from  TBLMSampleBlnco Where CompanyID=@companyID and [Year]=@nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<int> RESET_DashBilancoViewMizan(int _year, long _compID)
        {
            return StaticQuery<int>("DELETE from  TBLMSampleBlncoMzn Where CompanyID=@companyID and [Year]=@nyear", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static int SET_MIZANHEADER(int _year, long _compID)
        {
            return StaticQuery<int>("EXEC SP_A_MIZANHEADER @nyear,@companyID", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public static List<int> RESET_REVENUEView(int _year, long _compID)
        {
            StaticQuery<int>("DELETE from  TBLWcapital Where CompanyID=@companyID and [Year]=@nyear", new { nyear = _year, companyID = _compID });
            return StaticQuery<int>("DELETE from  TBLMRevenue Where CompanyID=@companyID and [Year]=@nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<int> RESET_REVENUEViewMzn(int _year, long _compID)
        {

            return StaticQuery<int>("DELETE from  TBLMRevenueMzn Where CompanyID=@companyID and [Year]=@nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static IEnumerable<Data> Get_AllbyCsvID(string ide)
        {
            return StaticQuery<Data>("Select * From [TBLXMLSource] where CsvID=@ID", new { ID = ide });
        }
        public static IEnumerable<DataViewer> Get_AllbyCsvIDEntryNo(int ide, string entry)
        {
            return StaticQuery<DataViewer>("Select * From [TBLXMLSource] where CsvID=@ID and EntryNumber=@ent", new { ID = ide, ent = entry });
        }
        public static IEnumerable<DataViewer> Get_AllbyCsvIDEntryNoNope()
        {
            return StaticQuery<DataViewer>("Select top 10 * From [TBLXMLSource] order by ID desc");
        }
        public static IEnumerable<Data> Get_AllbyCsvIDFailed(string ide)
        {
            return StaticQuery<Data>("Select * From [TBLXMLSource] where CsvID=@ID  and IsFailed=1", new { ID = ide });
        }
        public static IEnumerable<Data> Get_AllbyCsvIDW(string ide, string entry)
        {
            return StaticQuery<Data>("Select * From [TBLXMLSource] where CsvID=@ID and EntryNumber=@ent", new { ID = ide, ent = entry });
        }
        public static IEnumerable<Data> Get_Allz()
        {
            return StaticQuery<Data>(" Select  EndDate,AccountMainID,AccountMainDescription,[DebitCreditCode],CAST(SUM(TotalDebit) as Decimal(18,2)) as Amount From [TBLXMLSource] group by  EndDate,AccountMainID,AccountMainDescription,[DebitCreditCode] order by AccountMainID");
        }
        public static Data GetRow_(string ide)
        {
            return StaticQuery<Data>("Select * From [TBLXMLSource] where ID=@ID ", new { ID = ide }).FirstOrDefault();
        }
        //   [SampleDataTypeOld21]

        public void InsertTB(List<Dataz> dat)
        {
            SqlConnection conn = null;
            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Sample";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dat;
                param.Direction = ParameterDirection.Input;
                String dbConnStr = BaseModel.ConnectionString;

                int ret = 0;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("SampleProcedure");
                    conn.Open();
                    sqlCmd.Connection = conn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add(param);

                    ret = sqlCmd.ExecuteNonQuery();
                }

                var hh = ret;
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 1;
                lg.CsvID = 1;
                lg.ERLOG = "InsertTB--" + ex.ToString();
                lg.Save_AppLogs();
                var tt = ex;
                throw;
            }
            finally
            { conn.Close(); }


        }


        //        void SqlMapper.IDynamicParameters.AddParameters(System.Data.IDbCommand command,
        //                                                SqlMapper.Identity identity)
        //        {
        //            List<Dataz> dat = new List<Dataz>();
        //     // and then whatever the code is...
        //     ((SqlCommand)command).Parameters
        //        .AddWithValue("", dat).SqlDbType = System.Data.SqlDbType.Structured;

        //}
        public static void InsertTBUP(DataCollection dat)
        {
            String dbConnStr = BaseModel.ConnectionString;
            IDbConnection conn = new SqlConnection(dbConnStr);// grab your conn
            conn.Open();
            try
            {
                IDbCommand command = conn.CreateCommand();
                //command.CommandText = "delete from testtable";
                //command.ExecuteNonQuery();
                int initTime = Environment.TickCount;

                IDbTransaction t = conn.BeginTransaction(
                   IsolationLevel.RepeatableRead);
                command.Transaction = t;
                StringBuilder builder = new StringBuilder();
                //builder.Append(string.Format(
                //    "INSERT INTO TBLXMLSource" +
                //    "([StartDate],[EndDate],[EnteredBy],[EnteredDate],[EntryNumber],[EntryComment],[BatchID],[BatchDescription],[TotalDebit],[TotalCredit],[DocumentType],[DocumentTypeDescription],[DocumentNumber],[DocumentDate],[PaymentMethod],[AccountMainID],[AccountMainDescription],[AccountSubDescription],[AccountSubID],[Amount],[DebitCreditCode],[PostingDate],[DetailComment],[CsvID]) " +
                //    "VALUES( {0}, {1}, {2} , {3}, {4} , {5}, {6} , {7}, {8} , {9}, {10} , {11}, {12} , {13}, {14} , {15}, {16} , {17}, {18} , {19}, {20} , {21}, {22} , {23}) GO ",
                //    dat[0].StartDate,dat[0].EndDate,dat[0].EnteredBy,dat[0].EnteredDate,dat[0].EntryNumber,dat[0].EntryComment,dat[0].BatchID,dat[0].BatchDescription,dat[0].TotalDebit,dat[0].TotalCredit,dat[0].DocumentType,dat[0].DocumentTypeDescription,dat[0].DocumentNumber,dat[0].DocumentDate,dat[0].PaymentMethod,dat[0].AccountMainID,dat[0].AccountMainDescription,dat[0].AccountSubDescription,dat[0].AccountSubID,dat[0].Amount,dat[0].DebitCreditCode,dat[0].PostingDate,dat[0].DetailComment,dat[0].CsvID));
                int tt = dat.Count / 5000;
                int yyy = 0;
                for (int z = 1; z < tt + 1; z++)
                {
                    builder = new StringBuilder();
                    for (int i = yyy; i < z * 5000; i++)
                    {
                        if (dat.Count <= i)
                        {
                            break;

                        }

                        builder.Append(string.Format(
                            "   INSERT INTO TBLXMLSource" +
                        "([StartDate],[EndDate],[EnteredBy],[EnteredDate],[EntryNumber],[EntryComment],[BatchID],[BatchDescription],[TotalDebit],[TotalCredit],[DocumentType],[DocumentTypeDescription],[DocumentNumber],[DocumentDate],[PaymentMethod],[AccountMainID],[AccountMainDescription],[AccountSubDescription],[AccountSubID],[Amount],[DebitCreditCode],[PostingDate],[DetailComment],[CsvID]) " +
                        "VALUES( '{0}', '{1}', '{2}' , '{3}', '{4}' , '{5}', '{6}' , '{7}', '{8}' , '{9}', '{10}' , '{11}', '{12}' , '{13}', '{14}' , '{15}', '{16}' , '{17}', '{18}' , '{19}', '{20}' , '{21}', '{22}' , '{23}') GO ",
                            dat[i].StartDate.ToString(), dat[i].EndDate.ToString(), dat[i].EnteredBy.ToString(), dat[i].EnteredDate.ToString(), dat[i].EntryNumber.ToString(), dat[i].EntryComment.ToString(), dat[i].BatchID.ToString(), dat[i].BatchDescription.ToString(), dat[i].TotalDebit.ToString(), dat[i].TotalCredit.ToString(), dat[i].DocumentType.ToString(), dat[i].DocumentTypeDescription.ToString(), dat[i].DocumentNumber.ToString(), dat[i].DocumentDate.ToString(), dat[i].PaymentMethod.ToString(), dat[i].AccountMainID.ToString(), dat[i].AccountMainDescription.ToString(), dat[i].AccountSubDescription.ToString(), dat[i].AccountSubID.ToString(), dat[i].Amount.ToString(), dat[i].DebitCreditCode.ToString(), dat[i].PostingDate.ToString(), dat[i].DetailComment.ToString(), dat[i].CsvID.ToString()));
                        yyy = i;
                    }
                    command.CommandText = builder.ToString();
                    command.ExecuteNonQuery();
                    t.Commit();
                }



                Console.WriteLine("{0} ms",
                  Environment.TickCount - initTime);
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 1;
                lg.CsvID = 1;
                lg.ERLOG = "InsertTBUP--" + ex.ToString();
                lg.Save_AppLogs();
                var tt = ex;
                throw;
            }
            finally
            {
                conn.Close();
            }
            //try

            ////{
            ////    SqlParameter param = new SqlParameter();
            ////    param.ParameterName = "@Sample";
            ////    param.SqlDbType = SqlDbType.Structured;
            ////    param.Value = dat;
            ////    param.Direction = ParameterDirection.Input;
            ////    String dbConnStr = BaseModel.ConnectionString;
            ////    SqlConnection conn = null;
            ////    int ret = 0;
            ////    using (conn = new SqlConnection(dbConnStr))
            ////    {
            ////        SqlCommand sqlCmd = new SqlCommand("SampleProcedure");
            ////        conn.Open();
            ////        sqlCmd.Connection = conn;
            ////        sqlCmd.CommandType = CommandType.StoredProcedure;

            ////        sqlCmd.Parameters.Add(param);

            ////        ret = sqlCmd.ExecuteNonQuery();
            ////    }
            //    var hh = ret;
            //    //using (IDbConnection conn = new SqlConnection(BaseModel.ConnectionString))
            //    //{
            //    //    conn.Open();

            //    //    // Execute the user defined function or stored procedure and fetch the
            //    //    // matching results:
            //    //    //var orderHistoryEntries =
            //    //    //    conn.Query<dynamic>("SampleProcedure",
            //    //    //                new TableValueParameter("@Sample", "SampleDataType21",
            //    //    //                                                   dat),null,true,240,CommandType.StoredProcedure);


            //    //    SqlMapper.Query<int>(conn, "SampleProcedure", new TableValueParameter("@Sample", "SampleDataType21",
            //    //                                                       dat), null, true, 240, CommandType.StoredProcedure);
            //    //    // Do something with the results:
            //    //    // Additional code here...
            //    //}

            //    //using (var conn = new SqlConnection(BaseModel.ConnectionString))
            //    //{
            //    //    conn.Open();

            //    //    // Execute the user defined function or stored procedure and fetch the
            //    //    // matching results:
            //    //    //var orderHistoryEntries =
            //    //    //    conn.Query<dynamic>("select * from udf_GetOrderHistoryForOrderIds(@OrderIds)",
            //    //    //                new TableValueParameter("@OrderIds", "OrderIdsTableType",
            //    //    //                                                   dat));

            //    //    // Do something with the results:
            //    //    var parameters = new DynamicParameters();
            //    //    parameters.AddTable("@Sample", "Dataz", dat);

            //    //    // Additional code here...
            //    //    conn.Query("SampleProcedure", parameters, commandType: CommandType.StoredProcedure);
            //    //}


            //    //SqlConnection conn = new SqlConnection(dbConnStr);
            //    //var result = conn.Query("SampleProcedure", parameters, commandType: CommandType.StoredProcedure);
            //    //SqlParameter param = new SqlParameter();
            //    //param.ParameterName = "@Sample";
            //    //param.SqlDbType = SqlDbType.Structured;
            //    //param.Value = dat;
            //    //param.Direction = ParameterDirection.Input;
            //    //String dbConnStr = BaseModel.ConnectionString;
            //    //SqlConnection conn = null;
            //    //int ret = 0;
            //    //using (conn = new SqlConnection(dbConnStr))
            //    //{
            //    //    SqlCommand sqlCmd = new SqlCommand("SampleProcedure");
            //    //    conn.Open();
            //    //    sqlCmd.Connection = conn;
            //    //    sqlCmd.CommandType = CommandType.StoredProcedure;

            //    //    sqlCmd.Parameters.Add(param);

            //    //    ret = sqlCmd.ExecuteNonQuery();
            //    //}
            //    //var hh = ret;
            //}
            //catch (Exception ex)
            //{
            //    var tt = ex;
            //    throw;
            //}


        }
        public static DataCollectionBlncMzn SetBilancoFromListMizan(List<DashBilancoViewMizan> dat, long compide, int myear)
        {

            DataCollectionBlncMzn nlist = new DataCollectionBlncMzn();
            DashBilancoViewMizan dt = new DashBilancoViewMizan();


            foreach (var itemz in dat)
            {
                dt = new DashBilancoViewMizan();
                dt.AccountMainID = itemz.AccountMainID;
                dt.AccountMainDescription = itemz.AccountMainDescription;
                dt.DebitCreditCode = itemz.DebitCreditCode;
                dt.Amount = itemz.Amount;
                dt.CompanyID = compide;
                dt.Year = myear;
                dt.GroupName = itemz.GroupName;
                dt.CounterZone = itemz.CounterZone;
                dt.TypeID = itemz.TypeID;
                dt.IsHidden = itemz.IsHidden; nlist.Add(dt);

            }
            return nlist;
        }
        public static DataCollectionBlncMznExcelNew SetBilancoFromListMizanExcelNew(List<XmlExcel> dat, long compide, int myear)
        {

            DataCollectionBlncMznExcelNew nlist = new DataCollectionBlncMznExcelNew();
            XmlExcel dt = new XmlExcel();



            //nlist = dat.Select(itemz => new XmlExcel { AccountMainID = itemz.AccountMainID, AccountMainDescription = itemz.AccountMainDescription, AmountBakiye = itemz.AmountBakiye, DebitAmount = itemz.DebitAmount, CreditAmount = itemz.CreditAmount, CompanyID = compide, Year = myear });

            foreach (var itemz in dat)
            {
                dt = new XmlExcel();
                dt.AccountMainID = itemz.AccountMainID;
                dt.AccountMainDescription = itemz.AccountMainDescription;
                dt.AmountBakiye = itemz.AmountBakiye;
                dt.DebitAmount = itemz.DebitAmount;
                dt.CreditAmount = itemz.CreditAmount;
                dt.CompanyID = compide;
                dt.CsvID = itemz.CsvID;
                dt.MainMonth = itemz.MainMonth;
                dt.Year = myear; nlist.Add(dt);
            }
            return nlist;
        }
        public static DataCollectionBlncMznExcel SetBilancoFromListMizanExcel(List<XmlExcel> dat, long compide, int myear, int mont)
        {

            DataCollectionBlncMznExcel nlist = new DataCollectionBlncMznExcel();
            XmlExcel dt = new XmlExcel();



            //nlist = dat.Select(itemz => new XmlExcel { AccountMainID = itemz.AccountMainID, AccountMainDescription = itemz.AccountMainDescription, AmountBakiye = itemz.AmountBakiye, DebitAmount = itemz.DebitAmount, CreditAmount = itemz.CreditAmount, CompanyID = compide, Year = myear });

            foreach (var itemz in dat)
            {
                if (itemz == null) continue;
                dt = new XmlExcel();
                dt.AccountMainID = itemz.AccountMainID;
                dt.AccountMainDescription = itemz.AccountMainDescription;
                dt.AmountBakiye = itemz.AmountBakiye?.Replace("-", "").Replace(" ", "") ?? "";
                dt.DebitAmount = itemz.DebitAmount?.Replace("-", "").Replace(" ", "") ?? "";
                dt.CreditAmount = itemz.CreditAmount?.Replace("-", "").Replace(" ", "") ?? "";
                dt.CompanyID = compide;
                dt.MainMonth = mont;
                dt.Year = myear; nlist.Add(dt);
            }
            return nlist;
        }

        public static DataCollectionBlncMznExcelPdf SetBilancoFromListMizanExcelPdf(List<TBLXMLSCheckpdfMizan> dat)
        {
             

            DataCollectionBlncMznExcelPdf nlist = new DataCollectionBlncMznExcelPdf();
            TBLXMLSCheckpdfMizan dt = new TBLXMLSCheckpdfMizan();



            //nlist = dat.Select(itemz => new XmlExcel { AccountMainID = itemz.AccountMainID, AccountMainDescription = itemz.AccountMainDescription, AmountBakiye = itemz.AmountBakiye, DebitAmount = itemz.DebitAmount, CreditAmount = itemz.CreditAmount, CompanyID = compide, Year = myear });

            foreach (var itemz in dat)
            {
                dt = new TBLXMLSCheckpdfMizan();
                dt.AccountMainID = itemz.AccountMainID;
                dt.AccountMainDescription = itemz.AccountMainDescription;
                dt.Amount1 = itemz.Amount1;
                dt.Amount1Diff = itemz.Amount1Diff;
                dt.Amount2 = itemz.Amount2;
                dt.Amount2Diff = itemz.Amount2Diff;
                dt.Amount3 = itemz.Amount3;
                dt.Amount3Diff = itemz.Amount3Diff;
                dt.Amount4 = itemz.Amount4;
                dt.Amount4Diff = itemz.Amount4Diff;
                dt.CompanyID = itemz.CompanyID;
                dt.Year = itemz.Year;
                dt.PageID=itemz.PageID;
                dt.MainMonth = itemz.MainMonth;
                nlist.Add(dt);
            }
            return nlist;
        }
        //public static DataCollectionBlncMznPDFExcelSub SetBilancoFromListMizanExcelSubPDF(List<TBLXMLSCheckpdfMizan> dat)
        //{

        //    DataCollectionBlncMznPDFExcelSub nlist = new DataCollectionBlncMznPDFExcelSub();
        //    TBLXMLSCheckpdfMizan dt = new TBLXMLSCheckpdfMizan();


        //    foreach (var itemz in dat)
        //    {
        //        dt = new TBLXMLSCheckpdfMizan();
        //        dt.AccountMainID = itemz.AccountMainID;
        //        dt.AccountMainDescription = itemz.AccountMainDescription;
        //        dt.Amount1 = itemz.Amount1;
        //        dt.Amount2 = itemz.Amount2;
        //        dt.Amount3 = itemz.Amount3;
        //        dt.Amount4 = itemz.Amount4;
        //        dt.Amount1Diff = itemz.Amount1Diff;
        //        dt.Amount2Diff = itemz.Amount2Diff;
        //        dt.Amount3Diff = itemz.Amount3Diff;
        //        dt.Amount4Diff = itemz.Amount4Diff;
        //        dt.AccountMainID = itemz.AccountMainID;
        //        dt.Year = itemz.Year; 
        //        nlist.Add(dt);
        //    }
        //    return nlist;
        //}
        public static DataCollectionBlncMznExcelSub SetBilancoFromListMizanExcelSub(List<XmlExcel> dat, long compide, int myear)
        {

            DataCollectionBlncMznExcelSub nlist = new DataCollectionBlncMznExcelSub();
            XmlExcel dt = new XmlExcel();


            foreach (var itemz in dat)
            {
                dt = new XmlExcel();
                dt.AccountMainID = itemz.AccountMainID;
                dt.AccountMainDescription = itemz.AccountMainDescription;
                dt.AmountBakiye = itemz.AmountBakiye?.Replace("-", "").Replace(" ", "") ?? "";
                dt.DebitAmount = itemz.DebitAmount?.Replace("-", "").Replace(" ", "") ?? "";
                dt.CreditAmount = itemz.CreditAmount?.Replace("-", "").Replace(" ", "") ?? "";
                dt.CompanyID = compide;
                dt.Year = myear; nlist.Add(dt);
            }
            return nlist;
        }
        public static DataCollectionBlnc SetBilancoFromList(List<DashBilancoView> dat, long compide, int myear)
        {

            DataCollectionBlnc nlist = new DataCollectionBlnc();
            DashBilancoView dt = new DashBilancoView();


            foreach (var itemz in dat)
            {
                dt = new DashBilancoView();
                dt.AccountMainID = itemz.AccountMainID;
                dt.AccountMainDescription = itemz.AccountMainDescription;
                dt.DebitCreditCode = itemz.DebitCreditCode;
                dt.Acilis = itemz.Acilis;
                dt.January = itemz.January;
                dt.February = itemz.February;
                dt.March = itemz.March;
                dt.April = itemz.April;
                dt.May = itemz.May;
                dt.June = itemz.June;
                dt.July = itemz.July;
                dt.August = itemz.August;
                dt.September = itemz.September;
                dt.October = itemz.October;
                dt.November = itemz.November;
                dt.December = itemz.December;
                dt.CompanyID = compide;
                dt.Year = myear;
                dt.GroupName = itemz.GroupName;
                dt.CounterZone = itemz.CounterZone;
                dt.TypeID = itemz.TypeID;
                dt.IsHidden = itemz.IsHidden; nlist.Add(dt);



            }
            return nlist;
        }

        public static DataCollectionBlncQnb SetBilancoFromListQnb(List<DashBilancoViewQnb> dat, long compide, int myear, byte codeMainTypeID)
        {

            DataCollectionBlncQnb nlist = new DataCollectionBlncQnb();
            DashBilancoViewQnb dt = new DashBilancoViewQnb();


            foreach (var itemz in dat)
            {
                dt = new DashBilancoViewQnb();
                dt.AccountMainID = itemz.AccountMainID;
                dt.AccountMainDescription = itemz.AccountMainDescription;
                dt.Amount = itemz.Amount;
                dt.CompanyID = compide;
                dt.Year = myear;
                dt.GroupName = itemz.GroupName;
                dt.CounterZone = itemz.CounterZone;
                dt.TypeID = itemz.TypeID;
                dt.IsHidden = itemz.IsHidden;
                dt.MainTypeID = codeMainTypeID;
                nlist.Add(dt);

            }
            return nlist;
        }
        //TBLMRevenue TBLMSampleBlnco   
        public static void InsertBilnco(DataCollectionBlnc dat)
        {

            if (dat.Count < 1)
            {
                return;
            }


            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Sample";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dat;
                param.Direction = ParameterDirection.Input;
                String dbConnStr = BaseModel.ConnectionString;
                SqlConnection conn = null;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("SampleBlncProcedure");
                    conn.Open();
                    sqlCmd.Connection = conn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add(param);

                    sqlCmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 1;
                lg.CsvID = 1;
                lg.ERLOG = "InsertBilnco--" + ex.ToString();
                lg.Save_AppLogs();

            }

        }


        public static void InsertBilncoQnb(DataCollectionBlncQnb dat)
        {
            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Sample";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dat;
                param.Direction = ParameterDirection.Input;
                String dbConnStr = BaseModel.ConnectionString;
                SqlConnection conn = null;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("SampleBlncProcedureQnb");
                    conn.Open();
                    sqlCmd.Connection = conn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add(param);

                    sqlCmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 1;
                lg.CsvID = 1;
                lg.ERLOG = "InsertBilncoQnb--" + ex.ToString();
                lg.Save_AppLogs();

            }


        }
        public static void InsertBilncoQnbGelir(DataCollectionBlncQnb dat)
        {
            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Sample";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dat;
                param.Direction = ParameterDirection.Input;
                String dbConnStr = BaseModel.ConnectionString;
                SqlConnection conn = null;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("SampleBlncProcedureQnbGelir");
                    conn.Open();
                    sqlCmd.Connection = conn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add(param);

                    sqlCmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 1;
                lg.CsvID = 1;
                lg.ERLOG = "InsertBilncoQnbGelir--" + ex.ToString();
                lg.Save_AppLogs();

            }

        }
        public static void InsertBilncoMzn(DataCollectionBlncMzn dat)
        {
            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Sample";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dat;
                param.Direction = ParameterDirection.Input;
                String dbConnStr = BaseModel.ConnectionString;
                SqlConnection conn = null;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("SampleBlncProcedureMzn");
                    conn.Open();
                    sqlCmd.Connection = conn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add(param);

                    sqlCmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 1;
                lg.CsvID = 1;
                lg.ERLOG = "InsertBilncoMzn--" + ex.ToString();
                lg.Save_AppLogs();

            }

        }
        public static void InsertDataMizanNew(DataCollectionBlncMznExcelNew dat)
        {

            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Sample";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dat;
                param.Direction = ParameterDirection.Input;
                String dbConnStr = BaseModel.ConnectionString;
                SqlConnection conn = null;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("SampleMizanExcelNew");
                    conn.Open();
                    sqlCmd.Connection = conn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add(param);

                    sqlCmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 1;
                lg.CsvID = 1;
                lg.ERLOG = "InsertDataMizan--" + ex.ToString();
                lg.Save_AppLogs();

            }




        }
        public static void InsertDataMizan(DataCollectionBlncMznExcel dat)
        {

            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Sample";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dat;
                param.Direction = ParameterDirection.Input;
                String dbConnStr = BaseModel.ConnectionString;
                SqlConnection conn = null;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("SampleMizanExcel");
                    conn.Open();
                    sqlCmd.Connection = conn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add(param);

                    sqlCmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 1;
                lg.CsvID = 1;
                lg.ERLOG = "InsertDataMizan--" + ex.ToString();
                lg.Save_AppLogs();

            }




        }

        public static void InsertDataMizanPdf(DataCollectionBlncMznExcelPdf dat)
        {
            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Sample";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dat;
                param.Direction = ParameterDirection.Input;
                String dbConnStr = BaseModel.ConnectionString;
                SqlConnection conn = null;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("SampleMizanExcelPDF");
                    conn.Open();
                    sqlCmd.Connection = conn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add(param);

                    sqlCmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 1;
                lg.CsvID = 1;
                lg.ERLOG = "InsertDataMizanPdf--" + ex.ToString();
                lg.Save_AppLogs();

            }

        }

        public static void InsertDataMizanSub(DataCollectionBlncMznExcelSub dat)
        {
            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Sample";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dat;
                param.Direction = ParameterDirection.Input;
                String dbConnStr = BaseModel.ConnectionString;
                SqlConnection conn = null;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("SampleMizanExcelSub");
                    conn.Open();
                    sqlCmd.Connection = conn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add(param);

                    sqlCmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 1;
                lg.CsvID = 1;
                lg.ERLOG = "InsertDataMizanSub--" + ex.ToString();
                lg.Save_AppLogs();

            }



        }
        public static void InsertRvn(DataCollectionBlnc dat)
        {

            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Sample";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dat;
                param.Direction = ParameterDirection.Input;
                String dbConnStr = BaseModel.ConnectionString;
                SqlConnection conn = null;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("SampleRvnProcedure");
                    conn.Open();
                    sqlCmd.Connection = conn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add(param);

                    sqlCmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 1;
                lg.CsvID = 1;
                lg.ERLOG = "InsertRvn--" + ex.ToString();
                lg.Save_AppLogs();

            }


        }
        public static void InsertRvnMzn(DataCollectionBlncMzn dat)
        {
            if (dat.Count < 1)
            {
                return;
            }

            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Sample";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dat;
                param.Direction = ParameterDirection.Input;
                String dbConnStr = BaseModel.ConnectionString;
                SqlConnection conn = null;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("SampleRvnProcedureMzn");
                    conn.Open();
                    sqlCmd.Connection = conn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add(param);

                    sqlCmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 1;
                lg.CsvID = 1;
                lg.ERLOG = "InsertRvnMzn--" + ex.ToString();
                lg.Save_AppLogs();

            }


        }
        public static void InsertWCapitalMzn(DataCollectionBlncMzn dat)
        {

            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Sample";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dat;
                param.Direction = ParameterDirection.Input;
                String dbConnStr = BaseModel.ConnectionString;
                SqlConnection conn = null;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("SampleWcapitalMzn");
                    conn.Open();
                    sqlCmd.Connection = conn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add(param);

                    sqlCmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 1;
                lg.CsvID = 1;
                lg.ERLOG = "InsertWCapitalMzn--" + ex.ToString();
                lg.Save_AppLogs();

            }


        }

        public static void InsertWCapital(DataCollectionBlnc dat)
        {
            if (dat.Count < 1)
            {
                return;
            }

            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Sample";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dat;
                param.Direction = ParameterDirection.Input;
                String dbConnStr = BaseModel.ConnectionString;
                SqlConnection conn = null;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("SampleWcapital");
                    conn.Open();
                    sqlCmd.Connection = conn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add(param);

                    sqlCmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 1;
                lg.CsvID = 1;
                lg.ERLOG = "InsertWCapital--" + ex.ToString();
                lg.Save_AppLogs();

            }


        }

        public static void InsertLiquidity(DataCollectionBlnc dat)
        {
            if (dat.Count < 1)
            {
                return;
            }

            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Sample";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dat;
                param.Direction = ParameterDirection.Input;
                String dbConnStr = BaseModel.ConnectionString;
                SqlConnection conn = null;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("SampleTBLLikidite");
                    conn.Open();
                    sqlCmd.Connection = conn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add(param);

                    sqlCmd.ExecuteNonQuery();
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 1;
                lg.CsvID = 1;
                lg.ERLOG = "InsertLiquidity--" + ex.ToString();
                lg.Save_AppLogs();

            }

        }

        public static void InsertLiquidityMzn(DataCollectionBlncMzn dat)
        {

            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Sample";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dat;
                param.Direction = ParameterDirection.Input;
                String dbConnStr = BaseModel.ConnectionString;
                SqlConnection conn = null;
                using (conn = new SqlConnection(dbConnStr))
                {
                    SqlCommand sqlCmd = new SqlCommand("SampleTBLLikiditeMzn");
                    conn.Open();
                    sqlCmd.Connection = conn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add(param);

                    sqlCmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 1;
                lg.CsvID = 1;
                lg.ERLOG = "InsertLiquidityMzn--" + ex.ToString();
                lg.Save_AppLogs();

            }



        }


        public void SetHataLast(long csvID)
        {


            String dbConnStr = BaseModel.ConnectionString;
            //SqlConnection conn = null;
            //using (conn = new SqlConnection(dbConnStr))
            //{
            //    SqlCommand sqlCmd = new SqlCommand("Update [TBLXMLSource] set IsFailed='1' where CsvID=@csv and EntryNumber in(Select ENTRYNO FROM  [dbo].[HATASATIRTOPLAM] where CsvID=@csv)");
            //    conn.Open();
            //    sqlCmd.Parameters.AddWithValue("@csv", csvID);
            //    sqlCmd.CommandTimeout = 240;
            //    sqlCmd.Connection = conn;
            //    sqlCmd.ExecuteNonQuery();
            //}

            SqlConnection cnn = new SqlConnection(dbConnStr);
            //  MainStrPro1zA  

            SqlCommand sqlCmd1 = new SqlCommand("setThreeZone", cnn);
            sqlCmd1.CommandType = CommandType.StoredProcedure;
            sqlCmd1.Parameters.AddWithValue("@csvID", csvID);
            //sqlCmd1.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cnn.Open();
            object obb = sqlCmd1.ExecuteScalar();
            int contractID = 0;
            try
            {
                contractID = Convert.ToInt32(obb);
            }
            catch
            {


            }
            cnn.Close();



        }
        public int SetHataLastz(long compID)
        {
            int returnVal = 0;
            String dbConnStr = BaseModel.ConnectionString;

            SqlConnection cnn1 = new SqlConnection(dbConnStr);

            SqlCommand sqlCmd21 = new SqlCommand("EXEC SetThreeZoneLast @csv", cnn1);
            sqlCmd21.Parameters.AddWithValue("@csv", compID);
            cnn1.Open();
            object obb = sqlCmd21.ExecuteScalar();
            cnn1.Close();

            try
            {
                returnVal = Convert.ToInt32(obb);
            }
            catch
            {

                returnVal = 0;
            }

            return returnVal;
        }
        public void SetHataLastza(long compID, int year_)
        {
            String dbConnStr = BaseModel.ConnectionString;

            SqlConnection cnn1 = new SqlConnection(dbConnStr);

            //SqlCommand sqlCmd21 = new SqlCommand("EXEC SetThreeZoneLastz @CompID,@year", cnn1);
            //sqlCmd21.Parameters.AddWithValue("@CompID", compID);
            //sqlCmd21.Parameters.AddWithValue("@year", year_);
            //cnn1.Open();
            //sqlCmd21.ExecuteNonQuery();
            //cnn1.Close();

            //cnn1 = new SqlConnection(dbConnStr);

            //SqlCommand sqlCmd21a = new SqlCommand("EXEC SP_ProMaxa @CompID,@year", cnn1);
            //sqlCmd21a.Parameters.AddWithValue("@CompID", compID);
            //sqlCmd21a.Parameters.AddWithValue("@year", year_);
            //cnn1.Open();
            //sqlCmd21a.ExecuteNonQuery();
            //cnn1.Close();



            cnn1 = new SqlConnection(dbConnStr);

            SqlCommand sqlCmd1 = new SqlCommand("EXEC SP_ProMax @CompID,@year", cnn1);
            sqlCmd1.Parameters.AddWithValue("@CompID", compID);
            sqlCmd1.Parameters.AddWithValue("@year", year_);
            cnn1.Open();
            sqlCmd1.ExecuteNonQuery();
            cnn1.Close();



        }
        public static IEnumerable<Data> GetRow_TBLXml(string ide)
        {
            return StaticQuery<Data>("Select * From [TBLXMLSource] where CsvID=@ID ", new { ID = ide });
        }
        public void Save_Edefter()
        {
            string sql = @"  INSERT INTO [TBLXMLSource]
          (  
        [StartDate] ,
        [EndDate] ,
        [EnteredBy] ,
        [EnteredDate] ,
        [EntryNumber] ,
        [EntryComment] ,
        [BatchID] ,
        [BatchDescription] ,
        [TotalDebit] ,
        [TotalCredit] ,
        [DocumentType] ,
        [DocumentTypeDescription] ,
        [DocumentNumber] ,
        [DocumentDate] ,
        [PaymentMethod] ,
        [AccountMainID] ,
        [AccountMainDescription] ,
        [AccountSubDescription] ,
        [AccountSubID] ,
        [Amount] ,
        [DebitCreditCode] ,
        [PostingDate] ,
        [DetailComment] ,
CsvID
          ) 
           VALUES 
         (  
        @StartDate ,
        @EndDate ,
        @EnteredBy ,
        @EnteredDate ,
        @EntryNumber ,
        @EntryComment ,
        @BatchID ,
        @BatchDescription ,
        @TotalDebit ,
        @TotalCredit ,
        @DocumentType ,
        @DocumentTypeDescription ,
        @DocumentNumber ,
        @DocumentDate ,
        @PaymentMethod ,
        @AccountMainID ,
        @AccountMainDescription ,
        @AccountSubDescription ,
        @AccountSubID ,
        @Amount ,
        @DebitCreditCode ,
        @PostingDate ,
        @DetailComment ,
@CsvID
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }

        public bool Update_()
        {
            try
            {
                string sql = "UPDATE   [TBLXMLSource] SET    [StartDate]=@StartDate , [EndDate]=@EndDate , [EnteredBy]=@EnteredBy , [EnteredDate]=@EnteredDate , [EntryNumber]=@EntryNumber , [EntryComment]=@EntryComment , [BatchID]=@BatchID , [BatchDescription]=@BatchDescription , [TotalDebit]=@TotalDebit , [TotalCredit]=@TotalCredit , [DocumentType]=@DocumentType , [DocumentTypeDescription]=@DocumentTypeDescription , [DocumentNumber]=@DocumentNumber , [DocumentDate]=@DocumentDate , [PaymentMethod]=@PaymentMethod , [AccountMainID]=@AccountMainID , [AccountMainDescription]=@AccountMainDescription , [AccountSubDescription]=@AccountSubDescription , [AccountSubID]=@AccountSubID , [Amount]=@Amount , [DebitCreditCode]=@DebitCreditCode , [PostingDate]=@PostingDate , [DetailComment]=@DetailComment,CsvID=@CsvID  WHERE [ID]=@ID";
                Execute(sql, this);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
