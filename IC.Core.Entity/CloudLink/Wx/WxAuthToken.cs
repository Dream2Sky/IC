using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity.CloudLink.Wx
{
    public class WxAuthToken
    {
        public string Access_Token { get; set; }
        public int Expires_In { get; set; }
        public string Refresh_Token { get; set; }
        public string OpenId { get; set; }
        public string Scope { get; set; }
    }
}
