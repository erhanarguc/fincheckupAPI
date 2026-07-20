using fincheckup.ENTITY;
using fincheckup.Models.Hvvn;
using fincheckup.Models.NKolay.ENTITY;
using fincheckup.Models.ViewM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;

namespace fincheckup.Controllers
{

    [Route("JsonService/MainPost/[action]")]
    public class MainPostController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendEmailAska(MailAskingjJsonContact tmail)
        {


            //MailMessage mail = new MailMessage();
            //mail.From = new MailAddress("nefsolutioncontact@gmail.com", "Iletisim fincheckup");

            //mail.To.Add("iletisim@nefsolution.com");
            //mail.To.Add("erhan.arguc@gmail.com");
            //mail.Subject = " Bilgilendirme site üzerinden bir mesaj geldi- fincheckup.ai";
            //mail.IsBodyHtml = true;
            //mail.Body = tmail.emailsechome();


            //SmtpClient sc = new SmtpClient();
            //sc.Port = 587;
            //sc.EnableSsl = true;
            //sc.Host = "smtp.gmail.com";
            //sc.UseDefaultCredentials = false;
            //sc.Credentials = new NetworkCredential("nefsolutioncontact@gmail.com", "QWEasz321*");
            if (!ModelState.IsValid) return BadRequest("Validasyon hatası.");
            var mailNamecheck = tmail.mailto.Split('@').FirstOrDefault();
            if (LooksLikeGibberish(tmail.name) || LooksLikeGibberish(tmail.content)  )
                return BadRequest("Spam algılandı (anlamsız içerik).");

            var disposableDomains = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        { "mailinator.com","tempmail.com","guerrillamail.com","10minutemail.com" };
            var domain = tmail.mailto.Split('@').LastOrDefault();
            if (domain != null && disposableDomains.Contains(domain))
                return BadRequest("Lütfen kalıcı bir e-posta adresi kullanın.");

            using (SmtpClient client = new SmtpClient()
            {
                Host = "smtp.office365.com",
                Port = 587,
                UseDefaultCredentials = false, // This require to be before setting Credentials property
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("mailpost@fincheckup.net", "Xaw70079"), // you must give a full email address for authentication 
                TargetName = "STARTTLS/smtp.office365.com", // Set to avoid MustIssueStartTlsFirst exception
                EnableSsl = true // Set to avoid secure connection exception
            })
            {

                MailMessage message = new MailMessage()
                {
                    From = new MailAddress("mailpost@fincheckup.net"), // sender must be a full email address
                    Subject = " Bilgilendirme site üzerinden bir mesaj geldi- fincheckup.ai",
                    IsBodyHtml = true,
                    Body = tmail.emailsechome(),
                    BodyEncoding = System.Text.Encoding.UTF8,
                    SubjectEncoding = System.Text.Encoding.UTF8,

                };

                message.To.Add("erhan@nefsolution.com");
                message.To.Add("derya@nefsolution.com");
                message.To.Add("karen@nefsolution.com");
                message.To.Add("funda@nefsolution.com");
                message.To.Add("cigdem.oteyaka@nefsolution.com");
                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    var chk = ex;
                }


            }




            return Json("Email Sent Successfully!");
        }

        static bool LooksLikeGibberish(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return true;
            var letters = s.Count(char.IsLetter);
            var digits = s.Count(char.IsDigit);
            // Harf oranı çok düşükse ya da ÜSTÜSTE 6+ rastgele harf kümesi varsa şüpheli
            if (letters < 3 || (double)letters / Math.Max(1, s.Length) < 0.4) return true;
            // Sessiz harf kümeleri (Türkçe karakterler dahil)
            if (System.Text.RegularExpressions.Regex.IsMatch(s, @"[bcçdfgğhjklmnprsştvyzBCÇDFGĞHJKLMNPRSŞTVYZ]{6,}"))
                return true;
            return false;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendEmailAskainfomaster(MailAskingjJsonContactmaster tmail)
        {
             


            using (SmtpClient client = new SmtpClient()
            {
                Host = "smtp.office365.com",
                Port = 587,
                UseDefaultCredentials = false, // This require to be before setting Credentials property
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("mailpost@fincheckup.net", "Xaw70079"), // you must give a full email address for authentication 
                TargetName = "STARTTLS/smtp.office365.com", // Set to avoid MustIssueStartTlsFirst exception
                EnableSsl = true // Set to avoid secure connection exception
            })
            {

                MailMessage message = new MailMessage()
                {
                    From = new MailAddress("mailpost@fincheckup.net"), // sender must be a full email address
                    Subject = tmail.content,
                    IsBodyHtml = true,
                    Body = tmail.emailsechomeinfo(),
                    BodyEncoding = System.Text.Encoding.UTF8,
                    SubjectEncoding = System.Text.Encoding.UTF8,

                };

                message.To.Add("erhan@nefsolution.com");
                message.To.Add("derya@nefsolution.com");
                message.To.Add("funda@nefsolution.com");
                message.To.Add("karen@nefsolution.com");
                message.To.Add("cigdem.oteyaka@nefsolution.com");

                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    var chk = ex;
                }


            }


            return Json("Email Sent Successfully!");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendEmailAskainfomasterkobi(MailAskingjJsonContactmaster tmail)
        {



            using (SmtpClient client = new SmtpClient()
            {
                Host = "smtp.office365.com",
                Port = 587,
                UseDefaultCredentials = false, // This require to be before setting Credentials property
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("mailpost@fincheckup.net", "Xaw70079"), // you must give a full email address for authentication 
                TargetName = "STARTTLS/smtp.office365.com", // Set to avoid MustIssueStartTlsFirst exception
                EnableSsl = true // Set to avoid secure connection exception
            })
            {

                MailMessage message = new MailMessage()
                {
                    From = new MailAddress("mailpost@fincheckup.net"), // sender must be a full email address
                    Subject = tmail.content,
                    IsBodyHtml = true,
                    Body = tmail.emailsechomeinfomaster(),
                    BodyEncoding = System.Text.Encoding.UTF8,
                    SubjectEncoding = System.Text.Encoding.UTF8,

                };

                message.To.Add("erhan@nefsolution.com");
                message.To.Add("derya@nefsolution.com");
                message.To.Add("funda@nefsolution.com");
                message.To.Add("karen@nefsolution.com");
                message.To.Add("cigdem.oteyaka@nefsolution.com");

                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    var chk = ex;
                }


            }


            return Json("Email Sent Successfully!");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendEmailAskainfo(MailAskingjJsonContact tmail)
        {

            //try
            //{
            //    //MailMessage mail = new MailMessage();
            //    //mail.From = new MailAddress("nefsolutioncontact@gmail.com", "Teklif fincheckup");

            //    //mail.To.Add("iletisim@nefsolution.com"); mail.To.Add("erhan.arguc@gmail.com");
            //    //mail.Subject = " Bilgilendirme site üzerinden bir teklif talebi geldi";
            //    //mail.IsBodyHtml = true;
            //    //mail.Body = tmail.emailsechomeinfo();


            //    //SmtpClient sc = new SmtpClient();
            //    //sc.Port = 587;
            //    //sc.EnableSsl = true;
            //    //sc.Host = "smtp.gmail.com";
            //    //sc.UseDefaultCredentials = false;
            //    //sc.Credentials = new NetworkCredential("nefsolutioncontact@gmail.com", "QWEasz321*");

            //    //sc.Send(mail);
            //}
            //catch (Exception ex)
            //{
            //    var chk = ex;
            //    throw;
            //}

            if (!ModelState.IsValid) return BadRequest("Validasyon hatası.");
            var mailNamecheck = tmail.mailto.Split('@').FirstOrDefault();
            if (LooksLikeGibberish(tmail.name) || LooksLikeGibberish(tmail.content))
                return BadRequest("Spam algılandı (anlamsız içerik).");

            var disposableDomains = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        { "mailinator.com","tempmail.com","guerrillamail.com","10minutemail.com" };
            var domain = tmail.mailto.Split('@').LastOrDefault();
            if (domain != null && disposableDomains.Contains(domain))
                return BadRequest("Lütfen kalıcı bir e-posta adresi kullanın.");
            using (SmtpClient client = new SmtpClient()
            {
                Host = "smtp.office365.com",
                Port = 587,
                UseDefaultCredentials = false, // This require to be before setting Credentials property
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("mailpost@fincheckup.net", "Xaw70079"), // you must give a full email address for authentication 
                TargetName = "STARTTLS/smtp.office365.com", // Set to avoid MustIssueStartTlsFirst exception
                EnableSsl = true // Set to avoid secure connection exception
            })
            {

                MailMessage message = new MailMessage()
                {
                    From = new MailAddress("mailpost@fincheckup.net"), // sender must be a full email address
                    Subject = " Bilgilendirme site üzerinden bir teklif talebi geldi- fincheckup.ai",
                    IsBodyHtml = true,
                    Body = tmail.emailsechomeinfo(),
                    BodyEncoding = System.Text.Encoding.UTF8,
                    SubjectEncoding = System.Text.Encoding.UTF8,

                };

                message.To.Add("erhan@nefsolution.com");
                message.To.Add("derya@nefsolution.com");
                message.To.Add("funda@nefsolution.com");
                message.To.Add("karen@nefsolution.com");
                message.To.Add("cigdem.oteyaka@nefsolution.com");

                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    var chk = ex;
                }


            }


            return Json("Email Sent Successfully!");
        }
        public JsonResult FormSubmita(bulten model)
        {
            int ide = 0;
            if (ModelState.IsValid)
            {

                var currentUser = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (model.ID > 0)
                {
                    ide = model.ID;
                    model.Update_();
                }
                else
                {
                    var bulten_ = new bulten
                    {
                        Title = model.Title,
                        SubTitle = model.SubTitle,
                        Kapsam = model.Kapsam,
                        YururlulukTarih = model.YururlulukTarih,
                        DuzenleyenKurum = model.DuzenleyenKurum,
                        Description = model.Description,
                        CreatedUser = currentUser
                    };

                    bulten_.Save_();
                    ide = bulten_.ID;
                }


            }
            return Json(ide);
        }

        public JsonResult FormSubmitPass(HhvnUsersView model)
        {
            int ide = 0;
            if (ModelState.IsValid)
            {

                var currentUser = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (model.ID > 0)
                {
                    ide = model.ID;



                    var usr_ = HhvnUsers.GetRow_UserGuid(model.UserGuid);
                    if (usr_ != null && !String.IsNullOrEmpty(model.Password) && usr_.Password != PassWordHash.Encrypt(model.Password))
                    {
                        usr_.Password = PassWordHash.Encrypt(model.Password);
                        usr_.Update_Password();
                    }


                }
                else
                {

                }


            }
            return Json(ide);
        }
        public JsonResult FormSubmitError(DataViewerError model)
        {

            if (ModelState.IsValid)
            {
                var numxhwxk = model.MainDescription.Replace(" ", string.Empty);

                model.MainDescription = numxhwxk;

                MainDash.DataErrorSetter(model);



            }
            return Json("ok");
        }
        public JsonResult FormSubmitCheck(DataViewerCheck model)
        {

            if (ModelState.IsValid)
            {
                string numxhwxk = model.MainDescription.Replace(" ", string.Empty);
                if (numxhwxk.Length > 3)
                {
                    var nlist = numxhwxk.Split(',').Select(x => Convert.ToInt32(x));
                    var uniqueItems = nlist.Distinct().OrderBy(x => x);
                    var setchk = uniqueItems.Select(s => s.ToString()).ToList();
                    string currentdesc = string.Join(",", setchk);
                    model.MainDescription = currentdesc;
                    MainDash.DataCheckSetter(model);
                }



            }
            return Json("ok");
        }
        public JsonResult FormSubmitUser(HhvnUsers model)
        {
            long ide = 0;
            if (ModelState.IsValid)
            {

                var currentUser = Int64.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var isusrAdmn = HhvnUsers.GetRow_User(currentUser);
                if (model.ID > 0)
                {



                    var usr_ = HhvnUsers.GetRow_UserGuid(model.UserGuid.ToString());
                    if (usr_ != null && usr_.ID == model.ID || isusrAdmn.UserTypeID == 1001)
                    {
                        ide = model.ID;

                        if (isusrAdmn.UserTypeID != 1001)
                        {
                            model.UserTypeID = usr_.UserTypeID;
                        }

                        model.Update_User();
                        if (!String.IsNullOrEmpty(model.Password) && usr_.Password != PassWordHash.Encrypt(model.Password))
                        {
                            model.Password = PassWordHash.Encrypt(model.Password);
                            model.Update_Password();
                        }

                        UserCompany.Update_UserCompany(model.ID, model.CompanyList);
                    }

                }
                else
                {
                    if (isusrAdmn.UserTypeID == 1001)
                    {
                        var usr_ = new HhvnUsers
                        {
                            CityID = model.CityID,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Email = model.Email,
                            Phone = model.Phone,
                            Password = PassWordHash.Encrypt(model.Password),
                            IsActive = model.IsActive,
                            UserTypeID = model.UserTypeID
                        };

                        usr_.Save_User();
                        UserCompany.Update_UserCompany(usr_.ID, model.CompanyList);
                        ide = usr_.ID;
                    }


                }


            }
            return Json(ide);
        }
        public JsonResult FormSubmitCompany(Companies model)
        {
            long ide = 0;
            if (ModelState.IsValid)
            {

                var currentUser = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (model.ID > 0)
                {
                    ide = model.ID;
                    model.Update_Company();
                }
                else
                {
                    Companies compp = Companies.Get_CompanybyTax(model.TaxID);
                    if (compp != null) { return Json(-1); }
                    var cmp_ = new Companies
                    {
                        Adress = model.Adress,
                        CityID = model.CityID,
                        CompanyName = model.CompanyName,
                        ContactGSM = model.ContactGSM,
                        ContactMail = model.ContactMail,
                        TaxID = model.TaxID,
                        TaxOffice = model.TaxOffice,
                        Notes = model.Notes,
                        ContactName = model.ContactName,
                        NaceCode = model.NaceCode,
                        MainCompanyID = model.MainCompanyID,
                        XmlSourceID = model.XmlSourceID

                    };

                    cmp_.Save_Company();
                    ide = cmp_.ID;
                }


            }
            return Json(ide);
        }
        public JsonResult DeleteUser([FromBody] long postid)
        {
            string retvalue = "true";
            var pst = HhvnUsers.GetRow_User(postid);
            if (pst.IsDeleted)
            {
                pst.IsDeleted = false;
                pst.Update_User();

            }
            else
            {
                HhvnUsers.DeleteUser(postid);
            }


            return Json(retvalue);
        }



        public class Model
        {
            public IFormFile File { get; set; }
            public string Param { get; set; }
            public string Parama { get; set; }
        }
        public JsonResult UploadImage(Model postimg)
        {

            string SavePath = "true";
            if (postimg != null)
            {

                //Set Key Name
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(postimg.File.FileName);

                //Get url To Save
                SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", ImageName);

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    postimg.File.CopyTo(stream);
                }
            }


            return Json(SavePath);
        }
        public System.Drawing.Image DownloadImageFromUrl(string imageUrl)
        {
            System.Drawing.Image image = null;

            try
            {
                System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                System.Net.WebResponse webResponse = webRequest.GetResponse();

                System.IO.Stream stream = webResponse.GetResponseStream();

                image = System.Drawing.Image.FromStream(stream);

                webResponse.Close();
            }
            catch
            {
                return null;
            }

            return image;
        }

        [RequestSizeLimit(500000000)]
        public JsonResult UploadVideoMain(Model postimg)
        {

            //var pst = Posts.GetRow_Posts(postid);
            //if (pst.IsDeleted)
            //{
            //    pst.IsDeleted = false;
            //    pst.Update_Posts();

            //}
            //else
            //{
            //    Posts.DeletePosts(postid);
            //}
            string SavePath = "true";

            if (postimg != null)
            {

                //Set Key Name
                string ImageName = Guid.NewGuid().ToString() + ".jpg"; //Path.GetExtension(postimg.File.FileName);

                //Get url To Save
                SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", ImageName);


                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    postimg.File.CopyTo(stream);
                }
            }



            return Json(SavePath);
        }
    }
}