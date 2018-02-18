using System;
using System.Collections.Generic;
using System.Text;
using IC.Core.Entity;
using IC.Core.Entity.CloudLink.Wx;
using IC.Core.Utility.Http;

namespace IC.Wx.Services
{
    public class AuthService : IAuthService
    {
        public void GetAuthCode(WxContext wxContext, string redirectUrl)
        {
            //?appid=APPID&redirect_uri=REDIRECT_URI&response_type=code&scope=SCOPE&state=STATE#wechat_redirect
            Dictionary<string, string> paramDict = new Dictionary<string, string>();
            paramDict.Add("appid", wxContext.AuthInfo.AppId);
            paramDict.Add("redirect_uri", redirectUrl);
            paramDict.Add("response_type", "code");
            paramDict.Add("scope", "snsapi_base#wechat_redirect");

            HttpRequestUtil.Get<string>(Const.WxAuthCodeUrl, paramDict);
        }

        public WxAuthToken GetAuthToken(WxContext wxContext, string code)
        {
            Dictionary<string, string> paramDict = new Dictionary<string, string>();
            paramDict.Add("appid", wxContext.AuthInfo.AppId);
            paramDict.Add("secret", wxContext.AuthInfo.AppSercet);
            paramDict.Add("code", code);
            paramDict.Add("grant_type", "authorization_code");

            return HttpRequestUtil.Get<WxAuthToken>(Const.WxAuthTokenUrl, paramDict);
        }
    }
}
