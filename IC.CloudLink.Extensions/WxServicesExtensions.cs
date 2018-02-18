using System;
using System.Collections.Generic;
using System.Text;
using IC.Core.Entity.CloudLink.Wx;
using IC.Core.Utility;
using JetBrains.Annotations;

namespace IC.CloudLink.Extensions
{
    public static class WxServicesExtensions
    {
        public static void InitAuthInfo([NotNull]this WxContext wxContext, string appId, string appSercet)
        {
            Check.NotNull(wxContext,"wxContext");
            
            wxContext.AuthInfo.AppId = appId;
            wxContext.AuthInfo.AppSercet = appSercet;
        }
    }
}
