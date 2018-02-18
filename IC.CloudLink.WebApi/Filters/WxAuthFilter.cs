using IC.CloudLink.Services;
using IC.CloudLink.Services.Contracts;
using IC.CloudLink.WebApi.Controllers;
using IC.Core.Entity;
using IC.Core.Utility.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IC.CloudLink.WebApi.Filters
{
    public class WxAuthFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var openId = context.HttpContext.Session.GetString("OpenId");
            
            if (string.IsNullOrWhiteSpace(openId))
            {
                openId = HttpRequestUtil.Get<string>(Const.WxGateWayAuthUrl, null);
                context.HttpContext.Session.SetString("OpenId", openId);
            }
        }
    }
}
