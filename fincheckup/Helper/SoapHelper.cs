using System.IO;
using System.Net;
using System.Xml;

namespace fincheckup.Helper
{
    public static class SoapHelper
    {
        public static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
        public static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
        public static string CreatexmluserValidationByUserIdPasswordRequest(string kulanickodu, string pass, string vlkntckn)
        {
            string retval =
            "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ser=\"http://services.teminat.finansman.uut.cs.com.tr/\"> <soapenv:Header>  <wsse:Security soap:mustUnderstand=\"1\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:soap=\"soap\">  <wsse:UsernameToken> <wsse:Username>fincheckup.entegrasyon</wsse:Username> <wsse:Password>H6MjuGYu</wsse:Password>  </wsse:UsernameToken> </wsse:Security> </soapenv:Header> <soapenv:Body> <ser:userValidationByUserIdPassword>  <vknTckn>" + vlkntckn + "</vknTckn> <kulaniciKodu>" + kulanickodu + "</kulaniciKodu> <sifre>" + pass + "</sifre> </ser:userValidationByUserIdPassword> </soapenv:Body> </soapenv:Envelope>";
            return retval;


        }
        public static string CreatexmluserValidationByQnbUserIdRequest(string qnbuserId, string vlkntckn)
        {

            string retval =
           "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ser=\"http://services.teminat.finansman.uut.cs.com.tr/\" > <soapenv:Header>  <wsse:Security soap:mustUnderstand=\"1\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:soap=\"soap\" >  <wsse:UsernameToken> <wsse:Username>fincheckup.entegrasyon</wsse:Username> <wsse:Password>H6MjuGYu</wsse:Password>  </wsse:UsernameToken> </wsse:Security> </soapenv:Header> <soapenv:Body> <ser:userValidationByQnbUserId> <vknTckn>" + vlkntckn + "</vknTckn> <qnbUserId>" + qnbuserId + "</qnbUserId> </ser:userValidationByQnbUserId> </soapenv:Body> </soapenv:Envelope>";
            return retval;


        }
        public static string CreatexmldefterIzinSilRequest(string vlkntckn)
        {



            string retval =
           "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ser=\"http://services.teminat.finansman.uut.cs.com.tr/\" > <soapenv:Header>  <wsse:Security soap:mustUnderstand=\"1\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:soap=\"soap\" >  <wsse:UsernameToken> <wsse:Username>fincheckup.entegrasyon</wsse:Username> <wsse:Password>H6MjuGYu</wsse:Password>  </wsse:UsernameToken> </wsse:Security> </soapenv:Header> <soapenv:Body> <ser:defterIzinSil>  <vknTckn>" + vlkntckn + "</vknTckn> </ser:defterIzinSil> </soapenv:Body> </soapenv:Envelope>";
            return retval;


        }
        public static string CreatexmlIzinKaydetRequest(string vlkntckn, string hedefkaynak)
        {
            string retval =
        "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ser=\"http://services.teminat.finansman.uut.cs.com.tr/\" > <soapenv:Header>  <wsse:Security soap:mustUnderstand=\"1\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:soap=\"soap\" >  <wsse:UsernameToken> <wsse:Username>fincheckup.entegrasyon</wsse:Username> <wsse:Password>H6MjuGYu</wsse:Password>  </wsse:UsernameToken> </wsse:Security> </soapenv:Header> <soapenv:Body> <ser:defterIzinKaydet>  <vknTckn>" + vlkntckn + "</vknTckn>  <hedefKaynak>" + hedefkaynak + "</hedefKaynak> </ser:defterIzinKaydet> </soapenv:Body> </soapenv:Envelope>";
            return retval;
        }
    }
}
