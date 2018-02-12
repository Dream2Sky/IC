using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using IC.CloudLink.Services.Contracts;
using IC.Core.Entity.CloudLink.SMS;
using IC.Core.Utility.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static IC.Core.Entity.Enum;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IC.CloudLink.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : BaseController<AccountController>
    {
        private SMSContext smsContext;
        private ISMSService smsService;
        public AccountController(ILogger<AccountController> logger, IDBService dbService
            , SMSContext smsContext, ISMSService smsService) : base(logger, dbService)
        {
            this.smsContext = smsContext;
            this.smsService = smsService;
        }

        [HttpGet]
        public IActionResult IsRegister()
        {
            var openId = HttpContext.Session.GetString("OpenId");
            if (string.IsNullOrWhiteSpace(openId))
            {
                return Ok(HttpRequestUtil.GetHttpResponse(HTTP_STATUS_CODE.TIMEOUT, ""));
            }
            var res = dbService.GetUserByOpenId(openId);
            var isRegister = res.Count() <= 0 ? false : true;

            return Ok(HttpRequestUtil.GetHttpResponse(HTTP_STATUS_CODE.SUCCESS, isRegister));
        }

        [HttpPost]
        public IActionResult Register(string phone, string vaildCode)
        {
            return Ok();
        }

        [NonAction]
        private bool IsValidCode(string phone, string validCode)
        {
            return false;
        }

        [HttpGet]
        public IActionResult SendSMS(string phone)
        {
            SendSmsResponse sendSmsResponse = smsService.SentMsg(smsService.InitAcsClient(smsContext),
                smsService.InitSmsRequest(smsContext, phone, "{\"code\":\"123\"}"));
            SMSResult result = new SMSResult()
            {
                Code = sendSmsResponse.Code,
                BizId = sendSmsResponse.BizId,
                Message = sendSmsResponse.Message,
                RequestId = sendSmsResponse.RequestId
            };
            return Ok(HttpRequestUtil.GetHttpResponse(HTTP_STATUS_CODE.SUCCESS, result));
        }

    }
}
