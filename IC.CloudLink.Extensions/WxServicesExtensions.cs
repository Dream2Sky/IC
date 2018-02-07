using IC.Core.Entity.CloudLink.Wx;
using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using IC.Core.Utility;

namespace IC.CloudLink.Extensions
{
    public static class WxServicesExtensions
    {
        public static void InitAuthInfo([NotNull]this WxContext wxContext, string appId, string appSercet)
        {
            Check.NotNull(wxContext,"wxContext");

            wxContext.AuthInfo = new WxAuthInfo();
            wxContext.AuthInfo.AppId = appId;
            wxContext.AuthInfo.AppSercet = appSercet;
        }
    }
}
