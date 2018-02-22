using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IC.Core.Entity.CloudLink.DB
{
    public class ReChargeRecord : HasId
    {
        [StringLength(36)]
        public string UserId { get; set; }
        public decimal Amount { get; set; }
    }
}
