using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity.CloudLink.DB
{
    public class FlowCard:HasId
    { 
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
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

    }
}
