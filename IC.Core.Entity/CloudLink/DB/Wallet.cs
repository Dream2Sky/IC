using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity.CloudLink.DB
{
    public class Wallet:HasId
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 用户钱包余额
        /// </summary>
        public decimal Balance { get; set; }
    }
}
