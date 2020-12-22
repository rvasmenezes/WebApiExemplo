using System;
using System.Collections.Generic;
using System.Text;

namespace Lider.DPVAT.APIGeracaoSinistro.Soap.Rest
{
    public interface ISOAPCommunicationService
    {
        /// <summary>
        /// Método para realizar uma comunicação via SOAP.
        /// </summary>
        /// <param name="urlSOAPWebRequest">Endereço do serviço SOAP.</param>
        /// <param name="actionSOAPWebRequest">A action, do serviço SOAP, que será executada.</param>
        /// <param name="xMLEnvio">XML de envio.</param>
        /// <returns>XML de retorno.</returns>
        string GetSOAP(string urlSOAPWebRequest, string actionSOAPWebRequest, string xMLEnvio);
    }
}
