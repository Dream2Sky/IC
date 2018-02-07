using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity.CloudLink.Wx
{
    public class WxContext
    {
        public WxContext()
        {
            AuthInfo = new WxAuthInfo();
            Token = new WxToken();
            AuthToken = new WxToken();
            Ticket = new WxTicket();
        }
        private WxAuthInfo authInfo;

        public WxAuthInfo AuthInfo
        {
            get { return authInfo; }
            set { authInfo = value; }
        }

        private WxToken token;

        /// <summary>
        /// 普通access_token
        /// </summary>
        public WxToken Token
        {
            get { return token; }
            set { token = value; }
        }

        private WxToken authToken;
        /// <summary>
        /// 网页授权access_token
        /// </summary>
        public WxToken AuthToken
        {
            get { return authToken; }
            set { authToken = value; }
        }

        private WxTicket ticket;

        public WxTicket Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }

        public string NonceStr { get; } = "b33b5f905e844a62931fe7ebfb846c9f";
    }
}
