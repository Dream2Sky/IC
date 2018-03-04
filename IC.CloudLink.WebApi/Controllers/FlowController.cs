using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IC.CloudLink.Services.Contracts;
using IC.CloudLink.WebApi.Models;
using IC.Core.Entity;
using IC.Core.Entity.CloudLink.SMS;
using IC.Core.Entity.Common;
using IC.Core.Utility.Extensions;
using IC.Core.Utility.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static IC.Core.Entity.Enum;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IC.CloudLink.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FlowController : BaseController<FlowController>
    {
        private IICCIDService iCCIDService;
        public FlowController(ILogger<FlowController> logger, IDBService dbService, IICCIDService iCCIDService) : base(logger, dbService)
        {
            this.iCCIDService = iCCIDService;
        }

        /// <summary>
        /// 获取指定openId的所有流量卡信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 添加新卡
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="iccId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddCards(string openId, string iccId)
        {
            if (!iCCIDService.IsValidICCID(iccId))
            {
                return Ok(HttpRequestUtil.GetHttpResponse((int)BIZSTATUS.INVALIDICCID, BIZSTATUS.INVALIDICCID.GetDescription(), ""));
            }

            if (dbService.IsExistedFlowCard(iccId))
            {
                return Ok(HttpRequestUtil.GetHttpResponse((int)BIZSTATUS.EXISTEDCARD, BIZSTATUS.EXISTEDCARD.GetDescription(), ""));
            }

            var state = BIZSTATUS.SUCCESS;
            if (!dbService.AddFlowCards(openId, iccId))
            {
                state = BIZSTATUS.ERROR;
            }

            return Ok(HttpRequestUtil.GetHttpResponse((int)state, state.GetDescription(), ""));
        }

        /// <summary>
        /// 购买流量套餐
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="iccId"></param>
        /// <param name="flowPackageId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult BuyFlowPackage(string openId, string iccId, string flowPackageId)
        {
            var cards = dbService.GetFlowCards(openId);
            if (cards == null || cards.Count()<=0 || cards.SingleOrDefault(n=>n.ICCId == iccId)==null)
            {
                return Ok(HttpRequestUtil.GetHttpResponse((int)BIZSTATUS.USERHASNOCARD, BIZSTATUS.USERHASNOCARD.GetDescription(), ""));
            }

            if (!dbService.IsExistedFlowPackage(flowPackageId))
            {
                return Ok(HttpRequestUtil.GetHttpResponse((int)BIZSTATUS.INVALIDFLOWPACKAGE, BIZSTATUS.INVALIDFLOWPACKAGE.GetDescription(), ""));
            }

            if (dbService.BuyFlowPackage(iccId, flowPackageId))
            {
                return Ok(HttpRequestUtil.GetHttpResponse((int)BIZSTATUS.SUCCESS, BIZSTATUS.SUCCESS.GetDescription(), ""));
            }
            return Ok(HttpRequestUtil.GetHttpResponse((int)BIZSTATUS.ERROR, BIZSTATUS.ERROR.GetDescription(), ""));
        }

    }
}
