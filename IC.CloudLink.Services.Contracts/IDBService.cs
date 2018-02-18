using IC.Core.Entity.CloudLink.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace IC.CloudLink.Services.Contracts
{
    public interface IDBService
    {
        IEnumerable<User> GetUserByOpenId(string openId);
        bool IsRegister(string openId);
    }
}
