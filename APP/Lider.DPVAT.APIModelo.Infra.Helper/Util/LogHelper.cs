using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Lider.DPVAT.Administrativo.FaturamentoRCO.Application.Util
{
    public class LogHelper
    {
        public void SetWebLogInfo(HttpContext httpContext)
        {
            httpContext.Items["ErrorStatusCode"] = httpContext.Response.StatusCode.ToString();
            httpContext.Items["ErrorRequestPath"] = httpContext.Request.Path.ToString();
            httpContext.Items["ErrorStatusDescription"] = ((HttpStatusCode)httpContext.Response.StatusCode).ToString();
            httpContext.Items["ErrorStatusDescription"] = ((HttpStatusCode)httpContext.Response.StatusCode).ToString();
        }
    }
}
