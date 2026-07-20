using DevExpress.Office.Utils;
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using fincheckup.Models.DigiForm;
using fincheckup.Models.Mizan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace fincheckup.Helper
{
    public static class ExcelHelper
    {
        public static DataTable ExcelToDataTable(string filePath)
        {
            var book = new Workbook();
            book.LoadDocument(filePath);

            // Gizli sayfaları kaldır
            for (int i = book.Worksheets.Count - 1; i >= 0; i--)
            {
                if (book.Worksheets[i].Visible == false)
                    book.Worksheets.RemoveAt(i);
            }

            Worksheet sheet = book.Worksheets[0];
            var range1 = sheet.GetUsedRange();

            // Gizli kolon index'lerini topla
            List<int> nlist = new List<int>();
            for (int i = range1.CurrentRegion.ColumnCount - 1; i >= 0; i--)
            {
                if (sheet.Columns[i].Visible == false)
                    nlist.Add(i);
            }

            var range = sheet.GetUsedRange();
            var table = sheet.CreateDataTable(range, false);

            // TÜM kolonları string yap (son kolon dahil — tarih hatası burada çözülüyor)
            for (int i = 0; i < table.Columns.Count; i++)
                table.Columns[i].DataType = typeof(string);

            var exporter = sheet.CreateDataTableExporter(range, table, false);
            exporter.Options.SkipEmptyRows = true;
            exporter.CellValueConversionError += Exporter_CellValueConversionError;
            exporter.Export();

            // Gizli kolonları sil
            for (int i = range1.CurrentRegion.ColumnCount - 1; i >= 0; i--)
            {
                if (nlist.Contains(i))
                    table.Columns.Remove(table.Columns[i]);
            }

            // Temizlik & hizalama
            TrimAllCells(table);
            RemoveEmptyColumns(table);
            RemoveConstantColumns(table);

            return table;
        }

        public static DataTable ExcelToDataTableFull(string filePath)
        {
            var book = new Workbook();
            book.LoadDocument(filePath);

            // Gizli sayfaları kaldır
            for (int i = book.Worksheets.Count - 1; i >= 0; i--)
            {
                if (book.Worksheets[i].Visible == false)
                    book.Worksheets.RemoveAt(i);
            }

            DataTable tablez = new DataTable();

            foreach (Worksheet sheet in book.Worksheets)
            {
                var range1 = sheet.GetUsedRange();

                // Gizli kolon index'lerini topla
                List<int> nlist = new List<int>();
                for (int i = range1.CurrentRegion.ColumnCount - 1; i >= 0; i--)
                {
                    if (sheet.Columns[i].Visible == false)
                        nlist.Add(i);
                }

                var range = sheet.GetUsedRange();
                var table = sheet.CreateDataTable(range, false);

                // TÜM kolonları string yap (son kolon dahil)
                for (int i = 0; i < table.Columns.Count; i++)
                    table.Columns[i].DataType = typeof(string);

                var exporter = sheet.CreateDataTableExporter(range, table, false);
                exporter.Options.SkipEmptyRows = true;
                exporter.CellValueConversionError += Exporter_CellValueConversionError;
                exporter.Export();

                // Gizli kolonları sil
                for (int i = range1.CurrentRegion.ColumnCount - 1; i >= 0; i--)
                {
                    if (nlist.Contains(i))
                        table.Columns.Remove(table.Columns[i]);
                }

                // Temizlik & hizalama (Merge'den ÖNCE)
                TrimAllCells(table);
                RemoveEmptyColumns(table);
                RemoveConstantColumns(table);

                tablez.Merge(table);
            }

            return tablez;
        }
        //public static DataTable ExcelToDataTable(string filePath)
        //{
        //    var book = new Workbook();
        //    book.LoadDocument(filePath);


        //    for (int i = book.Worksheets.Count - 1; i >= 0; i--)
        //    {
        //        if (book.Worksheets[i].Visible == false)
        //        {
        //            book.Worksheets.RemoveAt(i);
        //        }
        //    }
        //    Worksheet sheet1 = book.Worksheets[0];

        //    var range1 = sheet1.GetUsedRange();
        //    //    var table1 = sheet1.CreateDataTable(range1, false);
        //    //int counter = table1.Columns.Count;
        //    //Worksheet sheet1z = book.Worksheets[0];
        //    //sheet1z.ClearContents(range1);
        //    //sheet1z.CopyFrom(sheet);
        //    Worksheet sheet = book.Worksheets[0];
        //    List<int> nlist = new List<int>();
        //    for (int i = range1.CurrentRegion.ColumnCount; i >= 0; i--)
        //    {
        //        if (sheet.Columns[i].Visible == false)
        //        {
        //            nlist.Add(i);
        //        }
        //    }


        //    var range = sheet.GetUsedRange();

        //    //for (int i = range.CurrentRegion.ColumnCount-1; i >=0 ; i--)
        //    //{
        //    //    if (range.CurrentRegion[i].ColumnWidth == 0)
        //    //    {
        //    //        range.CurrentRegion[i].Delete();
        //    //    }
        //    //}

        //    var table = sheet.CreateDataTable(range, false);
        //    for (int i = 0; i < table.Columns.Count - 1; i++)
        //    {
        //        table.Columns[i].DataType = typeof(string);
        //    }
        //    //for (int i = range1.CurrentRegion.ColumnCount - 1; i >= 0; i--)
        //    //{
        //    //    table.Columns[i].DataType = System.Type.GetType("System.object");

        //    //}
        //    var exporter = sheet.CreateDataTableExporter(range, table, false);

        //    exporter.Options.SkipEmptyRows = true;
        //    exporter.CellValueConversionError += Exporter_CellValueConversionError;
        //    exporter.Export();

        //    for (int i = range1.CurrentRegion.ColumnCount - 1; i >= 0; i--)
        //    {

        //        if (nlist.Contains(i))
        //        {

        //            table.Columns.Remove(table.Columns[i]);
        //        }
        //    }
        //    return table;




        //}
        //public static DataTable ExcelToDataTableFull(string filePath)
        //{
        //    var book = new Workbook();
        //    book.LoadDocument(filePath);


        //    for (int i = book.Worksheets.Count - 1; i >= 0; i--)
        //    {
        //        if (book.Worksheets[i].Visible == false)
        //        {
        //            book.Worksheets.RemoveAt(i);
        //        }
        //    }

        //    DataTable tablez = new DataTable();

        //    foreach (Worksheet item in book.Worksheets)
        //    {
        //        Worksheet sheet1 = item;

        //        var range1 = sheet1.GetUsedRange();
        //        //    var table1 = sheet1.CreateDataTable(range1, false);
        //        //int counter = table1.Columns.Count;
        //        //Worksheet sheet1z = book.Worksheets[0];
        //        //sheet1z.ClearContents(range1);
        //        //sheet1z.CopyFrom(sheet);
        //        Worksheet sheet = item;
        //        List<int> nlist = new List<int>();
        //        for (int i = range1.CurrentRegion.ColumnCount; i >= 0; i--)
        //        {
        //            if (sheet.Columns[i].Visible == false)
        //            {
        //                nlist.Add(i);
        //            }
        //        }


        //        var range = sheet.GetUsedRange();

        //        //for (int i = range.CurrentRegion.ColumnCount-1; i >=0 ; i--)
        //        //{
        //        //    if (range.CurrentRegion[i].ColumnWidth == 0)
        //        //    {
        //        //        range.CurrentRegion[i].Delete();
        //        //    }
        //        //}

        //        var table = sheet.CreateDataTable(range, false);
        //        for (int i = 0; i < table.Columns.Count - 1; i++)
        //        {
        //            table.Columns[i].DataType = typeof(string);
        //        }
        //        //for (int i = range1.CurrentRegion.ColumnCount - 1; i >= 0; i--)
        //        //{
        //        //    table.Columns[i].DataType = System.Type.GetType("System.object");

        //        //}
        //        var exporter = sheet.CreateDataTableExporter(range, table, false);

        //        exporter.Options.SkipEmptyRows = true;
        //        exporter.CellValueConversionError += Exporter_CellValueConversionError;
        //        exporter.Export();

        //        for (int i = range1.CurrentRegion.ColumnCount - 1; i >= 0; i--)
        //        {

        //            if (nlist.Contains(i))
        //            {

        //                table.Columns.Remove(table.Columns[i]);
        //            }
        //        }

        //        tablez.Merge(table);
        //    }


        //    return tablez;




        //}
        public static IEnumerable<XmlExcel> CheckColumnPdfExcelFromJson(List<Datum> eList)
        {
            int counter = 0;

            IEnumerable<XmlExcel> nfortList = eList.Select(x => new XmlExcel() { AccountMainID = x.HesapKodu, AccountMainDescription = x.HesapAdi, DebitAmount = x.Borc.ToString(), CreditAmount = x.Alacak.ToString(), AmountBakiye = x.BorcBakiye.ToString(), DebitBakiye = x.BorcBakiye.ToString(), CreditBakiye = x.AlacakBakiye.ToString() });
            return nfortList;

        }
        public static List<XmlExcel> CheckColumnPdfExcel(DataTable e)
        {
            int counter = 0;

            List<string> nlist = new List<string>();
            List<List<string>> nlista = new List<List<string>>();
            int chkzone = 0;

            foreach (DataColumn column in e.Columns)
            {
                nlist = new List<string>();
                foreach (DataRow row in e.Rows)
                {
                    counter++;
                    if (row[column] != null)
                    {
                        string value = row[column].ToString();
                        if (!String.IsNullOrEmpty(value))
                        {
                            if (!nlist.Contains(value))
                            {
                                nlist.Add(value);
                            }
                        }
                    }


                }
                nlista.Add(nlist);


            }
            List<int> ntechg = new List<int>();
            chkzone = nlista.Max(x => x.Count) / 10;
            for (int i = nlista.Count - 1; i >= 0; i--)
            {
                if (nlista[i].Count < 5)
                {

                    if (nlista[i].Count == 0)
                    {
                        nlista.RemoveAt(i);
                        ntechg.Add(i);
                    }
                    if (nlista[i].Count > 0 && (!nlista[i][0].ToLower().Contains("alacak") && !nlista[i][0].ToLower().Contains("borç") && !nlista[i][0].ToLower().Contains("borc")))
                    {
                        nlista.RemoveAt(i);
                        ntechg.Add(i);
                    }

                }
            }
            ntechg.Sort();


            for (int i = ntechg.Count - 1; i >= 0; i--)
            {

                //ntechg.Add(i);
                e.Columns.RemoveAt(ntechg[i]);
            }
            // t.Columns.RemoveAt(columnIndex);
            //for (int i = 0; i < 10; i++)
            //{

            //    for (int z = 0; z < e.Columns.Count; z++)
            //    {
            //        if (!nlist.Contains(e.Rows[i][z]))
            //        {
            //            nlist.Add(e.Rows[i][z]);
            //        }
            //        nlista.Add(nlist);
            //    }

            //}

            while (e.Columns.Count < 5)
            {
                e.Columns.Add(new DataColumn());
            }

            //if (e.Columns.Count > 5)
            //{
            //    for (int i = e.Columns.Count - 1; i >= 5; i--)
            //    {
            //        e.Columns.RemoveAt(i);
            //    }
            //}


            var chk = nlista;

            e.Columns[0].ColumnName = "AccountMainID";
            e.Columns[1].ColumnName = "AccountMainDescription";
            e.Columns[2].ColumnName = "DebitAmount";
            e.Columns[3].ColumnName = "CreditAmount";
            if (e.Columns.Count > 4)
            {
                e.Columns[4].ColumnName = "DebitBakiye";

            }
            if (e.Columns.Count > 5)
            {
                e.Columns[5].ColumnName = "CreditBakiye";

            }
            e.AcceptChanges();


            //var json = JsonConvert.SerializeObject(e);
            //var YourConvertedDataType = JsonConvert.DeserializeObject<XmlExcel>(json);

            //DataTable dtCloned = e.Clone();




            //foreach (DataRow row in e.Rows)
            //{
            //    dtCloned.ImportRow(row);
            //}


            try
            {
                //List<XmlExcelCheck> nlistExceln = new List<XmlExcelCheck>();
                //XmlExcelCheck nexceln = new XmlExcelCheck();
                //foreach (var item in e.AsEnumerable())
                //{
                //    try
                //    {
                //        nexceln = new XmlExcelCheck();
                //        nexceln.AccountMainID = checkValz(item.Field<String>("AccountMainID")).ToString();
                //        nexceln.AccountMainDescription = checkValz(item.Field<String>("AccountMainDescription").ToString()).ToString();
                //        nexceln.DebitAmount = checkValz(item.Field<String>("DebitAmount").ToString()).ToString();
                //        nexceln.CreditAmount = checkValz(item.Field<String>("CreditAmount").ToString()).ToString();
                //        nexceln.AmountBakiye = checkValz(item.Field<String>("AmountBakiye")).ToString();
                //        nlistExceln.Add(nexceln);
                //    }
                //    catch (Exception ex)
                //    {
                //        var chkxx = ex;
                //        throw;
                //    }

                //}
                List<XmlExcel> lstCustomer = new List<XmlExcel>();

                if (e.Columns.Count > 5)
                {

                    lstCustomer = e.AsEnumerable()
  .Select(x => {
      // Hücre değerlerini güvenle al
      string accId = Convert.ToString(x["AccountMainID"]);
      string accDesc = Convert.ToString(x["AccountMainDescription"]);
      string dbtAmt = Convert.ToString(x["DebitAmount"]);
      string crdAmt = Convert.ToString(x["CreditAmount"]);
      string dbtBak = Convert.ToString(x["DebitBakiye"]);
      string crdBak = Convert.ToString(x["CreditBakiye"]);

      return new XmlExcel
      {
          AccountMainID = checkValz(accId)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
          AccountMainDescription = checkValz(accDesc)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
          DebitAmount = checkValz(dbtAmt),
          CreditAmount = checkValz(crdAmt),
          DebitBakiye = checkValz(dbtBak),
          CreditBakiye = checkValz(crdBak)
      };
  })
  .ToList();
                }
                else if (e.Columns.Count > 4)
                {
                    lstCustomer = e.AsEnumerable()
     .Select(x => {
         // Hücre değerlerini güvenle al
         string accId = Convert.ToString(x["AccountMainID"]);
         string accDesc = Convert.ToString(x["AccountMainDescription"]);
         string dbtAmt = Convert.ToString(x["DebitAmount"]);
         string crdAmt = Convert.ToString(x["CreditAmount"]);
         string dbtBak = Convert.ToString(x["DebitBakiye"]);

         return new XmlExcel
         {
             AccountMainID = checkValz(accId)
                                         .Replace("\r", "")
                                         .ReplaceLineEndings()
                                         .Split(Environment.NewLine, StringSplitOptions.None)[0],
             AccountMainDescription = checkValz(accDesc)
                                         .Replace("\r", "")
                                         .ReplaceLineEndings()
                                         .Split(Environment.NewLine, StringSplitOptions.None)[0],
             DebitAmount = checkValz(dbtAmt),
             CreditAmount = checkValz(crdAmt),
             DebitBakiye = checkValz(dbtBak)
         };
     })
     .ToList();
                }
                else
                {
                    lstCustomer = e.AsEnumerable()
.Select(x => {
    // Hücre değerlerini güvenle al
    string accId = Convert.ToString(x["AccountMainID"]);
    string accDesc = Convert.ToString(x["AccountMainDescription"]);
    string dbtAmt = Convert.ToString(x["DebitAmount"]);
    string crdAmt = Convert.ToString(x["CreditAmount"]);

    return new XmlExcel
    {
        AccountMainID = checkValz(accId)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
        AccountMainDescription = checkValz(accDesc)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
        DebitAmount = checkValz(dbtAmt),
        CreditAmount = checkValz(crdAmt)
    };
})
.ToList();
                }

                int conuter = lstCustomer.Count();
                int conuterz = lstCustomer.Where(x => x.AccountMainID.Length < 3).Count();
                if (conuterz > conuter / 2)
                {
                    e.Columns.RemoveAt(0);
                    return CheckColumnRev(e);
                }
                else
                {
                    return lstCustomer;
                }

            }
            catch
            {
                List<XmlExcel> lstCustomer = new List<XmlExcel>();
                if (e.Columns.Count > 5)
                {

                    lstCustomer = e.AsEnumerable()
  .Select(x => {
      // Hücre değerlerini güvenle al
      string accId = Convert.ToString(x["AccountMainID"]);
      string accDesc = Convert.ToString(x["AccountMainDescription"]);
      string dbtAmt = Convert.ToString(x["DebitAmount"]);
      string crdAmt = Convert.ToString(x["CreditAmount"]);
      string dbtBak = Convert.ToString(x["DebitBakiye"]);
      string crdBak = Convert.ToString(x["CreditBakiye"]);

      return new XmlExcel
      {
          AccountMainID = checkValz(accId)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
          AccountMainDescription = checkValz(accDesc)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
          DebitAmount = checkValz(dbtAmt),
          CreditAmount = checkValz(crdAmt),
          DebitBakiye = checkValz(dbtBak),
          CreditBakiye = checkValz(crdBak)
      };
  })
  .ToList();
                }
                else if (e.Columns.Count > 4)
                {
                    lstCustomer = e.AsEnumerable()
     .Select(x => {
         // Hücre değerlerini güvenle al
         string accId = Convert.ToString(x["AccountMainID"]);
         string accDesc = Convert.ToString(x["AccountMainDescription"]);
         string dbtAmt = Convert.ToString(x["DebitAmount"]);
         string crdAmt = Convert.ToString(x["CreditAmount"]);
         string dbtBak = Convert.ToString(x["DebitBakiye"]);

         return new XmlExcel
         {
             AccountMainID = checkValz(accId)
                                         .Replace("\r", "")
                                         .ReplaceLineEndings()
                                         .Split(Environment.NewLine, StringSplitOptions.None)[0],
             AccountMainDescription = checkValz(accDesc)
                                         .Replace("\r", "")
                                         .ReplaceLineEndings()
                                         .Split(Environment.NewLine, StringSplitOptions.None)[0],
             DebitAmount = checkValz(dbtAmt),
             CreditAmount = checkValz(crdAmt),
             DebitBakiye = checkValz(dbtBak)
         };
     })
     .ToList();
                }
                else
                {
                    lstCustomer = e.AsEnumerable()
.Select(x => {
    // Hücre değerlerini güvenle al
    string accId = Convert.ToString(x["AccountMainID"]);
    string accDesc = Convert.ToString(x["AccountMainDescription"]);
    string dbtAmt = Convert.ToString(x["DebitAmount"]);
    string crdAmt = Convert.ToString(x["CreditAmount"]);

    return new XmlExcel
    {
        AccountMainID = checkValz(accId)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
        AccountMainDescription = checkValz(accDesc)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
        DebitAmount = checkValz(dbtAmt),
        CreditAmount = checkValz(crdAmt)
    };
})
.ToList();
                }

                int conuter = lstCustomer.Count();
                int conuterz = lstCustomer.Where(x => x.AccountMainID.Length < 3).Count();
                if (conuterz > conuter / 2)
                {
                    e.Columns.RemoveAt(0);
                    return CheckColumnRev(e);
                }
                else
                {
                    return lstCustomer;
                }

            }



        }
        private static void Exporter_CellValueConversionError(object sender, CellValueConversionErrorEventArgs e)
        {
            e.Action = DataTableExporterAction.Continue;
            e.DataTableValue = null;
        }
        public static IEnumerable<XmlExcel> CheckColumn(DataTable e)
        {
            int counter = 0;

            List<string> nlist = new List<string>();
            List<List<string>> nlista = new List<List<string>>();
            int chkzone = 0;

            foreach (DataColumn column in e.Columns)
            {
                nlist = new List<string>();
                foreach (DataRow row in e.Rows)
                {
                    counter++;
                    if (row[column] != null)
                    {
                        string value = row[column].ToString();
                        if (!String.IsNullOrEmpty(value))
                        {
                            if (!nlist.Contains(value))
                            {
                                nlist.Add(value);
                            }
                        }
                    }


                }
                nlista.Add(nlist);


            }
            List<int> ntechg = new List<int>();
            chkzone = nlista.Max(x => x.Count) / 10;
            for (int i = nlista.Count - 1; i >= 0; i--)
            {
                if (nlista[i].Count < 5)
                {
                    nlista.RemoveAt(i);
                    ntechg.Add(i);
                }
            }
            ntechg.Sort();


            for (int i = ntechg.Count - 1; i >= 0; i--)
            {

                //ntechg.Add(i);
                e.Columns.RemoveAt(ntechg[i]);
            }
            // t.Columns.RemoveAt(columnIndex);
            //for (int i = 0; i < 10; i++)
            //{

            //    for (int z = 0; z < e.Columns.Count; z++)
            //    {
            //        if (!nlist.Contains(e.Rows[i][z]))
            //        {
            //            nlist.Add(e.Rows[i][z]);
            //        }
            //        nlista.Add(nlist);
            //    }

            //}

            while (e.Columns.Count < 5)
            {
                e.Columns.Add(new DataColumn());
            }

            //if (e.Columns.Count > 5)
            //{
            //    for (int i = e.Columns.Count - 1; i >= 5; i--)
            //    {
            //        e.Columns.RemoveAt(i);
            //    }
            //}


            var chk = nlista;

            e.Columns[0].ColumnName = "AccountMainID";
            e.Columns[1].ColumnName = "AccountMainDescription";
            e.Columns[2].ColumnName = "DebitAmount";
            e.Columns[3].ColumnName = "CreditAmount";
            if (e.Columns.Count > 4)
            {
                e.Columns[4].ColumnName = "DebitBakiye";

            }
            if (e.Columns.Count > 5)
            {
                e.Columns[5].ColumnName = "CreditBakiye";

            }
            e.AcceptChanges();


            //var json = JsonConvert.SerializeObject(e);
            //var YourConvertedDataType = JsonConvert.DeserializeObject<XmlExcel>(json);

            //DataTable dtCloned = e.Clone();




            //foreach (DataRow row in e.Rows)
            //{
            //    dtCloned.ImportRow(row);
            //}



            try
            {
                //List<XmlExcelCheck> nlistExceln = new List<XmlExcelCheck>();
                //XmlExcelCheck nexceln = new XmlExcelCheck();
                //foreach (var item in e.AsEnumerable())
                //{
                //    try
                //    {
                //        nexceln = new XmlExcelCheck();
                //        nexceln.AccountMainID = checkValz(item.Field<String>("AccountMainID")).ToString();
                //        nexceln.AccountMainDescription = checkValz(item.Field<String>("AccountMainDescription").ToString()).ToString();
                //        nexceln.DebitAmount = checkValz(item.Field<String>("DebitAmount").ToString()).ToString();
                //        nexceln.CreditAmount = checkValz(item.Field<String>("CreditAmount").ToString()).ToString();
                //        nexceln.AmountBakiye = checkValz(item.Field<String>("AmountBakiye")).ToString();
                //        nlistExceln.Add(nexceln);
                //    }
                //    catch (Exception ex)
                //    {
                //        var chkxx = ex;
                //        throw;
                //    }

                //}

                List<XmlExcel> lstCustomer = new List<XmlExcel>();

                if (e.Columns.Count > 5)
                {

                    lstCustomer = e.AsEnumerable()
  .Select(x => {
      // Hücre değerlerini güvenle al
      string accId = Convert.ToString(x["AccountMainID"]);
      string accDesc = Convert.ToString(x["AccountMainDescription"]);
      string dbtAmt = Convert.ToString(x["DebitAmount"]);
      string crdAmt = Convert.ToString(x["CreditAmount"]);
      string dbtBak = Convert.ToString(x["DebitBakiye"]);
      string crdBak = Convert.ToString(x["CreditBakiye"]);

      return new XmlExcel
      {
          AccountMainID = checkValz(accId)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
          AccountMainDescription = checkValz(accDesc)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
          DebitAmount = checkValz(dbtAmt),
          CreditAmount = checkValz(crdAmt),
          DebitBakiye = checkValz(dbtBak),
          CreditBakiye = checkValz(crdBak)
      };
  })
  .ToList();
                }
                else if (e.Columns.Count > 4)
                {
                    lstCustomer = e.AsEnumerable()
     .Select(x => {
         // Hücre değerlerini güvenle al
         string accId = Convert.ToString(x["AccountMainID"]);
         string accDesc = Convert.ToString(x["AccountMainDescription"]);
         string dbtAmt = Convert.ToString(x["DebitAmount"]);
         string crdAmt = Convert.ToString(x["CreditAmount"]);
         string dbtBak = Convert.ToString(x["DebitBakiye"]);

         return new XmlExcel
         {
             AccountMainID = checkValz(accId)
                                         .Replace("\r", "")
                                         .ReplaceLineEndings()
                                         .Split(Environment.NewLine, StringSplitOptions.None)[0],
             AccountMainDescription = checkValz(accDesc)
                                         .Replace("\r", "")
                                         .ReplaceLineEndings()
                                         .Split(Environment.NewLine, StringSplitOptions.None)[0],
             DebitAmount = checkValz(dbtAmt),
             CreditAmount = checkValz(crdAmt),
             DebitBakiye = checkValz(dbtBak)
         };
     })
     .ToList();
                }
                else
                {
                    lstCustomer = e.AsEnumerable()
.Select(x => {
    // Hücre değerlerini güvenle al
    string accId = Convert.ToString(x["AccountMainID"]);
    string accDesc = Convert.ToString(x["AccountMainDescription"]);
    string dbtAmt = Convert.ToString(x["DebitAmount"]);
    string crdAmt = Convert.ToString(x["CreditAmount"]);

    return new XmlExcel
    {
        AccountMainID = checkValz(accId)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
        AccountMainDescription = checkValz(accDesc)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
        DebitAmount = checkValz(dbtAmt),
        CreditAmount = checkValz(crdAmt)
    };
})
.ToList();
                }
                int conuter = lstCustomer.Count();
                int conuterz = lstCustomer.Where(x => x.AccountMainID.Length < 3).Count();
                if (conuterz > conuter / 2)
                {
                    e.Columns.RemoveAt(0);
                    return CheckColumnRev(e);
                }
                else
                {
                    return lstCustomer;
                }

            }
            catch
            {

                List<XmlExcel> lstCustomer = new List<XmlExcel>();
                if (e.Columns.Count > 5)
                {

                    lstCustomer = e.AsEnumerable()
  .Select(x => {
      // Hücre değerlerini güvenle al
      string accId = Convert.ToString(x["AccountMainID"]);
      string accDesc = Convert.ToString(x["AccountMainDescription"]);
      string dbtAmt = Convert.ToString(x["DebitAmount"]);
      string crdAmt = Convert.ToString(x["CreditAmount"]);
      string dbtBak = Convert.ToString(x["DebitBakiye"]);
      string crdBak = Convert.ToString(x["CreditBakiye"]);

      return new XmlExcel
      {
          AccountMainID = checkValz(accId)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
          AccountMainDescription = checkValz(accDesc)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
          DebitAmount = checkValz(dbtAmt),
          CreditAmount = checkValz(crdAmt),
          DebitBakiye = checkValz(dbtBak),
          CreditBakiye = checkValz(crdBak)
      };
  })
  .ToList();
                }
                else if (e.Columns.Count > 4)
                {
                    lstCustomer = e.AsEnumerable()
     .Select(x => {
         // Hücre değerlerini güvenle al
         string accId = Convert.ToString(x["AccountMainID"]);
         string accDesc = Convert.ToString(x["AccountMainDescription"]);
         string dbtAmt = Convert.ToString(x["DebitAmount"]);
         string crdAmt = Convert.ToString(x["CreditAmount"]);
         string dbtBak = Convert.ToString(x["DebitBakiye"]);

         return new XmlExcel
         {
             AccountMainID = checkValz(accId)
                                         .Replace("\r", "")
                                         .ReplaceLineEndings()
                                         .Split(Environment.NewLine, StringSplitOptions.None)[0],
             AccountMainDescription = checkValz(accDesc)
                                         .Replace("\r", "")
                                         .ReplaceLineEndings()
                                         .Split(Environment.NewLine, StringSplitOptions.None)[0],
             DebitAmount = checkValz(dbtAmt),
             CreditAmount = checkValz(crdAmt),
             DebitBakiye = checkValz(dbtBak)
         };
     })
     .ToList();
                }
                else
                {
                    lstCustomer = e.AsEnumerable()
.Select(x => {
    // Hücre değerlerini güvenle al
    string accId = Convert.ToString(x["AccountMainID"]);
    string accDesc = Convert.ToString(x["AccountMainDescription"]);
    string dbtAmt = Convert.ToString(x["DebitAmount"]);
    string crdAmt = Convert.ToString(x["CreditAmount"]);

    return new XmlExcel
    {
        AccountMainID = checkValz(accId)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
        AccountMainDescription = checkValz(accDesc)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
        DebitAmount = checkValz(dbtAmt),
        CreditAmount = checkValz(crdAmt)
    };
})
.ToList();
                }


                int conuter = lstCustomer.Count();
                int conuterz = lstCustomer.Where(x => x.AccountMainID.Length < 3).Count();
                if (conuterz > conuter / 2)
                {
                    e.Columns.RemoveAt(0);
                    return CheckColumnRev(e);
                }
                else
                {
                    return lstCustomer;
                }

            }



        }
        public static List<XmlExcel> CheckColumnRev(DataTable e)
        {
            int counter = 0;

            List<string> nlist = new List<string>();
            List<List<string>> nlista = new List<List<string>>();
            int chkzone = 0;

            foreach (DataColumn column in e.Columns)
            {
                nlist = new List<string>();
                foreach (DataRow row in e.Rows)
                {
                    counter++;
                    if (row[column] != null)
                    {
                        string value = row[column].ToString();
                        if (!String.IsNullOrEmpty(value))
                        {
                            if (!nlist.Contains(value))
                            {
                                nlist.Add(value);
                            }
                        }
                    }


                }
                nlista.Add(nlist);


            }
            List<int> ntechg = new List<int>();
            chkzone = nlista.Max(x => x.Count) / 10;
            for (int i = nlista.Count - 1; i >= 0; i--)
            {
                if (nlista[i].Count < 5)
                {
                    nlista.RemoveAt(i);
                    ntechg.Add(i);
                }
            }
            ntechg.Sort();


            for (int i = ntechg.Count - 1; i >= 0; i--)
            {

                //ntechg.Add(i);
                e.Columns.RemoveAt(ntechg[i]);
            }
            // t.Columns.RemoveAt(columnIndex);
            //for (int i = 0; i < 10; i++)
            //{

            //    for (int z = 0; z < e.Columns.Count; z++)
            //    {
            //        if (!nlist.Contains(e.Rows[i][z]))
            //        {
            //            nlist.Add(e.Rows[i][z]);
            //        }
            //        nlista.Add(nlist);
            //    }

            //}

            while (e.Columns.Count < 5)
            {
                e.Columns.Add(new DataColumn());
            }

            //if (e.Columns.Count > 5)
            //{
            //    for (int i = e.Columns.Count - 1; i >= 5; i--)
            //    {
            //        e.Columns.RemoveAt(i);
            //    }
            //}


            var chk = nlista;

            e.Columns[0].ColumnName = "AccountMainID";
            e.Columns[1].ColumnName = "AccountMainDescription";
            e.Columns[2].ColumnName = "DebitAmount";
            e.Columns[3].ColumnName = "CreditAmount";
            if (e.Columns.Count > 4)
            {
                e.Columns[4].ColumnName = "DebitBakiye";

            }
            if (e.Columns.Count > 5)
            {
                e.Columns[5].ColumnName = "CreditBakiye";

            }

            e.AcceptChanges();


            //var json = JsonConvert.SerializeObject(e);
            //var YourConvertedDataType = JsonConvert.DeserializeObject<XmlExcel>(json);

            //DataTable dtCloned = e.Clone();




            //foreach (DataRow row in e.Rows)
            //{
            //    dtCloned.ImportRow(row);
            //}


            try
            {
                //List<XmlExcelCheck> nlistExceln = new List<XmlExcelCheck>();
                //XmlExcelCheck nexceln = new XmlExcelCheck();
                //foreach (var item in e.AsEnumerable())
                //{
                //    try
                //    {
                //        nexceln = new XmlExcelCheck();
                //        nexceln.AccountMainID = checkValz(item.Field<String>("AccountMainID")).ToString();
                //        nexceln.AccountMainDescription = checkValz(item.Field<String>("AccountMainDescription").ToString()).ToString();
                //        nexceln.DebitAmount = checkValz(item.Field<String>("DebitAmount").ToString()).ToString();
                //        nexceln.CreditAmount = checkValz(item.Field<String>("CreditAmount").ToString()).ToString();
                //        nexceln.AmountBakiye = checkValz(item.Field<String>("AmountBakiye")).ToString();
                //        nlistExceln.Add(nexceln);
                //    }
                //    catch (Exception ex)
                //    {
                //        var chkxx = ex;
                //        throw;
                //    }

                //}

                List<XmlExcel> lstCustomer = new List<XmlExcel>();

                if (e.Columns.Count > 5)
                {

                    lstCustomer = e.AsEnumerable()
  .Select(x => {
      // Hücre değerlerini güvenle al
      string accId = Convert.ToString(x["AccountMainID"]);
      string accDesc = Convert.ToString(x["AccountMainDescription"]);
      string dbtAmt = Convert.ToString(x["DebitAmount"]);
      string crdAmt = Convert.ToString(x["CreditAmount"]);
      string dbtBak = Convert.ToString(x["DebitBakiye"]);
      string crdBak = Convert.ToString(x["CreditBakiye"]);

      return new XmlExcel
      {
          AccountMainID = checkValz(accId)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
          AccountMainDescription = checkValz(accDesc)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
          DebitAmount = checkValz(dbtAmt),
          CreditAmount = checkValz(crdAmt),
          DebitBakiye = checkValz(dbtBak),
          CreditBakiye = checkValz(crdBak)
      };
  })
  .ToList();
                }
                else if (e.Columns.Count > 4)
                {
                    lstCustomer = e.AsEnumerable()
     .Select(x => {
         // Hücre değerlerini güvenle al
         string accId = Convert.ToString(x["AccountMainID"]);
         string accDesc = Convert.ToString(x["AccountMainDescription"]);
         string dbtAmt = Convert.ToString(x["DebitAmount"]);
         string crdAmt = Convert.ToString(x["CreditAmount"]);
         string dbtBak = Convert.ToString(x["DebitBakiye"]);

         return new XmlExcel
         {
             AccountMainID = checkValz(accId)
                                         .Replace("\r", "")
                                         .ReplaceLineEndings()
                                         .Split(Environment.NewLine, StringSplitOptions.None)[0],
             AccountMainDescription = checkValz(accDesc)
                                         .Replace("\r", "")
                                         .ReplaceLineEndings()
                                         .Split(Environment.NewLine, StringSplitOptions.None)[0],
             DebitAmount = checkValz(dbtAmt),
             CreditAmount = checkValz(crdAmt),
             DebitBakiye = checkValz(dbtBak)
         };
     })
     .ToList();
                }
                else
                {
                    lstCustomer = e.AsEnumerable()
.Select(x => {
    // Hücre değerlerini güvenle al
    string accId = Convert.ToString(x["AccountMainID"]);
    string accDesc = Convert.ToString(x["AccountMainDescription"]);
    string dbtAmt = Convert.ToString(x["DebitAmount"]);
    string crdAmt = Convert.ToString(x["CreditAmount"]);

    return new XmlExcel
    {
        AccountMainID = checkValz(accId)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
        AccountMainDescription = checkValz(accDesc)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
        DebitAmount = checkValz(dbtAmt),
        CreditAmount = checkValz(crdAmt)
    };
})
.ToList();
                }
                return lstCustomer;

            }
            catch
            {

                List<XmlExcel> lstCustomer = new List<XmlExcel>();
                if (e.Columns.Count > 5)
                {

                    lstCustomer = e.AsEnumerable()
  .Select(x => {
      // Hücre değerlerini güvenle al
      string accId = Convert.ToString(x["AccountMainID"]);
      string accDesc = Convert.ToString(x["AccountMainDescription"]);
      string dbtAmt = Convert.ToString(x["DebitAmount"]);
      string crdAmt = Convert.ToString(x["CreditAmount"]);
      string dbtBak = Convert.ToString(x["DebitBakiye"]);
      string crdBak = Convert.ToString(x["CreditBakiye"]);

      return new XmlExcel
      {
          AccountMainID = checkValz(accId)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
          AccountMainDescription = checkValz(accDesc)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
          DebitAmount = checkValz(dbtAmt),
          CreditAmount = checkValz(crdAmt),
          DebitBakiye = checkValz(dbtBak),
          CreditBakiye = checkValz(crdBak)
      };
  })
  .ToList();
                }
                else if (e.Columns.Count > 4)
                {
                    lstCustomer = e.AsEnumerable()
     .Select(x => {
         // Hücre değerlerini güvenle al
         string accId = Convert.ToString(x["AccountMainID"]);
         string accDesc = Convert.ToString(x["AccountMainDescription"]);
         string dbtAmt = Convert.ToString(x["DebitAmount"]);
         string crdAmt = Convert.ToString(x["CreditAmount"]);
         string dbtBak = Convert.ToString(x["DebitBakiye"]);

         return new XmlExcel
         {
             AccountMainID = checkValz(accId)
                                         .Replace("\r", "")
                                         .ReplaceLineEndings()
                                         .Split(Environment.NewLine, StringSplitOptions.None)[0],
             AccountMainDescription = checkValz(accDesc)
                                         .Replace("\r", "")
                                         .ReplaceLineEndings()
                                         .Split(Environment.NewLine, StringSplitOptions.None)[0],
             DebitAmount = checkValz(dbtAmt),
             CreditAmount = checkValz(crdAmt),
             DebitBakiye = checkValz(dbtBak)
         };
     })
     .ToList();
                }
                else
                {
                    lstCustomer = e.AsEnumerable()
.Select(x => {
    // Hücre değerlerini güvenle al
    string accId = Convert.ToString(x["AccountMainID"]);
    string accDesc = Convert.ToString(x["AccountMainDescription"]);
    string dbtAmt = Convert.ToString(x["DebitAmount"]);
    string crdAmt = Convert.ToString(x["CreditAmount"]);

    return new XmlExcel
    {
        AccountMainID = checkValz(accId)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
        AccountMainDescription = checkValz(accDesc)
                                      .Replace("\r", "")
                                      .ReplaceLineEndings()
                                      .Split(Environment.NewLine, StringSplitOptions.None)[0],
        DebitAmount = checkValz(dbtAmt),
        CreditAmount = checkValz(crdAmt)
    };
})
.ToList();
                }

                return lstCustomer;
            }



        }
        public static string checkValz(object obb)
        {
            string chkk = string.Empty;
            if (obb != null && Convert.ToString(obb) != string.Empty)
            {
                return obb.ToString();
            }

            return chkk;

        }
        private static void TrimAllCells(DataTable table)
        {
            foreach (DataRow row in table.Rows)
                for (int c = 0; c < table.Columns.Count; c++)
                    if (row[c] is string s)
                        row[c] = s.Trim();
        }

        // Tamamen boş kolonları sil
        private static void RemoveEmptyColumns(DataTable table)
        {
            for (int c = table.Columns.Count - 1; c >= 0; c--)
            {
                bool allEmpty = true;
                foreach (DataRow row in table.Rows)
                {
                    if (!string.IsNullOrWhiteSpace(row[c]?.ToString()))
                    {
                        allEmpty = false;
                        break;
                    }
                }
                if (allEmpty)
                    table.Columns.RemoveAt(c);
            }
        }

        // Tüm dolu hücrelerinde aynı değeri tekrar eden kolonları sil (ör. hep "TL")
        private static void RemoveConstantColumns(DataTable table)
        {
            for (int c = table.Columns.Count - 1; c >= 0; c--)
            {
                string firstVal = null;
                bool isConstant = true;

                foreach (DataRow row in table.Rows)
                {
                    var val = (row[c]?.ToString() ?? string.Empty).Trim();
                    if (string.IsNullOrEmpty(val))
                        continue;

                    if (firstVal == null)
                        firstVal = val;
                    else if (!string.Equals(firstVal, val, StringComparison.OrdinalIgnoreCase))
                    {
                        isConstant = false;
                        break;
                    }
                }

                if (isConstant && firstVal != null)
                    table.Columns.RemoveAt(c);
            }
        }
        public static IEnumerable<XmlExcel> ChangeColumName(DataTable e)
        {
            e.Columns[0].ColumnName = "AccountMainID";
            e.Columns[1].ColumnName = "AccountMainDescription";
            e.Columns[2].ColumnName = "DebitAmount";
            e.Columns[3].ColumnName = "CreditAmount";
            if (e.Columns.Count > 4)
            {
                e.Columns[4].ColumnName = "DebitBakiye";

            }
            if (e.Columns.Count > 5)
            {
                e.Columns[5].ColumnName = "CreditBakiye";

            }
            e.AcceptChanges();



            //var json = JsonConvert.SerializeObject(e);
            //var YourConvertedDataType = JsonConvert.DeserializeObject<XmlExcel>(json);



            IEnumerable<XmlExcel> lstCustomer = e.AsEnumerable().Select(x => new XmlExcel()
            {
                AccountMainID = x.Field<String>("AccountMainID").ToString(),
                AccountMainDescription = x.Field<string>("AccountMainDescription"),
                DebitAmount = x.Field<string>("DebitAmount"),
                CreditAmount = x.Field<string>("CreditAmount"),
                DebitBakiye = x.Field<string>("DebitBakiye"),
                CreditBakiye = x.Field<string>("CreditBakiye")
            }).ToList();

            return lstCustomer;
        }
    }
}
