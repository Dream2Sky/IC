using IC.Core.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IC.CloudLink.Services.Contracts
{
    public interface IVerificationCodeService
    {
        VerificationCode NewCode(Dictionary<string, List<VerificationCode>> codeDict, string phone);
        List<VerificationCode> GetCode(Dictionary<string, List<VerificationCode>> codeDict, string phone);
        bool ValidateCode(Dictionary<string, List<VerificationCode>> codeDict, string phone, int code);
        
    }
}
