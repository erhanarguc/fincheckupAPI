using fincheckup.Models.NKolay.ENTITY.NwEntity;
using System.Collections.Generic;
using System; 
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using fincheckup.Models;
using fincheckup.Models.NKolay.ViewM;
using fincheckup.ENTITY;

namespace fincheckup.Services
{
    public class XmlPipelineAudit
    {
        private List<Dataz> _xMLSourceRow;
        private List<ErrorCheckSet> _errorCheckSet;
        private List<TBLErrzoneInsideWordRow> _errzoneWord;
        private Dictionary<string,string> perEntryGroup;

        public XmlPipelineAudit(List<Dataz> xMLSourceRow, List<ErrorCheckSet> errorCheckSet, List<TBLErrzoneInsideWordRow>  errzoneWord)
        {
            _xMLSourceRow = xMLSourceRow;
            _errorCheckSet = errorCheckSet;
            _errzoneWord= errzoneWord;
            perEntryGroup= _xMLSourceRow
                .GroupBy(x => x.EntryNumber!.Trim(), StringComparer.Ordinal)
                .ToDictionary(
                    g => g.Key,
                    g => string.Join(",",
                             g.Select(s => s.AccountMainID)
              .Where(id => !string.IsNullOrWhiteSpace(id))
              .Select(id => id.Trim())
              .Distinct(StringComparer.Ordinal)
              .OrderBy(id => id, StringComparer.Ordinal)),
                    StringComparer.Ordinal);
        }

        public   Task<List<TBLErrzoneInsideXMLRow>> ProcessStepI(long csvId)
        {
            List<TBLErrzoneInsideXMLRow> elist = new List<TBLErrzoneInsideXMLRow> ();

            var rules = _errorCheckSet.Where(r => r.QueryType == 1);

            foreach (var rule in rules)
            {
                var matches = _xMLSourceRow
                    .Where(x => 
                        string.Equals(x.AccountMainID?.Trim(), rule.MainDescription?.Trim(), StringComparison.Ordinal) && 
                        !string.IsNullOrWhiteSpace(x.EntryNumber))
                    .Select(x => x.EntryNumber!.Trim())
                    .Distinct(StringComparer.Ordinal); // tekilleştirmek istersen

                foreach (var en in matches)
                {
                    elist.Add(new TBLErrzoneInsideXMLRow
                    {
                        CsvID = csvId,
                        EntryNo = en,
                        ErrorInsideID = rule.ID
                    });
                }
            }
            return Task.FromResult(elist);
        }
        public   Task<List<TBLErrzoneInsideXMLRow>> ProcessStepII(long csvId)
        {
            List<TBLErrzoneInsideXMLRow> elist = new List<TBLErrzoneInsideXMLRow>();


            var rules = _errorCheckSet.Where(r => r.QueryType == 2);

            // @TablSearch: sadece bu CsvID için EntryNumber -> string_agg(AccountMainID, ',')
            var accountGroupByEntry =
                _xMLSourceRow
                    .Where(x =>   !string.IsNullOrWhiteSpace(x.EntryNumber))
                    .GroupBy(x => x.EntryNumber!.Trim(), StringComparer.Ordinal)
                    .ToDictionary(
                        g => g.Key,
                        g => string.Join(",",
                                g.Select(z => z.AccountMainID ?? string.Empty)
                                 .Where(s => s.Length > 0)
                                 .Distinct(StringComparer.Ordinal)
                                 .OrderBy(s => s, StringComparer.Ordinal)),
                        StringComparer.Ordinal);

            foreach (var rule in rules)
            {
                // İçteki IN (...) alt sorgusu ile aynı: base filtreyi sağlayan entry'ler
                var candidateEntries =
                    _xMLSourceRow
                        .Where(x => 
                            string.Equals(x.AccountMainID?.Trim(), rule.MainDescription?.Trim(), StringComparison.Ordinal) &&
                            string.Equals(x.DebitCreditCode?.Trim(), rule.DebitCreditCode?.Trim(), StringComparison.Ordinal) &&
                            !string.IsNullOrWhiteSpace(x.EntryNumber))
                        .Select(x => x.EntryNumber!.Trim())
                        .Distinct(StringComparer.Ordinal)
                        .ToList();

                // NOT LIKE '%@OutMainDesc%'
                var outKey = (rule.OutMainDesc ?? string.Empty).Trim();
                if (outKey.Length == 0) continue; // NOT LIKE '%%' SQL'de hep false; burada da atlıyoruz

                foreach (var entry in candidateEntries)
                {
                    if (!accountGroupByEntry.TryGetValue(entry, out var mainIdGroup))
                        continue;

                    if (mainIdGroup.IndexOf(outKey, StringComparison.Ordinal) < 0)
                    {
                        elist.Add(new TBLErrzoneInsideXMLRow
                        {
                            CsvID = csvId,
                            EntryNo = entry,
                            ErrorInsideID = rule.ID // @InsideID karşılığı
                        });
                    }
                }
            }

            return Task.FromResult(elist);

             
        }

        public Task<List<TBLErrzoneInsideXMLRow>> ProcessStepIII(long csvId)
        {
            List<TBLErrzoneInsideXMLRow> elist = new List<TBLErrzoneInsideXMLRow>();


            var rules = _errorCheckSet.Where(r => r.QueryType == 3);
  
     

            foreach (var rule in rules)
            {
            
                var candidateEntries = _xMLSourceRow
                    .Where(x => 
                        string.Equals(x.AccountMainID?.Trim(), rule.MainDescription?.Trim(), StringComparison.Ordinal) &&
                        string.Equals(x.DebitCreditCode?.Trim(), rule.DebitCreditCode?.Trim(), StringComparison.Ordinal))
                    .Select(x => x.EntryNumber!.Trim())
                    .Distinct(StringComparer.Ordinal)
                    .ToList();

                var inKey = (rule.InMainDesc ?? string.Empty).Trim();  
                var outKey = (rule.OutMainDesc ?? string.Empty).Trim();  

                var tablSearchEntryno = new HashSet<string>(StringComparer.Ordinal);
                var tablSearchEntrynoOut = new HashSet<string>(StringComparer.Ordinal);

                foreach (var entry in candidateEntries)
                {
                    if (!perEntryGroup.TryGetValue(entry, out var mainIdGroup))
                        continue;

                    
                    if (inKey.Length == 0 || mainIdGroup.IndexOf(inKey, StringComparison.Ordinal) >= 0)
                        tablSearchEntryno.Add(entry);

                  
                    if (outKey.Length == 0 || mainIdGroup.IndexOf(outKey, StringComparison.Ordinal) < 0)
                        tablSearchEntrynoOut.Add(entry);
                }
 
                foreach (var entry in tablSearchEntryno.Intersect(tablSearchEntrynoOut, StringComparer.Ordinal))
                {
                    elist.Add(new TBLErrzoneInsideXMLRow
                    {
                        CsvID = csvId,
                        EntryNo = entry,
                        ErrorInsideID = rule.ID
                    });
                }
            }
             

            return Task.FromResult(elist);


        }

        public Task<List<TBLErrzoneInsideXMLRow>> ProcessStepIV(long csvId)
        {
            List<TBLErrzoneInsideXMLRow> elist = new List<TBLErrzoneInsideXMLRow>();


            var rules = _errorCheckSet.Where(r => r.QueryType == 4);
  
     

            foreach (var rule in rules)
            {
                
                var candidateEntries = _xMLSourceRow
                    .Where(x =>
                        (x.IsOpener == 0) &&
                        (x.IsPassedEntry == 0) &&
                        string.Equals(x.AccountMainID?.Trim(), rule.MainDescription?.Trim(), StringComparison.Ordinal) &&
                        string.Equals(x.DebitCreditCode?.Trim(), rule.DebitCreditCode?.Trim(), StringComparison.Ordinal))
                    .Select(x => x.EntryNumber!.Trim())
                    .Distinct(StringComparer.Ordinal)
                    .ToList();

                
                var likeKey = (rule.InMainDesc ?? string.Empty).Trim() + (rule.InMainDescDC ?? string.Empty).Trim();

                foreach (var entry in candidateEntries)
                {
                    if (!perEntryGroup.TryGetValue(entry, out var mainIdGroup))
                        continue;

                    if (likeKey.Length == 0 || mainIdGroup.IndexOf(likeKey, StringComparison.Ordinal) >= 0)
                    {
                        elist.Add(new TBLErrzoneInsideXMLRow
                        {
                            CsvID = csvId,
                            EntryNo = entry,
                            ErrorInsideID = rule.ID
                        });
                    }
                }
            }


            return Task.FromResult(elist);


        }

        public Task<List<TBLErrzoneInsideXMLRow>> ProcessStepV(long csvId)
        {
            List<TBLErrzoneInsideXMLRow> elist = new List<TBLErrzoneInsideXMLRow>();

            var rules = _errorCheckSet.Where(r => r.QueryType == 5);

            foreach (var rule in rules)
            {
                var matches = _xMLSourceRow
                    .Where(x => 
                        (x.IsOpener == 0) &&
                        (x.IsPassedEntry == 0) &&
                        string.Equals(x.AccountMainID?.Trim(), rule.MainDescription?.Trim(), StringComparison.Ordinal) &&
                        string.Equals(x.DebitCreditCode?.Trim(), rule.DebitCreditCode?.Trim(), StringComparison.Ordinal) &&
                        (x.Amount  ) > rule.CheckAmount &&
                        !string.IsNullOrWhiteSpace(x.EntryNumber))
                    .Select(x => x.EntryNumber!.Trim())
                    .Distinct(StringComparer.Ordinal);

                foreach (var en in matches)
                {
                    elist.Add(new TBLErrzoneInsideXMLRow
                    {
                        CsvID = csvId,
                        EntryNo = en,
                        ErrorInsideID = rule.ID
                    });
                }
            }





            return Task.FromResult(elist);


        }

        public Task<List<TBLErrzoneInsideXMLRow>> ProcessStepVI(long csvId)
        {
            List<TBLErrzoneInsideXMLRow> elist = new List<TBLErrzoneInsideXMLRow>();

            var rules = _errorCheckSet.Where(r => r.QueryType == 6);
             
            var wordsByInside = _errzoneWord
                .GroupBy(w => w.ErrorInsideID)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(w => (w.Description ?? string.Empty).Trim())
                          .Where(s => s.Length > 0)
                          .Distinct(StringComparer.OrdinalIgnoreCase)
                          .ToArray());

   
 
            foreach (var rule in rules)
            {
          
                if (!wordsByInside.TryGetValue(rule.ID, out var keywords) || keywords.Length == 0)
                    continue;

                var matches = _xMLSourceRow
                    .Where(x =>
                        string.Equals(x.AccountMainID?.Trim(), rule.MainDescription?.Trim(), StringComparison.Ordinal) &&
                        string.Equals(x.DebitCreditCode?.Trim(), rule.DebitCreditCode?.Trim(), StringComparison.Ordinal) &&
                        keywords.Any(k => x.DetailComment!.IndexOf(k, StringComparison.OrdinalIgnoreCase) >= 0))
                    .Select(x => x.EntryNumber!.Trim())
                    .Distinct(StringComparer.Ordinal);

                foreach (var en in matches)
                {
                    elist.Add(new TBLErrzoneInsideXMLRow
                    {
                        CsvID = csvId,
                        EntryNo = en,
                        ErrorInsideID = rule.ID
                    });
                }
            }



            return Task.FromResult(elist);


        }

        public Task<List<TBLErrzoneInsideXMLRow>> ProcessStepVII(long csvId)
        {
            List<TBLErrzoneInsideXMLRow> elist = new List<TBLErrzoneInsideXMLRow>();

            var rules = _errorCheckSet.Where(r => r.QueryType == 7);

          
  

            foreach (var rule in rules)
            {
                
                var candidateEntries = _xMLSourceRow
                    .Where(x =>
                        (x.IsOpener == 0) &&
                        (x.IsPassedEntry == 0) &&
                        string.Equals(x.AccountMainID?.Trim(), rule.MainDescription?.Trim(), StringComparison.Ordinal) &&
                        string.Equals(x.DebitCreditCode?.Trim(), rule.DebitCreditCode?.Trim(), StringComparison.Ordinal) &&
                        !string.IsNullOrEmpty(x.AccountSubDescription) &&
                        x.AccountSubDescription!.IndexOf("kasa noksan", StringComparison.OrdinalIgnoreCase) >= 0)
                    .Select(x => x.EntryNumber!.Trim())
                    .Distinct(StringComparer.Ordinal)
                    .ToList();
                 
                var has950_951 = new HashSet<string>(
                    perEntryGroup
                        .Where(kv => kv.Value.IndexOf("950,951", StringComparison.Ordinal) >= 0)
                        .Select(kv => kv.Key),
                    StringComparer.Ordinal);

                // Sonuç: candidateEntries \ has950_951
                foreach (var entry in candidateEntries.Where(e => !has950_951.Contains(e)))
                {
                    elist.Add(new TBLErrzoneInsideXMLRow
                    {
                        CsvID = csvId,
                        EntryNo = entry,
                        ErrorInsideID = rule.ID
                    });
                }
            }


            return Task.FromResult(elist);


        }

        public Task<List<TBLErrzoneInsideXMLRow>> ProcessStepVIII(long csvId)
        {
            List<TBLErrzoneInsideXMLRow> elist = new List<TBLErrzoneInsideXMLRow>();

            var rules = _errorCheckSet.Where(r => r.QueryType == 8);

        
            var keywords = _errzoneWord
                .Where(w => w.ErrorInsideID == 17)
                .Select(w => (w.Description ?? string.Empty).Trim())
                .Where(s => s.Length > 0)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            if (keywords.Length == 0)
                return Task.FromResult(elist);

        

            foreach (var rule in rules)
            {
         
                var matched = _xMLSourceRow
                    .Where(x =>
                        (x.IsOpener == 0) &&
                        (x.IsPassedEntry == 0) &&
                        string.Equals(x.AccountMainID?.Trim(), rule.MainDescription?.Trim(), StringComparison.Ordinal) &&
                        string.Equals(x.DebitCreditCode?.Trim(), rule.DebitCreditCode?.Trim(), StringComparison.Ordinal) &&
                        keywords.Any(k => x.AccountSubDescription!.IndexOf(k, StringComparison.OrdinalIgnoreCase) >= 0))
                    .Select(x => new { Entry = x.EntryNumber!.Trim(), Acc = (x.AccountMainID ?? string.Empty).Trim() })
                    .ToList();

              
                var tablSearch = matched
                    .GroupBy(x => x.Entry, StringComparer.Ordinal)
                    .ToDictionary(
                        g => g.Key,
                        g => string.Join(",",
                                g.Select(z => z.Acc)
                                 .Where(s => s.Length > 0)
                                 .Distinct(StringComparer.Ordinal)
                                 .OrderBy(s => s, StringComparer.Ordinal)),
                        StringComparer.Ordinal);

                var rowCountb = tablSearch.Count;
                if (rowCountb == 0) continue;

                
                var tablSearchEntryno = new HashSet<string>(
                    tablSearch.Where(kv =>
                            kv.Value.IndexOf("646", StringComparison.Ordinal) >= 0 ||
                            kv.Value.IndexOf("656", StringComparison.Ordinal) >= 0)
                              .Select(kv => kv.Key),
                    StringComparer.Ordinal);

                var rowCounta = tablSearchEntryno.Count;

         
                if (rowCounta < 1)
                {
                    var chosen = tablSearch.Keys.OrderBy(k => k, StringComparer.Ordinal).First();  
                    elist.Add(new TBLErrzoneInsideXMLRow
                    {
                        CsvID = csvId,
                        EntryNo = chosen,
                        ErrorInsideID = rule.ID
                    });
                }
            }
             
            return Task.FromResult(elist);


        }
        public Task<List<TBLErrzoneInsideXMLRow>> ProcessStepXV(long csvId)
        {
            List<TBLErrzoneInsideXMLRow> elist = new List<TBLErrzoneInsideXMLRow>();

            var rules = _errorCheckSet.Where(r => r.QueryType == 8);


            var keywords = _errzoneWord
                .Where(w => w.ErrorInsideID == 101)
                .Select(w => (w.Description ?? string.Empty).Trim())
                .Where(s => s.Length > 0)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            if (keywords.Length == 0)
                return Task.FromResult(elist);



            foreach (var rule in rules)
            {

                var matched = _xMLSourceRow
                    .Where(x =>
                        (x.IsOpener == 0) &&
                        (x.IsPassedEntry == 0) &&
                        string.Equals(x.AccountMainID?.Trim(), rule.MainDescription?.Trim(), StringComparison.Ordinal) &&
                        string.Equals(x.DebitCreditCode?.Trim(), rule.DebitCreditCode?.Trim(), StringComparison.Ordinal) &&
                        keywords.Any(k => x.AccountSubDescription!.IndexOf(k, StringComparison.OrdinalIgnoreCase) >= 0))
                    .Select(x => new { Entry = x.EntryNumber!.Trim(), Acc = (x.AccountMainID ?? string.Empty).Trim() })
                    .ToList();


                var tablSearch = matched
                    .GroupBy(x => x.Entry, StringComparer.Ordinal)
                    .ToDictionary(
                        g => g.Key,
                        g => string.Join(",",
                                g.Select(z => z.Acc)
                                 .Where(s => s.Length > 0)
                                 .Distinct(StringComparer.Ordinal)
                                 .OrderBy(s => s, StringComparer.Ordinal)),
                        StringComparer.Ordinal);

                var rowCountb = tablSearch.Count;
                if (rowCountb == 0) continue;


                var tablSearchEntryno = new HashSet<string>(
                    tablSearch.Where(kv =>
                            kv.Value.IndexOf("309", StringComparison.Ordinal) >= 0 ||
                            kv.Value.IndexOf("329", StringComparison.Ordinal) >= 0)
                              .Select(kv => kv.Key),
                    StringComparer.Ordinal);

                var rowCounta = tablSearchEntryno.Count;


                if (rowCounta < 1)
                {
                    var chosen = tablSearch.Keys.OrderBy(k => k, StringComparer.Ordinal).First();
                    elist.Add(new TBLErrzoneInsideXMLRow
                    {
                        CsvID = csvId,
                        EntryNo = chosen,
                        ErrorInsideID = rule.ID
                    });
                }
            }

            return Task.FromResult(elist);


        }

        public Task<List<TBLErrzoneInsideXMLRow>> ProcessStepX(long csvId)
        {
            List<TBLErrzoneInsideXMLRow> elist = new List<TBLErrzoneInsideXMLRow>();

            var rules = _errorCheckSet.Where(r => r.QueryType == 10);

             
            foreach (var rule in rules)
            {
                var matches = _xMLSourceRow
                    .Where(x =>
                        (x.IsOpener == 0) &&
                        (x.IsPassedEntry == 0) &&
                        string.Equals(x.AccountMainID?.Trim(), rule.MainDescription?.Trim(), StringComparison.Ordinal) &&
                        string.Equals(x.DebitCreditCode?.Trim(), rule.DebitCreditCode?.Trim(), StringComparison.Ordinal))
                    .Select(x => x.EntryNumber!.Trim())
                    .Distinct(StringComparer.Ordinal);

                foreach (var en in matches)
                {
                    elist.Add(new TBLErrzoneInsideXMLRow
                    {
                        CsvID = csvId,
                        EntryNo = en,
                        ErrorInsideID = rule.ID
                    });
                }
            }


            return Task.FromResult(elist);


        }

        public Task<List<TBLErrzoneInsideXMLRow>> ProcessStepXI(long csvId)
        {
            List<TBLErrzoneInsideXMLRow> elist = new List<TBLErrzoneInsideXMLRow>();

            var rules = _errorCheckSet.Where(r => r.QueryType == 11);

           

            foreach (var rule in rules)
            {
                var matches = _xMLSourceRow
                    .Where(x =>
                        (x.IsOpener == 0) &&
                        (x.IsPassedEntry == 0) &&
                        string.Equals(x.AccountMainID?.Trim(), rule.MainDescription?.Trim(), StringComparison.Ordinal) &&
                        string.Equals(x.DebitCreditCode?.Trim(), rule.DebitCreditCode?.Trim(), StringComparison.Ordinal))
                    .Select(x => x.EntryNumber!.Trim())
                    .Distinct(StringComparer.Ordinal);

                foreach (var en in matches)
                {
                    elist.Add(new TBLErrzoneInsideXMLRow
                    {
                        CsvID = csvId,
                        EntryNo = en,
                        ErrorInsideID = rule.ID
                    });
                }
            }


            return Task.FromResult(elist);


        }

        public Task<List<TBLErrzoneInsideXMLRow>> ProcessStepXII(long csvId)
        {
            List<TBLErrzoneInsideXMLRow> elist = new List<TBLErrzoneInsideXMLRow>();

            var rules = _errorCheckSet.Where(r => r.QueryType == 12);

 
            var keywords = _errzoneWord
                .Where(w => w.ErrorInsideID == 31)
                .Select(w => (w.Description ?? string.Empty).Trim())
                .Where(s => s.Length > 0)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            if (keywords.Length == 0)
                return Task.FromResult(elist);
 

            foreach (var rule in rules)
            {
                var matches = _xMLSourceRow
                    .Where(x =>
                        (x.IsOpener == 0) &&
                        (x.IsPassedEntry == 0) &&
                        string.Equals(x.AccountMainID?.Trim(), rule.MainDescription?.Trim(), StringComparison.Ordinal) &&
                        string.Equals(x.DebitCreditCode?.Trim(), rule.DebitCreditCode?.Trim(), StringComparison.Ordinal) &&
                        keywords.Any(k => x.AccountSubDescription!.IndexOf(k, StringComparison.OrdinalIgnoreCase) >= 0))
                    .Select(x => x.EntryNumber!.Trim())
                    .Distinct(StringComparer.Ordinal);

                foreach (var en in matches)
                {
                    elist.Add(new TBLErrzoneInsideXMLRow
                    {
                        CsvID = csvId,
                        EntryNo = en,
                        ErrorInsideID = rule.ID
                    });
                }
            }


            return Task.FromResult(elist);


        }

        public Task<List<TBLErrzoneInsideXMLRow>> ProcessStepXIII(long csvId)
        {
            List<TBLErrzoneInsideXMLRow> elist = new List<TBLErrzoneInsideXMLRow>();

            var rules = _errorCheckSet.Where(r => r.QueryType == 13);
             
            var innerEntrySet = new HashSet<string>(
                _xMLSourceRow
                    .Where(x =>
                        (x.IsOpener == 0) &&
                        (x.IsPassedEntry == 0) &&
                        string.Equals(x.AccountMainID?.Trim(), "300", StringComparison.Ordinal) &&
                        !string.IsNullOrEmpty(x.AccountSubDescription) &&
                        x.AccountSubDescription!.IndexOf("kredi kart", StringComparison.OrdinalIgnoreCase) >= 0)
                    .Select(x => x.EntryNumber!.Trim())
                    .Distinct(StringComparer.Ordinal),
                StringComparer.Ordinal);

     
            var matches = _xMLSourceRow
                .Where(x =>
                    innerEntrySet.Contains(x.EntryNumber!.Trim()) &&
                    !string.Equals(x.AccountMainID?.Trim(), "309", StringComparison.Ordinal) &&
                    !string.Equals(x.AccountMainID?.Trim(), "329", StringComparison.Ordinal))
                .Select(x => x.EntryNumber!.Trim())
                .Distinct(StringComparer.Ordinal);

            foreach (var en in matches)
            {
                elist.Add(new TBLErrzoneInsideXMLRow
                {
                    CsvID = csvId,
                    EntryNo = en,
                    ErrorInsideID = 33
                });
            }


            return Task.FromResult(elist);


        }

        public Task<List<TBLErrzoneInsideXMLRow>> ProcessStepXIV(long csvId)
        {
            List<TBLErrzoneInsideXMLRow> elist = new List<TBLErrzoneInsideXMLRow>();

            var rules = _errorCheckSet.Where(r => r.QueryType == 14);

            var innerEntrySet = new HashSet<string>(
         _xMLSourceRow
             .Where(x =>
                 (x.IsOpener == 0) &&
                 (x.IsPassedEntry == 0) &&
                 string.Equals(x.AccountMainID?.Trim(), "698", StringComparison.Ordinal))
             .Select(x => x.EntryNumber!.Trim())
             .Distinct(StringComparer.Ordinal),
         StringComparer.Ordinal);

     
            var matches = _xMLSourceRow
                .Where(x => innerEntrySet.Contains(x.EntryNumber!.Trim()))
                .Select(x => x.EntryNumber!.Trim())
                .Distinct(StringComparer.Ordinal);

            foreach (var en in matches)
            {
                elist.Add(new TBLErrzoneInsideXMLRow
                {
                    CsvID = csvId,
                    EntryNo = en,
                    ErrorInsideID = 34
                });
            }
            return Task.FromResult(elist);


        }

        public async Task<List<TBLErrzoneInsideXMLRow>> RunAllStepsAsync(long csvId)
        {
            var tasks = new Task<List<TBLErrzoneInsideXMLRow>>[]
            {
        ProcessStepI(csvId),
        ProcessStepII(csvId),
        ProcessStepIII(csvId),
        ProcessStepIV(csvId),
        ProcessStepV(csvId),
        ProcessStepVI(csvId),
        ProcessStepVII(csvId),
        ProcessStepVIII(csvId),
        ProcessStepX(csvId),
        ProcessStepXI(csvId),
        ProcessStepXII(csvId),
        ProcessStepXIII(csvId),
        ProcessStepXIV(csvId),
            };

            var results = await Task.WhenAll(tasks);

         
            var allyyy = results.SelectMany(x => x);
            var distinct = allyyy
    .DistinctBy(x => (x.CsvID, x.EntryNo, x.ErrorInsideID))
    .ToList();

            return distinct;
        }

       
        public async Task<List<TBLErrzoneInsideXMLRow>> RunAllAndPersistAsync(string connStr, long csvId)
        {
            var list = await RunAllStepsAsync(csvId);
            await BulkInsert_XmlCheckGroupMappingsAsync(connStr, list);
            return list ;
        }
        public async Task BulkInsert_XmlCheckGroupMappingsAsync(
    string connStr,
    IEnumerable<TBLErrzoneInsideXMLRow> data)
        {
            var dt = new DataTable(); 
            dt.Columns.Add("CsvID", typeof(int));
            dt.Columns.Add("EntryNo", typeof(string));  
            dt.Columns.Add("ErrorInsideID", typeof(int)); 

            foreach (var r in data)
            {
                var row = dt.NewRow();
                row["CsvID"] = r.CsvID;
                row["EntryNo"] =  r.EntryNo ;  
                row["ErrorInsideID"] = r.ErrorInsideID ; 
                dt.Rows.Add(row);
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "dbo.TBLErrzoneInsideXML";

                    bulkCopy.ColumnMappings.Add("CsvID", "CsvID");
                    bulkCopy.ColumnMappings.Add("EntryNo", "EntryNo");
                    bulkCopy.ColumnMappings.Add("ErrorInsideID", "ErrorInsideID"); 
                    bulkCopy.WriteToServer(dt);
                }
            }


        }
 
     
    }
}
