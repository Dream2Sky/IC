using IC.CloudLink.Services;
using IC.CloudLink.Services.Contracts;
using IC.CloudLink.WebApi.Controllers;
using IC.Core.Entity;
using IC.Core.Entity.Http;
using IC.Core.Utility.Extensions;
using IC.Core.Utility.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IC.CloudLink.WebApi.Filters
{
    public class ChkOpenIdFilter : BaseFilter, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(!IsFilter)
            {
                return;
            }
            var isInvalid = false;
            var arg = context.ActionArguments["OpenId"];
            if (arg == null)
            {
                isInvalid = true;
            }
            else{
                var argOpenId = Convert.ToString(arg);
                var openId = context.HttpContext.Session.GetString("OpenId");
            
                if (openId != argOpenId)
                {
                    isInvalid = true;
                }
            }
            if(isInvalid)
            {
                var resultContainer = GetFilterContextResult(Core.Entity.Enum.HTTP_SUCCESS.FAIL, IC.Core.Entity.Enum.HTTP_STATUS_CODE.INVALIDOPENID);
                context.Result = resultContainer;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
