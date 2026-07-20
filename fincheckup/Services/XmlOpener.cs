using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using fincheckup.ENTITY;
using fincheckup.Models.NKolay.ENTITY.NwEntity;

namespace fincheckup.Services
{
    public sealed class XmlOpener
    {
        private List<Dataz> _xMLSourceRow;
        private int _month; 
        public XmlOpener(List<Dataz> xMLSourceRow, int month )
        {
            _xMLSourceRow = xMLSourceRow;
            _month = month; 
        }

        public async Task<List<Dataz>> ProcessXmlGroup()
        {
      
            var tr = new CultureInfo("tr-TR");
            var cmp = tr.CompareInfo;

       
            if (_month == 1)
            {
                var keywords = new[] { "açılış", "acilis", "acls", "açls"};
       
                foreach (var r in _xMLSourceRow.Where(x => !string.IsNullOrWhiteSpace(x.DetailComment)
&& keywords.Any(k =>
                cmp.IndexOf(x.DetailComment!, k, CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) >= 0)))
                {
                    r.IsOpener = 1;
                }

            }
            else if (_month ==  12 )
            {
                var xmlCheckGroups = _xMLSourceRow
     .GroupBy(x => new { x.EntryNumber, x.TotalCredit, x.CsvID })
     .Select(g => new XmlCheckGroupRow
     {
         EntryNumber = g.Key.EntryNumber,
         TotalCredit = g.Key.TotalCredit,
         CsvID = g.Key.CsvID,
         AccountMainIDList = string.Join(",",
             g.Select(s => s.AccountMainID)
              .Where(id => !string.IsNullOrWhiteSpace(id))
              .Select(id => id.Trim())
              .Distinct(StringComparer.Ordinal)
              .OrderBy(id => id, StringComparer.Ordinal)
         ) 
     })
     .ToList();
                var keywordskap = new[] { "Kapanış", "KAPANIŞ", "kapanış", "Mali Yılın devri", "KAPANIŞ", "KAPATIL", "KPNS", "kapanış", "KPNŞ", "Kpns", "kapanis", "KAPANİS", "Kapaniş" };
                var keywordskapnon = new[] { "BAKİYE KAPANIŞI", "BAKIYE KAPANIS" };
  
                foreach (var r in _xMLSourceRow.Where(x => !string.IsNullOrWhiteSpace(x.DetailComment)
   && (keywordskap.Any(k =>
                   cmp.IndexOf(x.DetailComment!, k, CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) >= 0)) || (keywordskap.Any(k =>
                   cmp.IndexOf(x.EntryComment!, k, CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) >= 0))))
                {
                    r.IsPassedEntry = 1;
                }


                foreach (var r in _xMLSourceRow.Where(x => !string.IsNullOrWhiteSpace(x.DetailComment)
 && keywordskapnon.Any(k =>
                 cmp.IndexOf(x.DetailComment!, k, CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) >= 0)))
                {
                    r.IsPassedEntry = 0;
                }
              


                var groups = xmlCheckGroups
       .Where(g =>  !string.IsNullOrWhiteSpace(g.EntryNumber))
       .Select(g => new
       {
           Entry = g.EntryNumber!.Trim(),
           List = (g.AccountMainIDList ?? string.Empty).Trim()
       })
       .ToList();

              
                static bool Eq(string s, string target) =>
                    string.Equals(s, target, StringComparison.Ordinal);

                static bool EndsWithToken(string s, string suffix) =>
                    s.EndsWith(suffix, StringComparison.Ordinal);

                static bool ContainsToken(string s, string token) =>
                    s.IndexOf(token, StringComparison.Ordinal) >= 0;

                var exactPairs = new HashSet<string>(new[]
                {
        "710,711","720,721","730,731","740,741","750,751","760,761","770,771","780,781"
    }, StringComparer.Ordinal);

                
                var entriesToMark = new HashSet<string>(StringComparer.Ordinal);

                foreach (var g in groups)
                {
                    var L = g.List;

                    if (Eq(L, "690,691,692") ||
                        Eq(L, "690,691") ||
                        EndsWithToken(L, ",690,692") ||
                        (EndsWithToken(L, ",690,691") && ContainsToken(L, "600,")) ||
                        EndsWithToken(L, ",690") ||
                        exactPairs.Contains(L))
                    {
                        entriesToMark.Add(g.Entry);
                    }
                }

                if (entriesToMark.Count != 0)
                { 
               
                foreach (var r in _xMLSourceRow.Where(x =>  !string.IsNullOrWhiteSpace(x.EntryNumber) &&
                         entriesToMark.Contains(x.EntryNumber!.Trim())))
                {
                    r.IsPassedEntry = 1;  
                }
                }
            }


            foreach (var r in _xMLSourceRow.Where(x => !string.IsNullOrEmpty(x.AccountMainID)
                           && (x.AccountMainID!.StartsWith("9", StringComparison.Ordinal)
                            || x.AccountMainID!.StartsWith("8", StringComparison.Ordinal))))
            {
                r.IsPassedEntry = 1;
            }

        


            return _xMLSourceRow;

        }
   }
}
