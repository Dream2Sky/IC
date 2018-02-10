using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity.CloudLink.DB
{
    public class User:HasId
    {
        /// <summary>
        /// 微信OpenId
        /// </summary>
        public string WxOpenId { get; set; }

        /// <summary>
        /// 用户手机
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 用户余额
        /// </summary>
        public decimal Balance { get; set; }
    }
}
