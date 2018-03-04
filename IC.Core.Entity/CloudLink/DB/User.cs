using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace IC.Core.Entity.CloudLink.DB
{
    public class User:HasId
    {
        /// <summary>
        /// 微信OpenId
        /// </summary>
        [StringLength(32)]
        public string WxOpenId { get; set; }

        /// <summary>
        /// 用户手机
        /// </summary>
        [StringLength(13)]
        public string Phone { get; set; }

        /// <summary>
        /// 用户余额
        /// </summary>
        public decimal Balance { get; set; }

        public ICollection<FlowCard> FlowCards { get; set; }
        public ICollection<ReChargeRecord> ReChargeRecords { get; set; }
    }
}
