using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity.CloudLink.DB
{
    public class ReChargeRecord : HasId
    {
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
    }
}
