using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IC.Core.Entity.CloudLink.DB
{
    public class FlowPackage:HasId
    {
        /// <summary>
        /// 套餐名
        /// </summary>
        [StringLength(100)]
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
        public Enum.PERID Type { get; set; }

        /// <summary>
        /// 套餐说明
        /// </summary>
        [StringLength(1000)]
        public string Desc { get; set; }

        public ICollection<FlowPackageRecord> FlowPackageRecords { get; set; }
    }
}
