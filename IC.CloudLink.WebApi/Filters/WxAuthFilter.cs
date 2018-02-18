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
    public class WxAuthFilter : Attribute, IActionFilter
    {
        public bool IsFilter { get; set; }
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
            var openId = context.HttpContext.Session.GetString("OpenId");
            
            if (string.IsNullOrWhiteSpace(openId))
            {
                HttpResult<string> result = new HttpResult<string>();
                result.Success = Convert.ToString(Core.Entity.Enum.HTTP_SUCCESS.FAIL);
                result.Code = (int)IC.Core.Entity.Enum.HTTP_STATUS_CODE.TIMEOUT;
                result.Msg = IC.Core.Entity.Enum.HTTP_STATUS_CODE.TIMEOUT.GetDescription();
                ResultContainer resultContainer = new ResultContainer(result);
                context.Result = resultContainer;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
        }
    }
}
