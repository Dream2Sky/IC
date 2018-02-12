using IC.CloudLink.Services.Contracts;
using IC.Core.Entity.CloudLink.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IC.CloudLink.Services
{
    public class DBService : IDBService
    {
        protected CloudLinkDBContext cloudLinkDBContext;
        public DBService(CloudLinkDBContext _cloudLinkDBContext)
        {
            this.cloudLinkDBContext = _cloudLinkDBContext;
        }

        /// <summary>
        /// 根据openId获取用户
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public IEnumerable<User> GetUserByOpenId(string openId)
        {
            var res = cloudLinkDBContext.Users.Where(n => n.WxOpenId == openId);
            return res;
        }
    }
}
