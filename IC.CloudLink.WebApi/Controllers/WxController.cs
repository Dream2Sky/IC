using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IC.CloudLink.Services.Contracts;
using IC.Core.Entity.CloudLink.Wx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
    }
}
