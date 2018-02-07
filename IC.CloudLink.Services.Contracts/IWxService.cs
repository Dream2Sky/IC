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
        WxToken GetAuthToken(WxContext wxContext, string code);

        /// <summary>
        /// 获取微信公众号api访问token
        /// </summary>
        /// <returns></returns>
        WxToken GetToken(WxContext wxContext);

        /// <summary>
        /// 获取微信jssdk签名所需的ticket
        /// </summary>
        /// <returns></returns>
        WxTicket GetTicket(WxContext context);

        /// <summary>
        /// 获取微信jssdk授权配置
        /// </summary>
        /// <returns></returns>
        WxJSSDKConfig GetWxJSSDKConfig(WxContext context, string url);
    }
}
