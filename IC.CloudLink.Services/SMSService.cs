﻿using IC.CloudLink.Services.Contracts;
using IC.Core.Entity;
using IC.Core.Entity.CloudLink.SMS;
using IC.Core.Utility.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace IC.CloudLink.Services
{
    public class SMSService : ISMSService
    {
        public SMSResult SentSMS(string phone, int code)
        {
            Dictionary<string, string> paramDict = new Dictionary<string, string>();
            paramDict.Add("phone", phone);
            paramDict.Add("code", Convert.ToString(code));
            return HttpRequestUtil.Get<SMSResult>(Const.SMSUrl, paramDict);
        }
    }
}
