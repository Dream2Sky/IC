using IC.CloudLink.Services.Contracts;
using IC.Core.Entity.CloudLink.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IC.CloudLink.Services
{
    public partial class DBService
    {
        /// <summary>
        /// 根据openId获取用户
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public IEnumerable<User> GetUserByOpenId(string openId)
        {
            var res = cloudLinkDBContext.Users.Include(n => n.FlowCards).Where(n => n.WxOpenId == openId);
            return res;
        }

        /// <summary>
        /// 判断openId是否已经注册
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public bool IsRegister(string openId)
        {
            var isRegister = false;
            if (!string.IsNullOrWhiteSpace(openId))
            {
                var res = GetUserByOpenId(openId);
                isRegister = res.Count() <= 0 ? false : true;
            }
            return isRegister;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="openId"></param>
        /// <returns></returns>
        public void Register(string phone, string openId)
        {
            var user = new User()
            {
                WxOpenId = openId,
                Phone = phone
            };
            cloudLinkDBContext.Users.Add(user);
            cloudLinkDBContext.SaveChanges();
        }
    }
}
