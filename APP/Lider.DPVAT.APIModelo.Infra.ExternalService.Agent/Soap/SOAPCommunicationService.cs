using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Lider.DPVAT.APIGeracaoSinistro.Soap.Rest
{
    public class SOAPCommunicationService : ISOAPCommunicationService
    {
        /// <summary>
        /// Método para realizar uma comunicação via SOAP.
        /// </summary>
        /// <param name="urlSOAPWebRequest">Endereço do serviço SOAP.</param>
        /// <param name="actionSOAPWebRequest">A action, do serviço SOAP, que será executada.</param>
        /// <param name="xMLEnvio">XML de envio.</param>
        /// <returns>XML de retorno.</returns>
        public string GetSOAP(string urlSOAPWebRequest, string actionSOAPWebRequest, string xMLEnvio)
        {
            string soapResult;
            try
            {
                var _url = urlSOAPWebRequest;
                var _action = actionSOAPWebRequest;

                XmlDocument soapEnvelopeXml = CreateSoapEnvelope(xMLEnvio);
                HttpWebRequest webRequest = CreateWebRequest(_url, _action);
                InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

                IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

                asyncResult.AsyncWaitHandle.WaitOne();


                using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
                {
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                    }
                }

            }
            catch (Exception)
            {

                soapResult = string.Empty;
            }
            return soapResult;
        }

        private static XmlDocument CreateSoapEnvelope(string xMLEnvio)
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(xMLEnvio);
            return soapEnvelopeDocument;
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
