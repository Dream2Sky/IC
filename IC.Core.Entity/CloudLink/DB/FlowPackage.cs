using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity.CloudLink.DB
{
    public class FlowPackage:HasId
    {
        /// <summary>
        /// 套餐名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 套餐金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 套餐流量
        /// </summary>
        public decimal Flow { get; set; }

        /// <summary>
        /// 有效期类型 可选值:  Month\月包  Quarter\季包  HalfYear\半年包   Year\年包
        /// </summary>
        public string Type { get; set; }
    }
}
