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

        [NonAction]
        public string GetWxOpenId(string code, string state)
        {
            var res = wxService.GetAuthToken(wxContext, code);
            if (res == null)
            {
                return null;
            }
            string openId = Convert.ToString(res.OpenId);
            return openId;
        }

        [HttpGet]
        public IActionResult GetWxUserInfo(string code, string state)
        {
            var openId = GetWxOpenId(code, state);
            if (string.IsNullOrWhiteSpace(openId))
            {
                return Ok(HttpRequestUtil.GetHttpResponse(HTTP_STATUS_CODE.ERROR, ""));
            }
            HttpContext.Session.SetString("OpenId", openId);

            var userInfo = wxService.GetWxUserInfo(wxContext, openId);
            if (userInfo == null)
            {
                return Ok(HttpRequestUtil.GetHttpResponse(HTTP_STATUS_CODE.ERROR, ""));
            }

            var wxUserInfo = BuildWxUserInfo(userInfo);
            return Ok(HttpRequestUtil.GetHttpResponse(HTTP_STATUS_CODE.SUCCESS, wxUserInfo));
        }

        private WxUserInfo BuildWxUserInfo(dynamic userInfo)
        {
            WxUserInfo wxUserInfo = new WxUserInfo()
            {
                Subscribe = Convert.ToInt64(userInfo.Subscribe),
                OpenId = Convert.ToString(userInfo.OpenId),
                NickName = Convert.ToString(userInfo.NickName),
                Sex = Convert.ToInt64(userInfo.Sex),
                City = Convert.ToString(userInfo.City),
                Country = Convert.ToString(userInfo.Country),
                Province = Convert.ToString(userInfo.Province),
                Lang = Convert.ToString(userInfo.Language),
                ImgUrl = Convert.ToString(userInfo.Headimgurl)
            };

            return wxUserInfo;
        }
    }
}
