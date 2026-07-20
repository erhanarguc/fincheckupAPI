
using fincheckup.ENTITY;
using fincheckup.Helper;
using fincheckup.Models.Apinet;
using fincheckup.Models.Hvvn;
using fincheckup.Models.Qnb.soap;
using fincheckup.Models.ViewM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace fincheckup.Controllers
{

    [Route("JsonService/FinWsdl/[action]")]
    public class FinWsdlController : Controller
    {

        string xmlMessage = string.Empty;
        public string soapResult;
        public JsonResult ValidationByQnbUserIdRequest(FinansmanEntegrasyonCs sendPar)
        {

            try
            {


                var _url = "https://connector.efinans.com.tr:443/connector/ws/finansmanEntegrasyonWebService";
                var _action = "http://services.teminat.finansman.uut.cs.com.tr/FinansmanEntegrasyonWebService/userValidationByQnbUserIdRequest";

                xmlMessage = SoapHelper.CreatexmluserValidationByQnbUserIdRequest(sendPar.qnbUserId, sendPar.vknTckn);

                XmlDocument soapEnvelopeXml = new XmlDocument();
                soapEnvelopeXml.LoadXml(xmlMessage);
                HttpWebRequest webRequestz = SoapHelper.CreateWebRequest(_url, _action);
                SoapHelper.InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequestz);


                IAsyncResult asyncResult = webRequestz.BeginGetResponse(null, null);
                asyncResult.AsyncWaitHandle.WaitOne();
                using (WebResponse webResponse = webRequestz.EndGetResponse(asyncResult))
                {
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                    }
                }
                var chkkkk = soapResult;

                var serializer = new XmlSerializer(typeof(QnbSoapResponse.Envelope));
                QnbSoapResponse.Envelope result;
                using (var reader = new StringReader(chkkkk))
                {
                    result = (QnbSoapResponse.Envelope)serializer.Deserialize(reader);
                }

                if (result != null)
                {

                    return Json(result.Body.userValidationByQnbUserIdResponse.@return.responseCode + "_" + UppercaseWords(result.Body.userValidationByQnbUserIdResponse.@return.responseMessage));
                }

                var hh = result;


                return Json(chkkkk);




            }
            catch (Exception ex)
            {
                var chhhk = ex;
                return Json(chhhk);

            }

        }
        public JsonResult CreateByUserIdPasswordUyumsoft(FinansmanEntegrasyonCs sendPar)
        {

            try
            {
                long ide1 = 0;
                long comide1 = 0;

                try
                {

                    ide1 = Convert.ToInt64(sendPar.ide);



                    comide1 = Convert.ToInt64(sendPar.comide);
                }
                catch
                {


                }
                var usr = HhvnUsers.GetRow_User(ide1);
                var comi = Companies.Get_CompanyRow(comide1);
                ApiCompany comm = ApiCompany.CreateNew( comi, usr);

                ConnectApi ntake = new ConnectApi();
                var result = ntake.SavePermission(comm);
                var chkke = new TBLAAQnbSignLog(ide1, comide1, 4, DateTime.Now, DateTime.Now, DateTime.Now.AddYears(1), 0, null, null, 0, null, null, 1);
                //////////////chkke.Save_TBLAAQnbSignLog();
                var hh = result.Result;

                //return Json("ok");
                //return Json(result);

                return Json("ok");


            }
            catch (Exception ex)
            {
                var chhhk = ex;
                return Json(chhhk);

            }

        }
        public JsonResult ValidationByUserIdPasswordSovos(FinansmanEntegrasyonCs sendPar)
        {

            try
            {
                long ide1 = 0;
                long comide1 = 0;
                int connecttorId = 0;
                try
                {

                    ide1 = Convert.ToInt64(sendPar.ide);

                    connecttorId = Convert.ToInt32(sendPar.rowide);


                    comide1 = Convert.ToInt64(sendPar.comide);
                }
                catch
                {


                }


                var mSourceResultmain = SourceResult.getValue().Where(x=>x.MYear== connecttorId).FirstOrDefault();
                ConnectApi ntake = new ConnectApi();
                var usr = HhvnUsers.GetRow_User(ide1);
                var comi = Companies.Get_CompanyRow(comide1);
                ApiCompany comm = ApiCompany.CreateNew(comi, usr);
                comm.companyPortalUser = sendPar.kulaniciKodu;
                comm.companyPortalPassword = sendPar.password;
                comm.companyWebUser = sendPar.kulaniciKodu;
                comm.companyWebPassword = sendPar.password;
                // CompanyPortalUser = " + npar.kulaniciKodu + " & CompanyPortalPassword = " + npar.password
                var resultz = ntake.SavePermission(comm);
                var hhchk = resultz.Result;
                Thread.Sleep(500);

                var result = ntake.GetEledger(sendPar, mSourceResultmain.ShortText);
                var chkke = new TBLAAQnbSignLog(ide1, comide1, 4, DateTime.Now, DateTime.Now, DateTime.Now.AddYears(1), 0, null, null, 0, null, null, 1);
                chkke.Save_TBLAAQnbSignLog();
                var hh = result.Result;


                return Json(result.Result.message);




            }
            catch (Exception ex)
            {
                var chhhk = ex;
                return Json(chhhk);

            }

        }
        public JsonResult ValidationByUserIdPasswordUyumsoft(FinansmanEntegrasyonCs sendPar)
        {

            try
            {
                long ide1 = 0;
                long comide1 = 0;

                try
                {

                    ide1 = Convert.ToInt64(sendPar.ide);



                    comide1 = Convert.ToInt64(sendPar.comide);
                }
                catch
                {


                }
                ConnectApi ntake = new ConnectApi();
                var usr = HhvnUsers.GetRow_User(ide1);
                var comi = Companies.Get_CompanyRow(comide1);
                ApiCompany comm = ApiCompany.CreateNew(comi, usr);
                comm.companyPortalUser = sendPar.kulaniciKodu;
                comm.companyPortalPassword = sendPar.password;
                comm.companyWebUser = sendPar.kulaniciKodu;
                comm.companyWebPassword = sendPar.password;
                // CompanyPortalUser = " + npar.kulaniciKodu + " & CompanyPortalPassword = " + npar.password
                var resultz = ntake.SavePermission(comm);
                var hhchk = resultz.Result;
                Thread.Sleep(500);

                var result = ntake.GetEledger(sendPar,"us");
                var chkke = new TBLAAQnbSignLog(ide1, comide1, 4, DateTime.Now, DateTime.Now, DateTime.Now.AddYears(1), 0, null, null, 0, null, null, 1);
                chkke.Save_TBLAAQnbSignLog();
                var hh = result.Result;

           
                 return Json(result.Result.message);




            }
            catch (Exception ex)
            {
                var chhhk = ex;
                return Json(chhhk);

            }

        }
        public JsonResult ValidationByUserIdPasswordRequest(FinansmanEntegrasyonCs sendPar)
        {

            try
            {


                var _url = "https://connector.efinans.com.tr:443/connector/ws/finansmanEntegrasyonWebService";
                var _action = "http://services.teminat.finansman.uut.cs.com.tr/FinansmanEntegrasyonWebService/userValidationByUserIdPasswordRequest";

                xmlMessage = SoapHelper.CreatexmluserValidationByUserIdPasswordRequest(sendPar.kulaniciKodu, sendPar.password, sendPar.vknTckn);

                XmlDocument soapEnvelopeXml = new XmlDocument();
                soapEnvelopeXml.LoadXml(xmlMessage);
                HttpWebRequest webRequestz = SoapHelper.CreateWebRequest(_url, _action);
                SoapHelper.InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequestz);


                IAsyncResult asyncResult = webRequestz.BeginGetResponse(null, null);
                asyncResult.AsyncWaitHandle.WaitOne();
                using (WebResponse webResponse = webRequestz.EndGetResponse(asyncResult))
                {
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                    }
                }
                var chkkkk = soapResult;

                var serializer = new XmlSerializer(typeof(QnbSoapResponse1.Envelope));
                QnbSoapResponse1.Envelope result;
                using (var reader = new StringReader(chkkkk))
                {
                    result = (QnbSoapResponse1.Envelope)serializer.Deserialize(reader);
                }

                if (result != null)
                {

                    return Json(result.Body.userValidationByUserIdPasswordResponse.@return.responseCode + "_" + UppercaseWords(result.Body.userValidationByUserIdPasswordResponse.@return.responseMessage));
                }

                var hh = result;


                return Json(result);




            }
            catch (Exception ex)
            {
                var chhhk = ex;
                return Json(chhhk);

            }

        }

        public JsonResult ValidationdefterIzinSilRequest(FinansmanEntegrasyonCs sendPar)
        {

            try
            {
                TBLAAQnbSignLog chk= TBLAAQnbSignLog.Get_TBLAAQnbSignLogRow(Convert.ToInt64(sendPar.rowide));

                if (chk.CompanyEntegratorID == 3 || chk.CompanyEntegratorID == 4)
                {
                    long usride = Convert.ToInt64(sendPar.ide);
                    long compide = Convert.ToInt64(sendPar.comide);
                    long rwide = Convert.ToInt64(sendPar.rowide);


                    chk.IsDeclined = 1;
                    chk.DeclinedDate = DateTime.Now;
                    chk.DeclinedUserID = usride;
                    chk.Update_TBLAAQnbSignLog();
                    return Json("İzin İçin Verilen Kayıt Silindi");
                }
                else
                {
                    var _url = "https://connector.efinans.com.tr:443/connector/ws/finansmanEntegrasyonWebService";
                    var _action = "http://services.teminat.finansman.uut.cs.com.tr/FinansmanEntegrasyonWebService/defterIzinSilRequest";

                    xmlMessage = SoapHelper.CreatexmldefterIzinSilRequest(sendPar.vknTckn);

                    XmlDocument soapEnvelopeXml = new XmlDocument();
                    soapEnvelopeXml.LoadXml(xmlMessage);
                    HttpWebRequest webRequestz = SoapHelper.CreateWebRequest(_url, _action);
                    SoapHelper.InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequestz);


                    IAsyncResult asyncResult = webRequestz.BeginGetResponse(null, null);
                    asyncResult.AsyncWaitHandle.WaitOne();
                    using (WebResponse webResponse = webRequestz.EndGetResponse(asyncResult))
                    {
                        using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                        {
                            soapResult = rd.ReadToEnd();
                        }
                    }
                    var chkkkk = soapResult;

                    var serializer = new XmlSerializer(typeof(QnbSoapResponse3.Envelope));
                    QnbSoapResponse3.Envelope result;
                    using (var reader = new StringReader(chkkkk))
                    {
                        result = (QnbSoapResponse3.Envelope)serializer.Deserialize(reader);
                    }


                    var hh = result;
                    if (result != null)
                    {
                        long usride = Convert.ToInt64(sendPar.ide);
                        long compide = Convert.ToInt64(sendPar.comide);
                        long rwide = Convert.ToInt64(sendPar.rowide);

                       
                        chk.IsDeclined = 1;
                        chk.DeclinedDate = DateTime.Now;
                        chk.DeclinedUserID = usride;
                        chk.Update_TBLAAQnbSignLog();
                        return Json(UppercaseWords(result.Body.defterIzinSilResponse.@return.responseCode + "_" + result.Body.defterIzinSilResponse.@return.responseMessage));
                    }

                    return Json(chkkkk);
                }
           




            }
            catch (Exception ex)
            {
                var chhhk = ex;
                return Json(chhhk);

            }

        }
        public JsonResult ValidationdefterIzinSilBank(FinansmanEntegrasyonCs sendPar)
        {

            try
            {
                long usride = Convert.ToInt64(sendPar.ide);
                long compide = Convert.ToInt64(sendPar.comide);
                long rwide = Convert.ToInt64(sendPar.rowide);

                TBLAAQnbSignLog nlog = TBLAAQnbSignLog.Get_TBLAAQnbSignLogRow(rwide);
                nlog.DeclinedDateBank = DateTime.Now;
                nlog.IsDeclinedBank = 1;
                nlog.IsDeclined  = 1;
                nlog.DeclinedUserIDBank = usride;
                nlog.Update_TBLAAQnbSignLog();
                //var _url = "https://connectortest.efinans.com.tr:443/connector/ws/finansmanEntegrasyonWebService";
                //var _action = "http://services.teminat.finansman.uut.cs.com.tr/FinansmanEntegrasyonWebService/defterIzinSilRequest";

                //xmlMessage = SoapHelper.CreatexmldefterIzinSilRequest(sendPar.vknTckn);

                //XmlDocument soapEnvelopeXml = new XmlDocument();
                //soapEnvelopeXml.LoadXml(xmlMessage);
                //HttpWebRequest webRequestz = SoapHelper.CreateWebRequest(_url, _action);
                //SoapHelper.InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequestz);


                //IAsyncResult asyncResult = webRequestz.BeginGetResponse(null, null);
                //asyncResult.AsyncWaitHandle.WaitOne();
                //using (WebResponse webResponse = webRequestz.EndGetResponse(asyncResult))
                //{
                //    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                //    {
                //        soapResult = rd.ReadToEnd();
                //    }
                //}
                //var chkkkk = soapResult;

                //var serializer = new XmlSerializer(typeof(QnbSoapResponse3.Envelope));
                //QnbSoapResponse3.Envelope result;
                //using (var reader = new StringReader(chkkkk))
                //{
                //    result = (QnbSoapResponse3.Envelope)serializer.Deserialize(reader);
                //}


                //var hh = result;
                //if (result != null)
                //{

                //    return Json(UppercaseWords(result.Body.defterIzinSilResponse.@return.responseCode + "_" + result.Body.defterIzinSilResponse.@return.responseMessage));
                //}
                string chkkkk = "Ok";
                return Json(chkkkk);




            }
            catch (Exception ex)
            {
                var chhhk = ex;
                return Json(chhhk);

            }

        }
        public JsonResult ValidationdefterIzinKaydetRequest(FinansmanEntegrasyonCs sendPar)
        {

            try
            {
                long comide = Convert.ToInt64(sendPar.comide);
                long ide = Convert.ToInt64(sendPar.ide);

                var _url = "https://connector.efinans.com.tr:443/connector/ws/finansmanEntegrasyonWebService";
                var _action = "http://services.teminat.finansman.uut.cs.com.tr/FinansmanEntegrasyonWebService/defterIzinKaydetRequest";

                xmlMessage = SoapHelper.CreatexmlIzinKaydetRequest(sendPar.vknTckn, sendPar.hedefkaynak);

                XmlDocument soapEnvelopeXml = new XmlDocument();
                soapEnvelopeXml.LoadXml(xmlMessage);
                HttpWebRequest webRequestz = SoapHelper.CreateWebRequest(_url, _action);
                SoapHelper.InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequestz);


                IAsyncResult asyncResult = webRequestz.BeginGetResponse(null, null);
                asyncResult.AsyncWaitHandle.WaitOne();
                using (WebResponse webResponse = webRequestz.EndGetResponse(asyncResult))
                {
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                    }
                }
                var chkkkk = soapResult;
                QnbSoapResponse5.Envelope result;
                try
                {
                    var serializer = new XmlSerializer(typeof(QnbSoapResponse5.Envelope));

                    using (var reader = new StringReader(chkkkk))
                    {
                        result = (QnbSoapResponse5.Envelope)serializer.Deserialize(reader);
                    }


                    var hh = result;
                }
                catch
                {

                    return Json("nok");
                }

                var chkke = new TBLAAQnbSignLog(ide, comide, 1, DateTime.Now, DateTime.Now, DateTime.Now.AddYears(1), 0, null, null, 0, null, null, 1);
                chkke.Save_TBLAAQnbSignLog();

                if (result != null)
                {
                    return Json(UppercaseWords(result.Body.defterIzinKaydetResponse.@return.responseCode + "_" + result.Body.defterIzinKaydetResponse.@return.responseMessage));

                }

                return Json(chkkkk);




            }
            catch (Exception ex)
            {
                var chhhk = ex;
                return Json(chhhk);

            }

        }
        static string UppercaseWords(string value)
        {
            value = value.Replace(".", " ");
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }

    }

    public class FinansmanEntegrasyonCs
    {
        public string vknTckn { get; set; }

        public string qnbUserId { get; set; }
        public string password { get; set; }

        public string kulaniciKodu { get; set; }
        public string hedefkaynak { get; set; }
        public string ide { get; set; }
        public string comide { get; set; }
        public string rowide { get; set; }
    }
    public class MySerializer<T> where T : class
    {
        public static string Serialize(T obj)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
            using (var sww = new StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(sww) { Formatting = Formatting.Indented })
                {
                    xsSubmit.Serialize(writer, obj);
                    return sww.ToString();
                }
            }
        }
    }

}
