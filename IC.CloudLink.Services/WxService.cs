using IC.CloudLink.Services.Contracts;
using IC.Core.Entity.CloudLink.Wx;
using IC.Core.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace IC.CloudLink.Services
{
    public class WxService : IWxService
    {
        public WxToken GetAuthToken(WxContext wxContext, string code)
        {
            throw new NotImplementedException();
        }

        public WxTicket GetTicket(WxContext context)
        {
            throw new NotImplementedException();
        }

        public WxToken GetToken(WxContext wxContext)
        {
            throw new NotImplementedException();
        }

        public WxJSSDKConfig GetWxJSSDKConfig(WxContext context, string url)
        {
            throw new NotImplementedException();
        }
    }
}
