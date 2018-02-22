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
        /// 获取用户流量卡集合
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public IEnumerable<FlowCard> GetFlowCards(string openId)
        {
            var users = GetUserByOpenId(openId);
            if (users != null && users.Count() > 0)
            {
                return users.First().FlowCards;
            }
            return null;
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
                Id = Guid.NewGuid().ToString(),
                WxOpenId = openId,
                Phone = phone,
                CreateTime = DateTime.Now,
                DelTime = DateTime.MinValue,
                IsDel = false
            };
            cloudLinkDBContext.Users.Add(user);
            cloudLinkDBContext.SaveChanges();
        }
    }
}
