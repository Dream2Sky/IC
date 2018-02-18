using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IC.CloudLink.Services.Contracts;
using IC.Core.Entity.CloudLink.SMS;
using IC.Core.Entity.Common;
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
        public IActionResult IsRegister()
        {
            var openId = HttpContext.Session.GetString("OpenId");
            var res = dbService.GetUserByOpenId(openId);
            var isRegister = res.Count() <= 0 ? false : true;

            return Ok(HttpRequestUtil.GetHttpResponse(HTTP_STATUS_CODE.SUCCESS, isRegister));
        }

        [HttpPost]
        public IActionResult Register(string phone, string vaildCode)
        {
            
            return Ok();
        }

        [HttpGet]
        public IActionResult IsValidCode(string phone, string validCode)
        {
            var res = verificationCodeService.ValidateCode(codeDict, phone, Convert.ToInt32(validCode));
            return Ok(HttpRequestUtil.GetHttpResponse(HTTP_STATUS_CODE.SUCCESS, res));
        }

        /// <summary>
        /// 点击发送手机验证码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SendVerificationCode(string phone)
        {
            var code = verificationCodeService.NewCode(codeDict, phone);

            var result = smsService.SentSMS(phone, code.Code);

            return Ok(HttpRequestUtil.GetHttpResponse(HTTP_STATUS_CODE.SUCCESS, result));
        }

    }
}
