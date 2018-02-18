using IC.CloudLink.Services.Contracts;
using IC.Core.Entity.Common;
using IC.Core.Utility.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IC.CloudLink.Services
{
    public class VerificationCodeService : IVerificationCodeService
    {
        public List<VerificationCode> GetCode(Dictionary<string, List<VerificationCode>> codeDict, string phone)
        {
            if (codeDict.ContainsKey(phone))
            {
                return codeDict[phone];
            }
            return null;
        }

        public VerificationCode NewCode(Dictionary<string, List<VerificationCode>> codeDict, string phone)
        {
            VerificationCode code = VerificationCodeUtil.NewCode();
            if (codeDict.ContainsKey(phone))
            {
                List<VerificationCode> codeList = codeDict[phone];
                if (codeList == null)
                {
                    codeList = new List<VerificationCode>();
                    codeDict[phone] = codeList;
                }
                codeList.Add(code);
            }
            else
            {
                List<VerificationCode> codeList = new List<VerificationCode>();
                codeList.Add(code);
                codeDict.Add(phone, codeList);
            }
            return code;
        }

        /// <summary>
        /// 验证 验证码, 验证完毕之后删掉验证码字典
        /// </summary>
        /// <param name="codeDict"></param>
        /// <param name="phone"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool ValidateCode(Dictionary<string, List<VerificationCode>> codeDict, string phone, int code)
        {
            List<VerificationCode> codeList = GetCode(codeDict, phone);
            if (codeList == null || codeList.Count <= 0)
            {
                return false;
            }

            var res = codeList.FindAll(n => n.Code == code && n.ExpiresTime > DateTime.Now);
            if (res == null || res.Count <= 0)
            {
                return false;
            }
            else
            {
                codeDict.Remove(phone);
                return true;
            }
        }
    }
}
