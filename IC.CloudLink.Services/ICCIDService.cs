using IC.CloudLink.Services.Contracts;
using IC.Core.Entity;
using IC.Core.Entity.Common;
using IC.Core.Utility.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace IC.CloudLink.Services
{
    public class ICCIDService : IICCIDService
    {
        public ICCIDCheckResult GetICCIDCheckResult(string iccId)
        {
            Dictionary<string, string> paramDict = new Dictionary<string, string>();
            paramDict.Add("iccid", iccId);

            HttpClient httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Host = "iccidchaxun.com";
            httpClient.DefaultRequestHeaders.Referrer = new Uri("http://iccidchaxun.com/");

            var result = HttpRequestUtil.Get<ICCIDCheckResult>(httpClient, Const.ICCIDCheckUrl, paramDict);
            
            return result;
        }

        public bool IsValidICCID(string iccId)
        {
            var result = GetICCIDCheckResult(iccId);
            if (result.State == 200)
            {
                return true;
            }
            return false;
        }
    }
}
