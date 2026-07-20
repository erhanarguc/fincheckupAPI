using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using fincheckup.ENTITY;
using fincheckup.Models;
using fincheckup.Models.NKolay.ENTITY.NwEntity;

namespace fincheckup.Services
{
    public sealed class XmlPipeline
    {
        private List<Dataz> _xMLSourceRow;
        private List<WzoneRow> _wzoneRow;
        private List<string> _entryNoFrAudit;
        public XmlPipeline(List<Dataz> xMLSourceRow, List<WzoneRow> wzoneRow, List<string> entryNoFrAudit)
        {
            _xMLSourceRow = xMLSourceRow;
            _wzoneRow = wzoneRow;
            _entryNoFrAudit = entryNoFrAudit;
        }

        public async Task<List<Dataz>> ProcessXmlGroup()
        {
            var xmlChkSource = _xMLSourceRow.Where(x => (x.IsOpener == 0 || x.IsPassedEntry == 0))
          .GroupBy(x => new { x.TotalCredit, x.TotalDebit, x.AccountMainID,  x.EntryNumber,x.CsvID,x.CompanyDocumentId })
          .Select(g => new XmlChkSourceRow
          {
              TotalDebit = g.Key.TotalDebit ,
              TotalCredit = g.Key.TotalCredit,
              AccountMainID = g.Key.AccountMainID,
              EntryNumber = g.Key.EntryNumber,
              CsvID = g.Key.CsvID,
              CompanyDocumentId = g.Key.CompanyDocumentId,
          })
        
          .OrderBy(r => r.EntryNumber).ThenBy(r => r.AccountMainID, StringComparer.Ordinal)
          .ToList();
 
            var xmlCheckGroups = xmlChkSource
                .GroupBy(x => new { x.EntryNumber, x.TotalCredit, x.CsvID, x.CompanyDocumentId })
                .Select(g => new XmlCheckGroupRow
                {
                    EntryNumber = g.Key.EntryNumber, 
                    TotalCredit = g.Key.TotalCredit,
                    CsvID = g.Key.CsvID,
                    CompanyDocumentId = g.Key.CompanyDocumentId,
                    AccountMainIDList = string.Join(",",
                        g.Select(s => s.AccountMainID ?? string.Empty)
                         .OrderBy(s => s, StringComparer.Ordinal)) 
                })
                .ToList();

        
            var zoneLookup = _wzoneRow
                .Where(z => !string.IsNullOrWhiteSpace(z.MainDescription))
                .Select(z => z.MainDescription!.Trim())
                .ToHashSet(StringComparer.Ordinal);

            var xmlCheckGroupMains = xmlCheckGroups
                .Where(g => zoneLookup.Contains((g.AccountMainIDList ?? string.Empty).Trim()))
                .GroupBy(g => new { g.EntryNumber, g.TotalCredit, g.CsvID })  
                .Select(x => new XmlCheckGroupMainRow
                {
                    EntryNumber = x.Key.EntryNumber, 
                    TotalCredit = x.Key.TotalCredit, 
                })
                .ToList();
            var okKeys = xmlCheckGroupMains 
      .Select(m => (
          Entry: m.EntryNumber?.Trim(),
          Credit: m.TotalCredit  
      ))
      .ToHashSet();

          
            foreach (var g in xmlCheckGroups )
            {
                var key = (g.EntryNumber?.Trim(), g.TotalCredit );
                g.IsFailed = !okKeys.Contains(key);
            }

            var ttt = xmlCheckGroups.Where(x => x.IsFailed == true);
            var controlList = xmlCheckGroups.Where(x => x.IsFailed == true).Select(t => t.EntryNumber);

            var resultFirst = _xMLSourceRow
                    .Where(x => controlList.Contains(x.EntryNumber))
                    .ToList().Select(c => { c.IsFailed = true; return c; }).ToList(); 
            var controlListII = _entryNoFrAudit.Where(x => !controlList.Contains(x));
            var resultLast= _xMLSourceRow
                    .Where(x => controlListII.Contains(x.EntryNumber))
                    .ToList().Select(c => { c.IsFailed = true; return c; }).ToList();
            resultFirst.AddRange(resultLast);
            //await BulkInsert_XmlChkSourceMappingsAsync(Database.ConnectionString, xmlChkSource);      
            await BulkInsert_XmlCheckGroupMappingsAsync(Database.ConnectionString, xmlCheckGroups);
            //await BulkInsert_XmlCheckGroupMainMappingsAsync(Database.ConnectionString, xmlCheckGroupMains);

            return resultFirst;
        }
        public async Task BulkInsert_XmlCheckGroupMappingsAsync(
    string connStr,
    IEnumerable<XmlCheckGroupRow> data )
        { 
            var dt = new DataTable();
            dt.Columns.Add("EntryNumber", typeof(string));
            dt.Columns.Add("CompanyDocumentId", typeof(long));
            dt.Columns.Add("TotalCredit", typeof(float));  
            dt.Columns.Add("CsvID", typeof(int));     
            dt.Columns.Add("AccountMainIDList", typeof(string));
            dt.Columns.Add("IsFailed", typeof(bool));      

            foreach (var r in data)
            {
                var row = dt.NewRow();
                row["EntryNumber"] = OrDbNull(r.EntryNumber);
                row["CompanyDocumentId"] = r.CompanyDocumentId;
                row["TotalCredit"] =  r.TotalCredit ;
                row["CsvID"] =  r.CsvID  ;
                row["AccountMainIDList"] = OrDbNull(r.AccountMainIDList);
                row["IsFailed"] = r.IsFailed;
                dt.Rows.Add(row);
            }
             
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "dbo.XmlCheckGroup";

                    bulkCopy.ColumnMappings.Add("EntryNumber", "EntryNumber");
                    bulkCopy.ColumnMappings.Add("CompanyDocumentId", "CompanyDocumentId");
                    bulkCopy.ColumnMappings.Add("TotalCredit", "TotalCredit");
                    bulkCopy.ColumnMappings.Add("CsvID", "CsvID");
                    bulkCopy.ColumnMappings.Add("AccountMainIDList", "AccountMainIDList");
                    bulkCopy.ColumnMappings.Add("IsFailed", "IsFailed");
                    bulkCopy.WriteToServer(dt);
                }
            }


        }

        public async Task BulkInsert_XmlChkSourceMappingsAsync(
        string connStr,
    IEnumerable<XmlChkSourceRow> data )
        {
            
            var dt = new DataTable();
            dt.Columns.Add("TotalDebit", typeof(string));
            dt.Columns.Add("TotalCredit", typeof(float)); 
            dt.Columns.Add("AccountMainID", typeof(string));
            dt.Columns.Add("CsvID", typeof(int));
            dt.Columns.Add("EntryNumber", typeof(string));
            dt.Columns.Add("CompanyDocumentId", typeof(long));

            foreach (var r in data)
            {
                var row = dt.NewRow();
                row["TotalDebit"] =  r.TotalDebit ;
                row["TotalCredit"] =  r.TotalCredit  ;
                row["AccountMainID"] = OrDbNull(r.AccountMainID);
                row["CsvID"] = r.CsvID ;
                row["EntryNumber"] = OrDbNull(r.EntryNumber );
                row["CompanyDocumentId"] = r.CompanyDocumentId;
                dt.Rows.Add(row);
            }

            

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "dbo.XmlChkSource"; 
                    bulkCopy.ColumnMappings.Add("TotalDebit", "TotalDebit");
                    bulkCopy.ColumnMappings.Add("TotalCredit", "TotalCredit");
                    bulkCopy.ColumnMappings.Add("AccountMainID", "AccountMainID");
                    bulkCopy.ColumnMappings.Add("CsvID", "CsvID");
                    bulkCopy.ColumnMappings.Add("EntryNumber", "EntryNumber");
                    bulkCopy.ColumnMappings.Add("CompanyDocumentId", "CompanyDocumentId");
                    bulkCopy.WriteToServer(dt);
                }
            }
 
        }
        public async Task BulkInsert_XmlCheckGroupMainMappingsAsync(
    string connStr,
    IEnumerable<XmlCheckGroupMainRow> data,
    int timeoutSeconds = 120,
    int batchSize = 10_000)
        {
          
            var dt = new DataTable();
            dt.Columns.Add("EntryNumber", typeof(string));
            dt.Columns.Add("CompanyDocumentId", typeof(long));
            dt.Columns.Add("TotalCredit", typeof(float)); 
            dt.Columns.Add("CsvID", typeof(int));

            foreach (var r in data)
            {
                var row = dt.NewRow();
                row["EntryNumber"] = OrDbNull(r.EntryNumber);
                row["CompanyDocumentId"] = r.CompanyDocumentId;
                row["TotalCredit"] =  r.TotalCredit ;
                row["CsvID"] =  r.CsvID ;
                dt.Rows.Add(row);
            }

             
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "dbo.XmlCheckGroupMain";

                    bulkCopy.ColumnMappings.Add("EntryNumber", "EntryNumber");
                    bulkCopy.ColumnMappings.Add("CompanyDocumentId", "CompanyDocumentId");
                    bulkCopy.ColumnMappings.Add("TotalCredit", "TotalCredit");
                    bulkCopy.ColumnMappings.Add("CsvID", "CsvID");
                    bulkCopy.WriteToServer(dt);
                }
            }
        }
    
 
         
        static object OrDbNull<T>(T? v) where T : struct => v.HasValue ? v.Value : DBNull.Value;
        static object OrDbNull(string? v) => v is null ? DBNull.Value : v;
    }
}
