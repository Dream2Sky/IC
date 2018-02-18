using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using IC.CloudLink.Services.Contracts;
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
        private WxContext wxContext;
        private IWxService wxService;
        public WxController(ILogger<WxController> logger, IDBService dbService, 
            IWxService wxService, WxContext wxContext) 
            : base(logger, dbService)
        {
            this.wxContext = wxContext;
            this.wxService = wxService;
        }

        [HttpGet("{url}")]
        public IActionResult GetJSSDKConfig(string url)
        {
            var config = wxService.GetWxJSSDKConfig(wxContext, url);
            var statusCode = config == null ? HTTP_STATUS_CODE.DATAEMPTY : HTTP_STATUS_CODE.SUCCESS;

            return Ok(HttpRequestUtil.GetHttpResponse(statusCode, config));
        }

        [HttpGet]
        public IActionResult GetWxUserInfo()
        {
            var openId = HttpContext.Session.GetString("OpenId");
            var userInfo = wxService.GetWxUserInfo(wxContext, openId);
            if (userInfo == null)
            {
                return Ok(HttpRequestUtil.GetHttpResponse(HTTP_STATUS_CODE.ERROR, ""));
            }

            if (dbService.IsRegister(openId))
            {
                return Ok(HttpRequestUtil.GetHttpResponse(HTTP_STATUS_CODE.SUCCESS, userInfo));
            }
            else
            {
                return Ok(HttpRequestUtil.GetHttpResponse(HTTP_STATUS_CODE.NOREGISTER, openId));
            }
        }
    }
}
