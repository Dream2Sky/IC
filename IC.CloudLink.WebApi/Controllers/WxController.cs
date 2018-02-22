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
using IC.CloudLink.WebApi.Filters;
using Microsoft.AspNetCore.Authorization;
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
        [ChkOpenIdFilter(IsFilter = false)]
        public IActionResult GetJSSDKConfig(string url)
        {
            var config = wxService.GetWxJSSDKConfig(wxContext, url);
            var statusCode = config == null ? BIZSTATUS.DATAEMPTY : BIZSTATUS.SUCCESS;

            return Ok(HttpRequestUtil.GetHttpResponse((int)statusCode, statusCode.GetDescription(), config));
        }

        [HttpGet]
        [WxAuthFilter(IsFilter = false)]
        [ChkOpenIdFilter(IsFilter = false)]
        public IActionResult GetWxOpenId(string code, string state)
        {
            var res = wxService.GetAuthToken(wxContext, code);
            if (res != null)
            {
                HttpContext.Session.SetString("OpenId", res.OpenId);
                return Redirect("/?openId="+res.OpenId);
            }
            else
            {
                return Ok(HttpRequestUtil.GetHttpResponse<string>((int)BIZSTATUS.ERROR, BIZSTATUS.ERROR.GetDescription(),""));
            }
        }

        [HttpGet]
        public IActionResult GetWxUserInfo(string openId)
        {
            var userInfo = wxService.GetWxUserInfo(wxContext, openId);
            if (userInfo == null)
            {
                return Ok(HttpRequestUtil.GetHttpResponse((int)BIZSTATUS.ERROR,BIZSTATUS.ERROR.GetDescription(), ""));
            }

            if (dbService.IsRegister(openId))
            {
                return Ok(HttpRequestUtil.GetHttpResponse((int)BIZSTATUS.SUCCESS, BIZSTATUS.SUCCESS.GetDescription(),userInfo));
            }
            else
            {
                return Ok(HttpRequestUtil.GetHttpResponse((int)BIZSTATUS.NOREGISTER,BIZSTATUS.NOREGISTER.GetDescription(), openId));
            }
        }
    }
}
