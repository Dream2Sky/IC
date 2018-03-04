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
            var res = cloudLinkDBContext.Users.Include(n => n.FlowCards).Where(n => n.WxOpenId == openId && n.IsDel == false);
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
        /// 是否存在当前用户
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public bool IsExistedUser(string openId, ref User user)
        {
            var isExisted = false;
            IEnumerable<User> users = null;
            if (!string.IsNullOrWhiteSpace(openId))
            {
                users = GetUserByOpenId(openId);
                isExisted = users.Count() <= 0 ? false : true;
            }

            if (isExisted)
            {
                user = users.FirstOrDefault();
            }
            return isExisted;
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

        /// <summary>
        /// 微信充值成功回调
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool ReCharge(string openId, decimal amount)
        {
            bool res = false;
            var user = cloudLinkDBContext.Users.Include(n => n.ReChargeRecords).Where(o => o.WxOpenId == openId).FirstOrDefault();
            if (user == null)
            {
                return res;
            }
            user.Balance += amount;
            using (var trans = cloudLinkDBContext.Database.BeginTransaction())
            {
                try
                {
                    AddReChargeRecord(user, amount);
                    cloudLinkDBContext.SaveChanges();
                    trans.Commit();
                    res = true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    res = false;
                    throw;
                }
            }
            return res;
        }


        /// <summary>
        /// 添加一条充值记录
        /// </summary>
        /// <param name="user"></param>
        /// <param name="amount"></param>
        public void AddReChargeRecord(User user, decimal amount)
        {
            ReChargeRecord reChargeRecord = new ReChargeRecord()
            {
                UserId = user.Id,
                Amount = amount
            };
            cloudLinkDBContext.Users.SingleOrDefault(n=>n.Id == user.Id).ReChargeRecords.Add(reChargeRecord);
            cloudLinkDBContext.SaveChangesAsync();
        }
    }
}
