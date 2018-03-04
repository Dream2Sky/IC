using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IC.CloudLink.Services.Contracts;
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
    public class AccountController : BaseController<AccountController>
    {
        private ISMSService smsService;
        private IVerificationCodeService verificationCodeService;
        private Dictionary<string, List<VerificationCode>> codeDict;
        public AccountController(ILogger<AccountController> logger, IDBService dbService
            , ISMSService smsService, IVerificationCodeService verificationCodeService,
            Dictionary<string, List<VerificationCode>> codeDict) : base(logger, dbService)
        {
            this.smsService = smsService;
            this.verificationCodeService = verificationCodeService;
            this.codeDict = codeDict;
        }

        [HttpGet]
        public IActionResult IsRegister(string openId)
        {
            var res = dbService.GetUserByOpenId(openId);
            var isRegister = res.Count() <= 0 ? false : true;

            return Ok(HttpRequestUtil.GetHttpResponse((int)BIZSTATUS.SUCCESS, BIZSTATUS.SUCCESS.GetDescription(), isRegister));
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="phone"></param>
        /// <param name="validCode"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register(string openId, string phone, string validCode)
        {
            var isValidCode = verificationCodeService.ValidateCode(codeDict, phone, Convert.ToInt32(validCode));
            if (!isValidCode)
            {
                return Ok(HttpRequestUtil.GetHttpResponse((int)BIZSTATUS.INVALIDCODE, BIZSTATUS.INVALIDCODE.GetDescription(), isValidCode));
            }

            dbService.Register(phone, openId);
            return Ok(HttpRequestUtil.GetHttpResponse((int)BIZSTATUS.SUCCESS, BIZSTATUS.SUCCESS.GetDescription(), ""));
        }

        /// <summary>
        /// 点击发送手机验证码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SendVerificationCode(string openId, string phone)
        {
            var code = verificationCodeService.NewCode(codeDict, phone);

            var result = smsService.SentSMS(phone, code.Code);

            return Ok(HttpRequestUtil.GetHttpResponse((int)BIZSTATUS.SUCCESS, BIZSTATUS.SUCCESS.GetDescription(), result));
        }

        /// <summary>
        /// 微信充值成功后回调方法
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RechargeCallBack(string openId, decimal amount)
        {
            var isOk = dbService.ReCharge(openId, amount);
            var state = isOk ? BIZSTATUS.SUCCESS : BIZSTATUS.FAILEDTORECHARGE;

            return Ok(HttpRequestUtil.GetHttpResponse((int)state, state.GetDescription(), ""));
        }

    }
}
