using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lider.DPVAT.Administrativo.FaturamentoRCO.Helper.Models
{
    public class ErrorDetailsModels
    {
        public string Data { get; set; }
        public string System { get; set; }
        public string Application { get; set; }
        public string Version { get; set; }
        public string Host { get; set; }
        public string ErrorMensagem { get; set; }
        public string Error { get; set; }
        public string CurrentDirectory { get; set; }
        public string OSVersion { get; set; }
        public string UserDomainName { get; set; }
        public string UserName { get; set; }
        public string MethodName { get; set; }
        public string StackTrace { get; set; }
        public string WebUrl { get; set; }
        public string WebPage { get; set; }
        public string WebResponsePage { get; set; }
        public string WebStatusCode { get; set; }
        public string WebUsername { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
