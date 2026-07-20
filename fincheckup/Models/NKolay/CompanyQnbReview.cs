using CsvHelper;
using CsvHelper.Configuration;
using fincheckup.Models.Hvvn;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace fincheckup.Models.NKolay
{
    public class CompanyQnbReview
    {
        public string qnbCorporateId { get; set; }
        public string productionCode { get; set; }
        public string applicationId { get; set; }
        public string CreatedDate { get; set; }
        public string PerFormStutue { get; set; }
        public string ModeStutue { get; set; }
        public string AccountDate { get; set; }
        public string ActivateDate { get; set; }
        public string IsPriced { get; set; }

        public static CompanyQnbReview getReview(DateTime creatitonDate, string qnbCorporateId_, string applicationId_)
        {
            CompanyQnbReview nn = new CompanyQnbReview();
            nn.qnbCorporateId = qnbCorporateId_;
            nn.productionCode = "FINCHECKUP";
            nn.applicationId = applicationId_;
            nn.CreatedDate = creatitonDate.ToString("yyyyMMdd");
            nn.PerFormStutue = "1";
            nn.ModeStutue = "1";
            nn.AccountDate = creatitonDate.ToString("yyyyMMdd");
            nn.ActivateDate = creatitonDate.ToString("yyyyMMdd");
            nn.IsPriced = "0";
            return nn;
        }
        public string GetValues(List<CompanyQnbReview> nlist)
        {

            string nname = System.Guid.NewGuid().ToString("D") + ".csv";
            var FileDicz = "/FileContent/" + nname;
            var FileDic = "wwwroot\\FileContent\\" + nname;

            //
            string filePathZ = WebHelper.path;
            string FilePath = System.IO.Path.Combine(filePathZ, FileDic);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", HasHeaderRecord = false };
            using (var writer = new StreamWriter(FilePath, append: true))
            {
                using (var csv = new CsvWriter(writer, config))
                {
                    csv.WriteRecords(nlist);
                }
            }


            //using (var mem = new MemoryStream())
            //using (var writerz = new StreamWriter(mem))
            //using (var csvWriter = new CsvWriter(writerz))
            //{
            //    csvWriter.Configuration.Delimiter = ";";
            //    csvWriter.Configuration.HasHeaderRecord = true;
            //    csvWriter.Configuration.AutoMap<Project>();

            //    csvWriter.WriteHeader<Project>();
            //    csvWriter.WriteRecords(data);

            //    writer.Flush();
            //    var result = Encoding.UTF8.GetString(mem.ToArray());
            //    Console.WriteLine(result);
            //}

            return FileDicz;
        }
    }
}
