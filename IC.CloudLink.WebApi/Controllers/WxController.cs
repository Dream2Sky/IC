using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IC.CloudLink.Services.Contracts;
using IC.Core.Entity.CloudLink.Wx;
using IC.Core.Utility.Http;
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
            var statusCode = HTTP_STATUS_CODE.SUCCESS;
            var msg = "请求成功";
            if (config == null)
            {
                statusCode = HTTP_STATUS_CODE.DATAEMPTY;
                msg = "请求成功，但数据为空";
            }
            return Ok(HttpRequestUtil.GetHttpResponse(HTTP_SUCCESS.SUCCESS, statusCode, msg, config));
        }
    }
}
