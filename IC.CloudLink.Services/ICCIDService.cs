using IC.CloudLink.Services.Contracts;
using IC.Core.Entity;
using IC.Core.Entity.Common;
using IC.Core.Utility.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace IC.CloudLink.Services
{
    public class ICCIDService : IICCIDService
    {
        public JObject GetICCIDCheckResult(string iccId)
        {
            Dictionary<string, string> paramDict = new Dictionary<string, string>();
            paramDict.Add("iccid", iccId);

            var result = HttpRequestUtil.GetTest<JObject>();
            return result;
        }

        public bool IsValidICCID(string iccId)
        {
            var result = GetICCIDCheckResult(iccId);
            if (Convert.ToInt32(result["state"]) == 200)
            {
                return true;
            }
            return false;
        }
    }
}
