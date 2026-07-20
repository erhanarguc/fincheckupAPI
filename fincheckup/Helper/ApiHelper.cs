using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace fincheckup.Helper
{
    public static class ApiHelper
    {
        static Dictionary<string, string> dict = new Dictionary<string, string>
{
    { "1026", "Yüklemiş olduğunuz e-defter  bulunamadı." },
    { "1027", "Toplamda bulunan dosya adediniz (xx) olarak bulunmuştur."},
    { "1200", "Verilerinizin aktarımı başarılı bir şekilde tamamlanmıştır."},
    { "1201", "Veri yükleme talebiniz sonuçlanamamıştır."},
    { "1028", "Sisteme (xx) tarihinde yüklemiş olduğunuz dosyalar bulunmuştur."},
    { "1029", "Göndermiş olduğunuz dosyalar bulunamamıştır."},
    { "1030", "Verilerinizin aktarımı için vermiş olduğunuz izin başarılı bir şekilde kaydedilmiştir."},
    {"1032", "Daha önce verilmiş  izin kaydınız bulunmaktadır"},
    { "1031", "Vermiş olduğunuz izinler sisteme kaydedilememiştir."}
};
        public static string ConvertFileToBase64(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            try
            {
                // Read the file's bytes
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

                // Convert to Base64 string and return
                return Convert.ToBase64String(fileBytes);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw new FileNotFoundException($"File not found at the path: {filePath}", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException($"Access to the file is denied: {filePath}", ex);
            }
            catch (Exception ex)
            {
                // Catch all other exceptions
                throw new Exception($"An error occurred while converting the file to Base64: {ex.Message}", ex);
            }
        }
        public static string ToMessage(string message)
        {
            List<string> errlist = new List<string>() { "1026", "1201", "1029", "1031" };
            string chk = "ok_";

            string sKeyResult = dict.Keys.FirstOrDefault<string>(s => message.Contains(s));

            if (errlist.Any(s => message.Contains(s)))
            {
                chk = "nok_";
            }

            if (string.IsNullOrEmpty(sKeyResult))
            {

                return message;
            }

            return chk + dict[sKeyResult];
        }

        public static string ToUrl(this Object instance, string requestUri)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(requestUri + "?");
            var properties = instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            for (int i = 0; i < properties.Length; i++)
            {
                urlBuilder.AppendFormat("{0}={1}&", properties[i].Name, properties[i].GetValue(instance, null));
            }
            if (urlBuilder.Length > 1)
            {
                urlBuilder.Remove(urlBuilder.Length - 1, 1);
            }
            return urlBuilder.ToString();
        }

    }
}
