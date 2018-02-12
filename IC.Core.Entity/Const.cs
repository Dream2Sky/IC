using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity
{
    public static class Const
    {
        public static string WxTokenUrl
        {
            get
            {
                return "https://api.weixin.qq.com/cgi-bin/token";
            }
        }

        public static string WxTicketUrl
        {
            get
            {
                return "https://api.weixin.qq.com/cgi-bin/ticket/getticket";
            }
        }

        public static string WxAuthTokenUrl
        {
            get
            {
                return "https://api.weixin.qq.com/sns/oauth2/access_token";
            }
        }

        public static string WxUserInfo
        {
            get
            {
                return "https://api.weixin.qq.com/cgi-bin/user/info";
            }
        }
    }
}
