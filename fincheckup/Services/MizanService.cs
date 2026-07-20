using fincheckup.Models;
using fincheckup.Models.ViewM;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace fincheckup.Services
{
    public class MizanService
    {
        // Tüm TBLXMLSourceOne verilerinin yüklü olduğu liste
        private List<SourceOneT> _data;

        public MizanService(List<SourceOneT> data)
        {
            _data = data;
        }

        public List<SourceOneT> CalculatePlus()
        {
            var accountMainIdsA = new[] { "120", "133", "136", "127", "131", "159", "231", "181", "281", "132", "195", "232", "220", "236", "259" };
            var list = _data.Where(x => accountMainIdsA.Contains(x.AccountMainID)).ToList();
            var firstdotCount = GetDotSayisi(list);
            var lastdotCount = GetDotSayisiAll(list);

            var filteredSourceData = list
    .Where(item =>
    {
        // AccountMainID için DotSay değeri var mı?
        var matchedDot = firstdotCount
            .FirstOrDefault(d => d.AccountMainID == item.AccountMainID);

        // Yoksa filtreleme dışında bırak
        if (matchedDot == null || string.IsNullOrEmpty(item.AccountSubID))
            return false;

        // Dot sayısı eşleşiyorsa dahil et
        var itemDotCount = item.AccountSubID.Count(c => c == '.');
        return itemDotCount == matchedDot.DotSay;
    })
    .ToList();


            var accountsbublist = filteredSourceData.Select(x => x.AccountSubID);
            var filteredSourceData1 = list
  .Where(item =>
  {
      // AccountMainID için DotSay değeri var mı?
      var matchedDot = lastdotCount
          .FirstOrDefault(d => d.AccountMainID == item.AccountMainID);

      // Yoksa filtreleme dışında bırak
      if (matchedDot == null || string.IsNullOrEmpty(item.AccountSubID))
          return false;

      // Dot sayısı eşleşiyorsa dahil et
      var itemDotCount = item.AccountSubID.Count(c => c == '.');
      return itemDotCount == matchedDot.DotSay;
  })
  .ToList();

            filteredSourceData1 = filteredSourceData1.Where(x => !accountsbublist.Contains(x.AccountSubID)).ToList();
            filteredSourceData.AddRange(filteredSourceData1);




            foreach (var item in filteredSourceData)
            {
                item.AccountSubID = NormalizeTextSubid(item.AccountSubID);
                item.AccountSubDescription = NormalizeText(item.AccountSubDescription);
            }

            foreach (var check in filteredSourceData)
            {
                if (!string.IsNullOrWhiteSpace(check.AccountSubMain))
                {
                    check.AccountSubDescription = check.AccountSubDescription?
                        .Replace(check.AccountSubMain, "", StringComparison.OrdinalIgnoreCase).Trim();
                }

                var parts = check.AccountSubDescription?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts?.Length >= 2)
                    check.AccountSubMain = $"{parts[0]} {parts[1]}";
                else
                    check.AccountSubMain = check.AccountSubDescription;
            }

            return filteredSourceData;




        }
        public List<SourceOneT> CalculateMinus()
        {

            var accountMainIdsA = new[] { "320", "329", "333", "331", "336", "340", "381", "431", "481", "339", "440", "439", "436", "420", "429" };


            var list = _data.Where(x => accountMainIdsA.Contains(x.AccountMainID)).ToList();
            var firstdotCount = GetDotSayisi(list);
            var lastdotCount = GetDotSayisiAll(list);

            var filteredSourceData = list
.Where(item =>
{
    // AccountMainID için DotSay değeri var mı?
    var matchedDot = firstdotCount
        .FirstOrDefault(d => d.AccountMainID == item.AccountMainID);

    // Yoksa filtreleme dışında bırak
    if (matchedDot == null || string.IsNullOrEmpty(item.AccountSubID))
        return false;

    // Dot sayısı eşleşiyorsa dahil et
    var itemDotCount = item.AccountSubID.Count(c => c == '.');
    return itemDotCount == matchedDot.DotSay;
})
.ToList();

            var accountsbublist = filteredSourceData.Select(x => x.AccountSubID);
            var filteredSourceData1 = list
  .Where(item =>
  {
      // AccountMainID için DotSay değeri var mı?
      var matchedDot = lastdotCount
          .FirstOrDefault(d => d.AccountMainID == item.AccountMainID);

      // Yoksa filtreleme dışında bırak
      if (matchedDot == null || string.IsNullOrEmpty(item.AccountSubID))
          return false;

      // Dot sayısı eşleşiyorsa dahil et
      var itemDotCount = item.AccountSubID.Count(c => c == '.');
      return itemDotCount == matchedDot.DotSay;
  })
  .ToList();

            filteredSourceData1 = filteredSourceData1.Where(x => !accountsbublist.Contains(x.AccountSubID)).ToList();
            filteredSourceData.AddRange(filteredSourceData1);


            foreach (var item in filteredSourceData)
            {
                item.AccountSubID = NormalizeTextSubid(item.AccountSubID);
                item.AccountSubDescription = NormalizeText(item.AccountSubDescription);
            }

            foreach (var check in filteredSourceData)
            {
                if (!string.IsNullOrWhiteSpace(check.AccountSubMain))
                {
                    check.AccountSubDescription = check.AccountSubDescription?
                        .Replace(check.AccountSubMain, "", StringComparison.OrdinalIgnoreCase).Trim();
                }

                var parts = check.AccountSubDescription?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts?.Length >= 2)
                    check.AccountSubMain = $"{parts[0]} {parts[1]}";
                else
                    check.AccountSubMain = check.AccountSubDescription;
            }


            return filteredSourceData;


        }
        private List<AcountWithDotCount> GetDotSayisi(List<SourceOneT> sourceData)
        {
            List<AcountWithDotCount> dotSayList = sourceData
     .Where(x =>
         !string.IsNullOrEmpty(x.AccountSubDescription) &&
         (x.AccountSubDescription.ToLower().Contains("aş.") ||
             x.AccountSubDescription.ToLower().Contains("a.ş.") ||
             x.AccountSubDescription.ToLower().Contains("anonim") ||
             x.AccountSubDescription.ToLower().Contains("ltd") ||
             x.AccountSubDescription.ToLower().Contains("limited") ||
             x.AccountSubDescription.ToLower().Contains("şti.")
         )
     )
     .GroupBy(x => new
     {
         x.AccountMainID,
         DotCount = x.AccountSubID.Count(c => c == '.')
     })
     .Select(g => new
     {
         g.Key.AccountMainID,
         DotSay = g.Key.DotCount,
         Toplam = g.Sum(x => Math.Abs(x.AmountBakiye ?? 0))
     })
     .GroupBy(x => x.AccountMainID)
     .Select(g => g
         .OrderByDescending(x => x.Toplam)
         .Select(x => new AcountWithDotCount
         {
             AccountMainID = x.AccountMainID,
             DotSay = x.DotSay
         })
         .First()
     )
     .ToList();
            return dotSayList;
        }
        private List<AcountWithDotCount> GetDotSayisiAll(List<SourceOneT> sourceData)
        {
            List<AcountWithDotCount> dotSayList = sourceData
     .GroupBy(x => new
     {
         x.AccountMainID,
         DotCount = x.AccountSubID.Count(c => c == '.')
     })
     .Select(g => new
     {
         g.Key.AccountMainID,
         DotSay = g.Key.DotCount
     })
     .GroupBy(x => x.AccountMainID)
     .Select(g => g
         .OrderByDescending(x => x.DotSay)
         .Select(x => new AcountWithDotCount
         {
             AccountMainID = x.AccountMainID,
             DotSay = x.DotSay
         })
         .First()
     )
     .ToList();
            return dotSayList;
        }
        public static string NormalizeText(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // Küçültülmüş metinle kelime eşleşmesi için normalize et
            var wordsToRemove = new[] { "BANKA", "ÇEK", "KREDİ", "CEK", "KREDI" };

            // Kelimeleri boşluklarla ayırarak sil (case-insensitive)
            string cleaned = input.ToUpper();

            foreach (var word in wordsToRemove)
            {
                cleaned = Regex.Replace(cleaned, $@"\b{word}\b", "", RegexOptions.IgnoreCase);
            }

            // Baş-son boşlukları sil, çift boşlukları teke indir
            cleaned = Regex.Replace(cleaned.Trim(), @"\s{2,}", " ");
            cleaned = cleaned.Replace("İ", "I").Replace("Ğ", "G").Replace("Ş", "S").Replace("Ö", "O").Replace("Ç", "C").Replace("Ü", "U");

            return cleaned;
        }
        public static string NormalizeTextSubid(string input)
        {
            return string.IsNullOrWhiteSpace(input)
        ? input
        : Regex.Replace(input.Trim(), @"\s{2,}", " ");
        }

        public async Task BulkInsertSourceOneTAsync(List<SourceOneT> dataList)
        {
            //       [AccountMainID][nvarchar](250) NULL,
            //[AccountSubID][nvarchar](450) NULL,
            //[AccountSubDescription][nvarchar](450) NULL,
            //[CompanyID][bigint] NULL,
            //[Year][int] NULL,
            //[AccountSubMain][nvarchar](450) NULL,
            //[DebitCreditCode][nvarchar](1) NULL,
            //[Amount][bigint] NULL,
            //[ConsolidatedCompanyID][bigint] NOT NULL,

            //   [ConsolidatedSubID] [nvarchar] (450) NULL

            using (var dataTable = new DataTable())
            {
                dataTable.Columns.Add("AccountSubMain", typeof(string));
                dataTable.Columns.Add("AccountMainID", typeof(string));
                dataTable.Columns.Add("AccountSubID", typeof(string));
                dataTable.Columns.Add("AccountSubDescription", typeof(string));
                dataTable.Columns.Add("CompanyID", typeof(long));
                dataTable.Columns.Add("Year", typeof(int));
                dataTable.Columns.Add("Amount", typeof(long));
                dataTable.Columns.Add("DebitCreditCode", typeof(string));

                // Verileri doldur
                foreach (var item in dataList)
                {
                    dataTable.Rows.Add(
                        item.AccountSubMain,
                        item.AccountMainID,
                        item.AccountSubID,
                        item.AccountSubDescription,
                        item.CompanyID,
                        item.Year,
                        item.AmountBakiye ?? (object)DBNull.Value,
                        item.DebitCreditCode
                    );
                }

                using (var sqlConnection = new SqlConnection(Database.ConnectionString))
                {
                    await sqlConnection.OpenAsync();

                    using (var bulkCopy = new SqlBulkCopy(sqlConnection))
                    {
                        bulkCopy.DestinationTableName = "CustomerCheck"; // Hedef tablo adını buraya yaz

                        bulkCopy.ColumnMappings.Add("AccountSubMain", "AccountSubMain");
                        bulkCopy.ColumnMappings.Add("AccountMainID", "AccountMainID");
                        bulkCopy.ColumnMappings.Add("AccountSubID", "AccountSubID");
                        bulkCopy.ColumnMappings.Add("AccountSubDescription", "AccountSubDescription");
                        bulkCopy.ColumnMappings.Add("CompanyID", "CompanyID");
                        bulkCopy.ColumnMappings.Add("Year", "Year");
                        bulkCopy.ColumnMappings.Add("Amount", "Amount");
                        bulkCopy.ColumnMappings.Add("DebitCreditCode", "DebitCreditCode");

                        await bulkCopy.WriteToServerAsync(dataTable);
                    }
                }
            }
        }
    }
    public class AcountWithDotCount()
    {

        public int DotSay { get; set; }
        public string AccountMainID { get; set; }
    }
}
