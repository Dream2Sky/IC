using IC.Core.Entity.CloudLink.Wx;
using System;
using System.Collections.Generic;
using System.Text;

namespace IC.CloudLink.Services.Contracts
{
    public interface IWxService
    {
        /// <summary>
        /// 获取微信公众号网页授权token
        /// </summary>
        /// <returns></returns>
        WxAuthToken GetAuthToken(WxContext wxContext, string code);

        /// <summary>
        /// 获取微信用户基本信息
        /// </summary>
        /// <param name="wxContext"></param>
        /// <returns></returns>
        WxUserInfo GetWxUserInfo(WxContext wxContext, string openId);

        /// <summary>
        /// 获取微信公众号api访问token
        /// </summary>
        /// <returns></returns>
        WxToken GetToken(WxContext wxContext);

        /// <summary>
        /// 获取微信jssdk签名所需的ticket
        /// </summary>
        /// <returns></returns>
        WxTicket GetTicket(WxContext wxContext);

        /// <summary>
        /// 获取微信jssdk授权配置
        /// </summary>
        /// <returns></returns>
        WxJSSDKConfig GetWxJSSDKConfig(WxContext wxContext, string url);

        /// <summary>
        /// 计算jssdk签名
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="nonceStr"></param>
        /// <param name="currentUrl"></param>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        string GetSignture(string ticket, string nonceStr, string currentUrl, string timeStamp);

    }
}
