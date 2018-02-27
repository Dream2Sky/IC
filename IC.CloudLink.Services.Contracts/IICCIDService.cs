using IC.Core.Entity.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace IC.CloudLink.Services.Contracts
{
    public interface IICCIDService
    {
        bool IsValidICCID(string iccId);
        JObject GetICCIDCheckResult(string iccId);
    }
}
