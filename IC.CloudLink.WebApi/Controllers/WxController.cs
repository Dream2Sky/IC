using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IC.CloudLink.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IC.CloudLink.WebApi.Controllers
{
    [Route("api/wx/[controller]/[action]")]
    public class WxController : BaseController<WxController>
    {
        public WxController(ILogger<WxController> logger, IDBService dbService) : base(logger, dbService)
        {
        }
        


    }
}
