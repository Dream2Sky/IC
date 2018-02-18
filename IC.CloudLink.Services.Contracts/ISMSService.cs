using Aliyun.Acs.Core;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using IC.Core.Entity.CloudLink.SMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IC.CloudLink.Services.Contracts
{
    public interface ISMSService
    {
        SMSResult SentSMS(string phone, int code);
    }
}
