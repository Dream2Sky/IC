using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity.CloudLink.DB
{
    public class HasId
    {
        public string Id { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDel { get; set; }

        public DateTime DelTime { get; set; }
    }
}
