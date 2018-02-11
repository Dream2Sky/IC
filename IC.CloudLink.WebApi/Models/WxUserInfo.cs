using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IC.CloudLink.WebApi.Models
{
    public class WxUserInfo
    {
        /// <summary>
        /// 是否已经关注过公众号 0表示没有
        /// </summary>
        public int Subscribe { get; set; }
        public string OpenId { get; set; }
        public string NickName { get; set; }
        public int Sex { get; set; }
        public string Lang { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string ImgUrl { get; set; }
    }
}
