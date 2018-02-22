using IC.CloudLink.Services;
using IC.CloudLink.Services.Contracts;
using IC.CloudLink.WebApi.Controllers;
using IC.Core.Entity;
using IC.Core.Entity.Http;
using IC.Core.Utility.Extensions;
using IC.Core.Utility.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IC.CloudLink.WebApi.Filters
{
    public class BaseFilter: Attribute
    {
        public bool IsFilter { get; set; }

        protected ResultContainer GetFilterContextResult(Core.Entity.Enum.HTTP_SUCCESS acceptStatus, int statusCode, string msg)
        {
            HttpResult<string> result = new HttpResult<string>();
            result.Success = Convert.ToString(acceptStatus);
            result.Code = statusCode;
            result.Msg = msg;
            ResultContainer resultContainer = new ResultContainer(result);

            return resultContainer;
        }
    }
}
