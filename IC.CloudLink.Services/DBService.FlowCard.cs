using IC.CloudLink.Services.Contracts;
using IC.Core.Entity.CloudLink.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IC.CloudLink.Services
{
    public partial class DBService
    {
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
        /// 添加新卡
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="iccId"></param>
        /// <returns></returns>
        public bool AddFlowCards(string openId, string iccId)
        {
            var users = GetUserByOpenId(openId);
            if (users != null && users.Count() > 0)
            {
                FlowCard flowCard = new FlowCard()
                {
                    ICCId = iccId,
                    OpenId = openId,
                    TotalFlow = 1024,
                    UsagedFlow = 0
                };
                users.First().FlowCards.Add(flowCard);
                cloudLinkDBContext.SaveChanges();

                return true;
            }
            return false;
        }
    }
}
