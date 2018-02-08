using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity.CloudLink.DB
{
    public class FlowPackageRecord : HasId
    {
        public Guid UserId { get; set; }
        public Guid CardId { get; set; }
        public Guid PackageId { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
