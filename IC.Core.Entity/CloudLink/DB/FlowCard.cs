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
        public Guid UserId { get; set; }

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
        /// 更新时间, 购买套餐时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

    }
}
