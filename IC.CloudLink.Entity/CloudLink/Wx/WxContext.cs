using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity.CloudLink.Wx
{
    public class WxContext
    {
        private WxAuthInfo authInfo;

        public WxAuthInfo AuthInfo
        {
            get { return authInfo; }
            set { authInfo = value; }
        }

        private WxToken token;

        public WxToken Token
        {
            get { return token; }
            set { token = value; }
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
