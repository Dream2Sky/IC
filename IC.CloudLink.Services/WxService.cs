using IC.CloudLink.Services.Contracts;
using IC.Core.Entity;
using IC.Core.Entity.CloudLink.Wx;
using IC.Core.Utility.Encrypt;
using IC.Core.Utility.Http;
using IC.Core.Utility.Time;
using System;
using System.Collections.Generic;
using System.Text;

namespace IC.CloudLink.Services
{
    public class WxService : IWxService
    {
        public WxAuthToken GetAuthToken(WxContext wxContext, string code)
        {
            Dictionary<string, string> paramDict = new Dictionary<string, string>();
            paramDict.Add("appid", wxContext.AuthInfo.AppId);
            paramDict.Add("secret", wxContext.AuthInfo.AppSercet);
            paramDict.Add("code", code);
            paramDict.Add("grant_type", "authorization_code");

            return HttpRequestUtil.Get<WxAuthToken>(Const.WxAuthTokenUrl, paramDict);
        }

        /// <summary>
        /// 计算jssdk签名
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="nonceStr"></param>
        /// <param name="currentUrl"></param>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public string GetSignture(string ticket, string nonceStr, string currentUrl, string timeStamp)
        {
            var str = string.Format("jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}", ticket, nonceStr, timeStamp, currentUrl);
            return EncryptUtil.Sha1(str, Encoding.UTF8);
        }

        /// <summary>
        /// 获取微信jssdk算签名用的ticket
        /// </summary>
        /// <param name="wxContext"></param>
        /// <returns></returns>
        public WxTicket GetTicket(WxContext wxContext)
        {
            if (wxContext.Ticket.ExpiresTime > DateTime.Now)
            {
                return wxContext.Ticket;
            }
            Dictionary<string, string> paramDict = new Dictionary<string, string>();
            paramDict.Add("access_token", GetToken(wxContext).Access_Token);
            paramDict.Add("type", "jsapi");

            var ticket = HttpRequestUtil.Get<WxTicket>(Const.WxTicketUrl, paramDict);
            wxContext.Ticket = ticket;

            return ticket;
        }

        /// <summary>
        /// 获取微信普通access_token
        /// </summary>
        /// <param name="wxContext"></param>
        /// <returns></returns>
        public WxToken GetToken(WxContext wxContext)
        {
            if (wxContext.Token.ExpiresTime > DateTime.Now)
            {
                return wxContext.Token;
            }
            Dictionary<string, string> paramDict = new Dictionary<string, string>();
            paramDict.Add("grant_type", "client_credential");
            paramDict.Add("appid", wxContext.AuthInfo.AppId);
            paramDict.Add("secret", wxContext.AuthInfo.AppSercet);

            var token = HttpRequestUtil.Get<WxToken>(Const.WxTokenUrl, paramDict);
            wxContext.Token = token;
            return token;
        }

        /// <summary>
        /// 获取微信jssdk鉴权配置
        /// </summary>
        /// <param name="wxContext"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public WxJSSDKConfig GetWxJSSDKConfig(WxContext wxContext, string url)
        {
            WxJSSDKConfig config = new WxJSSDKConfig();
            config.AppId = wxContext.AuthInfo.AppId;
            config.TimeStamp = Convert.ToString(DateTimeUtil.GetCurrentTimeStamp());
            config.Signature = GetSignture(GetTicket(wxContext).Ticket, wxContext.NonceStr, url, config.TimeStamp);
            config.NonceStr = wxContext.NonceStr;

            return config;
        }

        /// <summary>
        /// 获取微信用户基本信息
        /// </summary>
        /// <param name="wxContext"></param>
        /// <param name="openId"></param>
        /// <returns></returns>
        public WxUserInfo GetWxUserInfo(WxContext wxContext, string openId)
        {
            if (wxContext.Token == null || wxContext.Token.ExpiresTime <= DateTime.Now)
            {
                this.GetToken(wxContext);
            }
            Dictionary<string, string> paramDict = new Dictionary<string, string>();
            paramDict.Add("access_token", wxContext.Token.Access_Token);
            paramDict.Add("openid", openId);
            paramDict.Add("lang", "zh_CN");

            return HttpRequestUtil.Get<WxUserInfo>(Const.WxUserInfo, paramDict);
        }
    }
}
