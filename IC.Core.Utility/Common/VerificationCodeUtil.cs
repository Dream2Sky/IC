using IC.Core.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Utility.Common
{
    public class VerificationCodeUtil
    {
        public static VerificationCode NewCode()
        {
            VerificationCode code = new VerificationCode()
            {
                Code = new Random().Next(100000, 999999),
                ExpiresIn = 300,
                ExpiresTime = DateTime.Now.AddSeconds(300)
            };

            return code;
        }
    }
}
