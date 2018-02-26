using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IC.CloudLink.Services.Contracts;
using IC.CloudLink.WebApi.Models;
using IC.Core.Entity.CloudLink.SMS;
using IC.Core.Entity.Common;
using IC.Core.Utility.Extensions;
using IC.Core.Utility.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static IC.Core.Entity.Enum;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IC.CloudLink.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FlowController : BaseController<FlowController>
    {
        public FlowController(ILogger<FlowController> logger, IDBService dbService) : base(logger, dbService)
        {

        }

        [HttpGet]
        public IActionResult GetCards(string openId)
        {
            var cards = dbService.GetFlowCards(openId);
            if (cards == null || cards.Count() <= 0)
            {
                return Ok(HttpRequestUtil.GetHttpResponse((int)BIZSTATUS.NOCARDS, BIZSTATUS.NOCARDS.GetDescription(), ""));
            }
            List<FlowCardModel> flowCardsList = new List<FlowCardModel>();
            foreach (var item in cards)
            {
                FlowCardModel model = new FlowCardModel()
                {
                    OpenId = item.OpenId,
                    ICCId = item.ICCId,
                    TotalFlow = item.TotalFlow,
                    UsagedFlow = item.UsagedFlow
                };

                flowCardsList.Add(model);
            }
            return Ok(HttpRequestUtil.GetHttpResponse((int)BIZSTATUS.SUCCESS, BIZSTATUS.SUCCESS.GetDescription(), flowCardsList));
        }
    }
}
