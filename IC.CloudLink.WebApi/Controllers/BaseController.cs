using IC.CloudLink.Services.Contracts;
using IC.CloudLink.WebApi.Filters;
using IC.Core.Entity.CloudLink.Wx;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace IC.CloudLink.WebApi.Controllers
{
    [WxAuthFilter]
    public class BaseController<T>:Controller
    {
        protected ILogger logger;
        protected IDBService dbService;
        public BaseController(ILogger<T> logger, IDBService dbService)
        {
            this.logger = logger;
            this.dbService = dbService;
        }

        [NonAction]
        public string GetRootPath()
        {
            string rootPath = string.Format("{0}://{1}/", HttpContext.Request.Scheme,HttpContext.Request.Host);
            return rootPath;
        }
    }
}
