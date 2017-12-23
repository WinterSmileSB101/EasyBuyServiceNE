using Newegg.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Services
{
    public class ModuleServiceBases<TRequest> : RestServiceBase<TRequest>
    {
        protected override void OnBeforeExecute(TRequest request)
        {
            RequestContext.HttpReq.ResponseContentType = "application/json";
            RequestContext.HttpRes.Response.Charset = "utf-8";
        }
    }
}
