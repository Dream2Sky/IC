using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IC.Core.Entity.CloudLink.Wx
{
    public class WxUserInfo
    {
        /// <summary>
        /// 是否已经关注过公众号 0表示没有
        /// </summary>
        public int subscribe { get; set; }
        public string openid { get; set; }
        public string nickname { get; set; }
        public int sex { get; set; }
        public string language { get; set; }
        public string headimgurl { get; set; }
        public ulong subscribe_time { get; set; }
        public string unionid { get; set; }

    }
}
