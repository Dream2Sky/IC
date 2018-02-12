using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IC.CloudLink.Services.Contracts;
using IC.CloudLink.WebApi.Models;
using IC.Core.Entity.CloudLink.Wx;
using IC.Core.Utility.Extensions;
using IC.Core.Utility.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static IC.Core.Entity.Enum;

namespace IC.CloudLink.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class WxController : BaseController<WxController>
    {
        private IWxService wxService;
        private WxContext wxContext;
        public WxController(ILogger<WxController> logger, IDBService dbService,
            IWxService wxService, WxContext wxContext)
            : base(logger, dbService)
        {
            this.wxService = wxService;
            this.wxContext = wxContext;
        }

        [HttpGet("{url}")]
        public IActionResult GetJSSDKConfig(string url)
        {
            var config = wxService.GetWxJSSDKConfig(wxContext, url);
            var statusCode = config == null ? HTTP_STATUS_CODE.DATAEMPTY : HTTP_STATUS_CODE.SUCCESS;

            return Ok(HttpRequestUtil.GetHttpResponse(statusCode, config));
        }

        [HttpGet]
        public IActionResult GetWxUserInfo(string code, string state)
        {
            var res = wxService.GetAuthToken(wxContext, code);
            if (res == null)
            {
                return Ok(HttpRequestUtil.GetHttpResponse(HTTP_STATUS_CODE.ERROR, ""));
            }
            string openId = res.OpenId;

            HttpContext.Session.SetString("OpenId", openId);

            var userInfo = wxService.GetWxUserInfo(wxContext, openId);
            if (userInfo == null)
            {
                return Ok(HttpRequestUtil.GetHttpResponse(HTTP_STATUS_CODE.ERROR, ""));
            }
            logger.LogInformation(userInfo.openid);
            logger.LogInformation(userInfo.nickname);
            return Ok(HttpRequestUtil.GetHttpResponse(HTTP_STATUS_CODE.SUCCESS, userInfo));
        }
    }
}
