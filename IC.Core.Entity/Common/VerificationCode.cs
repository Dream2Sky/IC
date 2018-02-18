using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity.Common
{
    public class VerificationCode
    {
        public int Code { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime ExpiresTime { get; set; }
    }
}
