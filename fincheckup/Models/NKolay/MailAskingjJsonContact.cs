using System.ComponentModel.DataAnnotations;
using System.Text;

namespace fincheckup.Models.Hvvn
{
    public class MailAskingjJsonContact
    {
        [Required, EmailAddress, StringLength(120)]
        public string mailto { get; set; }
        [Required, StringLength(60, MinimumLength = 2)]
        [RegularExpression(@"^[\p{L}\s.'-]+$", ErrorMessage = "İsim sadece harf ve boşluk içerebilir.")]
        public string name { get; set; }
        public string education { get; set; }
        [Required, StringLength(20)]
        // +90, 0, boşluk ve tireleri kabul eden sade bir örnek
        [RegularExpression(@"^(\+?\d{1,3})?[\s-]?\d{3,5}[\s-]?\d{3,5}[\s-]?\d{2,5}$",
      ErrorMessage = "Telefon formatı hatalı.")]
        public string phone { get; set; }
        public string title { get; set; }
        [Required, StringLength(2000, MinimumLength = 10)]
        public string content { get; set; }
        public string Website { get; set; } = ""; 
        public string emailsechome()
        {

            StringBuilder sbr = new StringBuilder();

            sbr.AppendLine();
            sbr.AppendFormat("<br />Web Site Üzerinden Bir Mail Geldi ,<br /><br /><hr />");
            sbr.AppendLine();
            sbr.AppendFormat("İsim = {0} , <br /> ", this.name);
            sbr.AppendFormat("Telefon = {0} , <br /> ", this.phone);
            sbr.AppendFormat("E-posta = {0} , <br /> ", this.mailto);
            sbr.AppendFormat("Mesaj İçeriği = {0} , <br /> <br /> <hr />", this.content);
            sbr.AppendLine();
            sbr.AppendFormat("Güzel bir gün olsun <br />");

            return sbr.ToString();
        }
        public string emailsechomeinfo()
        {

            StringBuilder sbr = new StringBuilder();

            sbr.AppendLine();
            sbr.AppendFormat("<br />Web Site Üzerinden Bir  Teklif Talebi Mail Geldi ,<br /><br /><hr />");
            sbr.AppendLine();
            sbr.AppendFormat("İsim = {0} , <br /> ", this.name);
            sbr.AppendFormat("Şirket İsim = {0} , <br /> ", this.education);
            sbr.AppendFormat("Telefon = {0} , <br /> ", this.phone);
            sbr.AppendFormat("E-posta = {0} , <br /> ", this.mailto);
            sbr.AppendFormat("Mesaj İçeriği = {0} , <br /> <br /> <hr />", this.content);
            sbr.AppendLine();
            sbr.AppendFormat("Güzel bir gün olsun <br />");

            return sbr.ToString();
        }
    }

    public class MailAskingjJsonContactmaster
    {
        public string mailto { get; set; }
        public string name { get; set; }
        public string education { get; set; }
        public string phone { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string firmname { get; set; }
        public string firmowner { get; set; }
        public string firmvkn { get; set; }
        public string firmnace { get; set; }
        public string emailsechome()
        {

            StringBuilder sbr = new StringBuilder();

            sbr.AppendLine();
            sbr.AppendFormat("<br />Web Site Üzerinden Bir Mail Geldi ,<br /><br /><hr />");
            sbr.AppendLine();
            sbr.AppendFormat("İsim = {0} , <br /> ", this.name);
            sbr.AppendFormat("Telefon = {0} , <br /> ", this.phone);
            sbr.AppendFormat("E-posta = {0} , <br /> ", this.mailto);
            sbr.AppendFormat("Firma Adı = {0} , <br /> <br /> <hr />", this.firmname);
            sbr.AppendFormat("Firma Sahibi = {0} , <br /> ", this.firmowner);
            sbr.AppendFormat("Firma VKN = {0} , <br /> ", this.firmvkn);
            sbr.AppendFormat("Firma NACE = {0} , <br /> ", this.firmnace);
            sbr.AppendLine();
            sbr.AppendFormat("Güzel bir gün olsun <br />");

            return sbr.ToString();
        }
        public string emailsechomeinfomaster()
        {

            StringBuilder sbr = new StringBuilder();

            sbr.AppendLine();
            sbr.AppendFormat("<br /> Website üzerinden MASTERKOBI YILLIK kayıt Talebi Mail Geldi ,<br /><br /><hr />");
            sbr.AppendLine();
            sbr.AppendFormat("İsim = {0} , <br /> ", this.name);
            sbr.AppendFormat("Soyad = {0} , <br /> ", this.education);
            sbr.AppendFormat("Telefon = {0} , <br /> ", this.phone);
            sbr.AppendFormat("E-posta = {0} , <br /> ", this.mailto);
            sbr.AppendFormat("Firma Adı = {0} , <br /> <br /> <hr />", this.firmname);
            sbr.AppendFormat("Firma Sahibi = {0} , <br /> ", this.firmowner);
            sbr.AppendFormat("Firma VKN = {0} , <br /> ", this.firmvkn);
            sbr.AppendFormat("Firma NACE = {0} , <br /> ", this.firmnace);
            sbr.AppendLine();
            sbr.AppendFormat("Güzel bir gün olsun <br />");

            return sbr.ToString();
        }
        public string emailsechomeinfo()
        {

            StringBuilder sbr = new StringBuilder();

            sbr.AppendLine();
            sbr.AppendFormat("<br />Web Site Üzerinden MASTERKOBI kayıt Talebi Mail Geldi ,<br /><br /><hr />");
            sbr.AppendLine();
            sbr.AppendFormat("İsim = {0} , <br /> ", this.name);
            sbr.AppendFormat("Soyad = {0} , <br /> ", this.education);
            sbr.AppendFormat("Telefon = {0} , <br /> ", this.phone);
            sbr.AppendFormat("E-posta = {0} , <br /> ", this.mailto);
            sbr.AppendFormat("Firma Adı = {0} , <br /> <br /> <hr />", this.firmname);
            sbr.AppendFormat("Firma Sahibi = {0} , <br /> ", this.firmowner);
            sbr.AppendFormat("Firma VKN = {0} , <br /> ", this.firmvkn);
            sbr.AppendFormat("Firma NACE = {0} , <br /> ", this.firmnace);
            sbr.AppendLine();
            sbr.AppendFormat("Güzel bir gün olsun <br />");

            return sbr.ToString();
        }
    }
}
