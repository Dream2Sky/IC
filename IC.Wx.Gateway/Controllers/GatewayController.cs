using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IC.Core.Entity.CloudLink.Wx;
using IC.Core.Utility.Http;
using IC.Wx.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IC.Wx.Gateway.Controllers
{
    [Route("api/[controller]/[action]")]
    public class GatewayController : Controller
    {
        private IAuthService authService;
        private WxContext wxContext;
        public GatewayController(IAuthService authService, WxContext wxContext)
        {
            this.authService = authService;
            this.wxContext = wxContext;
        }

        [HttpGet]
        public void Auth()
        {
            authService.GetAuthCode(wxContext, GetRootPath()+"/api/gateway/GetAuthToken");
        }

        [HttpGet]
        public string GetAuthToken(string code, string state)
        {
            var res = authService.GetAuthToken(wxContext, code);
            if (res != null)
            {
                return res.OpenId;
            }
            return null;
        }

        [NonAction]
        public string GetRootPath()
        {
            string rootPath = string.Format("{0}://{1}/", HttpContext.Request.Scheme, HttpContext.Request.Host);
            return rootPath;
        }
    }
}
