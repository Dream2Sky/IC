using IC.Core.Entity.CloudLink.Wx;
using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Wx.Services
{
    public interface IAuthService
    {
        void GetAuthCode(WxContext wxContext, string redirectUrl);
        WxAuthToken GetAuthToken(WxContext wxContext, string code);
    }
}
