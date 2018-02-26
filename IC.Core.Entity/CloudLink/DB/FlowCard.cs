using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IC.Core.Entity.CloudLink.DB
{
    public class FlowCard:HasId
    { 
        /// <summary>
        /// 用户Id
        /// </summary>
        [StringLength(36)]
        public string UserId { get; set; }

        /// <summary>
        /// 用户openId
        /// </summary>
        /// <returns></returns>
        [StringLength(32)]
        public string OpenId { get; set; }
        
        /// <summary>
        /// 卡号
        /// </summary>
        [StringLength(20)]
        [Required]
        public string ICCId { get; set; }

        /// <summary>
        /// 总流量
        /// </summary>
        public decimal TotalFlow { get; set; }

        /// <summary>
        /// 已使用流量
        /// </summary>
        public decimal UsagedFlow { get; set; }

        /// <summary>
        /// 更新时间, 购买套餐的时候会怎加这里的总流量， 消费流量的时候会更新这里的已使用流量
        /// </summary>
        public DateTime UpdateTime { get; set; }

        public ICollection<FlowPackage> FlowPackages { get; set; }
        public ICollection<FlowPackageRecord> FlowPackageRecords { get; set; }

    }
}
