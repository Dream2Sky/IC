using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IC.Core.Entity.CloudLink.DB
{
    public class FlowPackageRecord : HasId
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [StringLength(36)]
        public string UserId { get; set; }

        /// <summary>
        /// 流量卡Id
        /// </summary>
        [StringLength(36)]
        public string CardId { get; set; }

        /// <summary>
        /// 套餐Id
        /// </summary>
        [StringLength(36)]
        public string PackageId { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpiryDate { get; set; }
    }
}
